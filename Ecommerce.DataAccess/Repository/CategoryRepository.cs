using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.Models;
using EcommerceWebApp.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repository
{
    //aqui categoryrepository manejara datos de la entidad category  heredata de repository<category>
    //implementamos IcategoryRepository nos permite definir los metodos que no existen en repositorio generico 
    public class CategoryRepository : Repository<Category>,ICategoryRepository
    {
       
        private ApplicationDbContext _db;//guardamos la referencia del dbcontext  que  es la base de datos se usara solo en esta clase por eso es private 
        
        public CategoryRepository(ApplicationDbContext db) :base(db) //llamamos al contructor de la clase repository<category>
        {
            //recibimos el contexto de la db mediante inyeccion de dependencias  y la guardamos en _db
            _db = db;
        }
       

        public void Update(Category category)
        {
            _db.Update(category);
        }
    }
}
