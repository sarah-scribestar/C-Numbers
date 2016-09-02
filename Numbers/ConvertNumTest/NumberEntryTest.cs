using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Numbers;

namespace ConvertNumTest
{
    [TestClass]
    public class NumberEntryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange
            string entryNum = "100";
            string expected = "one Hundred";
            ConvertNum cn = new ConvertNum();

            // act
            cn.Convert(entryNum);

            // assert
            string result = cn.Convert(entryNum);

        }
    }
}
