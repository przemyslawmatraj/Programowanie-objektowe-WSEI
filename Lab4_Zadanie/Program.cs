using System;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace Lab4_excercise
{
    enum Direction8
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        UP_LEFT,
        DOWN_LEFT,
        UP_RIGHT,
        DOWN_RIGHT
    }

    enum Direction4
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    class App
    {
        private static (int, int) p;

        public static void Main(string[] args)
        {
            Console.WriteLine("Zadanie 1:");
            Exercise1 exercise1 = new Exercise1();
            var point2 = exercise1.NextPoint(Direction4.DOWN, (0, 0), (800, 600));
            Console.WriteLine(point2.Item1 + " " + point2.Item2);
            // Zadanie 2
            Console.WriteLine("Zadanie 2:");
            Exercise2 exercise2 = new Exercise2();
            exercise2.StartTest();
            // Zadanie 3
            Console.WriteLine("Zadanie 3:");
            Exercise3 exercise3 = new Exercise3();
            exercise3.StartTest();
            // Zadanie 4
            Console.WriteLine("Zadanie 4:");
            Exercise4 exercise4 = new Exercise4();
            exercise4.StartTest();
        }
    }

    class Exercise1
    {
        public (int, int) NextPoint(Direction4 direction, (int, int) point, (int, int) screenSize)
        {
            int directionX = point.Item1;
            int directionY = point.Item2;
            int width = screenSize.Item1;
            int height = screenSize.Item2;
            switch (direction)
            {
                case Direction4.UP:
                    directionY--;
                    break;
                case Direction4.DOWN:
                    directionY++;
                    break;
                case Direction4.LEFT:
                    directionX--;
                    break;
                case Direction4.RIGHT:
                    directionX++;
                    break;
            }
            if (directionX < 0 || directionX > width || directionY < 0 || directionY > height)
            {
                return point;
            }
            return (directionX, directionY);
        }
    }

    class Exercise2
    {
        static int[,] screen =
        {
        {1, 0, 0},
        {0, 0, 0},
        {0, 0, 0}
    };

        private static (int, int) point = (0, 1);

        private Direction8 direction = DirectionTo(screen, point, 1);

        public static Direction8 DirectionTo(int[,] screen, (int, int) point2, int value)
        {
            int directionX = point2.Item1;
            int directionY = point2.Item2;
            int width = screen.GetLength(0);
            int height = screen.GetLength(1);
            if (directionX + 1 < width && screen[directionX + 1, directionY] == value)
            {
                return Direction8.RIGHT;
            }
            if (directionX - 1 >= 0 && screen[directionX - 1, directionY] == value)
            {
                return Direction8.LEFT;
            }
            if (directionY + 1 < height && screen[directionX, directionY + 1] == value)
            {
                return Direction8.DOWN;
            }
            if (directionY - 1 >= 0 && screen[directionX, directionY - 1] == value)
            {
                return Direction8.UP;
            }
            if (directionX + 1 < width && directionY + 1 < height && screen[directionX + 1, directionY + 1] == value)
            {
                return Direction8.DOWN_RIGHT;
            }
            if (directionX + 1 < width && directionY - 1 >= 0 && screen[directionX + 1, directionY - 1] == value)
            {
                return Direction8.UP_RIGHT;
            }
            if (directionX - 1 >= 0 && directionY + 1 < height && screen[directionX - 1, directionY + 1] == value)
            {
                return Direction8.DOWN_LEFT;
            }
            if (directionX - 1 >= 0 && directionY - 1 >= 0 && screen[directionX - 1, directionY - 1] == value)
            {
                return Direction8.UP_LEFT;
            }
            return Direction8.UP;
        }
        public void StartTest()
        {
            Console.WriteLine(direction);
        }
    }


    record Car(string Model = "Audi", bool HasPlateNumber = false, int Power = 100);

    class Exercise3
    {

        public static int CarCounter(Car[] cars)
        {
            Dictionary<string, int> carCounter = new Dictionary<string, int>();
            foreach (var car in cars)
            {
                if (carCounter.ContainsKey(car.Model.ToString() + car.HasPlateNumber.ToString() + car.Power.ToString()))
                {
                    carCounter[car.Model.ToString() + car.HasPlateNumber.ToString() + car.Power.ToString()]++;
                }
                else
                {
                    carCounter.Add(car.Model.ToString() + car.HasPlateNumber.ToString() + car.Power.ToString(), 1);
                }
            }
            return carCounter.Values.Max();
        }
        public static Car[] _cars = new Car[]
        {
                new Car(),
                new Car(Model: "Fiat", true),
                new Car(),
                new Car(Power: 100),
                new Car(Model: "Fiat", true),
                new Car(Power: 125),
                new Car()
        };
        private int result = CarCounter(_cars);
        public void StartTest()
        {
            Console.WriteLine(result);
        }
    }

    record Student(string LastName, string FirstName, char Group, string StudentId = "");

    class Exercise4
    {
        public static Student[] students = {
                                    new Student("Nowak","Ewa", 'C'),
                        new Student("Kowal","Adam", 'A'),
                        new Student("Nowak","Ewa2", 'A'),
                        new Student("Nowak","Ewa3", 'B'),
                        new Student("Nowak","Ewa4", 'C'),
                        new Student("Nowak","Ewa5", 'B')
                      };

        public static void AssignStudentId(Student[] students)
        {
            Dictionary<string, int> Groups = new Dictionary<string, int>();
            string[] temp = new string[students.Length];
            int i = 0;
            foreach (var student in students)
            {

                if (Groups.ContainsKey(student.Group.ToString()))
                {
                    Groups[student.Group.ToString()]++;
                }
                else
                {
                    Groups.Add(student.Group.ToString(), 1);
                }
                temp[i] = $"{student.LastName} {student.FirstName} '{student.Group}' - '{student.Group}{Groups[student.Group.ToString()].ToString("D3")}'";
                i++;
            }
            foreach (var s in temp)
            {
                Console.WriteLine(s);
            }
        }

        internal void StartTest()
        {
            AssignStudentId(students);
        }
    }
}
