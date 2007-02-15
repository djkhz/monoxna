#region License
/*
MIT License
Copyright � 2006 The Mono.Xna Team
http://www.taoframework.com
All rights reserved.

Authors
 * Alan McGovern

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
using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework.Design;
using System.Text;

namespace Microsoft.Xna.Framework
{
    [Serializable, StructLayout(LayoutKind.Sequential)]
    [TypeConverter(typeof(Vector2Converter))]
    public struct Vector2 : IEquatable<Vector2>
    {
        #region Private Fields

        private static Vector2 zeroVector = new Vector2(0f, 0f);
        private static Vector2 unitVector = new Vector2(1f, 1f);
        private static Vector2 unitXVector = new Vector2(1f, 0f);
        private static Vector2 unitYVector = new Vector2(0f, 1f);

        #endregion Private Fields


        #region Public Fields

        public float X;
        public float Y;

        #endregion Public Fields


        #region Properties

        public static Vector2 Zero
        {
            get { return zeroVector; }
        }

        public static Vector2 One
        {
            get { return unitVector; }
        }

        public static Vector2 UnitX
        {
            get { return unitXVector; }
        }

        public static Vector2 UnitY
        {
            get { return unitYVector; }
        }

        #endregion Properties


        #region Constructors

        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector2(float value)
        {
            this.X = value;
            this.Y = value;
        }

        #endregion Constructors


        #region Public Methods

        public static Vector2 Add(Vector2 value1, Vector2 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            return value1;
        }

        public static void Add(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.X = value1.X + value2.X;
            result.Y = value1.Y + value2.Y;
        }

        public static Vector2 Barycentric(Vector2 value1, Vector2 value2, Vector2 value3, float amount1, float amount2)
        {
            throw new NotImplementedException();
        }

        public static void Barycentric(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, float amount1, float amount2, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public static Vector2 CatmullRom(Vector2 value1, Vector2 value2, Vector2 value3, Vector2 value4, float amount)
        {
            throw new NotImplementedException();
        }

        public static void CatmullRom(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, ref Vector2 value4, float amount, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public static Vector2 Clamp(Vector2 value1, Vector2 min, Vector2 max)
        {
            Clamp(ref value1, ref min, ref max, out value1);
            return value1;
        }

        public static void Clamp(ref Vector2 value1, ref Vector2 min, ref Vector2 max, out Vector2 result)
        {
            result.X = MathHelper.Clamp(value1.X, min.X, max.X);
            result.Y = MathHelper.Clamp(value1.Y, min.Y, max.Y);
        }

        public static float Distance(Vector2 value1, Vector2 value2)
        {
            float result;
            DistanceSquared(ref value1, ref value2, out result);
            return (float)Math.Sqrt(result);
        }

        public static void Distance(ref Vector2 value1, ref Vector2 value2, out float result)
        {
            DistanceSquared(ref value1, ref value2, out result);
            result = (float)Math.Sqrt(result);
        }

        public static float DistanceSquared(Vector2 value1, Vector2 value2)
        {
            float result;
            DistanceSquared(ref value1, ref value2, out result);
            return result;
        }

        public static void DistanceSquared(ref Vector2 value1, ref Vector2 value2, out float result)
        {
            result = (value1.X - value2.X) * (value1.X - value2.X) + (value1.Y - value2.Y) * (value1.Y - value2.Y);
        }

        public static Vector2 Divide(Vector2 value1, Vector2 value2)
        {
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            return value1;
        }

        public static void Divide(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.X = value1.X / value2.X;
            result.Y = value1.Y / value2.Y;
        }

        public static Vector2 Divide(Vector2 value1, float divider)
        {
            float factor = 1 / divider;
            value1.X *= factor;
            value1.Y *= factor;
            return value1;
        }

        public static void Divide(ref Vector2 value1, float divider, out Vector2 result)
        {
            float factor = 1 / divider;
            result.X = value1.X * factor;
            result.Y = value1.Y * factor;
        }

        public static float Dot(Vector2 value1, Vector2 value2)
        {
            return value1.X * value2.X + value1.Y * value2.Y;
        }

        public static void Dot(ref Vector2 value1, ref Vector2 value2, out float result)
        {
            result = value1.X * value2.X + value1.Y * value2.Y;
        }

        public bool Equals(Vector2 other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            return (obj is Vector2) ? this == ((Vector2)obj) : false;
        }

        public override int GetHashCode()
        {
            return (int)(this.X + this.Y);
        }

        public static Vector2 Hermite(Vector2 value1, Vector2 tangent1, Vector2 value2, Vector2 tangent2, float amount)
        {
            throw new NotImplementedException();
        }

        public static void Hermite(ref Vector2 value1, ref Vector2 tangent1, ref Vector2 value2, ref Vector2 tangent2, float amount, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public float Length()
        {
            float result;
            DistanceSquared(ref this, ref zeroVector, out result);
            return (float)Math.Sqrt(result);
        }

        public float LengthSquared()
        {
            float result;
            DistanceSquared(ref this, ref zeroVector, out result);
            return result;
        }

        public static Vector2 Lerp(Vector2 value1, Vector2 value2, float amount)
        {
            throw new NotImplementedException();
        }

        public static void Lerp(ref Vector2 value1, ref Vector2 value2, float amount, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public void Normalize()
        {
            Normalize(ref this, out this);
        }

        public static Vector2 Normalize(Vector2 value)
        {
            Normalize(ref value, out value);
            return value;
        }

        public static void Normalize(ref Vector2 value, out Vector2 result)
        {
            float factor;
            Distance(ref value, ref zeroVector, out factor);
            factor = 1 / factor;
            result.X = value.X * factor;
            result.Y = value.Y * factor;
        }

        public static Vector2 Max(Vector2 value1, Vector2 value2)
        {
            Max(ref value1, ref value2, out value1);
            return value1;
        }

        public static void Max(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result = new Vector2(value1.X > value2.X ? value1.X : value2.X,
                                 value1.Y > value2.Y ? value1.Y : value2.Y);
        }

        public static Vector2 Min(Vector2 value1, Vector2 value2)
        {
            Min(ref value1, ref value2, out value1);
            return value1;
        }

        public static void Min(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result = new Vector2(value1.X < value2.X ? value1.X : value2.X,
                     value1.Y < value2.Y ? value1.Y : value2.Y);
        }

        public static Vector2 Multiply(Vector2 value1, Vector2 value2)
        {
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            return value1;
        }

        public static Vector2 Multiply(Vector2 value1, float scaleFactor)
        {
            value1.X *= scaleFactor;
            value1.Y *= scaleFactor;
            return value1;
        }

        public static void Multiply(ref Vector2 value1, float scaleFactor, out Vector2 result)
        {
            result.X = value1.X * scaleFactor;
            result.Y = value1.Y * scaleFactor;
        }

        public static void Multiply(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.X = value1.X * value2.X;
            result.Y = value1.Y * value2.Y;
        }

        public static Vector2 Negate(Vector2 value)
        {
            value.X = -value.X;
            value.Y = -value.Y;
            return value;
        }

        public static void Negate(ref Vector2 value, out Vector2 result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
        }

        public static Vector2 SmoothStep(Vector2 value1, Vector2 value2, float amount)
        {
            throw new NotImplementedException();
        }

        public static void SmoothStep(ref Vector2 value1, ref Vector2 value2, float amount, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public static Vector2 Subtract(Vector2 value1, Vector2 value2)
        {
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            return value1;
        }

        public static void Subtract(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result.X = value1.X - value2.X;
            result.Y = value1.Y - value2.Y;
        }

        public static Vector2 Transform(Vector2 position, Matrix matrix)
        {
            throw new NotImplementedException();
        }

        public static void Transform(ref Vector2 position, ref Matrix matrix, out Vector2 result)
        {
            throw new NotImplementedException();
        }

        public static Vector2 TransformNormal(Vector2 normal, Matrix matrix)
        {
            Vector2.TransformNormal(ref normal, ref matrix, out normal);
            return normal;
        }

        public static void TransformNormal(ref Vector2 normal, ref Matrix matrix, out Vector2 result)
        {
            result = new Vector2((normal.X * matrix.M11) + (normal.Y * matrix.M21),
                                 (normal.X * matrix.M12) + (normal.Y * matrix.M22));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(24);
            sb.Append("{X:");
            sb.Append(this.X);
            sb.Append(" Y:");
            sb.Append(this.Y);
            sb.Append("}");
            return sb.ToString();
        }
        #endregion Public Methods


        #region Operators

        public static Vector2 operator -(Vector2 value)
        {
            value.X = -value.X;
            value.Y = -value.Y;
            return value;
        }


        public static bool operator ==(Vector2 value1, Vector2 value2)
        {
            return value1.X == value2.X && value1.Y == value2.Y;
        }


        public static bool operator !=(Vector2 value1, Vector2 value2)
        {
            return value1.X != value2.X || value1.Y != value2.Y;
        }


        public static Vector2 operator +(Vector2 value1, Vector2 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            return value1;
        }


        public static Vector2 operator -(Vector2 value1, Vector2 value2)
        {
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            return value1;
        }


        public static Vector2 operator *(Vector2 value1, Vector2 value2)
        {
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            return value1;
        }


        public static Vector2 operator *(Vector2 value, float scaleFactor)
        {
            value.X *= scaleFactor;
            value.Y *= scaleFactor;
            return value;
        }


        public static Vector2 operator *(float scaleFactor, Vector2 value)
        {
            value.X *= scaleFactor;
            value.Y *= scaleFactor;
            return value;
        }


        public static Vector2 operator /(Vector2 value1, Vector2 value2)
        {
            value1.X /= value2.X;
            value1.Y /= value2.Y;
            return value1;
        }


        public static Vector2 operator /(Vector2 value1, float divider)
        {
            float factor = 1 / divider;
            value1.X *= factor;
            value1.Y *= factor;
            return value1;
        }

        #endregion Operators
    }
}