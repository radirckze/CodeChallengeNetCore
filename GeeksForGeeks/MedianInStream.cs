using System;
using System.Collections.Generic;

namespace CSExtended.CodeChallenge {

    //Problem source: http://practice.geeksforgeeks.org/problems/find-median-in-a-stream/0

    //Simple algorith. Using a private list. When adding things will be added in sorted
    //order. So finding median is easy and you can retrieve it by index.

    public class MedianInStream {

        private List<int> streamList = new List<int>();

        public int AddToStreamList(int nextInt) {
            //add to soted List
            int currPos = 0;
            while(currPos < streamList.Count && nextInt < streamList[currPos]) {
                currPos++;
            } 
            streamList.Insert(currPos, nextInt);

            bool oddLength = streamList.Count % 2 == 1? true:false;
            int mid = streamList.Count/2;
            if (oddLength) {
                return streamList[mid];
            }
            else {
                return (streamList[mid-1] + streamList[mid])/2;
            }

        }

        public void TestMedianInStream() {

            Console.WriteLine("Added {0}, median is {1}", 5, this.AddToStreamList(5));
            Console.WriteLine("Added {0}, median is {1}", 15, this.AddToStreamList(15));
            Console.WriteLine("Added {0}, median is {1}", 1, this.AddToStreamList(1));
            Console.WriteLine("Added {0}, median is {1}", 3, this.AddToStreamList(3));
            Console.WriteLine("Added {0}, median is {1}", 5, this.AddToStreamList(5));
            Console.WriteLine("Added {0}, median is {1}", 20, this.AddToStreamList(20));
        }

    }
}