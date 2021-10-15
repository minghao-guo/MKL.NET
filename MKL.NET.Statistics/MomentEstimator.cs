﻿using System;

namespace MKLNET;

/// <summary>A central and standard moments estimator up to kurtosis.
/// See <see href="https://en.wikipedia.org/wiki/Algorithms_for_calculating_variance">Algorithms for calculating variance</see>.</summary>
public class Moment4Estimator
{
    /// <summary>The number of sample observations.</summary>
    public long N;
    /// <summary>The mean.</summary>
    public double M1;
    /// <summary>The second central sum.</summary>
    public double S2;
    /// <summary>The third central sum.</summary>
    public double S3;
    /// <summary>The fourth central sum.</summary>
    public double S4;
    /// <summary>The mean.</summary>
    public double Mean => M1;
    /// <summary>The variance.</summary>
    public double Variance => S2 / (N - 1);
    /// <summary>The standard deviation.</summary>
    public double StandardDeviation => Math.Sqrt(S2 / (N - 1));
    /// <summary>The skewness corrected for systematic bias.</summary>
    public double Skewness => Math.Sqrt((N - 1) / S2) * S3 / S2 * N / (N - 2);
    /// <summary>The excess kurtosis corrected for systematic bias.</summary>
    public double Kurtosis => (((N + 1) * S4 / (S2 * S2) - 3) * N + 3) * (N - 1) / (N - 2) / (N - 3);
    /// <summary>Add a sample observation.</summary>
    /// <param name="o">Sample observation value.</param>
    public void Add(double o)
    {
        o -= M1;
        var s = o / ++N;
        M1 += s;
        var term1 = (N - 1) * o * s;
        S4 += (term1 * s * (N * N - 3 * N + 3) + 6 * s * S2 - 4 * S3) * s;
        S3 += (term1 * (N - 2) - 3 * S2) * s;
        S2 += term1;
    }
    /// <summary>Combine another Moment4Estimator.</summary>
    /// <param name="o">Moment4Estimator</param>
    public void Add(Moment4Estimator o)
    {
        var n = N + o.N;
        var d = o.M1 - M1;
        var d2 = d * d;
        var s1 = (N * M1 + o.N * o.M1) / n;
        var s2 = S2 + o.S2 + d2 * N * o.N / n;
        var s3 = S3 + o.S3 + d2 * d * N * o.N * (N - o.N) / (n * n) + 3 * d * (N * o.S2 - o.N * S2) / n;
        S4 = S4 + o.S4 + d2 * d2 * N * o.N * (N * N - N * o.N + o.N * o.N) / (n * n * n)
              + 6 * d2 * (N * N * o.S2 + o.N * o.N * S2) / (n * n) + 4 * d * (N * o.S3 - o.N * S3) / n;
        M1 = s1;
        S2 = s2;
        S3 = s3;
        N = n;
    }
    /// <summary>Combine two Moment4Estimators.</summary>
    /// <param name="a">First Moment4Estimator</param>
    /// <param name="b">Second Moment4Estimator</param>
    public static Moment4Estimator operator +(Moment4Estimator a, Moment4Estimator b)
    {
        var n = a.N + b.N;
        var d = b.M1 - a.M1;
        var d2 = d * d;
        return new Moment4Estimator
        {
            N = n,
            M1 = (a.N * a.M1 + b.N * b.M1) / n,
            S2 = a.S2 + b.S2 + d2 * a.N * b.N / n,
            S3 = a.S3 + b.S3 + d2 * d * a.N * b.N * (a.N - b.N) / (n * n) + 3 * d * (a.N * b.S2 - b.N * a.S2) / n,
            S4 = a.S4 + b.S4 + d2 * d2 * a.N * b.N * (a.N * a.N - a.N * b.N + b.N * b.N) / (n * n * n)
                    + 6 * d2 * (a.N * a.N * b.S2 + b.N * b.N * a.S2) / (n * n) + 4 * d * (a.N * b.S3 - b.N * a.S3) / n
        };
    }
}

