using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

namespace Frostfire.Math
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Vector2 : IEquatable<Vector2>
    {
        public float X, Y;

        public static readonly int SIZE_IN_BYTES = Marshal.SizeOf(typeof(Vector2));

        public static readonly Vector2 ZERO = new Vector2(0.0f);
        public static readonly Vector2 ONE = new Vector2(1.0f);

        public static readonly Vector2 UNIT_X = new Vector2(1.0f, 0.0f);
        public static readonly Vector2 UNIT_Y = new Vector2(0.0f, 1.0f);

        public static readonly Vector2 MIN_VALUE = new Vector2(Single.MinValue);
        public static readonly Vector2 MAX_VALUE = new Vector2(Single.MaxValue);

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

        public float this[int index]
        {
            get
            {
                if (index == 0)
                    return this.X;
                if (index == 1)
                    return this.Y;
                
                throw new ArgumentOutOfRangeException("index", "Index out of range.");
            }
            set
            {
                if (index == 0)
                    this.X = value;
                if (index == 1)
                    this.Y = value;

                throw new ArgumentOutOfRangeException("index", "Index out of range.");
            }
        }


        #region Operations

        public static void Add(ref Vector2 left, ref Vector2 right, out Vector2 result)
        {
            result = new Vector2(left.X + right.X, left.Y + right.Y);
        }
        public static Vector2 Add(ref Vector2 left, ref Vector2 right)
        {
            return new Vector2(left.X + right.X, left.Y + right.Y);
        }
        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X + right.X, left.Y + right.Y);
        }
        public void Add(ref Vector2 value)
        {
            this.X += value.X;
            this.Y += value.Y;
        }
        public void Add(Vector2 value)
        {
            this.X += value.X;
            this.Y += value.Y;
        }

        public static void Add(ref Vector2 left, float right, out Vector2 result)
        {
            result = new Vector2(left.X + right, left.Y + right);
        }
        public static Vector2 Add(ref Vector2 left, float right)
        {
            return new Vector2(left.X + right, left.Y + right);
        }
        public static Vector2 operator +(Vector2 left, float right)
        {
            return new Vector2(left.X + right, left.Y + right);
        }
        public static Vector2 operator +(float left, Vector2 right)
        {
            return new Vector2(left + right.X, left + right.Y);
        }
        public void Add(float value)
        {
            this.X += value;
            this.Y += value;
        }

        public static void Subtract(ref Vector2 left, ref Vector2 right, out Vector2 result)
        {
            result = new Vector2(left.X - right.X, left.Y - right.Y);
        }
        public static Vector2 Subtract(ref Vector2 left, ref Vector2 right)
        {
            return new Vector2(left.X - right.X, left.Y - right.Y);
        }
        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X - right.X, left.Y - right.Y);
        }
        public void Subtract(ref Vector2 value)
        {
            this.X -= value.X;
            this.Y -= value.Y;
        }
        public void Subtract(Vector2 value)
        {
            this.X -= value.X;
            this.Y -= value.Y;
        }

        public static void Subtract(ref Vector2 left, float right, out Vector2 result)
        {
            result = new Vector2(left.X - right, left.Y - right);
        }
        public static void Subtract(float left, ref Vector2 right, out Vector2 result)
        {
            result = new Vector2(left - right.X, left - right.Y);
        }
        public static Vector2 Subtract(ref Vector2 left, float right)
        {
            return new Vector2(left.X - right, left.Y - right);
        }
        public static Vector2 Subtract(float left, ref Vector2 right)
        {
            return new Vector2(left - right.X, left - right.Y);
        }
        public static Vector2 operator -(Vector2 left, float right)
        {
            return new Vector2(left.X - right, left.Y - right);
        }
        public static Vector2 operator -(float left, Vector2 right)
        {
            return new Vector2(left - right.X, left - right.Y);
        }
        public void Subtract(float value)
        {
            this.X -= value;
            this.Y -= value;
        }

        public static void Multiply(ref Vector2 left, ref Vector2 right, out Vector2 result)
        {
            result = new Vector2(left.X * right.X, left.Y * right.Y);
        }
        public static Vector2 Multiply(ref Vector2 left, ref Vector2 right)
        {
            return new Vector2(left.X * right.X, left.Y * right.Y);
        }
        public static Vector2 operator *(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X * right.X, left.Y * right.Y);
        }
        public void Multiply(ref Vector2 value)
        {
            this.X *= value.X;
            this.Y *= value.Y;
        }
        public void Multiply(Vector2 value)
        {
            this.X *= value.X;
            this.Y *= value.Y;
        }

        public static void Multiply(ref Vector2 left, float right, out Vector2 result)
        {
            result = new Vector2(left.X * right, left.Y * right);
        }
        public static Vector2 Multiply(ref Vector2 left, float right)
        {
            return new Vector2(left.X * right, left.Y * right);
        }
        public static Vector2 operator *(Vector2 left, float right)
        {
            return new Vector2(left.X * right, left.Y * right);
        }
        public static Vector2 operator *(float left, Vector2 right)
        {
            return new Vector2(right.X * left, right.Y * left);
        }
        public void Multiply(float value)
        {
            this.X *= value;
            this.Y *= value;
        }

        public static void Divide(ref Vector2 left, ref Vector2 right, out Vector2 result)
        {
            result = new Vector2(left.X / right.X, left.Y / right.Y);
        }
        public static Vector2 Divide(ref Vector2 left, ref Vector2 right)
        {
            return new Vector2(left.X / right.X, left.Y / right.Y);
        }
        public static Vector2 operator /(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X / right.X, left.Y / right.Y);
        }
        public void Divide(ref Vector2 value)
        {
            this.X /= value.X;
            this.Y /= value.Y;
        }
        public void Divide(Vector2 value)
        {
            this.X /= value.X;
            this.Y /= value.Y;
        }

        public static void Divide(ref Vector2 left, float right, out Vector2 result)
        {
            result = new Vector2(left.X / right, left.Y / right);
        }
        public static void Divide(float left, ref Vector2 right, out Vector2 result)
        {
            result = new Vector2(left / right.X, left / right.Y);
        }
        public static Vector2 Divide(ref Vector2 left, float right)
        {
            return new Vector2(left.X / right, left.Y / right);
        }
        public static Vector2 Divide(float left, ref Vector2 right)
        {
            return new Vector2(left / right.X, left / right.Y);
        }
        public static Vector2 operator /(Vector2 left, float right)
        {
            return new Vector2(left.X / right, left.Y / right);
        }
        public static Vector2 operator /(float left, Vector2 right)
        {
            return new Vector2(left / right.X, left / right.Y);
        }
        public void Divide(float value)
        {
            this.X *= value;
            this.Y *= value;
        }

        public static void Negate(ref Vector2 value, out Vector2 result)
        {
            result = new Vector2(-value.X, -value.Y);
        }
        public static Vector2 Negate(ref Vector2 value)
        {
            return new Vector2(-value.X, -value.Y);
        }
        public static Vector2 operator -(Vector2 value)
        {
            return new Vector2(-value.X, -value.Y);
        }
        public void Negate()
        {
            this.X = -this.X;
            this.Y = -this.Y;
        }

        #endregion


        #region Comparison

        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode() * 397) ^ Y.GetHashCode();
            }
        }

        public bool Equals(ref Vector2 value)
        {
            return
                System.Math.Abs(this.X - value.X) < FMath.EPSILON &&
                System.Math.Abs(this.Y - value.Y) < FMath.EPSILON;
        }
        public bool Equals(Vector2 value)
        {
            return Equals(ref value);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            return this.Equals((Vector2)obj);
        }
        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return left.Equals(ref right);
        }
        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !left.Equals(ref right);
        }

        #endregion


        #region Functions

        public static void Abs(ref Vector2 value, out Vector2 result)
        {
            result.X = System.Math.Abs(value.X);
            result.Y = System.Math.Abs(value.Y);
        }
        public static Vector2 Abs(ref Vector2 value)
        {
            Vector2 result;
            Abs(ref value, out result);
            return result;
        }
        public static Vector2 Abs(Vector2 value)
        {
            Vector2 result;
            Abs(ref value, out result);
            return result;
        }
        public void Abs()
        {
            Abs(ref this, out this);
        }

        public static void Barycentric(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, float factor1, float factor2, out Vector2 result)
        {
            result = new Vector2(
                (value1.X + (factor1 * (value2.X - value1.X))) + (factor2 * (value3.X - value1.X)),
                (value1.Y + (factor1 * (value2.Y - value1.Y))) + (factor2 * (value3.Y - value1.Y)));
        }
        public static Vector2 Barycentric(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, float factor1, float factor2)
        {
            Vector2 result;
            Barycentric(ref value1, ref value2, ref value3, factor1, factor2, out result);
            return result;
        }
        public static Vector2 Barycentric(Vector2 value1, Vector2 value2, Vector2 value3, float factor1, float factor2)
        {
            Vector2 result;
            Barycentric(ref value1, ref value2, ref value3, factor1, factor2, out result);
            return result;
        }

        public static void CatmullRom(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, ref Vector2 value4, float factor, out Vector2 result)
        {
            float squared = factor * factor;
            float cubed = factor * squared;

            result.X = 0.5f * ((((2.0f * value2.X) + ((-value1.X + value3.X) * factor)) +
                (((((2.0f * value1.X) - (5.0f * value2.X)) + (4.0f * value3.X)) - value4.X) * squared)) +
                ((((-value1.X + (3.0f * value2.X)) - (3.0f * value3.X)) + value4.X) * cubed));

            result.Y = 0.5f * ((((2.0f * value2.Y) + ((-value1.Y + value3.Y) * factor)) +
                (((((2.0f * value1.Y) - (5.0f * value2.Y)) + (4.0f * value3.Y)) - value4.Y) * squared)) +
                ((((-value1.Y + (3.0f * value2.Y)) - (3.0f * value3.Y)) + value4.Y) * cubed));
        }
        public static Vector2 CatmullRom(ref Vector2 value1, ref Vector2 value2, ref Vector2 value3, ref Vector2 value4, float factor)
        {
            Vector2 result;
            CatmullRom(ref value1, ref value2, ref value3, ref value4, factor, out result);
            return result;
        }
        public static Vector2 CatmullRom(Vector2 value1, Vector2 value2, Vector2 value3, Vector2 value4, float factor)
        {
            Vector2 result;
            CatmullRom(ref value1, ref value2, ref value3, ref value4, factor, out result);
            return result;
        }

        public static void Clamp(ref Vector2 value, ref Vector2 min, ref Vector2 max, out Vector2 result)
        {
            result = new Vector2(
                FMath.Clamp(value.X, min.X, max.X),
                FMath.Clamp(value.Y, min.Y, max.Y));
        }
        public static Vector2 Clamp(ref Vector2 value, ref Vector2 min, ref Vector2 max)
        {
            Vector2 result;
            Clamp(ref value, ref min, ref max, out result);
            return result;
        }
        public static Vector2 Clamp(Vector2 value, Vector2 min, Vector2 max)
        {
            Vector2 result;
            Clamp(ref value, ref min, ref max, out result);
            return result;
        }
        public void Clamp(ref Vector2 min, ref Vector2 max)
        {
            Clamp(ref this, ref min, ref max, out this);
        }
        public void Clamp(Vector2 min, Vector2 max)
        {
            Clamp(ref this, ref min, ref max, out this);
        }

        public static void Cross(ref Vector2 left, ref Vector2 right, out float result)
        {
            result = left.X * right.Y - right.X * left.Y;
        }
        public static float Cross(ref Vector2 left, ref Vector2 right)
        {
            return left.X * right.Y - right.X * left.Y;
        }
        public static float Cross(Vector2 left, Vector2 right)
        {
            return left.X * right.Y - right.X * left.Y;
        }

        public static void Distance(ref Vector2 left, ref Vector2 right, out float result)
        {
            float diffX = left.X - right.X;
            float diffY = left.Y - right.Y;
            result = (float)System.Math.Sqrt(diffX * diffX + diffY * diffY);
        }
        public static float Distance(ref Vector2 left, ref Vector2 right)
        {
            float result;
            Distance(ref left, ref right, out result);
            return result;
        }
        public static float Distance(Vector2 left, Vector2 right)
        {
            float result;
            Distance(ref left, ref right, out result);
            return result;
        }

        public static void DistanceSq(ref Vector2 left, ref Vector2 right, out float result)
        {
            float diffX = left.X - right.X;
            float diffY = left.Y - right.Y;
            result = diffX * diffX + diffY * diffY;
        }
        public static float DistanceSq(ref Vector2 left, ref Vector2 right)
        {
            float result;
            DistanceSq(ref left, ref right, out result);
            return result;
        }
        public static float DistanceSq(Vector2 left, Vector2 right)
        {
            float result;
            DistanceSq(ref left, ref right, out result);
            return result;
        }

        public static void Dot(ref Vector2 left, ref Vector2 right, out float result)
        {
            result = left.X * right.X + left.Y * right.Y;
        }
        public static float Dot(ref Vector2 left, ref Vector2 right)
        {
            return left.X * right.X + left.Y * right.Y;
        }
        public static float Dot(Vector2 left, Vector2 right)
        {
            return left.X * right.X + left.Y * right.Y;
        }

        public static void Hermite(ref Vector2 value1, ref Vector2 tangent1, ref Vector2 value2, ref Vector2 tangent2, float factor, out Vector2 result)
        {
            float squared = factor * factor;
            float cubed = factor * squared;
            float part1 = ((2.0f * cubed) - (3.0f * squared)) + 1.0f;
            float part2 = (-2.0f * cubed) + (3.0f * squared);
            float part3 = (cubed - (2.0f * squared)) + factor;
            float part4 = cubed - squared;

            result.X = (((value1.X * part1) + (value2.X * part2)) + (tangent1.X * part3)) + (tangent2.X * part4);
            result.Y = (((value1.Y * part1) + (value2.Y * part2)) + (tangent1.Y * part3)) + (tangent2.Y * part4);
        }
        public static Vector2 Hermite(ref Vector2 value1, ref Vector2 tangent1, ref Vector2 value2, ref Vector2 tangent2, float factor)
        {
            Vector2 result;
            Hermite(ref value1, ref tangent1, ref value2, ref tangent2, factor, out result);
            return result;
        }
        public static Vector2 Hermite(Vector2 value1, Vector2 tangent1, Vector2 value2, Vector2 tangent2, float factor)
        {
            Vector2 result;
            Hermite(ref value1, ref tangent1, ref value2, ref tangent2, factor, out result);
            return result;
        }

        public static float Length(ref Vector2 value)
        {
            return (float)System.Math.Sqrt(value.X * value.X + value.Y * value.Y);
        }
        public static float Length(Vector2 value)
        {
            return (float)System.Math.Sqrt(value.X * value.X + value.Y * value.Y);
        }
        public float Length()
        {
            return Length(ref this);
        }

        public static float LengthSq(ref Vector2 value)
        {
            return value.X * value.X + value.Y * value.Y;
        }
        public static float LengthSq(Vector2 value)
        {
            return value.X * value.X + value.Y * value.Y;
        }
        public float LengthSq()
        {
            return LengthSq(ref this);
        }

        public static void Lerp(ref Vector2 start, ref Vector2 end, float factor, out Vector2 result)
        {
            result = new Vector2(
                FMath.Lerp(start.X, end.X, factor),
                FMath.Lerp(start.Y, end.Y, factor));
        }
        public static Vector2 Lerp(ref Vector2 start, ref Vector2 end, float factor)
        {
            Vector2 result;
            Lerp(ref start, ref end, factor, out result);
            return result;
        }
        public static Vector2 Lerp(Vector2 start, Vector2 end, float factor)
        {
            Vector2 result;
            Lerp(ref start, ref end, factor, out result);
            return result;
        }

        public static void Maximize(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result = new Vector2(
                value1.X <= value2.X ? value2.X : value1.X,
                value1.Y <= value2.Y ? value2.Y : value1.Y);
        }
        public static Vector2 Maximize(ref Vector2 value1, ref Vector2 value2)
        {
            Vector2 result;
            Maximize(ref value1, ref value2, out result);
            return result;
        }
        public static Vector2 Maximize(Vector2 value1, Vector2 value2)
        {
            Vector2 result;
            Maximize(ref value1, ref value2, out result);
            return result;
        }
        public void Maximize(ref Vector2 value)
        {
            Maximize(ref this, ref value, out this);
        }
        public void Maximize(Vector2 value)
        {
            Maximize(ref this, ref value, out this);
        }

        public static void Minimize(ref Vector2 value1, ref Vector2 value2, out Vector2 result)
        {
            result = new Vector2(
                value1.X >= value2.X ? value2.X : value1.X,
                value1.Y >= value2.Y ? value2.Y : value1.Y);
        }
        public static Vector2 Minimize(ref Vector2 value1, ref Vector2 value2)
        {
            Vector2 result;
            Minimize(ref value1, ref value2, out result);
            return result;
        }
        public static Vector2 Minimize(Vector2 value1, Vector2 value2)
        {
            Vector2 result;
            Minimize(ref value1, ref value2, out result);
            return result;
        }
        public void Minimize(ref Vector2 value)
        {
            Minimize(ref this, ref value, out value);
        }
        public void Minimize(Vector2 value)
        {
            Minimize(ref this, ref value, out value);
        }

        /// <summary>
        /// Returns the value of the vector's largest component.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static void Max(ref Vector2 value, out float result)
        {
            result = System.Math.Max(value.X, value.Y);
        }
        public static float Max(ref Vector2 value)
        {
            return System.Math.Max(value.X, value.Y);
        }
        public static float Max(Vector2 value)
        {
            return System.Math.Max(value.X, value.Y);
        }
        public float Max()
        {
            return Max(ref this);
        }

        /// <summary>
        /// Returns the value of the vector's smallest component.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void Min(ref Vector2 value, out float result)
        {
            result = System.Math.Min(value.X, value.Y);
        }
        public static float Min(ref Vector2 value)
        {
            return System.Math.Min(value.X, value.Y);
        }
        public static float Min(Vector2 value)
        {
            return System.Math.Min(value.X, value.Y);
        }
        public float Min()
        {
            return Min(ref this);
        }

        public static void Normalize(ref Vector2 value, out Vector2 result)
        {
            float lengthSq = value.LengthSq();
            if (lengthSq < FMath.EPSILON)
            {
                result = ZERO;
                return;
            }
            float lengthInverse = 1.0f / FMath.Sqrt(lengthSq);
            result = new Vector2(value.X * lengthInverse, value.Y * lengthInverse);
        }
        public static Vector2 Normalize(ref Vector2 value)
        {
            Vector2 result;
            Normalize(ref value, out result);
            return result;
        }
        public static Vector2 Normalize(Vector2 value)
        {
            Vector2 result;
            Normalize(ref value, out result);
            return result;
        }
        public void Normalize()
        {
            Normalize(ref this, out this);
        }

        public static void Transform(ref Vector2 value, ref Matrix transformation, out Vector2 result)
        {
            float invW = 1.0f /
                         (transformation.M14 * value.X +
                          transformation.M24 * value.Y +
                          transformation.M44);
            result.X = (transformation.M11 * value.X +
                        transformation.M21 * value.Y +
                        transformation.M41) * invW;
            result.Y = (transformation.M12 * value.X +
                        transformation.M22 * value.Y +
                        transformation.M42) * invW;
        }
        public static Vector2 Transform(ref Vector2 value, ref Matrix transformation)
        {
            Vector2 result;
            Transform(ref value, ref transformation, out result);
            return result;
        }
        public static Vector2 Transform(Vector2 value, Matrix transformation)
        {
            Vector2 result;
            Transform(ref value, ref transformation, out result);
            return result;
        }
        public void Transform(ref Matrix transformation)
        {
            Transform(ref this, ref transformation, out this);
        }
        public void Transform(Matrix transformation)
        {
            Transform(ref this, ref transformation, out this);
        }

        public static void TransformNormal(ref Vector2 value, ref Matrix transformation, out Vector2 result)
        {
            result.X = transformation.M11 * value.X +
                       transformation.M21 * value.Y;
            result.Y = transformation.M12 * value.X +
                       transformation.M22 * value.Y;
        }
        public static Vector2 TransformNormal(ref Vector2 value, ref Matrix transformation)
        {
            Vector2 result;
            TransformNormal(ref value, ref transformation, out result);
            return result;
        }
        public static Vector2 TransformNormal(Vector2 value, Matrix transformation)
        {
            Vector2 result;
            TransformNormal(ref value, ref transformation, out result);
            return result;
        }
        public void TransformNormal(ref Matrix transformation)
        {
            TransformNormal(ref this, ref transformation, out this);
        }
        public void TransformNormal(Matrix transformation)
        {
            TransformNormal(ref this, ref transformation, out this);
        }

        public static void Wrap(ref Vector2 value, ref Vector2 minInclusive, ref Vector2 maxExclusive, out Vector2 result)
        {
            result = new Vector2(
                FMath.Wrap(value.X, minInclusive.X, maxExclusive.X),
                FMath.Wrap(value.Y, minInclusive.Y, maxExclusive.Y)
                );
        }
        public static Vector2 Wrap(ref Vector2 value, ref Vector2 minInclusive, ref Vector2 maxExclusive)
        {
            Vector2 result;
            Wrap(ref value, ref minInclusive, ref maxExclusive, out result);
            return result;
        }
        public static Vector2 Wrap(Vector2 value, Vector2 minInclusive, Vector2 maxExclusive)
        {
            Vector2 result;
            Wrap(ref value, ref minInclusive, ref maxExclusive, out result);
            return result;
        }
        public void Wrap(ref Vector2 minInclusive, ref Vector2 maxExclusive)
        {
            Wrap(ref this, ref minInclusive, ref maxExclusive, out this);
        }
        public void Wrap(Vector2 minInclusive, Vector2 maxExclusive)
        {
            Wrap(ref this, ref minInclusive, ref maxExclusive, out this);
        }

        #endregion


        #region Conversion

        public Vector3 ToVector3(float z = 0.0f)
        {
            return new Vector3(X, Y, z);
        }

        public float[] ToArray()
        {
            return new float[] { X, Y };
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", this.X, this.Y);
        }

        #endregion

    }

    public static class Vector2Extensions
    {
        public static void Write(this BinaryWriter bin, Vector2 value)
        {
            bin.Write(value.X);
            bin.Write(value.Y);
        }

        public static Vector2 ReadVector2(this BinaryReader bin)
        {
            float x = bin.ReadSingle();
            float y = bin.ReadSingle();
            return new Vector2(x, y);
        }
    }
}
