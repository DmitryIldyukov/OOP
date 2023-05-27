using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumbers
{
    public class CRational
    {
        /// <summary>
        /// Создание рационального числа
        /// </summary>
        /// <param name="numerator">
        /// Числитель
        /// </param>
        /// <param name="denominator">
        /// Знаменатель
        /// </param>
        public CRational(int numerator = 0, int denominator = 1)
        {
            if (denominator == 0)
                throw new ArgumentNullException();

            if (denominator < 0)
                throw new ArgumentException();

            Numerator = numerator;
            Denominator = denominator;
            this.ToRational();
        }

        /// <summary>
        /// Унарный минус
        /// </summary>
        /// <param name="rationalNumber"></param>
        /// <returns></returns>
        public static CRational operator -(CRational rationalNumber)
        {
            return new CRational { Numerator = -rationalNumber.Numerator, Denominator = rationalNumber.Denominator };
        }

        /// <summary>
        /// Унарный плюс
        /// </summary>
        /// <param name="rationalNumber"></param>
        /// <returns></returns>
        public static CRational operator +(CRational rationalNumber)
        {
            return new CRational { Numerator = rationalNumber.Numerator, Denominator = rationalNumber.Denominator };
        }

        /// <summary>
        /// Бинарный минус
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static CRational operator -(CRational num1, CRational num2)
        {
            int newNumerator = num1.Numerator * num2.Denominator - num2.Numerator * num1.Denominator;
            int commonDenuminator = num1.Denominator * num2.Denominator;
            return new CRational(newNumerator, commonDenuminator);
        }

        /// <summary>
        /// Бинарный плюс
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static CRational operator +(CRational num1, CRational num2)
        {
            int newNumerator = num1.Numerator * num2.Denominator + num2.Numerator * num1.Denominator;
            int commonDenuminator = num1.Denominator * num2.Denominator;
            return new CRational(newNumerator, commonDenuminator);
        }

        /// <summary>
        /// Префиксный оператор увеличения
        /// </summary>
        /// <param name="rational"></param>
        /// <returns></returns>
        public static CRational operator ++(CRational rational)
        {
            int newNumerator = rational.Numerator + rational.Numerator * rational.Denominator;
            return new CRational(newNumerator, rational.Denominator);
        }

        /// <summary>
        /// Префиксный оператор уменьшения
        /// </summary>
        /// <param name="rational"></param>
        /// <returns></returns>
        public static CRational operator --(CRational rational)
        {
            int newNumerator = rational.Numerator - rational.Numerator * rational.Denominator;
            return new CRational(newNumerator, rational.Denominator);
        }

        /// <summary>
        /// Неявное прeобразование типа int в CRational
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator CRational(int value)
        {
            return new CRational(value);
        }

        /// <summary>
        /// Получить значение рационального числа
        /// </summary>
        /// <returns></returns>
        public double ToDouble()
        {
            return Numerator / Denominator;
        }

        /// <summary>
        /// Приведение рационального числа к правильному виду
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        private void ToRational()
        {
            int numerator = Numerator;
            int denominator = Denominator;
            int greatestCommonDivisor = GetGreatestCommonDivisor(numerator, denominator);
            Numerator /= greatestCommonDivisor;
            Denominator /= greatestCommonDivisor;
        }

        /// <summary>
        /// Получение НОД
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        private int GetGreatestCommonDivisor(int num1, int num2)
        {
            num1 = Math.Abs(num1);
            num2 = Math.Abs(num2);
            while (num1 != num2 && num1 > 0 && num1 > 0)
            {
                if (num1 > num2)
                {
                    num1 -= num2;
                    continue;
                }
                if (num1 < num2)
                {
                    num2 -= num1;
                    continue;
                }
            }

            if (num1 != num2)
            {
                return 1;
            }

            return num1;
        }

        /// <summary>
        /// Получить значения рационального числа
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        /// <summary>
        /// Получение значения числителя
        /// </summary>
        /// <returns></returns>
        public int GetNumerator()
        {
            return Numerator;
        }

        /// <summary>
        /// Получение значения знаменателя
        /// </summary>
        /// <returns></returns>
        public int GetDenominator()
        {
            return Denominator;
        }

        private int Numerator { get; set; }
        private int Denominator { get; set; }
    }
}
