﻿using System.Collections;
using System.Collections.Generic;
using ColorCombinationKata;

namespace ColorCombinationKataTests
{
    public class InvalidTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {"Blue", "Green", new List<Chip<string>>()};
            yield return new object[] {"Blue", "Green", new List<Chip<string>> {new Chip<string>("Blue", "Blue")}};
            yield return new object[]
            {
                "Blue", "Green",
                new List<Chip<string>>
                {
                    new Chip<string>("Blue", "Yellow"),
                    new Chip<string>("Red", "Orange"),
                    new Chip<string>("Red", "Green"),
                    new Chip<string>("Yellow", "Red"),
                    new Chip<string>("Orange", "Purple")
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}