using TakeALook.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model
{
    public class Poi : DBObjectBase, IPoi
    {
        public int CategoryID { get; set; }
        public int ProvinceID { get; set; }
        public int DistrictID { get; set; }
        public int NeighborhoodID { get; set; }
        public string TableName { get; set; }
        public string CustomID { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Address { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
