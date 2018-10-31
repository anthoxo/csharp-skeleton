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
                int zbeub = n - 4;
                i = 0;
                foreach(int p in portfolios) {
                    for (j = i + 1 ; j < zbeub ; j += 5) {
                        if (answer < (p ^ portfolios[j])){
                            answer = p ^ portfolios[j];
                        }
                        if (answer < (p ^ portfolios[j+1])){
                            answer = p ^ portfolios[j+1];
                        }
                        if (answer < (p ^ portfolios[j+2])){
                            answer = p ^ portfolios[j+2];
                        }
                        if (answer < (p ^ portfolios[j+3])){
                            answer = p ^ portfolios[j+3];
                        }
                        if (answer < (p ^ portfolios[j+4])){
                            answer = p ^ portfolios[j+4];
                        }
                    }
                    while (j < n) {
                        if (answer < (p ^ portfolios[j])){
                            answer = p ^ portfolios[j];
                        }
                        j += 1;
                    }
                    i += 1;
                }
                return answer;
            }
        }
        public static int Answer2(int[] portfolios)
        {
            int n = portfolios.Length;
            if (n < 2) {
                return 0;
            } else {
                int i,j;
                int answer = 0;
                int zbeub = n - 4;
                i = 0;
                foreach(int p in portfolios) {
                    for (j = i + 1 ; j < zbeub ; j += 5) {
                        int t1 = p ^ portfolios[j];
                        int t2 = p ^ portfolios[j+1];
                        int t3 = p ^ portfolios[j+2];
                        int t4 = p ^ portfolios[j+3];
                        int t5 = p ^ portfolios[j+4];
                        if (answer < t1){
                            answer = t1;
                        }
                        if (answer < t2){
                            answer = t2;
                        }
                        if (answer < t3){
                            answer = t3;
                        }
                        if (answer < t4){
                            answer = t4;
                        }
                        if (answer < t5){
                            answer = t5;
                        }
                    }
                    while (j < n) {
                        int t6 = p ^ portfolios[j];
                        if (answer < t6){
                            answer = t6;
                        }
                        j += 1;
                    }
                    i += 1;
                }
                return answer;
            }
        }

    //     int n = portfolios.Length;
    //     int n1 = n-1;
    //     int n5 = n-4;
    //     if(n < 2)
    //         return 0;
    //     int ans = 0;
    //     for(int i = 0; i<n1; ++i){
    //         int p = portfolios[i];
    //         int j = i+1;
    //         for(j=i+1; j<n5; j+=5){
    //             if( (p^portfolios[j]) > ans){ans =  p^portfolios[j];}
    //             if( (p^portfolios[j+1]) > ans){ans =  p^portfolios[j+1];}
    //             if( (p^portfolios[j+2]) > ans){ans =  p^portfolios[j+2];}
    //             if( (p^portfolios[j+3]) > ans){ans =  p^portfolios[j+3];}
    //             if( (p^portfolios[j+4]) > ans){ans =  p^portfolios[j+4];}
    //         }
    //         while(j<n){
    //             if((p^portfolios[j]) > ans){ans =  p^portfolios[j];}
    //             j++;
    //         }
    //     }
    //     return ans;
    // }



    }
}
