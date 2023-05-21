using Bodies.Body;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bodies
{
    class RemoteControl
    {
        /// <summary>
        /// Создание контроллера
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <param name="bodies"></param>
        public RemoteControl(System.IO.TextReader input, System.IO.TextWriter output, ref List<CBody> bodies)
        {
            Input = input;
            Output = output;
            BodiesList = bodies;
        }

        /// <summary>
        /// Запуск программы
        /// </summary>
        public void StartProgram()
        {
            const int Exit = 9;
            const string helpLine = "Выберите:\n1 - создать конус\n2 - создать цилиндр\n3 - создать параллелепипед\n" +
                "4 - создать сферу\n5 - показать все тела\n6 - показать тело с наибольшей массой\n7 - показать тело, которое будет " +
                "легче всего весить, будучи полностью погруженным в воду\n9 - выход из программы";
            const string Error = "Ошибка, введите число";

            int command = 0;

            Output.WriteLine(helpLine);
            while (command != Exit)
            {
                Output.Write("> ");
                if (!int.TryParse(Input.ReadLine(), out command))
                {
                    Output.WriteLine(Error);
                }
                else
                {
                    Controll(command);
                }
            }
        }

        /// <summary>
        /// Контроллер
        /// </summary>
        /// <param name="command"></param>
        private void Controll(int command)
        {
            const string Error = "Такой команды не существует!";

            switch (command)
            {
                case 1:
                    {
                        CreateCone();
                        break;
                    }
                case 2:
                    {
                        CreateCylinder();
                        break;
                    }
                case 3:
                    {
                        CreateParallelepiped();
                        break;
                    }
                case 4:
                    {
                        CreateSphere();
                        break;
                    }
                case 5:
                    {
                        ShowAllBodies();
                        break;
                    }
                case 6:
                    {
                        ShowBodyWithLargestMass();
                        break;
                    }
                case 7:
                    {
                        ShowBodyWithSmallestMassInWater();
                        break;
                    }
                default:
                    {
                        Output.WriteLine(Error);
                        break;
                    }
            }
        }

        /// <summary>
        /// Создание сферы
        /// </summary>
        /// <returns></returns>
        private bool CreateSphere()
        {
            double radius, density;
            Output.WriteLine("Введите радиус тела: ");
            Output.Write("> ");
            if (!double.TryParse(Input.ReadLine(), out radius))
            {
                Output.WriteLine("Ошибка, неверный ввод радиуса!");
                return false;
            }
            Output.WriteLine("Введите плотность тела: ");
            Output.Write("> ");
            if (!double.TryParse(Input.ReadLine(), out density))
            {
                Output.WriteLine("Ошибка, неверный ввод плотности!");
                return false;
            }

            CSphere sphere = new CSphere(radius, density);

            BodiesList.Add(sphere);

            Output.WriteLine("Фигура создана");
            return true;
        }

        /// <summary>
        /// Создание цилиндра
        /// </summary>
        /// <returns></returns>
        private bool CreateCylinder()
        {
            double radius, height, density;
            Output.WriteLine("Введите радиус тела: ");
            Output.Write("> ");
            if (!double.TryParse(Input.ReadLine(), out radius))
            {
                Output.WriteLine("Ошибка, неверный ввод!");
                return false;
            }

            Output.WriteLine("Введите высоту тела: ");
            Output.Write("> ");
            if (!double.TryParse(Input.ReadLine(), out height))
            {
                Output.WriteLine("Ошибка, неверный ввод!");
                return false;
            }

            Output.WriteLine("Введите плотность тела: ");
            Output.Write("> ");
            if (!double.TryParse(Input.ReadLine(), out density))
            {
                Output.WriteLine("Ошибка, неверный ввод!");
                return false;
            }

            CCylinder cylinder = new CCylinder(radius, height, density);
            BodiesList.Add(cylinder);

            Output.WriteLine("Фигура создана");
            return true;
        }

        /// <summary>
        /// Создание Конуса
        /// </summary>
        /// <returns></returns>
        private bool CreateCone()
        {
            double radius, height, density;
            Output.WriteLine("Введите радиус тела: ");
            Output.Write("> ");
            if (!double.TryParse(Input.ReadLine(), out radius))
            {
                Output.WriteLine("Ошибка, неверный ввод!");
                return false;
            }

            Output.WriteLine("Введите высоту тела: ");
            Output.Write("> ");
            if (!double.TryParse(Input.ReadLine(), out height))
            {
                Output.WriteLine("Ошибка, неверный ввод!");
                return false;
            }

            Output.WriteLine("Введите плотность тела: ");
            Output.Write("> ");
            if (!double.TryParse(Input.ReadLine(), out density))
            {
                Output.WriteLine("Ошибка, неверный ввод!");
                return false;
            }

            CCone cone = new CCone(radius, height, density);

            BodiesList.Add(cone);

            Output.WriteLine("Фигура создана");
            return true;
        }

        /// <summary>
        /// Создание Параллелепипеда
        /// </summary>
        /// <returns></returns>
        private bool CreateParallelepiped()
        {
            double width, height, depth, density;
            Output.WriteLine("Введите ширину тела: ");
            Output.Write("> ");
            if (!double.TryParse(Input.ReadLine(), out width))
            {
                Output.WriteLine("Ошибка, неверный ввод!");
                return false;
            }
            Output.WriteLine("Введите высоту тела: ");
            Output.Write("> ");
            if (!double.TryParse(Input.ReadLine(), out height))
            {
                Output.WriteLine("Ошибка, неверный ввод!");
                return false;
            }
            Output.WriteLine("Введите глубину тела: ");
            Output.Write("> ");
            if (!double.TryParse(Input.ReadLine(), out depth))
            {
                Output.WriteLine("Ошибка, неверный ввод!");
                return false;
            }
            Output.WriteLine("Введите плотность тела: ");
            Output.Write("> ");
            if (!double.TryParse(Input.ReadLine(), out density))
            {
                Output.WriteLine("Ошибка, неверный ввод!");
                return false;
            }

            CParallelepiped parallelepiped = new CParallelepiped(width, height, depth, density);

            BodiesList.Add(parallelepiped);

            Output.WriteLine("Фигура создана");
            return true;
        }

        /// <summary>
        /// Показ всех созданных тел
        /// </summary>
        private void ShowAllBodies()
        {
            if (BodiesList.Count == 0)
            {
                Output.WriteLine("Вы не создали ни одного тела");
                return;
            }
            foreach (var body in BodiesList)
            {
                Output.WriteLine(body.ToString());
            }
        }

        /// <summary>
        /// Показ тела с наибольшей массой
        /// </summary>
        private void ShowBodyWithLargestMass()
        {
            if (BodiesList.Count == 0)
            {
                Output.WriteLine("Вы не создали ни одного тела");
                return;
            }

            CBody largestMassBody = BodiesList[0];

            for (int i = 1; i < BodiesList.Count; i++)
            {
                if (BodiesList[i].GetMass() > largestMassBody.GetMass())
                {
                    largestMassBody = BodiesList[i];
                }
            }

            Output.WriteLine("Тело с наибольшей массой: ");
            Output.WriteLine(largestMassBody.ToString());
        }

        /// <summary>
        /// Показ тела с наименьшей массой в воде
        /// </summary>
        private void ShowBodyWithSmallestMassInWater()
        {
            if (BodiesList.Count == 0)
            {
                Output.WriteLine("Вы не создали ни одного тела");
                return;
            }

            CBody smallestMassInWaterBody = BodiesList[0];

            for (int i = 1; i < BodiesList.Count; i++)
            {
                if (GetMassInWater(BodiesList[i]) > GetMassInWater(smallestMassInWaterBody))
                {
                    smallestMassInWaterBody = BodiesList[i];
                }
            }

            Output.WriteLine("Тело с наименьшей массой в воде: ");
            Output.WriteLine(smallestMassInWaterBody.ToString());
        }

        /// <summary>
        /// Рассчет массы тела в воде
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        private double GetMassInWater(CBody body)
        {
            const double g = 9.81;
            const double waterDensity = 1000;

            return (body.Density - waterDensity) * g * body.GetVolume();
        }

        private System.IO.TextReader Input { get; }
        private System.IO.TextWriter Output { get; }
        private List<CBody> BodiesList { get; }
    }
}
