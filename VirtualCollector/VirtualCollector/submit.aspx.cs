using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace VirtualCollector
{
    public partial class submit : System.Web.UI.Page
    {
        private string name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                name = (string)Session["usrname"];
            }
            catch (Exception ex)
            {
            }
            Label1.Text = name + " , Welcome!";
            LabelUsrName.Text = name;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {

            if (TextboxCode.Text.Length <= 20)
            {
                return;
            }

            MySqlConnection conn;
            string h_connString = "server=localhost;user id=root; password=2000021177lty; port=3306; database=judge; pooling=false; charset=utf8; Allow User Variables=True";//根据实际修改
            conn = new MySqlConnection(h_connString);
            try
            {                
                conn.Open();
                string insertstring = "insert into main(submit_author,submit_time,submit_problem" +
                    ",submit_code,judge_status,judge_result)values(" +
                    "'" + LabelUsrName.Text + "',@submit_time,'" + DropDownListProblems.SelectedItem.Text +
                    "',@submit_code,0,0)";
                MySqlCommand sc = new MySqlCommand(insertstring, conn);

                //time
                MySqlParameter ptime = new MySqlParameter("@submit_time", MySqlDbType.DateTime);
                ptime.Value = DateTime.Now;
                sc.Parameters.Add(ptime);

                //code
                MySqlParameter pcode = new MySqlParameter("@submit_code", MySqlDbType.Text);
                pcode.Value = TextboxCode.Text;
                sc.Parameters.Add(pcode);

                sc.ExecuteNonQuery();
                conn.Close();
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            /*
            MySqlConnection conn;
            string h_connString = "server=localhost;user id=root; password=2000021177lty; port=3306; database=judge; pooling=false; charset=utf8; Allow User Variables=True";//根据实际修改
            conn = new MySqlConnection(h_connString);
            try
            {
                conn.Open();
                string insertstring = "DELETE FROM main";
                MySqlCommand sc = new MySqlCommand(insertstring, conn);
                sc.ExecuteNonQuery();
                conn.Close();
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            */
        }

    }
}