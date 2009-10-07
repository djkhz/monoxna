#region License
/*
MIT License
Copyright © 2009 The Mono.Xna Team

All rights reserved.

Authors:
Lars Magnusson (lavima)

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
using System.Xml;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using MonoDevelop.Projects;
using MonoDevelop.Projects.Dom;

namespace MonoDevelop.Xna
{	
	
	public class ContentProject : DotNetProject
    {
		#region Fields
		
		[ItemProperty("XnaFrameworkVersion")]
		protected string xnaFrameworkVersion = "v2.0";

		#endregion
		
		#region Properties
		
		private ContentSourceCollection contentSources;
		public ContentSourceCollection ContentSources {
			get { return contentSources; }	
		}
		
		#endregion
		
        #region Constructors
		
		public ContentProject (string languageName)
			: base (languageName)
		{
		}

		public ContentProject (string language, ProjectCreateInformation info, XmlElement projectOptions)
			: base (language, info, projectOptions)
		{
			contentSources = new ContentSourceCollection();
			Items.Bind(contentSources);
		}
		
		#endregion


        #region DotNetProject Overrides
		
		public override string ProjectType {
			get  { return "Content"; }
		}
		
		protected override BuildResult DoBuild (IProgressMonitor monitor, string itemConfiguration)
        {
		
            return base.DoBuild(monitor, itemConfiguration); 
        }
		
		public override void Save (IProgressMonitor monitor)
		{
			base.Save (monitor);
		}


        #endregion
	}
}