using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Numbers;

namespace ConvertNumTest
{
    [TestClass]
    public class NumberEntryTest
    {
        [TestMethod]
        public void TestOne()
        {
            //arrange
            string entryNum = "1";
            string expected = "One";
            ConvertNum cn = new ConvertNum();

            // act
            Trace.WriteLine(cn.Convert(entryNum));

            // assert
            string result = cn.Convert(entryNum);
            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void TestZero()
        {
            //arrange
            string entryNum = "0";
            string expected = "Zero";
            ConvertNum cn = new ConvertNum();

            // act
            Trace.WriteLine(cn.Convert(entryNum));

            // assert
            string result = cn.Convert(entryNum);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMinusZero()
        {
            //arrange
            string entryNum = "-0";
            string expected = "Minus Zero";
            ConvertNum cn = new ConvertNum();

            // act
            Trace.WriteLine(cn.Convert(entryNum));

            // assert
            string result = cn.Convert(entryNum);
            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void TestOneHhund()
        {
            //arrange
            string entryNum = "101";
            string expected = "One Hundred and One";
            ConvertNum cn = new ConvertNum();

            // act
            Trace.WriteLine(cn.Convert(entryNum));

            // assert
            string result = cn.Convert(entryNum);
            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void TestoneThous()
        {
            //arrange
            string entryNum = "1001";
            string expected = "One Thousand and One";
            ConvertNum cn = new ConvertNum();

            // act
            Trace.WriteLine(cn.Convert(entryNum));

            // assert
            string result = cn.Convert(entryNum);
            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void TestTenThous()
        {
            //arrange
            string entryNum = "10001";
            string expected = "Ten Thousand and One";
            ConvertNum cn = new ConvertNum();

            // act
            Trace.WriteLine(cn.Convert(entryNum));

            // assert
            string result = cn.Convert(entryNum);
            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void TestHunThousandone()
        {
            //arrange
            string entryNum = "100001";
            string expected = "One Hundred Thousand and One";
            ConvertNum cn = new ConvertNum();

            // act
            Trace.WriteLine(cn.Convert(entryNum));

            // assert
            string result = cn.Convert(entryNum);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMilandOne()
        {
            //arrange
            string entryNum = "1000001";
            string expected = "One Million and One";
            ConvertNum cn = new ConvertNum();

            // act
            Trace.WriteLine(cn.Convert(entryNum));

            // assert
            string result = cn.Convert(entryNum);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMilHundThousHundEleven()
        {
            //arrange
            string entryNum = "1111111";
            string expected = "One Million One Hundred and Eleven Thousand One Hundred and Eleven";
            ConvertNum cn = new ConvertNum();

            // act
            Trace.WriteLine(cn.Convert(entryNum));

            // assert
            string result = cn.Convert(entryNum);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMilHundThousHund()
        {
            //arrange
            string entryNum = "1100100";
            string expected = "One Million One Hundred Thousand One Hundred";
            ConvertNum cn = new ConvertNum();

            // act
            Trace.WriteLine(cn.Convert(entryNum));

            // assert
            string result = cn.Convert(entryNum);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMilHundThousTen()
        {
            //arrange
            string entryNum = "1100010";
            string expected = "One Million One Hundred Thousand and Ten";
            ConvertNum cn = new ConvertNum();

            // act
            Trace.WriteLine(cn.Convert(entryNum));

            // assert
            string result = cn.Convert(entryNum);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMilHundThousOne()
        {
            //arrange
            string entryNum = "1100001";
            string expected = "One Million One Hundred Thousand and One";
            ConvertNum cn = new ConvertNum();

            // act
            Trace.WriteLine(cn.Convert(entryNum));

            // assert
            string result = cn.Convert(entryNum);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMilHundThous()
        {
            //arrange
            string entryNum = "1100000";
            string expected = "One Million One Hundred Thousand";
            ConvertNum cn = new ConvertNum();

            // act
            Trace.WriteLine(cn.Convert(entryNum));

            // assert
            string result = cn.Convert(entryNum);
            Assert.AreEqual(expected, result);
        }
    }
}
