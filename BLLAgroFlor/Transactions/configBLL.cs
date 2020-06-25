using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLAgroFlor.Transactions
{
    class configBLL
    {
        //BLL Bussiness Logic Layer
        //Capa de Logica del Negocio

        public static void Create(config a)
        {

            using (dbAgroFlorEntities db = new dbAgroFlorEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.config.Add(a);
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

        public static config Get(int? id)
        {
            dbAgroFlorEntities db = new dbAgroFlorEntities();
            return db.config.Find(id);
        }

        public static void Update(config c)
        {
            using (dbAgroFlorEntities db = new dbAgroFlorEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.config.Attach(c);
                        db.Entry(c).State = System.Data.Entity.EntityState.Modified;
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
                        config alumno = db.config.Find(id);
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

        public static List<config> List()
        {
            dbAgroFlorEntities db = new dbAgroFlorEntities();
            return db.config.ToList();
        }

    }
}
