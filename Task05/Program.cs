using System;
using System.Collections.Generic;
using System.Linq;

namespace Task05
{
    /// <summary>
    /// Longest Palindrome
    /// https://leetcode.com/problems/longest-palindromic-substring/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
//            Console.WriteLine(new Program().Attempt1("badab"));
//            Console.WriteLine(new Program().Attempt1("xbadab"));
//            Console.WriteLine(new Program().Attempt1("cbbd"));
//            Console.WriteLine(new Program().Attempt1("babad"));
//            Console.WriteLine(new Program().Attempt1("cyyoacmjwjubfkzrrbvquqkwhsxvmytmjvbborrtoiyotobzjmohpadfrvmxuagbdczsjuekjrmcwyaovpiogspbslcppxojgbfxhtsxmecgqjfuvahzpgprscjwwutwoiksegfreortttdotgxbfkisyakejihfjnrdngkwjxeituomuhmeiesctywhryqtjimwjadhhymydlsmcpycfdzrjhstxddvoqprrjufvihjcsoseltpyuaywgiocfodtylluuikkqkbrdxgjhrqiselmwnpdzdmpsvbfimnoulayqgdiavdgeiilayrafxlgxxtoqskmtixhbyjikfmsmxwribfzeffccczwdwukubopsoxliagenzwkbiveiajfirzvngverrbcwqmryvckvhpiioccmaqoxgmbwenyeyhzhliusupmrgmrcvwmdnniipvztmtklihobbekkgeopgwipihadswbqhzyxqsdgekazdtnamwzbitwfwezhhqznipalmomanbyezapgpxtjhudlcsfqondoiojkqadacnhcgwkhaxmttfebqelkjfigglxjfqegxpcawhpihrxydprdgavxjygfhgpcylpvsfcizkfbqzdnmxdgsjcekvrhesykldgptbeasktkasyuevtxrcrxmiylrlclocldmiwhuizhuaiophykxskufgjbmcmzpogpmyerzovzhqusxzrjcwgsdpcienkizutedcwrmowwolekockvyukyvmeidhjvbkoortjbemevrsquwnjoaikhbkycvvcscyamffbjyvkqkyeavtlkxyrrnsmqohyyqxzgtjdavgwpsgpjhqzttukynonbnnkuqfxgaatpilrrxhcqhfyyextrvqzktcrtrsbimuokxqtsbfkrgoiznhiysfhzspkpvrhtewthpbafmzgchqpgfsuiddjkhnwchpleibavgmuivfiorpteflholmnxdwewj"));

//            Console.WriteLine(Attempt2("babad"));
//            Console.WriteLine(Attempt2("cyyoacmjwjubfkzrrbvquqkwhsxvmytmjvbborrtoiyotobzjmohpadfrvmxuagbdczsjuekjrmcwyaovpiogspbslcppxojgbfxhtsxmecgqjfuvahzpgprscjwwutwoiksegfreortttdotgxbfkisyakejihfjnrdngkwjxeituomuhmeiesctywhryqtjimwjadhhymydlsmcpycfdzrjhstxddvoqprrjufvihjcsoseltpyuaywgiocfodtylluuikkqkbrdxgjhrqiselmwnpdzdmpsvbfimnoulayqgdiavdgeiilayrafxlgxxtoqskmtixhbyjikfmsmxwribfzeffccczwdwukubopsoxliagenzwkbiveiajfirzvngverrbcwqmryvckvhpiioccmaqoxgmbwenyeyhzhliusupmrgmrcvwmdnniipvztmtklihobbekkgeopgwipihadswbqhzyxqsdgekazdtnamwzbitwfwezhhqznipalmomanbyezapgpxtjhudlcsfqondoiojkqadacnhcgwkhaxmttfebqelkjfigglxjfqegxpcawhpihrxydprdgavxjygfhgpcylpvsfcizkfbqzdnmxdgsjcekvrhesykldgptbeasktkasyuevtxrcrxmiylrlclocldmiwhuizhuaiophykxskufgjbmcmzpogpmyerzovzhqusxzrjcwgsdpcienkizutedcwrmowwolekockvyukyvmeidhjvbkoortjbemevrsquwnjoaikhbkycvvcscyamffbjyvkqkyeavtlkxyrrnsmqohyyqxzgtjdavgwpsgpjhqzttukynonbnnkuqfxgaatpilrrxhcqhfyyextrvqzktcrtrsbimuokxqtsbfkrgoiznhiysfhzspkpvrhtewthpbafmzgchqpgfsuiddjkhnwchpleibavgmuivfiorpteflholmnxdwewj"));
            Console.WriteLine(Attempt3("xabcdeedcbae"));
//            Console.WriteLine(Attempt3("xabbaa"));
//            Console.WriteLine(Attempt3("aacdecaa"));
//            Console.WriteLine(Attempt3("cyyoacmjwjubfkzrrbvquqkwhsxvmytmjvbborrtoiyotobzjmohpadfrvmxuagbdczsjuekjrmcwyaovpiogspbslcppxojgbfxhtsxmecgqjfuvahzpgprscjwwutwoiksegfreortttdotgxbfkisyakejihfjnrdngkwjxeituomuhmeiesctywhryqtjimwjadhhymydlsmcpycfdzrjhstxddvoqprrjufvihjcsoseltpyuaywgiocfodtylluuikkqkbrdxgjhrqiselmwnpdzdmpsvbfimnoulayqgdiavdgeiilayrafxlgxxtoqskmtixhbyjikfmsmxwribfzeffccczwdwukubopsoxliagenzwkbiveiajfirzvngverrbcwqmryvckvhpiioccmaqoxgmbwenyeyhzhliusupmrgmrcvwmdnniipvztmtklihobbekkgeopgwipihadswbqhzyxqsdgekazdtnamwzbitwfwezhhqznipalmomanbyezapgpxtjhudlcsfqondoiojkqadacnhcgwkhaxmttfebqelkjfigglxjfqegxpcawhpihrxydprdgavxjygfhgpcylpvsfcizkfbqzdnmxdgsjcekvrhesykldgptbeasktkasyuevtxrcrxmiylrlclocldmiwhuizhuaiophykxskufgjbmcmzpogpmyerzovzhqusxzrjcwgsdpcienkizutedcwrmowwolekockvyukyvmeidhjvbkoortjbemevrsquwnjoaikhbkycvvcscyamffbjyvkqkyeavtlkxyrrnsmqohyyqxzgtjdavgwpsgpjhqzttukynonbnnkuqfxgaatpilrrxhcqhfyyextrvqzktcrtrsbimuokxqtsbfkrgoiznhiysfhzspkpvrhtewthpbafmzgchqpgfsuiddjkhnwchpleibavgmuivfiorpteflholmnxdwewj"));
        }
        
        
        public static string Attempt3(string s)
        {
            var longest = 0;
            var start = 0;

            bool InRangeOdd(int i2, int gap2) => i2 - gap2 >= 0 && i2 + gap2 < s.Length;
            bool InRangeEven(int i1, int gap1) => i1 - gap1 >= 0 && i1 + 1 + gap1 < s.Length;

            for (int i = 0; i < s.Length - longest / 2; i++)
            {                 
                // odd                 
                var gap = 1; // gap means number of (non-repeating letters) on one side till center. E.g. for "abcba", gap is 3, where "c" is center and "abc" length is 3.     
                while (InRangeOdd(i, gap) && s[i - gap] == s[i + gap])
                {
                    gap++;
                }

                var newLongest = 1 + (gap - 1) * 2;
                if (longest < newLongest)
                {                     
                    longest = newLongest;                     
                    start = i - gap + 1;                 
                }                                  
                // even                 
                gap = 0;                 
                while (InRangeEven(i, gap) && s[i - gap] == s[i + 1 + gap])
                {
                    gap++;
                }

                if (longest < gap * 2)
                {                     
                    longest = gap*2;                     
                    start = i - gap + 1;                 
                }
            }

            return s.Substring(start, longest);
        }

        public static string Attempt2(string a)
        {
            var b = string.Concat(a.Reverse());
            var lengths = new int[a.Length, b.Length];
            int greatestLength = 0;
            string output = "";
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    {
                        lengths[i, j] = i == 0 || j == 0 ? 1 : lengths[i - 1, j - 1] + 1;
                        if (lengths[i, j] > greatestLength)
                        {
                            greatestLength = lengths[i, j];
                            output = a.Substring(i - greatestLength + 1, greatestLength);
                        }
                    }
                    else
                    {
                        lengths[i, j] = 0;
                    }
                }
            }
            return output;
        }
        
        public string Attempt1(string s) 
        {
            var list = new List<char>();
            var largest = "";
        
            foreach(char c in s.ToCharArray())
            {
                list.Add(c);
                
                var indexes = list
                    .Select((b,i) => b == c ? i : -1)
                    .Where(i => i != -1);
            
                foreach(var index in indexes)
                {
                    var range = list.GetRange(index, list.Count() - index);
                    var substring = (string) String.Concat(range);
                    var reverseSubstring = String.Concat(substring.Reverse());
                    if (largest.Length < substring.Length && reverseSubstring == substring) {
                        largest = substring;
                    }
                }
            }
        
            return largest;
        }
    }
}