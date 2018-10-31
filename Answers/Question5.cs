using System.Collections.Generic;
using System;
using System.Linq;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question5
    {
        // public static int Answer2(int[] numOfShares, int totalValueOfShares) {
        //     if (numOfShares.Length == 0) {
        //         return 0;
        //     } else {
        //         List<int> job = new List<int>();
        //         List<int> numbers = new List<int>();
        //         List<bool> alreadyAdded = new List<bool>();

        //         int a;
        //         int b;

        //         for (int i = 0 ; i < numOfShares.Length ; i++) {
        //             job.Add(int.MaxValue);
        //             alreadyAdded.Add(false);
        //             if (numOfShares[i] > 0) {
        //                 numbers.Add(numOfShares[i]);
        //             }
        //         }
        //         for (int i = numOfShares.Length ; i < totalValueOfShares + 1 ; i++) {
        //             job.Add(int.MaxValue);
        //             alreadyAdded.Add(false);
        //         }
        //         job[0] = 0;
        //         alreadyAdded[0] = true;
        //         foreach(int number in numbers) {
        //             for (int i = 0 ; i < totalValueOfShares + 1 ; i++) {
        //                 if (alreadyAdded[i]) {
        //                     a = number;
        //                     b = i;
        //                     for (int k = a ; b + k < totalValueOfShares + 1 ; k = k + a) {
        //                         int c = b + k;
        //                         int t = job[c-a];
        //                         if (1 + t < job[c]) {
        //                             job[c] = 1 + t;
        //                             alreadyAdded[c] = true;
        //                         }
        //                     }

        //                 }
        //             }
        //         }
        //         if (job[totalValueOfShares] == int.MaxValue) {
        //             return 0;
        //         } else {
        //             return job[totalValueOfShares];
        //         }
        //     }
        // }
        public static int Answer(int[] numOfShares, int totalValueOfShares)
        {
            if (numOfShares.Length == 0 || totalValueOfShares == 0) {
                return 0;
            } else {
                int max = 10000;
                int[] bruh = new int[totalValueOfShares + 1];
                for (int i = 0 ; i < totalValueOfShares + 1 ; i += 1) {
                    bruh[i] = max;
                }
                bruh[0] = 0;
                int n = numOfShares.Length;
                for (int i = 0 ; i < n ; i++) {
                    int number = numOfShares[i];
                    if (number > 0) {
                        for (int k = number ; k < totalValueOfShares + 1 ; k += 1) {
                            int r = bruh[k - number] + 1;
                            if (r < bruh[k]) {
                                bruh[k] = r;
                            }
                        }
                    }
                }
                int t = bruh[totalValueOfShares];
                if (t == max) {
                    return 0;
                } else {
                    return t;
                }
            }
        }
        public static int Answer2(int[] numOfShares, int totalValueOfShares)
        {
            int max = numOfShares.Sum();
            if (max < totalValueOfShares) {
                return 0;
            } else {
                int max1 = totalValueOfShares+1;
                int[] bruh = new int[totalValueOfShares + 1];
                for (int i = 0 ; i < totalValueOfShares + 1 ; i += 1) {
                    bruh[i] = max1;
                }
                bruh[0] = 0;
                List<int> alreadyAdded = new List<int>();
                List<int> tmp = new List<int>();
                foreach (int num in numOfShares) {
                    int n = totalValueOfShares/num;
                    for (int i = num ; i < n ; i += num) {
                        foreach (int poop in alreadyAdded) {
                            int t = poop + i;
                            if (t < totalValueOfShares + 1) {
                                tmp.Add(poop + i);
                                int r = bruh[i - num] + 1;
                                if (r < bruh[i]) {
                                    bruh[i] = r;
                                }
                            }
                        }
                        tmp.Add(i);
                    }
                    alreadyAdded.AddRange(tmp);
                }
                return (bruh[totalValueOfShares] == max1) ? 0 : bruh[totalValueOfShares];
            }
        }
    }
}