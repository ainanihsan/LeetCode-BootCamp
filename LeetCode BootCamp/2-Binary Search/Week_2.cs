
public class Week_2
{
    // How should the boundary variables left and right be initialized?
    // Should we use left < right or left <= right as the exit condition in our while-loop?
    // How should the boundary variables be updated? Should we choose left = mid,
    // left = mid + 1, right = mid, or right = mid - 1 ?

    private static int totalCount = 0;

    // Finds the index where target should be inserted in a sorted list.
    public static int SearchInsertPosition(List<int> nums, int target)
    {
        int left = 0;
        int right = nums.Count;

        // Binary search for insert position
        while (left < right)
        {
            int mid = (left + right) / 2;

            if (nums[mid] < target)    // Move left boundary if mid value is less than target
                left = mid + 1;
            else                      // Otherwise, move right boundary
                right = mid;
        }
        return left;
    }

    // Finds the leftmost (first) index of target in a sorted array.
    public static int LeftBound(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        // Binary search for left bound
        while (left < right)
        {
            int mid = (left + right) / 2;

            if (nums[mid] < target)         // Move left boundary if mid value is less than target
                left = mid + 1;
            else if (nums[mid] > target)    // Move right boundary if mid value is greater than target
                right = mid - 1;
            else                            // Narrow right boundary to mid if mid value equals target
                right = mid;
        }

        // Check if left index is target
        if (nums != null && nums[left] == target)
            return left;
        else
            return -1;
    }

    // Finds the rightmost (last) index of target in a sorted array.
    public static int RightBound(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        // Binary search for right bound
        while (left < right)
        {
            int mid = (left + (right - left) / 2) + 1;

            if (nums[mid] < target)         // Move left boundary if mid value is less than target
                left = mid + 1;
            else if (nums[mid] > target)    // Move right boundary if mid value is greater than target
                right = mid - 1;
            else                            // Narrow left boundary to mid if mid value equals target
                left = mid;
        }

        // Check if right index is target
        if (nums != null && nums[right] == target)
            return right;
        else
            return -1;
    }

    // Returns the starting and ending position of a given target value.
    public static int[] SearchRange(int[] nums, int target)
    {
        int leftbound = LeftBound(nums, target);
        int rightbound = RightBound(nums, target);

        return new int[] { leftbound, rightbound };
    }

    // Checks if it is possible to cut at least k ribbons of length x.
    static bool isPossible(int[] ribbons, int x, int k)
    {
        totalCount = 0;
        for (int i = 0; i < ribbons.Length; i++)
        {
            // Count how many ribbons of length x can be cut from each ribbon
            totalCount += (ribbons[i] / x);
        }
        // Return true if totalCount is at least k
        if (totalCount >= k)
            return true;
        else
            return false;
    }

    // Finds the maximum length to cut at least k ribbons using binary search.
    public static int MaxLength(int[] ribbons, int k)
    {
        int left = 1;
        int right = ribbons.Max();

        // Binary search for maximum possible ribbon length
        while (left < right)
        {
            int mid = (left + right + 1) / 2;

            if (isPossible(ribbons, mid, k))    // If possible, try longer length
                left = mid;
            else                                // Otherwise, try shorter length
                right = mid - 1;
        }
        // Return left if possible, otherwise 0
        return isPossible(ribbons, left, k) ? left : 0;
    }

    // Finds a peak element in the array and returns its index.
    // A peak element is one that is greater than its neighbors.
    // Uses binary search for O(log n) time complexity.
    public static int FindPeakElement(int[] nums)
    {
        int left = 0;
        int right = nums.Length - 1;

        // Binary search for peak element
        while (left <= right)
        {
            int mid = (left + right) / 2;
            // Check if mid is not at the boundary
            if (right - left >= 1 && mid != 0)
            {
                // If mid is greater than both neighbors, it's a peak
                if (nums[mid] > nums[mid - 1] && nums[mid] > nums[mid + 1])
                {
                    return mid;
                }
                // If left neighbor is greater, move to left half
                else if (nums[mid] < nums[mid - 1])
                    right = mid - 1;
                // If right neighbor is greater, move to right half
                else if (nums[mid] < nums[mid + 1])
                    left = mid + 1;
            }
            else
                // If only one element left, return its index
                return mid;
        }

        return -1; // No peak found (should not happen for valid input)
    }


    // Searches for a target value in a rotated sorted array.
    // Returns the index if found, otherwise returns -1.
    // Uses binary search for O(log n) time complexity.
    public static int Search(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        // Binary search in rotated sorted array
        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (nums[mid] == target)
                return mid;

            // Check if left half is sorted
            if (nums[left] <= nums[mid])
            {
                // Target is in the left half
                if (nums[left] <= target && target < nums[mid])
                    right = mid - 1;
                else
                    left = mid + 1;  // Target is in the right half
            }
            // Right half is sorted
            else
            {
                // Target is in the right half
                if (nums[mid] < target && target <= nums[right])
                    left = mid + 1;
                else
                    right = mid - 1; // Target is in the left half
            }
        }

        return -1; // Target not found
    }

}