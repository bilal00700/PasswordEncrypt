using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.SessionState;

namespace Password
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlConnection vcon = new SqlConnection(ConfigurationManager.ConnectionStrings["HrAndPayroll"].ToString());

            string query = string.Format("SELECT * FROM [UserLogins]");
            
            vcon.Open();
            SqlCommand cmd = new SqlCommand(query, vcon);//Advised to use parameterized query
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                HttpContext context = HttpContext.Current;
                context.Session["syscode"] = dr.GetValue(3).ToString();
                vcon.Close();
                Response.Redirect("~/WebForm1.aspx");
           
            }
             
        
        }
    }
}