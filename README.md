# Frostfire.Math
A C# single-precision 3D math library

This project was created both as a learning exercise and because I needed an API-independent math framework. The code is focused on creating a simplified experience for developers, eliminating duplicates and rarely used functions and bringing it more in-line with the XNA and Unity APIs.

The library is written for an engine that uses a right-handed Carthesian coordinate system, however none of the functions provided depend on the coordinate system used. Matrices are stored row-major, and matrix functions are written for row-vector matrices.

It is largely based on the SlimDX math source code, and released under the same license. Large parts of it have been ported from the C++ sources, other parts directly from (old) C# sources. Most of it has been rewritten and/or refactored. Other parts have been added, modified or removed.

The FMath class contains shortcuts for single precision floating-point math, and a host of useful functions.

Do note that this is largely untested, and depending on your use case you might be better off with more mature libraries such as [SharpDX.Mathematics](https://github.com/sharpdx/SharpDX/tree/master/Source/SharpDX.Mathematics).
