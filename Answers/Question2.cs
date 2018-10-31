using System.Collections.Generic;
using System;
using System.Linq;
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

        public static int Answer2(int[] cashflowIn, int[] cashflowOut)
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
        public class Question2bis
    {
        public static int findMinDist(int[] cashIn, int[] cashOut){
            int n = cashIn.Length;
            int m = cashOut.Length;
            int minDist = -1;
            // there should at least be a zero in each list
            if(n==1 && m == 1) return -1;
            else if(n==1) minDist = cashOut[1];
            else if(m==1) minDist = cashIn[1];
            else minDist = cashIn[1] < cashOut[1] ? cashIn[1] : cashOut[1];
            int i = 1;
            int j = 1;
            int dist;
            while(true){
                dist = Math.Abs(cashIn[i]-cashOut[j]);
                
                if(dist == 0)
                    return 0;
                else if(dist < minDist) 
                    minDist = dist;

                if(cashIn[i] < cashOut[j] && i != n-1)
                    i += 1;
                else if(cashIn[i] >= cashOut[j] && j != m-1)
                    j += 1;
                else
                    // we're either at the end of both lists or gonna increase the gap between values
                    break;
            }
            return minDist;
        }
        public static int[] sumSetCust2(int[] cashFlow) {
            int n = cashFlow.Length;
            int maxSum = 0;
            for(int i=0; i<n; ++i)
                maxSum += cashFlow[i];

            bool[] sumSetIdx = new bool[maxSum+1];
            sumSetIdx[0] = true;

            List<int> sumSet = new List<int>();
            sumSet.Add(0);
            for(int i=0; i<n; ++i){
                List<int> newSumSet = new List<int>();
                int lenSumSet = sumSet.Count();
                int cashFlowI = cashFlow[i];
                for(int j=0; j<lenSumSet; j++){
                    int newSum = sumSet[j]+cashFlowI;
                    if(!sumSetIdx[newSum]){
                        sumSetIdx[newSum] = true;
                        newSumSet.Add(newSum);
                    }
                }
                for(int j=0; j<newSumSet.Count(); j++){
                    sumSet.Add(newSumSet[j]);
                }
            }
            sumSet.Sort();
            return sumSet.ToArray();
        }
        public static int Answer(int[] cashflowIn, int[] cashflowOut) {
            int[] cashIn = sumSetCust2(cashflowIn);
            int[] cashOut = sumSetCust2(cashflowOut);
            int minDist = findMinDist(cashIn, cashOut);
            return minDist;
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