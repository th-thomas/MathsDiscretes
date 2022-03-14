namespace PgcdLibrary;

public class PgcdEuclide : IPgcd
{
    public ulong GetPgcd(ulong a, ulong b)
    {
        return b == 0 ? a : GetPgcd(b, a % b);
    }
}
