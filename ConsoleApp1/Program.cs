using System;

namespace ConsoleApp1
{
    public class Pair<T, U>
    {
        public Pair()
        {
        }

        public Pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }
        public Pair(Pair<T, U> arg)
        {
            this.First = arg.First;
            this.Second = arg.Second;
        }

        public T First { get; set; }
        public U Second { get; set; }
    }
    internal class Program
    {
        static int counter = 0;
        const double eps = 0.0001;
        const double step = 0.2;

        static void Main(string[] args)
        {
            var startPoint = new Pair<double, double>(0, 0);
            var endPoint = GradDown(startPoint);

            Console.WriteLine($"Для функции 3*(x1 - 3)^2 + 3*(x3 - 3)^2 + 3 был найден минимум: " +
                $"({Math.Round(endPoint.First, 4)},{Math.Round(endPoint.Second, 4)})" +
                $"\n(оптимальная точка без округления = ({endPoint.First},{endPoint.Second}) )" +
                $"\nПри начальной точке = ({startPoint.First},{startPoint.Second})" +
                $"\nЧисло выполненных итераций = {counter}" +
                $"\nДля этого был задан шаг = {step}" +
                $"\nТочность E = {eps}");
        }

        static Pair<double, double> CalsGradient(double x1, double x2)
        {
            Pair<double, double> grad = new();

            grad.First = 6 * x1 - 18;
            grad.Second = 6 * x2 - 18;

            return grad;
        }
        static Pair<double, double> GradDown(Pair<double, double> x)
        {
            Pair<double, double> current = new(x);
            Pair<double, double> last;
            Pair<double, double> grad;

            do
            {
                counter++;
                last = current;

                grad = CalsGradient(last.First, last.Second);
                current.First = last.First - step * grad.First;
                current.Second = last.Second - step * grad.Second;

                grad = CalsGradient(current.First, current.Second);

            } while (Math.Abs(grad.First) > eps || Math.Abs(grad.Second) > eps);

            return current;
        }
    }
}