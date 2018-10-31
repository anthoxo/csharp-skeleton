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
    }
}
