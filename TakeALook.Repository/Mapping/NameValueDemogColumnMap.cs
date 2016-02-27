using TakeALook.Model;
using TakeALook.Repository.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Repository.Mapping
{
    /// <summary>
    /// EntityTypeConfiguration<T> içerisindeki T yerine interface, abstract class, generic vb. kullanılmaz. Runtime hatası verir.
    /// ITakeALookDBContextObjectten türeyenler TakeALook Contextine tablo olarak create edilecek.
    /// </summary>
    public class NameValueDemogColumnMap : EntityTypeConfiguration<NameValueDemogColumn>, ITakeALookDBContextObject
    {
        public NameValueDemogColumnMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.GroupName).IsRequired().HasMaxLength(300);
            Property(t => t.DemogColumnOrder);
            Property(t => t.DemogColumnName).IsRequired().HasMaxLength(300);
            Property(t => t.UserFriendlyDemogColumnName).IsRequired().HasMaxLength(300);
            ToTable("NameValueDemogColumn");
        }
    }
}
