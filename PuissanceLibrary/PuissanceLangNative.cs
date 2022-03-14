using System.Numerics;

namespace PuissanceLibrary;

public class PuissanceLangNative : IPuissance
{
    public BigInteger GetResult(BigInteger a, int b)
    {
        return BigInteger.Pow(a, b);
    }
}
