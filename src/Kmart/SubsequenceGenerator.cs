using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kmart
{
    public class SubsequenceGenerator
    {
        public static string Generate(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException(nameof(input), "Input is null or empty");
            }

            if(!Regex.IsMatch(input, "^(\\d+\\s?)+$"))
            {
                throw new ArgumentException(nameof(input), "Input format is invalid");
            }


            var nums = input.Split(' ').Select(n => int.Parse(n)).ToArray();

            var list = new List<int>();
            var longestList = new List<int>();
            int currentMax;
            int highestCount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                currentMax = int.MinValue;
                var conseqJ = i;
                for (int j = i; j < nums.Length; j++)
                {
                    if (nums[j] > currentMax && j - conseqJ == 1)
                    {
                        conseqJ = j;
                        list.Add(nums[j]);
                        currentMax = nums[j];
                    }
                }

                // Compare previous highest subsequence
                if (highestCount < list.Count)
                {
                    highestCount = list.Count;
                    longestList = new List<int>(list);
                }
                list.Clear();
            }

            return string.Join(' ', longestList.Select(n => n.ToString()));
        }
    }
}
