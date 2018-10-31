using System;
using System.Linq;
using C_Sharp_Challenge_Skeleton.Beans;
using System.Collections.Generic;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    class Solution2 {
        Graph2 graph;
        int k;
        int sizeTmp;
        int size;
        public Solution2(Graph2 g) {
            this.graph = g;
            this.k = 0;
        }
        public int[] RunK(int[] listK, int k) {
            int n1 = this.graph.nbNodes * this.sizeTmp;
            int[] result = new int[n1];
            int s = 0;
            for (int i = 0 ; i < this.sizeTmp ; i = i + k) {
                int n = listK[i+k-1] + 1;
                for (int j = n ; j < this.graph.nbNodes; j += 1) {
                    for (int l = i ; l < i + k; l += 1) {
                        if (this.graph.GetEdge(listK[l], j) == 1) {
                            goto bruh;
                        }
                    }
                    for (int l = i ; l < i + k ; ++l) {
                        result[s + (l - i)] = listK[l];
                    }
                    result[s + k] = j;
                    s += (k+1);
                    bruh:
                        continue;
                }
            }
            this.sizeTmp = s;
            return result;
        }
        public int[] FindStables() {
            int[] result = null;
            if (this.graph.nbNodes != 0) {
                result = new int[this.graph.nbNodes];
                for (int i = 0 ; i < this.graph.nbNodes ; ++i) {
                    result[i] = i;
                }
                this.sizeTmp = this.graph.nbNodes;
                this.size = this.sizeTmp;
                this.k = 0;
                int[] tmp = result;
                do {
                    this.size = this.sizeTmp;
                    this.k += 1;
                    result = tmp;
                    tmp = this.RunK(result, this.k);
                } while (this.sizeTmp != 0);
            }
            return result;
        }

        public int FindSolution() {
            int[] stables = this.FindStables();
            int n = this.size;
            if (n == 0) {
                return 0;
            } else {
                int a = 0;
                for (int i = 0 ; i < n ; i = i + this.k) {
                    int b = 0;
                    for (int j = 0 ; j < this.graph.nbNodes ; ++j) {
                        for (int l = i ; l < i + this.k; ++l) {
                            int t = stables[l];
                            if (t == j) {
                                break;
                            } else if (this.graph.GetEdge(t, j) == 1) { 
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
    class Solution {
        Graph2 graph;
        int k;
        int sizeTmp;
        int ptr;
        int size;
        int[] stables;
        int max;
        public Solution(Graph2 g) {
            this.graph = g;
            this.k = 0;
            this.max = 1000;
            this.stables = new int[this.max];
        }
        public int[] RunK(int k) {
            int s = 0;
            int ptr = this.ptr;
            for (int i = 0 ; i < this.sizeTmp ; i = i + k) {
                int n = this.stables[(ptr + i + k - 1)%this.max] + 1;
                for (int j = n ; j < this.graph.nbNodes; ++j) {
                    for (int l = i ; l < i + k; ++l) {
                        if (this.graph.GetEdge(this.stables[(ptr + l)%this.max], j) == 1) {
                            goto bruh;
                        }
                    }
                    for (int l = i ; l < i + k ; ++l) {
                        this.stables[(ptr + this.sizeTmp + s + (l - i))%this.max] = this.stables[(ptr + l)%this.max];
                    }
                    stables[(ptr + this.sizeTmp + s + k)%this.max] = j;
                    s += (k+1);
                    bruh:
                        continue;
                }
            }
            this.ptr = (this.ptr + this.sizeTmp)%this.max; 
            this.sizeTmp = s;
            return stables;
        }
        public void FindStables() {
            if (this.graph.nbNodes != 0) {
                for (int i = 0 ; i < this.graph.nbNodes ; ++i) {
                    this.stables[i] = i;
                }
                this.sizeTmp = this.graph.nbNodes;
                this.size = this.sizeTmp;
                this.ptr = 0;
                this.k = 0;
                int[] tmp = stables;
                do {
                    this.size = this.sizeTmp;
                    this.k += 1;
                    stables = tmp;
                    tmp = this.RunK(this.k);
                } while (this.sizeTmp != 0 && this.k != this.graph.nbNodes);
            }
        }

        public int FindSolution() {
            this.FindStables();
            int n = this.size;
            int ptr = this.ptr;
            if (n == 0) {
                return 0;
            } else {
                int a = 0;
                for (int i = 0 ; i < n ; i = i + this.k) {
                    int b = 0;
                    for (int j = 0 ; j < this.graph.nbNodes ; ++j) {
                        for (int l = i ; l < i + this.k; ++l) {
                            int t = this.stables[ptr + l];
                            if (t == j) {
                                break;
                            } else if (this.graph.GetEdge(t, j) == 1) { 
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
            if (numOfNodes == 1) {
                return 1;
            }
            int n2 = numOfNodes * numOfNodes;
            int[] edges = new int[n2];
            foreach(Edge t in edgeLists) {
                int a = t.EdgeA - 1 ;
                int b = t.EdgeB - 1;
                edges[a * numOfNodes + b] = 1;
                edges[b * numOfNodes + a] = 1;
            }            
            Graph2 g = new Graph2(numOfNodes, edges);
            Solution solution = new Solution(g);
            return solution.FindSolution();
        }
        public static int Answer2(int numOfNodes, Edge[] edgeLists)
        {
            if (numOfNodes == 1) {
                return 1;
            }
            int n2 = numOfNodes * numOfNodes;
            int[] edges = new int[n2];
            foreach(Edge t in edgeLists) {
                int a = t.EdgeA - 1 ;
                int b = t.EdgeB - 1;
                edges[a * numOfNodes + b] = 1;
                edges[b * numOfNodes + a] = 1;
            }            
            Graph2 g = new Graph2(numOfNodes, edges);
            Solution2 solution = new Solution2(g);
            return solution.FindSolution();
        }
    }
}