using System.Collections.Generic;
using System.Linq;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question4
    {
        public static int Answer(string[,] machineToBeFixed, int numOfConsecutiveMachines)
        {
            int result = int.MaxValue - 1;
            int sumTmp = 0;
            for (int i = 0 ; i < machineToBeFixed.GetLength(0) ; i++) {
                List<int> tmp = new List<int>();
                for (int j = 0 ; j < machineToBeFixed.GetLength(1) ; j++) {
                    if (machineToBeFixed[i, j] == "X") {
                        tmp.RemoveAll(t => true);
                        sumTmp = 0;
                        
                    } else {
                        int a = int.Parse(machineToBeFixed[i, j]);
                        sumTmp += a;
                        tmp.Add(a);
                        if (tmp.Count == numOfConsecutiveMachines) {
                            if (sumTmp < result) {
                                result = sumTmp;
                            }
                            sumTmp -= tmp[0];
                            tmp.RemoveAt(0);
                        }
                    }
                }
            }
            return (result == int.MaxValue - 1) ? 0 : result;
        }
    }
}