using System;
using C_Sharp_Challenge_Skeleton.Beans;
using System.Collections.Generic;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    class Solution {
        Graph2 graph;
        int k;
        int sizeTmp;
        int size;
        public Solution(Graph2 g) {
            this.graph = g;
            this.k = 0;
        }
        public int[] RunK(int[] listK, int k) {
            int[] result = new int[this.graph.nbNodes * this.sizeTmp];
            int s = 0;
            for (int i = 0 ; i < this.sizeTmp ; i = i + k) {
                int n = listK[i+k-1] + 1;
                for (int j = n ; j < this.graph.nbNodes; j++) {
                    bool pred = true;
                    int i_plus_k = i + k;
                    for (int l = i ; l < i_plus_k; l++) {
                        if (this.graph.GetEdge(listK[l], j) == 1) {
                            pred = false;
                            break;
                        }
                    }
                    if (pred) {
                        for (int l = i ; l < i_plus_k ; l++) {
                            result[s + (l - i)] = listK[l];
                        }
                        result[s + k] = j;
                        s += (k+1);
                    }
                }
            }
            this.sizeTmp = s;
            return result;
        }
        public int[] FindStables() {
            int[] result = null;
            if (this.graph.nbNodes != 0) {
                result = new int[this.graph.nbNodes];
                for (int i = 0; i < this.graph.nbNodes ; i++) {
                    result[i] = i;
                }
                this.sizeTmp = this.graph.nbNodes;
                this.size = this.sizeTmp;
                this.k = 0;
                int[] tmp = result;
                while (this.sizeTmp != 0) {
                    this.size = this.sizeTmp;
                    this.k += 1;
                    result = tmp;
                    // Console.WriteLine("Itération : " + k + ", taille : " + this.size);
                    // for (int i = 0 ; i < this.size ; i++) {
                    //     Console.Write(result[i] + ",");
                    // }
                    // Console.WriteLine();
                    tmp = this.RunK(result, this.k);
                }
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
                    for (int j = 0 ; j < this.graph.nbNodes ; j++) {
                        for (int l = i ; l < i + this.k; l++) {
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
    class Solution2 {
        Graph2 graph;
        int k;
        int sizeTmp;
        int size;
        int[] iterGraphNode;
        public Solution2(Graph2 g) {
            this.graph = g;
            this.k = 0;
            this.iterGraphNode = new int[this.graph.nbNodes];
        }
        public int[] RunK(int[] listK, int k) {
            int[] result = new int[this.graph.nbNodes * this.sizeTmp];
            int s = 0;
            for (int i = 0 ; i < this.sizeTmp ; i = i + k) {
                int n = listK[i+k-1] + 1;
                for (int j = n ; j < this.graph.nbNodes; j = j + 1) {
                    bool pred = true;
                    int[] iter = new int[k];
                    int l = i;
                    int i_plus_k = i + k;
                    foreach(int _ in iter) {
                        if (this.graph.GetEdge(listK[l], j) == 1) {
                            pred = false;
                            break;
                        }
                        l += 1;
                    }
                    if (pred) {
                        l = i;
                        foreach(int _ in iter) {
                            result[s + (l - i)] = listK[l];
                            l += 1;
                        }
                        result[s + k] = j;
                        s += (k+1);
                    }
                }
            }
            this.sizeTmp = s;
            return result;
        }
        public int[] FindStables() {
            int[] result = null;
            if (this.graph.nbNodes != 0) {
                result = new int[this.graph.nbNodes];
                int i = 0;
                foreach(int _ in this.iterGraphNode) {
                    result[i] = i;
                    i += 1;
                }
                this.sizeTmp = this.graph.nbNodes;
                this.size = this.sizeTmp;
                this.k = 0;
                int[] tmp = result;
                while (this.sizeTmp != 0) {
                    this.size = this.sizeTmp;
                    this.k += 1;
                    result = tmp;
                    // Console.WriteLine("Itération : " + k + ", taille : " + this.size);
                    // for (int i = 0 ; i < this.size ; i++) {
                    //     Console.Write(result[i] + ",");
                    // }
                    // Console.WriteLine();
                    tmp = this.RunK(result, this.k);
                }
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
                    for (int j = 0 ; j < this.graph.nbNodes ; j++) {
                        for (int l = i ; l < i + this.k; l++) {
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