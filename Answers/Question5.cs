using System.Collections.Generic;
using System;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question5
    {
        public static int Answer(int[] numOfShares, int totalValueOfShares)
        {
            Console.WriteLine("Ex : " + totalValueOfShares);
            if (numOfShares.Length == 0) {
                return 0;
            } else {
                List<int> job = new List<int>();
                SortedList<int, int> numbers = new SortedList<int, int>(new DescendingKeyComparer<int>());
                SortedList<int, int> alreadyAdded = new SortedList<int, int>(new DescendingKeyComparer<int>());

                int a;
                int b;

                for (int i = 0 ; i < numOfShares.Length ; i++) {
                    job.Add(int.MaxValue - 1);
                    numbers.Add(numOfShares[i], numOfShares[i]);
                }
                for (int i = numOfShares.Length ; i < totalValueOfShares + 1 ; i++) {
                    job.Add(int.MaxValue - 1);
                }
                job[0] = 0;
                alreadyAdded.Add(0, 0); 
                bool stop = false;
                for (int i = 0 ; i < numbers.Values.Count && !stop ; i++) {
                    SortedList<int,int> tmp = new SortedList<int, int>(new DescendingKeyComparer<int>());
                    for (int j = 0 ; j < alreadyAdded.Values.Count && !stop; j++) {
                        a = numbers.Values[i];
                        b = alreadyAdded.Values[j];
                        for (int k = 1 ; b + a * k < totalValueOfShares + 1 ; k++) {
                            if (1 + job[b+a*(k-1)] < job[b+a*k]) {
                                job[b+a*k] = 1 + job[b+a*(k-1)];
                                try {
                                    tmp.Add(b+a*k,b+a*k);
                                } catch (System.ArgumentException _) {

                                }
                            }
                            if (b + a * k == totalValueOfShares) {
                                stop = true;
                            }
                        }
                    }
                    // Console.WriteLine("alreadyAdded : " + numbers.Values[i]);
                    // foreach (KeyValuePair<int, int> kvp in alreadyAdded) {
                    //     Console.WriteLine(kvp.Key + "," + kvp.Value);
                    // }

                    // Console.WriteLine("tmp");
                    // foreach (KeyValuePair<int, int> kvp in tmp) {
                    //     Console.WriteLine(kvp.Key + "," + kvp.Value);
                    // }
                    for (int j = 0 ; j < tmp.Values.Count ; j++) {
                        try {
                            alreadyAdded.Add(tmp.Values[j], tmp.Values[j]);
                        } catch (System.ArgumentException _) {

                        } 
                    }
                }
                if (job[totalValueOfShares] == int.MaxValue - 1) {
                    return 0;
                } else {
                    return job[totalValueOfShares];
                }
            }
        }
    }

}