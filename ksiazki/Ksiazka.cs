using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Ksiazki
{
    public class Ksiazka
    {
        public int Id { get; set; }
        public string Tytul { get; set; }
        public string Autor { get; set; }
        public int RokWydania { get; set; }
        public string Gatunek { get; set; }

        static List<Ksiazka> ksiazki = new List<Ksiazka>();
        static string path = "ksiazki.json";

        static Ksiazka()
        {
            if (File.Exists(path))
            {
                ksiazki = JsonSerializer.Deserialize<List<Ksiazka>>(File.ReadAllText(path));
            }
        }

        public static void SaveData()
        {
            File.WriteAllText(path, JsonSerializer.Serialize(ksiazki));
        }

        public static bool Exists(int id)
        {
            return ksiazki.Any(k => k.Id == id);
        }

        public static void Add(string tytul, string autor, int rokWydania, string gatunek)
        {
            int newId = ksiazki.Count > 0 ? ksiazki.Max(k => k.Id) + 1 : 1;
            ksiazki.Add(new Ksiazka
            {
                Id = newId,
                Tytul = tytul,
                Autor = autor,
                RokWydania = rokWydania,
                Gatunek = gatunek
            });
            SaveData();
        }

        public static void Remove(int id)
        {
            if (!Exists(id))
            {
                Console.WriteLine("Ksiazka nie istnieje.");
                return;
            }

            ksiazki.RemoveAll(k => k.Id == id);
            NormalizeIds();
            SaveData();
        }

        public static void NormalizeIds()
        {
            for (int i = 0; i < ksiazki.Count; i++)
            {
                ksiazki[i].Id = i + 1;
            }
        }

        public static void Show(int id)
        {
            if (!Exists(id))
            {
                Console.WriteLine("Ksiazka nie istnieje.");
                return;
            }

            Ksiazka k = ksiazki.Find(k => k.Id == id);
            Info(k);
        }

        public static void ShowAll()
        {
            foreach (var k in ksiazki)
            {
                Console.WriteLine($"{k.Id} | {k.Tytul}");
            }
        }

        public static void Info(Ksiazka k)
        {
            Console.WriteLine($"ID: {k.Id}");
            Console.WriteLine($"Tytul: {k.Tytul}");
            Console.WriteLine($"Autor: {k.Autor}");
            Console.WriteLine($"Rok Wydania: {k.RokWydania}");
            Console.WriteLine($"Gatunek: {k.Gatunek}");
        }
    }
}
