using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumbers
{
    public class CRational : IComparable<CRational>
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
            if (denominator <= 0)
                throw new ArgumentNullException( "Знаменатель должен быть натуральным числом" );

            Numerator = numerator;
            Denominator = denominator;
            this.ToRational();
        }

        /// <summary>
        /// Унарный минус
        /// </summary>
        /// <param name="rationalNumber">Рациональное число</param>
        /// <returns></returns>
        public static CRational operator -(CRational rationalNumber)
        {
            return new CRational { Numerator = -rationalNumber.Numerator, Denominator = rationalNumber.Denominator };
        }

        /// <summary>
        /// Унарный плюс
        /// </summary>
        /// <param name="rationalNumber">Рациональное число</param>
        /// <returns></returns>
        public static CRational operator +(CRational rationalNumber)
        {
            return rationalNumber;
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
        /// <param name="rational">Рациональное число</param>
        /// <returns></returns>
        public static CRational operator ++(CRational rational)
        {
            int newNumerator = rational.Numerator + rational.Denominator;
            return new CRational(newNumerator, rational.Denominator);
        }

        /// <summary>
        /// Префиксный оператор уменьшения
        /// </summary>
        /// <param name="rational">Рациональное число</param>
        /// <returns></returns>
        public static CRational operator --(CRational rational)
        {
            int newNumerator = rational.Numerator - rational.Denominator;
            return new CRational(newNumerator, rational.Denominator);
        }

        /// <summary>
        /// Умножение
        /// </summary>
        /// <param name="rational1"></param>
        /// <param name="rational2"></param>
        /// <returns></returns>
        public static CRational operator *(CRational rational1, CRational rational2)
        {
            int newNumerator = rational1.Numerator * rational2.Numerator;
            int commonDenuminator = rational1.Denominator * rational2.Denominator;
            return new CRational(newNumerator, commonDenuminator);
        }

        /// <summary>
        /// Деление
        /// </summary>
        /// <param name="rational1"></param>
        /// <param name="rational2"></param>
        /// <returns></returns>
        public static CRational operator /(CRational rational1, CRational rational2)
        {
            int newNumerator = rational1.Numerator * rational2.Denominator;
            int commonDenuminator = rational1.Denominator * rational2.Numerator;
            return new CRational(newNumerator, commonDenuminator);
        }

        /// <summary>
        /// Проверка на неравенство
        /// </summary>
        /// <param name="rational1"></param>
        /// <param name="rational2"></param>
        /// <returns></returns>
        public static bool operator !=(CRational rational1, CRational rational2)
        {
            return rational1.ToDouble() != rational2.ToDouble();
        }

        /// <summary>
        /// Проверка на равенство
        /// </summary>
        /// <param name="rational1"></param>
        /// <param name="rational2"></param>
        /// <returns></returns>
        public static bool operator ==(CRational rational1, CRational rational2)
        {
            return rational1.ToDouble() == rational2.ToDouble();
        }

        /// <summary>
        /// Оператор сравнения (больше)
        /// </summary>
        /// <param name="rational1"></param>
        /// <param name="rational2"></param>
        /// <returns></returns>
        public static bool operator >(CRational rational1, CRational rational2)
        {
            return rational1.ToDouble() > rational2.ToDouble();
        }

        /// <summary>
        /// Оператор сравнения (меньше)
        /// </summary>
        /// <param name="rational1"></param>
        /// <param name="rational2"></param>
        /// <returns></returns>
        public static bool operator <(CRational rational1, CRational rational2)
        {
            return rational1.ToDouble() < rational2.ToDouble();
        }

        /// <summary>
        /// Оператор сравнения (больше или равно)
        /// </summary>
        /// <param name="rational1"></param>
        /// <param name="rational2"></param>
        /// <returns></returns>
        public static bool operator >=(CRational rational1, CRational rational2)
        {
            return rational1.ToDouble() >= rational2.ToDouble();
        }

        /// <summary>
        /// Оператор сравнения (меньше или равно)
        /// </summary>
        /// <param name="rational1"></param>
        /// <param name="rational2"></param>
        /// <returns></returns>
        public static bool operator <=(CRational rational1, CRational rational2)
        {
            return rational1.ToDouble() <= rational2.ToDouble(); 
        }

        /// <summary>
        /// Неявное прeобразование типа int в CRational
        /// </summary>
        /// <param name="value">Челое число</param>
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
        /// <param name="numerator">Числитель</param>
        /// <param name="denominator">Знаменатель</param>
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
        /// Получить значение рационального числа
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

        public int CompareTo(CRational other)
        {
            if (this.ToDouble() > other.ToDouble()) return 1;
            else if (this.ToDouble() < other.ToDouble()) return -1;
            else return 0;
        }

        private int Numerator { get; set; }
        private int Denominator { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            return this == (CRational)obj;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this);
        }
    }
}
