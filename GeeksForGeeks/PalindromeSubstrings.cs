using System;

namespace CSExtended.CodeChallenge {

    //approach: for the string, for all possible substring combinatons, check whether 
    //the substring is a palindrome.

    public class PalindromeSubstrings {

        //take all possible sub-stings and chec if it is a palindrome.
        public int FindPalindromeSubstrings(string theString) {
            int paliSubs = 0;
            if (theString == null || theString.Length < 2) {
                return paliSubs;
            }

            for(int i=0; i<theString.Length-1; i++) {
                for(int j=i+1; j<theString.Length; j++) {
                    if (this.IsPalindrome(theString, i, j)) {
                        paliSubs++;
                    }
                }
            }

            return paliSubs;
        }

        //compare if range is plindrome. 
        private bool IsPalindrome(string theString, int from, int to) {
           int start=from;
           int end=to;
           while(start<end) {
               if (theString[start] != theString[end]){
                   return false;
               }
               start++;
               end--;
           }
           return true;
        }

        public void TestPaliSubstring() {

            
            Console.WriteLine("Number of palindrome in a null string: {0}", 
                this.FindPalindromeSubstrings(null));

            Console.WriteLine("Number of palindrome in abaab: {0}", 
                this.FindPalindromeSubstrings("abaab"));

            Console.WriteLine("Number of palindrome in abbaeae: {0}", 
                this.FindPalindromeSubstrings("abbaeae"));
            
        }
    }


}