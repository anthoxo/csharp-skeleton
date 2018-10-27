using System.Collections.Generic;
using System;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question5
    {
        public static int Answer(int[] numOfShares, int totalValueOfShares)
        {
            if (numOfShares.Length == 0) {
                return 0;
            } else {
                List<int> job = new List<int>();
                List<int> numbers = new List<int>();
                List<int> alreadyAdded = new List<int>();

                int a;
                int b;

                for (int i = 0 ; i < numOfShares.Length ; i++) {
                    job.Add(-1);
                    Question5.AddDesc(numbers, numOfShares[i], false);
                }
                for (int i = numOfShares.Length ; i < totalValueOfShares + 1 ; i++) {
                    job.Add(-1);
                }
                job[0] = 0;
                alreadyAdded.Add(0); 
                bool stop = false;
                for (int i = 0 ; i < numbers.Count && !stop ; i++) {
                    List<int> tmp = new List<int>();
                    for (int j = 0 ; j < alreadyAdded.Count; j++) {
                        for (int k = 1 ; alreadyAdded[j] + numbers[i] * k < totalValueOfShares + 1 ; k++) {
                            a = numbers[i];
                            b = alreadyAdded[j];
                            if (job[b+a*k] == -1 || 1 + job[b+a*(k-1)] < job[a*k]) {
                                job[b+a*k] = 1 + job[b+a*(k-1)];
                                Question5.AddDesc(tmp, b+a*k, true);
                            }
                            if (b + a * k == totalValueOfShares) {
                                stop = true;
                            }
                        }
                    }
                    for (int j = 0 ; j < tmp.Count ; j++) {
                        Question5.AddDesc(alreadyAdded, tmp[i], true);
                    }
                }
                if (job[totalValueOfShares] == -1) {
                    return 0;
                } else {
                    return job[totalValueOfShares];
                }
            }
        }
        public static void AddDesc(List<int> list, int a, bool uniq) {
            bool pred = true;
            for (int j = 0; j < list.Count && pred; j++) {
                if (list[j] <= a) {
                    pred = false;
                    if (!uniq || list[j] != a) {
                        list.Insert(j, a);
                    }
                }
            }
            if (pred) {
                list.Add(a);
            }
        }

    }

}