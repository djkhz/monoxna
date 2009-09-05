#region License

/*
MIT License
Copyright © 2006 The Mono.Xna Team

All rights reserved.
 
Authors:
 * Stuart Carnie (stuart.carnie@gmail.com)
 * Lars Magnusson (lavima@gmail.com)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

#endregion License

using System;
using System.Threading;
using System.Collections.Generic;
using Tao.Sdl;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

#if NUNITTESTS
using Microsoft.Xna.Framework.Test;
#endif

namespace Microsoft.Xna.Framework
{
    public class Game : IDisposable
    {
        #region Private Fields
		
		private const long DefaultTargetElapsedTicks = 10000000L / 60L;
		
		private bool inRun;
        private bool isFixedTimeStep;
		private bool isMouseVisible;
		private bool isActive;
        private bool isExiting;

        GameComponentCollection components;
        List<IDrawable> visibleDrawable;
        List<IUpdateable> enabledUpdateable;

        GameServiceContainer services;
        bool disposed;

        GameTime gameTime;
        TimeSpan inactiveSleepTime;
        TimeSpan targetElapsedTime;
        
        Content.ContentManager content;
        GameWindow window;
        IGraphicsDeviceManager graphicsManager;
        IGraphicsDeviceService graphicsService;
        

        #endregion Private Fields

		#region Public Properties

        public GameComponentCollection Components {
            get { return components; }
        }

        public TimeSpan InactiveSleepTime {
            get { return inactiveSleepTime; }
            set { inactiveSleepTime = value; }
        }

        public bool IsActive {
            get { return isActive; }
        }

        public bool IsFixedTimeStep {
            get { return isFixedTimeStep; }
            set { isFixedTimeStep = value; }
        }

        public bool IsMouseVisible {
            get { return isMouseVisible; }
            set {
				if (isMouseVisible == value)
					return;
				isMouseVisible = value;
				Sdl.SDL_ShowCursor(isMouseVisible ? Sdl.SDL_ENABLE : Sdl.SDL_DISABLE); 
			}
        }

        public GameServiceContainer Services {
            get { return services; }
        }

        public TimeSpan TargetElapsedTime {
            get { return targetElapsedTime; }
            set { targetElapsedTime = value; }
        }

#if XNA_1_1
        internal
#else
        public
#endif
        ContentManager Content {
            get { return this.content; }

#if XNA_3_0
            set { this.content = value; }
#endif
        }

#if XNA_1_1
        internal
#else
        public
#endif
        GraphicsDevice GraphicsDevice {
            get {
                if (graphicsService == null)
                {
                    graphicsService = this.Services.GetService(typeof(IGraphicsDeviceService)) as IGraphicsDeviceService;
                    if (graphicsService == null)
                    	throw new InvalidOperationException();
                }
                return graphicsService.GraphicsDevice;
            }
        }


        public GameWindow Window
        {
            get { return window; }
        }

        #endregion Public Properties

        #region Constructors

        public Game()
        {
			isExiting = false;
			inRun = false;
			
            isFixedTimeStep = true;
            
			visibleDrawable = new List<IDrawable>();
            enabledUpdateable = new List<IUpdateable>();

            components = new GameComponentCollection();
            components.ComponentAdded += new EventHandler<GameComponentCollectionEventArgs>(GameComponentAdded);
            components.ComponentRemoved += new EventHandler<GameComponentCollectionEventArgs>(GameComponentRemoved);

            services = new GameServiceContainer();

            content = new ContentManager(services);

			
            gameTime = new GameTime(TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero);

            inactiveSleepTime = TimeSpan.FromTicks(0);
			targetElapsedTime = TimeSpan.FromTicks(DefaultTargetElapsedTicks);

            window =  new SdlGameWindow(this);
			isActive = true;
        }
		
		#endregion Constructors
		
        #region Destructor

        ~Game()
        {
            Dispose(false);
        }

        #endregion Destructor        

        #region Public Methods

#if XNA_3_0
        public void SuppressDraw()
        {
            throw new NotImplementedException();
        }
#endif

        public void ResetElapsedTime()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Exit()
        {
			isExiting = true;
        }

        public void Run()
        {
			if(inRun)
				throw new InvalidOperationException("Run Method called more than once");
			inRun = true;
			BeginRun();
			
			int result = Sdl.SDL_Init (Sdl.SDL_INIT_TIMER | Sdl.SDL_INIT_VIDEO);
			if (result == 0)
				Console.WriteLine("SDL initialized");
			else
				Console.WriteLine("Couldn't initialize SDL");
			
			graphicsManager = (IGraphicsDeviceManager)Services.GetService(typeof (IGraphicsDeviceManager));
            if (graphicsManager != null)
                graphicsManager.CreateDevice();
			

			graphicsService = (IGraphicsDeviceService)Services.GetService(typeof (IGraphicsDeviceService));
            if (graphicsService != null)
            {
                graphicsService.DeviceCreated += DeviceCreated;
                graphicsService.DeviceResetting += DeviceResetting;
                graphicsService.DeviceReset += DeviceReset;
                graphicsService.DeviceDisposing += DeviceDisposing;
            }     
			
			((SdlGameWindow)window).Create("", GraphicsDevice.PresentationParameters.BackBufferWidth, 
			                                GraphicsDevice.PresentationParameters.BackBufferHeight,
			                                GraphicsDevice.PresentationParameters.IsFullScreen);
			
			IsMouseVisible = IsMouseVisible;	// Set mouse visible now that SDL is initialized
			
			Initialize();
			            
            isActive = true;			            
			
			while (!isExiting)
				Tick ();
            EndRun();
			
			inRun = false;
        }

        public void Tick()
        {
			Sdl.SDL_Event sdlEvent;
			if (Sdl.SDL_PollEvent(out sdlEvent) != 0)
			{
				switch (sdlEvent.type)
				{
				case Sdl.SDL_QUIT:
					Exit();
					break;
				}
			}			
			
			TimeSpan updateTime = TimeSpan.FromMilliseconds(Sdl.SDL_GetTicks() - gameTime.TotalRealTime.TotalMilliseconds);
			if (isFixedTimeStep)
			{
				while (updateTime < TargetElapsedTime)
				{
					updateTime = TimeSpan.FromMilliseconds(Sdl.SDL_GetTicks() - gameTime.TotalRealTime.TotalMilliseconds);
				}				
				gameTime.ElapsedGameTime = TargetElapsedTime;
				gameTime.TotalGameTime = gameTime.TotalGameTime.Add(TargetElapsedTime);
			}
			else
			{
				gameTime.ElapsedGameTime = updateTime;
				gameTime.TotalGameTime = gameTime.TotalGameTime.Add(updateTime);
			}
			
			gameTime.ElapsedRealTime = updateTime;
			gameTime.TotalRealTime = gameTime.TotalRealTime.Add(updateTime);
			
			Update(gameTime);
			Draw(gameTime);
        }

        #endregion Public methods

        #region Protected Methods

#if XNA_3_0
        protected virtual bool ShowMissingRequirementMessage(Exception exception)
        {
            throw new NotImplementedException();
        }
#endif

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
				return;
            
			// Dispose managed
			if (disposing)
			{
                foreach (IGameComponent component in components)
                {
                    IDisposable disposable = component as IDisposable;
                    if (disposable != null)
                        disposable.Dispose();
                }
			}
				
			// Dispose unmanaged
			Sdl.SDL_Quit();				

            disposed = true;
            if (Disposed != null)
                Disposed(this, EventArgs.Empty);        
        }

        protected virtual bool BeginDraw()
        {
            return graphicsManager.BeginDraw();
        }

        protected virtual void BeginRun()
        {
        }

        protected virtual void Draw(GameTime gameTime)
        {
            foreach (IDrawable drawable in visibleDrawable)
            {
                drawable.Draw(gameTime);
            }
        }

        protected virtual void EndDraw()
        {
            graphicsManager.EndDraw();
        }

        protected virtual void EndRun()
        {
        }

        protected virtual void Initialize()
        {
            this.graphicsService = this.Services.GetService(typeof(IGraphicsDeviceService)) as IGraphicsDeviceService;

            foreach (IGameComponent component in components)
            {
                component.Initialize();
            }

           	LoadContent();
        }

        void DeviceCreated(object sender, EventArgs e)
        {
            LoadContent();
        }

        void DeviceDisposing(object sender, EventArgs e)
        {
            UnloadGraphicsContent(true);
        }

        void DeviceReset(object sender, EventArgs e)
        {
            LoadGraphicsContent(false);
        }

        void DeviceResetting(object sender, EventArgs e)
        {
            UnloadGraphicsContent(false);
        }

#if XNA_1_1
        internal
#else
        protected
#endif
        virtual void LoadContent()
        {
        }

#if XNA_1_1
#else
        [System.Obsolete("The LoadGraphicsContent method is obsolete and will be removed in the future. Use the LoadContent method instead.")]
#endif
        protected virtual void LoadGraphicsContent(bool loadAllContent)
        {
            //throw new NotImplementedException();
            // We don't have anything to be done here FIXME
        }

        protected virtual void OnActivated(object sender, EventArgs args)
        {
            if (Activated != null)
                Activated(sender, args);
        }

        protected virtual void OnDeactivated(object sender, EventArgs args)
        {
            if (Deactivated != null)
                Deactivated(sender, args);
        }

        protected virtual void OnExiting(object sender, EventArgs args)
        {
            if (Exiting != null)
                Exiting(sender, args);
        }

#if XNA_1_1
        internal
#else
        protected
#endif
        virtual void UnloadContent()
        {
        }

#if XNA_1_1
#else
        [Obsolete("The UnloadGraphicsContent method is obsolete and will be removed in the future.  Use the UnloadContent method instead.")]
#endif
        protected virtual void UnloadGraphicsContent(bool unloadAllContent)
        {
        }

        protected virtual void Update(GameTime gameTime)
        {
            foreach (IUpdateable updateable in enabledUpdateable)
            {
                updateable.Update(gameTime);
            }
        }

        #endregion Protected Methods

        #region Private Methods
		
		void DrawFrame()
        {
            if (BeginDraw())
            {
                Draw(gameTime);
                EndDraw();
            }
        }

        void WindowExiting(object sender, EventArgs e)
        {
            OnExiting(sender, e);
        }

        void WindowDeactivated(object sender, EventArgs e)
        {
            isActive = false;
            OnDeactivated(sender, e);
        }

        void WindowActivated(object sender, EventArgs e)
        {
            isActive = true;
            OnActivated(sender, e);
        }

        #region Game Component Collection Methods

        void GameComponentAdded(object sender, GameComponentCollectionEventArgs e)
        {
            IDrawable d = e.GameComponent as IDrawable;
            if (d != null)
            {
                d.DrawOrderChanged += DrawableDrawOrderChanged;
                d.VisibleChanged += DrawableVisibleChanged;

                if (d.Visible)
                    AddDrawable(d);
            }

            IUpdateable u = e.GameComponent as IUpdateable;
            if (u != null)
            {
                u.UpdateOrderChanged += UpdatableUpdateOrderChanged;
                u.EnabledChanged += UpdatableEnabledChanged;

                if (u.Enabled)
                    AddUpdatable(u);
            }
        }

        void GameComponentRemoved(object sender, GameComponentCollectionEventArgs e)
        {
            IDrawable d = e.GameComponent as IDrawable;
            if (d != null)
            {
                d.DrawOrderChanged -= DrawableDrawOrderChanged;
                d.VisibleChanged -= DrawableVisibleChanged;

                if (d.Visible)
                    visibleDrawable.Remove(d);
            }

            IUpdateable u = e.GameComponent as IUpdateable;
            if (u != null)
            {
                u.UpdateOrderChanged -= UpdatableUpdateOrderChanged;
                u.EnabledChanged -= UpdatableEnabledChanged;

                if (u.Enabled)
                    enabledUpdateable.Remove(u);
            }
        }

        #region Updatable Methods

        void AddUpdatable(IUpdateable u)
        {
            enabledUpdateable.Add(u);
            enabledUpdateable.Sort(UpdatableComparison);
        }

        void UpdatableEnabledChanged(object sender, EventArgs e)
        {
            IUpdateable u = (IUpdateable)sender;
            if (u.Enabled)
                AddUpdatable(u);
            else
                enabledUpdateable.Remove(u);
        }

        void UpdatableUpdateOrderChanged(object sender, EventArgs e)
        {
            enabledUpdateable.Sort(UpdatableComparison);
        }

        static int UpdatableComparison(IUpdateable x, IUpdateable y)
        {
            return x.UpdateOrder - y.UpdateOrder;
        }

        #endregion Updatable Methods

        #region Drawable Methods

        void AddDrawable(IDrawable d)
        {
            visibleDrawable.Add(d);
            visibleDrawable.Sort(DrawableComparison);
        }

        void DrawableVisibleChanged(object sender, EventArgs e)
        {
            IDrawable d = (IDrawable)sender;
            if (d.Visible)
                AddDrawable(d);
            else
                visibleDrawable.Remove(d);
        }

        void DrawableDrawOrderChanged(object sender, EventArgs e)
        {
            visibleDrawable.Sort(DrawableComparison);
        }

        static int DrawableComparison(IDrawable x, IDrawable y)
        {
            return x.DrawOrder - y.DrawOrder;
        }

        #endregion Drawable Methods 

        #endregion Game Component Collection Methods

        #endregion Private Methods

        #region Public Events

        public event EventHandler Activated;
        public event EventHandler Deactivated;
        public event EventHandler Disposed;
        public event EventHandler Exiting;

        #endregion Public Events

        #region Internal Members

        #endregion Internal Members
    }
}
