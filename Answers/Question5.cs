﻿using System.Collections.Generic;
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
                SortedSet<int> numbers = new SortedSet<int>(new DescendingKeyComparer<int>());
                SortedSet<int> alreadyAdded = new SortedSet<int>(new DescendingKeyComparer<int>());

                int a;
                int b;

                for (int i = 0 ; i < numOfShares.Length ; i++) {
                    job.Add(-1);
                    if (numOfShares[i] > 0) {
                        numbers.Add(numOfShares[i]);
                    }
                }
                for (int i = numOfShares.Length ; i < totalValueOfShares + 1 ; i++) {
                    job.Add(-1);
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
                            if (1 + job[c-a] < job[c] || job[c] == -1) {
                                job[c] = 1 + job[c-a];
                                tmp.Add(c);
                            }
                        }
                    }
                    foreach (int tmpValue in tmp) {
                        try {
                            alreadyAdded.Add(tmpValue);
                        } catch (System.ArgumentException) {

                        } 
                    }
                }
                if (job[totalValueOfShares] == - 1) {
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
                SortedSet<int> numbers = new SortedSet<int>(new DescendingKeyComparer<int>());
                for (int i = 0 ; i < numOfShares.Length ; i++) {
                    job.Add(10000);
                    if (numOfShares[i] > 0) {
                        numbers.Add(numOfShares[i]);
                    }
                }
                for (int i = numOfShares.Length ; i < totalValueOfShares + 1 ; i++) {
                    job.Add(10000);
                }
                job[0] = 0;
                foreach(int number in numbers) {
                    for (int k = 1 ; k < totalValueOfShares + 1 ; k++) {
                        if (number <= k) {
                            if (1 + job[k - number] < job[k]) {
                                job[k] = 1 + job[k - number];
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