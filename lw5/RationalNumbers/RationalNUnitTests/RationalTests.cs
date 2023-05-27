using NUnit.Framework;
using RationalNumbers;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RationalTests")]

namespace RationalNUnitTests
{
    public class RationalCreatingTests
    {
        [Test]
        public void Creating_Rational_Number_Without_Args()
        {
            CRational rationalNumber = new CRational();
            Assert.AreEqual(0, rationalNumber.GetNumerator());
            Assert.AreEqual(1, rationalNumber.GetDenominator());
        }

        [Test]
        public void Creating_Rational_Number_With_Once_Argument()
        {
            CRational rationalNumber = new CRational(5);
            Assert.AreEqual(5, rationalNumber.GetNumerator());
            Assert.AreEqual(1, rationalNumber.GetDenominator());
        }

        [Test]
        public void Creating_Rational_Number_With_Two_Args()
        {
            CRational rationalNumber = new CRational(5, 3);
            Assert.AreEqual(5, rationalNumber.GetNumerator());
            Assert.AreEqual(3, rationalNumber.GetDenominator());
        }

        [Test]
        public void Creating_Rational_Number_With_Once_Argument_Less_Than_Zero()
        {
            CRational rationalNumber = new CRational(-9);
            Assert.AreEqual(-9, rationalNumber.GetNumerator());
            Assert.AreEqual(1, rationalNumber.GetDenominator());
        }

        [Test]
        public void Creating_Rational_Number_With_Two_Args_Where_Denominator_Is_Less_Than_Zero()
        {
            Assert.Throws<ArgumentException>(() => new CRational(9, -1));
        }

        [Test]
        public void Creating_Rational_Number_With_Two_Args_Where_Denominator_Is_Zero()
        {
            Assert.Throws<ArgumentNullException>(() => new CRational(9, 0));
        }

        [Test]
        public void Creating_Rational_Number_With_Two_Args_Where_The_Wrong_Kind()
        {
            CRational rationalNumber = new CRational(20, 10);
            Assert.AreEqual(2, rationalNumber.GetNumerator());
            Assert.AreEqual(1, rationalNumber.GetDenominator());
        }
    }
    public class RationalToDoubleMethodTests
    {
        [Test]
        public void Rational_Number_Is_Good()
        {
            CRational rationalNumber = new CRational(20, 10);
            Assert.AreEqual(2.0, rationalNumber.ToDouble());
        }
    }
    public class RationalUnaryMinusAndPlusOperatorTests
    {
        [Test]
        public void Unary_Minus_Good()
        {
            CRational rationalNumber = new CRational(5, 3);
            CRational minusRationalNum = -rationalNumber;
            Assert.AreEqual(-5, minusRationalNum.GetNumerator());
            Assert.AreEqual(3, minusRationalNum.GetDenominator());
        }

        [Test]
        public void Unary_Minus_Where_Numerator_Is_Zero()
        {
            CRational rational = new CRational();
            CRational minusRational = -rational;
            Assert.AreEqual(0, minusRational.GetNumerator());
            Assert.AreEqual(1, minusRational.GetDenominator());
        }

        [Test]
        public void Unary_Plus_Good()
        {
            CRational rationalNumber = new CRational(5, 3);
            CRational minusRationalNum = +rationalNumber;
            Assert.AreEqual(5, minusRationalNum.GetNumerator());
            Assert.AreEqual(3, minusRationalNum.GetDenominator());
        }

        [Test]
        public void Unary_Plus_Where_Numerator_Is_Zero()
        {
            CRational rational = new CRational();
            CRational minusRational = +rational;
            Assert.AreEqual(0, minusRational.GetNumerator());
            Assert.AreEqual(1, minusRational.GetDenominator());
        }
    }
    public class RationalBinaryPlusAndMinusOperatorsTests
    { 
        [Test]
        public void Binary_Plus_With_CRational_Arguments_Default()
        {
            CRational rational1 = new CRational(3, 2);
            CRational rational2 = new CRational(5, 2);

            CRational result = rational1 + rational2;
            CRational expectedResult = new CRational(4);

            Assert.AreEqual(expectedResult.GetNumerator(), result.GetNumerator());
            Assert.AreEqual(expectedResult.GetDenominator(), result.GetDenominator());
        }
        
