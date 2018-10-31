using System.Collections.Generic;
using System;
namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question2
    {
        class Solution2 {

            public Dictionary<int, int> dicoIn;
            public Dictionary<int, int> dicoOut;
            public void GeneratePartitions(int[] cashflowIn, int[] cashflowOut) {
                this.dicoIn = new Dictionary<int, int>();
                this.dicoOut = new Dictionary<int, int>();
                int m1 = (cashflowIn.Length < cashflowOut.Length) ? cashflowIn.Length : cashflowOut.Length;
                int m2 = (m1 == cashflowOut.Length) ? cashflowIn.Length : cashflowOut.Length;
                for (int i = 0 ; i < m1 ; i++) {
                    int t1 = cashflowIn[i];
                    int t2 = cashflowOut[i];
                    if (!dicoIn.TryAdd(t1, 1)) {
                        dicoIn[t1] += 1; 
                    }
                    if (!dicoOut.TryAdd(t2, 1)) {
                        dicoOut[t2] += 1; 
                    }
                }
                if (m1 == cashflowOut.Length) {
                    for (int i = m1 ; i < m2 ; i++) {
                        int t1 = cashflowIn[i];
                        if (!dicoIn.TryAdd(t1, 1)) {
                            dicoIn[t1] += 1; 
                        }
                    }
                } else {
                    for (int i = m1 ; i < m2 ; i++) {
                    int t2 = cashflowOut[i];
                        if (!dicoOut.TryAdd(t2, 1)) {
                            dicoOut[t2] += 1; 
                        }
                    }
                }
            }

            public List<int> FindAllSum(Dictionary<int,int> dico) {
                List<int> alreadyAdded = new List<int>();
                foreach (KeyValuePair<int,int> kvp in dico) {
                    List<int> tmp = new List<int>();
                    int a = kvp.Key;
                    for (int i = 0 ; i < kvp.Value ; i++) {
                        foreach (int kk in alreadyAdded) {
                            tmp.Add(kk + a);
                        }
                    }
                    for (int i = 0 ; i < kvp.Value ; i++) {
                        tmp.Add(a);
                        a += kvp.Key;
                    }
                    alreadyAdded.AddRange(tmp);
                }
                alreadyAdded.Sort();
                return alreadyAdded;
            }
            public int FindMinDistance(int[] l1, int[] l2) {
                int min = (l1[0] < l2[0]) ? l1[0] : l2[0];
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
                for (int i = 0 ; i < tab.Length ; i++) {
                    int t = tab[i];
                    if (t < r) {
                        r = t;
                    }
                }
                return r;
            }
        }
        class Solution {

            public int[] dicoIn;
            public int[] dicoOut;
            public void GeneratePartitions(int[] cashflowIn, int[] cashflowOut) {
                this.dicoIn = cashflowIn;
                this.dicoOut = cashflowOut;
            }
            public List<int> FindAllSum(int[] dico) {
                int[] alreadyAdded = new int[(int)Math.Pow(2, dico.Length)];
                int i = 0;
                int j = 0;
                foreach (int v in dico) {
                    for (int kk = 0 ; kk < i ; ++kk) {
                        alreadyAdded[j + kk] = kk + v;
                        j += 1;
                    }
                    i = j;
                    alreadyAdded[i] = v;
                    j += 1;
                }
                List<int> result = new List<int>(alreadyAdded);
                result.Sort();
                return result;
            }
            public int FindMinDistance(int[] l1, int[] l2) {
                int min = (l1[0] < l2[0]) ? l1[0] : l2[0];
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
        public static int Answer2(int[] cashflowIn, int[] cashflowOut)
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

        public static int Answer(int[] cashflowIn, int[] cashflowOut)
        {            
            Solution2 s = new Solution2();
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

/**
JE LAISSE EN SUSPEND / LES DEUX ALGOS SEMBLENT FAIRE LE MEME TEMPS
 */

//  public static async System.Threading.Tasks.Task<int> AnswerRegroupParraTask(int[] cashflowIn, int[] cashflowOut) {
//         int degreeOfParallelism = Environment.ProcessorCount;
//         if(Environment.ProcessorCount > 1){
//             var results = await System.Threading.Tasks.Task.WhenAll(
//                 System.Threading.Tasks.Task.Run(() => sumSetCounts(cashflowIn)),
//                 System.Threading.Tasks.Task.Run(() => sumSetCounts(cashflowOut)));