using System.Collections.Generic;
using System;
using System.Linq;
namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question2
    {
        class Solution {
            public int[] dicoIn;
            public int[] dicoOut;
            public void GeneratePartitions(int[] cashflowIn, int[] cashflowOut) {
                this.dicoIn = cashflowIn;
                this.dicoOut = cashflowOut;
            }
            public List<int> FindAllSum(int[] dico) {
                int[] sums = new int[(int)Math.Pow(2, dico.Length) - 1];
                int i = 0;
                int j = 0;
                foreach (int v in dico) {
                    i = j;
                    for (int kk = 0 ; kk < i ; ++kk) {
                        sums[i + kk] = sums[kk] + v;
                        j += 1;
                    }
                    sums[j] = v;
                    j += 1;
                }
                List<int> result = new List<int>(sums);
                result.Sort();
                return result;
            }
            public int FindMinDistance(int[] l1, int[] l2) {
                int min;
                if (l1[0] < l2[0]) {
                    min = l1[0];
                } else {
                    min = l2[0];
                }

                int i = 0;
                int j = 0;
                int n = l1.Length;
                int m = l2.Length;
                while (i < n && j < m) {
                    int a1 = l1[i];
                    int a2 = l2[j];
                    int t;
                    if (a1 < a2) {
                        i += 1;
                        t = a2 - a1;
                        if (t < min) {
                            min = t;
                        }
                    } else {
                        j += 1;
                        t = a1 - a2;
                        if (t < min) {
                            min = t;
                        }
                    }
                    if (min == 0) {
                        return 0;
                    }
                }
                return min;
            }

            public int Run(int[] cashflowIn, int[] cashflowOut) {
                this.GeneratePartitions(cashflowIn, cashflowOut);
                return this.FindMinDistance(this.FindAllSum(this.dicoIn).ToArray(), this.FindAllSum(this.dicoOut).ToArray());
            }
            public int GetMin(int[] tab) {
                int r = int.MaxValue;
                foreach (int v in tab) {
                    if (v < r) {
                        r = v;
                    }
                }
                return r;
            }
        }
        public static int Answer(int[] cashflowIn, int[] cashflowOut)
        {            
            Solution s = new Solution();
            if (cashflowIn.Length == 0) {
                return s.GetMin(cashflowOut);
            } else if (cashflowOut.Length == 0) {
                return s.GetMin(cashflowIn);
            } else {
                return s.Run(cashflowIn, cashflowOut);
            }
        }
    }
}
//  public static async System.Threading.Tasks.Task<int> AnswerRegroupParraTask(int[] cashflowIn, int[] cashflowOut) {
//         int degreeOfParallelism = Environment.ProcessorCount;
//         if(Environment.ProcessorCount > 1){
//             var results = await System.Threading.Tasks.Task.WhenAll(
//                 System.Threading.Tasks.Task.Run(() => sumSetCounts(cashflowIn)),
//                 System.Threading.Tasks.Task.Run(() => sumSetCounts(cashflowOut)));