using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLAgroFlor.Transactions
{
    class registroBLL
    {
        //BLL Bussiness Logic Layer
        //Capa de Logica del Negocio

        public static void Create(registro a)
        {

            using (dbAgroFlorEntities db = new dbAgroFlorEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.registro.Add(a);
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

        public static registro Get(int? id)
        {
            dbAgroFlorEntities db = new dbAgroFlorEntities();
            return db.registro.Find(id);
        }

        public static void Update(registro r)
        {
            using (dbAgroFlorEntities db = new dbAgroFlorEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.registro.Attach(r);
                        db.Entry(r).State = System.Data.Entity.EntityState.Modified;
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
                        registro alumno = db.registro.Find(id);
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

        public static List<registro> List()
        {
            dbAgroFlorEntities db = new dbAgroFlorEntities();
            return db.registro.ToList();
        }

    }
}
