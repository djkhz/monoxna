#region License
/*
MIT License
Copyright � 2006 The Mono.Xna Team
http://www.taoframework.com
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Microsoft.Xna.Framework.Graphics
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential)]
	public struct CompiledShader
	{
		
		public byte[] GetShaderCode() { throw new NotImplementedException(); }
		public string ErrorsAndWarnings { get { throw new NotImplementedException(); } }
		public bool Success { get { throw new NotImplementedException(); } }
		public CompiledShader(byte[] compiledShaderCode, string errors) { throw new NotImplementedException(); }
		public string[] GetSamplers() { throw new NotImplementedException(); }
		public ShaderSemantic[] GetInputSemantics() { throw new NotImplementedException(); }
		public ShaderSemantic[] GetOutputSemantics() { throw new NotImplementedException(); }
		public Version ShaderVersion { get { throw new NotImplementedException(); } }
		public int ShaderSize { get { throw new NotImplementedException(); } }
		public override string ToString() { throw new NotImplementedException(); }
	}
}