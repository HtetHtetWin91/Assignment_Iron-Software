using System.Text;

public class Assignment
    {
    public static void Main()
        {
        while (true)
            {
            Console.Write("Please input: ");
            string input = Console.ReadLine() ?? "Default Value";

            if (!input.EndsWith("#"))
                {
                Console.WriteLine("# should always be included at the end of every input.");
                }
            else
                {
                string result = OldPhonePad(input);
                Console.WriteLine("You entered: " + result);
                Console.Write("Do you want to input again? (yes/no): ");
                string continueInput = Console.ReadLine() ?? "Default Value";
                if (continueInput?.ToLower() != "yes")
                    {
                    break;
                    }
                }
            }
        }

    public static string OldPhonePad(string input)
        {
        var keyMap = new Dictionary<char, string>
        {
            {'2', "ABC"},
            {'3', "DEF"},
            {'4', "GHI"},
            {'5', "JKL"},
            {'6', "MNO"},
            {'7', "PQRS"},
            {'8', "TUV"},
            {'9', "WXYZ"}
        };

        var result = new StringBuilder();
        char lastChar = '\0';
        int count = 0;

        foreach (char c in input)
            {
            if (c == '#')
                {
                if (count > 0 && keyMap.ContainsKey(lastChar))
                    {
                    result.Append(keyMap[lastChar][(count - 1) % keyMap[lastChar].Length]);
                    Console.WriteLine($"Processingfinal: {lastChar}, Count: {count}, Result: {result}");
                    }
                break;
                }
            else if (c == '*')
                {
                // Backspace - only remove the last character if present
                if (result.Length > 0)
                    {
                    count = 0;
                    Console.WriteLine($"Processingstar: *, Count: {count}, Result: {result}");
                    }
                }
            else if (c == ' ')
                {
                // Space indicates the end of a current sequence
                if (count > 0 && keyMap.ContainsKey(lastChar))
                    {
                    result.Append(keyMap[lastChar][(count - 1) % keyMap[lastChar].Length]);
                    }
                count = 0;
                lastChar = '\0';
                }
            else
                {
                if (c == lastChar)
                    {
                    count++;
                    }
                else
                    {
                    // Append the last sequence's final character if available
                    if (count > 0 && keyMap.ContainsKey(lastChar))
                        {
                        result.Append(keyMap[lastChar][(count - 1) % keyMap[lastChar].Length]);
                        }
                    lastChar = c;
                    count = 1;
                    }

                if (count > 0 && keyMap.ContainsKey(lastChar))
                    {
                    int index = (count - 1) % keyMap[lastChar].Length;
                    Console.WriteLine($"Processing: {c}, Count: {count}, Result: {result}{keyMap[lastChar][index]}");
                    }
                }
            }
        return result.ToString();
        }
    }
