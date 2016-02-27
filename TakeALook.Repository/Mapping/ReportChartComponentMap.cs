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
    public class ReportChartComponentMap : EntityTypeConfiguration<ReportChartComponent>, ITakeALookDBContextObject
    {
        public ReportChartComponentMap()
        {
            HasKey(t => t.ID);
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.ShowingTab).IsRequired();
            Property(t => t.DemogColumnInTitle).HasMaxLength(300);
            Property(t => t.UserFriendlyDemogColumnInTitle).HasMaxLength(300);
            Property(t => t.DemogColumnInTitleColumnOrder).IsOptional(); //nullable
            Property(t => t.ChartType).IsRequired().HasMaxLength(300); 
            ToTable("ReportChartComponent");
        }
    }
}
