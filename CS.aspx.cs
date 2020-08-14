using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.BindDataList();
        }
    }

    private void BindDataList()
    {
        string strConnString = ConfigurationManager.ConnectionStrings["online_learning"].ConnectionString;
        using (MySqlConnection con = new MySqlConnection(strConnString))
        {
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT video_id, Name FROM online_videos ";
                cmd.Connection = con;
                con.Open();
                DataList1.DataSource = cmd.ExecuteReader();
                DataList1.DataBind();
                con.Close();
            }
        }
    }

    protected void Upload(object sender, EventArgs e)
    {
        using (BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream))
        {
            byte[] bytes = br.ReadBytes((int)FileUpload1.PostedFile.InputStream.Length);
            string strConnString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "INSERT INTO online_videos(Name, contentType, Data) VALUES (@Name, @ContentType, @Data)";
                    cmd.Parameters.AddWithValue("@Name", Path.GetFileName(FileUpload1.PostedFile.FileName));
                    cmd.Parameters.AddWithValue("@ContentType", "video/mp4");
                    cmd.Parameters.AddWithValue("@Data", bytes);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        Response.Redirect(Request.Url.AbsoluteUri);
    }
}