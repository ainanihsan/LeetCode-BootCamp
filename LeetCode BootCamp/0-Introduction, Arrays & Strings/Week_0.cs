
class Week_0
{
    public static int StrStr(string haystack, string needle)
    {
        int index = 0;
        if (!String.IsNullOrEmpty(needle))
        {
            index = haystack.IndexOf(needle);
        }
        return index; 
    }

    public static string ReverseString(string s)
    {
        if (String.IsNullOrEmpty(s))
            return s;
        char[] c = s.ToCharArray();

        // Write your code here
        int left = 0;
        int right = c.Length - 1;
        for (left = 0; left < right; left++)
        {
            char temp = c[left];
            c[left] = c[right];
            c[right] = temp;
            right--;
        }
        return new string(c);
    }

    public static int RemoveDuplicates(int[] nums)
    {
        // Write your code here
        int index = 0, second_index = 1;
        while (second_index < nums.Length)
        {
            if (nums[index] != nums[second_index])
            {
                index++;
                nums[index] = nums[second_index];
            }
            second_index++;
        }
        return index + 1;
    }
    // Brute force solution
    public static int[] TwoSum(int[] nums, int target)
    {
        // Write your code here

        for (int i = 0; i < nums.Length; i++)
            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                    return new int[] { nums[i], nums[j] };
            }

        return new int[] { -1, -1 }; // placeholder
    }

    public static int[] TwoSum_TwoPointer(int[] nums, int target)
    {
        Array.Sort(nums);
        // Write your code here
        int left = 0, right = nums.Length - 1;
        int curr_sum = 0;
        while (left < right)
        {
            curr_sum = nums[left] + nums[right];
            if (curr_sum == target)
            {
                return new int[] { nums[left], nums[right] };
            }
            if (curr_sum > target)
            {
                right--;
            }
            else if (curr_sum < target)
            {
                left++;
            }
        }

        return new int[] { -1, -1 }; // placeholder
    }

}
