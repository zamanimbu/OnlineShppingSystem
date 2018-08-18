using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineShoppingCartApp.UI
{
    public partial class main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public Button SignOutButton
        {
            get { return signOutButtonMasterPage; }
            set { signOutButtonMasterPage = value; }

        }

    }
}