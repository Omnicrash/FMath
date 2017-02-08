using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

namespace Frostfire.Math
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Quaternion : IEquatable<Quaternion>
    {
        public float X, Y, Z, W;

        public static readonly int SIZE_IN_BYTES = Marshal.SizeOf(typeof(Quaternion));

        //public static readonly Quaternion ZERO = new Quaternion();
        public static readonly Quaternion IDENTITY = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);

        public Quaternion(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return X;
                    case 1: return Y;
                    case 2: return Z;
                    case 3: return W;
                }
                throw new ArgumentOutOfRangeException("index", "Index out of range.");
            }

            set
            {
                switch (index)
                {
                    case 0: X = value; break;
                    case 1: Y = value; break;
                    case 2: Z = value; break;
                    case 3: W = value; break;
                    default: throw new ArgumentOutOfRangeException("index", "Index out of range.");
                }
            }
        }


        #region Operations

        public static void Add(ref Quaternion left, ref Quaternion right, out Quaternion result)
        {
            result = new Quaternion(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
        }
        public static Quaternion Add(ref Quaternion left, ref Quaternion right)
        {
            return new Quaternion(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
        }
        public static Quaternion operator +(Quaternion left, Quaternion right)
        {
            return new Quaternion(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
        }
        public void Add(ref Quaternion value)
        {
            this.X += value.X;
            this.Y += value.Y;
            this.Z += value.Z;
            this.W += value.W;
        }
        public void Add(Quaternion value)
        {
            this.X += value.X;
            this.Y += value.Y;
            this.Z += value.Z;
            this.W += value.W;
        }

        public static void Subtract(ref Quaternion left, ref Quaternion right, out Quaternion result)
        {
            result = new Quaternion(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
        }
        public static Quaternion Subtract(ref Quaternion left, ref Quaternion right)
        {
            return new Quaternion(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
        }
        public static Quaternion operator -(Quaternion left, Quaternion right)
        {
            return new Quaternion(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
        }
        public void Subtract(ref Quaternion value)
        {
            this.X -= value.X;
            this.Y -= value.Y;
            this.Z -= value.Z;
            this.W -= value.W;
        }
        public void Subtract(Quaternion value)
        {
            this.X -= value.X;
            this.Y -= value.Y;
            this.Z -= value.Z;
            this.W -= value.W;
        }

        public static void Multiply(ref Quaternion left, ref Quaternion right, out Quaternion result)
        {
            float lx = left.X;
            float ly = left.Y;
            float lz = left.Z;
            float lw = left.W;
            float rx = right.X;
            float ry = right.Y;
            float rz = right.Z;
            float rw = right.W;

            result.X = (rx * lw + lx * rw + ry * lz) - (rz * ly);
            result.Y = (ry * lw + ly * rw + rz * lx) - (rx * lz);
            result.Z = (rz * lw + lz * rw + rx * ly) - (ry * lx);
            result.W = (rw * lw) - (rx * lx + ry * ly + rz * lz);
        }
        public static Quaternion Multiply(ref Quaternion left, ref Quaternion right)
        {
            Quaternion result;
            Multiply(ref left, ref right, out result);
            return result;
        }
        public static Quaternion operator *(Quaternion left, Quaternion right)
        {
            Quaternion result;
            Multiply(ref left, ref right, out result);
            return result;
        }
        public void Multiply(ref Quaternion value)
        {
            Multiply(ref this, ref value, out this);
        }
        public void Multiply(Quaternion value)
        {
            Multiply(ref this, ref value, out this);
        }

        public static void Scale(ref Quaternion value, float scale, out Quaternion result)
        {
            result = new Quaternion(value.X * scale, value.Y * scale, value.Z * scale, value.W * scale);
        }
        public static Quaternion Scale(ref Quaternion value, float scale)
        {
            return new Quaternion(value.X * scale, value.Y * scale, value.Z * scale, value.W * scale);
        }
        public static Quaternion operator *(Quaternion value, float scale)
        {
            return new Quaternion(value.X * scale, value.Y * scale, value.Z * scale, value.W * scale);
        }
        public static Quaternion operator *(float scale, Quaternion value)
        {
            return new Quaternion(scale * value.X, scale * value.Y, scale * value.Z, scale * value.W);
        }
        public void Scale(float scale)
        {
            this.X *= scale;
            this.Y *= scale;
            this.Z *= scale;
            this.W *= scale;
        }

        public static void Negate(ref Quaternion value, out Quaternion result)
        {
            result = new Quaternion(-value.X, -value.Y, -value.Z, -value.W);
        }
        public static Quaternion Negate(ref Quaternion value)
        {
            return new Quaternion(-value.X, -value.Y, -value.Z, -value.W);
        }
        public static Quaternion operator -(Quaternion value)
        {
            return new Quaternion(-value.X, -value.Y, -value.Z, -value.W);
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

        public bool Equals(ref Quaternion value)
        {
            return
                System.Math.Abs(this.X - value.X) < FMath.EPSILON &&
                System.Math.Abs(this.Y - value.Y) < FMath.EPSILON &&
                System.Math.Abs(this.Z - value.Z) < FMath.EPSILON &&
                System.Math.Abs(this.W - value.W) < FMath.EPSILON;
        }
        public bool Equals(Quaternion value)
        {
            return Equals(ref value);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;
            return Equals((Quaternion)obj);
        }
        public static bool operator ==(Quaternion left, Quaternion right)
        {
            return left.Equals(ref right);
        }
        public static bool operator !=(Quaternion left, Quaternion right)
        {
            return !left.Equals(ref right);
        }

        #endregion


        #region Functions

        public static void Barycentric(ref Quaternion value1, ref Quaternion value2, ref Quaternion value3, float factor1, float factor2, out Quaternion result)
        {
            Quaternion start = Slerp(value1, value2, factor1 + factor2);
            Quaternion end = Slerp(value1, value3, factor1 + factor2);
            result = Slerp(start, end, factor2 / (factor1 + factor2));
        }
        public static Quaternion Barycentric(ref Quaternion value1, ref Quaternion value2, ref Quaternion value3, float factor1, float factor2)
        {
            Quaternion result;
            Barycentric(ref value1, ref value2, ref value3, factor1, factor2, out result);
            return result;
        }
        public static Quaternion Barycentric(Quaternion value1, Quaternion value2, Quaternion value3, float factor1, float factor2)
        {
            Quaternion result;
            Barycentric(ref value1, ref value2, ref value3, factor1, factor2, out result);
            return result;
        }

        public static void Conjugate(ref Quaternion value, out Quaternion result)
        {
            result = new Quaternion(-value.X, -value.Y, -value.Z, value.W);
        }
        public static Quaternion Conjugate(ref Quaternion value)
        {
            return new Quaternion(-value.X, -value.Y, -value.Z, value.W);
        }
        public static Quaternion Conjugate(Quaternion value)
        {
            return new Quaternion(-value.X, -value.Y, -value.Z, value.W);
        }
        public void Conjugate()
        {
            this.X = -X;
            this.Y = -Y;
            this.Z = -Z;
        }

        public static void Dot(ref Quaternion left, ref Quaternion right, out float result)
        {
            result = (left.X * right.X) + (left.Y * right.Y) + (left.Z * right.Z) + (left.W * right.W);
        }
        public static float Dot(ref Quaternion left, ref Quaternion right)
        {
            return (left.X * right.X) + (left.Y * right.Y) + (left.Z * right.Z) + (left.W * right.W);
        }
        public static float Dot(Quaternion left, Quaternion right)
        {
            return (left.X * right.X) + (left.Y * right.Y) + (left.Z * right.Z) + (left.W * right.W);
        }

        public static void Exp(ref Quaternion value, out Quaternion result)
        {
            float angle = (float)System.Math.Sqrt((value.X * value.X) + (value.Y * value.Y) + (value.Z * value.Z));
            float sin = (float)System.Math.Sin(angle);

            if (System.Math.Abs(sin) >= FMath.EPSILON)
            {
                float coeff = sin / angle;
                result.X = coeff * value.X;
                result.Y = coeff * value.Y;
                result.Z = coeff * value.Z;
            }
            else
                result = value;

            result.W = (float)System.Math.Cos(angle);
        }
        public static Quaternion Exp(ref Quaternion value)
        {
            Quaternion result;
            Exp(ref value, out result);
            return result;
        }
        public static Quaternion Exp(Quaternion value)
        {
            Quaternion result;
            Exp(ref value, out result);
            return result;
        }
        public void Exp()
        {
            Exp(ref this, out this);
        }

        public static void Invert(ref Quaternion value, out Quaternion result)
        {
            float lengthSq = value.LengthSq();
            if (lengthSq > FMath.EPSILON)
            {
                float invLengthSq = 1.0f / lengthSq;

                result = new Quaternion
                {
                    X = -value.X * invLengthSq,
                    Y = -value.Y * invLengthSq,
                    Z = -value.Z * invLengthSq,
                    W = value.W * invLengthSq
                };
            }
            else
                result = value;
        }
        public static Quaternion Invert(ref Quaternion value)
        {
            Quaternion result;
            Invert(ref value, out result);
            return result;
        }
        public static Quaternion Invert(Quaternion value)
        {
            Quaternion result;
            Invert(ref value, out result);
            return result;
        }
        public void Invert()
        {
            Invert(ref this, out this);
        }

        public static void Length(ref Quaternion value, out float result)
        {
            result = (float)System.Math.Sqrt((value.X * value.X) + (value.Y * value.Y) + (value.Z * value.Z) + (value.W * value.W));
        }
        public static float Length(ref Quaternion value)
        {
            return (float)System.Math.Sqrt((value.X * value.X) + (value.Y * value.Y) + (value.Z * value.Z) + (value.W * value.W));
        }
        public static float Length(Quaternion value)
        {
            return (float)System.Math.Sqrt((value.X * value.X) + (value.Y * value.Y) + (value.Z * value.Z) + (value.W * value.W));
        }
        public float Length()
        {
            return (float)System.Math.Sqrt((X * X) + (Y * Y) + (Z * Z) + (W * W));
        }

        public static void LengthSq(ref Quaternion value, out float result)
        {
            result = (value.X * value.X) + (value.Y * value.Y) + (value.Z * value.Z) + (value.W * value.W);
        }
        public static float LengthSq(ref Quaternion value)
        {
            return (value.X * value.X) + (value.Y * value.Y) + (value.Z * value.Z) + (value.W * value.W);
        }
        public static float LengthSq(Quaternion value)
        {
            return (value.X * value.X) + (value.Y * value.Y) + (value.Z * value.Z) + (value.W * value.W);
        }
        public float LengthSq()
        {
            return (X * X) + (Y * Y) + (Z * Z) + (W * W);
        }

        public static void Lerp(ref Quaternion start, ref Quaternion end, float factor, out Quaternion result)
        {
            float inverse = 1.0f - factor;

            if (Dot(start, end) >= 0.0f)
            {
                result.X = (inverse * start.X) + (factor * end.X);
                result.Y = (inverse * start.Y) + (factor * end.Y);
                result.Z = (inverse * start.Z) + (factor * end.Z);
                result.W = (inverse * start.W) + (factor * end.W);
            }
            else
            {
                result.X = (inverse * start.X) - (factor * end.X);
                result.Y = (inverse * start.Y) - (factor * end.Y);
                result.Z = (inverse * start.Z) - (factor * end.Z);
                result.W = (inverse * start.W) - (factor * end.W);
            }

            result.Normalize();
        }
        public static Quaternion Lerp(ref Quaternion start, ref Quaternion end, float factor)
        {
            Quaternion result;
            Lerp(ref start, ref end, factor, out result);
            return result;
        }

        public static void Ln(ref Quaternion value, out Quaternion result)
        {
            if (System.Math.Abs(value.W) < 1.0f)
            {
                float angle = (float)System.Math.Acos(value.W);
                float sin = (float)System.Math.Sin(angle);

                if (System.Math.Abs(sin) >= FMath.EPSILON)
                {
                    float coeff = angle / sin;
                    result.X = value.X * coeff;
                    result.Y = value.Y * coeff;
                    result.Z = value.Z * coeff;
                }
                else
                    result = value;
            }
            else
                result = value;

            result.W = 0.0f;
        }
        public static Quaternion Ln(ref Quaternion value)
        {
            Quaternion result;
            Ln(ref value, out result);
            return result;
        }
        public static Quaternion Ln(Quaternion value)
        {
            Quaternion result;
            Ln(ref value, out result);
            return result;
        }
        public void Ln()
        {
            Ln(ref this, out this);
        }

        public static void Normalize(ref Quaternion value, out Quaternion result)
        {
            float length = value.Length();
            if (length > FMath.EPSILON)
            {
                float invLength = 1.0f / length;
                result = new Quaternion
                {
                    X = value.X * invLength,
                    Y = value.Y * invLength,
                    Z = value.Z * invLength,
                    W = value.W * invLength
                };
            }
            else
                result = value;
        }
        public static Quaternion Normalize(ref Quaternion value)
        {
            Quaternion result;
            Normalize(ref value, out result);
            return result;
        }
        public static Quaternion Normalize(Quaternion value)
        {
            Quaternion result;
            Normalize(ref value, out result);
            return result;
        }
        public void Normalize()
        {
            Normalize(ref this, out this);
        }
        
        public static void Slerp(ref Quaternion start, ref Quaternion end, float factor, out Quaternion result)
        {
            float opposite;
            float inverse;
            float dot = Dot(start, end);

            if (System.Math.Abs(dot) > 1.0f - FMath.EPSILON)
            {
                inverse = 1.0f - factor;
                opposite = factor * System.Math.Sign(dot);
            }
            else
            {
                float acos = (float)System.Math.Acos(System.Math.Abs(dot));
                float invSin = 1.0f / (float)System.Math.Sin(acos);

                inverse = (float)System.Math.Sin((1.0f - factor) * acos) * invSin;
                opposite = (float)System.Math.Sin(factor * acos) * invSin * System.Math.Sign(dot);
            }

            result.X = (inverse * start.X) + (opposite * end.X);
            result.Y = (inverse * start.Y) + (opposite * end.Y);
            result.Z = (inverse * start.Z) + (opposite * end.Z);
            result.W = (inverse * start.W) + (opposite * end.W);
        }
        public static Quaternion Slerp(ref Quaternion start, ref Quaternion end, float factor)
        {
            Quaternion result;
            Slerp(ref start, ref end, factor, out result);
            return result;
        }
        public static Quaternion Slerp(Quaternion start, Quaternion end, float factor)
        {
            Quaternion result;
            Slerp(ref start, ref end, factor, out result);
            return result;
        }

        public static void Squad(ref Quaternion value1, ref Quaternion value2, ref Quaternion value3, ref Quaternion value4, float factor, out Quaternion result)
        {
            Quaternion start = Slerp(value1, value4, factor);
            Quaternion end = Slerp(value2, value3, factor);
            result = Slerp(start, end, 2.0f * factor * (1.0f - factor));
        }
        public static Quaternion Squad(ref Quaternion value1, ref Quaternion value2, ref Quaternion value3, ref Quaternion value4, float factor)
        {
            Quaternion result;
            Squad(ref value1, ref value2, ref value3, ref value4, factor, out result);
            return result;
        }
        public static Quaternion Squad(Quaternion value1, Quaternion value2, Quaternion value3, Quaternion value4, float factor)
        {
            Quaternion result;
            Squad(ref value1, ref value2, ref value3, ref value4, factor, out result);
            return result;
        }

        public static void SquadSetup(ref Quaternion value1, ref Quaternion value2, ref Quaternion value3, ref Quaternion value4, out Quaternion result1, out Quaternion result2, out Quaternion result3)
        {
            Quaternion q0 = (value1 + value2).LengthSq() < (value1 - value2).LengthSq() ? -value1 : value1;
            Quaternion q2 = (value2 + value3).LengthSq() < (value2 - value3).LengthSq() ? -value3 : value3;
            Quaternion q3 = (value3 + value4).LengthSq() < (value3 - value4).LengthSq() ? -value4 : value4;
            Quaternion q1 = value2;

            Quaternion q1Exp = Exp(q1);
            Quaternion q2Exp = Exp(q2);

            result1 = q1 * Exp(-0.25f * (Ln(q1Exp * q2) + Ln(q1Exp * q0)));
            result2 = q2 * Exp(-0.25f * (Ln(q2Exp * q3) + Ln(q2Exp * q1)));
            result3 = q2;
        }
        public static void SquadSetup(Quaternion value1, Quaternion value2, Quaternion value3, Quaternion value4, out Quaternion result1, out Quaternion result2, out Quaternion result3)
        {
            SquadSetup(ref value1, ref value2, ref value3, ref value4, out result1, out result2, out result3);
        }

        #endregion


        #region Conversion

        public static void FromAxisAngle(ref Vector3 axis, float angle, out Quaternion result)
        {
            axis.Normalize();

            float half = angle * 0.5f;
            float sin = (float)System.Math.Sin(half);
            float cos = (float)System.Math.Cos(half);

            result.X = axis.X * sin;
            result.Y = axis.Y * sin;
            result.Z = axis.Z * sin;
            result.W = cos;
        }
        public static Quaternion FromAxisAngle(ref Vector3 axis, float angle)
        {
            Quaternion result;
            FromAxisAngle(ref axis, angle, out result);
            return result;
        }
        public static Quaternion FromAxisAngle(Vector3 axis, float angle)
        {
            Quaternion result;
            FromAxisAngle(ref axis, angle, out result);
            return result;
        }

        public void ToAxisAngle(out Vector3 axis, out float angle)
        {
            float length = (this.X * this.X) + (this.Y * this.Y) + (this.Z * this.Z);
            if (length < FMath.EPSILON)
            {
                angle = 0.0f;
                axis = Vector3.UNIT_X;
                return;
            }

            angle = 2.0f * (float)System.Math.Acos(this.W);
            float inv = 1.0f / length;
            axis = new Vector3(this.X * inv, this.Y * inv, this.Z * inv);
        }

        public static void FromMatrix(ref Matrix rotation, out Quaternion result)
        {
            float sqrt;
            float half;
            float scale = rotation.M11 + rotation.M22 + rotation.M33;

            if (scale > 0.0f)
            {
                sqrt = (float)System.Math.Sqrt(scale + 1.0f);
                result.W = sqrt * 0.5f;
                sqrt = 0.5f / sqrt;

                result.X = (rotation.M23 - rotation.M32) * sqrt;
                result.Y = (rotation.M31 - rotation.M13) * sqrt;
                result.Z = (rotation.M12 - rotation.M21) * sqrt;
            }
            else if ((rotation.M11 >= rotation.M22) && (rotation.M11 >= rotation.M33))
            {
                sqrt = (float)System.Math.Sqrt(1.0f + rotation.M11 - rotation.M22 - rotation.M33);
                half = 0.5f / sqrt;

                result.X = 0.5f * sqrt;
                result.Y = (rotation.M12 + rotation.M21) * half;
                result.Z = (rotation.M13 + rotation.M31) * half;
                result.W = (rotation.M23 - rotation.M32) * half;
            }
            else if (rotation.M22 > rotation.M33)
            {
                sqrt = (float)System.Math.Sqrt(1.0f + rotation.M22 - rotation.M11 - rotation.M33);
                half = 0.5f / sqrt;

                result.X = (rotation.M21 + rotation.M12) * half;
                result.Y = 0.5f * sqrt;
                result.Z = (rotation.M32 + rotation.M23) * half;
                result.W = (rotation.M31 - rotation.M13) * half;
            }
            else
            {
                sqrt = (float)System.Math.Sqrt(1.0f + rotation.M33 - rotation.M11 - rotation.M22);
                half = 0.5f / sqrt;

                result.X = (rotation.M31 + rotation.M13) * half;
                result.Y = (rotation.M32 + rotation.M23) * half;
                result.Z = 0.5f * sqrt;
                result.W = (rotation.M12 - rotation.M21) * half;
            }
        }
        public static Quaternion FromMatrix(ref Matrix rotation)
        {
            Quaternion result;
            FromMatrix(ref rotation, out result);
            return result;
        }
        public static Quaternion FromMatrix(Matrix rotation)
        {
            Quaternion result;
            FromMatrix(ref rotation, out result);
            return result;
        }

        public static void FromEulerAngles(float pitch, float yaw, float roll, out Quaternion result)
        {
            float halfRoll = roll * 0.5f;
            float halfPitch = pitch * 0.5f;
            float halfYaw = yaw * 0.5f;

            float sinRoll = (float)System.Math.Sin(halfRoll);
            float cosRoll = (float)System.Math.Cos(halfRoll);
            float sinPitch = (float)System.Math.Sin(halfPitch);
            float cosPitch = (float)System.Math.Cos(halfPitch);
            float sinYaw = (float)System.Math.Sin(halfYaw);
            float cosYaw = (float)System.Math.Cos(halfYaw);

            result.X = (cosYaw * sinPitch * cosRoll) + (sinYaw * cosPitch * sinRoll);
            result.Y = (sinYaw * cosPitch * cosRoll) - (cosYaw * sinPitch * sinRoll);
            result.Z = (cosYaw * cosPitch * sinRoll) - (sinYaw * sinPitch * cosRoll);
            result.W = (cosYaw * cosPitch * cosRoll) + (sinYaw * sinPitch * sinRoll);
        }
        public static void FromEulerAngles(Vector3 rotation, out Quaternion result)
        {
            FromEulerAngles(rotation.X, rotation.Y, rotation.Z, out result);
        }
        public static Quaternion FromEulerAngles(float pitch, float yaw, float roll)
        {
            Quaternion result;
            FromEulerAngles(pitch, yaw, roll, out result);
            return result;
        }
        public static void FromEulerAngles(ref Vector3 rotation, out Quaternion result)
        {
            FromEulerAngles(rotation.X, rotation.Y, rotation.Z, out result);
        }
        public static Quaternion FromEulerAngles(ref Vector3 rotation)
        {
            return FromEulerAngles(rotation.X, rotation.Y, rotation.Z);
        }
        public static Quaternion FromEulerAngles(Vector3 rotation)
        {
            return FromEulerAngles(rotation.X, rotation.Y, rotation.Z);
        }

        public static void ToEulerAngles(ref Quaternion rotation, out Vector3 result)
        {
            // Pitch
            result.X = FMath.Atan2(2.0f * (rotation.Y * rotation.Z + rotation.W * rotation.X), rotation.W * rotation.W - rotation.X * rotation.X - rotation.Y * rotation.Y + rotation.Z * rotation.Z);
            //result.X = FMath.Atan2(2.0f * rotation.X * rotation.W - 2.0f * rotation.Y * rotation.Z, 1.0f - 2.0f * rotation.X * rotation.X - 2.0f * rotation.Z * rotation.Z);
            // Yaw
            result.Y = FMath.Asin(-2.0f * (rotation.X * rotation.Z - rotation.W * rotation.Y));
            //result.Y = FMath.Atan2(2.0f * rotation.Y * rotation.W - 2.0f * rotation.X * rotation.Z, 1.0f - 2.0f * rotation.Y * rotation.Y - 2.0f * rotation.Z * rotation.Z);
            // Roll
            result.Z = FMath.Atan2(2.0f * (rotation.X * rotation.Y + rotation.W * rotation.Z), rotation.W * rotation.W + rotation.X * rotation.X - rotation.Y * rotation.Y - rotation.Z * rotation.Z);
            //result.Z = FMath.Asin(2.0f * rotation.X * rotation.Y + 2.0f * rotation.Z * rotation.W);
        }
        public static Vector3 ToEulerAngles(ref Quaternion rotation)
        {
            Vector3 result;
            ToEulerAngles(ref rotation, out result);
            return result;
        }
        public static Vector3 ToEulerAngles(Quaternion rotation)
        {
            Vector3 result;
            ToEulerAngles(ref rotation, out result);
            return result;
        }
        public Vector3 ToEulerAngles()
        {
            return ToEulerAngles(ref this);
        }

        public float[] ToArray()
        {
            return new float[] { X, Y, Z, W };
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1} Z:{2} W:{3}", X, Y, Z, W);
        }
        
        #endregion

    }

    public static class QuaternionExtensions
    {
        public static void Write(this BinaryWriter bin, Quaternion value)
        {
            bin.Write(value.X);
            bin.Write(value.Y);
            bin.Write(value.Z);
            bin.Write(value.W);
        }

        public static Quaternion ReadQuaternion(this BinaryReader bin)
        {
            float x = bin.ReadSingle();
            float y = bin.ReadSingle();
            float z = bin.ReadSingle();
            float w = bin.ReadSingle();
            return new Quaternion(x, y, z, w);
        }
    }

}
