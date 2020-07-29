using System;
using System.Collections.Generic;

namespace DemoNetCore21.Dominio.Contratos.Repositorios
{
    // IDisposable. Es para liberar recursos despues que se haya utilizado el objeto.
    // 
    public interface IRepositorioBase<TEntity>: IDisposable where TEntity: class
    {
        IEnumerable<TEntity> Get();
    }
}
