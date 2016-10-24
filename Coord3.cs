using System;
using System.IO;
using System.Runtime.InteropServices;

namespace FMath
{
    /// <summary>
    /// Defines a coordinate with 3 components.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Coord3 : IEquatable<Coord3>
    {
        public int X, Y, Z;

        public static readonly int SIZE_IN_BYTES = Marshal.SizeOf(typeof(Coord3));

        public static readonly Coord3 ZERO = new Coord3(0);
        public static readonly Coord3 ONE = new Coord3(1);

        public static readonly Coord3 UNIT_X = new Coord3(1, 0, 0);
        public static readonly Coord3 UNIT_Y = new Coord3(0, 1, 0);
        public static readonly Coord3 UNIT_Z = new Coord3(0, 0, 1);

        public static readonly Coord3 MIN_VALUE = new Coord3(Int32.MinValue);
        public static readonly Coord3 MAX_VALUE = new Coord3(Int32.MaxValue);

        public Coord3(int value)
        {
            X = Y = Z = value;
        }
        public Coord3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Coord3(Vector3 vector)
        {
            X = (int)vector.X;
            Y = (int)vector.Y;
            Z = (int)vector.Z;
        }
        
        public Vector3 ToVector3()
        {
            return new Vector3(X, Y, Z);
        }

        public override string ToString()
        {
            return string.Format("X: {0}, Y: {1}, Z: {2}", X, Y, Z);
        }
        public static implicit operator string(Coord3 value)
        {
            return value.ToString();
        }

        public bool Equals(Coord3 value)
        {
            return value.X == X && value.Y == Y && value.Z == Z;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            return Equals((Coord3)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = X;
                result = (result * 397) ^ Y;
                result = (result * 397) ^ Z;
                return result;
            }
        }

        public static bool operator ==(Coord3 a, Coord3 b)
        {
            return (a.X == b.X && a.Y == b.Y && a.Z == b.Z);
        }
        public static bool operator !=(Coord3 a, Coord3 b)
        {
            return !(a.X == b.X && a.Y == b.Y && a.Z == b.Z);
        }

        public static bool operator <(Coord3 a, Coord3 b)
        {
            return (a.X < b.X || a.Y < b.Y || a.Z < b.Z);
        }
        public static bool operator >(Coord3 a, Coord3 b)
        {
            return (a.X > b.X || a.Y > b.Y || a.Z > b.Z);
        }
        public static bool operator <=(Coord3 a, Coord3 b)
        {
            return (a.X <= b.X || a.Y <= b.Y || a.Z <= b.Z);
        }
        public static bool operator >=(Coord3 a, Coord3 b)
        {
            return (a.X >= b.X || a.Y >= b.Y || a.Z >= b.Z);
        }

        public static Coord3 operator -(Coord3 value)
        {
            return new Coord3(-value.X, -value.Y, -value.Z);
        }

        public static Coord3 operator +(Coord3 a, Coord3 b)
        {
            return new Coord3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Coord3 operator -(Coord3 a, Coord3 b)
        {
            return new Coord3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Coord3 operator *(Coord3 a, Coord3 b)
        {
            return new Coord3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        }
        public static Coord3 operator /(Coord3 a, Coord3 b)
        {
            return new Coord3(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
        }

        public static Coord3 operator +(Coord3 a, int b)
        {
            return new Coord3(a.X + b, a.Y + b, a.Z + b);
        }
        public static Coord3 operator -(Coord3 a, int b)
        {
            return new Coord3(a.X - b, a.Y - b, a.Z - b);
        }
        public static Coord3 operator *(Coord3 a, int b)
        {
            return new Coord3(a.X * b, a.Y * b, a.Z * b);
        }
        public static Coord3 operator /(Coord3 a, int b)
        {
            return new Coord3(a.X / b, a.Y / b, a.Z / b);
        }


        public static void Abs(ref Coord3 value, out Coord3 result)
        {
            result.X = Math.Abs(value.X);
            result.Y = Math.Abs(value.Y);
            result.Z = Math.Abs(value.Z);
        }
        public static Coord3 Abs(ref Coord3 value)
        {
            Coord3 result;
            Abs(ref value, out result);
            return result;
        }
        public static Coord3 Abs(Coord3 value)
        {
            Coord3 result;
            Abs(ref value, out result);
            return result;
        }
        public void Abs()
        {
            Abs(ref this, out this);
        }

        public static Coord3 Maximize(Coord3 left, Coord3 right)
        {
            return new Coord3()
            {
                X = left.X <= right.X ? right.X : left.X,
                Y = left.Y <= right.Y ? right.Y : left.Y,
                Z = left.Z <= right.Z ? right.Z : left.Z,
            };
        }
        public Coord3 Maximize(Coord3 value)
        {
            return Maximize(this, value);
        }
        
        public static Coord3 Minimize(Coord3 left, Coord3 right)
        {
            return new Coord3()
            {
                X = left.X >= right.X ? right.X : left.X,
                Y = left.Y >= right.Y ? right.Y : left.Y,
                Z = left.Z >= right.Z ? right.Z : left.Z,
            };
        }
        public Coord3 Minimize(Coord3 value)
        {
            return Minimize(this, value);
        }

        /// <summary>
        /// Returns the value of the coordinate's largest component.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Max(Coord3 value)
        {
            return System.Math.Max(value.X, System.Math.Max(value.Y, value.Z));
        }
        public int Max()
        {
            return Max(this);
        }

        /// <summary>
        /// Returns the value of the coordinate's smallest component.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Min(Coord3 value)
        {
            return System.Math.Min(value.X, System.Math.Min(value.Y, value.Z));
        }
        public int Min()
        {
            return Min(this);
        }


    }

    public static class Coord3Extensions
    {
        public static void Write(this BinaryWriter bin, Coord3 value)
        {
            bin.Write(value.X);
            bin.Write(value.Y);
            bin.Write(value.Z);
        }

        public static Coord3 ReadCoord3(this BinaryReader bin)
        {
            int x = bin.ReadInt32();
            int y = bin.ReadInt32();
            int z = bin.ReadInt32();
            return new Coord3(x, y, z);
        }
    }

}

