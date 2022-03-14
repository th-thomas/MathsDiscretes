namespace PgcdLibrary;

public class PgcdEuclide : IPgcd
{
    public ulong GetResult(ulong a, ulong b)
    {
        return b == 0 ? a : GetResult(b, a % b);
    }
}
