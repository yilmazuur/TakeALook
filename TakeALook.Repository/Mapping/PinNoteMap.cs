using TakeALook.Model;
using TakeALook.Repository.Interface;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TakeALook.Repository.Mapping
{
    /// <summary>
    /// EntityTypeConfiguration<T> içerisindeki T yerine interface, abstract class, generic vb. kullanılmaz. Runtime hatası verir.
    /// ITakeALookDBContextObjectten türeyenler TakeALook Contextine tablo olarak create edilecek.
    /// </summary>
    public class PinNoteMap : EntityTypeConfiguration<PinNote>, ITakeALookDBContextObject
    {
        public PinNoteMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.UserID).IsRequired().HasMaxLength(300);
            Property(t => t.Longitude).IsRequired();
            Property(t => t.Latitude).IsRequired();
            Property(t => t.Name).IsRequired().HasMaxLength(300);
            Property(t => t.Address).IsRequired().HasMaxLength(500);
            Property(t => t.Note).IsRequired().HasMaxLength(1000);
            Property(t => t.AddedDate).IsRequired();
            Property(t => t.ModifiedDate).IsRequired();
            ToTable("PinNote");
        }
    }
}
