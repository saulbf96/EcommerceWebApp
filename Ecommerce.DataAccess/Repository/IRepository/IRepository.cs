using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repository.IRepository
{
   public  interface IRepository<T> where T : class //esto indica que la interface es generica T debe ser una clase 
       //where T : class  no struct  o tipo primitivo 
    {
        //T- Category

        IEnumerable<T> GetAll(); //obtener todos los registros de la tabla
        //Devuelve un solo registro que cumpla la condición enviada mediante una expresión lambda.
        T Get(Expression<Func<T, bool>> filter); //obtener un solo registro 
        void Add(T entity);//Agrega una nueva entidad T al contexto, para luego ser guardada en la base de datos:
        //void Update(T entity);//Actualiza un registro existente. Generalmente:
        void Remove(T entity);  //Elimina un registro especifico
        void RemoveRange(IEnumerable<T> entity);//Eliminar vasrios registros al mismo tiempo

    }
}
