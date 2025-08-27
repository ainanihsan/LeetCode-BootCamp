public class Week_6
{
    // Returns an array where each element is the number of days until a warmer temperature.
        public static int[] DailyTemperatures(int[] temperatures)
    {
        int n = temperatures.Length;
        int[] result = new int[n]; // Result array to store days until warmer temperature
        Stack<int> temps = new Stack<int>(); // Stack to keep indices of temperatures

        for (int i = 0; i < n; i++)
        {
            // Check if current temperature is warmer than the temperature at the index on top of the stack
            while (temps.Count() != 0 && temperatures[temps.Peek()] < temperatures[i])
            {
                int index = temps.Pop(); // Get the index of the colder temperature
                result[index] = i - index; // Calculate the number of days until a warmer temperature
            }
            temps.Push(i); // Push current index onto the stack
        }

        // Indices left in the stack do not have a warmer temperature in the future, so their result remains 0
        return result;
    }


    static Dictionary<char, char> parenthesis = new()
    {
        {'[',']'},
        {'{','}'},
        {'(',')'},
    };
    public static bool IsValid(string s)
    {
        // Placeholder for your stack-based solution!
        Stack<char> openingStack = new Stack<char>();

        foreach (var c in s.ToCharArray())
        {
            if (parenthesis.ContainsKey(c))
            {
                openingStack.Push(c);
            }
            else
            {
                if (openingStack.Count != 0 && parenthesis.TryGetValue(openingStack.Peek(), out char expectedClose) && expectedClose == c)
                {
                    openingStack.Pop();
                }
                else
                {
                    return false;
                }

            }
        }

        return openingStack.Count() == 0;
    }

    public static int Calculate(string s)
    {
        // Placeholder for your stack-based solution!

        Stack<int> stack = new Stack<int>();
        int result = 0;
        int sign = 1;
        int number = 0;

        foreach (var c in s.ToCharArray())
        {
            if (char.IsDigit(c))
            {
                number = number * 10 + (c - '0');
            }
            else if (c == '+')
            {
                result += sign * number;
                sign = 1;
                number = 0;
            }
            else if (c == '-')
            {
                result += sign * number;
                sign = -1;
                number = 0;
            }
            else if (c == '(')
            {
                stack.Push(result);
                stack.Push(sign);
                result = 0;
                sign = 1;
            }
            else if (c == ')')
            {
                result += sign * number;
                number = 0;
                result *= stack.Pop();
                result += stack.Pop();
            }

        }

        return result + (sign * number);
    }


}