﻿using System;

namespace MKLNET
{
    public enum Layout
    {
        RowMajor = 101,
        ColMajor = 102,
    }

    public enum Transpose
    {
        No = 111,
        Yes = 112,
    }

    public enum TransChar : byte
    {
        No = (byte)'N',
        Yes = (byte)'T',
    }

    public enum Diag
    {
        NonUnit = 131,
        Unit = 132,
    }

    public enum DiagChar : byte
    {
        NonUnit = (byte)'N',
        Unit = (byte)'U',
    }

    public enum Side
    {
        Left = 141,
        Right = 142,
    }

    public enum UpLo : byte
    {
        Lower = (byte)'L',
        Upper = (byte)'U',
    }

    public enum Norm : byte
    {
        // Largest absolute value of the matrix.
        MaxAbs = (byte)'M',
        // 1-norm of the matrix (maximum column sum).
        One = (byte)'1',
        // Infinity norm of the matrix (maximum row sum).
        Inf = (byte)'I',
        // Frobenius norm of the matrix (square root of sum of squares).
        Frobenius = (byte)'F',
    }

    unsafe internal struct MKLVersion_
    {
        public int MajorVersion;
        public int MinorVersion;
        public int UpdateVersion;
        public sbyte* ProductStatus;
        public sbyte* Build;
        public sbyte* Processor;
        public sbyte* Platform;
    }

    public struct MKLVersion
    {
        public int MajorVersion;
        public int MinorVersion;
        public int UpdateVersion;
        public string ProductStatus;
        public string Build;
        public string Processor;
        public string Platform;
    }

    public struct VslStream
    {
        readonly IntPtr Ptr;
    }

    public struct VsldConvTask
    {
        readonly IntPtr Ptr;
    }

    public struct VslsConvTask
    {
        readonly IntPtr Ptr;
    }

    public struct VsldCorrTask
    {
        readonly IntPtr Ptr;
    }

    public struct VslsCorrTask
    {
        readonly IntPtr Ptr;
    }

    public struct VsldSSTask
    {
        readonly IntPtr Ptr;
    }

    public struct VslsSSTask
    {
        readonly IntPtr Ptr;
    }

    public struct VsliSSTask
    {
        readonly IntPtr Ptr;
    }

    public enum VslMode
    {
        AUTO   = 0,
        DIRECT = 1,
        FFT    = 2,
    }

    public enum VslStorage
    {
        ROWS = 0x00010000,
        COLS = 0x00020000,
    }

    public enum VslFormat
    {
        FULL     = 0x00000000,
        L_PACKED = 0x00000001,
        U_PACKED = 0x00000002,
    }

    public enum VslPrecision
    {
        SINGLE = 1,
        DOUBLE = 2,
    }

    public enum VslEstimate : ulong
    {
        SS_MEAN          = 0x0000000000000001,
        SS_2R_MOM        = 0x0000000000000002,
        SS_3R_MOM        = 0x0000000000000004,
        SS_4R_MOM        = 0x0000000000000008,
        SS_2C_MOM        = 0x0000000000000010,
        SS_3C_MOM        = 0x0000000000000020,
        SS_4C_MOM        = 0x0000000000000040,
        SS_SUM           = 0x0000000002000000,
        SS_2R_SUM        = 0x0000000004000000,
        SS_3R_SUM        = 0x0000000008000000,
        SS_4R_SUM        = 0x0000000010000000,
        SS_2C_SUM        = 0x0000000020000000,
        SS_3C_SUM        = 0x0000000040000000,
        SS_4C_SUM        = 0x0000000080000000,
        SS_KURTOSIS      = 0x0000000000000080,
        SS_SKEWNESS      = 0x0000000000000100,
        SS_VARIATION     = 0x0000000000000200,
        SS_MIN           = 0x0000000000000400,
        SS_MAX           = 0x0000000000000800,
        SS_COV           = 0x0000000000001000,
        SS_COR           = 0x0000000000002000,
        SS_CP            = 0x0000000100000000,
        SS_POOLED_COV    = 0x0000000000004000,
        SS_GROUP_COV     = 0x0000000000008000,
        SS_POOLED_MEAN   = 0x0000000800000000,
        SS_GROUP_MEAN    = 0x0000001000000000,
        SS_QUANTS        = 0x0000000000010000,
        SS_ORDER_STATS   = 0x0000000000020000,
        SS_SORTED_OBSERV = 0x0000008000000000,
        SS_ROBUST_COV    = 0x0000000000040000,
        SS_OUTLIERS      = 0x0000000000080000,
        SS_PARTIAL_COV   = 0x0000000000100000,
        SS_PARTIAL_COR   = 0x0000000000200000,
        SS_MISSING_VALS  = 0x0000000000400000,
        SS_PARAMTR_COR   = 0x0000000000800000,
        SS_STREAM_QUANTS = 0x0000000001000000,
        SS_MDAD          = 0x0000000200000000,
        SS_MNAD          = 0x0000000400000000,
    }

