using System.Collections.Generic;
using System;
using System.Linq;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question5
    {
        public static int Answer2(int[] numOfShares, int totalValueOfShares)
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
        public static int Answer(int[] numOfShares, int totalValueOfShares)
        {
            if (totalValueOfShares < 1 || numOfShares == null || numOfShares.Length == 0) {
                return 0;
            } else {
                int max = 10000;
                int[] bruh = new int[totalValueOfShares + 1];
                for (int i = 0 ; i < totalValueOfShares + 1 ; ++i) {
                    bruh[i] = max;
                }
                bruh[0] = 0;
                int n = numOfShares.Length;
                if (n > 50) {
                    numOfShares = (new HashSet<int>(numOfShares)).ToArray();
                    n = numOfShares.Length;
                }
                for (int i = 0 ; i < n ; ++i) {
                    int number = numOfShares[i];
                    if (number > 0) {
                        for (int k = number ; k < totalValueOfShares + 1 ; ++k) {
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
    }
}