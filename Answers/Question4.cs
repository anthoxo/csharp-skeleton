using System.Collections.Generic;
using System.Linq;
using System;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class Question4
    {
        public static int Parse(string str) {
            int y = 0;
            int n = str.Length;
            for (int i = 0 ; i < n; i++) {
                y = y * 10 + (str[i] - '0');
            }
            return y;
        }
        public static int Answer(string[,] machineToBeFixed, int numOfConsecutiveMachines)
        {
            int m = machineToBeFixed.GetLength(1);
            if (m < numOfConsecutiveMachines) {
                return 0;
            } else {
                int result = int.MaxValue;
                int n = machineToBeFixed.GetLength(0);
                for (int i = 0 ; i < n ; i++) {
                    int lastX = -1;
                    int GODNESS = 0;
                    bool pred = false;
                    for (int j = 0 ; j < m ; j++) {
                        if (machineToBeFixed[i, j][0] == 'X') {
                            lastX = j;
                            GODNESS = 0;
                            pred = false;
                            if (m-j-1 < numOfConsecutiveMachines) {
                                break;
                            }
                        } else {
                            if (j - lastX == numOfConsecutiveMachines) {
                                if (pred) {
                                    GODNESS += Question4.Parse(machineToBeFixed[i, j]);
                                } else {
                                    for (int kk = 0 ; kk < numOfConsecutiveMachines ; ++kk) {
                                        GODNESS += Question4.Parse(machineToBeFixed[i, j - kk]);
                                    }
                                    pred = true;
                                }
                                if (GODNESS < result) {
                                    result = GODNESS;
                                }
                                lastX += 1;
                                GODNESS -= Question4.Parse(machineToBeFixed[i, lastX]);
                            }
                        }
                    }
                }
                return (result == int.MaxValue) ? 0 : result;
            }
        }
        public static int Answer2(string[,] machineToBeFixed, int numOfConsecutiveMachines)
        {
            int m = machineToBeFixed.GetLength(1);
            if (m < numOfConsecutiveMachines) {
                return 0;
            } else {
                int result = int.MaxValue;
                int n = machineToBeFixed.GetLength(0);
                for (int i = 0 ; i < n ; ++i) {
                    int lastX = -1;
                    int sumTmp = 0;
                    for (int j = 0 ; j < m ; ++j) {
                        if (machineToBeFixed[i, j][0] == 'X') {
                            lastX = j;
                            sumTmp = 0;
                            if (m-j-1 < numOfConsecutiveMachines) {
                                break;
                            }
                        } else {
                            int a = Question4.Parse(machineToBeFixed[i, j]);
                            sumTmp += a;
                            if (j - lastX == numOfConsecutiveMachines) {
                                if (sumTmp < result) {
                                    result = sumTmp;
                                }
                                lastX += 1;
                                sumTmp -= Question4.Parse(machineToBeFixed[i, lastX]);
                            }
                        }
                    }
                }
                if (result == int.MaxValue) {
                    return 0;
                } else {
                    return result;
                }
            }
        }
    }
}