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
    class Dijkstra {
        public Graph graph;
        SortedList<int, int> alreadySeen;
        SortedList<int,int> notSeen;
        int finalNode;
        public Dijkstra(Graph graph, int finalNode) {
            this.graph = graph;
            this.alreadySeen = new SortedList<int, int>();
            this.notSeen = new SortedList<int, int>(new DuplicateKeyComparer<int>());
            this.finalNode = finalNode;
            this.InitValues();
        }
        public void InitValues() {
            this.notSeen.Add(0, 0);
            for (int i = 1 ; i < this.graph.nbNodes ; i++) {
                this.notSeen.Add(int.MaxValue - 1, i);
            }
        }
        public int FindIndexMin() {
            return this.notSeen.Values[0];
        }

        public void majDistance(SortedList<int,int> list , int s1, int s2, int d1, int d2) {
            if (d2 > d1) {
                list.Add(d1,s2);
            } else {
                list.Add(d2, s2);
            }
        }

        public int StepDijkstra() {
            int ind = this.FindIndexMin();
            int d1 = this.notSeen.Keys[0];
            this.alreadySeen.Add(ind, d1);
            this.notSeen.RemoveAt(0);

            if (ind != this.finalNode) {
                SortedList<int, int> tmpNotSeen = new SortedList<int, int>(new DuplicateKeyComparer<int>());
                foreach(KeyValuePair<int,int> kvp in this.notSeen) {
                    int edge = this.graph.GetEdge(ind, kvp.Value);
                    if (edge != -1) {
                        this.majDistance(tmpNotSeen, ind, kvp.Value, d1 + edge, kvp.Key);
                    } else {
                        tmpNotSeen.Add(kvp.Key, kvp.Value);
                    }
                }
                this.notSeen = tmpNotSeen;
            }
            return ind;
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