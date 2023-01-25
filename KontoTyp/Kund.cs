using Bokning_G.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokning_G.KontoTyp
{
    internal class Kund
    {
        public static void bokningar(int kundid, string namn)
        {
            using (var db = new MyDBContext())
            {
                int case1 = 0;
                int case2 = 0;
                int switcherr;
                DateTime Nu = DateTime.Now;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Välkommen till Bilals salong!");
                Console.WriteLine("Det tar en timme att klippa en person");
                Console.WriteLine("Datumet är " + Nu.ToString("f"));
                Console.ResetColor();
                    DateTime Öppning;
                DateTime Stängning;
                string SdateString = "2030-01-20 21:00";
                Stängning = DateTime.Parse(SdateString);
                string ÖdateString = "2030-01-20 07:00";
                Öppning = DateTime.Parse(ÖdateString);
                var bokning = db.Bokningarna;
                Console.ForegroundColor= ConsoleColor.Blue;
                Console.WriteLine("Öppettiderna är 08:00 - 20:00");
                Console.ResetColor();
                Console.WriteLine("Id  -  Tid -  Namn  -  Pris");
                foreach (var bokningarna in bokning)
                {
                    
                    Console.WriteLine($"{bokningarna.Id}  -  {bokningarna.Tid.ToString("f")}  -  {bokningarna.KundNamn} {bokningarna.Pris}");
                    if (bokningarna.Pris == 250)
                    {
                        case1++;
                    }
                    else if (bokningarna.Pris == 200)
                    {
                        case2++;
                    }
                }
                if (case1 > case2) // kollar vad den populäraste produkten är 
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Det populäraste alternativet är att klippa år och skägg! För 250kr");
                    Console.ResetColor();
                }
                else if (case1 < case2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Det populäraste alternativet är att endast klippa år! För 200kr");
                    Console.ResetColor();
                }
                else if (case1 == case2) 
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Alternativen är lika mycket valda");
                    Console.ResetColor();
                } 
                DateTime userDateInput;
                Console.Write("[1] Det kostar: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("250kr");
                Console.ResetColor();
                Console.WriteLine(" för att klippa hår och skägg");
                Console.Write("[2] Det kostar: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("200kr");
                Console.ResetColor();
                Console.WriteLine(" för att klippa endast hår");
                Console.WriteLine("[0] För att gå tillbaka");
                if (int.TryParse(Console.ReadLine(), out switcherr))
                    switch (switcherr)
                {
                        case 1:
                            try
                            {
                                Console.WriteLine("Mata in de nya datumet i detta format (YYYY-MM-DD hh:00)");
                                if (DateTime.TryParse(Console.ReadLine(), out userDateInput))
                                {
                                    if (userDateInput <= Nu)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Du skrev in ett datum som redan har passerat");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    else if (userDateInput.ToString("mm") != "00")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Fel inmatning");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    else if (userDateInput.Hour >= Stängning.Hour)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Det är stängt boka en annan tid");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    else if (userDateInput.Hour <= Öppning.Hour)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Det är stängt boka en annan tid");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        var Skapabokningar = new Bokningar
                                        {
                                        };
                                        if (userDateInput.ToString("D-HH") == Skapabokningar.Tid.ToString("D-HH"))
                                        {
                                            Console.WriteLine("Du kan inte boka denna tid för den är redan bokad");

                                        }
                                        else
                                        {
                                            var Skapabokningarna = new Bokningar
                                            {
                                                Tid = userDateInput,
                                                KundNamn = namn,
                                                SkapaKontoId = kundid,
                                                Pris = 250
                                            };
                                            var skapade = db.Bokningarna;
                                            skapade.Add(Skapabokningarna);
                                            db.SaveChanges();
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine($"Du har precis bokat tiden {userDateInput.ToString("f")}");
                                            Console.ResetColor();
                                            Console.ReadKey();
                                            Console.Clear();
                                        }
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
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine("Det angivna datumet är redan bokat");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 2:
                            Console.WriteLine("Mata in de nya datumet i detta format (YYYY-MM-DD hh:00)");
                            if (DateTime.TryParse(Console.ReadLine(), out userDateInput))
                            {
                                if (userDateInput <= Nu)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Du skrev in ett datum som redan har passerat");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else if (userDateInput.ToString("mm") != "00")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Fel inmatning");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else if (userDateInput.Hour >= Stängning.Hour)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Det är stängt boka en annan tid");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else if (userDateInput.Hour <= Öppning.Hour)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Det är stängt boka en annan tid");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else
                                {
                                    var Skapabokningar = new Bokningar
                                    {
                                    };

                                    if (userDateInput.ToString("d-HH") == Skapabokningar.Tid.ToString("d-HH"))
                                    {
                                        Console.WriteLine("Du kan inte boka denna tid för den är redan bokad");

                                    }
                                    else
                                    {
                                        var Skapabokningarna = new Bokningar
                                        {
                                            Tid = userDateInput,
                                            KundNamn = namn,
                                            SkapaKontoId = kundid,
                                            Pris = 200
                                        };
                                        var skapade = db.Bokningarna;
                                        skapade.Add(Skapabokningarna);
                                        db.SaveChanges();
                                        Console.Clear();
                                        Console.WriteLine($"Du har precis bokat tiden {userDateInput.ToString("f")}");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Fel inmatning");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 0:
                            Console.Clear();
                            Console.WriteLine("Du har valt att gå tillbaka");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Fel inmatning");
                    Console.ReadKey();
                    Console.Clear();
                }
            }    
        }
        public static void BokningsHistorik(int kundid)
        {
            Console.Clear();
            using (var db = new MyDBContext())
            {
                var TillgängligaBokningar = new Bokningar
                {
                };
                var Historik = (from h in db.Bokningarna
                                    where h.SkapaKontoId == kundid
                                    select h);
                    Console.WriteLine("Id  -  Tid  -  KundNamn  -  Pris");
                    foreach (var h in Historik)
                    {
                        Console.WriteLine($"{h.Id}  -  {h.Tid.ToString("f")}  -  {h.KundNamn}  -  {h.Pris}");
                    }
            }
        }
    }
}
