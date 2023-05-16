using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of items: ");
        int n = int.Parse(Console.ReadLine());

        int[] A = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter the value of item {i + 1}: ");
            A[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(A);



        // median ----> p50
        double c = (double)(n + 1) / 2;
        int b = (n + 1) / 2;
        double u = c - b;
        double median = A[b - 1] + u * (A[b] - A[b - 1]);
        Console.WriteLine($"Median: {median}");



        // mode
        int mode = 0;
        int count = 0;
        int mode2 = 0;
        int count2 = 0;
        for (int i = 0; i < n; i++)
        {
            int frequency = 0;
            for (int j = 0; j < n; j++)
            {
                if (A[j] == A[i])
                {
                    frequency++;
                }
            }
            if (frequency > count)
            {
                count = frequency;
                mode = A[i];
            }
            else if (frequency == count)
            {
                count2 = frequency;
                mode2 = A[i];
            }

        }

        if (mode == A[0] && count == 1)
        {
            Console.WriteLine("no mode");
        }
        else
        {
            if (count == count2)
            {
                Console.WriteLine($"Mode: {mode} , {mode2}");

            }
            else
            {
                Console.WriteLine($"Mode: {mode}");
            }
        }




        // range 
        int range = A[n - 1] - A[0];
        Console.WriteLine($"Range: {range}");



        // q1 ----> p25 , q3 ----> p75 , q4 ----> p90  
        c = (double)(n + 1) / 4;
        b = (n + 1) / 4;
        u = c - b;
        double q1 = A[b - 1] + u * (A[b] - A[b - 1]);
        Console.WriteLine($"First Quartile: {q1}");
        c = (double)3 * (n + 1) / 4;
        b = 3 * (n + 1) / 4;
        u = c - b;
        double q3 = A[b - 1] + u * (A[b] - A[b - 1]);
        Console.WriteLine($"Third Quartile: {q3}");
        c = (double)9 * (n + 1) / 10;
        b = 9 * (n + 1) / 10;
        u = c - b;
        double p90 = A[b - 2] + u * (A[b - 1] - A[b - 2]);
        Console.WriteLine($"P90: {p90}");



        //iqr
        double iqr = q3 - q1;
        Console.WriteLine($"Interquartile range: {iqr}");



        // outlier
        double lowerBoundary = (q1 - (1.5 * iqr));
        double upperBoundary = (q3 + (1.5 * iqr));
        Console.WriteLine($"Lower outlier boundary: {lowerBoundary}");
        Console.WriteLine($"Upper outlier boundary: {upperBoundary}");
        Console.Write("Enter a value to check for outlier: ");
        int x = int.Parse(Console.ReadLine());
        if (x < lowerBoundary || x > upperBoundary)
        {
            Console.WriteLine($"{x} is an outlier.");
        }
        else
        {
            Console.WriteLine($"{x} is not an outlier.");
        }
    }
}