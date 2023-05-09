using System.Diagnostics.Metrics;

namespace _convert_number
{
// Создайте структуру «Десятичное число».
// Определите внутри неё необходимые поля и методы.
// Реализуйте следующую функциональность:
// ■ Перевод числа в двоичную систему;
// ■ Перевод числа в восьмеричную систему;
// ■ Перевод числа в шестнадцатеричную систему.
    internal class Program
    {
        static void Main(string[] args)
        {
            DecimalNum obj = new DecimalNum();
            Console.WriteLine("Bin " + obj.ToBinary());
            Console.WriteLine("Oct " + obj.ToOct());
            Console.WriteLine("Hex " + obj.ToHex());
        }
    }
    struct DecimalNum
    {
        decimal my_num;

        public DecimalNum(decimal val)
        {
            my_num = val;
        }

        public DecimalNum()
        {
            Console.WriteLine("Enter your number:");
            my_num = Convert.ToDecimal(Console.ReadLine());
        }

        public string ToBinary()
        {
            return (Convert.ToString((long)my_num, 2));
        }

        public string ToOct()
        {
            return (Convert.ToString((long)my_num, 8));
        }

        public string ToHex()
        {
            return ((UInt64)my_num).ToString("X");
        }
    }
}