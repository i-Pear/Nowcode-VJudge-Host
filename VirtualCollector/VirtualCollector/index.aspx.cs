using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VirtualCollector
{
    public partial class index : System.Web.UI.Page
    {
        readonly Dictionary<string, string> pwdBook = new Dictionary<string, string> {
            { "admin", "admin" },
            { "user1",  "pwd1" }
        };

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string text = username.Text;
            string str2 = password.Text;
            bool flag = false;
            try
            {
                if (pwdBook[text] == str2)
                {
                    flag = true;
                }
            }
            catch (Exception)
            {
            }
            if (flag)
            {
                Session.Add("usrname", text);
                Server.Transfer("submit.aspx");
            }

        }
    }
}