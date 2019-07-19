using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace StringCalculator.UnitTests
{
    [TestClass]
    public class AddClassTests
    {
        [TestMethod]
        public void Add_EmptyString_Returns0()
        {
            var addclass = new AddClass();
            var result = addclass.Add("");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Add_FwdSlashFwdSlash_Returns0()
        {
            var addclass = new AddClass();
            var result = addclass.Add("//");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Add_Zero_Returns0()
        {
            var addclass = new AddClass();
            var result = addclass.Add("0");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Add_NumbersSeparatedByComma_Returns1()
        {
            var addclass = new AddClass();
            var result = addclass.Add("0,1");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Add_NumbersSeparatedByComma_Returns3()
        {
            var addclass = new AddClass();
            var result = addclass.Add("0,1,2");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_NumbersNewLineAndSeparatedByComma_Returns6()
        {
            var addclass = new AddClass();
            var result = addclass.Add("1\n2,3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Add_SemicolonDelimiterSpecified_Returns3()
        {
            var addclass = new AddClass();
            var result = addclass.Add("//;\n1;2");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_IgnoreNegativeNumbers_Returns1()
        {
            var addclass = new AddClass();
            var result = addclass.Add("//;\n-1,1");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Add_IgnoreNumbersGreaterThan1000_Returns2()
        {
            var addclass = new AddClass();
            var result = addclass.Add("//;\n1001;2");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Add_MultipleCharDelimiter_Returns6()
        {
            var addclass = new AddClass();
            var result = addclass.Add("//[***]\n1***2***3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Add_MultipleDelimiter_Returns6()
        {
            var addclass = new AddClass();
            var result = addclass.Add("//[*][%]\n1*2%3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Add_MultipleDelimitersThatHaveMultipleChar_Returns6()
        {
            var addclass = new AddClass();
            var result = addclass.Add("//[**][%%]\n1**2%%3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Add_IgnoreStringsBoundByWrongDelimiter_Returns3()
        {
            var addclass = new AddClass();
            var result = addclass.Add("//[$]\n1%2,3");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_TrimSpaceAndCombineCharactersThatConnect_Returns16()
        {
            var addclass = new AddClass();
            var result = addclass.Add("//[$]\n1 2$3,1");
            Assert.AreEqual(16, result);
        }
    }
}
