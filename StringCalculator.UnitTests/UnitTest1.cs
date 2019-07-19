using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace StringCalculator.UnitTests
{
    [TestClass]
    public class AddClassTests
    {
        [TestMethod]
        public void Add_NumbersEmpty_Returns0()
        {
            // Arrange
            var addclass = new AddClass();

            // Act
            var result = addclass.Add("");

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Add_NumbersFSlash_Returns0()
        {
            var addclass = new AddClass();
            var result = addclass.Add("//");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Add_Numbers0_Returns0()
        {
            var addclass = new AddClass();
            var result = addclass.Add("0");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Add_Numbers0Com1_Returns1()
        {
            var addclass = new AddClass();
            var result = addclass.Add("0,1");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Add_Numbers0Com1Com2_Returns3()
        {
            var addclass = new AddClass();
            var result = addclass.Add("0,1,2");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_Numbers1N2Com3_Returns6()
        {
            var addclass = new AddClass();
            var result = addclass.Add("1\n2,3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Add_NumbersSemi1Semi2_Returns3()
        {
            var addclass = new AddClass();
            var result = addclass.Add("//;\n1;2");
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_NumbersNeg1Com1_Returns1()
        {
            var addclass = new AddClass();
            var result = addclass.Add("//;\n-1,1");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Add_NumbersGreaterThanThousand_Returns2()
        {
            var addclass = new AddClass();
            var result = addclass.Add("//;\n1001;2");
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Add_NumbersLenDelim_Returns6()
        {
            var addclass = new AddClass();
            var result = addclass.Add("//[***]\n1***2***3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Add_NumbersMultiDelim_Returns6()
        {
            var addclass = new AddClass();
            var result = addclass.Add("//[*][%]\n1*2%3");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Add_NumbersMultiDelimLenDelim_Returns6()
        {
            var addclass = new AddClass();
            var result = addclass.Add("//[**][%%]\n1**2%%3");
            Assert.AreEqual(6, result);
        }
    }
}
