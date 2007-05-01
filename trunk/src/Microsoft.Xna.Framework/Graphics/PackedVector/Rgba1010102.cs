#region License
/*
MIT License
Copyright � 2006 The Mono.Xna Team

All rights reserved.

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

using Microsoft.Xna.Framework;
using System;

namespace Microsoft.Xna.Framework.Graphics.PackedVector
{
    public struct Rgba1010102 : IPackedVector<uint>, IPackedVector, IEquatable<Rgba1010102>
    {
        public Rgba1010102(Vector4 vector){ throw new NotImplementedException(); }
        
        public Rgba1010102(float x, float y, float z, float w){ throw new NotImplementedException(); }

        public static bool operator !=(Rgba1010102 a, Rgba1010102 b){ throw new NotImplementedException(); }
        
        public static bool operator ==(Rgba1010102 a, Rgba1010102 b){ throw new NotImplementedException(); }

        [CLSCompliant(false)]
        public uint PackedValue { get{ throw new NotImplementedException(); } set{ throw new NotImplementedException(); } }
        
        public override bool Equals(object obj){ throw new NotImplementedException(); }
        
        public bool Equals(Rgba1010102 other){ throw new NotImplementedException(); }
        
        public override int GetHashCode(){ throw new NotImplementedException(); }
        
        public override string ToString(){ throw new NotImplementedException(); }
        
        public Vector4 ToVector4(){ throw new NotImplementedException(); }

        void IPackedVector.PackFromVector4(Vector4 vector)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}