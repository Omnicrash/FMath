using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace FMath
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct BoundingSphere : IEquatable<BoundingSphere>
    {
        public static readonly int SIZE_IN_BYTES = Marshal.SizeOf(typeof(BoundingSphere));

        public static readonly BoundingSphere MIN_VALUE = new BoundingSphere(Vector3.ZERO, Single.MinValue);
        public static readonly BoundingSphere MAX_VALUE = new BoundingSphere(Vector3.ZERO, Single.MaxValue);

        public Vector3 Center;
        public float Radius;
        
        public BoundingSphere(Vector3 center, float radius)
        {
            this.Center = center;
            this.Radius = radius;
        }


        #region Comparison

        public override int GetHashCode()
        {
            unchecked
            {
                return (Center.GetHashCode() * 397) ^ Radius.GetHashCode();
            }
        }

        public bool Equals(ref BoundingSphere value)
        {
            return
                this.Center == value.Center &&
                System.Math.Abs(this.Radius - value.Radius) < FMath.EPSILON;
        }
        public bool Equals(BoundingSphere value)
        {
            return Equals(ref value);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            return this.Equals((BoundingSphere)obj);
        }
        public static bool operator ==(BoundingSphere left, BoundingSphere right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(BoundingSphere left, BoundingSphere right)
        {
            return !Equals(left, right);
        }

        #endregion


        #region Collision

        public bool Intersects(ref Vector3 point)
        {
            Vector3 centerDiff = point - this.Center;

            float lengthSquared = centerDiff.X * centerDiff.X + centerDiff.Y * centerDiff.Y + centerDiff.Z * centerDiff.Z;
            float radiusSquared = this.Radius * this.Radius;

            return !(lengthSquared >= radiusSquared);
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

        public bool Intersects(ref BoundingSphere sphere)
        {
            float combinedRadius = this.Radius + sphere.Radius;
            float distance = Vector3.Distance(this.Center, sphere.Center);
            return (distance < combinedRadius);
        }
        public bool Intersects(BoundingSphere sphere)
        {
            return Intersects(ref sphere);
        }
        public ContainmentType Contains(ref BoundingSphere sphere)
        {
            float combinedRadius = this.Radius + sphere.Radius;
            float distance = Vector3.Distance(this.Center, sphere.Center);

            if (this.Radius >= distance + sphere.Radius)
                return ContainmentType.Contains;
            if (distance < combinedRadius)
                return ContainmentType.Intersects;
            return ContainmentType.Disjoint;
        }
        public ContainmentType Contains(BoundingSphere sphere)
        {
            return Contains(ref sphere);
        }

        public bool Intersects(ref BoundingBox box)
        {
            return box.Intersects(ref this);
        }
        public bool Intersects(BoundingBox box)
        {
            return box.Intersects(ref this);
        }
        public ContainmentType Contains(ref BoundingBox box)
        {
            if(!box.Intersects(ref this))
                return ContainmentType.Disjoint;

            Vector3 centerDiff = new Vector3();
            float radiusSquared = this.Radius * this.Radius;
            centerDiff.X = this.Center.X - box.Minimum.X;
            centerDiff.Y = this.Center.Y - box.Maximum.Y;
            centerDiff.Z = this.Center.Z - box.Maximum.Z;
            if(centerDiff.LengthSq() > radiusSquared)
                return ContainmentType.Intersects;
            centerDiff.X = this.Center.X - box.Maximum.X;
            centerDiff.Y = this.Center.Y - box.Maximum.Y;
            centerDiff.Z = this.Center.Z - box.Maximum.Z;
            if(centerDiff.LengthSq() > radiusSquared)
                return ContainmentType.Intersects;
            centerDiff.X = this.Center.X - box.Maximum.X;
            centerDiff.Y = this.Center.Y - box.Minimum.Y;
            centerDiff.Z = this.Center.Z - box.Maximum.Z;
            if(centerDiff.LengthSq() > radiusSquared)
                return ContainmentType.Intersects;
            centerDiff.X = this.Center.X - box.Minimum.X;
            centerDiff.Y = this.Center.Y - box.Minimum.Y;
            centerDiff.Z = this.Center.Z - box.Maximum.Z;
            if(centerDiff.LengthSq() > radiusSquared)
                return ContainmentType.Intersects;
            centerDiff.X = this.Center.X - box.Minimum.X;
            centerDiff.Y = this.Center.Y - box.Maximum.Y;
            centerDiff.Z = this.Center.Z - box.Minimum.Z;
            if(centerDiff.LengthSq() > radiusSquared)
                return ContainmentType.Intersects;
            centerDiff.X = this.Center.X - box.Maximum.X;
            centerDiff.Y = this.Center.Y - box.Maximum.Y;
            centerDiff.Z = this.Center.Z - box.Minimum.Z;
            if(centerDiff.LengthSq() > radiusSquared)
                return ContainmentType.Intersects;
            centerDiff.X = this.Center.X - box.Maximum.X;
            centerDiff.Y = this.Center.Y - box.Minimum.Y;
            centerDiff.Z = this.Center.Z - box.Minimum.Z;
            if(centerDiff.LengthSq() > radiusSquared)
                return ContainmentType.Intersects;
            centerDiff.X = this.Center.X - box.Minimum.X;
            centerDiff.Y = this.Center.Y - box.Minimum.Y;
            centerDiff.Z = this.Center.Z - box.Minimum.Z;
            if(centerDiff.LengthSq() > radiusSquared)
                return ContainmentType.Intersects;
            
            return ContainmentType.Contains;
        }
        public ContainmentType Contains(BoundingBox box)
        {
            return Contains(ref box);
        }

        #endregion
        

        public static BoundingSphere CreateFromPoints(Vector3[] points)
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

            Vector3 center = Vector3.Lerp(boundsMin, boundsMax, 0.5f);
            float radius = Vector3.Distance(boundsMin, boundsMax) * 0.5f;

            return new BoundingSphere(center, radius);
        }

        public static void Merge(ref BoundingSphere a, ref BoundingSphere b, out BoundingSphere result)
        {
            float distanceCenter = Vector3.Distance(a.Center, b.Center);
            result.Radius = (a.Radius + b.Radius + distanceCenter) * 0.5f;
            result.Center = Vector3.Lerp(a.Center, b.Center, result.Radius - a.Radius);
        }
        public static BoundingSphere Merge(ref BoundingSphere a, ref BoundingSphere b)
        {
            BoundingSphere result;
            Merge(ref a, ref b, out result);
            return result;
        }
        public static BoundingSphere Merge(BoundingSphere a, BoundingSphere b)
        {
            BoundingSphere result;
            Merge(ref a, ref b, out result);
            return result;
        }

        public BoundingBox ToBoundingBox()
        {
            BoundingBox result = new BoundingBox();
            Vector3 radiusVector = new Vector3(Radius);
            result.Minimum = Center - radiusVector;
            result.Maximum = Center + radiusVector;
            return result;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "Center:{0} Radius:{1}", this.Center, this.Radius);
        }
        public static implicit operator string(BoundingSphere value)
        {
            return value.ToString();
        }

    }
}
