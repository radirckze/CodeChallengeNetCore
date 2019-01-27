using System;
using System.Collections.Generic;

namespace CSExtended.CodeChallenge {

    //Problem source: http://practice.geeksforgeeks.org/problems/travelling-salesman-problem/0
    
    //Approach: from the start as the current-city, recursively find the min path from 
    //the current-city back to start such that each city that has not been visited 
    //(i.e., not in visited), is visited first. 
    // At each stage return just the minimum distance needed to get to start. 
    
    public class TravelingSalesman {

        public int FindMinPath(int[,] graph, int start) {

            if (graph == null) {
                throw new ArgumentException();
            }
           
           int numCities = graph.GetLength(0);
           return MinPath(graph, start, start, numCities, new List<int>() {start} );
           
        }

        //recursively find the min path from current city back to start such that
        //each city that has not been visited yet (not in visited), is visited first. 
        private int MinPath(int[,]graph, int start, int currCity, int numCities, 
        List<int> visited) {

            // if all cities are visited. return distance from current city to starting point.
            if (visited.Count == numCities) {
                return graph[currCity, start];
            }

            int minPathDistance = -1;
            int minPathCity = 0;
            for(int i=0; i<numCities; i++) {
                if (!visited.Contains(i)) {
                    visited.Add(i);
                    int theDistance = MinPath(graph, start, i, numCities, visited);
                    if (minPathDistance ==-1 || theDistance < minPathDistance) {
                        minPathDistance = theDistance;
                        minPathCity = i;
                    }
                    visited.Remove(i);
                }
            }

            return minPathDistance + graph[currCity, minPathCity];
        }

        public void TestTravelingSalesman() {

            int[,] graph = null;
             //null check - throws argument exception.
            
            graph = new int[,] {{0, 111}, {112, 0}};
            int minPath = this.FindMinPath(graph, 0);
            Console.WriteLine("Status of first test is {0}", minPath==223);

            graph = new int[,] {{0,1000,5000}, {5000,0,1000}, {1000,5000,0}};
            minPath = this.FindMinPath(graph, 0);
            Console.WriteLine("Status of second test is {0}", minPath==3000);

        }


    }

}