using System.Collections.Generic;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question4
    {
        public static int Answer(string[,] machineToBeFixed, int numOfConsecutiveMachines)
        {
            int result = -1;
            for (int i = 0 ; i < machineToBeFixed.GetLength(0) ; i++) {
                List<int> tmp = new List<int>();
                for (int j = 0 ; j < machineToBeFixed.GetLength(1) ; j++) {
                    if (machineToBeFixed[i, j] == "X") {
                        tmp.RemoveAll(_ => true);
                    } else {
                        tmp.Add(int.Parse(machineToBeFixed[i, j]));
                        if (tmp.Count == numOfConsecutiveMachines) {
                            int r = 0;
                            tmp.ForEach(t => r += t);
                            result = (result == -1 || r < result) ? r : result;
                            tmp.RemoveAt(0);
                        }
                    }
                }
            }
            return (result == -1) ? 0 : result;
        }
    }
}