using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyScheduleAnalyzer
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        [Params(100, 1000, 10000, 100000)]
        public  int Iterations;

        [Benchmark]
        public string StringConcatenation()
        {
            string result = "";
            for(int i = 0;i< Iterations; i++)
            {
                result += "a";
            }
            return result;
        }

        [Benchmark]
        public string StringBuilderConcatenation()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Iterations; i++)
            {
                result.Append("a");
            }

            return result.ToString();
        }
    }
}
