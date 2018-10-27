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
        public List<List<int>> edges {
            get;
        }
        public Graph() {
            this.nbNodes = 0;
            this.edges = new List<List<int>>();
        }
        public Graph(int nbNodes, List<List<int>> edges) {
            this.nbNodes = nbNodes;
            this.edges = edges;
        }

        public List<int> GetNodes(int i) {
            return this.edges[i];
        }

        public int GetEdge(int i, int j) {
            return this.edges[i][j];
        }
        public void AddNode() {
            List<int> tmp = new List<int>();
            for (int i = 0 ; i < this.nbNodes ; i++) {
                tmp.Add(-1);
            } 
            this.nbNodes += 1;
            this.edges.Add(tmp);
            for (int k = 0 ; k < this.nbNodes ; k++) {
                this.edges[k].Add(-1);
            }
        }

        public void AddEdge(int i, int j, int value) {
            if ((i > this.nbNodes && j > this.nbNodes) || i == j) {

            } else {
                if (i == this.nbNodes || j == this.nbNodes) {
                    this.AddNode();
                }
                this.edges[i][j] = value;
                this.edges[j][i] = value;
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
        List<int> alreadySeen;
        List<Data> notSeen;
        int finalNode;
        public Dijkstra(Graph graph, int finalNode) {
            this.graph = graph;
            this.alreadySeen = new List<int>();
            this.notSeen = new List<Data>();
            this.finalNode = finalNode;
            this.InitValues();
        }
        public void InitValues() {
            List<int> t = new List<int>();
            this.notSeen.Add(new Data(0, 0));
            this.alreadySeen.Add(int.MaxValue-1);
            for (int i = 1 ; i < this.graph.nbNodes ; i++) {
                this.notSeen.Add(new Data(i, int.MaxValue - 1));
                this.alreadySeen.Add(int.MaxValue-1);
            }
        }
        public int FindIndexMin() {
            int r = 0;
            int m = int.MaxValue - 2;
            for (int i = 0 ; i < this.notSeen.Count ; i++) {
                if (this.notSeen[i].v < m) {
                    r = i;
                    m = this.notSeen[i].v;
                }
            }
            return r;
        }

        public void majDistance(int indice, int s2, int d1, int d2) {
            if (d2 > d1) {
                this.notSeen[indice] = new Data(s2, d1);
            }
        }

        public int StepDijkstra() {
            int ind = this.FindIndexMin();
            Data f1 = this.notSeen[ind];
            int d1 = f1.v;
            this.alreadySeen[f1.k] = d1;
            this.notSeen.RemoveAt(ind);
            if (f1.k != this.finalNode) {
                for (int i = 0 ; i < this.notSeen.Count ; i++) {
                    Data f2 = this.notSeen[i];
                    int edge = this.graph.GetEdge(f1.k, f2.k);
                    if (edge != -1) {
                        this.majDistance(i, f2.k, f1.v + edge, f2.v);
                    }
                }
            }
            return f1.k;
        }
        public int StartDijkstra() {
            int ind = 0;
            while(ind != this.finalNode) {
                ind = this.StepDijkstra();
            }
            return this.alreadySeen[ind];
        }
    }
    public class Question6
    {
        public static int Answer(int numOfServers, int targetServer, int[,] connectionTimeMatrix)
        {
            //TODO: Please work out the solution;
            List<List<int>> edges = new List<List<int>>();
            for (int i = 0 ; i < numOfServers ; i++) {
                List<int> tmpList = new List<int>();
                for (int j = 0 ; j < numOfServers ; j++) {
                    tmpList.Add(connectionTimeMatrix[i, j]);
                }
                edges.Add(tmpList);
            }
            Graph g = new Graph(numOfServers, edges);
            Dijkstra dijkstra = new Dijkstra(g, targetServer);
            int result = dijkstra.StartDijkstra();
            return result;
        }
    }
}