using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadataci_2 {
    class Program {
        static void Main() {
            Artikal artikal = new Artikal();
            while (true) {

                Console.Write("1) Dodaj artikal \n2) Prikazi stanje artikla \n3) Izmeni stanje artikla \n0) Izlaz \nIzaberite jednu od navedenih opcija > ");
                string unos_korisnika = Console.ReadLine();
                Console.Clear();
                
                switch (unos_korisnika) {
                
                    case "1":
                        Console.Write("Ime artikla : ");
                        string ime = Console.ReadLine();
                        Console.Write("Sifra artikla : ");
                        string sifra = Console.ReadLine();
                        Console.Write("Stanje artikla : ");
                        int stanje = int.Parse(Console.ReadLine());
                        Console.Write("Ulazna cena : ");
                        decimal uCena = decimal.Parse(Console.ReadLine());
                        Console.Write("Marza artikla : ");
                        decimal marza = decimal.Parse(Console.ReadLine());
                        decimal cena = artikal.Cena(uCena, marza);
                        Artikal.artikli.Add(new Artikal(ime,sifra,stanje,uCena,marza,cena));
                        Console.Clear();
                        break;
                   
                    case "2":
                        Console.Clear();
                        artikal.Prikazi_Artikle();
                        break;
                    
                    case "3":
                        Console.Clear();
                        Console.Write("Unesite ime artikla kome zelite da promenite stanje : ");
                        string ime_Artikla = Console.ReadLine();
                        Console.Write("Promena stanja artikla : ");
                        int promena_Stanja = int.Parse(Console.ReadLine());
                        artikal.Izmeni_stanje(ime_Artikla,promena_Stanja);
                        break;
                    
                    case "0":
                        Environment.Exit(0);
                        break;
                    
                    default:
                        Console.WriteLine("\nPogresna komanda! \n");
                        break;
                }

            }        
        
        }

        class Artikal {
            static public List<Artikal> artikli = new List<Artikal>();
            public string ime, sifra;
            public int stanje;
            public decimal ulazna_cena;
            public decimal cena;
            public decimal marza;

            
            public Artikal(string Ime, string Sifra, int Stanje, decimal uCena, decimal Marza, decimal Cena) {
                ime = Ime;
                sifra = Sifra;
                stanje = Stanje;
                ulazna_cena = uCena;
                marza = Marza;
                cena = Cena;
            }
            
            public Artikal() { }
            
            public decimal Cena(decimal ulazna_Cena, decimal Marza) {
                return ulazna_Cena * (1 + Marza / 100);
            }
            public void Prikazi_Artikle() {
                Console.WriteLine("Ime \tStanje \tCena \tSifra \n");

                foreach (Artikal i in artikli) {
                    Console.WriteLine($"{i.ime} \t{i.stanje} \t{i.cena} \t{i.sifra}");
                }
                Console.WriteLine();
            }
            
            public void Izmeni_stanje(string Ime_artikla, int Izmena_Stanja) {
                bool check = false;
                foreach (Artikal i in artikli) {
                    if (i.ime == Ime_artikla) {
                        if (i.stanje + Izmena_Stanja < 0) {
                            Console.WriteLine($"Greska! Stanje trenutnog artikla je {i.stanje}");
                            check = true;
                        }
                        else {
                            i.stanje += Izmena_Stanja;
                            check = true;
                        }       
                    }
                }
                if (check == false){
                    Console.WriteLine("\nNe postojeci artikal.\n");
                }
            }
        }
    }
}
