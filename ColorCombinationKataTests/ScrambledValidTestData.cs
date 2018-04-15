using System.Collections;
using System.Collections.Generic;
using ColorCombinationKata;

namespace ColorCombinationKataTests
{
    public class ScrambledValidTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                "Blue", "Green",
                new List<Chip<string>>
                {
                    new Chip<string>("Blue", "Yellow"),
                    new Chip<string>("Red", "Orange"),
                    new Chip<string>("Red", "Green"),
                    new Chip<string>("Yellow", "Red"),
                    new Chip<string>("Orange", "Red")
                }
            };
            yield return new object[]
            {
                "Blue", "Green",
                new List<Chip<string>>
                {
                    new Chip<string>("Blue", "Green"),
                    new Chip<string>("Blue", "Yellow"),
                    new Chip<string>("Green", "Yellow"),
                    new Chip<string>("Orange", "Red"),
                    new Chip<string>("Red", "Green"),
                    new Chip<string>("Red", "Orange"),
                    new Chip<string>("Yellow", "Blue"),
                    new Chip<string>("Yellow", "Red")
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}