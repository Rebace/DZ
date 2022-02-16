using DZ_Ellipse;

class Program
{
    public static void Main(string[] args)
    {
        int verticalRadius = 10;
        int horizontalRadius = 5;

        try
        {
            Ellipse ellipse = new Ellipse(verticalRadius, horizontalRadius);
            Console.WriteLine($"Площадь эллипса: {ellipse.GetSquare()}");
            Console.WriteLine($"Длина эллипса: {ellipse.GetLength()}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
