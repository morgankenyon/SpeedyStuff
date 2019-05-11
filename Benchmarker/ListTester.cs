using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmarker
{
    public class ListTester
    {
        public void TestList()
        {
            var intList = new List<int>();
            Console.WriteLine($"count/capacity: {intList.Count}/{intList.Capacity}");

            for(int i = 0; i < 10; i++)
            {
                intList.Add(i);
                Console.WriteLine($"count/capacity: {intList.Count}/{intList.Capacity}");
            }
            Console.ReadKey();
        }
    }
}
