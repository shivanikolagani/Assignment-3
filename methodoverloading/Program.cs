namespace methodoverloading
{
    public class Source
    {
        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }
        public double Add(double a, double b, double c)
        {
            return a + b + c;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Source numbers = new Source();

            int IntResult = numbers.Add(100, 200, 300);
            Console.WriteLine(IntResult);
            double doubleResult = numbers.Add(2.4, 4.5, 42.3);
            Console.WriteLine(doubleResult);
        }
    }
}
