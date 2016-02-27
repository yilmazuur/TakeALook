using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Repository.Interface
{
    /// <summary>
    /// UnitOfWorkün GenericRepository dışındaki repositoryler ile de çalışması için eklendi.
    /// Bu interfaceten türeyen contextlere UnitOfWork yönlendirme yapabilecek.
    /// .NET'in DbContext methodlarından lazım olanlar buraya çıkarıldı, çünkü repository içinde interface kullanılacak.
    /// </summary>
    public interface ICustomDBContext
    {
        int SaveChanges();
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);
        void Dispose();
    }
}
