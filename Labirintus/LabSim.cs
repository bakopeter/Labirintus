using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Labirintus
{
    internal class LabSim
    {
        List<string> Adatsorok;
        char[,] Lab;

        bool keresesKesz;
        bool nincsMegoldas;

        int oszlopokSzama;
        int sorokSzama;
        int kijaratOszlopIndex;
        int kijaratSorIndex;

        public bool KeresesKesz { get => keresesKesz; set => keresesKesz = value; }
        public bool NincsMegoldas { get => nincsMegoldas; set => nincsMegoldas = value; }

        public int OszlopokSzama { get => oszlopokSzama; private set => oszlopokSzama = value; }
        public int SorokSzama { get => sorokSzama; private set => sorokSzama = value; }
        public int KijaratOszlopIndex { get => kijaratOszlopIndex; private set => kijaratOszlopIndex = value; }
        public int KijaratSorIndex { get => kijaratSorIndex; private set => kijaratSorIndex = value; }

        private void BeolvasasAdatsorok(string forras)
        {
            StreamReader sr = new StreamReader(forras);
            while (!sr.EndOfStream)
            {
                Adatsorok.Add(sr.ReadLine());
            }
            sr.Close();
        }
        private void FeltoltLab() 
        { 
            for (int i = 0; i < SorokSzama; i++)
            {
                for (int j = 0; j < OszlopokSzama; j++)
                {
                    Lab[i, j] = Adatsorok[i][j];
                }
            }
        }
        public void KiirLab(bool torol = false)
        {
            (int leftPos, int topPos) = Console.GetCursorPosition();
            for (int i = 0; i < SorokSzama; i++)
            {
                Console.Write("\t");
                for(int j = 0; j < OszlopokSzama; j++)
                {
                    Console.Write(Lab[i, j]);
                }
                Console.WriteLine();
            }
            if (torol) {
                Console.SetCursorPosition(leftPos, topPos);
            }
        }
        public LabSim(string forras)
        {
            this.Adatsorok = new List<string>();
            BeolvasasAdatsorok(forras);
            
            SorokSzama = Adatsorok.Count();
            OszlopokSzama = Adatsorok[0].Length;
            KijaratSorIndex = SorokSzama -2;
            KijaratOszlopIndex = OszlopokSzama -1;

            Lab = new char[SorokSzama, OszlopokSzama];
            FeltoltLab();
        }
        public void Utkereses()
        {
            KeresesKesz = false;
            NincsMegoldas = false;
            int r = 1;
            int c = 0;

            while (!KeresesKesz && !NincsMegoldas)
            {
                Lab[r, c] = 'O';
                if (Lab[r, c+1] == ' ') {
                    c++;
                } else if (Lab[r+1, c] == ' ') {
                    r++;
                } else {
                    Lab[r, c] = '-';
                    if (Lab[r, c-1] == 'O') {
                        c--;
                    } else {
                        r--;
                    }
                }
                KeresesKesz = (r == KijaratSorIndex && c == KijaratOszlopIndex);
                if (KeresesKesz) { Lab[r, c] = 'O'; }
                NincsMegoldas = (r == 1 && c == 0);
                KiirLab(true);
                Thread.Sleep(200);
            }
        } 
    }
}
