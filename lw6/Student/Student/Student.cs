using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class CStudent
    {
        public CStudent(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error message: {e.Message}\nError type: {e.GetType()}");
            }
        }


        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Patronymic
        {
            get { return patronymic; }
            set { patronymic = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private string name;
        private string surname;
        private string patronymic;
        private int age;
    }
}
