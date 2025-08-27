public class Week_4
{

    public static IList<int> FindAnagrams(string s, string p)
    {
        List<int> result = new List<int>();
        if (s.Length < p.Length) return result;

        int[] expectedFreq = new int[26];
        int[] windowFreq = new int[26];
        int m = p.Length;

        foreach (char c in p) expectedFreq[c - 'a']++;

        // Initialize first window
        for (int i = 0; i < m; i++)
            windowFreq[s[i] - 'a']++;

        // Check first window
        if (Enumerable.SequenceEqual(windowFreq, expectedFreq))
            result.Add(0);

        // Slide window
        for (int i = m; i < s.Length; i++)
        {
            windowFreq[s[i] - 'a']++;       // add new char
            windowFreq[s[i - m] - 'a']--;   // remove old char

            if (Enumerable.SequenceEqual(windowFreq, expectedFreq))
                result.Add(i - m + 1);
        }

        return result;
    }

    public static int CharacterReplacement(string s, int k)
    {
        int[] freq = new int[26];
        int maxFreq = 0;  // Max frequency of any single character in current window
        int left = 0;
        int maxLen = 0;

        for (int right = 0; right < s.Length; right++)
        {
            freq[s[right] - 'A']++;
            maxFreq = Math.Max(maxFreq, freq[s[right] - 'A']);

            // If the number of chars to change > k, shrink the window from left
            if ((right - left + 1) - maxFreq > k)
            {
                freq[s[left] - 'A']--;
                left++;
            }

            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }
    public static int LengthOfLongestSubstring(string s)
    {
        // TODO: Implement the logic here

        int[] freq = new int[26]; // Only for lowercase 'a' to 'z'
        int left = 0;
        int maxLen = 0;

        for (int right = 0; right < s.Length; right++)
        {
            freq[s[right] - 'a']++;

            // Shrink the window until the current character has freq 1
            while (freq[s[right] - 'a'] > 1)
            {
                freq[s[left] - 'a']--;
                left++;
            }

            maxLen = Math.Max(maxLen, right - left + 1);
        }

        return maxLen;
    }

}