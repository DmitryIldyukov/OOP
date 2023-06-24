using NUnit.Framework;
using Student;
using System;

namespace StudentNUnitTests
{
    public class Tests
    {
        [Test]
        public void CreateGoodStudent()
        {
            CStudent student = new CStudent("Dmitry", "Ildyukov", "Yuryevich", 20);
            Assert.AreEqual(student.ToString(), "Имя: Dmitry\nФамилия: Ildyukov\nОтчество: Yuryevich\nВозраст: 20");
        }

        [Test]
        public void IncorrectArgumentEmptyName()
        {
            Assert.Throws<ArgumentNullException>(() => new CStudent("", "Ildyukov", "Yuryevich", 20));
        }

        [Test]
        public void IncorrectArgumentExceptionNameWithSpaces()
        {
            Assert.Throws<ArgumentException>(() => new CStudent("Dm itry", "Ildyukov", "Yuryevich", 20));
        }

        [Test]
        public void IncorrectArgumentEmptySurame()
        {
            Assert.Throws<ArgumentNullException>(() => new CStudent("Dmitry", "", "Yuryevich", 20));
        }

        [Test]
        public void IncorrectArgumentExceptionSurnameWithSpaces()
        {
            Assert.Throws<ArgumentException>(() => new CStudent("Dmitry", "Il dyu kov", "Yuryevich", 20));
        }

        [Test]
        public void IncorrectArgumentExceptionPatronymicWithSpaces()
        {
            Assert.Throws<ArgumentException>(() => new CStudent("Dmitry", "Ildyukov", "Yu rye vich", 20));
        }

        [Test]
        public void IncorrectArgumentExceptionAgeDown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new CStudent("Dmitry", "Ildyukov", "Yuryevich", 0));
        }

        [Test]
        public void IncorrectArgumentExceptionAgeUp()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new CStudent("Dmitry", "Ildyukov", "Yuryevich", 70));
        }

        [Test]
        public void IncorrentArgumentExceptionCommitOrRollback()
        {
            CStudent student = new CStudent("Dmitry", "Ildyukov", "Yuryevich", 20);
            CStudent correctStudent = new CStudent("Dmitry", "Ildyukov", "Yuryevich", 20);

            try
            {
                student.Rename("Dmitry", "Ildyukov", "Yu rye vich");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

            Assert.AreEqual(student.ToString(), correctStudent.ToString());
        }
    }
}