using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model
{
    /// <summary>
    /// Bundan derive edilenlerin repositorysi oluşturulabilir.
    /// </summary>
    public abstract class DBObjectBase
    {
        public int ID { get; set; }
    }
}
