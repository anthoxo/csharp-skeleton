﻿using System;
using C_Sharp_Challenge_Skeleton.Beans;
using System.Collections.Generic;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    class Solution2 {
        Graph graph;

        int k;

        int sizeTmp;
        int size;
        public Solution2(Graph g) {
            this.graph = g;
            this.k = 0;
        }
        public int[] RunK(int[] listK, int k) {
            int[] result = new int[this.graph.nbNodes * this.sizeTmp];
            int s = 0;
            for (int i = 0 ; i < this.sizeTmp ; i = i + k) {
                int n = listK[i+k-1];
                for (int j = n ; j < this.graph.nbNodes; j++) {
                    bool pred = true;
                    int i_plus_k = i+k;
                    for (int l = i ; l < i_plus_k; l++) {
                        if (this.graph.GetEdge(listK[l], j) == 1 || listK[l] == j) {
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
    public class Question3
    {
        public static int Answer(int numOfNodes, Edge[] edgeLists)
        {
            int n2 = numOfNodes * numOfNodes;
            int[] edges = new int[n2];
            for (int i = 0 ; i < edgeLists.Length ; i++) {
                Edge t = edgeLists[i];
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
            int[,] edges = new int[numOfNodes, numOfNodes];
            for (int i = 0 ; i < numOfNodes ; i++) {
                for (int j = 0 ; j < numOfNodes ; j++) {
                    edges[i,j] = -1;
                }
            }
            for (int i = 0 ; i < edgeLists.Length ; i++) {
                Edge t = edgeLists[i];
                int a = t.EdgeA - 1 ;
                int b = t.EdgeB - 1;
                edges[a, b] = 1;
                edges[b, a] = 1;
            }
            Graph g = new Graph(numOfNodes, edges);
            Solution2 solution = new Solution2(g);
            return solution.FindSolution();
        }
    }
}