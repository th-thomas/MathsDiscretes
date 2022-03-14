using System;

namespace PgcdLibrary;

public class PgcdNaive : IPgcd
{
    public ulong GetResult(ulong a, ulong b)
    {
        ulong pgcd = 1;
        for (ulong i = 2; i < (Math.Min(a, b) + 1); i++)
        {
            if ((a % i == 0) && (b % i == 0))
            {
                pgcd = i;
            }
        }
        return pgcd;
    }
}
