public class Week_5
{
    // Finds intersections between two lists of intervals.
    // Each interval is represented as an int[] with two elements: [start, end].
    // Returns a list of intervals where the two input lists overlap.
    public static List<int[]> IntervalIntersection(int[][] intervals1, int[][] intervals2)
    {
        List<int[]> overlaps = new List<int[]>();
        // Example:
        //  intervals1: [1,3], [5,7]
        //  intervals2: [2,5]
        // Overlap: [2,3], [5,5]

        int i = 0, j = 0; // Pointers for intervals1 and intervals2

        // Iterate through both interval lists
        while (i < intervals1.Length && j < intervals2.Length)
        {
            int start1 = intervals1[i][0], end1 = intervals1[i][1];
            int start2 = intervals2[j][0], end2 = intervals2[j][1];

            // Find the intersection between intervals1[i] and intervals2[j]
            int start = Math.Max(start1, start2);
            int end = Math.Min(end1, end2);

            // If intervals overlap, add the intersection to the result
            if (start <= end)
            {
                overlaps.Add(new int[] { start, end });
            }

            // Move the pointer that ends first to check next interval
            if (end1 < end2) i++;
            else j++;
        }
        return overlaps;
    }

    // Merges overlapping intervals in a list of intervals.
    // Each interval is represented as an int[] with two elements: [start, end].
    // Returns a list of merged intervals.
    public static List<int[]> Merge(int[][] intervals)
    {
        List<int[]> result = new List<int[]>();

        // Sort intervals by their start value.
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        // If only one interval, return it as is.
        if (intervals.Length == 1)
        {
            result.Add(new int[] { intervals[0][0], intervals[0][1] });
            return result;
        }

        // Iterate through intervals and merge if overlapping.
        for (int i = 0; i < intervals.Length - 1; i++)
        {
            // If result is empty, handle first merge or add both intervals.
            if (result.Count() == 0)
            {
                if (intervals[i][1] >= intervals[i + 1][0]) // Overlapping, merge
                {
                    result.Add(new int[] { intervals[i][0], Math.Max(intervals[i][1], intervals[i + 1][1]) });
                }
                else // Not overlapping, add both intervals
                {
                    result.Add(new int[] { intervals[i][0], intervals[i][1] });
                    result.Add(new int[] { intervals[i + 1][0], intervals[i + 1][1] });
                }
            }
            else
            {
                int[] lastresult = result.Last();
                // If last merged interval overlaps with current, merge them.
                if (lastresult[1] >= intervals[i + 1][0])
                {
                    result.RemoveAt(result.Count - 1);
                    result.Add(new int[] { lastresult[0], Math.Max(lastresult[1], intervals[i + 1][1]) });
                }
                else // No overlap, add current interval.
                {
                    result.Add(new int[] { intervals[i + 1][0], intervals[i + 1][1] });
                }
            }
        }

        return result;
    }

    public static int LargestOverlap(int[][] intervals)
    {
        List<(int time, int type)> events = new List<(int, int)>(); // type: +1 for start, -1 for end

        foreach (var interval in intervals)
        {
            events.Add((interval[0], 1));  // Start of interval
            events.Add((interval[1], -1)); // End of interval
        }

        // Sort by time. If times are equal, starts (+1) come before ends (-1)
        events.Sort((a, b) =>
        {
            if (a.time != b.time)
                return a.time.CompareTo(b.time);
            return a.type.CompareTo(b.type); // end (-1) before start (+1)
        });

        int active = 0;
        int maxOverlap = 0;

        foreach (var e in events)
        {
            active += e.type;
            maxOverlap = Math.Max(maxOverlap, active);
        }

        return maxOverlap;
    }


}