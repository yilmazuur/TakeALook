using TakeALook.Model;
using TakeALook.Repository.Interface;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace TakeALook.Repository
{
    /// <summary>
    /// Contextteki class->tablo DB mappingleri Mapping folderının altında yapıldı.
    /// Inheritance olan classlarda generic mapping EF tarafından desteklenmiyor. 
    /// Bir de inheritance kullanılmasa bile best practice bu işlemin açık bir şekilde yapılması.
    /// </summary>
    public class TakeALookDBContext : DbContext, ICustomDBContext
    {
        /// <summary>
        /// Automatic db migration işlemleri için default Ctor eklendi.
        /// Migrations folderı yoksa -> Package Manager Console : Enable-Migrations –EnableAutomaticMigrations -Force -Verbose
        /// </summary>
        public TakeALookDBContext() 
            : base("name=TakeALookEntities") 
        {
            //Context initialize edilirken veritabanındaki objelere bir şey yapmasın.
            Database.SetInitializer<TakeALookDBContext>(null);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : DBObjectBase
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// Uygulama veritabanına ilk defa erişirken çalışır. 
        /// Context instanceı her oluşturulduğunda çağırılmaz.
        /// ConnectionString'de belirtilen db objesi yoksa Mappinglere bakarak create eder.
        /// Buraya eklenmeyen mapping create edilmez. ITakeALookDBContextObject interfaceinden türetilen mappingler alındı.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var configurationTypesToRegister = from t in Assembly.GetExecutingAssembly().GetTypes()
                                           where t.BaseType != null && t.BaseType.IsGenericType && t.GetInterface("ITakeALookDBContextObject") != null
                                                && t.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)
                                           select t;
            foreach (var configType in configurationTypesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(configType);
                modelBuilder.Configurations.Add(configurationInstance);
                base.OnModelCreating(modelBuilder);
            }
        }
    }
}
