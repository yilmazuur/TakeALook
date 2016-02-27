using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model.Interface
{
    public interface IUserControlDto
    {
        string HtmlScript { get; set; }
        string JqueryScript { get; set; }
        int ShowingTab { get; set; }
    }
}
