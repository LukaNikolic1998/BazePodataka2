using BpProjekat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class Read
    {
        public static List<Stamparija> ReadStamparija()
        {
            List<Stamparija> st = new List<Stamparija>();
            using (var db = new BpProjekatModelContext())
            {
                var query = from b in db.Stamparijas select b;
                foreach (var item in query)
                {
                    st.Add(item);
                }
            }
            return st;
        }

        public static List<Izdavac> ReadIzdavac()
        {
            List<Izdavac> st = new List<Izdavac>();
            using (var db = new BpProjekatModelContext())
            {
                var query = from b in db.Izdavacs select b;
                foreach (var item in query)
                {
                    st.Add(item);
                }
            }
            return st;
        }

        public static List<Striparnica> ReadStriparnica()
        {
            List<Striparnica> st = new List<Striparnica>();
            using (var db = new BpProjekatModelContext())
            {
                var query = from b in db.Striparnicas select b;
                foreach (var item in query)
                {
                    st.Add(item);
                }
            }
            return st;
        }

        public static List<Kategorija> ReadKategorija()
        {
            List<Kategorija> st = new List<Kategorija>();
            using (var db = new BpProjekatModelContext())
            {
                var query = from b in db.Kategorijas select b;
                foreach (var item in query)
                {
                    st.Add(item);
                }
            }
            return st;
        }

        public static List<Festival> ReadFestival()
        {
            List<Festival> st = new List<Festival>();
            using (var db = new BpProjekatModelContext())
            {
                var query = from b in db.Festivals select b;
                foreach (var item in query)
                {
                    st.Add(item);
                }
            }
            return st;
        }

        public static List<Nagrada> ReadNagrada()
        {
            List<Nagrada> st = new List<Nagrada>();
            using (var db = new BpProjekatModelContext())
            {
                var query = from b in db.Nagradas select b;
                foreach (var item in query)
                {
                    st.Add(item);
                }
            }
            return st;
        }

        public static List<Strip> ReadStrip()
        {
            List<Strip> st = new List<Strip>();
            using (var db = new BpProjekatModelContext())
            {
                var query = from b in db.Strips select b;
                foreach (var item in query)
                {
                    st.Add(item);
                }
            }
            return st;
        }

        public static List<Autor> ReadAutor(string entitet)
        {
            List<Autor> st = new List<Autor>();
            using (var db = new BpProjekatModelContext())
            {
                var query = from b in db.Autors select b;
                foreach (var item in query)
                {
                    if (entitet.Equals("scenarista") && item.tipaut.Equals("scenarista"))
                    {
                        st.Add(item);
                    }
                    else if (entitet.Equals("crtac") && item.tipaut.Equals("crtac"))
                    {
                        st.Add(item);
                    }
                }
            }
            return st;
        }

        public static List<Izdaje> ReadIzdaje()
        {
            List<Izdaje> st = new List<Izdaje>();
            using (var db = new BpProjekatModelContext())
            {
                var query = from b in db.Izdajes select b;
                foreach (var item in query)
                {
                     st.Add(item);
                }
            }
            return st;
        }

        public static List<Prodaje> ReadProdaje()
        {
            List<Prodaje> st = new List<Prodaje>();
            using (var db = new BpProjekatModelContext())
            {
                var query = from b in db.Prodajes select b;
                foreach (var item in query)
                {
                    st.Add(item);
                }
            }
            return st;
        }

        public static List<Crta> ReadCrta()
        {
            List<Crta> st = new List<Crta>();
            using (var db = new BpProjekatModelContext())
            {
                var query = from b in db.Crtas select b;
                foreach (var item in query)
                {
                    st.Add(item);
                }
            }
            return st;
        }

        public static List<Pise> ReadPise()
        {
            List<Pise> st = new List<Pise>();
            using (var db = new BpProjekatModelContext())
            {
                var query = from b in db.Pises select b;
                foreach (var item in query)
                {
                    st.Add(item);
                }
            }
            return st;
        }

        public static List<Ucestvuje> ReadUcestvuje()
        {
            List<Ucestvuje> st = new List<Ucestvuje>();
            using (var db = new BpProjekatModelContext())
            {
                var query = from b in db.Ucestvujes select b;
                foreach (var item in query)
                {
                    st.Add(item);
                }
            }
            return st;
        }

        public static List<Dodeljuje> ReadDodeljuje()
        {
            List<Dodeljuje> st = new List<Dodeljuje>();
            using (var db = new BpProjekatModelContext())
            {
                var query = from b in db.Dodeljujes select b;
                foreach (var item in query)
                {
                    st.Add(item);
                }
            }
            return st;
        }
    }
}
