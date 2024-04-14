using System.Threading;

namespace Labirintus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] labs = { "Lab1.txt", "Lab2.txt" };

            foreach (string lab in labs)
            {
                LabSim lab1 = new LabSim(lab);
                Console.CursorVisible = false;
                Console.Clear();

                Console.WriteLine("\n 5. feladat: Labirintus adatai");
                Console.WriteLine($"\tSorok száma: {lab1.SorokSzama}");
                Console.WriteLine($"\tOszlopok száma: {lab1.OszlopokSzama}");
                Console.WriteLine($"\tKijárat indexe: " +
                    $"sor:{lab1.KijaratSorIndex} oszlop:{lab1.KijaratOszlopIndex}");
                Console.WriteLine("\n 6. feladat: A labirintus");
                lab1.KiirLab(true);
                Thread.Sleep(1000);
                lab1.Utkereses();

                string eredmeny = lab1.KeresesKesz
                    ? "Útvonal megtalálva!" : "Nincs megoldás!";

                lab1.KiirLab();
                Console.WriteLine($"\n 8. feladat: {eredmeny}");
                Console.ReadLine();
            }
        }
    }
}
