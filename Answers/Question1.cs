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
            //TODO: Please work out the solution;
            int i,j;
            int n = portfolios.Length;
            int answer = 0;
            for (i = 0 ; i < n ; i++) {
                for (j = i + 1 ; j < n ; j++) {
                    int t = portfolios[i] ^ portfolios[j];
                    if (answer < t){
                        answer = t;
                    }
                }
            }
            return answer;
        }
    }
}
