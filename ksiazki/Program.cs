using System;
using Ksiazki;

class Program
{
    static void Main(string[] args)
    {
        Menu();
    }

    static void Menu(string message = "")
    {
        Console.Clear();

        if (!string.IsNullOrEmpty(message)) Console.WriteLine(message);
        Console.WriteLine("1. Wyświetl wszystkie książki");
        Console.WriteLine("2. Wyświetl książkę");
        Console.WriteLine("3. Dodaj książkę");
        Console.WriteLine("4. Usuń książkę");
        Console.WriteLine("5. Wyjdź");

        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
        {
            Console.WriteLine("Wybierz poprawną opcję.");
        }

        switch (choice)
        {
            case 1:
                Ksiazka.ShowAll();
                Console.ReadKey();
                Menu();
                break;

            case 2:
                Console.WriteLine("Podaj ID książki, którą chcesz wyświetlić:");
                if (int.TryParse(Console.ReadLine(), out int showId))
                {
                    Ksiazka.Show(showId);
                }
                else
                {
                    Console.WriteLine("Niepoprawne ID.");
                }
                Console.ReadKey();
                Menu();
                break;

            case 3:
                Console.WriteLine("Podaj tytuł:");
                string tytul = Console.ReadLine();

                Console.WriteLine("Podaj autora:");
                string autor = Console.ReadLine();

                Console.WriteLine("Podaj rok wydania:");
                if (int.TryParse(Console.ReadLine(), out int rokWydania))
                {
                    Console.WriteLine("Podaj gatunek:");
                    string gatunek = Console.ReadLine();

                    Ksiazka.Add(tytul, autor, rokWydania, gatunek);
                    Menu("Książka dodana!");
                }
                else
                {
                    Console.WriteLine("Niepoprawny rok wydania.");
                    Menu();
                }
                break;

            case 4:
                Console.WriteLine("Podaj ID książki, którą chcesz usunąć:");
                if (int.TryParse(Console.ReadLine(), out int removeId))
                {
                    Ksiazka.Remove(removeId);
                    Menu("Książka usunięta!");
                }
                else
                {
                    Console.WriteLine("Niepoprawne ID.");
                    Menu();
                }
                break;

            case 5:
                Environment.Exit(0);
                break;
        }
    }
}
