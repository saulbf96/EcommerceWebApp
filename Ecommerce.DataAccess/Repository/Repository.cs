using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DataAccess.Repository.IRepository;
using EcommerceWebApp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ecommerce.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class //esto es un repositorio generico para reazar CRUD
        //es generico porque usa <T>,IRepository esto significa que esta oblicada a implementar los metodos definidos de interfaz
    {
        //Agregams una iyeccion de dependencia 
        private readonly ApplicationDbContext _db; //se al,acena a una instancia  con readonly solo puede asignarse al constructor 

        internal DbSet<T> dbSet;//Representa ala tabla correspondiente  ala entidad T 
        //constructor 
        public Repository(ApplicationDbContext db)
        {
            _db = db;// Asignamos el DbContext recibido por inyección de dependencias al campo privado _db
            this.dbSet = _db.Set<T>();//obtenemos la tabla 
            //_db.Categories == dbSet;
        }
        public void Add(T entity)// agregamos una nueva entidad al conexto 
        {
            dbSet.Add(entity);
            
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet; //creamos una consulta que parte de la tabla T 
            query = query.Where(filter);// agregamos filtros 
            return query.FirstOrDefault(); //regresamos los datos 
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
