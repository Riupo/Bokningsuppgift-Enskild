using Bokning_G.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokning_G.KontoTyp
{
    internal class Admin
    {
        public static void ÄndraAdmin()
        {
            Console.Clear();
            using (var db = new MyDBContext()) // READ
            {
                var List = db.Skapade;
                Console.WriteLine("Id  -  Namn  -  Användernamn  -  Lösenord  -  Email  -  Telefonnummer  -  Ålder  -  Admin");
                foreach (var konton in List)
                {
                    
                    if (konton.isAdmin == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"{konton.Id} - {konton.Namn} - {konton.Användernamn} - {konton.Lösenord} - {konton.Mail} - {konton.Telefonnummer} - {konton.Ålder.Date.ToString("yyyy/MM/dd")} - {konton.isAdmin}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{konton.Id} - {konton.Namn} - {konton.Användernamn} - {konton.Lösenord} - {konton.Mail} - {konton.Telefonnummer} - {konton.Ålder.Date.ToString("yyyy/MM/dd")} - {konton.isAdmin}");
                        Console.ResetColor();
                    }
                }
                int switcher;
                int IdUpdate;
                Console.WriteLine("Välj id att ändra");
                if (int.TryParse(Console.ReadLine(), out IdUpdate))
                {
                    Console.WriteLine("[1] För att ändra namn");
                    Console.WriteLine("[2] För att ändra användarnamn");
                    Console.WriteLine("[3] För att ändra lösenord");
                    Console.WriteLine("[4] För att ändra email");
                    Console.WriteLine("[5] För att ändra telefonnummer");
                    Console.WriteLine("[6] För att ändra behörigheter");
                    Console.WriteLine("[7] För att ta bort konto");
                    if (int.TryParse(Console.ReadLine(), out switcher))
                    {
                        switch (switcher)
                        {
                            case 1:
                                Console.WriteLine("Mata in nya namnet");
                                string Update = Console.ReadLine();
                                var kontoupdate = (from n in db.Skapade
                                                where n.Id == IdUpdate
                                                select n).SingleOrDefault();
                                if (kontoupdate != null)
                                {
                                    kontoupdate.Namn = Update;
                                    db.SaveChanges();
                                }
                                Console.Clear();
                                Console.WriteLine("Du har nu ändrat namnet på Id " + IdUpdate);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 2:
                                Console.WriteLine("Mata in nya användernamnet");
                                Update = Console.ReadLine();
                                kontoupdate = (from n in db.Skapade
                                                   where n.Id == IdUpdate
                                                   select n).SingleOrDefault();
                                if (kontoupdate != null)
                                {
                                    kontoupdate.Användernamn = Update;
                                    db.SaveChanges();
                                }
                                Console.Clear();
                                Console.WriteLine("Du har nu ändrat användernamnet på Id " + IdUpdate);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 3:
                                Console.WriteLine("Mata in nya lösenordet");
                                Update = Console.ReadLine();
                                kontoupdate = (from n in db.Skapade
                                                         where n.Id == IdUpdate
                                                         select n).SingleOrDefault();
                                if (kontoupdate != null)
                                {
                                    kontoupdate.Lösenord = Update;
                                    db.SaveChanges();
                                }
                                Console.Clear();
                                Console.WriteLine("Du har nu ändrat lösenordet på Id " + IdUpdate);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 4:
                                Console.WriteLine("Mata in ditt nya email");
                                Update = Console.ReadLine().ToLower();
                                kontoupdate = (from n in db.Skapade
                                               where n.Id == IdUpdate
                                               select n).SingleOrDefault();
                                if (kontoupdate != null)
                                {
                                    kontoupdate.Mail = Update;
                                    db.SaveChanges();
                                }
                                Console.Clear();
                                Console.WriteLine("Du har nu ändrat mailet på Id " + IdUpdate);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            case 5:
                                Console.WriteLine("Mata in ditt nya telefonnummer");
                                int nr;
                                if (int.TryParse(Console.ReadLine(), out nr))

                                {
                                    kontoupdate = (from n in db.Skapade
                                                   where n.Id == IdUpdate
                                                   select n).SingleOrDefault();
                                    if (kontoupdate != null)
                                    {
                                        kontoupdate.Telefonnummer = nr;
                                        db.SaveChanges();
                                    }
                                    Console.Clear();
                                    Console.WriteLine("Du har nu ändrat Telefonnumret på Id " + IdUpdate);
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Fel inmatning");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                break;
                            case 6:
                                Console.WriteLine("Skriv ja/nej för att göra admin");
                                Update = Console.ReadLine().ToLower();
                                if (Update == "ja")
                                {
                                    kontoupdate = (from n in db.Skapade
                                                   where n.Id == IdUpdate
                                                   select n).SingleOrDefault();
                                    if (kontoupdate != null)
                                    {
                                        kontoupdate.isAdmin = true;
                                        db.SaveChanges();
                                    }
                                    Console.Clear();
                                    Console.WriteLine("Du har nu gjort " + IdUpdate + " till admin");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else if (Update == "nej")
                                {
                                    kontoupdate = (from n in db.Skapade
                                                   where n.Id == IdUpdate
                                                   select n).SingleOrDefault();
                                    if (kontoupdate != null)
                                    {
                                        kontoupdate.isAdmin = false;
                                        db.SaveChanges();
                                    }
                                    Console.Clear();
                                    Console.WriteLine("Du har nu tagit " + IdUpdate + " ifrån han admin");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Fel inmatning");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                break;
                            case 7:
                                Console.Clear();
                                    IdUpdate = int.Parse(Console.ReadLine());
                                    var deleteKonto = (from k in db.Skapade
                                                            where k.Id == IdUpdate
                                                            select k).SingleOrDefault();
                                    if (deleteKonto != null)
                                    {
                                        db.Skapade.Remove((SkapaKonto)deleteKonto);
                                        db.SaveChanges();
                                    }
                                Console.Clear();
                                Console.WriteLine("Du har nu tagit bort Id" + IdUpdate);
                                Console.ReadKey();
                                Console.Clear();
                                break;
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
                else
                {
                    Console.Clear();
                    Console.WriteLine("Fel inmatning");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
        public static void ÄndraBokningar()
        {
            DateTime UpdatedDate;
            Console.Clear();
            using (var db = new MyDBContext()) // READ
            {
                //var känd = new Bokningar
                //{
                //};
                DateTime Nu = DateTime.Now;
                int prispermånad = 0;
                int IdUpdate;
                int switches;
                int switcher;
                var list = db.Bokningarna;
                Console.WriteLine("Id  -  KontoId  -  Tid  -  Namn  -  Pris");
                foreach (var bokningar in list)
                {
                    Console.WriteLine($"{bokningar.Id}  -  {bokningar.SkapaKontoId}  -  {bokningar.Tid.ToString("f")}  -  {bokningar.KundNamn}  -  {bokningar.Pris}");
                    if (bokningar.Tid.ToString("MM") == Nu.ToString("MM"))
                    {
                        prispermånad += bokningar.Pris;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Du tjänar " + prispermånad + "kr per månad");
                    Console.ResetColor();
                }
                            Console.WriteLine("Mata in id du vill ändra");
                            IdUpdate = int.Parse(Console.ReadLine());
                            Console.WriteLine("[1] För att ändra datum");
                            Console.WriteLine("[2] För att ta bort bokning");
                            if (int.TryParse(Console.ReadLine(), out switches))
                            {
                                switch (switches)
                                {
                                    case 1:
                    Console.WriteLine("Mata in de nya datumet i detta format (YYYY-MM-DD hh:00)");
                                if (DateTime.TryParse(Console.ReadLine(), out UpdatedDate))
                                {
                                    var bokingupdater = (from TDL in db.Bokningarna
                                                         where TDL.Id == IdUpdate
                                                         select TDL).SingleOrDefault();
                                    if (bokingupdater != null)
                                    {
                                        bokingupdater.Tid = UpdatedDate;
                                        db.SaveChanges();
                                    Console.Clear();
                                    Console.WriteLine("Du har nu ändrat id: " + IdUpdate);
                                    Console.ReadKey();
                                    Console.Clear();
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
                                    case 2:
                                        Console.Clear();
                                            var deleteTodoListID = (from b in db.Bokningarna
                                                                    where b.Id == IdUpdate
                                                                    select b).SingleOrDefault();
                                            if (deleteTodoListID != null)
                                            {
                                                db.Bokningarna.Remove((Bokningar)deleteTodoListID);
                                                db.SaveChanges();
                                            }
                            Console.Clear();
                            Console.WriteLine("Du har nu tagit bort id: " + IdUpdate);
                            Console.ReadKey();
                            Console.Clear();
                                        break;
                            }
                    }
                    
            }
        }
    }
}
