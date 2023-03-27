using System;
using System.Collections.Generic;
using System.IO;

public class Polynomial
{
    private readonly List<double> Coefficients;

    public Polynomial()
    {
        Coefficients = new List<double>();
    }

    public Polynomial(List<double> coefficients)
    {
        Coefficients = coefficients;
    }

    public static Polynomial BuildPolynomial(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var coefficients = new List<double>();
        
        foreach (var line in lines)
        {
            var parts = line.Split(' ');
            if (parts.Length != 2)
            {
                throw new FormatException($"Invalid line format: {line}");
            }
            
            if (!double.TryParse(parts[0], out var coefficient))
            {
                throw new FormatException($"Invalid coefficient: {parts[0]}");
            }
            
            if (!int.TryParse(parts[1], out var degree))
            {
                throw new FormatException($"Invalid degree: {parts[1]}");
            }
            
            while (coefficients.Count <= degree)
            {
                coefficients.Add(0);
            }
            
            coefficients[degree] = coefficient;
        }
        
        return new Polynomial(coefficients);
    }

    public override string ToString()
    {
        var terms = new List<string>();

        for (var i = Coefficients.Count - 1; i >= 0; i--)
        {
            if (Coefficients[i] == 0)
            {
                continue;
            }

            var term = "";
            if (i > 1)
            {
                term += $"{Coefficients[i]}x^{i}";
            }
            else if (i == 1)
            {
                term += $"{Coefficients[i]}x";
            }   
            else
            {
                term += $"{Coefficients[i]}";
            }
            terms.Add(term);
        }

        return string.Join(" + ", terms);
    }

    public void Insert(double coefficient, int degree)
    {
        if (degree < 0)
        {
            throw new ArgumentException("Degree must be non-negative.", nameof(degree));
        }

        while (Coefficients.Count <= degree)
        {
            Coefficients.Add(0);
        }

        var currentCoefficient = Coefficients[degree];
        Coefficients[degree] = currentCoefficient + coefficient;

        while (Coefficients.Count > 1 && Coefficients[Coefficients.Count - 1] == 0)
        {
            Coefficients.RemoveAt(Coefficients.Count - 1);
        }
    }


    public void Sum(Polynomial other)
    {
        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        int degree = Math.Max(Coefficients.Count, other.Coefficients.Count);
        for (int i = 0; i < degree; i++)
        {
            double coeff1 = (i < Coefficients.Count) ? Coefficients[i] : 0;
            double coeff2 = (i < other.Coefficients.Count) ? other.Coefficients[i] : 0;
            Coefficients[i] = coeff1 + coeff2;
        }

        while (Coefficients.Count > 1 && Coefficients[Coefficients.Count - 1] == 0)
        {
            Coefficients.RemoveAt(Coefficients.Count - 1);
        }
    }

    public void Derive()
    {
        if (Coefficients.Count <= 1)
        {
            Coefficients.Clear();
            Coefficients.Add(0);
        }
        else
        {
            for (int i = 1; i < Coefficients.Count; i++)
            {
                Coefficients[i - 1] = i * Coefficients[i];
            }
            Coefficients.RemoveAt(Coefficients.Count - 1);
        }
    }

    public double Value(int x)
    {
        double result = 0;
        for (int i = Coefficients.Count - 1; i >= 0; i--)
        {
            result = Coefficients[i] + (x * result);
        }
        return result;
    }

}