/// <summary>A central and standard moments estimator up to skewness.
/// See <see href="https://en.wikipedia.org/wiki/Algorithms_for_calculating_variance">Algorithms for calculating variance</see>.</summary>
public class Moment3Estimator
{
    /// <summary>The number of sample observations.</summary>
    public long N;
    /// <summary>The mean.</summary>
    public double M1;
    /// <summary>The second central sum.</summary>
    public double S2;
    /// <summary>The third central sum.</summary>
    public double S3;
    /// <summary>The mean.</summary>
    public double Mean => M1;
    /// <summary>The variance.</summary>
    public double Variance => S2 / (N - 1);
    /// <summary>The standard deviation.</summary>
    public double StandardDeviation => Math.Sqrt(S2 / (N - 1));
    /// <summary>The skewness corrected for systematic bias.</summary>
    public double Skewness => Math.Sqrt((N - 1) / S2) * S3 / S2 * N / (N - 2);
    /// <summary>Add a sample observation.</summary>
    /// <param name="o">Sample observation value.</param>
    public void Add(double o)
    {
        o -= M1;
        var s = o / ++N;
        M1 += s;
        var term1 = (N - 1) * o * s;
        S3 += (term1 * (N - 2) - 3 * S2) * s;
        S2 += term1;
    }
    /// <summary>Combine another Moment3Estimator.</summary>
    /// <param name="o">Moment3Estimator</param>
    public void Add(Moment3Estimator o)
    {
        var n = N + o.N;
        var d = o.M1 - M1;
        var d2 = d * d;
        var s1 = (N * M1 + o.N * o.M1) / n;
        var s2 = S2 + o.S2 + d2 * N * o.N / n;
        var s3 = S3 + o.S3 + d2 * d * N * o.N * (N - o.N) / (n * n) + 3 * d * (N * o.S2 - o.N * S2) / n;
        M1 = s1;
        S2 = s2;
        S3 = s3;
        N = n;
    }
    /// <summary>Combine two Moment3Estimators.</summary>
    /// <param name="a">First Moment3Estimator</param>
    /// <param name="b">Second Moment3Estimator</param>
    public static Moment3Estimator operator +(Moment3Estimator a, Moment3Estimator b)
    {
        var n = a.N + b.N;
        var d = b.M1 - a.M1;
        var d2 = d * d;
        return new Moment3Estimator
        {
            N = n,
            M1 = (a.N * a.M1 + b.N * b.M1) / n,
            S2 = a.S2 + b.S2 + d2 * a.N * b.N / n,
            S3 = a.S3 + b.S3 + d2 * d * a.N * b.N * (a.N - b.N) / (n * n) + 3 * d * (a.N * b.S2 - b.N * a.S2) / n,
        };
    }
}

/// <summary>A central and standard moments estimator up to variance.
/// See <see href="https://en.wikipedia.org/wiki/Algorithms_for_calculating_variance">Algorithms for calculating variance</see>.</summary>
public class Moment2Estimator
{
    /// <summary>The number of sample observations.</summary>
    public long N;
    /// <summary>The mean.</summary>
    public double M1;
    /// <summary>The second central sum.</summary>
    public double S2;
    /// <summary>The mean.</summary>
    public double Mean => M1;
    /// <summary>The variance.</summary>
    public double Variance => S2 / (N - 1);
    /// <summary>The standard deviation.</summary>
    public double StandardDeviation => Math.Sqrt(S2 / (N - 1));
    /// <summary>Add a sample observation.</summary>
    /// <param name="o">Sample observation value.</param>
    public void Add(double o)
    {
        o -= M1;
        var s = o / ++N;
        M1 += s;
        S2 += (N - 1) * o * s;
    }
    /// <summary>Combine another Moment2Estimator.</summary>
    /// <param name="o">Moment2Estimator</param>
    public void Add(Moment2Estimator o)
    {
        var n = N + o.N;
        var d = o.M1 - M1;
        var d2 = d * d;
        var s1 = (N * M1 + o.N * o.M1) / n;
        var s2 = S2 + o.S2 + d2 * N * o.N / n;
        M1 = s1;
        S2 = s2;
        N = n;
    }
    /// <summary>Combine two Moment2Estimators.</summary>
    /// <param name="a">First Moment2Estimator</param>
    /// <param name="b">Second Moment2Estimator</param>
    public static Moment2Estimator operator +(Moment2Estimator a, Moment2Estimator b)
    {
        var n = a.N + b.N;
        var d = b.M1 - a.M1;
        var d2 = d * d;
        return new Moment2Estimator
        {
            N = n,
            M1 = (a.N * a.M1 + b.N * b.M1) / n,
            S2 = a.S2 + b.S2 + d2 * a.N * b.N / n,
        };
    }
}