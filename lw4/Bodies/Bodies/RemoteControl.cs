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
        const string ERROR = "Такой команды не существует!";
        const string CHOISE_LINE = "Выберите, какое тело хотите создать:\n1 - Конус\n2 - Цилиндр\n3 - Параллелепипед\n4 - Сфера\n5 - Составное тело\n9 - отменить создание";
        const string HELP_LINE = "Выберите:\n1 - создать тело\n2 - показать все тела\n3 - показать тело с наибольшей массой\n4 - показать тело, которое будет легче всего весить, будучи полностью погруженным в воду\n9 - выход из программы";
        const string ERROR_NUMBER = "Ошибка, введите число";
        const string ENTER_RADIUS_LINE = "Введите радиус тела: ";
        const string ENTER_HEIGHT_LINE = "Введите высоту тела: ";
        const string ENTER_DENSITY_LINE = "Введите плотность тела: ";
        const string ENTER_WIDTH_LINE = "Введите ширину тела: ";
        const string ENTER_DEPTH_LINE = "Введите глубину тела: ";
        const string BODY_WITH_SMALLEST_MASS_IN_WATER_MESSAGE = "Тело с наименьшей массой в воде: ";
        const string SHOW_BODY_WITH_LARGEST_MASS_MESSAGE = "Тело с наибольшей массой: ";
        const string COMPOUND_BODY_ERROR_COUNT = "Составное тело должно состоять хотя бы из одного тела";
        const string COMPOUND_BODY_GET_COUNT_MESSAGE = "Введите размер составного тела (количество тел, из которых будет состоять составное тело)";
        const string NOBODY_MESSAGE = "Вы не создали ни одного тела";
        const string ERROR_ENTERED = "Ошибка, неверный ввод!";
        const string FIGURE_CREATED_MESSAGE = "Фигура создана";
        const string ENTER_LINE = "> ";

        const int EXIT = 9;
        const int CREATE_BODY_CHOISE = 1;
        const int SHOW_ALL_BODIES_CHOISE = 2;
        const int SHOW_BODY_WITH_LARGEST_MASS_CHOISE = 3;
        const int SHOW_BODY_WITH_SMALLEST_MASS_IN_WATER_CHOISE = 4;
        const int CREATE_CONE_CHOISE = 1;
        const int CREATE_CYLINDER_CHOISE = 2;
        const int CREATE_PARALLELEPIPED_CHOISE = 3;
        const int CREATE_SPHERE_CHOISE = 4;
        const int CREATE_COMPOUND_CHOISE = 5;

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
            int command = 0;
            
            while (command != EXIT)
            {
                Output.WriteLine(HELP_LINE);

                Output.Write(ENTER_LINE);
                if (!int.TryParse(Input.ReadLine(), out command))
                {
                    Output.WriteLine(ERROR_NUMBER);
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
            switch (command)
            {
                case CREATE_BODY_CHOISE:
                    {
                        CreateBody(this.BodiesList);
                        break;
                    }
                case SHOW_ALL_BODIES_CHOISE:
                    {
                        ShowAllBodies();
                        break;
                    }
                case SHOW_BODY_WITH_LARGEST_MASS_CHOISE:
                    {
                        ShowBodyWithLargestMass();
                        break;
                    }
                case SHOW_BODY_WITH_SMALLEST_MASS_IN_WATER_CHOISE:
                    {
                        ShowBodyWithSmallestMassInWater();
                        break;
                    }
                case EXIT:
                    {
                        break;
                    }
                default:
                    {
                        Output.WriteLine(ERROR);
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
            Output.WriteLine(CHOISE_LINE);
            Output.Write(ENTER_LINE);
            if (!int.TryParse(Input.ReadLine(), out int choise))
            {
                Output.WriteLine(ERROR);
                return false;
            }

            switch (choise)
            {
                case CREATE_CONE_CHOISE:
                    {
                        if (!CreateCone(bodiesList))
                            return false;
                        return true;
                    }
                case CREATE_CYLINDER_CHOISE:
                    {
                        if(!CreateCylinder(bodiesList))
                            return false;
                        return true;
                    }
                case CREATE_PARALLELEPIPED_CHOISE:
                    {
                        if (!CreateParallelepiped(bodiesList))
                            return false;
                        return true;
                    }
                case CREATE_SPHERE_CHOISE:
                    {
                        if(!CreateSphere(bodiesList))
                            return false;
                        return true;
                    }
                case CREATE_COMPOUND_CHOISE:
                    {
                        if (!CreateCompoundBody(bodiesList))
                            return false;
                        return true;
                    }
                case EXIT:
                    {
                        return false;
                    }
                default:
                    {
                        Output.WriteLine(ERROR);
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
            Output.WriteLine(ENTER_RADIUS_LINE);
            Output.Write(ENTER_LINE);
            if (!double.TryParse(Input.ReadLine(), out radius))
            {
                Output.WriteLine(ERROR_ENTERED);
                return false;
            }
            Output.WriteLine(ENTER_DENSITY_LINE);
            Output.Write(ENTER_LINE);
            if (!double.TryParse(Input.ReadLine(), out density))
            {
                Output.WriteLine(ENTER_DENSITY_LINE);
                return false;
            }

            CSphere sphere = new CSphere(radius, density);

            bodiesList.Add(sphere);

            Output.WriteLine(FIGURE_CREATED_MESSAGE);

            return true;
        }

        /// <summary>
        /// Создание цилиндра
        /// </summary>
        /// <returns></returns>
        private bool CreateCylinder(List<CBody> bodiesList)
        {
            double radius, height, density;
            Output.WriteLine(ENTER_RADIUS_LINE);
            Output.Write(ENTER_LINE);
            if (!double.TryParse(Input.ReadLine(), out radius))
            {
                Output.WriteLine(ERROR_ENTERED);
                return false;
            }

            Output.WriteLine(ENTER_HEIGHT_LINE);
            Output.Write(ENTER_LINE);
            if (!double.TryParse(Input.ReadLine(), out height))
            {
                Output.WriteLine(ERROR_ENTERED);
                return false;
            }

            Output.WriteLine(ENTER_DENSITY_LINE);
            Output.Write(ENTER_LINE);
            if (!double.TryParse(Input.ReadLine(), out density))
            {
                Output.WriteLine(ERROR_ENTERED);
                return false;
            }

            CCylinder cylinder = new CCylinder(radius, height, density);
            bodiesList.Add(cylinder);

            Output.WriteLine(FIGURE_CREATED_MESSAGE);

            return true;
        }

        /// <summary>
        /// Создание Конуса
        /// </summary>
        /// <returns></returns>
        private bool CreateCone(List<CBody> bodiesList)
        {
            double radius, height, density;
            Output.WriteLine(ENTER_RADIUS_LINE);
            Output.Write(ENTER_LINE);
            if (!double.TryParse(Input.ReadLine(), out radius))
            {
                Output.WriteLine(ERROR_ENTERED);
                return false;
            }

            Output.WriteLine(ENTER_HEIGHT_LINE);
            Output.Write(ENTER_LINE);
            if (!double.TryParse(Input.ReadLine(), out height))
            {
                Output.WriteLine(ERROR_ENTERED);
                return false;
            }

            Output.WriteLine(ENTER_DENSITY_LINE);
            Output.Write(ENTER_LINE);
            if (!double.TryParse(Input.ReadLine(), out density))
            {
                Output.WriteLine(ERROR_ENTERED);
                return false;
            }

            CCone cone = new CCone(radius, height, density);

            bodiesList.Add(cone);

            Output.WriteLine(FIGURE_CREATED_MESSAGE);

            return true;
        }

        /// <summary>
        /// Создание Параллелепипеда
        /// </summary>
        /// <returns></returns>
        private bool CreateParallelepiped(List<CBody> bodiesList)
        {
            double width, height, depth, density;
            Output.WriteLine(ENTER_WIDTH_LINE);
            Output.Write(ENTER_LINE);
            if (!double.TryParse(Input.ReadLine(), out width))
            {
                Output.WriteLine(ERROR_ENTERED);
                return false;
            }
            Output.WriteLine(ENTER_HEIGHT_LINE);
            Output.Write(ENTER_LINE);
            if (!double.TryParse(Input.ReadLine(), out height))
            {
                Output.WriteLine(ERROR_ENTERED);
                return false;
            }
            Output.WriteLine(ENTER_DEPTH_LINE);
            Output.Write(ENTER_LINE);
            if (!double.TryParse(Input.ReadLine(), out depth))
            {
                Output.WriteLine(ERROR_ENTERED);
                return false;
            }
            Output.WriteLine(ENTER_DENSITY_LINE);
            Output.Write(ENTER_LINE);
            if (!double.TryParse(Input.ReadLine(), out density))
            {
                Output.WriteLine(ERROR_ENTERED);
                return false;
            }

            CParallelepiped parallelepiped = new CParallelepiped(width, height, depth, density);

            bodiesList.Add(parallelepiped);

            Output.WriteLine(FIGURE_CREATED_MESSAGE);

            return true;
        }

        /// <summary>
        /// Создание составного тела
        /// </summary>
        /// <param name="bodiesList"></param>
        /// <returns></returns>
        private bool CreateCompoundBody(List<CBody> bodiesList)
        {
            Output.WriteLine(COMPOUND_BODY_GET_COUNT_MESSAGE);
            Output.Write(ENTER_LINE);
            if (!int.TryParse(Input.ReadLine(), out int count))
            {
                Output.WriteLine(ERROR_ENTERED);
                return false;
            }

            if (count <= 0)
            {
                Output.WriteLine(COMPOUND_BODY_ERROR_COUNT);
                return false;
            }

            CCompound compound = new CCompound();

            bodiesList.Add(compound);

            for (int i = 0; i < count; i++)
            {
                if (!CreateBody(compound.CompoundBodies))
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
                Output.WriteLine(NOBODY_MESSAGE);
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
                Output.WriteLine(NOBODY_MESSAGE);
                return;
            }

            CBody largestMassBody = BodiesList.Aggregate((body1, body2) => body1.GetMass() > body2.GetMass() ? body1 : body2);

            Output.WriteLine(SHOW_BODY_WITH_LARGEST_MASS_MESSAGE);
            Output.WriteLine(largestMassBody.ToString());
        }

        /// <summary>
        /// Показ тела с наименьшей массой в воде
        /// </summary>
        private void ShowBodyWithSmallestMassInWater()
        {
            if (BodiesList.Count == 0)
            {
                Output.WriteLine(NOBODY_MESSAGE);
                return;
            }

            CBody smallestMassInWaterBody = BodiesList.Aggregate((body1, body2) => GetMassInWater(body1) < GetMassInWater(body2) ? body1 : body2);

            Output.WriteLine(BODY_WITH_SMALLEST_MASS_IN_WATER_MESSAGE);
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

        public System.IO.TextReader Input { get; }
        public System.IO.TextWriter Output { get; }
        public List<CBody> BodiesList { get; }
    }
}