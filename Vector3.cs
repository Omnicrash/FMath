using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using static System.FormattableString;

namespace Frostfire.Math
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Vector3 : IEquatable<Vector3>
    {
        public float X, Y, Z;

        public static readonly int SIZE_IN_BYTES = Marshal.SizeOf(typeof(Vector3));
        
        public static readonly Vector3 ZERO = new Vector3(0.0f);
        public static readonly Vector3 ONE = new Vector3(1.0f);

        public static readonly Vector3 UNIT_X = new Vector3(1.0f, 0.0f, 0.0f);
        public static readonly Vector3 UNIT_Y = new Vector3(0.0f, 1.0f, 0.0f);
        public static readonly Vector3 UNIT_Z = new Vector3(0.0f, 0.0f, 1.0f);

        public static readonly Vector3 MIN_VALUE = new Vector3(Single.MinValue);
        public static readonly Vector3 MAX_VALUE = new Vector3(Single.MaxValue);
        
        public static readonly Vector3 UP = new Vector3(0.0f, 1.0f, 0.0f);
        public static readonly Vector3 FORWARD = new Vector3(0.0f, 0.0f, -1.0f);
        public static readonly Vector3 RIGHT = new Vector3(1.0f, 0.0f, 0.0f);

        public Vector3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        public Vector3(float value)
        {
            this.X = value;
            this.Y = value;
            this.Z = value;
        }

        public float this[int index]
        {
            get
            {
                if(index == 0)
                    return this.X;
                if(index == 1)
                    return this.Y;
                if(index == 2)
                    return this.Z;

                throw new ArgumentOutOfRangeException(nameof(index), "Index out of range.");
            }
            set
            {
                if (index == 0)
                    this.X = value;
                if (index == 1)
                    this.Y = value;
                if (index == 2)

                throw new ArgumentOutOfRangeException(nameof(index), "Index out of range.");
            }
        }


        #region Operations

        public static void Add(ref Vector3 left, ref Vector3 right, out Vector3 result)
        {
            result = new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }
        public static Vector3 Add(ref Vector3 left, ref Vector3 right)
        {
            return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }
        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }
        public void Add(ref Vector3 value)
        {
            this.X += value.X;
            this.Y += value.Y;
            this.Z += value.Z;
        }
        public void Add(Vector3 value)
        {
            this.X += value.X;
            this.Y += value.Y;
            this.Z += value.Z;
        }

        public static void Add(ref Vector3 left, float right, out Vector3 result)
        {
            result = new Vector3(left.X + right, left.Y + right, left.Z + right);
        }
        public static Vector3 Add(ref Vector3 left, float right)
        {
            return new Vector3(left.X + right, left.Y + right, left.Z + right);
        }
        public static Vector3 operator +(Vector3 left, float right)
        {
            return new Vector3(left.X + right, left.Y + right, left.Z + right);
        }
        public static Vector3 operator +(float left, Vector3 right)
        {
            return new Vector3(left + right.X, left + right.Y, left + right.Z);
        }
        public void Add(float value)
        {
            this.X += value;
            this.Y += value;
            this.Z += value;
        }
        
        public static void Subtract(ref Vector3 left, ref Vector3 right, out Vector3 result)
        {
            result = new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }
        public static Vector3 Subtract(ref Vector3 left, ref Vector3 right)
        {
            return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }
        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }
        public void Subtract(ref Vector3 value)
        {
            this.X -= value.X;
            this.Y -= value.Y;
            this.Z -= value.Z;
        }
        public void Subtract(Vector3 value)
        {
            this.X -= value.X;
            this.Y -= value.Y;
            this.Z -= value.Z;
        }

        public static void Subtract(ref Vector3 left, float right, out Vector3 result)
        {
            result = new Vector3(left.X - right, left.Y - right, left.Z - right);
        }
        public static void Subtract(float left, ref Vector3 right, out Vector3 result)
        {
            result = new Vector3(left - right.X, left - right.Y, left - right.Z);
        }
        public static Vector3 Subtract(ref Vector3 left, float right)
        {
            return new Vector3(left.X - right, left.Y - right, left.Z - right);
        }
        public static Vector3 Subtract(float left, ref Vector3 right)
        {
            return new Vector3(left - right.X, left - right.Y, left - right.Z);
        }
        public static Vector3 operator -(Vector3 left, float right)
        {
            return new Vector3(left.X - right, left.Y - right, left.Z - right);
        }
        public static Vector3 operator -(float left, Vector3 right)
        {
            return new Vector3(left - right.X, left - right.Y, left - right.Z);
        }
        public void Subtract(float value)
        {
            this.X -= value;
            this.Y -= value;
            this.Z -= value;
        }

        public static void Multiply(ref Vector3 left, ref Vector3 right, out Vector3 result)
        {
            result = new Vector3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
        }
        public static Vector3 Multiply(ref Vector3 left, ref Vector3 right)
        {
            return new Vector3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
        }
        public static Vector3 operator *(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
        }
        public void Multiply(ref Vector3 value)
        {
            this.X *= value.X;
            this.Y *= value.Y;
            this.Z *= value.Z;
        }
        public void Multiply(Vector3 value)
        {
            this.X *= value.X;
            this.Y *= value.Y;
            this.Z *= value.Z;
        }

        public static void Multiply(ref Vector3 left, float right, out Vector3 result)
        {
            result = new Vector3(left.X * right, left.Y * right, left.Z * right);
        }
        public static Vector3 Multiply(ref Vector3 left, float right)
        {
            return new Vector3(left.X * right, left.Y * right, left.Z * right);
        }
        public static Vector3 operator *(Vector3 left, float right)
        {
            return new Vector3(left.X * right, left.Y * right, left.Z * right);
        }
        public static Vector3 operator *(float left, Vector3 right)
        {
            return new Vector3(left * right.X, left * right.Y, left * right.Z);
        }
        public void Multiply(float value)
        {
            this.X *= value;
            this.Y *= value;
            this.Z *= value;
        }
        
        public static void Divide(ref Vector3 left, ref Vector3 right, out Vector3 result)
        {
            result = new Vector3(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
        }
        public static Vector3 Divide(ref Vector3 left, ref Vector3 right)
        {
            return new Vector3(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
        }
        public static Vector3 operator /(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
        }
        public void Divide(ref Vector3 value)
        {
            this.X /= value.X;
            this.Y /= value.Y;
            this.Z /= value.Z;
        }
        public void Divide(Vector3 value)
        {
            this.X /= value.X;
            this.Y /= value.Y;
            this.Z /= value.Z;
        }

        public static void Divide(ref Vector3 left, float right, out Vector3 result)
        {
            result = new Vector3(left.X / right, left.Y / right, left.Z / right);
        }
        public static void Divide(float left, ref Vector3 right, out Vector3 result)
        {
            result = new Vector3(left / right.X, left / right.Y, left / right.Z);
        }
        public static Vector3 Divide(ref Vector3 left, float right)
        {
            return new Vector3(left.X / right, left.Y / right, left.Z / right);
        }
        public static Vector3 Divide(float left, ref Vector3 right)
        {
            return new Vector3(left / right.X, left / right.Y, left / right.Z);
        }
        public static Vector3 operator /(Vector3 left, float right)
        {
            return new Vector3(left.X / right, left.Y / right, left.Z / right);
        }
        public static Vector3 operator /(float left, Vector3 right)
        {
            return new Vector3(left / right.X, left / right.Y, left / right.Z);
        }
        public void Divide(float value)
        {
            this.X /= value;
            this.Y /= value;
            this.Z /= value;
        }

        public static void Negate(ref Vector3 value, out Vector3 result)
        {
            result = new Vector3(-value.X, -value.Y, -value.Z);
        }
        public static Vector3 Negate(ref Vector3 value)
        {
            return new Vector3(-value.X, -value.Y, -value.Z);
        }
        public static Vector3 operator -(Vector3 value)
        {
            return new Vector3(-value.X, -value.Y, -value.Z);
        }
        public void Negate()
        {
            this.X = -this.X;
            this.Y = -this.Y;
            this.Z = -this.Z;
        }

        #endregion


        #region Comparison

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        public bool Equals(ref Vector3 value)
        {
            return
                System.Math.Abs(this.X - value.X) < FMath.EPSILON &&
                System.Math.Abs(this.Y - value.Y) < FMath.EPSILON &&
                System.Math.Abs(this.Z - value.Z) < FMath.EPSILON;
        }
        public bool Equals(Vector3 value)
        {
            return Equals(ref value);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            return Equals((Vector3)obj);
        }
        public static bool operator ==(Vector3 left, Vector3 right)
        {
            return left.Equals(ref right);
        }
        public static bool operator !=(Vector3 left, Vector3 right)
        {
            return !left.Equals(ref right);
        }

        #endregion


        #region Functions

        public static void Abs(ref Vector3 value, out Vector3 result)
        {
            result.X = System.Math.Abs(value.X);
            result.Y = System.Math.Abs(value.Y);
            result.Z = System.Math.Abs(value.Z);
        }
        public static Vector3 Abs(ref Vector3 value)
        {
            Vector3 result;
            Abs(ref value, out result);
            return result;
        }
        public static Vector3 Abs(Vector3 value)
        {
            Vector3 result;
            Abs(ref value, out result);
            return result;
        }
        public void Abs()
        {
            Abs(ref this, out this);
        }

        public static void Barycentric(ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, float factor1, float factor2, out Vector3 result)
        {
            result = new Vector3(
                (value1.X + (factor1 * (value2.X - value1.X))) + (factor2 * (value3.X - value1.X)),
                (value1.Y + (factor1 * (value2.Y - value1.Y))) + (factor2 * (value3.Y - value1.Y)),
                (value1.Z + (factor1 * (value2.Z - value1.Z))) + (factor2 * (value3.Z - value1.Z)));
        }
        public static Vector3 Barycentric(ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, float factor1, float factor2)
        {
            Vector3 result;
            Barycentric(ref value1, ref value2, ref value3, factor1, factor2, out result);
            return result;
        }
        public static Vector3 Barycentric(Vector3 value1, Vector3 value2, Vector3 value3, float factor1, float factor2)
        {
            Vector3 result;
            Barycentric(ref value1, ref value2, ref value3, factor1, factor2, out result);
            return result;
        }

        public static void CatmullRom(ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, ref Vector3 value4, float factor, out Vector3 result)
        {
            float squared = factor * factor;
            float cubed = factor * squared;

            result.X = 0.5f * ((((2.0f * value2.X) + ((-value1.X + value3.X) * factor)) +
                (((((2.0f * value1.X) - (5.0f * value2.X)) + (4.0f * value3.X)) - value4.X) * squared)) +
                ((((-value1.X + (3.0f * value2.X)) - (3.0f * value3.X)) + value4.X) * cubed));

            result.Y = 0.5f * ((((2.0f * value2.Y) + ((-value1.Y + value3.Y) * factor)) +
                (((((2.0f * value1.Y) - (5.0f * value2.Y)) + (4.0f * value3.Y)) - value4.Y) * squared)) +
                ((((-value1.Y + (3.0f * value2.Y)) - (3.0f * value3.Y)) + value4.Y) * cubed));

            result.Z = 0.5f * ((((2.0f * value2.Z) + ((-value1.Z + value3.Z) * factor)) +
                (((((2.0f * value1.Z) - (5.0f * value2.Z)) + (4.0f * value3.Z)) - value4.Z) * squared)) +
                ((((-value1.Z + (3.0f * value2.Z)) - (3.0f * value3.Z)) + value4.Z) * cubed));

        }
        public static Vector3 CatmullRom(ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, ref Vector3 value4, float factor)
        {
            Vector3 result;
            CatmullRom(ref value1, ref value2, ref value3, ref value4, factor, out result);
            return result;
        }
        public static Vector3 CatmullRom(Vector3 value1, Vector3 value2, Vector3 value3, Vector3 value4, float factor)
        {
            Vector3 result;
            CatmullRom(ref value1, ref value2, ref value3, ref value4, factor, out result);
            return result;
        }

        public static void Clamp(ref Vector3 value, ref Vector3 min, ref Vector3 max, out Vector3 result)
        {
            result = new Vector3(
                FMath.Clamp(value.X, min.X, max.X),
                FMath.Clamp(value.Y, min.Y, max.Y),
                FMath.Clamp(value.Z, min.Z, max.Z)
                );
        }
        public static Vector3 Clamp(ref Vector3 value, ref Vector3 min, ref Vector3 max)
        {
            Vector3 result;
            Clamp(ref value, ref min, ref max, out result);
            return result;
        }
        public static Vector3 Clamp(Vector3 value, Vector3 min, Vector3 max)
        {
            Vector3 result;
            Clamp(ref value, ref min, ref max, out result);
            return result;
        }
        public void Clamp(ref Vector3 min, ref Vector3 max)
        {
            Clamp(ref this, ref min, ref max, out this);
        }
        public void Clamp(Vector3 min, Vector3 max)
        {
            Clamp(ref this, ref min, ref max, out this);
        }

        public static void Cross(ref Vector3 left, ref Vector3 right, out Vector3 result)
        {
            result = new Vector3()
            {
                X = left.Y * right.Z - left.Z * right.Y,
                Y = left.Z * right.X - left.X * right.Z,
                Z = left.X * right.Y - left.Y * right.X
            };
        }
        public static Vector3 Cross(ref Vector3 left, ref Vector3 right)
        {
            Vector3 result;
            Cross(ref left, ref right, out result);
            return result;
        }
        public static Vector3 Cross(Vector3 left, Vector3 right)
        {
            Vector3 result;
            Cross(ref left, ref right, out result);
            return result;
        }

        public static void Distance(ref Vector3 left, ref Vector3 right, out float result)
        {
            float diffX = left.X - right.X;
            float diffY = left.Y - right.Y;
            float diffZ = left.Z - right.Z;
            result = (float)System.Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ);
        }
        public static float Distance(ref Vector3 left, ref Vector3 right)
        {
            float result;
            Distance(ref left, ref right, out result);
            return result;
        }
        public static float Distance(Vector3 left, Vector3 right)
        {
            float result;
            Distance(ref left, ref right, out result);
            return result;
        }

        public static void DistanceSq(ref Vector3 left, ref Vector3 right, out float result)
        {
            float diffX = left.X - right.X;
            float diffY = left.Y - right.Y;
            float diffZ = left.Z - right.Z;
            result = diffX * diffX + diffY * diffY + diffZ * diffZ;
        }
        public static float DistanceSq(ref Vector3 left, ref Vector3 right)
        {
            float result;
            DistanceSq(ref left, ref right, out result);
            return result;
        }
        public static float DistanceSq(Vector3 left, Vector3 right)
        {
            float result;
            DistanceSq(ref left, ref right, out result);
            return result;
        }

        public static void Dot(ref Vector3 left, ref Vector3 right, out float result)
        {
            result = left.X * right.X + left.Y * right.Y + left.Z * right.Z;
        }
        public static float Dot(ref Vector3 left, ref Vector3 right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
        }
        public static float Dot(Vector3 left, Vector3 right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
        }

        public static void Hermite(ref Vector3 value1, ref Vector3 tangent1, ref Vector3 value2, ref Vector3 tangent2, float factor, out Vector3 result)
        {
            float squared = factor * factor;
            float cubed = factor * squared;
            float part1 = ((2.0f * cubed) - (3.0f * squared)) + 1.0f;
            float part2 = (-2.0f * cubed) + (3.0f * squared);
            float part3 = (cubed - (2.0f * squared)) + factor;
            float part4 = cubed - squared;

            result.X = (((value1.X * part1) + (value2.X * part2)) + (tangent1.X * part3)) + (tangent2.X * part4);
            result.Y = (((value1.Y * part1) + (value2.Y * part2)) + (tangent1.Y * part3)) + (tangent2.Y * part4);
            result.Z = (((value1.Z * part1) + (value2.Z * part2)) + (tangent1.Z * part3)) + (tangent2.Z * part4);
        }
        public static Vector3 Hermite(ref Vector3 value1, ref Vector3 tangent1, ref Vector3 value2, ref Vector3 tangent2, float factor)
        {
            Vector3 result;
            Hermite(ref value1, ref tangent1, ref value2, ref tangent2, factor, out result);
            return result;
        }
        public static Vector3 Hermite(Vector3 value1, Vector3 tangent1, Vector3 value2, Vector3 tangent2, float factor)
        {
            Vector3 result;
            Hermite(ref value1, ref tangent1, ref value2, ref tangent2, factor, out result);
            return result;
        }

        public static void Length(ref Vector3 value, out float result)
        {
            result = (float)System.Math.Sqrt(value.X * value.X + value.Y * value.Y + value.Z * value.Z);
        }
        public static float Length(ref Vector3 value)
        {
            return (float)System.Math.Sqrt(value.X * value.X + value.Y * value.Y + value.Z * value.Z);
        }
        public static float Length(Vector3 value)
        {
            return (float)System.Math.Sqrt(value.X * value.X + value.Y * value.Y + value.Z * value.Z);
        }
        public float Length()
        {
            return (float)System.Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public static void LengthSq(ref Vector3 value, out float result)
        {
            result = value.X * value.X + value.Y * value.Y + value.Z * value.Z;
        }
        public static float LengthSq(ref Vector3 value)
        {
            return value.X * value.X + value.Y * value.Y + value.Z * value.Z;
        }
        public static float LengthSq(Vector3 value)
        {
            return value.X * value.X + value.Y * value.Y + value.Z * value.Z;
        }
        public float LengthSq()
        {
            return X * X + Y * Y + Z * Z;
        }

        public static void Lerp(ref Vector3 start, ref Vector3 end, float factor, out Vector3 result)
        {
            result = new Vector3(
                FMath.Lerp(start.X, end.X, factor),
                FMath.Lerp(start.Y, end.Y, factor),
                FMath.Lerp(start.Z, end.Z, factor));
        }
        public static Vector3 Lerp(ref Vector3 start, ref Vector3 end, float factor)
        {
            Vector3 result;
            Lerp(ref start, ref end, factor, out result);
            return result;
        }
        public static Vector3 Lerp(Vector3 start, Vector3 end, float factor)
        {
            Vector3 result;
            Lerp(ref start, ref end, factor, out result);
            return result;
        }

        public static void Maximize(ref Vector3 value1, ref Vector3 value2
            , out Vector3 result)
        {
            result = new Vector3()
            {
                X = value1.X <= value2.X ? value2.X : value1.X,
                Y = value1.Y <= value2.Y ? value2.Y : value1.Y,
                Z = value1.Z <= value2.Z ? value2.Z : value1.Z,
            };
        }
        public static Vector3 Maximize(ref Vector3 value1, ref Vector3 value2)
        {
            Vector3 result;
            Maximize(ref value1, ref value2, out result);
            return result;
        }
        public static Vector3 Maximize(Vector3 value1, Vector3 value2)
        {
            Vector3 result;
            Maximize(ref value1, ref value2, out result);
            return result;
        }
        public void Maximize(ref Vector3 value)
        {
            Maximize(ref this, ref value, out this);
        }
        public void Maximize(Vector3 value)
        {
            Maximize(ref this, ref value, out this);
        }

        public static void Minimize(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
        {
            result = new Vector3()
            {
                X = value1.X >= value2.X ? value2.X : value1.X,
                Y = value1.Y >= value2.Y ? value2.Y : value1.Y,
                Z = value1.Z >= value2.Z ? value2.Z : value1.Z,
            };
        }
        public static Vector3 Minimize(ref Vector3 value1, ref Vector3 value2)
        {
            Vector3 result;
            Minimize(ref value1, ref value2, out result);
            return result;
        }
        public static Vector3 Minimize(Vector3 value1, Vector3 value2)
        {
            Vector3 result;
            Minimize(ref value1, ref value2, out result);
            return result;
        }
        public void Minimize(ref Vector3 value)
        {
            Minimize(ref this, ref value, out this);
        }
        public void Minimize(Vector3 value)
        {
            Minimize(ref this, ref value, out this);
        }

        /// <summary>
        /// Returns the value of the vector's largest component.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static void Max(ref Vector3 value, out float result)
        {
            result = System.Math.Max(value.X, System.Math.Max(value.Y, value.Z));
        }
        public static float Max(ref Vector3 value)
        {
            return System.Math.Max(value.X, System.Math.Max(value.Y, value.Z));
        }
        public static float Max(Vector3 value)
        {
            return System.Math.Max(value.X, System.Math.Max(value.Y, value.Z));
        }
        public float Max()
        {
            return System.Math.Max(X, System.Math.Max(Y, Z));
        }

        /// <summary>
        /// Returns the value of the vector's smallest component.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static void Min(ref Vector3 value, out float result)
        {
            result = System.Math.Min(value.X, System.Math.Min(value.Y, value.Z));
        }
        public static float Min(ref Vector3 value)
        {
            return System.Math.Min(value.X, System.Math.Min(value.Y, value.Z));
        }
        public static float Min(Vector3 value)
        {
            return System.Math.Min(value.X, System.Math.Min(value.Y, value.Z));
        }
        public float Min()
        {
            return System.Math.Min(X, System.Math.Min(Y, Z));
        }

        public static void Normalize(ref Vector3 value, out Vector3 result)
        {
            float lengthSq = value.LengthSq();
            if (lengthSq < FMath.EPSILON)
            {
                result = ZERO;
                return;
            }
            float lengthInverse = 1.0f / FMath.Sqrt(lengthSq);
            result = new Vector3(value.X * lengthInverse, value.Y * lengthInverse, value.Z * lengthInverse);
        }
        public static Vector3 Normalize(ref Vector3 value)
        {
            Vector3 result;
            Normalize(ref value, out result);
            return result;
        }
        public static Vector3 Normalize(Vector3 value)
        {
            Vector3 result;
            Normalize(ref value, out result);
            return result;
        }
        public void Normalize()
        {
            Normalize(ref this, out this);
        }

        public static void Reflect(ref Vector3 value, ref Vector3 normal, out Vector3 result)
        {
            float dotProduct;
            Dot(ref value, ref normal, out dotProduct);
            result = new Vector3()
            {
                X = value.X - normal.X * dotProduct,
                Y = value.Y - normal.Y * dotProduct,
                Z = value.Z - normal.Z * dotProduct
            };
        }
        public static Vector3 Reflect(ref Vector3 value, ref Vector3 normal)
        {
            Vector3 result;
            Reflect(ref value, ref normal, out result);
            return result;
        }
        public static Vector3 Reflect(Vector3 value, Vector3 normal)
        {
            Vector3 result;
            Reflect(ref value, ref normal, out result);
            return result;
        }
        public void Reflect(ref Vector3 normal)
        {
            Reflect(ref this, ref normal, out this);
        }
        public void Reflect(Vector3 normal)
        {
            Reflect(ref this, ref normal, out this);
        }
        
        public static void Transform(ref Vector3 value, ref Matrix transformation, out Vector3 result)
        {
            float invW = 1.0f /
                         (transformation.M14 * value.X +
                          transformation.M24 * value.Y +
                          transformation.M34 * value.Z +
                          transformation.M44);
            result.X = (transformation.M11 * value.X +
                        transformation.M21 * value.Y +
                        transformation.M31 * value.Z +
                        transformation.M41) * invW;
            result.Y = (transformation.M12 * value.X +
                        transformation.M22 * value.Y +
                        transformation.M32 * value.Z +
                        transformation.M42) * invW;
            result.Z = (transformation.M13 * value.X +
                        transformation.M23 * value.Y +
                        transformation.M33 * value.Z +
                        transformation.M43) * invW;
        }
        public static Vector3 Transform(ref Vector3 value, ref Matrix transformation)
        {
            Vector3 result;
            Transform(ref value, ref transformation, out result);
            return result;
        }
        public static Vector3 Transform(Vector3 value, Matrix transformation)
        {
            Vector3 result;
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

        public static void TransformNormal(ref Vector3 value, ref Matrix transformation, out Vector3 result)
        {
            result.X = transformation.M11 * value.X +
                       transformation.M21 * value.Y +
                       transformation.M31 * value.Z;
            result.Y = transformation.M12 * value.X +
                       transformation.M22 * value.Y +
                       transformation.M32 * value.Z;
            result.Z = transformation.M13 * value.X +
                       transformation.M23 * value.Y +
                       transformation.M33 * value.Z;
        }
        public static Vector3 TransformNormal(ref Vector3 value, ref Matrix transformation)
        {
            Vector3 result;
            TransformNormal(ref value, ref transformation, out result);
            return result;
        }
        public static Vector3 TransformNormal(Vector3 value, Matrix transformation)
        {
            Vector3 result;
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

        public static void Wrap(ref Vector3 value, ref Vector3 minInclusive, ref Vector3 maxExclusive, out Vector3 result)
        {
            result = new Vector3(
                FMath.Wrap(value.X, minInclusive.X, maxExclusive.X),
                FMath.Wrap(value.Y, minInclusive.Y, maxExclusive.Y),
                FMath.Wrap(value.Z, minInclusive.Z, maxExclusive.Z));
        }
        public static Vector3 Wrap(ref Vector3 value, ref Vector3 minInclusive, ref Vector3 maxExclusive)
        {
            Vector3 result;
            Wrap(ref value, ref minInclusive, ref maxExclusive, out result);
            return result;
        }
        public static Vector3 Wrap(Vector3 value, Vector3 minInclusive, Vector3 maxExclusive)
        {
            Vector3 result;
            Wrap(ref value, ref minInclusive, ref maxExclusive, out result);
            return result;
        }
        public void Wrap(ref Vector3 minInclusive, ref Vector3 maxExclusive)
        {
            Wrap(ref this, ref minInclusive, ref maxExclusive, out this);
        }
        public void Wrap(Vector3 minInclusive, Vector3 maxExclusive)
        {
            Wrap(ref this, ref minInclusive, ref maxExclusive, out this);
        }

        #endregion


        #region Conversion

        public Vector2 ToVector2()
        {
            return new Vector2(X, Y);
        }

        public Vector4 ToVector4(float w = 0.0f)
        {
            return new Vector4(X, Y, Z, w);
        }

        public Coord3 ToCoord3()
        {
            return new Coord3((int)X, (int)Y, (int)Z);
        }

        public static Vector3 FromColor(Color color)
        {
            return new Vector3(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f);
        }
        public static Color ToColor(Vector3 color)
        {
            return Color.FromArgb((int)(color.X * 255.0f), (int)(color.Y * 255.0f), (int)(color.Z * 255.0f));
        }
        public Color ToColor()
        {
            return ToColor(this);
        }

        public float[] ToArray()
        {
            return new float[] { X, Y, Z };
        }

        public override string ToString()
        {
            return Invariant($"X:{X} Y:{Y} Z:{Z}");
        }
        
        #endregion
    }

    public static class Vector3Extensions
    {
        public static void Write(this BinaryWriter bin, Vector3 value)
        {
            bin.Write(value.X);
            bin.Write(value.Y);
            bin.Write(value.Z);
        }

        public static Vector3 ReadVector3(this BinaryReader bin)
        {
            float x = bin.ReadSingle();
            float y = bin.ReadSingle();
            float z = bin.ReadSingle();
            return new Vector3(x, y, z);
        }
    }
}
