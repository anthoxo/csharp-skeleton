using System;
using C_Sharp_Challenge_Skeleton.Beans;
using System.Collections.Generic;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    class Solution {
        Graph graph;

        int k;
        public Solution(Graph g) {
            this.graph = g;
            this.k = 0;
        }

        public List<int> RunK(List<int> listK, int k) {
            List<int> result = new List<int>();
            for (int i = 0 ; i < listK.Count ; i = i + k) {
                int n = listK[i+k-1];
                for (int j = n ; j < this.graph.nbNodes; j++) {
                    bool pred = true;
                    for (int l = i ; l < i + k; l++) {
                        if (this.graph.GetEdge(listK[l], j) == 1 || listK[l] == j) {
                            pred = false;
                            break;
                        }
                    }
                    if (pred) {
                        for (int l = i ; l < i + k ; l++) {
                            result.Add(listK[l]);
                        }
                        result.Add(j);
                    }
                }
            }
            return result;
        }
        public List<int> FindStables() {
            List<int> result = new List<int>();
            if (this.graph.nbNodes != 0) {
                for (int i = 0; i < this.graph.nbNodes ; i++) {
                    result.Add(i);
                }
                this.k = 0;
                List<int> tmp = result;
                while (tmp.Count != 0) {
                    this.k += 1;
                    result = tmp;
                    tmp = this.RunK(result, this.k);
                }
            }
            return result;
        }

        public int FindSolution() {
            List<int> stables = this.FindStables();
            if (stables.Count == 0) {
                return 0;
            } else {
                int a = 0;
                for (int i = 0 ; i < stables.Count ; i = i + this.k) {
                    int b = 0;
                    for (int j = 0 ; j < this.graph.nbNodes ; j++) {
                        for (int l = i ; l < i + this.k; l++) {
                            if (stables[l] == j) {
                                break;
                            } else if (this.graph.GetEdge(stables[l], j) == 1) { 
                                b += 1;
                                break;
                            }
                        }
                    }
                    a = (a < this.k-b) ? this.k-b : a;
                }
                return a;
            }
        }
    }
    public class Question3
    {
        public static int Answer(int numOfNodes, Edge[] edgeLists)
        {
            Graph g = new Graph();
            for (int i = 0 ; i < numOfNodes ; i++) {
                g.AddNode();
            } 
            for (int i = 0 ; i < edgeLists.Length ; i++) {
                g.AddEdge(edgeLists[i].EdgeA-1, edgeLists[i].EdgeB-1, 1);
            }
            Solution solution = new Solution(g);
            return solution.FindSolution();
        }
    }
}