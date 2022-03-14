using PgcdLibrary;

namespace PGCD;

public class PgcdProgram
{
    public static void Main(string[] args)
    {
        var pgcdComparer = new PgcdComparer(new PgcdEuclide(), new PgcdNaive());
        pgcdComparer.CompareNew();
    }
}
