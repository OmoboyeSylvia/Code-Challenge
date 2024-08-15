using System;
using System.Text;

namespace C__Coding_Challenge
{
    public class OldPhonePad
    {
        public static string ConvertToText(string input)
        {
            // I defined  the mapping of keypad digits to letters here
            string[] keyMappings = new string[]
            {
            " ",    // 0
            "&'(",  // 1
            "ABC",  // 2
            "DEF",  // 3
            "GHI",  // 4
            "JKL",  // 5
            "MNO",  // 6
            "PQRS", // 7
            "TUV",  // 8
            "WXYZ"  // 9
            };

            StringBuilder output = new StringBuilder();
            int count = 0;
            char lastChar = '\0';

            foreach (char c in input)
            {
                if (c == '#')
                {
                    break;
                }
                else if (c == '*')
                {
                    if (output.Length > 0)
                    {
                        output.Remove(output.Length - 1, 1);
                    }
                    lastChar = '\0';  // Here is to reset  lastChar after backspace
                    count = 0;
                }
                else if (c == ' ')
                {
                    // here is to reset  when space is encountered
                    lastChar = '\0';
                    count = 0;
                }
                else if (char.IsDigit(c))
                {
                    if (c == lastChar)
                    {
                        count++;
                    }
                    else
                    {
                        if (lastChar != '\0')
                        {
                            int index = count % keyMappings[lastChar - '0'].Length;
                            output.Append(keyMappings[lastChar - '0'][index]);
                        }
                        lastChar = c;
                        count = 1;
                    }
                }
            }

            // here is to append the last character
            if (lastChar != '\0')
            {
                int index = count % keyMappings[lastChar - '0'].Length;
                output.Append(keyMappings[lastChar - '0'][index]);
            }

            return output.ToString();
        }
    }

}
