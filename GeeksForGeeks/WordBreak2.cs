using System;
using System.Collections.Generic;

namespace CSExtended.CodeChallenge {

    // Problem: http://practice.geeksforgeeks.org/problems/word-break-part-2/0

    public class WordBreak2 {

        // public List<string> GetWordStrings(string theString, string[] words) {
            
        //     //do null checks and all the good struff
        //     List<string> results = new List<string>();
        //     foreach(string word in words) {
        //         if (theString.IndexOf(word) == 0) {
        //             List<string> results4Word = new List<string>();
        //             string partialMatch = word;
        //             int start = word.Length;
        //             GetStrings4Word(theString, partialMatch, start, words,
        //                             results4Word);

        //             if 

        //         }
        //     }
        // }


        public void GetStrings4Word(string theString, 
                            string partialMatch, int start, 
                            string[] words, List<string> resultStrings) {

            if (start == theString.Length) {
                resultStrings.Add(partialMatch.Trim());
                return;
            }
            else if(start < theString.Length) {
                foreach(string word in words) {
                    if (theString.IndexOf(word, start) == start) {
                        //partialMatch = partialMatch + " " + word;
                        //start = start + word.Length;
                        GetStrings4Word(theString, partialMatch+ " " + word, 
                                start + word.Length, words, resultStrings);
                    }
                }

                return;
            }
            else {
                return;
            }
        }

        public void TestWordBreak2() {

            Console.WriteLine("Testing TestWordBreak-2");


            string theString = "snakesandladder";
            string[] words =  new string[] {"snake", "snakes", "and", "sand", "ladder"};

            List<string> result = new List<string>();
            this.GetStrings4Word(theString, "", 0, words, result);
            if (result.Count == 2 && 
                (result[0].Equals("snakes and ladder") && 
                result[1].Equals("snake sand ladder")) ||
                (result[0].Equals("snake sand ladder") && 
                result[1].Equals("snakes and ladder"))) 
            {
                Console.WriteLine(theString + " test passed");
            }
            else {
                Console.WriteLine(theString + " test failed");
            }

            //Other test cases           

            //words: lr m lrm hcdar wk
            //String hcdarlrm

            //Need to add a test case with multiple matches (thisisthis, 
            // words: this is this, and a case with no matches.)

            
            
        }

    }

}