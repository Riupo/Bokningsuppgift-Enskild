using Bokning_G.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bokning_G
{
    internal class Konto
    {
        public static void VälkomstText()
        {
            while(true)
            {
                Console.WriteLine("Har du ett konto Ja/Nej");
                var input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "ja":
                        Console.Clear();
                        Loggain();
                        break;
                    case "nej":
                        Console.Clear();
                        SkapaKonto(); // skapar konto
                        Console.Clear();
                        Console.WriteLine("Du har nu skapat ett konto");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Fel inmatning");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
        public static void Loggain()
        {
                Console.Clear();
                Console.WriteLine("Ange epost eller användernamn: ");
                var svar = Console.ReadLine().ToLower();
                using (var db = new MyDBContext())
                {
                    var loggain = (from t in db.Skapade
                                   where t.Användernamn == svar || t.Mail == svar
                                   select t).SingleOrDefault();
                    if (svar == "bilals@hotmail.se" || svar == "bilal02" || loggain.isAdmin == true) // admin
                    {
                        Console.WriteLine("Ange Lösenord");
                        string lösen = Console.ReadLine();
                        if (lösen == "123bilal123") // admin
                        {
                            Console.Clear();
                            AdminLogin(svar);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Lösenordet är fel");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    else if (loggain != null) // kund
                    {
                        Console.WriteLine("Ange Lösenord");
                        string lösen = Console.ReadLine();
                        if (lösen == loggain.Lösenord)
                        {
                            Console.Clear();
                            KundLogin(svar);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Lösenordet är fel");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Fel användernamn eller mail");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
        }
        enum MenuListKund
        {
            Boka = 1,
            Visa_Boknings_Historik,
            Logga_ut = 9
        }
        enum MenuListAdmin
        {
            Uppdatera_kunder = 1,
            Ändra_bokning_och_hur_mycket_du_tjänar_per_månad,
            Logga_ut = 9
        }
        public static void SkapaKonto()
        {
            Console.Clear();
            Console.WriteLine("Skriv in ditt användernamn");
            string användernamn = Console.ReadLine().ToLower();
            Console.WriteLine("Skriv in lösenord");
            string LösenordInput = Console.ReadLine().ToLower();
            Console.WriteLine("Skriv in ditt Fullständiga namn");
            string NamnInput = Console.ReadLine();
            Console.WriteLine("Skriv in personnummer YYYY-MM-DD");
            DateTime personnummer = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Skriv in mail");
            string mail = Console.ReadLine().ToLower();
            Console.WriteLine("Skriv in ditt telefonnummer");
            int telefonnummer;
            if (int.TryParse(Console.ReadLine(), out telefonnummer))
            {
                using (var db = new MyDBContext())
                {
                    var Konton = new SkapaKonto
                    {
                        Användernamn = användernamn,
                        Lösenord = LösenordInput,
                        Namn = NamnInput,
                        Ålder = personnummer,
                        Telefonnummer = telefonnummer,
                        Mail = mail,
                        isAdmin = false
                        
                    };
                    var Konto = db.Skapade;
                    Konto.Add(Konton);
                    db.SaveChanges();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Fel inmatning");
                Console.ReadKey();
                Console.Clear();
            }   
        }
        public static void AdminLogin(string svaret)
        {
            using (var db = new MyDBContext())
            {
                var hittaKund = (from t in db.Skapade
                                 where t.Mail == svaret || t.Användernamn == svaret
                                 select t).SingleOrDefault();
                if (hittaKund != null)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Välkommen ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(hittaKund.Namn);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(" du är inloggad på ett admin konto!");
                    Console.ResetColor();
                    var loop = true;
                    while (loop)
                    {
                        foreach (int i in Enum.GetValues(typeof(MenuListAdmin)))
                        {
                            Console.WriteLine($"{i}. {Enum.GetName(typeof(MenuListAdmin), i).Replace('_', ' ')}");
                        }
                        int nr;
                        MenuListAdmin menu = (MenuListAdmin)99; // Default
                        if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                        {
                            menu = (MenuListAdmin)nr;
                            Console.Clear();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Fel inmatning");
                            Console.ReadKey();
                            Console.Clear();

                        }
                        switch (menu)
                        {
                            case MenuListAdmin.Uppdatera_kunder:
                                KontoTyp.Admin.ÄndraAdmin();
                                break;
                            case MenuListAdmin.Ändra_bokning_och_hur_mycket_du_tjänar_per_månad:
                                KontoTyp.Admin.ÄndraBokningar();
                                break;
                            case MenuListAdmin.Logga_ut:
                                loop = false;
                                Console.Clear();
                                Console.WriteLine("Du har precis loggat ut");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    }
                }
            }
        }
        public static void KundLogin(string svaret)
        {
            using (var db = new MyDBContext())
            {
                var hittaKund = (from t in db.Skapade
                                 where t.Mail == svaret || t.Användernamn == svaret
                                 select t).SingleOrDefault();
                if (hittaKund != null)
                {
                    Console.Clear();
                    Console.WriteLine("Välkommen " + hittaKund.Namn);
                    var loop = true;
                    while (loop)
                    {
                        foreach (int i in Enum.GetValues(typeof(MenuListKund)))
                        {
                            Console.WriteLine($"{i}. {Enum.GetName(typeof(MenuListKund), i).Replace('_', ' ')}");
                        }
                        int nr;
                        MenuListKund menu = (MenuListKund)99;
                        if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out nr))
                        {
                            menu = (MenuListKund)nr;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Fel inmatning");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        switch (menu)
                        {
                            case MenuListKund.Boka:
                                Console.Clear();
                                KontoTyp.Kund.bokningar(hittaKund.Id, hittaKund.Namn);
                                break;
                            case MenuListKund.Visa_Boknings_Historik:
                                KontoTyp.Kund.BokningsHistorik(hittaKund.Id);
                                break;
                            case MenuListKund.Logga_ut:
                                loop = false;
                                Console.Clear();
                                Console.WriteLine("Du har precis loggat ut");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    }
                }
            }
        }
    }
}
