using System.Collections.Generic;
using System;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question5
    {
        public static int Answer2(int[] numOfShares, int totalValueOfShares) {
            if (numOfShares.Length == 0) {
                return 0;
            } else {
                List<int> job = new List<int>();
                List<int> numbers = new List<int>();
                List<int> alreadyAdded = new List<int>();

                int a;
                int b;

                for (int i = 0 ; i < numOfShares.Length ; i++) {
                    job.Add(int.MaxValue);
                    if (numOfShares[i] > 0) {
                        numbers.Add(numOfShares[i]);
                    }
                }
                for (int i = numOfShares.Length ; i < totalValueOfShares + 1 ; i++) {
                    job.Add(int.MaxValue);
                }
                job[0] = 0;
                alreadyAdded.Add(0);
                foreach(int number in numbers) {
                    List<int> tmp = new List<int>();
                    foreach (int added in alreadyAdded) {
                        a = number;
                        b = added;
                        
                        for (int k = a ; b + k < totalValueOfShares + 1 ; k = k + a) {
                            int c = b + k;
                            if (1 + job[c-a] < job[c]) {
                                job[c] = 1 + job[c-a];
                                tmp.Add(c);
                            }
                        }
                    }
                    alreadyAdded.AddRange(tmp);
                }
                if (job[totalValueOfShares] == int.MaxValue) {
                    return 0;
                } else {
                    return job[totalValueOfShares];
                }
            }
        }
        public static int Answer(int[] numOfShares, int totalValueOfShares)
        {
            if (numOfShares.Length == 0) {
                return 0;
            } else {
                List<int> job = new List<int>();
                for (int i = 0 ; i < totalValueOfShares + 1 ; i++) {
                    job.Add(10000);
                }
                job[0] = 0;
                int n = numOfShares.Length;
                for (int i = 0 ; i < n ; i++) {
                    int number = numOfShares[i];
                    if (number > 0) {
                        for (int k = 1 ; k < totalValueOfShares + 1 ; k++) {
                            if (number <= k) {
                                if (1 + job[k - number] < job[k]) {
                                    job[k] = 1 + job[k - number];
                                }
                            }
                        }
                    }
                }
                if (job[totalValueOfShares] == 10000) {
                    return 0;
                } else {
                    return job[totalValueOfShares];
                }
            }
        }
    }

}