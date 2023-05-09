using System.Runtime.CompilerServices;

namespace dz_struct
{
    // Задание 1
    // Создайте структуру «Трёхмерный вектор». Определите внутри неё необходимые поля и методы.
    // Реализуйте следующую функциональность:
    //     ■ Умножение вектора на число;
    //     ■ Сложение векторов;
    //     ■ Вычитание векторов.
    internal class struct_vector
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;   // переменная key для считывания нажатой клавиши                                
            do                    // заход в цикл
            {
                Console.Clear();  // очистка консоли
                Show_menu();      // вывод в консоль меню
                
                key = Console.ReadKey();    // считываем нажатую клавишу
                switch (key.Key)            // в зависимости от того, какая клавиша нажата (Key Возвращает клавишу консоли)
                {
                    case (ConsoleKey.D1):   // если нажата клавиша 1 - выполняем сложение векторов
                        Console.ReadKey();  // считывание клавиши
                        
                        Console.WriteLine("Enter first vector values for addition" +
                           "(3 integer digits with an 'enter' key)");
                        // считываем вводимые пользователем значения 1го вектора, конвертируем в инт:
                        int a1 = int.Parse(Console.ReadLine()); 
                        int b1 = int.Parse(Console.ReadLine());
                        int c1 = int.Parse(Console.ReadLine());
                        Vector vector1 = new Vector(a1, b1, c1);  // создание 1го объекта вектор

                        Console.WriteLine("Enter second vector values for addition" +
                            "(3 integer digits with an 'enter' key)");
                        // считываем вводимые пользователем значения 2го вектора, конвертируем в инт:
                        int a2 = int.Parse(Console.ReadLine());
                        int b2 = int.Parse(Console.ReadLine());
                        int c2 = int.Parse(Console.ReadLine());
                        Vector vector2 = new Vector(a2, b2, c2);  // создание 2го объекта вектор

                        vector1.Show("\nYour vector: ");                // вывод в консоль 1го вектора
                        vector2.Show("Your vector: ");                  // вывод в консоль 2го вектора
                        vector1.Add_vectors(vector2);                   // вызов метода Сложение векторов
                        vector1.Show("Your vectors after addition: ");  // вывод в консоль результата
                        Console.WriteLine("To continue - press any key");
                        Console.ReadKey();                              //  считывание нажатия любой клавиши
                   break;
                                     
                   case (ConsoleKey.D2):    // если нажата клавиша 2 выполняем вычитание векторов
                        Console.ReadKey();  // считывание клавиши
                        
                        Console.WriteLine("Enter first vector values for subtraction" +
                           "(3 integer digits with an 'enter' key)");
                        // считываем вводимые пользователем значения 1го вектора, конвертируем в инт
                        int a3 = int.Parse(Console.ReadLine());
                        int b3 = int.Parse(Console.ReadLine());
                        int c3 = int.Parse(Console.ReadLine());
                        Vector vector3 = new Vector(a3, b3, c3);  // создание 1го объекта вектор

                        Console.WriteLine("Enter second vector values for subtraction" +
                          "(3 integer digits with an 'enter' key)");
                        // считываем вводимые пользователем значения 2го вектора, конвертируем в инт
                        int a4 = int.Parse(Console.ReadLine());
                        int b4 = int.Parse(Console.ReadLine());
                        int c4 = int.Parse(Console.ReadLine());
                        Vector vector4 = new Vector(a4, b4, c4);  // создание 2го объекта вектор
                       
                        vector3.Show("Your vector: ");                    // вывод в консоль 1го вектора
                        vector4.Show("Your vector: ");                    // вывод в консоль 2го вектора
                        vector3.Sub_vectors(vector4);                     // вызов метода Вычитание векторов
                        vector3.Show("Your vector after subtraction: ");  // вывод в консоль результата
                        Console.WriteLine("To continue - press any key");
                        Console.ReadKey();                                //  считывание нажатия любой клавиши
                    break;

                    case (ConsoleKey.D3):   // если нажата клавиша 3 выполняем умножение вектора на число
                        Console.ReadKey();  // считывание клавиши
                        
                        Console.WriteLine("Enter your vector values (3 integer digits with a space)" +
                        "and then press 'Enter' \n - Example: 1space2space3enter ");

                        // здесь использован метод Split, для того, что бы считать сразу три введенных значения
                        string[] arr = Console.ReadLine().Split();  // создаем массив строк с помощью строки, введенной в консоль,
                                                                    // которую метод Split по пробелам разбивает на отдельные строки
                        int a = int.Parse(arr[0]);                  // первое значение вектора, конвертированное в инт
                        int b = int.Parse(arr[1]);                  // второе значение вектора, конвертированное в инт
                        int c = int.Parse(arr[2]);                  // третье значение вектора, конвертированное в инт
                        Vector vector = new Vector(a, b, c);        // создание объекта вектор

                        Console.WriteLine("Enter number to multiplicate your vector: ");
                        int x = int.Parse(Console.ReadLine());      // ввод числа для умножения
                        vector.Show("Your vector: ");               // вывод вектора в консоль

                        vector.Mult_by_num(x);                              // вызов метода Умножение вектора на число
                        vector.Show("Your vector after multiplication: ");  // вывод в консоль редультата
                        Console.WriteLine("To continue - press any key");
                        Console.ReadKey();                                  //  считывание нажатия любой клавиши
                    break;
                }
            } while (key.Key!=ConsoleKey.Escape);  // выход из цикла, если нажата клавиша Escape
        }

        public static void Show_menu()  // метод для вывода в консоль меню
        {
            Console.WriteLine("\tVectors. \nWhat do you want to do?");
            Console.WriteLine("************************************");
            Console.WriteLine("1. Addition of vectors.");
            Console.WriteLine("2. Subtraction of vectors.");
            Console.WriteLine("3. Multiply the vector by a number.");
            Console.WriteLine("\nEnter 1, 2 or 3 and press 'Enter'. \nTo exit - press 'Escape'.");
            Console.WriteLine("************************************");
        }      
    }

    struct Vector                            // структура вектор
    {
        private int x, y, z;                 // поля структуры - значения вектора
        public Vector (int x, int y, int z)  // консруктор с параметрами
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public void Show(string massage)     // метод для вывода вектора в консоль
        {
            Console.WriteLine($"{massage} {{ {x}, {y}, {z} }}");
        }
        public void Mult_by_num(int num)     // метод для умножения вектора на число
        {
            x = num*x;
            y = num*y;
            z = num*z;
        }
        public void Add_vectors(Vector obj)  // метод для сложения векторов
        {
            x += obj.x;
            y += obj.y;
            z += obj.z;
        }
        public void Sub_vectors(Vector obj)  // метод для вычитания векторов
        {
            x -= obj.x;
            y -= obj.y;
            z -= obj.z;
        }
    }
}