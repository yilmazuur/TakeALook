using TakeALook.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model
{
    /// <summary>
    /// Poilerin category iconu
    /// </summary>
    public class Icon : DBObjectBase, IIcon 
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
