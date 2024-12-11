using System;
using System.Numerics;

class KaratsubaAlgorithm
{
    public static BigInteger Karatsuba(BigInteger x, BigInteger y)
    {
        if (x < 10 || y < 10)
            return x * y;

        int n = Math.Max(x.ToString().Length, y.ToString().Length);
        int half = n / 2;

        BigInteger x1 = x / BigInteger.Pow(10, half);
        BigInteger x0 = x % BigInteger.Pow(10, half);
        BigInteger y1 = y / BigInteger.Pow(10, half);
        BigInteger y0 = y % BigInteger.Pow(10, half);

        BigInteger z2 = Karatsuba(x1, y1);
        BigInteger z0 = Karatsuba(x0, y0);
        BigInteger z1 = Karatsuba(x1 + x0, y1 + y0) - z2 - z0;

        return z2 * BigInteger.Pow(10, 2 * half) + z1 * BigInteger.Pow(10, half) + z0;
    }

    public static void TestKaratsuba()
    {
        var testCases = new (BigInteger, BigInteger)[]
        {
            (1234, 5678),
            (123456789, 987654321),
            (BigInteger.Parse("123456789123456789"), BigInteger.Parse("987654321987654321")),
            (BigInteger.Parse("999999999999999999"), BigInteger.Parse("999999999999999999"))
        };

        foreach (var (x, y) in testCases)
        {
            BigInteger expected = x * y;
            BigInteger result = Karatsuba(x, y);
            Console.WriteLine($"x = {x}, y = {y}");
            Console.WriteLine($"Expected: {expected}");
            Console.WriteLine($"Karatsuba Result: {result}");
            Console.WriteLine(result == expected ? "Test Passed!" : "Test Failed!");
            Console.WriteLine();
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Testing Karatsuba Algorithm...");
        TestKaratsuba();
    }
}