        [Test]
        public void Binary_Plus_With_CRational_Arguments()
        {
            CRational rational1 = new CRational(-5);
            CRational rational2 = new CRational(4, 2);

            CRational result = rational1 + rational2;
            CRational expectedResult = new CRational(-3, 1);

            Assert.AreEqual(expectedResult.GetNumerator(), result.GetNumerator());
            Assert.AreEqual(expectedResult.GetDenominator(), result.GetDenominator());
        }

        [Test]
        public void Binary_Plus_With_CRational_Arguments_Numerator_Is_Zero()
        {
            CRational rational1 = new CRational();
            CRational rational2 = new CRational();

            CRational result = rational1 + rational2;
            CRational expectedResult = new CRational();

            Assert.AreEqual(expectedResult.GetNumerator(), result.GetNumerator());
            Assert.AreEqual(expectedResult.GetDenominator(), result.GetDenominator());
        }

        [Test]
        public void Binary_Plus_With_Integer()
        {
            CRational rational1 = new CRational(2, 3);
            int intNum = 5;

            CRational result = rational1 + intNum;
            CRational expectedResult = new CRational(17, 3);
            Assert.AreEqual(expectedResult.GetNumerator(), result.GetNumerator());
            Assert.AreEqual(expectedResult.GetDenominator(), result.GetDenominator());
        }

        [Test]
        public void Binary_Minus_With_CRational_Arguments_Default()
        {
            CRational rational1 = new CRational(3, 2);
            CRational rational2 = new CRational(5, 2);

            CRational result = rational1 - rational2;
            CRational expectedResult = new CRational(-1);

            Assert.AreEqual(expectedResult.GetNumerator(), result.GetNumerator());
            Assert.AreEqual(expectedResult.GetDenominator(), result.GetDenominator());
        }

        [Test]
        public void Binary_Minus_With_CRational_Arguments()
        {
            CRational rational1 = new CRational(-5);
            CRational rational2 = new CRational(4, 2);

            CRational result = rational1 - rational2;
            CRational expectedResult = new CRational(-7);

            Assert.AreEqual(expectedResult.GetNumerator(), result.GetNumerator());
            Assert.AreEqual(expectedResult.GetDenominator(), result.GetDenominator());
        }

        [Test]
        public void Binary_Minus_With_CRational_Arguments_Numerator_Is_Zero()
        {
            CRational rational1 = new CRational();
            CRational rational2 = new CRational();

            CRational result = rational1 - rational2;
            CRational expectedResult = new CRational();

            Assert.AreEqual(expectedResult.GetNumerator(), result.GetNumerator());
            Assert.AreEqual(expectedResult.GetDenominator(), result.GetDenominator());
        }

        [Test]
        public void Binary_Minus_With_Integer()
        {
            CRational rational1 = new CRational(2, 3);
            int intNum = 5;

            CRational result = rational1 - intNum;
            CRational expectedResult = new CRational(-13, 3);
            Assert.AreEqual(expectedResult.GetNumerator(), result.GetNumerator());
            Assert.AreEqual(expectedResult.GetDenominator(), result.GetDenominator());
        }
    }
    public class RationalPrefixPlusAndMinusOperatorsTests
    {
        [Test]
        public void Prefix_Plus()
        {
            CRational rational = new CRational(2, 3);
            CRational result = rational++;
            CRational expectedResult = new CRational(5, 3);
        }

        [Test]
        public void Prefix_Minus()
        {
            CRational rational = new CRational(2, 3);
            CRational result = rational--;
            CRational expectedResult = new CRational(-1, 3);
        }
    }
}