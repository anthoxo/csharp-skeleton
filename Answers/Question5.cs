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
                SortedList<int, int> numbers = new SortedList<int, int>(new DescendingKeyComparer<int>());
                SortedList<int, int> alreadyAdded = new SortedList<int, int>(new DescendingKeyComparer<int>());

                List<int> tmpNumbers = new List<int>();
                int a;
                int b;

                for (int i = 0 ; i < numOfShares.Length ; i++) {
                    job.Add(-1);
                    if (numOfShares[i] > 0) {
                        numbers.Add(numOfShares[i], numOfShares[i]);
                    }
                }
                for (int i = numOfShares.Length ; i < totalValueOfShares + 1 ; i++) {
                    job.Add(-1);
                }
                job[0] = 0;
                alreadyAdded.Add(0, 0); 
                for (int i = 0 ; i < numbers.Values.Count; i++) {
                    SortedList<int,int> tmp = new SortedList<int, int>(new DescendingKeyComparer<int>());
                    for (int j = 0 ; j < alreadyAdded.Values.Count; j++) {
                        a = numbers.Values[i];
                        b = alreadyAdded.Values[j];
                        
                        for (int k = a ; b + k < totalValueOfShares + 1 ; k = k + a) {
                            int c = b + k;
                            if (1 + job[c-a] < job[c] || job[c] == -1) {
                                job[c] = 1 + job[c-a];
                                try {
                                    tmp.Add(c,c);
                                } catch (System.ArgumentException) {

                                }
                            }
                        }
                    }
                    for (int j = 0 ; j < tmp.Values.Count ; j++) {
                        try {
                            alreadyAdded.Add(tmp.Values[j], tmp.Values[j]);
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
    }

}