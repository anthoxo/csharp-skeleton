using System.Collections.Generic;
using System;
namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question2
    {
        class Solution {

            public Dictionary<int, int> dicoIn;
            public Dictionary<int, int> dicoOut;
            public void GeneratePartitions(int[] cashflowIn, int[] cashflowOut) {
                Console.WriteLine("cashflowIN");
                for (int i = 0 ; i < cashflowIn.Length ; i++) {
                    Console.Write(cashflowIn[i] + ",");
                }
                Console.WriteLine();
                Console.WriteLine("cashflowOUT");
                for (int i = 0 ; i < cashflowOut.Length ; i++) {
                    Console.Write(cashflowOut[i] + ",");
                }
                Console.WriteLine();

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

            public SortedSet<int> FindAllSum(Dictionary<int,int> dico) {
                List<int> alreadyAdded = new List<int>();
                foreach (KeyValuePair<int,int> kvp in dico) {
                    List<int> tmp = new List<int>();
                    int a = kvp.Key;
                    for (int i = 0 ; i < kvp.Value ; i++) {
                        foreach (int kk in alreadyAdded) {
                            tmp.Add(kk + a);
                            a += kvp.Key;
                        }
                    }
                    a = kvp.Key;
                    for (int i = 0 ; i < kvp.Value ; i++) {
                        tmp.Add(a);
                        a += kvp.Key;
                    }
                    alreadyAdded.AddRange(tmp);
                }
                return new SortedSet<int>(alreadyAdded);
            }

            public int FindMinDistance(SortedSet<int> l1, SortedSet<int> l2) {
                int min = 1000;
                l1.Add(0);
                l2.Add(0);
                foreach (int a1 in l1) {
                    foreach (int a2 in l2) {
                        if (a1 == 0 && a2 ==0) {

                        } else {
                            int t = (a1 < a2) ? a2 - a1 : a1 - a2;
                            if (t == 0) {
                                return 0;
                            } else {
                                if (t < min) {
                                    min = t;
                                }
                            }
                        }
                    }
                }
                // foreach (int a1 in l1) {
                //     int tmpMin = int.MaxValue;
                //     int increase = -1;
                //     foreach (int a2 in l2) {
                //         if (a1 == 0 && a2 ==0) {

                //         } else {
                //             int t = (a1 < a2) ? a2 - a1 : a1 - a2;
                //             if (t == 0) {
                //                 return 0;
                //             } else {
                //                 if (t < min) {
                //                     min = t;
                //                     increase = 0;
                //                 } else if (increase == 0 || tmpMin < t) {
                //                     break;
                //                 } else {
                //                     tmpMin = t;
                //                 }
                //             }
                //         }
                //     }
                // }
                return min;
            }

            public int Run(int[] cashflowIn, int[] cashflowOut) {
                this.GeneratePartitions(cashflowIn, cashflowOut);
                return this.FindMinDistance(this.FindAllSum(this.dicoIn), this.FindAllSum(this.dicoOut));
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