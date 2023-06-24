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
            Assert.Throws<ArgumentNullException>(() => new CRational(9, -1));
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
        public bool IsGood(double first, double second)
        {
            const double e = 0.01;
            return Math.Abs(first - second) < e;
        }

        [Test]
        public void Rational_Number_Is_Good()
        {
            CRational rationalNumber = new CRational(20, 10);
            Assert.AreEqual(IsGood(2.0, rationalNumber.ToDouble()), true);
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
            rational++;
            CRational expectedResult = new CRational(5, 3);
            Assert.AreEqual(expectedResult.GetNumerator(), rational.GetNumerator());
            Assert.AreEqual(expectedResult.GetDenominator(), rational.GetDenominator());
        }

        [Test]
        public void Prefix_Minus()
        {
            CRational rational = new CRational(2, 3);
            rational--;
            CRational expectedResult = new CRational(-1, 3);
            Assert.AreEqual(expectedResult.GetNumerator(), rational.GetNumerator());
            Assert.AreEqual(expectedResult.GetDenominator(), rational.GetDenominator());
        }

        [Test]
        public void Assignment_Operator_Plus()
        {
            CRational rational = new CRational(2, 3);
            rational += 5;
            CRational expectedResult = new CRational(17, 3);
            Assert.AreEqual(expectedResult.GetNumerator(), rational.GetNumerator());
            Assert.AreEqual(expectedResult.GetDenominator(), rational.GetDenominator());
        }

        [Test]
        public void Assignment_Operator_Minus()
        {
            CRational rational = new CRational(2, 3);
            rational -= 5;
            CRational expectedResult = new CRational(-13, 3);
            Assert.AreEqual(expectedResult.GetNumerator(), rational.GetNumerator());
            Assert.AreEqual(expectedResult.GetDenominator(), rational.GetDenominator());
        }
    }

    public class RationalMultiplicationAndDivisionOperatorsTests
    { 
        [Test]
        public void Multiplication_With_Integer()
        {
            CRational rational = new CRational(2, 3);
            CRational result = rational * 5;
            CRational expectedResult = new CRational(10, 3);
            Assert.AreEqual(expectedResult.GetNumerator(), result.GetNumerator());
            Assert.AreEqual(expectedResult.GetDenominator(), result.GetDenominator());
        }

        [Test]
        public void Multiplication_With_Null()
        {
            CRational rational = new CRational(2, 3);
            int num = 0;
            CRational result = rational * num;
            CRational expectedResult = new CRational(0, 3);
            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public void Multiplication_With_Rational_Number()
        {
            CRational rational1 = new CRational(2, 3);
            CRational rational2 = new CRational(3, 2);
            CRational result = rational1 * rational2;
            CRational expectedResult = new CRational(1);
            Assert.AreEqual(expectedResult.GetNumerator(), result.GetNumerator());
            Assert.AreEqual(expectedResult.GetDenominator(), result.GetDenominator());
        }

        [Test]
        public void Integer_Multiplication_With_Assignment()
        {
            CRational rational = new CRational(2, 3);
            rational *= 5;
            CRational expectedResult = new CRational(10, 3);
            Assert.AreEqual(expectedResult.GetNumerator(), rational.GetNumerator());
            Assert.AreEqual(expectedResult.GetDenominator(), rational.GetDenominator());
        }

        [Test]
        public void Rational_Multiplication_With_Assignment()
        {
            CRational rational1 = new CRational(2, 3);
            CRational rational2 = new CRational(3, 2);
            rational1 *= rational2;
            CRational expectedResult = new CRational(1);
            Assert.AreEqual(expectedResult.GetNumerator(), rational1.GetNumerator());
            Assert.AreEqual(expectedResult.GetDenominator(), rational1.GetDenominator());
        }

        [Test]
        public void Division_With_Integer()
        {
            CRational rational = new CRational(2, 3);
            CRational result = rational / 5;
            CRational expectedResult = new CRational(2, 15);
            Assert.AreEqual(expectedResult.GetNumerator(), result.GetNumerator());
            Assert.AreEqual(expectedResult.GetDenominator(), result.GetDenominator());
        }

        [Test]
        public void Division_With_Rational_Number()
        {
            CRational rational1 = new CRational(2, 3);
            CRational rational2 = new CRational(3, 2);
            CRational result = rational1 / rational2;
            CRational expectedResult = new CRational(4, 9);
            Assert.AreEqual(expectedResult.GetNumerator(), result.GetNumerator());
            Assert.AreEqual(expectedResult.GetDenominator(), result.GetDenominator());
        }

        [Test]
        public void Integer_Division_With_Assignment()
        {
            CRational rational = new CRational(2, 3);
            rational /= 5;
            CRational expectedResult = new CRational(2, 15);
            Assert.AreEqual(expectedResult.GetNumerator(), rational.GetNumerator());
            Assert.AreEqual(expectedResult.GetDenominator(), rational.GetDenominator());
        }

        [Test]
        public void Rational_Division_With_Assignment()
        {
            CRational rational1 = new CRational(2, 3);
            CRational rational2 = new CRational(3, 2);
            rational1 /= rational2;
            CRational expectedResult = new CRational(4, 9);
            Assert.AreEqual(expectedResult.GetNumerator(), rational1.GetNumerator());
            Assert.AreEqual(expectedResult.GetDenominator(), rational1.GetDenominator());
        }

        [Test]
        public void Division_With_Null()
        {
            CRational rational = new CRational(5);
            Assert.Throws<DivideByZeroException>(() => rational /= 0);
        }

        [Test]
        public void Division_With_Null_Rational()
        {
            CRational rational = new CRational(5);
            CRational rational1 = new CRational(0);
            Assert.Throws<DivideByZeroException>(() => rational /= rational1);
        }
    }

    public class RationalEqualityTests
    {
        [Test]
        public void Equality_Of_Rational_And_Integer()
        {
            CRational rational1 = new CRational(2, 2);
            CRational rational2 = new CRational(2, 3);
            int intNum = 1;
            Assert.AreEqual(true, rational1 == intNum);
            Assert.AreEqual(false, rational2 == intNum);
        }

        [Test]
        public void Equality_Of_Rational_And_Rational()
        {
            CRational rational1 = new CRational(2, 2);
            CRational rational2 = new CRational(2, 3);
            CRational rational3 = new CRational(8, 8);
            Assert.AreEqual(true, rational1 == rational3);
            Assert.AreEqual(false, rational2 == rational3);
        }

        [Test]
        public void Inequality_Of_Rational_And_Integer()
        {
            CRational rational1 = new CRational(2, 2);
            CRational rational2 = new CRational(2, 3);
            int intNum = 1;
            Assert.AreEqual(false, rational1 != intNum);
            Assert.AreEqual(true, rational2 != intNum);
        }

        [Test]
        public void Inequality_Of_Rational_And_Rational()
        {
            CRational rational1 = new CRational(2, 2);
            CRational rational2 = new CRational(2, 3);
            CRational rational3 = new CRational(8, 8);
            Assert.AreEqual(false, rational1 != rational3);
            Assert.AreEqual(true, rational2 != rational3);
        }
    }

    public class ComparisonOperatorsTests
    {
        [Test]
        public void Operators_For_Comparing_Rational_With_Integer()
        {
            CRational rational = new CRational(2, 2);
            int intNum1 = 1;
            int intNum2 = 2;
            int intNum3 = 0;
            Assert.AreEqual(true, rational > intNum3);
            Assert.AreEqual(true, rational < intNum2);
            Assert.AreEqual(false, rational > intNum1);
            Assert.AreEqual(false, rational > intNum2);
            Assert.AreEqual(false, rational < intNum3);
            Assert.AreEqual(false, rational < intNum1);
        }

        [Test]
        public void Operators_For_Comparing_Rational_With_Rational()
        {
            CRational rational1 = new CRational(2, 2);
            CRational rational2 = new CRational(4, 4);
            CRational rational3 = new CRational(4, 2);
            CRational rational4 = new CRational();
            Assert.AreEqual(true, rational1 > rational4);
            Assert.AreEqual(true, rational1 < rational3);
            Assert.AreEqual(false, rational1 > rational2);
            Assert.AreEqual(false, rational1 > rational3);
            Assert.AreEqual(false, rational1 < rational4);
            Assert.AreEqual(false, rational1 < rational2);
        }
    }
}