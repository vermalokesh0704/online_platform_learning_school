<%@ WebHandler Language="C#" Class="File" %>

using System;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.IO;
public class File : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        try
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            string host = HttpContext.Current.Request.Url.Host;
            string l = HttpContext.Current.Request.Url.PathAndQuery;
            string urlName = HttpContext.Current.Request.UrlReferrer.AbsolutePath.ToString();
            if (urlName == "/Default.aspx")
            {
                //upload_doc fu = new upload_doc();
                //Utilities util = new Utilities();
                //ReturnClass.ReturnBool rb = new ReturnClass.ReturnBool();
                //ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
                //da_upload_doc da = new da_upload_doc();
                //fu.Action_id = context.Request.QueryString["id"].ToString();
                //byte[] bytes= null;
                //string contentType="";
                //string name="";
                //dt = da.get_upload_details_by_id(fu);
                //if (dt.table.Rows.Count > 0)
                //{
                //    bytes = (byte[])dt.table.Rows[0]["Data"];
                //    contentType = dt.table.Rows[0]["ContentType"].ToString();
                //    name = dt.table.Rows[0]["Name"].ToString();

                //}

                //    context.Response.Clear();
                //    context.Response.Buffer = true;
                //    context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + name);
                //    context.Response.ContentType = contentType;
                //    context.Response.BinaryWrite(bytes);
                //    context.Response.End();



                int id = int.Parse(context.Request.QueryString["id"]);
                byte[] bytes;
                string contentType;
                string strConnString = ConfigurationManager.ConnectionStrings["online_learning"].ConnectionString;
                string name;
                using (MySqlConnection con = new MySqlConnection(strConnString))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.CommandText = "SELECT Name, Data, contentType FROM online_videos WHERE video_id=@Id";
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Connection = con;
                        con.Open();
                        MySqlDataReader sdr = cmd.ExecuteReader();
                        sdr.Read();
                        bytes = (byte[])sdr["Data"];

                        contentType = sdr["contentType"].ToString();
                        name = sdr["Name"].ToString();
                        con.Close();
                    }
                }
                context.Response.Clear();
                context.Response.Buffer = true;
                //   context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + name);
                context.Response.ContentType = contentType;
                context.Response.BinaryWrite(bytes);
                context.Response.End();
            }
            else
            {

            }
        }catch(Exception ex)
        {

        }
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}