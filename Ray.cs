using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Frostfire.Math
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Ray : IEquatable<Ray>
    {
        public static readonly int SIZE_IN_BYTES = Marshal.SizeOf(typeof(Ray));

        public Vector3 Origin;
        public Vector3 Direction;
        public float Length;
        public Vector3 End
        {
            get { return Origin + (Direction * Length); }
            set
            {
                Vector3 line = value - Origin;
                Length = Vector3.Length(line);
                Direction = Vector3.Normalize(line);
            }
        }

        public Ray(Vector3 origin, Vector3 direction)
        {
            this.Origin = origin;
            this.Direction = direction;
            this.Length = Single.PositiveInfinity;
        }
        public Ray(Vector3 origin, Vector3 direction, float length)
        {
            this.Origin = origin;
            this.Direction = direction;
            this.Length = length;
        }


        #region Comparison

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Origin.GetHashCode();
                hashCode = (hashCode * 397) ^ Direction.GetHashCode();
                hashCode = (hashCode * 397) ^ Length.GetHashCode();
                return hashCode;
            }
        }

        public bool Equals(ref Ray value)
        {
            return
                Origin == value.Origin &&
                Direction == value.Direction &&
                System.Math.Abs(Length - value.Length) < FMath.EPSILON;
        }
        public bool Equals(Ray value)
        {
            return Equals(ref value);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            return Equals((Ray)obj);
        }
        public static bool operator ==(Ray left, Ray right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Ray left, Ray right)
        {
            return !left.Equals(right);
        }

        #endregion


        #region Collision

        public bool Intersects(ref Vector3 point)
        {
            Vector3 m = Origin - point;

            float b = Vector3.Dot(m, Direction);
            float c = Vector3.Dot(m, m) - FMath.EPSILON;

            if (c > 0.0f && b > 0.0f)
                return false;

            float discriminant = b * b - c;

            if (discriminant < 0.0f)
                return false;

            if (this.Length < Vector3.Length(m) - FMath.EPSILON)
                return false;

            return true;
        }
        public bool Intersects(Vector3 point)
        {
            return Intersects(ref point);
        }

        public bool Intersects(ref Ray ray, out Vector3 point)
        {
            Vector3 cross; Vector3.Cross(ref this.Direction, ref ray.Direction, out cross);
            float denominator = cross.Length();

            point = Vector3.ZERO;

            // Lines are parallel
            if (System.Math.Abs(denominator) < FMath.EPSILON)
            {
                // Lines are parallel and on top of each other
                if (System.Math.Abs(ray.Origin.X - this.Origin.X) < FMath.EPSILON &&
                    System.Math.Abs(ray.Origin.Y - this.Origin.Y) < FMath.EPSILON &&
                    System.Math.Abs(ray.Origin.Z - this.Origin.Z) < FMath.EPSILON)
                {
                    return true;
                }
            }

            denominator = denominator * denominator;

            // 3x3 matrix for the first ray
            float m11 = ray.Origin.X - this.Origin.X;
            float m12 = ray.Origin.Y - this.Origin.Y;
            float m13 = ray.Origin.Z - this.Origin.Z;
            float m21 = ray.Direction.X;
            float m22 = ray.Direction.Y;
            float m23 = ray.Direction.Z;
            float m31 = cross.X;
            float m32 = cross.Y;
            float m33 = cross.Z;

            // Determinant of first matrix
            float dets =
                m11 * m22 * m33 +
                m12 * m23 * m31 +
                m13 * m21 * m32 -
                m11 * m23 * m32 -
                m12 * m21 * m33 -
                m13 * m22 * m31;

            // 3x3 matrix for the second ray
            m21 = this.Direction.X;
            m22 = this.Direction.Y;
            m23 = this.Direction.Z;

            //Determinant of the second matrix.
            float dett =
                m11 * m22 * m33 +
                m12 * m23 * m31 +
                m13 * m21 * m32 -
                m11 * m23 * m32 -
                m12 * m21 * m33 -
                m13 * m22 * m31;

            //t values of the point of intersection.
            float s = dets / denominator;
            float t = dett / denominator;

            // Check if points are within the length of the ray
            if (this.Length < s - FMath.EPSILON ||
                ray.Length < t - FMath.EPSILON)
                return false;

            // The points of intersection
            Vector3 point1 = this.Origin + (s * this.Direction);
            Vector3 point2 = ray.Origin + (t * ray.Direction);

            // If the points are not equal, no intersection has occured
            if (System.Math.Abs(point2.X - point1.X) > FMath.EPSILON ||
                System.Math.Abs(point2.Y - point1.Y) > FMath.EPSILON ||
                System.Math.Abs(point2.Z - point1.Z) > FMath.EPSILON)
            {
                return false;
            }

            point = point1;
            return true;
        }
        public bool Intersects(Ray ray, out Vector3 point)
        {
            return Intersects(ref ray, out point);
        }
        public bool Intersects(ref Ray ray)
        {
            Vector3 dummy;
            return Intersects(ref ray, out dummy);
        }
        public bool Intersects(Ray ray)
        {
            Vector3 dummy;
            return Intersects(ref ray, out dummy);
        }

        public bool Intersects(ref Plane plane, out float distance)
        {
            float direction; Vector3.Dot(ref plane.Normal, ref this.Direction, out direction);

            if (System.Math.Abs(direction) < FMath.EPSILON)
            {
                distance = 0.0f;
                return false;
            }

            float position; Vector3.Dot(ref plane.Normal, ref this.Origin, out position);
            distance = (-plane.D - position) / direction;

            if (distance < 0.0f)
            {
                if (distance < -FMath.EPSILON)
                {
                    distance = 0.0f;
                    return false;
                }

                distance = 0.0f;
            }
            else if (this.Length < distance - FMath.EPSILON)
            {
                distance = 0.0f;
                return false;
            }

            return true;
        }
        public bool Intersects(Plane plane, out float distance)
        {
            return Intersects(ref plane, out distance);
        }
        public bool Intersects(ref Plane plane, out Vector3 point)
        {
            float distance;
            if (!Intersects(ref plane, out distance))
            {
                point = Vector3.ZERO;
                return false;
            }

            point = this.Origin + (this.Direction * distance);
            return true;
        }
        public bool Intersects(Plane plane, out Vector3 point)
        {
            return Intersects(ref plane, out point);
        }
        public bool Intersects(ref Plane plane)
        {
            float dummy;
            return Intersects(ref plane, out dummy);
        }
        public bool Intersects(Plane plane)
        {
            float dummy;
            return Intersects(ref plane, out dummy);
        }

        public bool Intersects(ref BoundingSphere sphere, out float distance)
        {
            Vector3 v; Vector3.Subtract(ref this.Origin, ref sphere.Center, out v);

            float b; Vector3.Dot(ref v, ref this.Direction, out b);
            float c = Vector3.Dot(ref v, ref v) - (sphere.Radius * sphere.Radius);

            if (c > 0f && b > 0f)
            {
                distance = 0f;
                return false;
            }

            float discriminant = b * b - c;

            if (discriminant < 0.0f)
            {
                distance = 0.0f;
                return false;
            }

            distance = -b - (float)System.Math.Sqrt(discriminant);

            if (distance < 0.0f)
                distance = 0.0f;
            else if (this.Length < distance - FMath.EPSILON)
            {
                distance = 0.0f;
                return false;
            }

            return true;
        }
        public bool Intersects(BoundingSphere sphere, out float distance)
        {
            return Intersects(ref sphere, out distance);
        }
        public bool Intersects(ref BoundingSphere sphere, out Vector3 point)
        {
            float distance;
            if (!Intersects(ref sphere, out distance))
            {
                point = Vector3.ZERO;
                return false;
            }

            point = this.Origin + (this.Direction * distance);
            return true;
        }
        public bool Intersects(BoundingSphere sphere, out Vector3 point)
        {
            return Intersects(ref sphere, out point);
        }
        public bool Intersects(ref BoundingSphere sphere)
        {
            float dummy;
            return Intersects(ref sphere, out dummy);
        }
        public bool Intersects(BoundingSphere sphere)
        {
            float dummy;
            return Intersects(ref sphere, out dummy);
        }
        
        bool Intersect1D(float start, float dir, float min, float max, ref float enter, ref float exit)
        {
            if (dir * dir < FMath.EPSILON * FMath.EPSILON)
                return (start >= min && start <= max);

            float t0 = (min - start) / dir;
            float t1 = (max - start) / dir;

            if (t0 > t1)
            {
                // Swap
                float tmp = t0;
                t0 = t1;
                t1 = tmp;
            }

            if (t0 > exit || t1 < enter)
                return false;

            if (t0 > enter) enter = t0;
            if (t1 < exit) exit = t1;
            return true;
        }
        public bool Intersects(ref BoundingBox box, out float distance)
        {
            distance = 0.0f;
            float enter = 0.0f, exit = float.MaxValue;

            if (!Intersect1D(Origin.X, Direction.X, box.Minimum.X, box.Maximum.X, ref enter, ref exit))
                return false;
            if (!Intersect1D(Origin.Y, Direction.Y, box.Minimum.Y, box.Maximum.Y, ref enter, ref exit))
                return false;
            if (!Intersect1D(Origin.Z, Direction.Z, box.Minimum.Z, box.Maximum.Z, ref enter, ref exit))
                return false;

            if (this.Length < enter - FMath.EPSILON)
                return false;

            distance = enter;
            return true;
        }
        public bool Intersects(BoundingBox box, out float distance)
        {
            return Intersects(ref box, out distance);
        }
        public bool Intersects(ref BoundingBox box, out Vector3 point)
        {
            float distance;
            if (!Intersects(ref box, out distance))
            {
                point = Vector3.ZERO;
                return false;
            }

            point = this.Origin + (this.Direction * distance);
            return true;
        }
        public bool Intersects(BoundingBox box, out Vector3 point)
        {
            return Intersects(ref box, out point);
        }
        public bool Intersects(ref BoundingBox box)
        {
            float dummy;
            return Intersects(ref box, out dummy);
        }
        public bool Intersects(BoundingBox box)
        {
            float dummy;
            return Intersects(ref box, out dummy);
        }
        public bool Intersects(ref BoundingBox box, out Faces face)
        {
            return box.Intersects(ref this, out face);
        }
        public bool Intersects(BoundingBox box, out Faces face)
        {
            return box.Intersects(ref this, out face);
        }
        public bool Intersects(ref BoundingBox box, out Faces face, out Vector3 point)
        {
            return box.Intersects(ref this, out face, out point);
        }
        public bool Intersects(BoundingBox box, out Faces face, out Vector3 point)
        {
            return box.Intersects(ref this, out face, out point);
        }

        #endregion


        #region Conversion

        public override string ToString()
        {
            if (Single.IsPositiveInfinity(Length))
                return string.Format(CultureInfo.CurrentCulture, "Origin:{0} Direction:{1}", Origin.ToString(), Direction.ToString());
            else
                return string.Format(CultureInfo.CurrentCulture, "Origin:{0} Length:{1} End:{2}", Origin.ToString(), Length.ToString(), End.ToString());
        }
        public static implicit operator string(Ray value)
        {
            return value.ToString();
        }

        #endregion

    }
}