using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question1
    {
        public static int Answer(int[] portfolios)
        {
            int n = portfolios.Length;
            if (n < 2) {
                return 0;
            } else {
                int i,j;
                int answer = 0;
                i = 0;
                foreach(int p in portfolios) {
                    for (j = i + 1 ; j < n ; j += 1) {
                        int t = p ^ portfolios[j];
                        if (answer < t){
                            answer = t;
                        }
                    }
                    i += 1;
                }
                return answer;
            }
        }

    }
}
