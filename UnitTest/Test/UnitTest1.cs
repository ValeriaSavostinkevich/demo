using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TriangleApp;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsRightTriangle()
        {
            Assert.IsTrue(TestTriangle.IsTriangle(3,4,5));
        }

        [TestMethod]
        public void IsTriangleIsoscelesTriangle()
        {
            Assert.IsTrue(TestTriangle.IsTriangle(3, 3, 5));
        }

        [TestMethod]
        public void IsTrianglePossible_SumMoreThanSideLength()
        {
            Assert.IsTrue(TestTriangle.IsTriangle(3, 2, 5));
        }

        [TestMethod]
        public void IsTriangle_ReturnsTrue()
        {
            Assert.IsFalse(TestTriangle.IsTriangle(3, 1, 5));
        }

        [TestMethod]
        public void IsTriangleEquilateralTriangle()
        {
            Assert.IsTrue(TestTriangle.IsTriangle(3, 3, 3));
        }

        [TestMethod]
        public void OneSideIsNegative()
        {
            Assert.IsFalse(TestTriangle.IsTriangle(-3, 1, 5));
        }

        [TestMethod]
        public void OneSideIsZero()
        {
            Assert.IsFalse(TestTriangle.IsTriangle(0, 1, 5));
        }

        [TestMethod]
        public void AllSidesIsZero()
        {
            Assert.IsFalse(TestTriangle.IsTriangle(0, 0, 5));
        }

        [TestMethod]
        public void AllSidesIsNegative()
        {
            Assert.IsFalse(TestTriangle.IsTriangle(-1, -1, -5));
        }

        [TestMethod]
        public void IsTrianglePossible()
        {
            Assert.IsFalse(TestTriangle.IsTriangle(19, 10, 5));
        }
    }
}
