using Algorithm;
using PgcdLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace PGCD;

public class PgcdComparer
{
    private readonly List<IPgcd> _pgcdMethods;
    private readonly List<int> _sizesOfNumbersInBits;
    private readonly uint _occurences;
    private readonly Random _random;
    private readonly Stopwatch _sw;

    public PgcdComparer(List<IPgcd> pgcdMethods!!, List<int> sizesOfNumbersInBits = null, uint occurences = 10_000)
    {
        if (pgcdMethods.Count < 2)
        {
            throw new ArgumentException("Give at least two algorithms for comparison", nameof(pgcdMethods));
        }

        _pgcdMethods = pgcdMethods;
        _sizesOfNumbersInBits = sizesOfNumbersInBits is null ? (new() { 10, 15, 20, 25, 30, 35, 40, 45, 50 }) : sizesOfNumbersInBits;
        _occurences = occurences == 0 ? 1 : occurences;
        _random = new();
        _sw = new();
    }

    public PgcdComparer(IPgcd pgcdMethod1, IPgcd pgcdMethod2, List<int> numberOfDigits = null, uint occurences = 10_000)
        : this(new List<IPgcd>() { pgcdMethod1, pgcdMethod2 }, numberOfDigits, occurences)
    {

    }

    public void CompareNew()
    {
        foreach (var bitLength in _sizesOfNumbersInBits)
        {
            Console.WriteLine($"For {bitLength} bits numbers:");
            foreach (var method in _pgcdMethods)
            {
                var name = method.GetType().FullName;
                var (averageTime, totalTime) = AlgorithmUtil.Time(() => method.GetPgcd(RandomNumber(bitLength), RandomNumber(bitLength)));
                Console.WriteLine($"\t{name} algorithm resulted in an average of {averageTime} ms (total: {totalTime} ms)");
            }
            Console.WriteLine();
        }
    }

    public void Compare()
    {
        foreach (var bitLength in _sizesOfNumbersInBits)
        {
            Console.WriteLine($"For {bitLength} bits numbers:");
            foreach (var method in _pgcdMethods)
            {
                _sw.Restart();
                for (var i = 0; i < _occurences; i++)
                {
                    method.GetPgcd(RandomNumber(bitLength), RandomNumber(bitLength));
                }
                _sw.Stop();
                var methodName = method.GetType().Name;
                Console.WriteLine($"\tPGCD method '{methodName}' resulted in an average time of {_sw.ElapsedMilliseconds / _occurences} ms");
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
