using System.Collections.Generic;
using System.Linq;
using System;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question4
    {
        public static int Parse(string str) {
            int y = 0;
            int n = str.Length;
            for (int i = 0 ; i < n; i++) {
                y = y * 10 + (str[i] - '0');
            }
            return y;
        }
        public static int Answer(string[,] machineToBeFixed, int numOfConsecutiveMachines)
        {
            int m = machineToBeFixed.GetLength(1);
            if (m < numOfConsecutiveMachines) {
                return 0;
            } else {
                int result = int.MaxValue;
                int n = machineToBeFixed.GetLength(0);
                for (int i = 0 ; i < n ; i++) {
                    int lastX = -1;
                    int sumTmp = 0;
                    for (int j = 0 ; j < m ; j++) {
                        if (machineToBeFixed[i, j][0] == 'X') {
                            lastX = j;
                            sumTmp = 0;
                            if (m-j-1 < numOfConsecutiveMachines) {
                                break;
                            }
                        } else {
                            int a = Question4.Parse(machineToBeFixed[i, j]);
                            sumTmp += a;
                            if (j - lastX == numOfConsecutiveMachines) {
                                if (sumTmp < result) {
                                    result = sumTmp;
                                }
                                lastX += 1;
                                sumTmp -= Question4.Parse(machineToBeFixed[i, lastX]);
                            }
                        }
                    }
                }
                return (result == int.MaxValue - 1) ? 0 : result;
            }
            // List<List<string>> machines = new List<List<string>>();
            // for (int i = 0 ; i < machineToBeFixed.GetLength(0) ; i++) {
            //     List<string> tmp = new List<string>();
            //     for (int j = 0 ; j < machineToBeFixed.GetLength(1) ; j++) {
            //         tmp.Add(machineToBeFixed[i,j]);
            //     }
            //     machines.Add(tmp);
            // }
            // IEnumerable<int> tt = machines.Select(l => {
            //     int r = int.MaxValue - 1;
            //     int sum = 0;
            //     List<int> tmp = new List<int>();
            //     for (int i = 0 ; i < l.Count ; i++) {
            //         if (l[i][0] == 'X') {
            //             tmp.RemoveAll(t => true);
            //             sum = 0;
            //         } else {
            //             int a = Question4.Parse(l[i]);
            //             sum += a;
            //             tmp.Add(a);
            //             if (tmp.Count == numOfConsecutiveMachines) {
            //                 if (sum < r) {
            //                     r = sum;
            //                 }
            //                 sum -= tmp[0];
            //                 tmp.RemoveAt(0);
            //             }
            //         }
            //     }
            //     return r;
            // });
            // int result = tt.Aggregate((a,b) => {
            //     if (a < b) {
            //         return a;
            //     } else {
            //         return b;
            //     }
            // });
            // return result;
        }
    }
}