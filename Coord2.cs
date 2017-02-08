using System;
using System.IO;
using System.Runtime.InteropServices;
using static System.FormattableString;

namespace Frostfire.Math
{
    /// <summary>
    /// Defines a coordinate with 2 components.
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Coord2 : IEquatable<Coord2>
    {
        public int X, Y;

        public static readonly int SIZE_IN_BYTES = Marshal.SizeOf(typeof(Coord2));
        
        public static readonly Coord2 ZERO = new Coord2(0);
        public static readonly Coord2 ONE = new Coord2(1);

        public static readonly Coord2 UNIT_X = new Coord2(1, 0);
        public static readonly Coord2 UNIT_Y = new Coord2(0, 1);
        
        public static readonly Coord2 MIN_VALUE = new Coord2(Int32.MinValue);
        public static readonly Coord2 MAX_VALUE = new Coord2(Int32.MaxValue);

        public Coord2(int value)
        {
            X = Y = value;
        }
        public Coord2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Coord2 value)
        {
            return value.X == X && value.Y == Y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            return Equals((Coord2)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public static bool operator ==(Coord2 a, Coord2 b)
        {
            return (a.X == b.X && a.Y == b.Y);
        }
        public static bool operator !=(Coord2 a, Coord2 b)
        {
            return !(a.X == b.X && a.Y == b.Y);
        }

        public static bool operator <(Coord2 a, Coord2 b)
        {
            return (a.X < b.X || a.Y < b.Y);
        }

        public static bool operator >(Coord2 a, Coord2 b)
        {
            return (a.X > b.X || a.Y > b.Y);
        }

        public static bool operator <=(Coord2 a, Coord2 b)
        {
            return (a.X <= b.X || a.Y <= b.Y);
        }

        public static bool operator >=(Coord2 a, Coord2 b)
        {
            return (a.X >= b.X || a.Y >= b.Y);
        }

        public static Coord2 operator -(Coord2 value)
        {
            return new Coord2(-value.X, -value.Y);
        }

        public static Coord2 operator +(Coord2 a, Coord2 b)
        {
            return new Coord2(a.X + b.X, a.Y + b.Y);
        }
        public static Coord2 operator -(Coord2 a, Coord2 b)
        {
            return new Coord2(a.X - b.X, a.Y - b.Y);
        }
        public static Coord2 operator *(Coord2 a, Coord2 b)
        {
            return new Coord2(a.X * b.X, a.Y * b.Y);
        }
        public static Coord2 operator /(Coord2 a, Coord2 b)
        {
            return new Coord2(a.X / b.X, a.Y / b.Y);
        }

        public static Coord2 operator +(Coord2 a, int b)
        {
            return new Coord2(a.X + b, a.Y + b);
        }
        public static Coord2 operator -(Coord2 a, int b)
        {
            return new Coord2(a.X - b, a.Y - b);
        }
        public static Coord2 operator *(Coord2 a, int b)
        {
            return new Coord2(a.X * b, a.Y * b);
        }
        public static Coord2 operator /(Coord2 a, int b)
        {
            return new Coord2(a.X / b, a.Y / b);
        }


        public static void Abs(ref Coord2 value, out Coord2 result)
        {
            result.X = System.Math.Abs(value.X);
            result.Y = System.Math.Abs(value.Y);
        }
        public static Coord2 Abs(ref Coord2 value)
        {
            Coord2 result;
            Abs(ref value, out result);
            return result;
        }
        public static Coord2 Abs(Coord2 value)
        {
            Coord2 result;
            Abs(ref value, out result);
            return result;
        }
        public void Abs()
        {
            Abs(ref this, out this);
        }

        public static Coord2 Maximize(Coord2 left, Coord2 right)
        {
            return new Coord2()
            {
                X = left.X <= right.X ? right.X : left.X,
                Y = left.Y <= right.Y ? right.Y : left.Y,
            };
        }

        public static Coord2 Minimize(Coord2 left, Coord2 right)
        {
            return new Coord2()
            {
                X = left.X >= right.X ? right.X : left.X,
                Y = left.Y >= right.Y ? right.Y : left.Y,
            };
        }

        /// <summary>
        /// Returns the value of the coordinate's largest component.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int Max(Coord2 value)
        {
            return System.Math.Max(value.X, value.Y);
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
        public static int Min(Coord2 value)
        {
            return System.Math.Min(value.X, value.Y);
        }
        public int Min()
        {
            return Min(this);
        }


        #region Conversion

        public Coord3 ToCoord3(int z = 0)
        {
            return new Coord3(X, Y, z);
        }

        public Vector2 ToVector2()
        {
            return new Vector2(X, Y);
        }

        public int[] ToArray()
        {
            return new int[] { X, Y };
        }

        public override string ToString()
        {
            return Invariant($"X: {X}, Y: {Y}");
        }

        #endregion

    }

    public static class Coord2Extensions
    {
        public static void Write(this BinaryWriter bin, Coord2 value)
        {
            bin.Write(value.X);
            bin.Write(value.Y);
        }

        public static Coord2 ReadCoord2(this BinaryReader bin)
        {
            int x = bin.ReadInt32();
            int y = bin.ReadInt32();
            return new Coord2(x, y);
        }
    }
}
