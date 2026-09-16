
namespace LAB1
{
    internal class Program
    {
        public static void Main()
        {
            int a = 0;
            int b = 0;
            int c = 0;
            Data(ref a, ref b, ref c);
            IsPositive(a, b, c);
            int perymetr = Perymetr(a, b, c);
            Area(a, b, c, perymetr);
            Type(a, b, c, perymetr);
        }
        

        public static void Data(ref int a,  ref int b, ref int c)
        {
            Console.Write("Введіть першу сторону: ");
            a = int.Parse(Console.ReadLine()); // Зчитуємо рядок
            Console.WriteLine($"Сторона а: {a}");
            Console.Write("Введіть другу сторону: ");
            b = int.Parse(Console.ReadLine()); // Зчитуємо рядок
            Console.WriteLine($"Сторона b: {b}");
            Console.Write("Введіть третю сторону: ");
            c = int.Parse(Console.ReadLine()); // Зчитуємо рядок
            Console.WriteLine($"Сторона c: {c}");
        }

        public static void IsPositive(int a, int b, int c)
        {
            if(a > 0 && b > 0 && c > 0)
            {
                Console.WriteLine("Всі сторони більші за 0");
            }
            else
            {
                Console.WriteLine("Не всі сторони більші за 0");
            }
        }

        public static bool Triangle(int a, int b, int c)
        {
            if (a + b > c && b + c > a && a + c > b)
            {
                Console.WriteLine("Створення трикутника можливе!");
                return true;
            }
            else
            {
                Console.WriteLine("Створення трикутника не можливе(");
                return false;
            }
        }

        public static int Perymetr(int a, int b, int c)
        {
            if (Triangle(a, b, c))
            {
                int perymetr = a + b + c;
                Console.WriteLine($"Периметр трикутника abc: {perymetr}");
                return perymetr;
            }
            return 0;
        }

        public static void Area(int a, int b, int c, int perymetr)
        {
            if (perymetr > 0)
            {
                double p = (double)perymetr/2;
                double area = Math.Sqrt(p*(p-a)*(p-b)*(p-c));
                Console.WriteLine($"Площа трикутника abc: {area}");
            }
            
        }

        public static void Type(int a, int b, int c, int perymetr)
        {
            if (a == b && b == c)
            {
                Console.WriteLine("Трикутник abc: Рівносторонній");
            }
            else if (a == b || a == c || b == c)
            {
                Console.WriteLine("Трикутник abc: Рівнобедрений");
            }
            else if (a * a + b * b == c * c || a * a + c * c == b * b || b * b + c * c == a * a)
            {
                Console.WriteLine("Трикутник abc: прямокутний");
            }
            else
            {
                Console.WriteLine("Трикутник abc: Різносторонній");
            }
        }
        
    }

    
}