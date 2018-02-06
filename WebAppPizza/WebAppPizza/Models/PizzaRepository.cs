using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPizza.Data;

namespace WebAppPizza.Models
{
    public class PizzaRepository : IRepositoryable<Pizza>
    {
        private PizzaDbContext _context;

        public PizzaRepository(PizzaDbContext context)   //constructeur
        {
            this._context = context;  
        }


        public void Create(Pizza obj)
        {
            this._context.Pizza.Add(obj);
            this._context.SaveChanges();
        }

        public void Delete(int key)
        {
            var pizza = this.readyById(key);
            this._context.Pizza.Remove(pizza);
            this._context.SaveChanges();
        }

        public List<Pizza> Read(Func<Pizza, bool> whereClause)
        {
            return this._context.Pizza.Where(whereClause).ToList();
        }

        public List<Pizza> Read(int skip, int take)
        {
            return this._context.Pizza.Skip(skip).Take(take).ToList(); 
        }

        public Pizza readyById(int key)
        {
            return this._context.Pizza.Find(key);
        }

        public void Update(Pizza obj)
        {
            this._context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this._context.SaveChanges();
        }

        public int Count()
        {

            return this._context.Pizza.Count();
        }
    }
}
