using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // prosimy usera o podanie liczby i sprawdzamy konwesje
        Console.WriteLine("Podaj dodatnią liczbę całkowitą:");
        string input = Console.ReadLine();

        if (long.TryParse(input, out long number))
        {
            // wywołanie funkcji nextsmaller
            long result = nextSmaller(number);

            // wyswietla odpoiedź
            if (result != -1)
            {
                Console.WriteLine("Kolejna mniejsza liczba z tymi samymi cyframi: " + result);
            }
            else
            {
                Console.WriteLine("Nie ma kolejnej mniejszej liczby z tymi samymi cyframi.");
            }
        }
        else
        {
            // ostrzezenie dla błędnej liczby
            Console.WriteLine("Błędny format liczby. Podaj dodatnią liczbę całkowitą.");
        }
    }

    // def funkcji
    static long nextSmaller(long n)
    {
        char[] digits = n.ToString().ToCharArray();
        if (digits.Length == 1)
        {
            return -1;
        }
        int index = digits.Length - 1;
        while (index > 0 && digits[index - 1] <= digits[index])
        {
            index--;
        }
        if (index == 0)
        {
            return -1;
        }
        int smallerDigitIndex = digits.Length - 1;
        while (digits[smallerDigitIndex] >= digits[index - 1])
        {
            smallerDigitIndex--;
        }
        char temp = digits[index - 1];
        digits[index - 1] = digits[smallerDigitIndex];
        digits[smallerDigitIndex] = temp;
        Array.Sort(digits, index, digits.Length - index);

        long result = long.Parse(new string(digits));
        return result; //wynik
    }
}
