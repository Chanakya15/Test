using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Test
{
    public partial class grid : System.Web.UI.Page
    {
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayRecord();
            }
        }
        public void DisplayRecord()
        {
            string connStr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            con = new SqlConnection(connStr);
            SqlDataAdapter Adp = new SqlDataAdapter("select * from dbo.Names", con);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            grdNames.DataSource = Dt;
            grdNames.DataBind();
            con.Close();

        }

    }
}