namespace OccurenceFinder
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*

            Problem:
            t and z are strings consist of lowercase English letters.

            Find all substrings for t, and return the maximum value of [ len(substring) x [how many times the substring occurs in z] ]

            Example:
            t = acldm1labcdhsnd
            z = shabcdacasklksjabcdfueuabcdfhsndsabcdmdabcdfa

            Solution:
            abcd is a substring of t, and it occurs 5 times in Z, abcd.Length x 5 = 20 is the solution

            */


            string FindOccurrence(string substring, string mainString)
            {
                int maxScore = 0;

                for (int len = 1; len <= substring.Length; len++)
                {
                    for (int i = 0; i <= substring.Length - len; i++)
                    {
                        string pattern = substring.Substring(i, len);
                        int count = CountOccurrences(mainString, pattern);
                        int score = len * count;
                        maxScore = Math.Max(maxScore, score);
                    }
                }

                return maxScore.ToString();
            }

            int CountOccurrences(string source, string pattern)
            {
                int count = 0;
                int i = 0;
                while ((i = source.IndexOf(pattern, i, StringComparison.OrdinalIgnoreCase)) != -1)
                {
                    i += pattern.Length;
                    count++;
                }
                return count;
            }

            var substring = "acldm1labcdhsnd";
            var mainString = "shabcdacasklksjabcdfueuabcdfhsndsabcdmdabcdfa";

            Console.WriteLine(FindOccurrence(substring, mainString));

        }
    }

}