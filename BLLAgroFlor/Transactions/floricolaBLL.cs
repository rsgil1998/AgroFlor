using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLAgroFlor.Transactions
{
    class floricolaBLL
    {
        //BLL Bussiness Logic Layer
        //Capa de Logica del Negocio

        public static void Create(floricola a)
        {

            using (dbAgroFlorEntities db = new dbAgroFlorEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.floricola.Add(a);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static floricola Get(int? id)
        {
            dbAgroFlorEntities db = new dbAgroFlorEntities();
            return db.floricola.Find(id);
        }

        public static void Update(floricola f)
        {
            using (dbAgroFlorEntities db = new dbAgroFlorEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.floricola.Attach(f);
                        db.Entry(f).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (dbAgroFlorEntities db = new dbAgroFlorEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        floricola alumno = db.floricola.Find(id);
                        db.Entry(alumno).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static List<floricola> List()
        {
            dbAgroFlorEntities db = new dbAgroFlorEntities();
            return db.floricola.ToList();
        }

    }
}
