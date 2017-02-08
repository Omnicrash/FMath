using System;
using System.Globalization;
using System.Runtime.InteropServices;
using static System.FormattableString;

namespace Frostfire.Math
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Plane : IEquatable<Plane>
    {
        public static readonly int SIZE_IN_BYTES = Marshal.SizeOf(typeof(Plane));

        public Vector3 Normal;
        public float D;

        public Plane(Vector4 value)
        {
            this.Normal = new Vector3(value.X, value.Y, value.Z);
            this.D = value.W;
        }
        public Plane(Vector3 point1, Vector3 point2, Vector3 point3)
        {
            Vector3 p21diff = point2 - point1;
            Vector3 p31diff = point3 - point1;

            float diffYZ = (p31diff.Z * p21diff.Y - p31diff.Y * p21diff.Z);
            float diffZX = (p31diff.X * p21diff.Z - p31diff.Z * p21diff.X);
            float diffXY = (p31diff.Y * p21diff.X - p31diff.X * p21diff.Y);
            float length = (float)System.Math.Sqrt(diffYZ * diffYZ + diffZX * diffZX + diffXY * diffXY);
            float invLength = 1.0f / length;
            this.Normal.X = invLength * diffYZ;
            this.Normal.Y = invLength * diffZX;
            this.Normal.Z = invLength * diffXY;
            this.D = -(point1.Y * Normal.Y + point1.X * Normal.X + point1.Z * Normal.Z);
        }
        public Plane(Vector3 point, Vector3 normal)
        {
            this.Normal = normal;
            this.D = -Vector3.Dot(normal, point);
        }
        public Plane(Vector3 normal, float d)
        {
            this.Normal = normal;
            this.D = d;
        }
        public Plane(float a, float b, float c, float d)
        {
            this.Normal = new Vector3(a, b, c);
            this.D = d;
        }


        #region Comparison

        public override int GetHashCode()
        {
            unchecked
            {
                return (Normal.GetHashCode() * 397) ^ D.GetHashCode();
            }
        }

        public bool Equals(ref Plane value)
        {
            return
                this.Normal == value.Normal &&
                System.Math.Abs(this.D - value.D) < FMath.EPSILON;
        }
        public bool Equals(Plane value)
        {
            return Equals(ref value);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            return this.Equals((Plane)obj);
        }
        public static bool operator ==(Plane left, Plane right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(Plane left, Plane right)
        {
            return !Equals(left, right);
        }

        #endregion


        #region Functions

        public static void Dot(ref Plane plane, ref Vector4 point, out float result)
        {
            result = plane.Normal.X * point.X + plane.Normal.Y * point.Y + plane.Normal.Z * point.Z + point.W * plane.D;
        }
        public static float Dot(ref Plane plane, ref Vector4 point)
        {
            return plane.Normal.X * point.X + plane.Normal.Y * point.Y + plane.Normal.Z * point.Z + point.W * plane.D;
        }
        public static float Dot(Plane plane, Vector4 point)
        {
            return plane.Normal.X * point.X + plane.Normal.Y * point.Y + plane.Normal.Z * point.Z + point.W * plane.D;
        }
        public float Dot(ref Vector4 point)
        {
            return this.Normal.X * point.X + this.Normal.Y * point.Y + this.Normal.Z * point.Z + point.W * this.D;
        }
        public float Dot(Vector4 point)
        {
            return this.Normal.X * point.X + this.Normal.Y * point.Y + this.Normal.Z * point.Z + point.W * this.D;
        }

        public static void DotNormal(ref Plane plane, ref Vector3 point, out float result)
        {
            result = plane.Normal.X * point.X + plane.Normal.Y * point.Y + plane.Normal.Z * point.Z;
        }
        public static float DotNormal(ref Plane plane, ref Vector3 point)
        {
            return plane.Normal.X * point.X + plane.Normal.Y * point.Y + plane.Normal.Z * point.Z;
        }
        public static float DotNormal(Plane plane, Vector3 point)
        {
            return plane.Normal.X * point.X + plane.Normal.Y * point.Y + plane.Normal.Z * point.Z;
        }
        public float DotNormal(ref Vector3 point)
        {
            return DotNormal(ref this, ref point);
        }
        public float DotNormal(Vector3 point)
        {
            return DotNormal(ref this, ref point);
        }

        public static void DotCoordinate(ref Plane plane, ref Vector3 point, out float result)
        {
            result = plane.Normal.X * point.X + plane.Normal.Y * point.Y + plane.Normal.Z * point.Z + plane.D;
        }
        public static float DotCoordinate(ref Plane plane, ref Vector3 point)
        {
            return plane.Normal.X * point.X + plane.Normal.Y * point.Y + plane.Normal.Z * point.Z + plane.D;
        }
        public static float DotCoordinate(Plane plane, Vector3 point)
        {
            return plane.Normal.X * point.X + plane.Normal.Y * point.Y + plane.Normal.Z * point.Z + plane.D;
        }
        public float DotCoordinate(ref Vector3 point)
        {
            return this.Normal.X * point.X + this.Normal.Y * point.Y + this.Normal.Z * point.Z + this.D;
        }
        public float DotCoordinate(Vector3 point)
        {
            return this.Normal.X * point.X + this.Normal.Y * point.Y + this.Normal.Z * point.Z + this.D;
        }

        public static void Normalize(ref Plane plane, out Plane result)
        {
            float magnitude = 1.0f / (float)(System.Math.Sqrt((plane.Normal.X * plane.Normal.X) + (plane.Normal.Y * plane.Normal.Y) + (plane.Normal.Z * plane.Normal.Z)));

            result.Normal.X = plane.Normal.X * magnitude;
            result.Normal.Y = plane.Normal.Y * magnitude;
            result.Normal.Z = plane.Normal.Z * magnitude;
            result.D = plane.D * magnitude;
        }
        public static Plane Normalize(ref Plane plane)
        {
            Plane result;
            Normalize(ref plane, out result);
            return result;
        }
        public static Plane Normalize(Plane plane)
        {
            Plane result;
            Normalize(ref plane, out result);
            return result;
        }
        public void Normalize()
        {
            Normalize(ref this, out this);
        }

        public static void Scale(ref Plane plane, float scale, out Plane result)
        {
            result = new Plane(plane.Normal.X * scale, plane.Normal.Y * scale, plane.Normal.Z * scale, plane.D * scale);
        }
        public static Plane Scale(ref Plane plane, float scale)
        {
            return new Plane(plane.Normal.X * scale, plane.Normal.Y * scale, plane.Normal.Z * scale, plane.D * scale);
        }
        public static Plane Scale(Plane plane, float scale)
        {
            return new Plane(plane.Normal.X * scale, plane.Normal.Y * scale, plane.Normal.Z * scale, plane.D * scale);
        }
        public void Scale(float scale)
        {
            Normal.Multiply(scale);
            D *= scale;
        }

        public static void Transform(ref Plane plane, ref Matrix transformation, out Plane result)
        {
            transformation.Invert();

            float x = plane.Normal.X;
            float y = plane.Normal.Y;
            float z = plane.Normal.Z;
            float d = plane.D;
           
            result.Normal.X = x * transformation.M11 + y * transformation.M12 + z * transformation.M13 + d * transformation.M14;
            result.Normal.Y = x * transformation.M21 + y * transformation.M22 + z * transformation.M23 + d * transformation.M24;
            result.Normal.Z = x * transformation.M31 + y * transformation.M32 + z * transformation.M33 + d * transformation.M34;
            result.D = x * transformation.M41 + y * transformation.M42 + z * transformation.M43 + d * transformation.M44;
        }
        public static Plane Transform(ref Plane plane, ref Matrix transformation)
        {
            Plane result;
            Transform(ref plane, ref transformation, out result);
            return result;
        }
        public static Plane Transform(Plane plane, Matrix transformation)
        {
            Plane result;
            Transform(ref plane, ref transformation, out result);
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


        #region Collision

        public PlaneIntersectionType Intersects(ref BoundingSphere sphere)
        {
            float num = this.Normal.Y * sphere.Center.Y + this.Normal.X * sphere.Center.X + this.Normal.Z * sphere.Center.Z + this.D;
            if(num > sphere.Radius)
                return PlaneIntersectionType.Front;
            if(num < -sphere.Radius)
                return PlaneIntersectionType.Back;
            return PlaneIntersectionType.Intersecting;
        }
        public PlaneIntersectionType Intersects(BoundingSphere sphere)
        {
            return Intersects(ref sphere);
        }

        public PlaneIntersectionType Intersects(ref BoundingBox box)
        {
            Vector3 vectorA;
            vectorA.X = this.Normal.X < 0.0f ? box.Minimum.X : box.Maximum.X;
            vectorA.Y = this.Normal.Y < 0.0f ? box.Minimum.Y : box.Maximum.Y;
            vectorA.Z = this.Normal.Z < 0.0f ? box.Minimum.Z : box.Maximum.Z;

            Vector3 vectorB;
            vectorB.X = this.Normal.X < 0.0f ? box.Maximum.X : box.Minimum.X;
            vectorB.Y = this.Normal.Y < 0.0f ? box.Maximum.Y : box.Minimum.Y;
            vectorB.Z = this.Normal.Z < 0.0f ? box.Maximum.Z : box.Minimum.Z;
            
            if(this.Normal.Y * vectorB.Y + this.Normal.X * vectorB.X + this.Normal.Z * vectorB.Z + this.D > 0.0)
                return PlaneIntersectionType.Front;
            if(this.Normal.Y * vectorA.Y + this.Normal.X * vectorA.X + this.Normal.Z * vectorA.Z + this.D < 0.0)
                return PlaneIntersectionType.Back;
            return PlaneIntersectionType.Intersecting;
        }
        public PlaneIntersectionType Intersects(BoundingBox box)
        {
            return Intersects(ref box);
        }

        #endregion


        #region Conversion

        public override string ToString()
        {
            return Invariant($"Normal:{Normal} D:{D}");
        }
        
        #endregion

    }
}
