using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace AlgoLab3
{
    public class Program
    {
        public int Wedd(int N, int[,] array)
        {
            int tribesCount = 1;
            HashSet<int>[] tribes = new HashSet<int>[2];
            tribes[tribesCount - 1] = new HashSet<int>();
            tribes[tribesCount] = new HashSet<int>();
            tribes[tribesCount - 1].Add(array[0, 0]);
            tribes[tribesCount - 1].Add(array[0, 1]);
            for (int i = 1; i < N; i++)
            {
                if (tribes[tribesCount - 1].Contains(array[i, 0]))
                {
                    tribes[tribesCount - 1].Add(array[i, 1]);
                }
                else if (tribes[tribesCount - 1].Contains(array[i, 1]))
                {
                    tribes[tribesCount - 1].Add(array[i, 0]);
                }
                else
                {
                    tribesCount++;
                    Array.Resize(ref tribes, tribesCount);
                    tribes[tribesCount - 1] = new HashSet<int>();
                    tribes[tribesCount - 1].Add(array[i, 0]);
                    tribes[tribesCount - 1].Add(array[i, 1]);
                }
            }
            for(int i = 0; i < tribesCount; i++)
            {
                for(int j = i + 1; i < tribesCount; j++)
                {
                    if (j == tribesCount)
                    {
                        break;
                    }
                    if (tribes[i].Overlaps(tribes[j]))
                    {
                        tribes[i].UnionWith(tribes[j]);
                        tribes[j].Clear();
                    }
                }
            }
            int amountOfCouplesToRemove = 0;
            int boysCounter = 0;
            int girlsCounter = 0;
           for (int i = 0; i < tribesCount; i++)
           {
                var counter = from tribesman in tribes[i]
                              where tribesman % 2 == 1
                              select tribesman;
                boysCounter += counter.Count();
                girlsCounter += tribes[i].Count - counter.Count();
                amountOfCouplesToRemove += counter.Count() * (tribes[i].Count - counter.Count());
           }
            return (boysCounter * girlsCounter) - amountOfCouplesToRemove;
        }
        public Program(){}
        static void Main(string[] args)
        {
            const int N = 6;
            int[,] array = new int[N,2] { { 1, 2 },{ 2, 4 },{ 1, 3 },{ 3, 5 },{ 1, 10 }, { 7, 9 } };
            Program algoObject= new Program();
            int couples=algoObject.Wedd(N, array);
            Console.WriteLine(couples);
        }
    }
}
