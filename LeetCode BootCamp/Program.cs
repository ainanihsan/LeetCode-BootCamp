
using static Week_3;

Console.WriteLine(".............. WEEK 0 ............");
string haystack = "this is the needle haystack problem";
string needle = "needle";

int result = Week_0.StrStr(haystack, needle);
Console.WriteLine("Needle Haystack problem");
Console.WriteLine(result);

Console.WriteLine("Reverse string problem");
Console.WriteLine(Week_0.ReverseString("LeetCode Bootcamp"));

int[] nums = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
int[] nums2 = { -1, 0, 1, 2, -1, -4 };
int[] nums3 = { 0, 2, 3, 0, 4, 0, 3, 4 };
Console.WriteLine("Remove Duplicates problem");
Console.WriteLine(Week_0.RemoveDuplicates(nums));

Console.WriteLine("Two sum problem");
var indexes = Week_0.TwoSum(nums2, 3);
Console.WriteLine(indexes[0]);
Console.WriteLine(indexes[1]);
Console.WriteLine("Two sum problem - two pointer approach");
indexes = Week_0.TwoSum_TwoPointer(nums2, 3);
Console.WriteLine(indexes[0]);
Console.WriteLine(indexes[1]);

Console.WriteLine(".............. WEEK 1 ............");

var res = Week_1.ThreeSum(nums2);
Console.WriteLine("Three sum problem");
foreach (var triplet in res)
{
    Console.WriteLine($"{triplet[0]} {triplet[1]} {triplet[2]}");
}
Console.WriteLine("Moving zeros problem");
Week_1.MoveZeroes(nums3);
Console.WriteLine(string.Join(" ", nums3));

Console.WriteLine("Linked List - find middle problem");

ListNode head = null, tail = null;

for (int i = 0; i < nums.Length; i++)
{
    ListNode node = new ListNode(nums[i]);
    if (head == null) head = node;
    else tail.next = node;
    tail = node;
}

var mid = Week_1.FindMiddle(head);
Console.WriteLine(mid.val);
mid = Week_1.FindMiddle_TwoPointer(head);
Console.WriteLine(mid.val);

Console.WriteLine("Linked list - Has Cycle problem");
Console.WriteLine(Week_1.HasCycle(head));

Console.WriteLine("Linked List - reverse problem");

var reversed = Week_1.ReverseList(head);
Week_1.PrintList(reversed);

Console.WriteLine(".............. WEEK 2 ............");

Console.WriteLine("Search insert position problem");
Array.Sort(nums3);
List<int> numbers = new(nums3);
Console.WriteLine(Week_2.SearchInsertPosition(numbers, 3));

Console.WriteLine("First Last position number");
var bounds = Week_2.SearchRange(nums3, 3);
Console.WriteLine(bounds[0]);
Console.WriteLine(bounds[1]);

int[] ribbons = new int[] { 9, 7, 5, 3 };
Console.WriteLine("Cutting ribbons problem");
Console.WriteLine(Week_2.MaxLength(ribbons, 3));

Console.WriteLine("Peak finding problem");
Console.WriteLine(Week_2.FindPeakElement(ribbons));

int[] rotatedArray = new int[] { 4, 5, 6, 7, 0, 1, 2, 3 };

Console.WriteLine("Rotated search problem");
Console.WriteLine(Week_2.Search(rotatedArray, 3));

Console.WriteLine(".............. WEEK 3 ............");

char[][] sudoku = new char[][]
{
    new char[] {'5','3','.','.','7','.','.','.','.'},
    new char[] {'6','.','.','1','9','5','.','.','.'},
    new char[] {'.','9','8','.','.','.','.','6','.'},
    new char[] {'8','.','.','.','6','.','.','.','3'},
    new char[] {'4','.','.','8','.','3','.','.','1'},
    new char[] {'7','.','.','.','2','.','.','.','6'},
    new char[] {'.','6','.','.','.','.','2','8','.'},
    new char[] {'.','.','.','4','1','9','.','.','5'},
    new char[] {'.','.','.','.','8','.','.','7','9'}
};

Console.WriteLine("Is valid sudoku problem");
Console.WriteLine(Week_3.IsValidSudoku(sudoku));

Console.WriteLine("Subarray sum");
Console.WriteLine("Count: " + Week_3.SubarraySum(nums, 3));

string[] strings = { "abc", "acb", "def", "fde", "cba" };

Console.WriteLine("Group anagrams problem");
var anagrams = Week_3.GroupAnagrams(strings);
foreach (var group in anagrams)
{
    Console.WriteLine(string.Join(" ", group));
}
Console.WriteLine("Range query problem");
var obj = new RangeSumQueryImmutable(nums);
Console.WriteLine(obj.SumRange(1, 3));
Console.WriteLine(".............. WEEK 4 ............");

Console.WriteLine("Find anagrams in string problem");
var anagramresult = Week_4.FindAnagrams("abcdefabcdesrefabc","abc");
foreach (var group in anagramresult)
{
    Console.WriteLine($"Anagrams: {group}");
}

Console.WriteLine("Character replacement problem");
Console.WriteLine(Week_4.CharacterReplacement("AABBABA", 2));
Console.WriteLine("Length of longest substring problem");
Console.WriteLine(Week_4.LengthOfLongestSubstring("abcabcbb"));

Console.WriteLine(".............. WEEK 5 ............");

Console.WriteLine("Interval intersection problem");
int[][] intervals1 = new int[][]
{
    new int[] {0, 2},
    new int[] {5, 10},
    new int[] {13, 23},
    new int[] {24, 25}
};

int[][] intervals2 = new int[][]
{
    new int[] {1, 5},
    new int[] {8, 12},
    new int[] {15, 24},
    new int[] {25, 26}
};


var intervals = Week_5.IntervalIntersection(intervals1, intervals2);
foreach (var inter in intervals)
{
    Console.WriteLine(inter[0] + " " + inter[1]);
}
Console.WriteLine("Interval merge problem");


intervals = Week_5.Merge(intervals1);
foreach (var inter in intervals)
{
    Console.WriteLine(inter[0] + " " + inter[1]);
}

Console.WriteLine("Largest Overlap problem");
Console.WriteLine(Week_5.LargestOverlap(intervals1));

Console.WriteLine(".................... Week 6 ...................");
Console.WriteLine("Daily temps problem");
var results = Week_6.DailyTemperatures(new int[] { 73, 64, 75, 77, 56, 65, 65, 77 });
foreach (var r in results)
{
    Console.WriteLine(r);
}

Console.WriteLine("Valid parenthesis problem");

Console.WriteLine(Week_6.IsValid("{[()]}"));

Console.WriteLine("Calculate expression problem");
Console.WriteLine(Week_6.Calculate("4+3+(3-2)"));

