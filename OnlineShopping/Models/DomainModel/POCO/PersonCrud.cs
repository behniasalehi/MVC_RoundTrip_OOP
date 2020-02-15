using OnlineShopping.Models.DomainModel.DTO.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineShopping.Models.DomainModel.POCO
{
    public class PersonCrud
    {
        #region [- ctor -]
        public PersonCrud()
        {

        }
        #endregion

        #region [- Tasks -] 

        #region [- Select() -]
        public List<Models.DomainModel.DTO.EF.Person> Select()
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    var q = context.Person.ToList();
                    return q;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }
        }
        #endregion 

        #region [- Insert(Person ref_Person) -]
        public void Insert(Person ref_Person)
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    context.Person.Add(ref_Person);
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }

        }
        #endregion

        #region [- Find(int? id) -]
        public Person Find(int? id)
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    Person person = context.Person.Find(id);
                    return person;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }
        }
        #endregion

        #region [- Update(Person person) -]
        public void Update(Person person)
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    context.Entry(person).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }

        }
        #endregion

        #region [- Delete(int? id) -]
        public void Delete(int id)
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    Person person = context.Person.Find(id);
                    context.Person.Remove(person);
                    context.SaveChanges();

                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }

            }

        } 
        #endregion

        #endregion
    }
}