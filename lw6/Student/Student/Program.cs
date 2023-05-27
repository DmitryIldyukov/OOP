using System;

namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {
            CStudent student1 = new CStudent("Name_1");
            student1.Age = 9;
            {
                CStudent student2 = new CStudent("Name_2");
                CStudent student3 = new CStudent("Name_3");
            }
            CStudent student4 = new CStudent("Name_4");
            CStudent Student5 = new CStudent("Name_5");
        }
    }
}
