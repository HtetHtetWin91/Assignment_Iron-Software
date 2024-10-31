using System;
using System.Text;
using System.Collections.Generic;

public class Assignment
    {
    public static void Main()
        {

        while (true)
            {
            // Prompt the user for input
            Console.Write("Please input: ");
            string input = Console.ReadLine() ?? "Default Value";

            if (!input.EndsWith("#"))
                {
                Console.Write("# should always be included at the end of every input.\n");
                }
            else
                {
                // Call the OldPhonePad method with the input
                string result = OldPhonePad(input);
                Console.WriteLine("You entered: " + result);
                Console.Write("Do you want to input again? (yes/no): ");
                string continueInput = Console.ReadLine() ?? "Default Value";
                if (continueInput?.ToLower() != "yes")
                    {
                    break; // Exit the loop if the user does not want to continue
                    }
                }
            }
        }
    public static string OldPhonePad(string input)
        {
        // Define the mapping of keys to letters
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

        var result = new StringBuilder();  // To build the final output
        var currentChars = new StringBuilder();  // To track current character sequence
        char lastChar = '\0';  // Track the last character for sequence detection

        foreach (char c in input)
            {
            if (c == '#')
                {
                // End of input - break out of the loop
                break;
                }
            else if (c == '*')
                {
                // Backspace - remove the last character from the result if present
                if (result.Length > 0)
                    {
                    result.Length--;  // This removes the last character safely
                    }
                }
            else if (c == ' ')
                {
                // Space indicates the end of a current sequence
                if (currentChars.Length > 0 && keyMap.ContainsKey(lastChar))
                    {
                    int index = (currentChars.Length - 1) % keyMap[lastChar].Length;
                    result.Append(keyMap[lastChar][index]);
                    currentChars.Clear();  // Clear sequence for the next set
                    }
                }
            else
                {
                // Handle digit input
                if (c != lastChar && currentChars.Length > 0)
                    {
                    // Add the corresponding letter for the last character sequence
                    if (keyMap.ContainsKey(lastChar))
                        {
                        int index = (currentChars.Length - 1) % keyMap[lastChar].Length;
                        result.Append(keyMap[lastChar][index]);
                        }
                    currentChars.Clear();
                    }

                // Update the current sequence
                currentChars.Append(c);
                lastChar = c;
                }
            }

        // Handle any remaining characters at the end of the input
        if (currentChars.Length > 0 && keyMap.ContainsKey(lastChar))
            {
            int index = (currentChars.Length - 1) % keyMap[lastChar].Length;
            result.Append(keyMap[lastChar][index]);
            }

        return result.ToString();
        }
    }
