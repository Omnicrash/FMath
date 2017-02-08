using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

namespace Frostfire.Math
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Vector4 : IEquatable<Vector4>
    {
        public float X, Y, Z, W;

        public static readonly int SIZE_IN_BYTES = Marshal.SizeOf(typeof(Vector4));
        
        public static readonly Vector4 ZERO = new Vector4(0.0f);
        public static readonly Vector4 ONE = new Vector4(1.0f);

        public static readonly Vector4 UNIT_X = new Vector4(1.0f, 0.0f, 0.0f, 0.0f);
        public static readonly Vector4 UNIT_Y = new Vector4(0.0f, 1.0f, 0.0f, 0.0f);
        public static readonly Vector4 UNIT_Z = new Vector4(0.0f, 0.0f, 1.0f, 0.0f);
        public static readonly Vector4 UNIT_W = new Vector4(0.0f, 0.0f, 0.0f, 1.0f);

        public static readonly Vector4 MIN_VALUE = new Vector4(Single.MinValue);
        public static readonly Vector4 MAX_VALUE = new Vector4(Single.MaxValue);

        public Vector4(float x, float y, float z, float w)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.W = w;
        }
        public Vector4(float value)
        {
            this.X = value;
            this.Y = value;
            this.Z = value;
            this.W = value;
        }

        public float this[int index]
        {
            get
            {
                switch(index)
                {
                    case 0:
                        return this.X;
                    case 1:
                        return this.Y;
                    case 2:
                        return this.Z;
                    case 3:
                        return this.W;
                    default:
                        throw new ArgumentOutOfRangeException("index", "Index out of range.");
                }
            }
            set
            {
                switch(index)
                {
                    case 0:
                        this.X = value;
                        break;
                    case 1:
                        this.Y = value;
                        break;
                    case 2:
                        this.Z = value;
                        break;
                    case 3:
                        this.W = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("index", "Index out of range.");
                }
            }
        }


        #region Operations

        public static void Add(ref Vector4 left, ref Vector4 right, out Vector4 result)
        {
            result = new Vector4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
        }
        public static Vector4 Add(ref Vector4 left, ref Vector4 right)
        {
            return new Vector4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
        }
        public static Vector4 operator +(Vector4 left, Vector4 right)
        {
            return new Vector4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
        }
        public void Add(ref Vector4 value)
        {
            this.X += value.X;
            this.Y += value.Y;
            this.Z += value.Z;
            this.W += value.W;
        }
        public void Add(Vector4 value)
        {
            this.X += value.X;
            this.Y += value.Y;
            this.Z += value.Z;
            this.W += value.W;
        }

        public static void Add(ref Vector4 left, float right, out Vector4 result)
        {
            result = new Vector4(left.X + right, left.Y + right, left.Z + right, left.W + right);
        }
        public static Vector4 Add(ref Vector4 left, float right)
        {
            return new Vector4(left.X + right, left.Y + right, left.Z + right, left.W + right);
        }
        public static Vector4 operator +(float left, Vector4 right)
        {
            return new Vector4(left + right.X, left + right.Y, left + right.Z, left + right.W);
        }
        public void Add(float value)
        {
            this.X += value;
            this.Y += value;
            this.Z += value;
            this.W += value;
        }

        public static void Subtract(ref Vector4 left, ref Vector4 right, out Vector4 result)
        {
            result = new Vector4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
        }
        public static Vector4 Subtract(ref Vector4 left, ref Vector4 right)
        {
            return new Vector4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
        }
        public static Vector4 operator -(Vector4 left, Vector4 right)
        {
            return new Vector4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
        }
        public void Subtract(ref Vector4 value)
        {
            this.X -= value.X;
            this.Y -= value.Y;
            this.Z -= value.Z;
            this.W -= value.W;
        }
        public void Subtract(Vector4 value)
        {
            this.X -= value.X;
            this.Y -= value.Y;
            this.Z -= value.Z;
            this.W -= value.W;
        }

        public static void Subtract(ref Vector4 left, float right, out Vector4 result)
        {
            result = new Vector4(left.X - right, left.Y - right, left.Z - right, left.W - right);
        }
        public static void Subtract(float left, ref Vector4 right, out Vector4 result)
        {
            result = new Vector4(left - right.X, left - right.Y, left - right.Z, left - right.W);
        }
        public static Vector4 Subtract(ref Vector4 left, float right)
        {
            return new Vector4(left.X - right, left.Y - right, left.Z - right, left.W - right);
        }
        public static Vector4 Subtract(float left, ref Vector4 right)
        {
            return new Vector4(left - right.X, left - right.Y, left - right.Z, left - right.W);
        }
        public static Vector4 operator -(Vector4 left, float right)
        {
            return new Vector4(left.X - right, left.Y - right, left.Z - right, left.W - right);
        }
        public static Vector4 operator -(float left, Vector4 right)
        {
            return new Vector4(left - right.X, left - right.Y, left - right.Z, left - right.W);
        }
        public void Subtract(float value)
        {
            this.X -= value;
            this.Y -= value;
            this.Z -= value;
            this.W -= value;
        }

        public static void Multiply(ref Vector4 left, ref Vector4 right, out Vector4 result)
        {
            result = new Vector4(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);
        }
        public static Vector4 Multiply(ref Vector4 left, ref Vector4 right)
        {
            return new Vector4(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);
        }
        public static Vector4 operator *(Vector4 left, Vector4 right)
        {
            return new Vector4(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);
        }
        public void Multiply(ref Vector4 value)
        {
            this.X *= value.X;
            this.Y *= value.Y;
            this.Z *= value.Z;
            this.W *= value.W;
        }
        public void Multiply(Vector4 value)
        {
            this.X *= value.X;
            this.Y *= value.Y;
            this.Z *= value.Z;
            this.W *= value.W;
        }

        public static void Multiply(ref Vector4 left, float right, out Vector4 result)
        {
            result = new Vector4(left.X * right, left.Y * right, left.Z * right, left.W * right);
        }
        public static Vector4 Multiply(ref Vector4 left, float right)
        {
            return new Vector4(left.X * right, left.Y * right, left.Z * right, left.W * right);
        }
        public static Vector4 operator *(Vector4 left, float right)
        {
            return new Vector4(left.X * right, left.Y * right, left.Z * right, left.W * right);
        }
        public static Vector4 operator *(float left, Vector4 right)
        {
            return new Vector4(left * right.X, left * right.Y, left * right.Z, left * right.W);
        }
        public void Multiply(float value)
        {
            this.X *= value;
            this.Y *= value;
            this.Z *= value;
            this.W *= value;
        }

        public static void Divide(ref Vector4 left, ref Vector4 right, out Vector4 result)
        {
            result = new Vector4(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);
        }
        public static Vector4 Divide(ref Vector4 left, ref Vector4 right)
        {
            return new Vector4(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);
        }
        public static Vector4 operator /(Vector4 left, Vector4 right)
        {
            return new Vector4(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.W / right.W);
        }
        public void Divide(ref Vector4 value)
        {
            this.X /= value.X;
            this.Y /= value.Y;
            this.Z /= value.Z;
            this.W /= value.W;
        }
        public void Divide(Vector4 value)
        {
            this.X /= value.X;
            this.Y /= value.Y;
            this.Z /= value.Z;
            this.W /= value.W;
        }

        public static void Divide(ref Vector4 left, float right, out Vector4 result)
        {
            result = new Vector4(left.X / right, left.Y / right, left.Z / right, left.W / right);
        }
        public static void Divide(float left, ref Vector4 right, out Vector4 result)
        {
            result = new Vector4(left / right.X, left / right.Y, left / right.Z, left / right.W);
        }
        public static Vector4 Divide(ref Vector4 left, float right)
        {
            return new Vector4(left.X / right, left.Y / right, left.Z / right, left.W / right);
        }
        public static Vector4 Divide(float left, ref Vector4 right)
        {
            return new Vector4(left / right.X, left / right.Y, left / right.Z, left / right.W);
        }
        public static Vector4 operator /(Vector4 left, float right)
        {
            return new Vector4(left.X / right, left.Y / right, left.Z / right, left.W / right);
        }
        public static Vector4 operator /(float left, Vector4 right)
        {
            return new Vector4(left / right.X, left / right.Y, left / right.Z, left / right.W);
        }
        public void Divide(float value)
        {
            this.X /= value;
            this.Y /= value;
            this.Z /= value;
            this.W /= value;
        }

        public static Vector4 Negate(ref Vector4 value)
        {
            return new Vector4(-value.X, -value.Y, -value.Z, -value.W);
        }
        public static Vector4 operator -(Vector4 value)
        {
            return new Vector4(-value.X, -value.Y, -value.Z, -value.W);
        }
        public void Negate()
        {
            this.X = -this.X;
            this.Y = -this.Y;
            this.Z = -this.Z;
            this.W = -this.W;
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
                hashCode = (hashCode * 397) ^ W.GetHashCode();
                return hashCode;
            }
        }

        public bool Equals(ref Vector4 value)
        {
            return
                System.Math.Abs(this.X - value.X) < FMath.EPSILON &&
                System.Math.Abs(this.Y - value.Y) < FMath.EPSILON &&
                System.Math.Abs(this.Z - value.Z) < FMath.EPSILON &&
                System.Math.Abs(this.W - value.W) < FMath.EPSILON;
        }
        public bool Equals(Vector4 value)
        {
            return Equals(ref value);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            return Equals((Vector4)obj);
        }
        public static bool operator ==(Vector4 left, Vector4 right)
        {
            return left.Equals(ref right);
        }
        public static bool operator !=(Vector4 left, Vector4 right)
        {
            return !left.Equals(ref right);
        }

        #endregion


        #region Functions

        public static void Abs(ref Vector4 value, out Vector4 result)
        {
            result.X = System.Math.Abs(value.X);
            result.Y = System.Math.Abs(value.Y);
            result.Z = System.Math.Abs(value.Z);
            result.W = System.Math.Abs(value.W);
        }
        public static Vector4 Abs(ref Vector4 value)
        {
            Vector4 result;
            Abs(ref value, out result);
            return result;
        }
        public static Vector4 Abs(Vector4 value)
        {
            Vector4 result;
            Abs(ref value, out result);
            return result;
        }
        public void Abs()
        {
            Abs(ref this, out this);
        }

        public static void Barycentric(ref Vector4 value1, ref Vector4 value2, ref Vector4 value3, float factor1, float factor2, out Vector4 result)
        {
            result = new Vector4(
                (value1.X + (factor1 * (value2.X - value1.X))) + (factor2 * (value3.X - value1.X)),
                (value1.Y + (factor1 * (value2.Y - value1.Y))) + (factor2 * (value3.Y - value1.Y)),
                (value1.Z + (factor1 * (value2.Z - value1.Z))) + (factor2 * (value3.Z - value1.Z)),
                (value1.W + (factor1 * (value2.W - value1.W))) + (factor2 * (value3.W - value1.W)));
        }
        public static Vector4 Barycentric(ref Vector4 value1, ref Vector4 value2, ref Vector4 value3, float factor1, float factor2)
        {
            Vector4 result;
            Barycentric(ref value1, ref value2, ref value3, factor1, factor2, out result);
            return result;
        }
        public static Vector4 Barycentric(Vector4 value1, Vector4 value2, Vector4 value3, float factor1, float factor2)
        {
            Vector4 result;
            Barycentric(ref value1, ref value2, ref value3, factor1, factor2, out result);
            return result;
        }

        public static void CatmullRom(ref Vector4 value1, ref Vector4 value2, ref Vector4 value3, ref Vector4 value4, float factor, out Vector4 result)
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

            result.W = 0.5f * ((((2.0f * value2.W) + ((-value1.W + value3.W) * factor)) +
                (((((2.0f * value1.W) - (5.0f * value2.W)) + (4.0f * value3.W)) - value4.W) * squared)) +
                ((((-value1.W + (3.0f * value2.W)) - (3.0f * value3.W)) + value4.W) * cubed));
        }
        public static Vector4 CatmullRom(ref Vector4 value1, ref Vector4 value2, ref Vector4 value3, ref Vector4 value4, float factor)
        {
            Vector4 result;
            CatmullRom(ref value1, ref value2, ref value3, ref value4, factor, out result);
            return result;
        }
        public static Vector4 CatmullRom(Vector4 value1, Vector4 value2, Vector4 value3, Vector4 value4, float factor)
        {
            Vector4 result;
            CatmullRom(ref value1, ref value2, ref value3, ref value4, factor, out result);
            return result;
        }

        public static void Clamp(ref Vector4 value, ref Vector4 min, ref Vector4 max, out Vector4 result)
        {
            result = new Vector4(
                FMath.Clamp(value.X, min.X, max.X),
                FMath.Clamp(value.Y, min.Y, max.Y),
                FMath.Clamp(value.Z, min.Z, max.Z),
                FMath.Clamp(value.W, min.W, max.W));
        }
        public static Vector4 Clamp(ref Vector4 value, ref Vector4 min, ref Vector4 max)
        {
            Vector4 result;
            Clamp(ref value, ref min, ref max, out result);
            return result;
        }
        public static Vector4 Clamp(Vector4 value, Vector4 min, Vector4 max)
        {
            Vector4 result;
            Clamp(ref value, ref min, ref max, out result);
            return result;
        }
        public void Clamp(ref Vector4 min, ref Vector4 max)
        {
            Clamp(ref this, ref min, ref max, out this);
        }
        public void Clamp(Vector4 min, Vector4 max)
        {
            Clamp(ref this, ref min, ref max, out this);
        }

        /*
        public static Vector4 Cross(Vector4 value1, Vector4 value2, Vector4 value3)
        {
            return new Vector4()
            {
                //NOT FINISHED
                X = left.Y * right.Z - left.Z * right.Y,
                Y = left.Z * right.X - left.X * right.Z,
                Z = left.X * right.Y - left.Y * right.X
            };
        }
        */

        public static void Distance(ref Vector4 left, ref Vector4 right, out float result)
        {
            float diffX = left.X - right.X;
            float diffY = left.Y - right.Y;
            float diffZ = left.Z - right.Z;
            float diffW = left.W - right.W;
            result = (float)System.Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ + diffW * diffW);
        }
        public static float Distance(ref Vector4 left, ref Vector4 right)
        {
            float result;
            Distance(ref left, ref right, out result);
            return result;
        }
        public static float Distance(Vector4 left, Vector4 right)
        {
            float result;
            Distance(ref left, ref right, out result);
            return result;
        }

        public static void DistanceSq(ref Vector4 left, ref Vector4 right, out float result)
        {
            float diffX = left.X - right.X;
            float diffY = left.Y - right.Y;
            float diffZ = left.Z - right.Z;
            float diffW = left.W - right.W;
            result = diffX * diffX + diffY * diffY + diffZ * diffZ + diffW * diffW;
        }
        public static float DistanceSq(ref Vector4 left, ref Vector4 right)
        {
            float result;
            Distance(ref left, ref right, out result);
            return result;
        }
        public static float DistanceSq(Vector4 left, Vector4 right)
        {
            float result;
            Distance(ref left, ref right, out result);
            return result;
        }

        public static void Dot(ref Vector4 left, ref Vector4 right, out float result)
        {
            result = left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
        }
        public static float Dot(ref Vector4 left, ref Vector4 right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
        }
        public static float Dot(Vector4 left, Vector4 right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
        }

        public static void Hermite(ref Vector4 value1, ref Vector4 tangent1, ref Vector4 value2, ref Vector4 tangent2, float factor, out Vector4 result)
        {
            float squared = factor * factor;
            float cubed = factor * squared;
            float part1 = ((2.0f * cubed) - (3.0f * squared)) + 1.0f;
            float part2 = (-2.0f * cubed) + (3.0f * squared);
            float part3 = (cubed - (2.0f * squared)) + factor;
            float part4 = cubed - squared;

            result = new Vector4(
                (((value1.X * part1) + (value2.X * part2)) + (tangent1.X * part3)) + (tangent2.X * part4),
                (((value1.Y * part1) + (value2.Y * part2)) + (tangent1.Y * part3)) + (tangent2.Y * part4),
                (((value1.Z * part1) + (value2.Z * part2)) + (tangent1.Z * part3)) + (tangent2.Z * part4),
                (((value1.W * part1) + (value2.W * part2)) + (tangent1.W * part3)) + (tangent2.W * part4));
        }
        public static Vector4 Hermite(ref Vector4 value1, ref Vector4 tangent1, ref Vector4 value2, ref Vector4 tangent2, float factor)
        {
            Vector4 result;
            Hermite(ref value1, ref tangent1, ref value2, ref tangent2, factor, out result);
            return result;
        }
        public static Vector4 Hermite(Vector4 value1, Vector4 tangent1, Vector4 value2, Vector4 tangent2, float factor)
        {
            Vector4 result;
            Hermite(ref value1, ref tangent1, ref value2, ref tangent2, factor, out result);
            return result;
        }

        public static void Length(ref Vector4 value, out float result)
        {
            result = (float)System.Math.Sqrt(value.X * value.X + value.Y * value.Y + value.Z * value.Z + value.W * value.W);
        }
        public static float Length(ref Vector4 value)
        {
            return (float)System.Math.Sqrt(value.X * value.X + value.Y * value.Y + value.Z * value.Z + value.W * value.W);
        }
        public static float Length(Vector4 value)
        {
            return (float)System.Math.Sqrt(value.X * value.X + value.Y * value.Y + value.Z * value.Z + value.W * value.W);
        }
        public float Length()
        {
            return Length(ref this);
        }

        public static void LengthSq(ref Vector4 value, out float result)
        {
            result = value.X * value.X + value.Y * value.Y + value.Z * value.Z + value.W * value.W;
        }
        public static float LengthSq(ref Vector4 value)
        {
            return value.X * value.X + value.Y * value.Y + value.Z * value.Z + value.W * value.W;
        }
        public static float LengthSq(Vector4 value)
        {
            return value.X * value.X + value.Y * value.Y + value.Z * value.Z + value.W * value.W;
        }
        public float LengthSq()
        {
            return LengthSq(ref this);
        }

        public static void Lerp(ref Vector4 start, ref Vector4 end, float factor, out Vector4 result)
        {
            result = new Vector4(
                FMath.Lerp(start.X, end.X, factor),
                FMath.Lerp(start.Y, end.Y, factor),
                FMath.Lerp(start.Z, end.Z, factor),
                FMath.Lerp(start.W, end.W, factor)
                );
        }
        public static Vector4 Lerp(ref Vector4 start, ref Vector4 end, float factor)
        {
            Vector4 result;
            Lerp(ref start, ref end, factor, out result);
            return result;
        }
        public static Vector4 Lerp(Vector4 start, Vector4 end, float factor)
        {
            Vector4 result;
            Lerp(ref start, ref end, factor, out result);
            return result;
        }

        public static void Maximize(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
        {
            result = new Vector4()
            {
                X = value1.X <= value2.X ? value2.X : value1.X,
                Y = value1.Y <= value2.Y ? value2.Y : value1.Y,
                Z = value1.Z <= value2.Z ? value2.Z : value1.Z,
                W = value1.W <= value2.W ? value2.W : value1.W,
            };
        }
        public static Vector4 Maximize(ref Vector4 value1, ref Vector4 value2)
        {
            Vector4 result;
            Maximize(ref value1, ref value2, out result);
            return result;
        }
        public static Vector4 Maximize(Vector4 value1, Vector4 value2)
        {
            Vector4 result;
            Maximize(ref value1, ref value2, out result);
            return result;
        }
        public void Maximize(ref Vector4 value)
        {
            Maximize(ref this, ref value, out this);
        }
        public void Maximize(Vector4 value)
        {
            Maximize(ref this, ref value, out this);
        }

        public static void Minimize(ref Vector4 value1, ref Vector4 value2, out Vector4 result)
        {
            result = new Vector4()
            {
                X = value1.X >= value2.X ? value2.X : value1.X,
                Y = value1.Y >= value2.Y ? value2.Y : value1.Y,
                Z = value1.Z >= value2.Z ? value2.Z : value1.Z,
                W = value1.W >= value2.W ? value2.W : value1.W,
            };
        }
        public static Vector4 Minimize(ref Vector4 value1, ref Vector4 value2)
        {
            Vector4 result;
            Minimize(ref value1, ref value2, out result);
            return result;
        }
        public static Vector4 Minimize(Vector4 value1, Vector4 value2)
        {
            Vector4 result;
            Minimize(ref value1, ref value2, out result);
            return result;
        }
        public void Minimize(ref Vector4 value)
        {
            Minimize(ref this, ref value, out this);
        }
        public void Minimize(Vector4 value)
        {
            Minimize(ref this, ref value, out this);
        }

        /// <summary>
        /// Returns the value of the vector's largest component.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static void Max(ref Vector4 value, out float result)
        {
            result = System.Math.Max(value.X, System.Math.Max(value.Y, System.Math.Max(value.Z, value.W)));
        }
        public static float Max(ref Vector4 value)
        {
            return System.Math.Max(value.X, System.Math.Max(value.Y, System.Math.Max(value.Z, value.W)));
        }
        public static float Max(Vector4 value)
        {
            return System.Math.Max(value.X, System.Math.Max(value.Y, System.Math.Max(value.Z, value.W)));
        }
        public float Max()
        {
            return Max(ref this);
        }

        /// <summary>
        /// Returns the value of the vector's smallest component.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static void Min(ref Vector4 value, out float result)
        {
            result = System.Math.Min(value.X, System.Math.Min(value.Y, System.Math.Min(value.Z, value.W)));
        }
        public static float Min(ref Vector4 value)
        {
            return System.Math.Min(value.X, System.Math.Min(value.Y, System.Math.Min(value.Z, value.W)));
        }
        public static float Min(Vector4 value)
        {
            return System.Math.Min(value.X, System.Math.Min(value.Y, System.Math.Min(value.Z, value.W)));
        }
        public float Min()
        {
            return Min(ref this);
        }

        public static void Normalize(ref Vector4 value, out Vector4 result)
        {
            float lengthSq = value.Length();
            if (lengthSq < FMath.EPSILON)
            {
                result = ZERO;
                return;
            }
            float lengthInverse = 1.0f / FMath.Sqrt(lengthSq);
            result = new Vector4(value.X * lengthInverse, value.Y * lengthInverse, value.Z * lengthInverse, value.W * lengthInverse);
        }
        public static Vector4 Normalize(ref Vector4 value)
        {
            Vector4 result;
            Normalize(ref value, out result);
            return result;
        }
        public static Vector4 Normalize(Vector4 value)
        {
            Vector4 result;
            Normalize(ref value, out result);
            return result;
        }
        public void Normalize()
        {
            Normalize(ref this, out this);
        }

        public static void Wrap(ref Vector4 value, ref Vector4 minInclusive, ref Vector4 maxExclusive, out Vector4 result)
        {
            result = new Vector4(
                FMath.Wrap(value.X, minInclusive.X, maxExclusive.X),
                FMath.Wrap(value.Y, minInclusive.Y, maxExclusive.Y),
                FMath.Wrap(value.Z, minInclusive.Z, maxExclusive.Z),
                FMath.Wrap(value.W, minInclusive.W, maxExclusive.W));
        }
        public static Vector4 Wrap(ref Vector4 value, ref Vector4 minInclusive, ref Vector4 maxExclusive)
        {
            Vector4 result;
            Wrap(ref value, ref minInclusive, ref maxExclusive, out result);
            return result;
        }
        public static Vector4 Wrap(Vector4 value, Vector4 minInclusive, Vector4 maxExclusive)
        {
            Vector4 result;
            Wrap(ref value, ref minInclusive, ref maxExclusive, out result);
            return result;
        }
        public void Wrap(ref Vector4 minInclusive, ref Vector4 maxExclusive)
        {
            Wrap(ref this, ref minInclusive, ref maxExclusive, out this);
        }
        public void Wrap(Vector4 minInclusive, Vector4 maxExclusive)
        {
            Wrap(ref this, ref minInclusive, ref maxExclusive, out this);
        }

        public static void Transform(ref Vector4 value, ref Matrix transformation, out Vector4 result)
        {
            result.X = transformation.M11 * value.X +
                       transformation.M21 * value.Y +
                       transformation.M31 * value.Z +
                       transformation.M41 * value.W;
            result.Y = transformation.M12 * value.X +
                       transformation.M22 * value.Y +
                       transformation.M32 * value.Z +
                       transformation.M42 * value.W;
            result.Z = transformation.M13 * value.X +
                       transformation.M23 * value.Y +
                       transformation.M33 * value.Z +
                       transformation.M43 * value.W;
            result.W = transformation.M14 * value.X +
                       transformation.M24 * value.Y +
                       transformation.M34 * value.Z +
                       transformation.M44 * value.W;
        }
        public static Vector4 Transform(ref Vector4 value, ref Matrix transformation)
        {
            Vector4 result;
            Transform(ref value, ref transformation, out result);
            return result;
        }
        public static Vector4 Transform(Vector4 value, Matrix transformation)
        {
            Vector4 result;
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

        #endregion


        #region Conversion
        
        public Vector3 ToVector3()
        {
            return new Vector3(X, Y, Z);
        }

        public static Vector4 FromColor(Color color)
        {
            return new Vector4(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f, color.A / 255.0f);
        }
        public static Color ToColor(Vector4 color)
        {
            return Color.FromArgb((int)(color.X * 255.0f), (int)(color.Y * 255.0f), (int)(color.Z * 255.0f), (int)(color.W * 255.0f));
        }
        public Color ToColor()
        {
            return ToColor(this);
        }

        public float[] ToArray()
        {
            return new float[] { X, Y, Z, W };
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1} Z:{2} W:{3}", this.X, this.Y, this.Z, this.W);
        }
        public static implicit operator string(Vector4 value)
        {
            return value.ToString();
        }

        #endregion

    }

    public static class Vector4Extensions
    {
        public static void Write(this BinaryWriter bin, Vector4 value)
        {
            bin.Write(value.X);
            bin.Write(value.Y);
            bin.Write(value.Z);
            bin.Write(value.W);
        }

        public static Vector4 ReadVector4(this BinaryReader bin)
        {
            float x = bin.ReadSingle();
            float y = bin.ReadSingle();
            float z = bin.ReadSingle();
            float w = bin.ReadSingle();
            return new Vector4(x, y, z, w);
        }
    }

}
