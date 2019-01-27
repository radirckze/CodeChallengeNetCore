using System;

namespace CSExtended.CodeChallenge {

    //problem: http://practice.geeksforgeeks.org/problems/maximum-sum-rectangle/0

    //Approach: starting from top left, for each square: 1 - find the max possible
    //dimentions; 2- for each possible dimention, find the sum; 3 - compare to ...

    public class MaxSumRectangle {

        public int FindMaxSumRectangle(int[,] rectangle) {
            if (rectangle == null) {
                throw new ArgumentException();
            }

            int numRows = rectangle.GetLength(0);
            int numCols = rectangle.GetLength(1);
            int maxSum = Int32.MinValue;
            int maxRowInd=0, maxColInd=0, maxRecSize=0; //the rectangle

            for (int i=0; i<numRows; i++) {
                for (int j=0; j<numCols; j++) {

                    //for starting point i,j, calculate sum of all possible rectagles
                    int maxPossibleRecSize = 0; //given i.j, the max rectangle size
                    if (numRows-i <= numCols-j) {
                        maxPossibleRecSize = numRows-i;
                    }
                    else {
                        maxPossibleRecSize = numCols-j;
                    }

                    int k = 0;
                    for(k=0; k<maxPossibleRecSize; k++) {
                        int currRecSum = 0;
                        for(int l=0; l<=k; l++) {
                            for(int m=0; m<=k; m++) {
                                currRecSum += rectangle[i+l, j+m];
                            }
                            
                        }

                        if (currRecSum > maxSum) {
                            maxSum = currRecSum;
                            maxRowInd = i;
                            maxColInd = j;
                            maxRecSize = k+1; //0 index
                        }
                    }

                }
            }

            Console.WriteLine("MaxSum={0}, MaxRow={1}, MaxCol={2}, Rectangle Size={3}",
                maxSum, maxRowInd, maxColInd, maxRecSize); 

            return maxSum;
        }


        //Add test cases
        public void RunTestCases() {
           // throw new NotImplementedException();
            int[,] rectangle = null;
            // test case from site. ***Note, result is 20, NOT 29. 
            rectangle = new int[,] {{1, 2,-1, 4, -20 },  {-8, -3, 4, 2, 1},
                                    {3, 8, 10, -8, 3}, {-4, -1, 1, 7, -6}}; 

            int result = this.FindMaxSumRectangle(rectangle);
            Console.WriteLine("First test status = {0}. Result={1}", result==20, result);

            //Need to add one more test where max-rectangle is completely inside.
        }



    }
}