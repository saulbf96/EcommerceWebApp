using Ecommerce.DataAccess.Repository.IRepository;
using EcommerceWebApp.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork //implementamos la interfaz hasta aqui tengo el repo cargado de category  y el metodo save 
    {
        private ApplicationDbContext _db;// aqui se almacena la db ya que esta en un campo privado 
        public ICategoryRepository Category { get; private set; }//esta propiedad pongo a disposicion de cualquier clase que trabaje con UnitoFwORK
        //AQUI SE DECLARA EL SET PRIVADO PARA QUE DESDE  afuera solo se pueda leer 
        //constructor
        public UnitOfWork(ApplicationDbContext db)// aqui el contrusctor recibe el contexto por medio de inyeccion de dependencias 
        {
            _db = db; //lo asignamos al campo _db 
            Category =  new CategoryRepository(_db); //hago una instancia pasandole el mismo contexto que ahora es _db hacia category
            //hasta aqui unitofwork comparte el mismo dbcontext y tambien categoryrepository
        }

        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
