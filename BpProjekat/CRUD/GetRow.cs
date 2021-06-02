using BpProjekat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class GetRow
    {
        public static Stamparija GetRowStamparija(int id)
        {
            Stamparija stamparija = new Stamparija();
            using (var db = new BpProjekatModelContext())
            {
                var get = from b in db.Stamparijas where b.idsta == id select b;
                foreach (var g in get)
                {
                    stamparija = g;
                }
            }
            return stamparija;
        }

        public static Izdavac GetRowIzdavac(int id)
        {
            Izdavac izdavac = new Izdavac();
            using (var db = new BpProjekatModelContext())
            {
                var get = from b in db.Izdavacs where b.idi == id select b;
                foreach (var g in get)
                {
                    izdavac = g;
                }
            }
            return izdavac;
        }

        public static Striparnica GetRowStriparnica(int id)
        {
            Striparnica striparnica = new Striparnica();
            using (var db = new BpProjekatModelContext())
            {
                var get = from b in db.Striparnicas where b.ids == id select b;
                foreach (var g in get)
                {
                    striparnica = g;
                }
            }
            return striparnica;
        }

        public static Nagrada GetRowNagrada(int id)
        {
            Nagrada nagrada = new Nagrada();
            using (var db = new BpProjekatModelContext())
            {
                var get = from b in db.Nagradas where b.idn == id select b;
                foreach (var g in get)
                {
                    nagrada = g;
                }
            }
            return nagrada;
        }

        public static Kategorija GetRowKategorija(int id)
        {
            Kategorija kategorija = new Kategorija();
            using (var db = new BpProjekatModelContext())
            {
                var get = from b in db.Kategorijas where b.idk == id select b;
                foreach (var g in get)
                {
                    kategorija = g;
                }
            }
            return kategorija;
        }

        public static Festival GetRowFestival(int id)
        {
            Festival festival = new Festival();
            using (var db = new BpProjekatModelContext())
            {
                var get = from b in db.Festivals where b.idf == id select b;
                foreach (var g in get)
                {
                    festival = g;
                }
            }
            return festival;
        }

        public static Strip GetRowStrip(int id)
        {
            Strip strip = new Strip();
            using (var db = new BpProjekatModelContext())
            {
                var get = from b in db.Strips where b.idstr == id select b;
                foreach (var g in get)
                {
                    strip = g;
                }
            }
            return strip;
        }

        public static Autor GetRowAutor(int id)
        {
            Autor autor = new Autor();
            using (var db = new BpProjekatModelContext())
            {
                var get = from b in db.Autors where b.ida == id select b;
                foreach (var g in get)
                {
                    autor = g;
                }
            }
            return autor;
        }

        public static Izdaje GetRowIzdaje(int idi,int idstr)
        {
            Izdaje izdaje = new Izdaje();
            using (var db = new BpProjekatModelContext())
            {
                var get = from b in db.Izdajes where b.Izdavac_idi == idi & b.Strip_idstr3 == idstr select b;
                foreach (var g in get)
                {
                    izdaje = g;
                }
            }
            return izdaje;
        }

        public static Prodaje GetRowProdaje(int ids, int idstr)
        {
            Prodaje prodaje = new Prodaje();
            using (var db = new BpProjekatModelContext())
            {
                var get = from b in db.Prodajes where b.Striparnica_ids == ids & b.Strip_idstr4 == idstr select b;
                foreach (var g in get)
                {
                    prodaje = g;
                }
            }
            return prodaje;
        }

        public static Crta GetRowCrta(int ida, int idstr)
        {
            Crta crta = new Crta();
            using (var db = new BpProjekatModelContext())
            {
                var get = from b in db.Crtas where b.Crtac_ida == ida & b.Strip_idstr2 == idstr select b;
                foreach (var g in get)
                {
                    crta = g;
                }
            }
            return crta;
        }

        public static Pise GetRowPise(int ida, int idstr)
        {
            Pise pise = new Pise();
            using (var db = new BpProjekatModelContext())
            {
                var get = from b in db.Pises where b.Scenarista_ida == ida & b.Strip_idstr1 == idstr select b;
                foreach (var g in get)
                {
                    pise = g;
                }
            }
            return pise;
        }

        public static Ucestvuje GetRowUcestvuje(int idf, int idstr)
        {
            Ucestvuje ucestvuje = new Ucestvuje();
            using (var db = new BpProjekatModelContext())
            {
                var get = from b in db.Ucestvujes where b.Festival_idf == idf & b.Strip_idstr5 == idstr select b;
                foreach (var g in get)
                {
                    ucestvuje = g;
                }
            }
            return ucestvuje;
        }

        public static Dodeljuje GetRowDodeljuje(int idn, int idf)
        {
            Dodeljuje dodeljuje = new Dodeljuje();
            using (var db = new BpProjekatModelContext())
            {
                var get = from b in db.Dodeljujes where b.Festival_idf == idf & b.Nagrada_idn == idn select b;
                foreach (var g in get)
                {
                    dodeljuje = g;
                }
            }
            return dodeljuje;
        }
    }
}
