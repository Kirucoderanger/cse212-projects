using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n======================\nDuplicate Counter\n======================");
        DuplicateCounter.Run();
        Console.WriteLine("\n======================\nDuplicate Counter Solution\n======================");
        DuplicateCounterSolution.Run();

        Console.WriteLine("\n======================\nTranslator\n======================");
        Translator.Run();
        Console.WriteLine("\n======================\nTranslator Solution\n======================");
        TranslatorSolution.Run();
    }
}