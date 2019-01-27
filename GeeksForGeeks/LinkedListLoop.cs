using System;
using System.Collections.Generic;

namespace CSExtended.CodeChallenge
{

    public class LinkedListLoop
    {

        public bool CheckLinkedListForLoops(LinkedListNode<char> rootNode)
        {

            //while this works, its more efficient to use a dictionary add the keys.

            if (rootNode != null)
            {
                LinkedListNode<char> currentRoot = rootNode;
                LinkedListNode<char> currentPos;
                while (currentRoot != null)
                {
                    currentPos = currentRoot.Next;
                    while (currentPos != null)
                    {
                        if (currentRoot.Value == currentPos.Value)
                        {
                            return true;
                        }
                        else
                        {
                            currentPos = currentPos.Next;
                        }
                    }
                    currentRoot = currentRoot.Next;

                }
            }

            return false;

        }

        public void TestLinkedListLoop() {

            LinkedList<char> charLinkedList = new LinkedList<char>();
            charLinkedList.AddLast('A');
            charLinkedList.AddLast('B');
            charLinkedList.AddLast('C');
            charLinkedList.AddLast('D');

            bool hasLoop = this.CheckLinkedListForLoops(charLinkedList.First);
            Console.WriteLine("List with no loops hasLopps= {0}", hasLoop);

            charLinkedList = new LinkedList<char>();
            charLinkedList.AddLast('A');
            charLinkedList.AddLast('B');
            charLinkedList.AddLast('C');
            charLinkedList.AddLast('D');
            charLinkedList.AddLast('C');
            charLinkedList.AddLast('E');

            hasLoop = this.CheckLinkedListForLoops(charLinkedList.First);
            Console.WriteLine("List with a loops hasLopps= {0}", hasLoop);


        }

    }
}



