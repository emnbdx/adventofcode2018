﻿using System.Linq;

namespace AdventOfCode2018
{
    public class Day2 : AbstractDay
    {
        public Day2() : base(2)
        { }

        public override string Part1()
        {
            var repeat2 = 0;
            var repeat3 = 0;
            foreach (var word in Data)
            {
                var groupedChar = word.ToCharArray().GroupBy(_ => _).Select(_ => _.Count()).ToList();

                if (groupedChar.Any(_ => _ == 2))
                    repeat2++;

                if (groupedChar.Any(_ => _ == 3))
                    repeat3++;
            }

            return (repeat2 * repeat3).ToString();
        }

        public override string Part2()
        {
            var result = "";
            foreach(var word in Data)
            {
                foreach (var otherWord in Data)
                {
                    if (word == otherWord)
                        continue;

                    // assume each word as same char count in same order   
                    var differCount = 0;
                    var differPos = 0;
                    for (var i = 0; i < word.Length; i++)
                    {
                        if (word[i] != otherWord[i])
                        {
                            differCount++;
                            differPos = i;
                        }
                    }

                    if (differCount == 1)
                    {
                        result = word.Remove(differPos, 1);
                        break;
                    }

                }
            }

            return result;
        }
    }
}
