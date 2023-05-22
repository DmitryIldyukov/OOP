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
            const string helpLine = "Выберите:\n1 - создать тело\n2 - показать все тела\n3 - показать тело с наибольшей массой\n4 - показать тело, которое будет " +
                "легче всего весить, будучи полностью погруженным в воду\n9 - выход из программы";
            const string Error = "Ошибка, введите число";

            int command = 0;

            
            while (command != Exit)
            {
                Output.WriteLine(helpLine);

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
                        CreateBody(this.BodiesList);
                        break;
                    }
                case 2:
                    {
                        ShowAllBodies();
                        break;
                    }
                case 3:
                    {
                        ShowBodyWithLargestMass();
                        break;
                    }
                case 4:
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
        /// Создание тела
        /// </summary>
        /// <param name="bodiesList"></param>
        /// <returns></returns>
        private bool CreateBody(List<CBody> bodiesList)
        {
            const string Error = "Такой команды не существует!";

            Output.WriteLine("Выберите, какое тело хотите создать:\n1 - Конус\n2 - Цилиндр\n3 - Параллелепипед\n4 - Сфера\n5 - Составное тело\n9 - отменить создание");
            if (!int.TryParse(Input.ReadLine(), out int choise))
            {
                Output.WriteLine("Такой команды не существует");
                return false;
            }

            switch (choise)
            {
                case 1:
                    {
                        if (!CreateCone(bodiesList))
                            return false;
                        return true;
                    }
                case 2:
                    {
                        if(!CreateCylinder(bodiesList))
                            return false;
                        return true;
                    }
                case 3:
                    {
                        if (!CreateParallelepiped(bodiesList))
                            return false;
                        return true;
                    }
                case 4:
                    {
                        if(!CreateSphere(bodiesList))
                            return false;
                        return true;
                    }
                case 5:
                    {
                        if (!CreateCompoundBody(bodiesList))
                            return false;
                        return true;
                    }
                case 9:
                    {
                        return false;
                    }
                default:
                    {
                        Output.WriteLine(Error);
                        return false;
                    }
            }
        }

        /// <summary>
        /// Создание сферы
        /// </summary>
        /// <returns></returns>
        private bool CreateSphere(List<CBody> bodiesList)
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

            bodiesList.Add(sphere);

            Output.WriteLine("Фигура создана");

            return true;
        }

        /// <summary>
        /// Создание цилиндра
        /// </summary>
        /// <returns></returns>
        private bool CreateCylinder(List<CBody> bodiesList)
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
            bodiesList.Add(cylinder);

            Output.WriteLine("Фигура создана");

            return true;
        }

        /// <summary>
        /// Создание Конуса
        /// </summary>
        /// <returns></returns>
        private bool CreateCone(List<CBody> bodiesList)
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

            bodiesList.Add(cone);

            Output.WriteLine("Фигура создана");

            return true;
        }

        /// <summary>
        /// Создание Параллелепипеда
        /// </summary>
        /// <returns></returns>
        private bool CreateParallelepiped(List<CBody> bodiesList)
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

            bodiesList.Add(parallelepiped);

            Output.WriteLine("Фигура создана");

            return true;
        }

        /// <summary>
        /// Создание составного тела
        /// </summary>
        /// <param name="bodiesList"></param>
        /// <returns></returns>
        private bool CreateCompoundBody(List<CBody> bodiesList)
        {
            Output.WriteLine("Введите размер составного тела (количество тел, из которых будет состоять составное тело)");
            if (!int.TryParse(Input.ReadLine(), out int count))
            {
                Output.WriteLine("Ошибка, введите число!");
                return false;
            }

            CCompound compound = new CCompound();

            bodiesList.Add(compound);

            for (int i = 0; i < count; i++)
            {
                if (!CreateBody(compound.ListBodies))
                    return false;
            }

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

        //TODO: Действия с составным телом, выбор составного тела

        private System.IO.TextReader Input { get; }
        private System.IO.TextWriter Output { get; }
        private List<CBody> BodiesList { get; }
    }
}
