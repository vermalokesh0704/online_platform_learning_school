using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for da_upload_doc
/// </summary>
public class da_upload_doc
{
    ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnBool rc = new ReturnClass.ReturnBool();

    string sipb = "Industry";
    string query;
    
    db_maria_connection da = new db_maria_connection();
    public da_upload_doc()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public ReturnClass.ReturnBool Upload_Video(upload_doc fu)
    {
        //query = "INSERT INTO online_videos (Name,Data,contentType,path)VALUES(@Name,@Data,@contentType,@path)";
        query = "INSERT INTO online_videos (Name,contentType,path,extension)VALUES(@Name,@contentType,@path,@extension)";
        MySqlParameter[] pm1 = new MySqlParameter[]{
                new MySqlParameter("Name", fu.Document_name),
             //   new MySqlParameter("Data", fu.Document_data),
                  new MySqlParameter("contentType", fu.Mime_type),
                    new MySqlParameter("path", fu.Panjiyan_category_id),
                      new MySqlParameter("extension", fu.File_extn)
            };
        rc = da.executeInsertQuery(query, pm1);
        return rc;
    }


    public ReturnClass.ReturnDataTable get_upload_details()
    {
        // query = @"select video_id,Name,Data,contentType,path  from online_videos ";
        query = @"select video_id,Name,contentType,path  from online_videos ";
        dt = da.executeSelectQuery(query);
        return dt;
    }

    public ReturnClass.ReturnDataTable get_upload_details_by_id(upload_doc d)
    {
        query = @"select Name,Data,contentType  from online_videos where video_id=@video_id ";
        MySqlParameter[] pr = new MySqlParameter[]{
            new MySqlParameter("video_id",d.Action_id)};
        dt = da.executeSelectQuery(query);
        return dt;
    }
}