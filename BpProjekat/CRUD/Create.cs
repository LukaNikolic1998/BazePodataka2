using BpProjekat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class Create
    {
        public static void CreateStamparija(string ime)
        {
            using (var db = new BpProjekatModelContext())
            {
                var stamparija = new Stamparija()
                {
                    imesta = ime
                };

                db.Stamparijas.Add(stamparija);
                db.SaveChanges();
            }
        }

        public static void CreateIzdavac(string ime)
        {
            using (var db = new BpProjekatModelContext())
            {
                var izdavac = new Izdavac()
                {
                    imei = ime
                };

                db.Izdavacs.Add(izdavac);
                db.SaveChanges();
            }
        }

        public static void CreateStriparnica(string ime)
        {
            using (var db = new BpProjekatModelContext())
            {
                var striparnica = new Striparnica()
                {
                    imes = ime
                };

                db.Striparnicas.Add(striparnica);
                db.SaveChanges();
            }

        }

        public static void CreateKategorija(string ime)
        {
            using (var db = new BpProjekatModelContext())
            {
                var kategorija = new Kategorija()
                {
                    imek = ime
                };

               // db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Kategorijas ON;");
                db.Kategorijas.Add(kategorija);
               
                db.SaveChanges();
               // db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Kategorijas OFF;");
            }

        }

        public static void CreateNagrada(string ime)
        {
            using (var db = new BpProjekatModelContext())
            {
                var nagrada = new Nagrada()
                {
                    imen = ime
                };

                db.Nagradas.Add(nagrada);
                db.SaveChanges();
            }
        }

        public static void CreateFestival(string ime,int god)
        {
            using (var db = new BpProjekatModelContext())
            {
                var festival = new Festival()
                {
                    imef = ime,
                    gododr = god
                };

                db.Festivals.Add(festival);
                db.SaveChanges();
            }
        }

        public static void CreateAutor(string entitet,string ime,string prz)
        {
            using (var db = new BpProjekatModelContext())
            {
                if (entitet.Equals("scenarista"))
                {
                    var scenarista = new Scenarista()
                    {
                        imea = ime,
                        prza = prz,
                        tipaut = "scenarista"
                    };

                    db.Autors.Add(scenarista);
                    db.SaveChanges();
                }
                else if (entitet.Equals("crtac"))
                {
                    var crtac = new Crtac()
                    {
                        imea = ime,
                        prza = prz,
                        tipaut = "crtac"
                    };

                    db.Autors.Add(crtac);
                    db.SaveChanges();
                }
            }
        }

        public static void CreateStrip(string ime,int idk,int idsta)
        {
            using (var db = new BpProjekatModelContext())
            {
                var strip = new Strip()
                {
                    imestr = ime,
                    Stamparija_idsta = idsta,
                    Kategorija_idk = idk
                };

                db.Strips.Add(strip);
                db.SaveChanges();
            }
        }

        public static void CreateIzdaje(int idi,int idstr)
        {
            using (var db = new BpProjekatModelContext())
            {
                var izdaje = new Izdaje()
                {
                    Izdavac_idi = idi,
                    Strip_idstr3 = idstr
                };

                db.Izdajes.Add(izdaje);
                db.SaveChanges();
            }
        }

        public static void CreateProdaje(int ids, int idstr)
        {
            using (var db = new BpProjekatModelContext())
            {
                var prodaje = new Prodaje()
                {
                    Striparnica_ids = ids,
                    Strip_idstr4 = idstr,
                    Strip = db.Strips.First(i => i.idstr == idstr)
            };

                db.Prodajes.Add(prodaje);
                db.SaveChanges();
            }
        }

        public static void CreateCrta(int ida, int idstr)
        {
            using (var db = new BpProjekatModelContext())
            {
                var crta = new Crta()
                {
                    Crtac_ida = ida,
                    Strip_idstr2 = idstr
                };

                db.Crtas.Add(crta);
                db.SaveChanges();
            }
        }

        public static void CreatePise(int ida, int idstr)
        {
            using (var db = new BpProjekatModelContext())
            {
                var pise = new Pise()
                {
                    Scenarista_ida = ida,
                    Strip_idstr1 = idstr
                };

                db.Pises.Add(pise);
                db.SaveChanges();
            }
        }

        public static void CreateUcestvuje(int idf, int idstr)
        {
            using (var db = new BpProjekatModelContext())
            {
                var ucestvuje = new Ucestvuje()
                {
                    Festival_idf = idf,
                    Strip_idstr5 = idstr
                };

                db.Ucestvujes.Add(ucestvuje);
                db.SaveChanges();
            }
        }

        public static void CreateDodeljuje(int idn,int idf, int idstr)
        {
            using (var db = new BpProjekatModelContext())
            {
                var dodeljuje = new Dodeljuje()
                {
                    Festival_idf = idf,
                    Nagrada_idn = idn,
                    UcestvujeStrip_idstr = idstr,
                    UcestvujeFestival_idf = idf
                };

                db.Dodeljujes.Add(dodeljuje);
                db.SaveChanges();
            }
        }
    }
}
