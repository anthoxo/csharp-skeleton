using System.Collections.Generic;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question4
    {
        public static int Answer(string[,] machineToBeFixed, int numOfConsecutiveMachines)
        {
            int result = -1;
            int sumTmp = 0;
            for (int i = 0 ; i < machineToBeFixed.GetLength(0) ; i++) {
                List<int> tmp = new List<int>();
                for (int j = 0 ; j < machineToBeFixed.GetLength(1) ; j++) {
                    if (machineToBeFixed[i, j] == "X") {
                        tmp = new List<int>();
                        sumTmp = 0;
                    } else {
                        int a = int.Parse(machineToBeFixed[i, j]);
                        sumTmp += a;
                        tmp.Add(a);
                        if (tmp.Count == numOfConsecutiveMachines) {
                            if (result == -1 || sumTmp < result) {
                                result = sumTmp;
                            }
                            sumTmp -= tmp[0];
                            tmp.RemoveAt(0);
                        }
                    }
                }
            }
            return (result == -1) ? 0 : result;
        }
    }
}