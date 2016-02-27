using TakeALook.Model;
using TakeALook.Model.Interface;
using TakeALook.Operation.Interface;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

namespace TakeALook.Operation
{
    public interface IParameteredUserControl
    {
        string Parameters { get; set; }
    }
    public class CustomUserControl : UserControl, IParameteredUserControl
    {
        public CustomUserControl() { }

        public string Parameters { get; set; }
    }
    public class UserControlOperations : IUserControlOperations
    {
        public IUserControlDto LoadUserControl(IUserControlRequest request)
        {
            using (Page page = new PageOverride())
            {
                CustomUserControl parameterizedUserControl = (CustomUserControl)page.LoadControl(string.Format("/App_Resource/Custom.UI.Controls.dll/Custom.UI.Controls.{0}.ascx", request.NameOfControl));
                if (parameterizedUserControl != null && request.Inputs != null)
                {
                    parameterizedUserControl.Parameters = JsonConvert.SerializeObject(request.Inputs);
                }
                page.Controls.Add(parameterizedUserControl);
                using (StringWriter writer = new StringWriter())
                {
                    page.Controls.Add(parameterizedUserControl);
                    HttpContext.Current.Server.Execute(page, writer, false);
                    string[] temp = Regex.Split(writer.ToString(), "<script>");
                    IUserControlDto uc = new UserControlDto();
                    uc.HtmlScript = temp[0];
                    uc.JqueryScript = temp[1].Replace("</script>", string.Empty);
                    return uc;
                }
            }
        }
    }
}
