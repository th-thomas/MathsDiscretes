using System;
using System.Diagnostics;

namespace Algorithm
{
    public static class AlgorithmUtil
    {
        public static (long averageTime, long totalTime) Time(this Action algorithm, uint occurences = 100)
        {
            occurences = occurences == 0 ? 1 : occurences;

            var sw = Stopwatch.StartNew();
            for (int i = 0; i < occurences; i++)
            {
                algorithm?.Invoke();
            }
            sw.Stop();

            return (sw.ElapsedMilliseconds / occurences, sw.ElapsedMilliseconds);
        }
    }
}
