using OnlineShopping.Models.DomainModel.DTO.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineShopping.Models.DomainModel.POCO
{
    public class ProductCrud
    {
        #region [- ctor -]
        public ProductCrud()
        {

        }
        #endregion

        #region [- Tasks -]

        #region [- Select() -]
        public List<Product> Select()
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    var product = context.Product.Include(p => p.Category);
                    
                    return product.ToList();
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
        public void Insert(Product ref_Product)
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    context.Product.Add(ref_Product);
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
        public Product Find(int? id)
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {

                   
                    Product product= context.Product.Find(id);
                    return product;
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
        public void Update(Product product)
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    context.Entry(product).State = EntityState.Modified;
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
        public void Delete(int id)
        {
            using (var context = new OnlineShoppingEntities())
            {
                try
                {
                    Category ref_Category = new Category { CategoryID = id };
                    context.Category.Attach(ref_Category);
                    context.Entry(ref_Category).State = System.Data.Entity.EntityState.Deleted;
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

        #region [- CategoryList() -]
        public List<Category> CategoryList()
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


        #endregion



    }
}