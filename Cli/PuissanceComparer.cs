using Algorithm;
using PuissanceLibrary;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Cli;

public class PuissanceComparer : IAlgoComparer
{
    private readonly List<IPuissance> _algorithms;
    private readonly List<int> _sizesOfNumbersInBits;
    private readonly Random _random;

    public PuissanceComparer(List<IPuissance> algorithms!!, List<int> sizesOfNumbersInBits = null)
    {
        if (algorithms.Count < 2)
        {
            throw new ArgumentException("Give at least two algorithms for comparison", nameof(algorithms));
        }

        _algorithms = algorithms;
        _sizesOfNumbersInBits = sizesOfNumbersInBits is null ? (new() { 10, 15, 20, 25, 30, 35, 40, 45, 50 }) : sizesOfNumbersInBits;
        _random = new();
    }

    public PuissanceComparer(IPuissance pgcdMethod1, IPuissance pgcdMethod2, List<int> numberOfDigits = null)
        : this(new List<IPuissance>() { pgcdMethod1, pgcdMethod2 }, numberOfDigits)
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

    private int RandomNumber(int bitLength)
    {
        return _random.Next((int)Math.Pow(2, bitLength - 1), (int)Math.Pow(2, bitLength));
    }
}
