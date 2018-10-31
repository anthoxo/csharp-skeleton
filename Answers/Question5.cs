using System.Collections.Generic;
using System;
using System.Linq;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question5
    {
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
                if (n > 50) {
                    numOfShares = (new HashSet<int>(numOfShares)).ToArray();
                    n = numOfShares.Length;
                }
                for (int i = 0 ; i < n ; i++) {
                    int number = numOfShares[i];
                    if (number > 0) {
                        int k = number;
                        for(; k < totalValueOfShares + 1-4; k+=5){
                            if (bruh[k - number] + 1 < bruh[k]) {
                                bruh[k] = bruh[k - number] + 1;
                            }
                            if (bruh[k+1 - number] + 1 < bruh[k+1]) {
                                bruh[k+1] = bruh[k+1 - number] + 1;
                            }
                            if (bruh[k+2 - number] + 1 < bruh[k+2]) {
                                bruh[k+2] = bruh[k+2 - number] + 1;
                            }
                            if (bruh[k+3 - number] + 1 < bruh[k+3]) {
                                bruh[k+3] = bruh[k+3 - number] + 1;
                            }
                            if (bruh[k+4 - number] + 1 < bruh[k+4]) {
                                bruh[k+4] = bruh[k+4 - number] + 1;
                            }
                        }
                        while(k< totalValueOfShares + 1){
                            if (bruh[k - number] + 1 < bruh[k]) {
                                bruh[k] = bruh[k - number] + 1;
                            }
                            ++k;
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