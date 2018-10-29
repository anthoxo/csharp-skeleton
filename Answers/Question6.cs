using System;
using System.Collections;
using System.Collections.Generic;

namespace C_Sharp_Challenge_Skeleton.Answers
{
    public class DescendingKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable {
        #region IComparer<TKey> Members
        public int Compare(TKey x, TKey y) {
            int result = x.CompareTo(y);
            return -result;
        }
        #endregion
    }

    public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable {
        #region IComparer<TKey> Members
        public int Compare(TKey x, TKey y) {
            int result = x.CompareTo(y);
            if (result == 0)
                return 1;
            else
                return result;
        }
        #endregion
    }
    public class Graph {
        public int nbNodes {
            get;
            set;
        }
        public List<int> edges {
            get;
        }
        public Graph() {
            this.nbNodes = 0;
            this.edges = new List<int>();
        }
        public Graph(int nbNodes, List<int> edges) {
            this.nbNodes = nbNodes;
            this.edges = edges;
        }

        public int GetEdge(int i, int j) {
            return this.edges[i * this.nbNodes + j];
        }
        public void AddNode() {
            // à tester dans Test.cs
            for (int i = this.nbNodes - 1 ; i >= 0 ; i--) {
                this.edges.Insert(i * this.nbNodes + this.nbNodes, -1);
            }
            this.nbNodes += 1;
            for (int i = 0 ; i < this.nbNodes ; i++) {
                this.edges.Add(-1);
            }
        }

        public void AddEdge(int i, int j, int value) {
            if ((i > this.nbNodes && j > this.nbNodes) || i == j) {

            } else {
                if (i == this.nbNodes || j == this.nbNodes) {
                    this.AddNode();
                }
                this.edges[i * this.nbNodes + j] = value;
                this.edges[j * this.nbNodes + i] = value;
            }
        }
    }

    class Data {
        public int k {
            get;
            set;
        }
        public int v {
            get;
            set;
        }
        public Data(int k, int v) {
            this.k = k;
            this.v = v;
        }
    }
    class Dijkstra {
        public Graph graph;
        List<bool> alreadySeen;
        List<int> distance;
        int finalNode;
        
        public Dijkstra(Graph graph, int finalNode) {
            this.graph = graph;
            this.alreadySeen = new List<bool>();
            this.distance = new List<int>();
            this.finalNode = finalNode;
            this.InitValues();
        }
        public void InitValues() {
            List<int> t = new List<int>();
            this.distance.Add(0);
            this.alreadySeen.Add(false);
            for (int i = 1 ; i < this.graph.nbNodes ; i++) {
                this.distance.Add(int.MaxValue);
                this.alreadySeen.Add(false);
            }
        }
        public int FindIndexMin() {
            int r = 0;
            int m = int.MaxValue;
            for (int i = 0 ; i < this.graph.nbNodes ; i++) {
                if (!this.alreadySeen[i]) {
                    int t = this.distance[i];
                    if (t < m) {
                        r = i;
                        m = t;
                    }
                }
            }
            return r;
        }

        public void majDistance(int s1, int s2, int d1, int d2) {
            if (d2 > d1) {
                this.distance[s2] = d1;
            }
        }

        public int StepDijkstra() {
            int ind = this.FindIndexMin();
            this.alreadySeen[ind] = true;
            if (ind != this.finalNode) {
                for (int i = 0 ; i < this.graph.nbNodes ; i++) {
                    if (!this.alreadySeen[i]) {
                        int edge = this.graph.GetEdge(ind, i);
                        if (edge != -1) {
                            int d2 = this.distance[i];
                            int d1 = this.distance[ind] + edge;
                            this.majDistance(ind, i, d1, d2);
                        }
                    }  
                }
            }
            return ind;
        }
        public int StartDijkstra() {
            int ind = 0;
            while(ind != this.finalNode) {
                ind = this.StepDijkstra();
            }
            return this.distance[ind];
        }
    }
    public class Question6
    {
        public static int Answer(int numOfServers, int targetServer, int[,] connectionTimeMatrix)
        {
            //TODO: Please work out the solution;
            Console.WriteLine("Bonjour");
            Console.WriteLine("n : " + numOfServers);
            Console.WriteLine("targetServer : " + targetServer);
            Console.WriteLine("size of matrix : " + connectionTimeMatrix.GetLength(0) + "," + connectionTimeMatrix.GetLength(1));
            if (numOfServers < 2) {
                return 0;
            }
            List<int> edges = new List<int>();
            for (int i = 0 ; i < numOfServers ; i++) {
                for (int j = 0 ; j < numOfServers ; j++) {
                    edges.Add(connectionTimeMatrix[i, j]);
                }
            }
            Graph g = new Graph(numOfServers, edges);
            Dijkstra dijkstra = new Dijkstra(g, targetServer);
            int result = dijkstra.StartDijkstra();
            return result;
        }
    }
}