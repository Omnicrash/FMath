using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Frostfire.Math
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct BoundingBox : IEquatable<BoundingBox>
    {
        public static readonly int SIZE_IN_BYTES = Marshal.SizeOf(typeof(BoundingBox));

        public static readonly BoundingBox MIN_VALUE = new BoundingBox(new Vector3(Single.MaxValue), new Vector3(Single.MinValue));
        public static readonly BoundingBox MAX_VALUE = new BoundingBox(new Vector3(Single.MinValue), new Vector3(Single.MaxValue));

        public Vector3 Minimum;
        public Vector3 Maximum;
        
        public float Width { get { return Maximum.X - Minimum.X; } }
        public float Height { get { return Maximum.Y - Minimum.Y; } }
        public float Depth { get { return Maximum.Z - Minimum.Z; } }

        public Vector3 Center { get { return (Minimum + Maximum) * 0.5f; } }
        
        public Vector3[] GetCorners()
        {
            return new Vector3[8]
            {
                new Vector3(this.Minimum.X, this.Maximum.Y, this.Maximum.Z),
                new Vector3(this.Maximum.X, this.Maximum.Y, this.Maximum.Z),
                new Vector3(this.Maximum.X, this.Minimum.Y, this.Maximum.Z),
                new Vector3(this.Minimum.X, this.Minimum.Y, this.Maximum.Z),
                new Vector3(this.Minimum.X, this.Maximum.Y, this.Minimum.Z),
                new Vector3(this.Maximum.X, this.Maximum.Y, this.Minimum.Z),
                new Vector3(this.Maximum.X, this.Minimum.Y, this.Minimum.Z),
                new Vector3(this.Minimum.X, this.Minimum.Y, this.Minimum.Z),
            };
        }

        public BoundingBox(Vector3 minimum, Vector3 maximum)
        {
            this.Minimum = minimum;
            this.Maximum = maximum;
        }


        #region Comparison

        public override int GetHashCode()
        {
            unchecked
            {
                return (Minimum.GetHashCode() * 397) ^ Maximum.GetHashCode();
            }
        }

        public bool Equals(ref BoundingBox value)
        {
            return this.Minimum == value.Minimum && this.Maximum == value.Maximum;
        }
        public bool Equals(BoundingBox value)
        {
            return this.Minimum == value.Minimum && this.Maximum == value.Maximum;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            return this.Equals((BoundingBox)obj);
        }
        
        public static bool operator ==(BoundingBox left, BoundingBox right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(BoundingBox left, BoundingBox right)
        {
            return !Equals(left, right);
        }

        #endregion


        #region Collision

        public bool Intersects(ref Vector3 point)
        {
            return (this.Minimum.X <= point.X && point.X <= this.Maximum.X &&
                    this.Minimum.Y <= point.Y && point.Y <= this.Maximum.Y &&
                    this.Minimum.Z <= point.Z && point.Z <= this.Maximum.Z);
        }
        public bool Intersects(Vector3 point)
        {
            return Intersects(ref point);
        }

        public PlaneIntersectionType Intersects(ref Plane plane)
        {
            return plane.Intersects(ref this);
        }
        public PlaneIntersectionType Intersects(Plane plane)
        {
            return plane.Intersects(ref this);
        }

        public bool Intersects(ref Ray ray)
        {
            return ray.Intersects(ref this);
        }
        public bool Intersects(Ray ray)
        {
            return ray.Intersects(ref this);
        }
        public bool Intersects(ref Ray ray, out float distance)
        {
            return ray.Intersects(ref this, out distance);
        }
        public bool Intersects(Ray ray, out float distance)
        {
            return ray.Intersects(ref this, out distance);
        }
        public bool Intersects(ref Ray ray, out Vector3 point)
        {
            return ray.Intersects(ref this, out point);
        }
        public bool Intersects(Ray ray, out Vector3 point)
        {
            return ray.Intersects(ref this, out point);
        }
        public bool Intersects(ref Ray ray, out Faces face, out Vector3 point)
        {
            Plane plane;
            float distance = Single.PositiveInfinity;
            face = Faces.None;
            point = Vector3.ZERO;
            Vector3 newPoint;

            // Front
            plane = new Plane(Maximum, new Vector3(0.0f, 0.0f, 1.0f));
            if (ray.Intersects(ref plane, out newPoint)
                && newPoint.X >= Minimum.X && newPoint.X <= Maximum.X
                && newPoint.Y >= Minimum.Y && newPoint.Y <= Maximum.Y)
            {
                float newDistance; Vector3.Distance(ref ray.Origin, ref newPoint, out newDistance);
                if (newDistance < distance)
                {
                    distance = newDistance;
                    face = Faces.Front;
                    point = newPoint;
                }
            }

            // Back
            plane = new Plane(Minimum, new Vector3(0.0f, 0.0f, -1.0f));
            if (ray.Intersects(ref plane, out newPoint)
                && newPoint.X >= Minimum.X && newPoint.X <= Maximum.X
                && newPoint.Y >= Minimum.Y && newPoint.Y <= Maximum.Y)
            {
                float newDistance; Vector3.Distance(ref ray.Origin, ref newPoint, out newDistance);
                if (newDistance < distance)
                {
                    distance = newDistance;
                    face = Faces.Back;
                    point = newPoint;
                }
            }

            // Right
            plane = new Plane(Maximum, new Vector3(1.0f, 0.0f, 0.0f));
            if (ray.Intersects(ref plane, out newPoint)
                && newPoint.Y >= Minimum.Y && newPoint.Y <= Maximum.Y
                && newPoint.Z >= Minimum.Z && newPoint.Z <= Maximum.Z)
            {
                float newDistance; Vector3.Distance(ref ray.Origin, ref newPoint, out newDistance);
                if (newDistance < distance)
                {
                    distance = newDistance;
                    face = Faces.Right;
                    point = newPoint;
                }
            }

            // Left
            plane = new Plane(Minimum, new Vector3(-1.0f, 0.0f, 0.0f));
            if (ray.Intersects(ref plane, out newPoint)
                && newPoint.Y >= Minimum.Y && newPoint.Y <= Maximum.Y
                && newPoint.Z >= Minimum.Z && newPoint.Z <= Maximum.Z)
            {
                float newDistance; Vector3.Distance(ref ray.Origin, ref newPoint, out newDistance);
                if (newDistance < distance)
                {
                    distance = newDistance;
                    face = Faces.Left;
                    point = newPoint;
                }
            }

            // Top
            plane = new Plane(Maximum, new Vector3(0.0f, 1.0f, 0.0f));
            if (ray.Intersects(ref plane, out newPoint)
                && newPoint.X >= Minimum.X && newPoint.X <= Maximum.X
                && newPoint.Z >= Minimum.Z && newPoint.Z <= Maximum.Z)
            {
                float newDistance; Vector3.Distance(ref ray.Origin, ref newPoint, out newDistance);
                if (newDistance < distance)
                {
                    distance = newDistance;
                    face = Faces.Top;
                    point = newPoint;
                }
            }

            // Bottom
            plane = new Plane(Minimum, new Vector3(0.0f, -1.0f, 0.0f));
            if (ray.Intersects(ref plane, out newPoint)
                && newPoint.X >= Minimum.X && newPoint.X <= Maximum.X
                && newPoint.Z >= Minimum.Z && newPoint.Z <= Maximum.Z)
            {
                float newDistance; Vector3.Distance(ref ray.Origin, ref newPoint, out newDistance);
                if (newDistance < distance)
                {
                    distance = newDistance;
                    face = Faces.Bottom;
                    point = newPoint;
                }
            }

            return !Single.IsPositiveInfinity(distance);
        }
        public bool Intersects(Ray ray, out Faces face, out Vector3 point)
        {
            return Intersects(ref ray, out face, out point);
        }
        public bool Intersects(ref Ray ray, out Faces face)
        {
            Vector3 point;
            return Intersects(ref ray, out face, out point);
        }
        public bool Intersects(Ray ray, out Faces face)
        {
            Vector3 point;
            return Intersects(ref ray, out face, out point);
        }

        public bool Intersects(ref BoundingSphere sphere)
        {
            Vector3 clampedCenter = Vector3.Clamp(sphere.Center, this.Minimum, this.Maximum);
            Vector3 centerDiff = sphere.Center - clampedCenter;

            float lengthSquared = centerDiff.X * centerDiff.X + centerDiff.Y * centerDiff.Y + centerDiff.Z * centerDiff.Z;
            float radiusSquared = sphere.Radius * sphere.Radius;

            if (lengthSquared > radiusSquared)
                return false;

            return true;
        }
        public bool Intersects(BoundingSphere sphere)
        {
            return Intersects(ref sphere);
        }
        public ContainmentType Contains(ref BoundingSphere sphere)
        {
            Vector3 clampedCenter = Vector3.Clamp(sphere.Center, this.Minimum, this.Maximum);
            Vector3 centerDiff = sphere.Center - clampedCenter;

            float lengthSquared = centerDiff.X * centerDiff.X + centerDiff.Y * centerDiff.Y + centerDiff.Z * centerDiff.Z;
            float radiusSquared = sphere.Radius * sphere.Radius;

            if (lengthSquared > radiusSquared)
            {
                return ContainmentType.Disjoint;
            }

            if (this.Width > sphere.Radius && this.Height > sphere.Radius && this.Depth > sphere.Radius &&
                this.Minimum.X + sphere.Radius <= sphere.Center.X &&
                sphere.Center.X <= this.Maximum.X - sphere.Radius &&
                this.Minimum.Y + sphere.Radius <= sphere.Center.Y &&
                sphere.Center.Y <= this.Maximum.Y - sphere.Radius &&
                this.Minimum.Z + sphere.Radius <= sphere.Center.Z &&
                sphere.Center.Z <= this.Maximum.Z - sphere.Radius)
            {
                return ContainmentType.Contains;
            }

            return ContainmentType.Intersects;
        }
        public ContainmentType Contains(BoundingSphere sphere)
        {
            return Contains(ref sphere);
        }

        public bool Intersects(ref BoundingBox box)
        {
            return !(this.Maximum.X < box.Minimum.X || this.Minimum.X > box.Maximum.X ||
               (this.Maximum.Y < box.Minimum.Y || this.Minimum.Y > box.Maximum.Y) ||
               (this.Maximum.Z < box.Minimum.Z || this.Minimum.Z > box.Maximum.Z));
        }
        public bool Intersects(BoundingBox box)
        {
            return Intersects(ref box);
        }
        public ContainmentType Contains(ref BoundingBox box)
        {
            if (this.Maximum.X < box.Minimum.X || this.Minimum.X > box.Maximum.X ||
               (this.Maximum.Y < box.Minimum.Y || this.Minimum.Y > box.Maximum.Y) ||
               (this.Maximum.Z < box.Minimum.Z || this.Minimum.Z > box.Maximum.Z))
            {
                return ContainmentType.Disjoint;
            }
            if (this.Minimum.X <= box.Minimum.X && box.Maximum.X <= this.Maximum.X &&
               (this.Minimum.Y <= box.Minimum.Y && box.Maximum.Y <= this.Maximum.Y) &&
               (this.Minimum.Z <= box.Minimum.Z && box.Maximum.Z <= this.Maximum.Z))
            {
                return ContainmentType.Contains;
            }
            
            return ContainmentType.Intersects;
        }
        public ContainmentType Contains(BoundingBox box)
        {
            return Contains(ref box);
        }

        #endregion

        
        public void AddPoint(ref Vector3 point)
        {
            Maximum.Maximize(ref point);
            Minimum.Minimize(ref point);
        }
        public void AddPoint(Vector3 point)
        {
            Maximum.Maximize(ref point);
            Minimum.Minimize(ref point);
        }

        public static BoundingBox FromPoints(Vector3[] points)
        {
            if (points == null || points.Length <= 0)
                throw new ArgumentNullException("points");

            Vector3 boundsMin = new Vector3(float.MaxValue);
            Vector3 boundsMax = new Vector3(float.MinValue);

            for (int i = 0; i < points.Length; i++)
            {
                Vector3 currentPoint = points[i];
                boundsMin = Vector3.Minimize(boundsMin, currentPoint);
                boundsMax = Vector3.Maximize(boundsMax, currentPoint);
            }

            Vector3 extents = (boundsMax - boundsMin) * 0.5f;
            Vector3 center = boundsMin + extents;

            return new BoundingBox(extents, center);
        }
        
        public static void Merge(ref BoundingBox a, ref BoundingBox b, out BoundingBox result)
        {
            result.Minimum = Vector3.Minimize(a.Minimum, b.Minimum);
            result.Maximum = Vector3.Maximize(a.Maximum, b.Maximum);
        }
        public static BoundingBox Merge(ref BoundingBox a, ref BoundingBox b)
        {
            BoundingBox result;
            Merge(ref a, ref b, out result);
            return result;
        }
        public static BoundingBox Merge(BoundingBox a, BoundingBox b)
        {
            BoundingBox result;
            Merge(ref a, ref b, out result);
            return result;
        }
        public void Merge(ref BoundingBox box)
        {
            Merge(ref this, ref box, out this);
        }
        public void Merge(BoundingBox box)
        {
            Merge(ref this, ref box, out this);
        }

        public BoundingSphere ToBoundingSphere()
        {
            BoundingSphere result = new BoundingSphere();
            result.Center = this.Center;
            result.Radius = Vector3.Distance(Minimum, Maximum) * 0.5f;
            return result;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "Minimum:{0} Maximum:{1}", Minimum, Maximum);
        }
        public static implicit operator string(BoundingBox value)
        {
            return value.ToString();
        }

    }
}
