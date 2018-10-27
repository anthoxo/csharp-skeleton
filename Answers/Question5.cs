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
                for (int i = 0 ; i < numOfShares.Length ; i++) {
                    job.Add(-1);
                    bool pred = true;
                    for (int j = 0; j < numbers.Count && pred; j++) {
                        if (numbers[j] < numOfShares[i]) {
                            pred = false;
                            numbers.Insert(j, numOfShares[i]);
                        }
                    }
                    if (pred) {
                        numbers.Add(numOfShares[i]);
                    }
                }
                for (int i = numOfShares.Length ; i < totalValueOfShares + 1 ; i++) {
                    job.Add(-1);
                }
                job[0] = 0;
                bool stop = false;
                for (int i = 0 ; i < numbers.Count && !stop ; i++) {
                    for (int j = 1 ; numbers[i] * j < totalValueOfShares + 1; j++) {
                        if (job[numbers[i]*j] == -1 || 1 + job[numbers[i]*(j-1)] < job[numbers[i]*j]) {
                            job[numbers[i]*j] = 1 + job[numbers[i]*(j-1)];
                        }
                        if (numbers[i] * j == totalValueOfShares) {
                            stop = true;
                        }
                    }
                }
                return job[totalValueOfShares];
            }
        }
    }
}