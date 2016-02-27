using TakeALook.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeALook.Model
{
    /// <summary>
    /// Kendo controllerinin iletileceği dto
    /// </summary>
    public class UserControlDto : IUserControlDto
    {
        public string HtmlScript { get; set; }
        public string JqueryScript { get; set; }
        public int ShowingTab { get; set; }
    }

    #region PageOverride

    /// <summary>
    /// Pagee child eklenebilmesi için yaratılan pagein runat=server özelliğini işlevsiz kılar
    /// htmlform eklemeden sayfaya kontrol ekleyebilmemizi sağlar.
    /// yapılan testlerde runat=server eklenen kontrollerde kendoui'ın doğru çalışmadığı tespit edildi.
    /// </summary>
    public class PageOverride : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
        }
    }

    #endregion
}
