using Algorithm;
using PgcdLibrary;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Cli;

public class PgcdComparer : IAlgoComparer
{
    private readonly List<IPgcd> _algorithms;
    private readonly List<int> _sizesOfNumbersInBits;
    private readonly Random _random;

    public PgcdComparer(List<IPgcd> algorithms!!, List<int> sizesOfNumbersInBits = null)
    {
        if (algorithms.Count < 2)
        {
            throw new ArgumentException("Give at least two algorithms for comparison", nameof(algorithms));
        }

        _algorithms = algorithms;
        _sizesOfNumbersInBits = sizesOfNumbersInBits is null ? (new() { 10, 15, 20, 25, 30, 35, 40, 45, 50 }) : sizesOfNumbersInBits;
        _random = new();
    }

    public PgcdComparer(IPgcd pgcdMethod1, IPgcd pgcdMethod2, List<int> numberOfDigits = null)
        : this(new List<IPgcd>() { pgcdMethod1, pgcdMethod2 }, numberOfDigits)
    {

    }

    public void Compare()
    {
        foreach (var bitLength in _sizesOfNumbersInBits)
        {
            Console.WriteLine($"For {bitLength} bits numbers:");
            foreach (var method in _algorithms)
            {
                var name = method.GetType().FullName;
                var (averageTime, totalTime) = AlgorithmUtil.Time(() => method.GetResult(RandomNumber(bitLength), RandomNumber(bitLength)));
                Console.WriteLine($"\t{name} algorithm resulted in an average of {averageTime} ms (total: {totalTime} ms)");
            }
            Console.WriteLine();
        }
    }

    private ulong RandomNumber(int bitLength)
    {
        var bits = new BitArray(bitLength);
        for (var i = 0; i < bits.Count; i++)
        {
            bits[i] = _random.Next(2) == 1;
        }
        var array = new int[2];
        bits.CopyTo(array, 0);

        return (uint)array[0] + ((ulong)(uint)array[1] << 32);
    }
}
