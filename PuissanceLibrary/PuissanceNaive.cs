using System.Numerics;

namespace PuissanceLibrary;

public class PuissanceNaive : IPuissance
{
    public BigInteger GetResult(BigInteger a, int b)
    {
        BigInteger e = 1;
        for (var i = 0; i < b; i++)
        {
            e *= a;
        }
        return e;
    }
}