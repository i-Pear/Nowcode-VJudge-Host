using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using Register;

namespace VirtualCollector
{
    public partial class board : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHelper rh = new RegisterHelper("vjudge", RegisterHelper.RegDomain.CurrentUser);
            ifr1.Src = rh.ReadRegeditKey("ifr1").ToString();

            string name = "";
            try
            {
                name = (string)Session["usrname"];
            }
            catch (Exception ex)
            {
            }

            MySqlConnection conn;
            string h_connString = "server=localhost;user id=root; password=2000021177lty; port=3306; database=judge; pooling=false; charset=utf8; Allow User Variables=True";//根据实际修改
            conn = new MySqlConnection(h_connString);
            try
            {
                conn.Open();
                string query = "";
                if (name == "")
                {
                    query = "select submit_author,submit_time,submit_problem,judge_status,judge_remoteid from main order by submit_time limit 40";
                }
                else
                {
                    query = "select submit_author,submit_time,submit_problem,judge_status,judge_remoteid from main where submit_author = '"+name+"' order by submit_time limit 40";
                }
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, conn);
                DataSet dataSet = new DataSet();
                mySqlDataAdapter.Fill(dataSet, "main");
                conn.Close();
                GridView1.DataSource = dataSet;
                GridView1.DataBind();
                int count = GridView1.Rows.Count;
                GridView1.Height = (count + 1) * 30;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}