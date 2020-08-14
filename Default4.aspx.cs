using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Configuration;
using MySql.Data.MySqlClient;

public partial class Default4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            DataTable dummy = new DataTable();
            dummy.Columns.Add("Name");
            dummy.Columns.Add("path");
            dummy.Rows.Add();
            gvCustomers.DataSource = dummy;
            gvCustomers.DataBind();
        }
    }

    [WebMethod]
    public static string GetCustomers()
    {
        string constr = ConfigurationManager.ConnectionStrings["online_learning"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(constr))
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "select video_id,Name,contentType,path  from online_videos ";
                cmd.Connection = con;
                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    return ds.GetXml();
                }
            }
        }
    }


}