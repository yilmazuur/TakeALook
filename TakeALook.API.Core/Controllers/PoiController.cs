using TakeALook.Model;
using TakeALook.Operation;
using TakeALook.Operation.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace TakeALook.API.Core.Controllers
{
    /// <summary>
    /// Poi servis
    /// </summary>
    public class PoiController : ApiController
    {
        private IPoiOperations m_PoiOperations;
        private ICategoryOperations m_CategoryOperations;

        /// <summary>
        /// Ctor
        /// </summary>
        public PoiController()
        {
            m_PoiOperations = new PoiOperations();
            m_CategoryOperations = new CategoryOperations();
        }

        /// <summary>
        /// Her işlem sonrası otomatik çalışır
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            m_PoiOperations.Dispose();
            m_CategoryOperations.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Dosya ile poi yükleme
        /// </summary>
        /// <returns></returns>
        [Route("api/v1/Poi/Upload")]
        public ServiceResponse PostFile()
        {
            return new ServiceResponse("Poiler yüklenemedi",
               delegate()
               {
                   var httpRequest = HttpContext.Current.Request;
                   if (httpRequest.Files.Count == 1)
                   {
                       var postedFile = httpRequest.Files[0];
                       string extension = postedFile.FileName.Split('.').Last();
                       if (extension != "csv")
                       {
                           return "Lütfen bir .csv dosyası seçiniz!";
                       }
                       CultureInfo ci = new CultureInfo("en-US");

                       var str = new StreamReader(postedFile.InputStream, Encoding.Default).ReadToEnd().Replace("\r", "");
                       var lines = str.Split(new string[1] { "\n" }, StringSplitOptions.None);
                       var keys = lines[0].Split(new string[1] { "\n" }, StringSplitOptions.None);
                       for (int i = 1; i < lines.Length; i++)
                       {
                           var temp = lines[i].Split(';');
                           Category cat = m_CategoryOperations.GetCategory(temp[1]) as Category;
                           if (cat == null)
                           {
                               cat = new Category()
                               {
                                   IconID = 1,
                                   ListOrder = 999,
                                   RenderOrder = 999,
                                   Name = temp[1]
                               };
                               cat = m_CategoryOperations.CreateCategory(cat) as Category;
                           }
                           Poi poi = new Poi();
                           poi.CustomID = temp[0];
                           poi.CategoryID = cat.ID;
                           poi.ProvinceID = Int32.Parse(temp[2], ci);
                           poi.DistrictID = Int32.Parse(temp[3], ci);
                           poi.NeighborhoodID = Int32.Parse(temp[4], ci);
                           poi.TableName = temp[5];
                           poi.Longitude = double.Parse(temp[6].Replace(',', '.'), ci);
                           poi.Longitude = double.Parse(temp[7].Replace(',', '.'), ci);
                           poi.Address = temp[8];
                           m_PoiOperations.CreatePoi(poi);
                       }

                       return "";
                   }
                   else
                   {
                       return "Lütfen bir dosya seçiniz";
                   }
               });
        }

    }
}
