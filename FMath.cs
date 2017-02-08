using System;
using System.Runtime.CompilerServices;

namespace Frostfire.Math
{
    public static class FMath
    {
        public const float PI = 3.1415926535f;
        public const float HALF_PI = 1.570796326794f;
        public const float EPSILON = 1.192092896e-07f; // or 1e-6f

        const float RAD_TO_DEG = (float)(180.0 / System.Math.PI);
        const float DEG_TO_RAD = (float)(System.Math.PI / 180.0);

        static readonly Random _randomizer = new Random();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Abs(float value)
        {
            return System.Math.Abs(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Acos(float value)
        {
            return (float)System.Math.Acos(value);
        }

        public static int AddBool(params bool[] boolean)
        {
            int value = 0;
            for (int i = 0; i < boolean.Length; i++)
                if (boolean[i])
                    value++;
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Asin(float value)
        {
            return (float)System.Math.Asin(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atan(float value)
        {
            return (float)System.Math.Atan(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atan2(float x, float y)
        {
            return (float)System.Math.Atan2(x, y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Ceil(float value)
        {
            return (float)System.Math.Ceiling(value);
        }

        /// <summary>
        /// Rounds a floating point value upwards to the next higher integer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int CeilToInt(float value)
        {
            int newValue = (int)value;
            if (value < 0.0f || System.Math.Abs(newValue - value) < EPSILON)
                return newValue;
            return ++newValue;
        }

        public static float CeilToPow2(float value, uint min = 1)
        {
            uint x;
            if (value < min)
                x = min - 1;
            else
            {
                x = (uint)value;
                if (System.Math.Abs(x - value) < EPSILON)
                    --x;
            }

            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            return (float)++x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ClampMin(int value, int min)
        {
            return value < min ? min : value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ClampMax(int value, int max)
        {
            return value > max ? max : value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ClampMin(float value, float min)
        {
            return value < min ? min : value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ClampMax(float value, float max)
        {
            return value > max ? max : value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        public static byte ClampByteMin(byte value, byte min)
        {
            return value < min ? min : value;
        }
        public static byte ClampByteMax(byte value, byte max)
        {
            return value > max ? max : value;
        }
        public static byte ClampByte(byte value, byte min, byte max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cos(float value)
        {
            return (float)System.Math.Cos(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cosh(float value)
        {
            return (float)System.Math.Cosh(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DegToRad(float angle)
        {
            return angle * DEG_TO_RAD;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float RadToDeg(float angle)
        {
            return angle * RAD_TO_DEG;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 DegToRad(Vector3 angle)
        {
            return new Vector3(angle.X * DEG_TO_RAD, angle.Y * DEG_TO_RAD, angle.Z * DEG_TO_RAD);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector3 RadToDeg(Vector3 angle)
        {
            return new Vector3(angle.X * RAD_TO_DEG, angle.Y * RAD_TO_DEG, angle.Z * RAD_TO_DEG);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Exp(float value)
        {
            return (float)System.Math.Exp(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Floor(float value)
        {
            return (float)System.Math.Floor(value);
        }

        /// <summary>
        /// Rounds a floating point value down to the next lower integer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int FloorToInt(float value)
        {
            int retValue = (int)value;
            if (value > 0.0f || System.Math.Abs(value - retValue) < EPSILON)
                return retValue;
            return --retValue;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEqual(float value1, float value2)
        {
            return System.Math.Abs(value1 - value2) < EPSILON;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPow2(int value)
        {
            return (value > 0) && ((value & (value - 1)) == 0);
        }

        /// <summary>
        /// Interpolates between 2 values.
        /// </summary>
        /// <param name="start">Starting value.</param>
        /// <param name="end">Ending value.</param>
        /// <param name="factor">Interpolation factor.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Lerp(float start, float end, float factor)
        {
            return start + ((end - start) * factor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log(float value)
        {
            return (float)System.Math.Log(value);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log(float value, float newBase)
        {
            return (float)System.Math.Log(value, newBase);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log10(float value)
        {
            return (float)System.Math.Log10(value);
        }

        /// <summary>
        /// Gets the largest of two values.
        /// </summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns>Returns the largest value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float value1, float value2)
        {
            return (value1 > value2) ? value1 : value2;
        }

        /// <summary>
        /// Gets the smallest of two values.
        /// </summary>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns>Returns the smallest value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float value1, float value2)
        {
            return (value1 < value2) ? value1 : value2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Pow(float value, float power)
        {
            return (float)System.Math.Pow(value, power);
        }

        /// <summary>
        /// Calculates a random floating point value between 0.0 and 1.0.
        /// </summary>
        public static float Rnd()
        {
            return (float)_randomizer.NextDouble();
        }
        /// <summary>
        /// Calculates a random floating point value between 2 values.
        /// </summary>
        /// <returns></returns>
        public static float Rnd(float min, float max)
        {
            return min + (float)_randomizer.NextDouble() * (max - min);
        }
        
        public static int RndInt(int startInclusive = 0, int endExclusive = 100)
        {
            return _randomizer.Next(startInclusive, endExclusive);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Round(float value, int digits = 0)
        {
            return (float)System.Math.Round(value, digits);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int RoundToInt(float value)
        {
            return (int)System.Math.Round(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sign(float value)
        {
            return System.Math.Sign(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sin(float value)
        {
            return (float)System.Math.Sin(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sinh(float value)
        {
            return (float)System.Math.Sinh(value);
        }

        /// <summary>
        /// Gets the square root.
        /// </summary>
        /// <param name="value">The value to calculate the square root from.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sqrt(float value)
        {
            // Still the fastest way to calculate the square root for a single precision floating point value in C#
            return (float)System.Math.Sqrt(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Tan(float value)
        {
            return (float)System.Math.Tan(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Tanh(float value)
        {
            return (float)System.Math.Tanh(value);
        }

        /// <summary>
        /// Wraps a value between Min and Max.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minInclusive">The minimum value.</param>
        /// <param name="maxExclusive">The Maximum value.</param>
        /// <returns></returns>
        public static float Wrap(float value, float minInclusive, float maxExclusive)
        {
            if (value < minInclusive)
                return (maxExclusive - (minInclusive - value));
            if (value >= maxExclusive)
                return value - (maxExclusive - minInclusive);
            return value;
        }

    }
}
