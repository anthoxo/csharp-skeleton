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
                List<int> tmp = listK.GetRange(i, k);
                int n = tmp[k-1];
                for (int j = n ; j < this.graph.nbNodes; j++) {
                    bool pred = true;
                    for (int l = 0 ; l < tmp.Count && pred; l++) {
                        if (this.graph.GetEdge(tmp[l], j) == 1 || tmp[l] == j) {
                            pred = false;
                        }
                    }
                    if (pred) {
                        tmp.Add(j);
                        result.AddRange(tmp);
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
                    List<int> tmp = stables.GetRange(i, this.k);
                    int b = 0;
                    for (int j = 0 ; j < this.graph.nbNodes ; j++) {
                        if (!tmp.Contains(j)) {
                            bool pred = false;
                            for (int l = 0 ; l < tmp.Count && !pred; l++) {
                                if (this.graph.GetEdge(tmp[l], j) == 1) { 
                                    b += 1;
                                    pred = true;
                                }
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