public class Week_1
{
    // Finds all unique triplets in the array which sum to zero
    public static List<List<int>> ThreeSum(int[] nums)
    {
        List<List<int>> triplets = new List<List<int>>();

        // Sort the array to make two-pointer approach possible and handle duplicates
        Array.Sort(nums);

        // Iterate through the array, treating each number as the first element of a potential triplet
        for (int j = 0; j < nums.Length - 2; j++)
        {
            int a = nums[j];

            // Skip duplicate values for the first element to avoid duplicate triplets
            if (j > 0 && nums[j] == nums[j - 1]) continue;

            int left = j + 1, right = nums.Length - 1;

            // Use two-pointer technique to find pairs that sum with 'a' to zero
            while (left < right)
            {
                // If the sum of nums[left] and nums[right] equals -a, we found a valid triplet
                if (nums[left] + nums[right] == -a)
                {
                    triplets.Add(new List<int> { a, nums[left], nums[right] });

                    // Skip duplicate values for the second element
                    while (left < right && nums[left] == nums[left + 1])
                        left += 1;
                    // Skip duplicate values for the third element
                    while (left < right && nums[right] == nums[right - 1])
                        right -= 1;

                    // Move both pointers inward after finding a valid triplet
                    left++;
                    right--;
                    continue;
                }
                // If the sum is less than -a, move the left pointer to increase the sum
                else if (nums[left] + nums[right] < -a)
                {
                    left++;
                }
                // If the sum is greater than -a, move the right pointer to decrease the sum
                else
                    right--;
            }
        }

        // Return the list of found triplets
        return triplets;
    }

    public static void MoveZeroes(int[] nums)
    {
        // put your function here

        int slow = 0, fast = 0;
        while (fast != nums.Length)
        {
            if (nums[fast] != 0)
            {
                int temp = nums[fast];
                nums[fast] = nums[slow];
                nums[slow] = temp;
                slow++;
            }
            fast++;
        }

    }


    //...................Linked List............

    static int CountNodes(ListNode head)
    {

        // Initialize count with 0
        int count = 0;

        // Initialize curr with head of Linked List
        ListNode curr = head;

        // Traverse till we reach null
        while (curr != null)
        {
            // Increment count by 1
            count++;

            // Move pointer to next node
            curr = curr.next;
        }

        // Return the count of nodes
        return count;
    }

    public static ListNode FindMiddle(ListNode head)
    {

        int middle = CountNodes(head) / 2;

        for (int i = 0; i < middle; i++)
        {
            head = head.next;
        }

        return head;
    }

    internal static ListNode FindMiddle_TwoPointer(ListNode head)
    {
        ListNode slow = head, fast = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        return slow;
    }
    public static bool HasCycle(ListNode head)
    {
        // put your function here


        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
            if (slow == fast)
                return true;
        }
        return false;
    }

    public static ListNode ReverseList(ListNode head)
    {
        ListNode FirstPtr = null;
        ListNode CurrentPtr = head;
        ListNode SecondPtr = null;

        while (CurrentPtr != null)
        {
            SecondPtr = CurrentPtr.next;
            CurrentPtr.next = FirstPtr;
            FirstPtr = CurrentPtr;
            CurrentPtr = SecondPtr;
        }
        return FirstPtr;
    }

    public static void PrintList(ListNode head)
    {
        while (head != null)
        {
            Console.Write(head.val);
            if (head.next != null) Console.Write(" ");
            head = head.next;
        }
        Console.WriteLine();
    }



}
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; next = null; }
}