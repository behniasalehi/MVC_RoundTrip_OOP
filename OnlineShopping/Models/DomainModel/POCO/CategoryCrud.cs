using OnlineShopping.Models.DomainModel.DTO.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineShopping.Models.DomainModel.POCO
{
    public class CategoryCrud
    {
        #region [- ctor -]
        public CategoryCrud()
        {

        }
        #endregion
        #region [- Tasks -]

        #region [- Select() -]
        public List<Category> Select()
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    var q = context.Category.ToList();
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

        #region [- Insert(Category ref_Category) -]
        public void Insert(Category ref_Category)
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    context.Category.Add(ref_Category);
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
        public Category Find(int? id)
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    Category category = context.Category.Find(id);
                    return category;
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

        #region [- Update(Category category) -]
        public void Update(Category category)
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    context.Entry(category).State = EntityState.Modified;
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

        #region [- Delete(int id) -]
        public void Delete(int? id)
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    Category category = context.Category.Find(id);
                    context.Category.Remove(category);
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