    public enum VslMethod
    {
        SS_FAST            = 0x00000001,
        SS_1PASS           = 0x00000002,
        SS_SD              = 0x00000004,
        SS_TBS             = 0x00000008,
        SS_MI              = 0x00000010,
        SS_BACON           = 0x00000020,
        SS_SQUANTS_ZW      = 0x00000040,
        SS_SQUANTS_ZW_FAST = 0x00000080,
        SS_FAST_USER_MEAN  = 0x00000100,
        SS_CP_TO_COVCOR    = 0x00000200,
        SS_SUM_TO_MOM      = 0x00000400,
        SS_RADIX           = 0x00100000,
    }

    public enum VslBrng
    {
        MCG31         = (1 << 20),
        R250          = (1 << 20) * 2,
        MRG32K3A      = (1 << 20) * 3,
        MCG59         = (1 << 20) * 4,
        WH            = (1 << 20) * 5,
        SOBOL         = (1 << 20) * 6,
        NIEDERR       = (1 << 20) * 7,
        MT19937       = (1 << 20) * 8,
        MT2203        = (1 << 20) * 9,
        IABSTRACT     = (1 << 20) * 10,
        DABSTRACT     = (1 << 20) * 11,
        SABSTRACT     = (1 << 20) * 12,
        SFMT19937     = (1 << 20) * 13,
        NONDETERM     = (1 << 20) * 14,
        ARS5          = (1 << 20) * 15,
        PHILOX4X32X10 = (1 << 20) * 16,
    }

    public enum VslMethodUniform
    {
        STD = 0,
        STD_ACCURATE = 1<<30,
    }

    public enum VslMethodUniformBits
    {
        STD = 0,
    }

    public enum VslMethodGaussian
    {
        BOXMULLER = 0,
        BOXMULLER2 = 1,
        ICDF = 2,
    }

    public enum VslMethodExponential
    {
        ICDF = 0,
        ICDF_ACCURATE = 1 << 30,
    }

    public enum VslMethodLaplace
    {
        ICDF = 0,
    }

    public enum VslMethodWeibull
    {
        ICDF = 0,
        ICDF_ACCURATE = 1 << 30,
    }

    public enum VslMethodCauchy
    {
        ICDF = 0,
    }

    public enum VslMethodRayleigh
    {
        ICDF = 0,
        ICDF_ACCURATE = 1 << 30,
    }

    public enum VslMethodLognormal
    {
        BOXMULLER2 = 0,
        ICDF = 1,
        BOXMULLER2_ACCURATE = 1 << 30,
        ICDF_ACCURATE = (1 << 30) | 1,
    }

    public enum VslMethodGumbel
    {
        ICDF = 0,
    }

    public enum VslMethodGamma
    {
        ICDF = 0,
        ICDF_ACCURATE = 1 << 30,
    }

    public enum VslMethodBeta
    {
        CJA = 0,
        CJA_ACCURATE = 1 << 30,
    }

    public enum VslMethodChiSquare
    {
        CHI2GAMMA = 0,
    }

    public enum VslMethodBernoulli
    {
        ICDF = 0,
    }

    public enum VslMethodGeometric
    {
        ICDF = 0,
    }

    public enum VslMethodBinomial
    {
        BTPE = 0,
    }

    public enum VslMethodMultinomial
    {
        MULTPOISSON = 0,
    }

    public enum VslMethodHypergeometric
    {
        H2PE = 0,
    }

    public enum VslMethodPoisson
    {
        PTPE = 0,
        POISNORM = 1,
    }

    public enum VslMethodPoissonV
    {
        POISNORM = 0,
    }

    public enum VslMethodNegBinomial
    {
        NBAR = 0,
    }

    public enum MklThreading
    {
        INTEL      = 0,
        SEQUENTIAL = 1,
        PGI        = 2,
        GNU        = 3,
        TBB        = 4,
    }

    public enum MklCBWR
    {
        OFF           =  0,
        BRANCH_OFF    =  1,
        AUTO          =  2,
        COMPATIBLE    =  3,
        SSE2          =  4,
        SSSE3         =  6,
        SSE4_1        =  7,
        SSE4_2        =  8,
        AVX           =  9,
        AVX2          = 10,
        AVX512_MIC    = 11,
        AVX512        = 12,
        AVX512_MIC_E1 = 13,
        AVX512_E1     = 14,
        STRICT        = 0x10000,
    }
}