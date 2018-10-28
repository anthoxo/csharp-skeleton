using System.Collections.Generic;
using System;
namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question2
    {
        class Solution {

            public List<List<int>> inList;
            public List<List<int>> outList;
            public void GeneratePartitions(int[] cashflowIn, int[] cashflowOut) {
                this.inList = new List<List<int>>();
                this.outList = new List<List<int>>();

                List<int> tmpIn = new List<int>();
                List<int> tmpOut = new List<int>();
                int m1 = (cashflowIn.Length < cashflowOut.Length) ? cashflowIn.Length : cashflowOut.Length;
                int m2 = (m1 == cashflowOut.Length) ? cashflowIn.Length : cashflowOut.Length;
                for (int i = 0 ; i < m1 ; i++) {
                    tmpIn.Add(cashflowIn[i]);
                    tmpOut.Add(cashflowOut[i]);
                }
                if (m1 == cashflowOut.Length) {
                    for (int i = m1 ; i < m2 ; i++) {
                        tmpIn.Add(cashflowIn[i]);
                    }
                } else {
                    for (int i = m1 ; i < m2 ; i++) {
                        tmpOut.Add(cashflowOut[i]);
                    }
                }
                tmpIn.Sort();
                tmpOut.Sort();
                int a = tmpIn[0];
                int tmpA = 0;
                List<int> tmp = new List<int>();
                while (tmpIn.Count != 0) {
                    if (a == tmpIn[0]) {
                        tmpA += a;
                    } else {
                        this.inList.Add(tmp);
                        tmp = new List<int>();
                        a = tmpIn[0];
                        tmpA = a;
                    }
                    tmp.Add(tmpA);
                    tmpIn.RemoveAt(0);
                }
                this.inList.Add(tmp);
                a = tmpOut[0];
                tmpA = 0;
                tmp = new List<int>();
                while (tmpOut.Count != 0) {
                    if (a == tmpOut[0]) {
                        tmpA += a;
                    } else {
                        outList.Add(tmp);
                        tmp = new List<int>();
                        a = tmpOut[0];
                        tmpA = a;
                    }
                    tmp.Add(tmpA);
                    tmpOut.RemoveAt(0);
                }
                outList.Add(tmp);
            }

            public SortedSet<int> FindAllSum(List<List<int>> countList) {
                SortedSet<int> alreadyAdded = new SortedSet<int>();
                for (int i = 0 ; i < countList.Count ; i++) {
                    List<int> count = countList[i];
                    List<int> tmp = new List<int>();
                    for (int j = 0 ; j < count.Count ; j++) {
                        tmp.Add(count[j]);
                        foreach (int kk in alreadyAdded) {
                            tmp.Add(count[j] + kk);
                        }
                    }
                    for (int j = 0 ; j < tmp.Count ; j++) {
                        try {
                            alreadyAdded.Add(tmp[j]);
                        } catch (System.ArgumentException) {

                        } 
                    }
                }
                return alreadyAdded;
            }

            public int FindMinDistance(SortedSet<int> l1, SortedSet<int> l2) {
                int min = 1000;
                foreach (int a1 in l1) {
                    foreach (int a2 in l2) {
                        if (a1 - a2 == 0) {
                            return 0;
                        } else {
                            int t = Math.Abs(a1-a2);
                            if (t < min) {
                                min = t;
                            }
                        }
                    }
                }
                return min;
            }

            public int Run(int[] cashflowIn, int[] cashflowOut) {
                this.GeneratePartitions(cashflowIn, cashflowOut);
                return this.FindMinDistance(this.FindAllSum(this.inList), this.FindAllSum(this.outList));
            }
        }
        public static int Answer(int[] cashflowIn, int[] cashflowOut)
        {            
            Solution s = new Solution();
            return s.Run(cashflowIn, cashflowOut);
        }
    }
}