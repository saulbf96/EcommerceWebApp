using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repository.IRepository
{
   internal  interface IRepository<T> where T : class //esto indica que la interface es generica T debe ser una clase 
       //where T : class  no struct  o tipo primitivo 
    {
        //T- Category

        IEnumerable<T> GetAll(); //obtener todos los registros de la tabla
        T Get(Expression<Func<T, bool>> filter); //obtener un solo registro 
    }
}
