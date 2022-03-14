using Algorithm;
using PgcdLibrary;
using PuissanceLibrary;

namespace Cli;

public class Program
{
    public static void Main(string[] args)
    {
        IAlgoComparer pgcdComparer = new PuissanceComparer(new PuissanceLangNative(), new PuissanceNaive());
        pgcdComparer.Compare();
    }
}
