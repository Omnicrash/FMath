using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace FMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Matrix : IEquatable<Matrix>
    {
        public float
            M11, M12, M13, M14,
            M21, M22, M23, M24,
            M31, M32, M33, M34,
            M41, M42, M43, M44;

        public static readonly int SIZE_IN_BYTES = Marshal.SizeOf(typeof(Matrix));

        public static readonly Matrix ZERO = new Matrix();
        public static readonly Matrix IDENTITY = new Matrix() { M11 = 1.0f, M22 = 1.0f, M33 = 1.0f, M44 = 1.0f };

        public Matrix(float value)
        {
            M11 = M12 = M13 = M14 =
            M21 = M22 = M23 = M24 =
            M31 = M32 = M33 = M34 =
            M41 = M42 = M43 = M44 = value;
        }
        public Matrix(float[] values)
        {
            if (values == null)
                throw new ArgumentNullException("values");
            if (values.Length != 16)
                throw new ArgumentOutOfRangeException("values", "Matrix must be defined by 16 values.");

            M11 = values[0];
            M12 = values[1];
            M13 = values[2];
            M14 = values[3];

            M21 = values[4];
            M22 = values[5];
            M23 = values[6];
            M24 = values[7];

            M31 = values[8];
            M32 = values[9];
            M33 = values[10];
            M34 = values[11];

            M41 = values[12];
            M42 = values[13];
            M43 = values[14];
            M44 = values[15];
        }

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return M11;
                    case 1: return M12;
                    case 2: return M13;
                    case 3: return M14;
                    case 4: return M21;
                    case 5: return M22;
                    case 6: return M23;
                    case 7: return M24;
                    case 8: return M31;
                    case 9: return M32;
                    case 10: return M33;
                    case 11: return M34;
                    case 12: return M41;
                    case 13: return M42;
                    case 14: return M43;
                    case 15: return M44;
                    default: throw new ArgumentOutOfRangeException("index", "Index out of range.");
                }
            }
            set
            {
                switch (index)
                {
                    case 0: M11 = value; break;
                    case 1: M12 = value; break;
                    case 2: M13 = value; break;
                    case 3: M14 = value; break;
                    case 4: M21 = value; break;
                    case 5: M22 = value; break;
                    case 6: M23 = value; break;
                    case 7: M24 = value; break;
                    case 8: M31 = value; break;
                    case 9: M32 = value; break;
                    case 10: M33 = value; break;
                    case 11: M34 = value; break;
                    case 12: M41 = value; break;
                    case 13: M42 = value; break;
                    case 14: M43 = value; break;
                    case 15: M44 = value; break;
                    default: throw new ArgumentOutOfRangeException("index", "Index out of range.");
                }
            }
        }
        public float this[int row, int column]
        {
            get
            {
                if (row < 0 || row > 3)
                    throw new ArgumentOutOfRangeException("row");
                if (column < 0 || column > 3)
                    throw new ArgumentOutOfRangeException("column");

                return this[(row * 4) + column];
            }
            set
            {
                if (row < 0 || row > 3)
                    throw new ArgumentOutOfRangeException("row");
                if (column < 0 || column > 3)
                    throw new ArgumentOutOfRangeException("column");

                this[(row * 4) + column] = value;
            }
        }

        public Vector4 Row1
        {
            get { return new Vector4(M11, M12, M13, M14); }
            set { M11 = value.X; M12 = value.Y; M13 = value.Z; M14 = value.W; }
        }
        public Vector4 Row2
        {
            get { return new Vector4(M21, M22, M23, M24); }
            set { M21 = value.X; M22 = value.Y; M23 = value.Z; M24 = value.W; }
        }
        public Vector4 Row3
        {
            get { return new Vector4(M31, M32, M33, M34); }
            set { M31 = value.X; M32 = value.Y; M33 = value.Z; M34 = value.W; }
        }
        public Vector4 Row4
        {
            get { return new Vector4(M41, M42, M43, M44); }
            set { M41 = value.X; M42 = value.Y; M43 = value.Z; M44 = value.W; }
        }

        public Vector4 Column1
        {
            get { return new Vector4(M11, M21, M31, M41); }
            set { M11 = value.X; M21 = value.Y; M31 = value.Z; M41 = value.W; }
        }
        public Vector4 Column2
        {
            get { return new Vector4(M12, M22, M32, M42); }
            set { M12 = value.X; M22 = value.Y; M32 = value.Z; M42 = value.W; }
        }
        public Vector4 Column3
        {
            get { return new Vector4(M13, M23, M33, M43); }
            set { M13 = value.X; M23 = value.Y; M33 = value.Z; M43 = value.W; }
        }
        public Vector4 Column4
        {
            get { return new Vector4(M14, M24, M34, M44); }
            set { M14 = value.X; M24 = value.Y; M34 = value.Z; M44 = value.W; }
        }

        public Vector3 Right
        {
            get { return new Vector3(M11, M12, M13); }
            set { M11 = value.X; M12 = value.Y; M13 = value.Z; }
        }
        public Vector3 Up
        {
            get { return new Vector3(M21, M22, M23); }
            set { M21 = value.X; M22 = value.Y; M23 = value.Z; }
        }
        public Vector3 Forward
        {
            get { return new Vector3(M31, M32, M33); }
            set { M31 = value.X; M32 = value.Y; M33 = value.Z; }
        }
        public Vector3 Position
        {
            get { return new Vector3(M41, M42, M43); }
            set { M41 = value.X; M42 = value.Y; M43 = value.Z; }
        }


        #region Operations

        public static void Add(ref Matrix left, ref Matrix right, out Matrix result)
        {
            result.M11 = left.M11 + right.M11;
            result.M12 = left.M12 + right.M12;
            result.M13 = left.M13 + right.M13;
            result.M14 = left.M14 + right.M14;
            result.M21 = left.M21 + right.M21;
            result.M22 = left.M22 + right.M22;
            result.M23 = left.M23 + right.M23;
            result.M24 = left.M24 + right.M24;
            result.M31 = left.M31 + right.M31;
            result.M32 = left.M32 + right.M32;
            result.M33 = left.M33 + right.M33;
            result.M34 = left.M34 + right.M34;
            result.M41 = left.M41 + right.M41;
            result.M42 = left.M42 + right.M42;
            result.M43 = left.M43 + right.M43;
            result.M44 = left.M44 + right.M44;
        }
        public static Matrix Add(ref Matrix left, ref Matrix right)
        {
            Matrix result;
            Add(ref left, ref right, out result);
            return result;
        }
        public static Matrix operator +(Matrix left, Matrix right)
        {
            Matrix result;
            Add(ref left, ref right, out result);
            return result;
        }
        public void Add(ref Matrix value)
        {
            M11 += value.M11; M12 += value.M12; M13 += value.M13; M14 += value.M14;
            M21 += value.M21; M22 += value.M22; M23 += value.M23; M24 += value.M24;
            M31 += value.M31; M32 += value.M32; M33 += value.M33; M34 += value.M34;
            M41 += value.M41; M42 += value.M42; M43 += value.M43; M44 += value.M44;
        }
        public void Add(Matrix value)
        {
            M11 += value.M11; M12 += value.M12; M13 += value.M13; M14 += value.M14;
            M21 += value.M21; M22 += value.M22; M23 += value.M23; M24 += value.M24;
            M31 += value.M31; M32 += value.M32; M33 += value.M33; M34 += value.M34;
            M41 += value.M41; M42 += value.M42; M43 += value.M43; M44 += value.M44;
        }

        public static void Subtract(ref Matrix left, ref Matrix right, out Matrix result)
        {
            result.M11 = left.M11 - right.M11;
            result.M12 = left.M12 - right.M12;
            result.M13 = left.M13 - right.M13;
            result.M14 = left.M14 - right.M14;
            result.M21 = left.M21 - right.M21;
            result.M22 = left.M22 - right.M22;
            result.M23 = left.M23 - right.M23;
            result.M24 = left.M24 - right.M24;
            result.M31 = left.M31 - right.M31;
            result.M32 = left.M32 - right.M32;
            result.M33 = left.M33 - right.M33;
            result.M34 = left.M34 - right.M34;
            result.M41 = left.M41 - right.M41;
            result.M42 = left.M42 - right.M42;
            result.M43 = left.M43 - right.M43;
            result.M44 = left.M44 - right.M44;
        }
        public static Matrix Subtract(ref Matrix left, ref Matrix right)
        {
            Matrix result;
            Subtract(ref left, ref right, out result);
            return result;
        }
        public static Matrix operator -(Matrix left, Matrix right)
        {
            Matrix result;
            Subtract(ref left, ref right, out result);
            return result;
        }
        public void Subtract(ref Matrix value)
        {
            M11 -= value.M11; M12 -= value.M12; M13 -= value.M13; M14 -= value.M14;
            M21 -= value.M21; M22 -= value.M22; M23 -= value.M23; M24 -= value.M24;
            M31 -= value.M31; M32 -= value.M32; M33 -= value.M33; M34 -= value.M34;
            M41 -= value.M41; M42 -= value.M42; M43 -= value.M43; M44 -= value.M44;
        }
        public void Subtract(Matrix value)
        {
            M11 -= value.M11; M12 -= value.M12; M13 -= value.M13; M14 -= value.M14;
            M21 -= value.M21; M22 -= value.M22; M23 -= value.M23; M24 -= value.M24;
            M31 -= value.M31; M32 -= value.M32; M33 -= value.M33; M34 -= value.M34;
            M41 -= value.M41; M42 -= value.M42; M43 -= value.M43; M44 -= value.M44;
        }

        public static void Multiply(ref Matrix left, ref Matrix right, out Matrix result)
        {
            result.M11 = (left.M11 * right.M11) + (left.M12 * right.M21) + (left.M13 * right.M31) + (left.M14 * right.M41);
            result.M12 = (left.M11 * right.M12) + (left.M12 * right.M22) + (left.M13 * right.M32) + (left.M14 * right.M42);
            result.M13 = (left.M11 * right.M13) + (left.M12 * right.M23) + (left.M13 * right.M33) + (left.M14 * right.M43);
            result.M14 = (left.M11 * right.M14) + (left.M12 * right.M24) + (left.M13 * right.M34) + (left.M14 * right.M44);
            result.M21 = (left.M21 * right.M11) + (left.M22 * right.M21) + (left.M23 * right.M31) + (left.M24 * right.M41);
            result.M22 = (left.M21 * right.M12) + (left.M22 * right.M22) + (left.M23 * right.M32) + (left.M24 * right.M42);
            result.M23 = (left.M21 * right.M13) + (left.M22 * right.M23) + (left.M23 * right.M33) + (left.M24 * right.M43);
            result.M24 = (left.M21 * right.M14) + (left.M22 * right.M24) + (left.M23 * right.M34) + (left.M24 * right.M44);
            result.M31 = (left.M31 * right.M11) + (left.M32 * right.M21) + (left.M33 * right.M31) + (left.M34 * right.M41);
            result.M32 = (left.M31 * right.M12) + (left.M32 * right.M22) + (left.M33 * right.M32) + (left.M34 * right.M42);
            result.M33 = (left.M31 * right.M13) + (left.M32 * right.M23) + (left.M33 * right.M33) + (left.M34 * right.M43);
            result.M34 = (left.M31 * right.M14) + (left.M32 * right.M24) + (left.M33 * right.M34) + (left.M34 * right.M44);
            result.M41 = (left.M41 * right.M11) + (left.M42 * right.M21) + (left.M43 * right.M31) + (left.M44 * right.M41);
            result.M42 = (left.M41 * right.M12) + (left.M42 * right.M22) + (left.M43 * right.M32) + (left.M44 * right.M42);
            result.M43 = (left.M41 * right.M13) + (left.M42 * right.M23) + (left.M43 * right.M33) + (left.M44 * right.M43);
            result.M44 = (left.M41 * right.M14) + (left.M42 * right.M24) + (left.M43 * right.M34) + (left.M44 * right.M44);
        }
        public static Matrix Multiply(ref Matrix left, ref Matrix right)
        {
            Matrix result;
            Multiply(ref left, ref right, out result);
            return result;
        }
        public static Matrix operator *(Matrix left, Matrix right)
        {
            Matrix result;
            Multiply(ref left, ref right, out result);
            return result;
        }
        public void Multiply(ref Matrix value)
        {
            Multiply(ref this, ref value, out this);
        }
        public void Multiply(Matrix value)
        {
            Multiply(ref this, ref value, out this);
        }

        public static void Multiply(ref Matrix value, float scale, out Matrix result)
        {
            result.M11 = value.M11 * scale;
            result.M12 = value.M12 * scale;
            result.M13 = value.M13 * scale;
            result.M14 = value.M14 * scale;

            result.M21 = value.M21 * scale;
            result.M22 = value.M22 * scale;
            result.M23 = value.M23 * scale;
            result.M24 = value.M24 * scale;

            result.M31 = value.M31 * scale;
            result.M32 = value.M32 * scale;
            result.M33 = value.M33 * scale;
            result.M34 = value.M34 * scale;

            result.M41 = value.M41 * scale;
            result.M42 = value.M42 * scale;
            result.M43 = value.M43 * scale;
            result.M44 = value.M44 * scale;
        }
        public static Matrix Multiply(ref Matrix value, ref float scale)
        {
            Matrix result;
            Multiply(ref value, scale, out result);
            return result;
        }
        public static Matrix operator *(Matrix value, float scale)
        {
            Matrix result;
            Multiply(ref value, scale, out result);
            return result;
        }
        public void Multiply(float scale)
        {
            Multiply(ref this, scale, out this);
        }

        public static void Negate(ref Matrix value, out Matrix result)
        {
            result.M11 = -value.M11;
            result.M12 = -value.M12;
            result.M13 = -value.M13;
            result.M14 = -value.M14;
            result.M21 = -value.M21;
            result.M22 = -value.M22;
            result.M23 = -value.M23;
            result.M24 = -value.M24;
            result.M31 = -value.M31;
            result.M32 = -value.M32;
            result.M33 = -value.M33;
            result.M34 = -value.M34;
            result.M41 = -value.M41;
            result.M42 = -value.M42;
            result.M43 = -value.M43;
            result.M44 = -value.M44;
        }
        public static Matrix Negate(ref Matrix value)
        {
            Matrix result;
            Negate(ref value, out result);
            return result;
        }
        public static Matrix operator -(Matrix value)
        {
            Matrix result;
            Negate(ref value, out result);
            return result;
        }
        public void Negate()
        {
            M11 = -M11; M12 = -M12; M13 = -M13; M14 = -M14;
            M21 = -M21; M22 = -M22; M23 = -M23; M24 = -M24;
            M31 = -M31; M32 = -M32; M33 = -M33; M34 = -M34;
            M41 = -M41; M42 = -M42; M43 = -M43; M44 = -M44;
        }

        #endregion


        #region Comparison

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = M11.GetHashCode();
                hashCode = (hashCode * 397) ^ M12.GetHashCode();
                hashCode = (hashCode * 397) ^ M13.GetHashCode();
                hashCode = (hashCode * 397) ^ M14.GetHashCode();
                hashCode = (hashCode * 397) ^ M21.GetHashCode();
                hashCode = (hashCode * 397) ^ M22.GetHashCode();
                hashCode = (hashCode * 397) ^ M23.GetHashCode();
                hashCode = (hashCode * 397) ^ M24.GetHashCode();
                hashCode = (hashCode * 397) ^ M31.GetHashCode();
                hashCode = (hashCode * 397) ^ M32.GetHashCode();
                hashCode = (hashCode * 397) ^ M33.GetHashCode();
                hashCode = (hashCode * 397) ^ M34.GetHashCode();
                hashCode = (hashCode * 397) ^ M41.GetHashCode();
                hashCode = (hashCode * 397) ^ M42.GetHashCode();
                hashCode = (hashCode * 397) ^ M43.GetHashCode();
                hashCode = (hashCode * 397) ^ M44.GetHashCode();
                return hashCode;
            }
        }

        public bool Equals(ref Matrix value)
        {
            return (
                System.Math.Abs(value.M11 - M11) < FMath.EPSILON &&
                System.Math.Abs(value.M12 - M12) < FMath.EPSILON &&
                System.Math.Abs(value.M13 - M13) < FMath.EPSILON &&
                System.Math.Abs(value.M14 - M14) < FMath.EPSILON &&

                System.Math.Abs(value.M21 - M21) < FMath.EPSILON &&
                System.Math.Abs(value.M22 - M22) < FMath.EPSILON &&
                System.Math.Abs(value.M23 - M23) < FMath.EPSILON &&
                System.Math.Abs(value.M24 - M24) < FMath.EPSILON &&

                System.Math.Abs(value.M31 - M31) < FMath.EPSILON &&
                System.Math.Abs(value.M32 - M32) < FMath.EPSILON &&
                System.Math.Abs(value.M33 - M33) < FMath.EPSILON &&
                System.Math.Abs(value.M34 - M34) < FMath.EPSILON &&

                System.Math.Abs(value.M41 - M41) < FMath.EPSILON &&
                System.Math.Abs(value.M42 - M42) < FMath.EPSILON &&
                System.Math.Abs(value.M43 - M43) < FMath.EPSILON &&
                System.Math.Abs(value.M44 - M44) < FMath.EPSILON);
        }
        public bool Equals(Matrix value)
        {
            return Equals(ref value);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            return Equals((Matrix)obj);
        }
        public static bool operator ==(Matrix left, Matrix right)
        {
            return left.Equals(ref right);
        }
        public static bool operator !=(Matrix left, Matrix right)
        {
            return !left.Equals(ref right);
        }

        #endregion


        #region Functions

        public static void Abs(ref Matrix value, out Matrix result)
        {
            result.M11 = System.Math.Abs(value.M11);
            result.M12 = System.Math.Abs(value.M12);
            result.M13 = System.Math.Abs(value.M13);
            result.M14 = System.Math.Abs(value.M14);

            result.M21 = System.Math.Abs(value.M21);
            result.M22 = System.Math.Abs(value.M22);
            result.M23 = System.Math.Abs(value.M23);
            result.M24 = System.Math.Abs(value.M24);

            result.M31 = System.Math.Abs(value.M31);
            result.M32 = System.Math.Abs(value.M32);
            result.M33 = System.Math.Abs(value.M33);
            result.M34 = System.Math.Abs(value.M34);

            result.M41 = System.Math.Abs(value.M41);
            result.M42 = System.Math.Abs(value.M42);
            result.M43 = System.Math.Abs(value.M43);
            result.M44 = System.Math.Abs(value.M44);
        }
        public static Matrix Abs(ref Matrix value)
        {
            Matrix result;
            Abs(ref value, out result);
            return result;
        }
        public static Matrix Abs(Matrix value)
        {
            Matrix result;
            Abs(ref value, out result);
            return result;
        }
        public void Abs()
        {
           Abs(ref this, out this);
        }

        public static void AffineTransformation(float scaling, ref Vector3 rotationCenter, ref Quaternion rotation, ref Vector3 translation, out Matrix result)
        {
            result =
                Scaling(scaling) *
                Translation(-rotationCenter) *
                RotationQuaternion(ref rotation) *
                Translation(ref rotationCenter) *
                Translation(ref translation);
        }
        public static Matrix AffineTransformation(float scaling, ref Vector3 rotationCenter, ref Quaternion rotation, ref Vector3 translation)
        {
            Matrix result;
            AffineTransformation(scaling, ref rotationCenter, ref rotation, ref translation, out result);
            return result;
        }
        public static Matrix AffineTransformation(float scaling, Vector3 rotationCenter, Quaternion rotation, Vector3 translation)
        {
            Matrix result;
            AffineTransformation(scaling, ref rotationCenter, ref rotation, ref translation, out result);
            return result;
        }

        public static void AffineTransformation2D(float scaling, ref Vector2 rotationCenter, float rotation, ref Vector2 translation, out Matrix result)
        {
            result =
                Scaling(scaling, scaling, 1.0f) *
                Translation((-rotationCenter).ToVector3()) *
                RotationZ(rotation) *
                Translation(rotationCenter.ToVector3()) *
                Translation(translation.ToVector3());
        }
        public static Matrix AffineTransformation2D(float scaling, ref Vector2 rotationCenter, float rotation, ref Vector2 translation)
        {
            Matrix result;
            AffineTransformation2D(scaling, ref rotationCenter, rotation, ref translation, out result);
            return result;
        }
        public static Matrix AffineTransformation2D(float scaling, Vector2 rotationCenter, float rotation, Vector2 translation)
        {
            Matrix result;
            AffineTransformation2D(scaling, ref rotationCenter, rotation, ref translation, out result);
            return result;
        }

        public static void Billboard(ref Vector3 position, ref Vector3 cameraPosition, ref Vector3 cameraUpVector, ref Vector3 cameraForwardVector, out Matrix result)
        {
            Vector3 difference; Vector3.Subtract(ref position, ref cameraPosition, out difference);

            float lengthsq = difference.LengthSq();
            if (lengthsq < FMath.EPSILON)
                Vector3.Negate(ref cameraForwardVector, out difference);
            else
                difference.Multiply(1.0f / (float)System.Math.Sqrt(lengthsq));

            Vector3 crossed; Vector3.Cross(ref cameraUpVector, ref difference, out crossed);
            crossed.Normalize();
            Vector3 final; Vector3.Cross(ref difference, ref crossed, out final);

            result.M11 = crossed.X;
            result.M12 = crossed.Y;
            result.M13 = crossed.Z;
            result.M14 = 0.0f;
            result.M21 = final.X;
            result.M22 = final.Y;
            result.M23 = final.Z;
            result.M24 = 0.0f;
            result.M31 = difference.X;
            result.M32 = difference.Y;
            result.M33 = difference.Z;
            result.M34 = 0.0f;
            result.M41 = position.X;
            result.M42 = position.Y;
            result.M43 = position.Z;
            result.M44 = 1.0f;
        }
        public static Matrix Billboard(ref Vector3 position, ref Vector3 cameraPosition, ref Vector3 cameraUpVector, ref Vector3 cameraForwardVector)
        {
            Matrix result;
            Billboard(ref position, ref cameraPosition, ref cameraUpVector, ref cameraForwardVector, out result);
            return result;
        }
        public static Matrix Billboard(Vector3 position, Vector3 cameraPosition, Vector3 cameraUpVector, Vector3 cameraForwardVector)
        {
            Matrix result;
            Billboard(ref position, ref cameraPosition, ref cameraUpVector, ref cameraForwardVector, out result);
            return result;
        }

        public static float Determinant(ref Matrix value)
        {
            float temp1 = (value.M33 * value.M44) - (value.M34 * value.M43);
            float temp2 = (value.M32 * value.M44) - (value.M34 * value.M42);
            float temp3 = (value.M32 * value.M43) - (value.M33 * value.M42);
            float temp4 = (value.M31 * value.M44) - (value.M34 * value.M41);
            float temp5 = (value.M31 * value.M43) - (value.M33 * value.M41);
            float temp6 = (value.M31 * value.M42) - (value.M32 * value.M41);

            return ((((value.M11 * (((value.M22 * temp1) - (value.M23 * temp2)) + (value.M24 * temp3))) - (value.M12 * (((value.M21 * temp1) -
                (value.M23 * temp4)) + (value.M24 * temp5)))) + (value.M13 * (((value.M21 * temp2) - (value.M22 * temp4)) + (value.M24 * temp6)))) -
                (value.M14 * (((value.M21 * temp3) - (value.M22 * temp5)) + (value.M23 * temp6))));
        }
        public float Determinant(Matrix value)
        {
            return Determinant(ref value);
        }
        public float Determinant()
        {
            return Determinant(ref this);
        }

        public static void Invert(ref Matrix value, out Matrix result)
        {
            result = ZERO;

            float b0 = (value.M31 * value.M42) - (value.M32 * value.M41);
            float b1 = (value.M31 * value.M43) - (value.M33 * value.M41);
            float b2 = (value.M34 * value.M41) - (value.M31 * value.M44);
            float b3 = (value.M32 * value.M43) - (value.M33 * value.M42);
            float b4 = (value.M34 * value.M42) - (value.M32 * value.M44);
            float b5 = (value.M33 * value.M44) - (value.M34 * value.M43);

            float d11 = value.M22 * b5 + value.M23 * b4 + value.M24 * b3;
            float d12 = value.M21 * b5 + value.M23 * b2 + value.M24 * b1;
            float d13 = value.M21 * -b4 + value.M22 * b2 + value.M24 * b0;
            float d14 = value.M21 * b3 + value.M22 * -b1 + value.M23 * b0;

            float det = value.M11 * d11 - value.M12 * d12 + value.M13 * d13 - value.M14 * d14;
            if (Math.Abs(det) <= FMath.EPSILON)
                return;

            det = 1.0f / det;

            float a0 = (value.M11 * value.M22) - (value.M12 * value.M21);
            float a1 = (value.M11 * value.M23) - (value.M13 * value.M21);
            float a2 = (value.M14 * value.M21) - (value.M11 * value.M24);
            float a3 = (value.M12 * value.M23) - (value.M13 * value.M22);
            float a4 = (value.M14 * value.M22) - (value.M12 * value.M24);
            float a5 = (value.M13 * value.M24) - (value.M14 * value.M23);

            float d21 = value.M12 * b5 + value.M13 * b4 + value.M14 * b3;
            float d22 = value.M11 * b5 + value.M13 * b2 + value.M14 * b1;
            float d23 = value.M11 * -b4 + value.M12 * b2 + value.M14 * b0;
            float d24 = value.M11 * b3 + value.M12 * -b1 + value.M13 * b0;

            float d31 = value.M42 * a5 + value.M43 * a4 + value.M44 * a3;
            float d32 = value.M41 * a5 + value.M43 * a2 + value.M44 * a1;
            float d33 = value.M41 * -a4 + value.M42 * a2 + value.M44 * a0;
            float d34 = value.M41 * a3 + value.M42 * -a1 + value.M43 * a0;

            float d41 = value.M32 * a5 + value.M33 * a4 + value.M34 * a3;
            float d42 = value.M31 * a5 + value.M33 * a2 + value.M34 * a1;
            float d43 = value.M31 * -a4 + value.M32 * a2 + value.M34 * a0;
            float d44 = value.M31 * a3 + value.M32 * -a1 + value.M33 * a0;

            result.M11 = +d11 * det; result.M12 = -d21 * det; result.M13 = +d31 * det; result.M14 = -d41 * det;
            result.M21 = -d12 * det; result.M22 = +d22 * det; result.M23 = -d32 * det; result.M24 = +d42 * det;
            result.M31 = +d13 * det; result.M32 = -d23 * det; result.M33 = +d33 * det; result.M34 = -d43 * det;
            result.M41 = -d14 * det; result.M42 = +d24 * det; result.M43 = -d34 * det; result.M44 = +d44 * det;
        }
        public static Matrix Invert(ref Matrix value)
        {
            Matrix result;
            Invert(ref value, out result);
            return result;
        }
        public static Matrix Invert(Matrix value)
        {
            Matrix result;
            Invert(ref value, out result);
            return result;
        }
        public void Invert()
        {
            Invert(ref this, out this);
        }

        public static void Reflect(ref Plane plane, out Matrix result)
        {
            float x = plane.Normal.X;
            float y = plane.Normal.Y;
            float z = plane.Normal.Z;
            float x2 = -2.0f * x;
            float y2 = -2.0f * y;
            float z2 = -2.0f * z;

            result = new Matrix();
            result.M11 = (x2 * x) + 1.0f;
            result.M12 = y2 * x;
            result.M13 = z2 * x;
            result.M14 = 0.0f;
            result.M21 = x2 * y;
            result.M22 = (y2 * y) + 1.0f;
            result.M23 = z2 * y;
            result.M24 = 0.0f;
            result.M31 = x2 * z;
            result.M32 = y2 * z;
            result.M33 = (z2 * z) + 1.0f;
            result.M34 = 0.0f;
            result.M41 = x2 * plane.D;
            result.M42 = y2 * plane.D;
            result.M43 = z2 * plane.D;
            result.M44 = 1.0f;
        }
        public static Matrix Reflect(ref Plane plane)
        {
            Matrix result;
            Reflect(ref plane, out result);
            return result;
        }
        public static Matrix Reflect(Plane plane)
        {
            Matrix result;
            Reflect(ref plane, out result);
            return result;
        }

        public static void RotationAxisAngle(ref Vector3 axis, float angle, out Matrix result)
        {
            float x = axis.X;
            float y = axis.Y;
            float z = axis.Z;
            float cos = (float)System.Math.Cos(angle);
            float sin = (float)System.Math.Sin(angle);
            float xx = x * x;
            float yy = y * y;
            float zz = z * z;
            float xy = x * y;
            float xz = x * z;
            float yz = y * z;

            result = Matrix.IDENTITY;
            result.M11 = xx + (cos * (1.0f - xx));
            result.M12 = (xy - (cos * xy)) + (sin * z);
            result.M13 = (xz - (cos * xz)) - (sin * y);
            result.M21 = (xy - (cos * xy)) - (sin * z);
            result.M22 = yy + (cos * (1.0f - yy));
            result.M23 = (yz - (cos * yz)) + (sin * x);
            result.M31 = (xz - (cos * xz)) + (sin * y);
            result.M32 = (yz - (cos * yz)) - (sin * x);
            result.M33 = zz + (cos * (1.0f - zz));
        }
        public static Matrix RotationAxisAngle(ref Vector3 axis, float angle)
        {
            Matrix result;
            RotationAxisAngle(ref axis, angle, out result);
            return result;
        }
        public static Matrix RotationAxisAngle(Vector3 axis, float angle)
        {
            Matrix result;
            RotationAxisAngle(ref axis, angle, out result);
            return result;
        }

        public static void RotationQuaternion(ref Quaternion rotation, out Matrix result)
        {
            float xx = rotation.X * rotation.X;
            float yy = rotation.Y * rotation.Y;
            float zz = rotation.Z * rotation.Z;
            float xy = rotation.X * rotation.Y;
            float zw = rotation.Z * rotation.W;
            float zx = rotation.Z * rotation.X;
            float yw = rotation.Y * rotation.W;
            float yz = rotation.Y * rotation.Z;
            float xw = rotation.X * rotation.W;

            result = Matrix.IDENTITY;
            result.M11 = 1.0f - (2.0f * (yy + zz));
            result.M12 = 2.0f * (xy + zw);
            result.M13 = 2.0f * (zx - yw);
            result.M21 = 2.0f * (xy - zw);
            result.M22 = 1.0f - (2.0f * (zz + xx));
            result.M23 = 2.0f * (yz + xw);
            result.M31 = 2.0f * (zx + yw);
            result.M32 = 2.0f * (yz - xw);
            result.M33 = 1.0f - (2.0f * (yy + xx));
        }
        public static Matrix RotationQuaternion(ref Quaternion rotation)
        {
            Matrix result;
            RotationQuaternion(ref rotation, out result);
            return result;
        }
        public static Matrix RotationQuaternion(Quaternion rotation)
        {
            Matrix result;
            RotationQuaternion(ref rotation, out result);
            return result;
        }

        public static void RotationEulerAngles(float pitch, float yaw, float roll, out Matrix result)
        {
            Quaternion quaternion = Quaternion.FromEulerAngles(pitch, yaw, roll);
            RotationQuaternion(ref quaternion, out result);
        }
        public static Matrix RotationEulerAngles(float pitch, float yaw, float roll)
        {
            Matrix result;
            RotationEulerAngles(pitch, yaw, roll, out result);
            return result;
        }
        public void RotateEulerAngles(float pitch, float yaw, float roll)
        {
            Multiply(RotationEulerAngles(pitch, yaw, roll));
        }

        public static void RotationEulerAngles(ref Vector3 rotation, out Matrix result)
        {
            Quaternion quaternion = Quaternion.FromEulerAngles(rotation.X, rotation.Y, rotation.Z);
            RotationQuaternion(ref quaternion, out result);
        }
        public static Matrix RotationEulerAngles(ref Vector3 rotation)
        {
            Matrix result;
            RotationEulerAngles(ref rotation, out result);
            return result;
        }
        public static Matrix RotationEulerAngles(Vector3 rotation)
        {
            Matrix result;
            RotationEulerAngles(ref rotation, out result);
            return result;
        }
        
        public static void RotationX(float angle, out Matrix result)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);

            result = Matrix.IDENTITY;
            result.M22 = cos;
            result.M23 = sin;
            result.M32 = -sin;
            result.M33 = cos;
        }
        public static Matrix RotationX(float angle)
        {
            Matrix result;
            RotationX(angle, out result);
            return result;
        }

        public static void RotationY(float angle, out Matrix result)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);

            result = Matrix.IDENTITY;
            result.M11 = cos;
            result.M13 = -sin;
            result.M31 = sin;
            result.M33 = cos;
        }
        public static Matrix RotationY(float angle)
        {
            Matrix result;
            RotationX(angle, out result);
            return result;
        }

        public static void RotationZ(float angle, out Matrix result)
        {
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);

            result = Matrix.IDENTITY;
            result.M11 = cos;
            result.M12 = sin;
            result.M21 = -sin;
            result.M22 = cos;
        }
        public static Matrix RotationZ(float angle)
        {
            Matrix result;
            RotationX(angle, out result);
            return result;
        }

        public static void Scaling(float x, float y, float z, out Matrix result)
        {
            result = Matrix.IDENTITY;
            result.M11 = x;
            result.M22 = y;
            result.M33 = z;
        }
        public static Matrix Scaling(float x, float y, float z)
        {
            Matrix result;
            Scaling(x, y, z, out result);
            return result;
        }
        public void Scale(float x, float y, float z)
        {
            Multiply(Scaling(x, y, z));
        }

        public static void Scaling(ref Vector3 scale, out Matrix result)
        {
            result = Matrix.IDENTITY;
            result.M11 = scale.X;
            result.M22 = scale.Y;
            result.M33 = scale.Z;
        }
        public static Matrix Scaling(ref Vector3 scale)
        {
            Matrix result;
            Scaling(ref scale, out result);
            return result;
        }
        public static Matrix Scaling(Vector3 scale)
        {
            Matrix result;
            Scaling(ref scale, out result);
            return result;
        }

        public static void Scaling(float scale, out Matrix result)
        {
            result = Matrix.IDENTITY;
            result.M11 = result.M22 = result.M33 = scale;
        }
        public static Matrix Scaling(float scale)
        {
            Matrix result;
            Scaling(scale, out result);
            return result;
        }

        public static void Shadow(ref Vector4 light, ref Plane plane, out Matrix result)
        {
            float dot = (plane.Normal.X * light.X) + (plane.Normal.Y * light.Y) + (plane.Normal.Z * light.Z) + (plane.D * light.W);
            float x = -plane.Normal.X;
            float y = -plane.Normal.Y;
            float z = -plane.Normal.Z;
            float d = -plane.D;

            result = new Matrix();
            result.M11 = (x * light.X) + dot;
            result.M21 = y * light.X;
            result.M31 = z * light.X;
            result.M41 = d * light.X;
            result.M12 = x * light.Y;
            result.M22 = (y * light.Y) + dot;
            result.M32 = z * light.Y;
            result.M42 = d * light.Y;
            result.M13 = x * light.Z;
            result.M23 = y * light.Z;
            result.M33 = (z * light.Z) + dot;
            result.M43 = d * light.Z;
            result.M14 = x * light.W;
            result.M24 = y * light.W;
            result.M34 = z * light.W;
            result.M44 = (d * light.W) + dot;
        }
        public static Matrix Shadow(ref Vector4 light, ref Plane plane)
        {
            Matrix result;
            Shadow(ref light, ref plane, out result);
            return result;
        }
        public static Matrix Shadow(Vector4 light, Plane plane)
        {
            Matrix result;
            Shadow(ref light, ref plane, out result);
            return result;
        }

        public static float Trace(ref Matrix value)
        {
            return value.M11 + value.M22 + value.M33 + value.M44;
        }
        public static float Trace(Matrix value)
        {
            return Trace(ref value);
        }
        public float Trace()
        {
            return Trace(ref this);
        }

        public static void Transformation(ref Vector3 scalingCenter, ref Quaternion scalingRotation, ref Vector3 scaling, ref Vector3 rotationCenter, ref Quaternion rotation, ref Vector3 translation, out Matrix result)
        {
            Matrix sr = RotationQuaternion(scalingRotation);

            result = Translation(-scalingCenter) * Transpose(sr) * Scaling(scaling) * sr * Translation(scalingCenter) * Translation(-rotationCenter) *
                RotationQuaternion(rotation) * Translation(rotationCenter) * Translation(translation);
        }
        public static Matrix Transformation(ref Vector3 scalingCenter, ref Quaternion scalingRotation, ref Vector3 scaling, ref Vector3 rotationCenter, ref Quaternion rotation, ref Vector3 translation)
        {
            Matrix result;
            Transformation(ref scalingCenter, ref scalingRotation, ref scaling, ref rotationCenter, ref rotation, ref translation, out result);
            return result;
        }
        public static Matrix Transformation(Vector3 scalingCenter, Quaternion scalingRotation, Vector3 scaling, Vector3 rotationCenter, Quaternion rotation, Vector3 translation)
        {
            Matrix result;
            Transformation(ref scalingCenter, ref scalingRotation, ref scaling, ref rotationCenter, ref rotation, ref translation, out result);
            return result;
        }

        public static void Transformation2D(ref Vector2 scalingCenter, float scalingRotation, ref Vector2 scaling, ref Vector2 rotationCenter, float rotation, ref Vector2 translation, out Matrix result)
        {
            result =
                Translation((-scalingCenter).ToVector3()) * RotationZ(-scalingRotation) * Scaling(scaling.ToVector3()) * RotationZ(scalingRotation) * Translation(scalingCenter.ToVector3()) *
                Translation((-rotationCenter).ToVector3()) * RotationZ(rotation) * Translation(rotationCenter.ToVector3()) * Translation(translation.ToVector3());

            result.M33 = 1.0f;
            result.M44 = 1.0f;
        }
        public static Matrix Transformation2D(ref Vector2 scalingCenter, float scalingRotation, ref Vector2 scaling, ref Vector2 rotationCenter, float rotation, ref Vector2 translation)
        {
            Matrix result;
            Transformation2D(ref scalingCenter, scalingRotation, ref scaling, ref rotationCenter, rotation, ref translation, out result);
            return result;
        }
        public static Matrix Transformation2D(Vector2 scalingCenter, float scalingRotation, Vector2 scaling, Vector2 rotationCenter, float rotation, Vector2 translation)
        {
            Matrix result;
            Transformation2D(ref scalingCenter, scalingRotation, ref scaling, ref rotationCenter, rotation, ref translation, out result);
            return result;
        }

        public static void Translation(float x, float y, float z, out Matrix result)
        {
            result = Matrix.IDENTITY;
            result.M41 = x;
            result.M42 = y;
            result.M43 = z;
        }
        public static Matrix Translation(float x, float y, float z)
        {
            Matrix result;
            Translation(x, y, z, out result);
            return result;
        }
        public static void Translation(ref Vector3 value, out Matrix result)
        {
            result = Matrix.IDENTITY;
            result.M41 = value.X;
            result.M42 = value.Y;
            result.M43 = value.Z;
        }
        public static Matrix Translation(ref Vector3 value)
        {
            Matrix result;
            Translation(ref value, out result);
            return result;
        }
        public static Matrix Translation(Vector3 value)
        {
            Matrix result;
            Translation(ref value, out result);
            return result;
        }
        
        public static void Transpose(ref Matrix value, out Matrix result)
        {
            result.M11 = value.M11;
            result.M12 = value.M21;
            result.M13 = value.M31;
            result.M14 = value.M41;
            result.M21 = value.M12;
            result.M22 = value.M22;
            result.M23 = value.M32;
            result.M24 = value.M42;
            result.M31 = value.M13;
            result.M32 = value.M23;
            result.M33 = value.M33;
            result.M34 = value.M43;
            result.M41 = value.M14;
            result.M42 = value.M24;
            result.M43 = value.M34;
            result.M44 = value.M44;
        }
        public static Matrix Transpose(ref Matrix value)
        {
            Matrix result;
            Transpose(ref value, out result);
            return result;
        }
        public static Matrix Transpose(Matrix value)
        {
            Matrix result;
            Transpose(ref value, out result);
            return result;
        }
        public void Transpose()
        {
            this = Transpose(ref this);
        }

        #endregion


        #region Conversion

        public void ToSRT(out Vector3 scale, out Quaternion rotation, out Vector3 translation)
        {
            // Get the translation
            translation.X = this.M41;
            translation.Y = this.M42;
            translation.Z = this.M43;

            // Scaling is the length of the rows
            scale.X = (float)Math.Sqrt((M11 * M11) + (M12 * M12) + (M13 * M13));
            scale.Y = (float)Math.Sqrt((M21 * M21) + (M22 * M22) + (M23 * M23));
            scale.Z = (float)Math.Sqrt((M31 * M31) + (M32 * M32) + (M33 * M33));

            // If any of the scaling factors are zero, then the rotation matrix can not exist
            if (Math.Abs(scale.X) < FMath.EPSILON ||
                Math.Abs(scale.Y) < FMath.EPSILON ||
                Math.Abs(scale.Z) < FMath.EPSILON)
            {
                rotation = Quaternion.IDENTITY;
                return;
            }

            // The rotation is the leftover matrix after dividing out the scaling
            Matrix rotationmatrix = new Matrix();
            rotationmatrix.M11 = M11 / scale.X;
            rotationmatrix.M12 = M12 / scale.X;
            rotationmatrix.M13 = M13 / scale.X;

            rotationmatrix.M21 = M21 / scale.Y;
            rotationmatrix.M22 = M22 / scale.Y;
            rotationmatrix.M23 = M23 / scale.Y;

            rotationmatrix.M31 = M31 / scale.Z;
            rotationmatrix.M32 = M32 / scale.Z;
            rotationmatrix.M33 = M33 / scale.Z;

            rotationmatrix.M44 = 1.0f;

            rotation = Quaternion.FromMatrix(rotationmatrix);
        }
        
        public float[] ToArray()
        {
            return new[] { M11, M12, M13, M14, M21, M22, M23, M24, M31, M32, M33, M34, M41, M42, M43, M44 };
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "[M11:{0} M12:{1} M13:{2} M14:{3}] [M21:{4} M22:{5} M23:{6} M24:{7}] [M31:{8} M32:{9} M33:{10} M34:{11}] [M41:{12} M42:{13} M43:{14} M44:{15}]",
                M11, M12, M13, M14, M21, M22, M23, M24, M31, M32, M33, M34, M41, M42, M43, M44);
        }
        public static implicit operator string(Matrix value)
        {
            return value.ToString();
        }

        #endregion

    }
}
