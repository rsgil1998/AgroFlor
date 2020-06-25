using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLAgroFlor.Transactions
{
    class variedadesBLL
    {
        //BLL Bussiness Logic Layer
        //Capa de Logica del Negocio

        public static void Create(variedades a)
        {

            using (dbAgroFlorEntities db = new dbAgroFlorEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.variedades.Add(a);
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

        public static variedades Get(int? id)
        {
            dbAgroFlorEntities db = new dbAgroFlorEntities();
            return db.variedades.Find(id);
        }

        public static void Update(variedades v)
        {
            using (dbAgroFlorEntities db = new dbAgroFlorEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.variedades.Attach(v);
                        db.Entry(v).State = System.Data.Entity.EntityState.Modified;
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
                        variedades alumno = db.variedades.Find(id);
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

        public static List<variedades> List()
        {
            dbAgroFlorEntities db = new dbAgroFlorEntities();
            return db.variedades.ToList();
        }

    }
}
