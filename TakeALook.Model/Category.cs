using TakeALook.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model
{
    public class Category : DBObjectBase, ICategory
    {
        public string Name { get; set; }
        public int IconID { get; set; }
        public int ListOrder { get; set; }
        public int RenderOrder { get; set; }
    }
}
