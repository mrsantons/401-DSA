﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DataStructures.GraphImplementation
{
    public class Graph<T>
    {
        Dictionary<T, Dictionary<T, int>> Nodes;
        // First we need to create an empty graph 
        public Graph()
        {
            //how I am storing the edges
            Nodes = new Dictionary<T, Dictionary<T, int>>();
        }
        //Add Node
        public bool AddNode(T value)
        {
            if (Nodes.ContainsKey(value)) return false;

            Nodes.Add(value, new Dictionary<T, int>());
            return true;
        }
        //Add Edge requirements- value of first node being connected, 
        //value of second node being connected, 
        //weight of edge defaulting at 1,
        //directional path default is false
        public bool AddEdge(T firstNodeValue, T secondNodeValue, int weight = 1, bool oneWay = false)
        {
            //if the edge does not contain either value return false
            if (!Nodes.ContainsKey(firstNodeValue) || !Nodes.ContainsKey(secondNodeValue)) return false;
            //set up the nodes
            // https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.collectionextensions.getvalueordefault?view=netcore-3.1
            Dictionary<T, int> nodeOne = Nodes[firstNodeValue];
            Dictionary<T, int> nodeTwo = Nodes[secondNodeValue];

            //Check if it contains the key
            if (nodeOne.ContainsKey(firstNodeValue)) return false;

            if (!oneWay && !firstNodeValue.Equals(secondNodeValue))
            {
                if (nodeTwo.ContainsKey(firstNodeValue)) return false;
                nodeTwo.Add(firstNodeValue, weight);
            }


            nodeOne.Add(secondNodeValue, weight);
            return true;
        }
        //GetNodes
        public List<T> GetNodes()
        {
            if (Nodes.Keys.Count < 1) return null;
            return Nodes.Keys.ToList();
        }
        //GetNeighbors
        public Dictionary<T, int> GetNeighbors(T value)
        {
            if (!Nodes.ContainsKey(value)) return null;

            return Nodes[value];
        }
        //Size
        public int Size()
        {
            return Nodes.Keys.Count;
        }
        //Breadth-First Search
        //T value is the Root node that the search will start with
        public List<T> BreadthFirstTraversal(T value)
        {
            //check if the root contains the key
            if (!Nodes.ContainsKey(value)) return null;
            //Now we will create a boolean to check if we have visited the node
            Dictionary<T, bool> visited = new Dictionary<T, bool>();
            visited.Add(value, true);
            //Since we have an input we will need an list of the outputs. These are the nodes we have visited. 
            List<T> output = new List<T> { value };
            //creation of the queue we will need
            Queue<List<T>> breadthTraversal = new Queue<List<T>>();
            breadthTraversal.Enqueue(
                Nodes.GetValueOrDefault(value).Keys.ToList()
            );
            //next we need a while loop to check if the node is visited or not
            while (breadthTraversal.TryDequeue(out List<T> neighbors))
            {
                foreach (T node in neighbors)
                {
                    if (!visited.ContainsKey(node))
                    {
                        visited.Add(node, true);
                        output.Add(node);
                        breadthTraversal.Enqueue(
                            Nodes.GetValueOrDefault(node).Keys.ToList()
                        );
                     

                        //change the boolean to true now that the node is visited

                        //Add the node to the output list

                        //the we will traverse each neighbor node
                        //enqueue the neighbors

                    }
                    
               
                }
            }
            //Finally what we all have been waiting for the output of the traversal!
            return output;
        }
    }
}
