using System.Collections;
using System.Collections.Generic;
using ColorCombinationKata;

namespace ColorCombinationKataTests
{
    public class ValidTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {"Blue", "Blue", new List<Chip<string>>()};
            yield return new object[] {"Blue", "Blue", new List<Chip<string>> {new Chip<string>("Blue", "Blue")}};
            yield return new object[] {"Blue", "Green", new List<Chip<string>> {new Chip<string>("Blue", "Green")}};
            yield return new object[]
            {
                "Blue", "Green",
                new List<Chip<string>> {new Chip<string>("Blue", "Red"), new Chip<string>("Red", "Green")}
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}