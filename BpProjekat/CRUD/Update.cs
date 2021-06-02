using BpProjekat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class Update
    {
        public static void UpdateStamparija(int id,string ime)
        {
            using (var db = new BpProjekatModelContext())
            {
                var stamparija = db.Stamparijas.First(i => i.idsta == id);
                stamparija.imesta = ime;
                db.SaveChanges();
            }
        }

        public static void UpdateIzdavac(int id, string ime)
        {
            using (var db = new BpProjekatModelContext())
            {
                var izdavac = db.Izdavacs.First(i => i.idi == id);
                izdavac.imei = ime;
                db.SaveChanges();
            }
        }

        public static void UpdateStriparnica(int id, string ime)
        {
            using (var db = new BpProjekatModelContext())
            {
                var striparnica = db.Striparnicas.First(i => i.ids == id);
                striparnica.imes = ime;
                db.SaveChanges();
            }
        }

        public static void UpdateNagrada(int id, string ime)
        {
            using (var db = new BpProjekatModelContext())
            {
                var nagrada = db.Nagradas.First(i => i.idn == id);
                nagrada.imen = ime;
                db.SaveChanges();
            }
        }

        public static void UpdateKategorija(int id, string ime)
        {
            using (var db = new BpProjekatModelContext())
            {
                var kategorija = db.Kategorijas.First(i => i.idk == id);
                kategorija.imek = ime;
                db.SaveChanges();
            }
        }

        public static void UpdateFestival(int id, string ime,int god)
        {
            using (var db = new BpProjekatModelContext())
            {
                var festival = db.Festivals.First(i => i.idf == id);
                festival.imef = ime;
                festival.gododr = god;
                db.SaveChanges();
            }
        }

        public static void UpdateAutor(int id, string ime, string prz)
        {
            using (var db = new BpProjekatModelContext())
            {
                var autor = db.Autors.First(i => i.ida == id);
                autor.imea = ime;
                autor.prza = prz;
                db.SaveChanges();
            }
        }

        public static void UpdateStrip(int id, string ime, int idk, int ids)
        {
            using (var db = new BpProjekatModelContext())
            {
                var strip = db.Strips.First(i => i.idstr == id);
                strip.imestr = ime;
                strip.Kategorija_idk = idk;
                strip.Stamparija_idsta = ids;
                db.SaveChanges();
            }
        }

        public static void UpdateIzdaje(int stari_idi, int stari_idstr,int idi, int idstr)
        {
            Delete.DeleteIzdaje(stari_idi, stari_idstr);
            Create.CreateIzdaje(idi, idstr);
        }

        public static void UpdateProdaje(int stari_ids, int stari_idstr, int ids, int idstr)
        {
            Delete.DeleteProdaje(stari_ids, stari_idstr);
            Create.CreateProdaje(ids, idstr);
        }

        public static void UpdateCrta(int stari_ids, int stari_idstr, int ids, int idstr)
        {
            Delete.DeleteCrta(stari_ids, stari_idstr);
            Create.CreateCrta(ids, idstr);
        }

        public static void UpdatePise(int stari_ids, int stari_idstr, int ids, int idstr)
        {
            Delete.DeletePise(stari_ids, stari_idstr);
            Create.CreatePise(ids, idstr);
        }

        public static void UpdateUcestvuje(int stari_ids, int stari_idstr, int idf, int idstr)
        {
            Delete.DeleteUcestvuje(stari_ids, stari_idstr);
            Create.CreateUcestvuje(idf, idstr);
        }

        public static void UpdateDodeljuje(int stari_idf, int stari_idn,int stari_idstr, int idn, int idf,int idstr)
        {
            Delete.DeleteDodeljuje(stari_idf, stari_idstr);
            Create.CreateDodeljuje(idn,idf, idstr);
        }
    }
}
