using System;

namespace projekt_KalkulatorBinarny
{
    class Program
    {
        static string wyjscie = "wyjscie";
        static string error = "błędna wartość";
        static string other_DEC = "na sys dec";
        static string DEC_other = "dec na sys";

        static string wczytaj_Tekst(string komunikat)
        {
            Console.WriteLine(komunikat);
            return Console.ReadLine();

        }
        static int wczytaj_Liczbe(string komunikat)
        {
            int wynik;
            Console.WriteLine(komunikat);
            while (!int.TryParse(Console.ReadLine(), out wynik) == true)
            {
                Console.Write("niepoprawna wartość");
            }
            return wynik;
        }




 
 
      
 

   

        static int obl_cyfra(char cyfra)
        {
            if (cyfra >= '0' && cyfra <= '9')
            {
                return int.Parse(cyfra.ToString());
            }
            char wielka_Cyfra = char.ToUpper(cyfra); //Zawsze wielkie znaki
            if (wielka_Cyfra >= 'A' && wielka_Cyfra <= 'Z')
            {
                return (int)wielka_Cyfra - 'A' + 10; // A=10, B-A=1+10=12, / C-A+10=3
            }
            return -1;
               
        }

        static bool czy_poprawna(string wartosc,int podstawa)
        {
            for(int i = 0; i<wartosc.Length; i++)
            {
                char cyfra = wartosc[i];
                int wartosc_cyfry = obl_cyfra(cyfra);
                if(wartosc_cyfry==-1 || wartosc_cyfry >= podstawa)
                {
                    return false;
                }
                
            }
            return true;
        }
        static int Other_DEC(string wartosc, int podstawa)
        {
            bool liczba_Poprawna = czy_poprawna(wartosc, podstawa);
            if (!liczba_Poprawna)
            {
                Console.WriteLine("Nieprawidłowa liczba dla podanego systemu");
                return -1;
            }
                int wynik = 0;
                int potega = 1;
            for(int i = wartosc.Length-1; i>=0; i--)
            {
                char aktualna_Wartosc = wartosc[i];
                int wartosc_Cyfry = obl_cyfra(aktualna_Wartosc);

                int dzialanie = wartosc_Cyfry * potega;
                wynik += dzialanie;

                potega *= podstawa;
            }
            return wynik;
        }

        
      
            


    


        static void Main(string[] args)
        {


            bool petla=true;
            do
            {
                string operacja = wczytaj_Tekst("podaj co chcesz zrobic");
                if (operacja.Equals(wyjscie)) {
                    petla = false;
                }
                else {
                    if (operacja.Equals(other_DEC))
                    {
                        int system = wczytaj_Liczbe("podaj system:");
                        string wartosc = wczytaj_Tekst($"podaj wartość liczby do konwersji dla systemu {system} na {"10"} " );
                        int wynik = Other_DEC(wartosc, system);
                        Console.WriteLine(wynik);
                    }
                    if(operacja.Equals(DEC_other))
                }


            } while (petla);



       
            


        }
    }
}
