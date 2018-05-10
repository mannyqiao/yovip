
namespace Enjoy.Portal.Dashboard.Models
{
    using System.Web.UI.WebControls;
    using System.Collections.Generic;

    public  class Portals
    {
        public virtual IEnumerable<MenuItem> Menus { get { return NavigationManagement.Menus; } }
        public virtual MenuItem Selected { get; set; }       
    }
}