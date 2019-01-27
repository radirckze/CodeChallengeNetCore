using System;
using System.Collections.Generic;


namespace CSExtended.CodeChallenge {

    //problem source: N-Queen: http://practice.geeksforgeeks.org/problems/n-queen-problem/0

    //Approach: Useing a sudo-constraint proramming style approach. 
    //For each column on the row 0, mark that as a valid position. 
    //    for each row starting at rwo 1
    //        For each column on row
    //            if it is a valid position, add it to the valid positions and break; 
    //If there are N valid placements then we found valid result. 
    //Constraint programming: ValidatePos checks that the queen placement constraints
    //are not violated.

    public class NQueen {

        private bool ValidatePos(List<int[]> placements, int row, int col) {
            int rowDiff=0, colDiff=0;

            foreach(int[] placement in placements) {
                rowDiff = Math.Abs(placement[0] - row);
                colDiff = Math.Abs(placement[1] - col);
                if (rowDiff ==0 || colDiff == 0 || rowDiff == colDiff) {
                    return false;
                }
            }

            return true;
        }

        public List<List<int[]>> PlaceQueens(int boardSize) {

            List<List<int[]>> validPlacements = new List<List<int[]>>();

            List<int[]> placements = null;
            for(int i=0; i<boardSize; i++) {
                placements = new List<int[]>();
                placements.Add(new int[] {0,i});

                for (int j = 1; j<boardSize; j++) {
                    for (int k = 0; k<boardSize; k++) {
                        if (this.ValidatePos(placements, j, k)) {
                            placements.Add(new int[] {j, k});
                            break; //you cannot place another on this row
                        }
                    }
                }

                if (placements.Count == boardSize) {
                    validPlacements.Add(placements);
                }
            }

            return validPlacements;
        }

        private void PrintPlacements(List<List<int[]>> placements) {
            foreach(List<int[]> placement in placements) {
                Console.Write("Valid Placement: ");
                foreach(int[] point in placement) {
                    Console.Write("[{0},{1}], ", point[0]+1, point[1]+1);//1-base counting
                }
                Console.WriteLine();
            }
        }

        public void TestNQueen(){

            List<List<int[]>> validPlacements = null;
            //test the 1X1 case
            validPlacements = this.PlaceQueens(1);
            Console.WriteLine("# of valid placements for a {0}X{0} board are: {1} ", 1, validPlacements.Count);
            if (validPlacements.Count > 0) {
                this.PrintPlacements(validPlacements);
            }
             //test the 1X1 case
            validPlacements = this.PlaceQueens(2);
            Console.WriteLine("# of valid placements for a {0}X{0} board are: {1}", 2, validPlacements.Count);
            if (validPlacements.Count > 0) {
                this.PrintPlacements(validPlacements);
            }
             //test the 1X1 case
            validPlacements = this.PlaceQueens(4);
            Console.WriteLine("# of valid placements for a {0}X{0} board are: {1}", 4, validPlacements.Count);
            if (validPlacements.Count > 0) {
                this.PrintPlacements(validPlacements);
            }


        }

    }

}