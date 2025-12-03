using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repository.IRepository
{
    public  interface IUnitOfWork
    {
        ICategoryRepository Category { get; } //aqui contiene el repositorio de categorias solo es lectura 

        void Save();//metodo para guardar cambios ala db 
    }
}
