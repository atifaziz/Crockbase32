using NUnit.Framework;

namespace Tests
{
    using System;
    using System.Collections;
    using System.Linq;

    public class Tests
    {
        static readonly IEnumerable TestData = new IEnumerable[]
        {
            new[] { "\xff"             , "ZW" },
            new[] { "\xff\xff"         , "ZZZG" },
            new[] { "\xff\xff\xff"     , "ZZZZY" },
            new[] { "\x80"             , "G0" },
            new[] { "f"                , "CR" },
            new[] { "fo"               , "CSQG" },
            new[] { "foo"              , "CSQPY" },
            new[] { "foob"             , "CSQPYRG" },
            new[] { "fooba"            , "CSQPYRK1" },
            new[] { "foobar"           , "CSQPYRK1E8" },
            new[] { "1234567890123456789012345678901234567890",
                    "64S36D1N6RVKGE9G64S36D1N6RVKGE9G64S36D1N6RVKGE9G64S36D1N6RVKGE9G" },
        };

        [TestCaseSource(nameof(TestData))]
        public void Encode(string input, string encoded)
        {
            var bytes = input.Select(ch => (byte)ch).ToArray();
            var result = Crockbase32.Encode(bytes);
            Assert.That(result, Is.EqualTo(encoded));
        }

        [TestCaseSource(nameof(TestData))]
        public void EncodeByteString(string input, string encoded)
        {
            var result = Crockbase32.EncodeByteString(input);
            Assert.That(result, Is.EqualTo(encoded));
        }

        [TestCase("\u1000")]
        public void EncodeByteStringOverflow(string s)
        {
            Assert.Throws<OverflowException>(() =>
                Crockbase32.EncodeByteString(s));
        }

        [TestCaseSource(nameof(TestData))]
        public void Decode(string decoded, string encoded)
        {
            var bytes = decoded.Select(ch => (byte)ch).ToArray();
            var actualDecoded = Crockbase32.Decode(encoded);
            Assert.That(actualDecoded, Is.EqualTo(bytes));
        }
    }
}
