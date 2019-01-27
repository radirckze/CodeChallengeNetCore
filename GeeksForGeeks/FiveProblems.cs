using System;
using System.Collections.Generic;

namespace CSExtended.CodeChallenge {

    //http://www.shiftedup.com/2015/05/07/five-programming-problems-every-software-engineer-should-be-able-to-solve-in-less-than-1-hour

    public class FiveProblems {

        public int SumNumbersInListFor(List<int> theList) {

            //no null or empty list check
            int theSum = 0;
            for(int i=0; i<theList.Count; i++) {
                theSum += theList[i];
            }

           return theSum;
        }

        public int SumNumbersInListWhile(List<int> theList) {

            //no null or empty list check
            int theSum = 0;
            int j=0;
            while(j < theList.Count) {
                theSum += theList[j];
                j++;
            }
            return theSum;

        }

        public int SumNumbersInListRecursive(List<int> theList, int currIndex) {
            if (theList == null) {
                return 0;
            }
            else if (currIndex == theList.Count-1) {
                return theList[currIndex];
            }
            else {
                return theList[currIndex] + SumNumbersInListRecursive(theList, currIndex+1);
            }
        }

        //assuming the lists are not null and that both lists have the same length
        public List<char> CombineTwoLists(List<char> list1, List<char> list2) {
            List<char> result = new List<char>();
            for (int i=0; i< list1.Count; i++) {
                result.Add(list1[i]);
                result.Add(list2[i]);
            }

            return result;
        }

        //assuming count is > 1. Sums the first 'count' finbonacci numbers.
        public int SumFibNumbers(int count=100) {
            //would be more elegant to do this with an array
            int prevFb = 0;
            int currFb = 1;
            int sum = 1;
            
            for(int i=0; i<count-2; i++) {
                int temp = currFb;
                currFb = prevFb + currFb;
                prevFb = temp;
                sum += currFb;
            }

            return sum;
        }

        // arrange list of integeres to form largest number.
        //assuming list contains at least 1 value 
        public string ArrangeToFromLargestNumber(List<int> numbers) {
            numbers.Sort(delegate(int x, int y) {
                string xStr = x.ToString();
                string yStr = y.ToString();
                return (yStr + xStr).CompareTo(xStr + yStr);
            });

            string arrangedStr = "";
            foreach(int num in numbers) {
                arrangedStr += num;
            }

            return arrangedStr;

        }
    }
}