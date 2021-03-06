﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Trees
{
    /* METHODS NEEDED
     * [x] 1. ADD
     * [] 2. Contains
     */
   

    public class BinarySearchTree<T> : BinaryTree<T> where T : IComparable<T>
    {
                                      // ADD METHOD
        public void Add(T valueToBeAdded)
        {

            // Set New Node
            Node newNode = new Node();
            newNode.Value = valueToBeAdded;

            if (Root == null) Root = newNode;
            else
            {
                // Set current node to root
                Node current = Root;
                // Set initial node to parent node
                Node parentNode; 

                while(true)
                {
                    parentNode = current; 
                    if(valueToBeAdded.CompareTo(current.Value) < 0)
                    {
                        current = current.Left;
                        //check if current is null
                        if(current == null)
                        {
                            parentNode.Left = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.Right; 
                        if(current == null)
                        {
                            parentNode.Right = newNode;
                            return;
                        }
                    }

                }


                
            }
        }
        public bool Contains(Node root, T value)
        {

            while (root != null)
            {
                if (root.Value.Equals(value)) return true;
                else if (root.Value.CompareTo(value) > 0)
                {
                    return Contains(root.Left, value);
                }
                else return Contains(root.Right, value);
            }
            return false;
        }


        public IEnumerable<T> GetMaxValue()
        // Short way = return InOrder().Max();
        // reduce
        // return InOrder().Aggregate(max,next) => max > next ? max : next);
        {
            if (Root == null) throw new Exception("Root is Null");


            Queues<Node> nodeQueue = new Queues<Node>();
            T max = Root.Value;
            Node current = nodeQueue.Dequeue();
            if (current.Value.CompareTo(max) > 0)
            {
                max = current.Value;
            }
            if (current.Left != null) nodeQueue.Enqueue(current.Left);

            if (current.Right != null) nodeQueue.Enqueue(current.Right);


            yield return max;
        }

    }
}
