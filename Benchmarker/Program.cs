using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Benchmarker
{
    [MemoryDiagnoser]
    public class Md5VsSha256
    {
        private SHA256 sha256 = SHA256.Create();
        private MD5 md5 = MD5.Create();
        private byte[] data;

        [Params(1000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            data = new byte[N];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public byte[] Sha256() => sha256.ComputeHash(data);

        [Benchmark]
        public byte[] Md5() => md5.ComputeHash(data);
    }
    
    [MemoryDiagnoser]
    public class ListMemoryBenchmarker
    {
        
        [Params(1000, 1000000)]
        public int N;
        
        [Benchmark(Baseline = true)]
        public void Array()
        {
            var array = new int[N];
            for(int i = 0; i < N; i++) 
            {
                array[i] = i;
            }
        }
        
        [Benchmark]
        public void ListA()
        {
            var list = new List<int>(N);
            for(int i = 0; i < N; i++) 
            {
                list.Add(i);
            }
        }
        
        [Benchmark]
        public void ListB()
        {
            var list = new List<int>();
            for(int i = 0; i < N; i++) 
            {
                list.Add(i);
            }            
        }

        [Benchmark]
        public void HashSet()
        {
            var set = new HashSet<int>();
            for(int i = 0; i < N; i++)
            {
                set.Add(i);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ListMemoryBenchmarker>();
        }
    }
}