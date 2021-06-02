using BpProjekat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class Delete
    {
        public static void DeleteStamparija(int id)
        {
            using (var db = new BpProjekatModelContext())
            {
                var delete = from b in db.Stamparijas where b.idsta == id select b;
                foreach (var del in delete)
                {
                    db.Stamparijas.Remove(del);
                }
                db.SaveChanges();
            }
        }

        public static void DeleteIzdavac(int id)
        {
            DeleteIzdaje(id, -1);
            using (var db = new BpProjekatModelContext())
            {
                var delete = from b in db.Izdavacs where b.idi == id select b;
                foreach (var del in delete)
                {
                    db.Izdavacs.Remove(del);
                }
                db.SaveChanges();
            }
        }

        public static void DeleteStriparnica(int id)
        {
            DeleteProdaje(id, -1);
            using (var db = new BpProjekatModelContext())
            {
                var delete = from b in db.Striparnicas where b.ids == id select b;
                foreach (var del in delete)
                {
                    db.Striparnicas.Remove(del);
                }
                db.SaveChanges();
            }
        }

        public static void DeleteKategorija(int id)
        {
            using (var db = new BpProjekatModelContext())
            {
                var delete = from b in db.Kategorijas where b.idk == id select b;
                foreach (var del in delete)
                {
                    db.Kategorijas.Remove(del);
                }
                db.SaveChanges();
            }
        }

        public static void DeleteFestival(int id)
        {
            DeleteUcestvuje(id, -1);
            using (var db = new BpProjekatModelContext())
            {
                var delete = from b in db.Festivals where b.idf == id select b;
                foreach (var del in delete)
                {
                    db.Festivals.Remove(del);
                }
                db.SaveChanges();
            }
        }

        public static void DeleteNagrada(int id)
        {
            using (var db = new BpProjekatModelContext())
            {
                var delete = from b in db.Nagradas where b.idn == id select b;
                foreach (var del in delete)
                {
                    db.Nagradas.Remove(del);
                }
                db.SaveChanges();
            }
        }

        public static void DeleteStrip(int id)
        {
            DeleteIzdaje(-1, id);
            DeleteProdaje(-1, id);
            DeleteCrta(-1, id);
            DeletePise(-1, id);
            DeleteUcestvuje(-1, id);
            using (var db = new BpProjekatModelContext())
            {
                var delete = from b in db.Strips where b.idstr == id select b;
                foreach (var del in delete)
                {
                    db.Strips.Remove(del);
                }
                db.SaveChanges();
            }
        }

        public static void DeleteAutor(int id)
        {
            DeletePise(id, -1);
            DeleteCrta(id, -1);
            using (var db = new BpProjekatModelContext())
            {
                var delete = from b in db.Autors where b.ida == id select b;
                foreach (var del in delete)
                {
                    db.Autors.Remove(del);
                }
                db.SaveChanges();
            }
        }

        public static void DeleteIzdaje(int idi,int idstr)
        {
            if (idi == -1)
            {
                using (var db = new BpProjekatModelContext())
                {
                    var delete = from b in db.Izdajes where b.Strip_idstr3 == idstr select b;
                    foreach (var del in delete)
                    {
                        db.Izdajes.Remove(del);
                    }
                    db.SaveChanges();
                }
            }
            else if (idstr == -1)
            {
                using (var db = new BpProjekatModelContext())
                {
                    var delete = from b in db.Izdajes where b.Izdavac_idi == idi select b;
                    foreach (var del in delete)
                    {
                        db.Izdajes.Remove(del);
                    }
                    db.SaveChanges();
                }
            }
            else
            {
                using (var db = new BpProjekatModelContext())
                {
                    var delete = from b in db.Izdajes where b.Izdavac_idi == idi & b.Strip_idstr3 == idstr select b;
                    foreach (var del in delete)
                    {
                        db.Izdajes.Remove(del);
                    }
                    db.SaveChanges();
                }
            }
        }

        public static void DeleteProdaje(int ids, int idstr)
        {
            if (ids == -1)
            {
                using (var db = new BpProjekatModelContext())
                {
                    var delete = from b in db.Prodajes where b.Strip_idstr4 == idstr select b;
                    foreach (var del in delete)
                    {
                        db.Prodajes.Remove(del);
                    }
                    db.SaveChanges();
                }
            }
            else if (idstr == -1)
            {
                using (var db = new BpProjekatModelContext())
                {
                    var delete = from b in db.Prodajes where b.Striparnica_ids == ids select b;
                    foreach (var del in delete)
                    {
                        db.Prodajes.Remove(del);
                    }
                    db.SaveChanges();
                }
            }
            else
            {
                using (var db = new BpProjekatModelContext())
                {
                    var delete = from b in db.Prodajes where b.Striparnica_ids == ids & b.Strip_idstr4 == idstr select b;
                    foreach (var del in delete)
                    {
                        db.Prodajes.Remove(del);
                    }
                    db.SaveChanges();
                }
            }
        }

        public static void DeleteCrta(int ida, int idstr)
        {
            if (ida == -1)
            {
                using (var db = new BpProjekatModelContext())
                {
                    var delete = from b in db.Crtas where b.Strip_idstr2 == idstr select b;
                    foreach (var del in delete)
                    {
                        db.Crtas.Remove(del);
                    }
                    db.SaveChanges();
                }
            }
            else if (idstr == -1)
            {
                using (var db = new BpProjekatModelContext())
                {
                    var delete = from b in db.Crtas where b.Crtac_ida == ida select b;
                    foreach (var del in delete)
                    {
                        db.Crtas.Remove(del);
                    }
                    db.SaveChanges();
                }
            }
            else
            {
                using (var db = new BpProjekatModelContext())
                {
                    var delete = from b in db.Crtas where b.Crtac_ida == ida & b.Strip_idstr2 == idstr select b;
                    foreach (var del in delete)
                    {
                        db.Crtas.Remove(del);
                    }
                    db.SaveChanges();
                }
            }
        }

        public static void DeletePise(int ida, int idstr)
        {
            if(ida == -1)
            {
                using (var db = new BpProjekatModelContext())
                {
                    var delete = from b in db.Pises where b.Strip_idstr1 == idstr select b;
                    foreach (var del in delete)
                    {
                        db.Pises.Remove(del);
                    }
                    db.SaveChanges();
                }
            }
            else if(idstr == -1)
            {
                using (var db = new BpProjekatModelContext())
                {
                    var delete = from b in db.Pises where b.Scenarista_ida == ida select b;
                    foreach (var del in delete)
                    {
                        db.Pises.Remove(del);
                    }
                    db.SaveChanges();
                }
            }
            else
            {
                using (var db = new BpProjekatModelContext())
                {
                    var delete = from b in db.Pises where b.Scenarista_ida == ida & b.Strip_idstr1 == idstr select b;
                    foreach (var del in delete)
                    {
                        db.Pises.Remove(del);
                    }
                    db.SaveChanges();
                }
            }
        }

        public static void DeleteUcestvuje(int idf, int idstr)
        {
            if(idf == -1)
            {
                using (var db = new BpProjekatModelContext())
                {
                    var delete = from b in db.Dodeljujes where b.UcestvujeStrip_idstr == idstr select b;
                    foreach (var del in delete)
                    {
                        db.Dodeljujes.Remove(del);
                    }
                    db.SaveChanges();
                }
                using (var db = new BpProjekatModelContext())
                {
                    var delete = from b in db.Ucestvujes where b.Strip_idstr5 == idstr select b;
                    foreach (var del in delete)
                    {
                        db.Ucestvujes.Remove(del);
                    }
                    db.SaveChanges();
                }
            }
            else if(idstr == -1)
            {
                using (var db = new BpProjekatModelContext())
                {
                    var delete = from b in db.Dodeljujes where b.Festival_idf == idf select b;
                    foreach (var del in delete)
                    {
                        db.Dodeljujes.Remove(del);
                    }
                    db.SaveChanges();
                }
                using (var db = new BpProjekatModelContext())
                {
                    var delete = from b in db.Ucestvujes where b.Festival_idf == idf select b;
                    foreach (var del in delete)
                    {
                        db.Ucestvujes.Remove(del);
                    }
                    db.SaveChanges();
                }
            }
            else
            {
                using (var db = new BpProjekatModelContext())
                {
                    var delete = from b in db.Dodeljujes where b.Festival_idf == idf & b.UcestvujeStrip_idstr == idstr select b;
                    foreach (var del in delete)
                    {
                        db.Dodeljujes.Remove(del);
                    }
                    db.SaveChanges();
                }
                using (var db = new BpProjekatModelContext())
                {
                    var delete = from b in db.Ucestvujes where b.Festival_idf == idf & b.Strip_idstr5 == idstr select b;
                    foreach (var del in delete)
                    {
                        db.Ucestvujes.Remove(del);
                    }
                    db.SaveChanges();
                }
            }
        }

        public static void DeleteDodeljuje(int idn, int idf)
        {
                using (var db = new BpProjekatModelContext())
                {
                    var delete = from b in db.Dodeljujes where b.Festival_idf == idf & b.Nagrada_idn == idn select b;
                    foreach (var del in delete)
                    {
                        db.Dodeljujes.Remove(del);
                    }
                    db.SaveChanges();
                }
        }
    }
}
