public class Week_3
{
    public static bool IsValidSudoku(char[][] board)
    {

        //...............Initialization.............
        HashSet<char>[] rows = new HashSet<char>[9];
        HashSet<char>[] cols = new HashSet<char>[9];
        HashSet<char>[][] subgrid = new HashSet<char>[3][];


        for (int i = 0; i < 9; i++)
        {
            rows[i] = new HashSet<char>();
            cols[i] = new HashSet<char>();
        }
        for (int i = 0; i < 3; i++)
        {
            subgrid[i] = new HashSet<char>[3];
            for (int j = 0; j < 3; j++)
            {
                subgrid[i][j] = new HashSet<char>();
            }
        }


        //...............

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (board[i][j] != '.')
                {
                    if (rows[i].Contains(board[i][j]))
                    {
                        return false;
                    }
                    else
                    {
                        rows[i].Add(board[i][j]);
                    }
                }
                if (board[j][i] != '.')
                {
                    if (cols[i].Contains(board[j][i]))
                    {
                        return false;
                    }
                    else
                    {
                        cols[i].Add(board[j][i]);
                    }
                }
                if (board[i][j] != '.')
                {
                    if (subgrid[i / 3][j / 3].Contains(board[i][j]))
                    {
                        return false;
                    }
                    else
                    {
                        subgrid[i / 3][j / 3].Add(board[i][j]);
                    }
                }

            }
        }

        return true; // placeholder
    }
    public static int SubarraySum(int[] nums, int k)
    {
        var prefixSumCount = new Dictionary<int, int>();
        prefixSumCount[0] = 1;

        int sum = 0, count = 0;

        foreach (int num in nums)
        {
            sum += num;

            if (prefixSumCount.ContainsKey(sum - k))
            {
                count += prefixSumCount[sum - k];
            }

            if (prefixSumCount.ContainsKey(sum))
                prefixSumCount[sum]++;
            else
                prefixSumCount[sum] = 1;
        }

        return count;
    }
    public static List<List<string>> GroupAnagrams(string[] strs)
    {
        // Implement your logic here
        Dictionary<string, List<string>> anagramMap = new Dictionary<string, List<string>>();

        //eat tea tan

        foreach (var str in strs)
        {
            char[] sortedCharArray = str.ToCharArray();
            Array.Sort(sortedCharArray);
            string sortedStr = new string(sortedCharArray);

            if (!anagramMap.ContainsKey(sortedStr))
            {
                anagramMap.Add(sortedStr, new List<string>());
            }

            anagramMap[sortedStr].Add(str);

        }

        return anagramMap.Values.ToList(); // placeholder
    }

    public class RangeSumQueryImmutable
    {
        int[] nums;
        public RangeSumQueryImmutable(int[] nums)
        {
            // Implement your logic here

            this.nums = new int[nums.Length];
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum = sum + nums[i];
                this.nums[i] = sum;
            }

        }

        public int SumRange(int left, int right)
        {
            // Implement your logic here

            if (left == 0) return this.nums[right];
            else
                return this.nums[right] - this.nums[left - 1];

        }
    }


}