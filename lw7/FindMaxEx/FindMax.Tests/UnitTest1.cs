using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace FindMax.Tests
{
    public class Tests
    {
        [Test]
        public void EmptyList()
        {
            List<int> emptyList = new List<int>();
            int maxValue = 2;
            Assert.AreEqual(ListFindMax.FindMax(emptyList, ref maxValue), false);
            Assert.AreEqual(maxValue, 2);
        }

        [Test]
        public void IntList()
        {
            int maxValue = 0;
            List<int> intList = new List<int>() { 1, 2, -10, 6, 1 };
            Assert.AreEqual(ListFindMax.FindMax(intList, ref maxValue), true);
            Assert.AreEqual(maxValue, 6);
        }

        [Test]
        public void FloatList()
        {
            List<float> floatList = new List<float>() { 1.1f, 2.2f, 9.7f, -4.4f, -5.5f };
            float maxValueFloat = 0;
            Assert.AreEqual(ListFindMax.FindMax(floatList, ref maxValueFloat), true);
            Assert.AreEqual(maxValueFloat, 9.7f);
        }

        [Test]
        public void StringList()
        {
            List<string> stringList = new List<string>() { "A", "AAAAA", "Hello", "Hella" };
            string maxValueString = String.Empty;
            Assert.AreEqual(ListFindMax.FindMax(stringList, ref maxValueString), true);
            Assert.AreEqual(maxValueString, "Hello");
        }

        [Test]
        public void ErrorList()
        {
            Person person1 = new Person(10, "Person1");
            Person person2 = new Person(20, "Person2");
            List<Person> people = new List<Person>() { person1, person2 };

            Assert.Throws<ArgumentException>(() => ListFindMax.FindMax(people, ref person1));
        }
    }
}