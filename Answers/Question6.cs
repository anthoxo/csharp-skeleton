using System;
using System.Collections;
using System.Collections.Generic;

namespace C_Sharp_Challenge_Skeleton.Answers
{
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
                this.edges[i].Insert(j, value);
                this.edges[j].Insert(i, value);
            }
        }

    }
    class Dijkstra {
        public Graph graph;
        List<bool> alreadySeen;
        List<int> distance;
        int finalNode;

        public Dijkstra() {
            this.graph = new Graph();
            this.alreadySeen = new List<bool>();
            this.distance = new List<int>();
        }
        public Dijkstra(Graph graph, int finalNode) {
            this.graph = graph;
            this.alreadySeen = new List<bool>();
            this.distance = new List<int>();
            this.finalNode = finalNode;
            this.InitValues();
        }

        public void InitValues() {
            for (int i = 0 ; i < this.graph.nbNodes ; i++) {
                this.distance.Add(-1);
                this.alreadySeen.Add(false);
            }
            this.distance[0] = 0;
        }
        public int FindIndexMin() {
            int r = -1;
            int m = -1;
            for (int i = 0 ; i < this.graph.nbNodes ; i++) {
                int d = this.distance[i];
                if (d != -1 && !(this.alreadySeen[i])) {
                    if (m == -1) {
                        r = i;
                        m = d;
                    } else if (d < m) {
                        r = i;
                        m = d;
                    }
                }
            }
            return r;
        }

        public void majDistance(int s1, int s2) {
            int edge = this.graph.GetEdge(s1, s2);
            int d2 = this.distance[s2];
            int d1 = this.distance[s1];
            if (edge != -1) {
                if (d2 == -1 || d2 > d1 + edge) {
                    this.distance.Insert(s2, d1 + edge);
                }
            }
        }

        public void StepDijkstra() {
            int ind = this.FindIndexMin();
            this.alreadySeen.Insert(ind, true);
            if (ind != this.finalNode) {
                for (int i = 0 ; i < this.graph.nbNodes ; i++) {
                    if (!(this.alreadySeen[i])) {
                        this.majDistance(ind, i);
                    }
                }
            }
        }
        public int StartDijkstra() {
            while(!(this.alreadySeen[this.finalNode])) {
                this.StepDijkstra();
            }
            return this.distance[this.finalNode];
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
            g = null;
            dijkstra = null;
            edges = null;
            return result;
        }
    }

        public class Question6Bis
    {
        public static int Answer(int numOfServers, int targetServer, int[,] connectionTimeMatrix)
        {
            //TODO: Please work out the solution;
            if(numOfServers == 0 || numOfServers > connectionTimeMatrix.GetLength(0)) {
              return -1;
            }
            List<int> visited = new List<int>();
            return lengthPath(targetServer, connectionTimeMatrix, connectionTimeMatrix[targetServer, 0], visited);
        }

        public static int lengthPath(int startingNode, int[,] graph, int minValue, List<int> visited)
        {
          for(int i = 0; i < graph.GetLength(0); i++) {
            graph[i, i] = 1000000;
          }
          if(startingNode == 0) {
            return 0;
          }
          visited.Add(startingNode);
          List<int> availableNodes = new List<int>();
          for(int i = 0; i < graph.GetLength(0); i++) {
            if(!availableNodes.Contains(i) && graph[startingNode, i] <= minValue) {
              availableNodes.Add(i);
            }
          }
          foreach(int node in availableNodes) {
            minValue = Math.Min(minValue, graph[startingNode, node] + lengthPath(node, graph, minValue, visited));
          }
          return minValue;
        }
    }


}