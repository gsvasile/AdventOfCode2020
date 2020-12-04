using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class ProgramDay3
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Advent Of Code Day 3!");

            List<string> input = new List<string>();

            // Add all lines of the input file into a list.
            using(var file = new System.IO.StreamReader("Input.txt"))
            {
                string line;
                while((line = file.ReadLine()) != null)
                {
                    input.Add(line);
                }
            }

            // Day 3 Part 1 - Get the number of trees encountered by
            // following the slope right 3, down 1
            // and submit that number.
            var mountainMatrix31 = GetNumberOfTreesEncountered(input, 3, 1);
            Console.WriteLine("Day 3 - Part 1: The number of trees encountered is: ");
            Console.WriteLine($"      {mountainMatrix31}");

            // Day 3 Part 2 - Multiply the number of trees encoutered by
            // following the slope right 3, down 1 and
            // following the slope right 1, down 1 and
            // following the slope right 5, down 1 and
            // following the slope right 7, down 1 and
            // following the slope right 1, down 2
            // together and submit the number.
            var mountainMatrix11 = GetNumberOfTreesEncountered(input, 1, 1);
            var mountainMatrix51 = GetNumberOfTreesEncountered(input, 5, 1);
            var mountainMatrix71 = GetNumberOfTreesEncountered(input, 7, 1);
            var mountainMatrix12 = GetNumberOfTreesEncountered(input, 1, 2);

            // Print the multiplication of the number of trees at each stated slope.
            Console.WriteLine("Day 3 - Part 2: The number of trees encountered at slopes 3/1, 1/1, 5/1, 7/1, and 1/2");
            Console.WriteLine("multiplied together is: ");
            Console.WriteLine($"      {mountainMatrix31 * mountainMatrix11 * mountainMatrix51 * mountainMatrix71 * mountainMatrix12}");
        }

        /// <summary>
        /// Gets the number of trees that are encountered by following the slope
        /// moving right and down by the given number of spaces to move.
        /// </summary>
        /// <param name="input">The mountain slope represented by open spaces ('.') and trees ('#')</param>
        /// <param name="numberOfSpacesToMoveRight">The number of spaces to 'move' to the right.</param>
        /// <param name="numberOfSpacesToMoveDown">The number of spaces to 'move' down.</param>
        /// <returns>The number of trees that were encountered while moving down the slope</returns>
        private static double GetNumberOfTreesEncountered(IList<string> input, int numberOfSpacesToMoveRight, int numberOfSpacesToMoveDown)
        {
            double numOfTreesEncountered = 0;
            var spacesMovedRight = numberOfSpacesToMoveRight;
            var treeSymbol = '#';

            // Moving down first (starting from the top left of the mountain at 0, 0.
            // The number of entries in the input is the number of rows.
            for(int i = numberOfSpacesToMoveDown; i < input.Count; i += numberOfSpacesToMoveDown)
            {
                // Then move right.
                // Since the mountain slope repeats horizontally, get the remainder
                // of the total number of spaces moved right divided by the original horizontal length.
                int j = spacesMovedRight % input[i].Length;
                if(input[i][j] == treeSymbol)
                {
                    ++numOfTreesEncountered;
                }
                spacesMovedRight += numberOfSpacesToMoveRight;
            }

            return numOfTreesEncountered;
        }
    }
}
