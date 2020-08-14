using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for olu_da_layer_new
/// </summary>
public class olu_da_layer_new : ReturnClass
{
    ReturnDataTable dt = new ReturnDataTable();
    ReturnBool rb = new ReturnBool();
    db_maria_connection db = new db_maria_connection();
    string query = null;
    public olu_da_layer_new()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public ReturnDataTable get_topic_name(bl_common ur)
    {
        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("Name", ur.Desc + "%"),
                new MySqlParameter("Subject_id", ur.Symptom_id )

            };
        query = @"select Topic_id as id,Topic_Name as Name, Topic_Description as description from topics_wise_subject where  Topic_Name like @Name and Subject_id=@Subject_id group by Topic_id order by Topic_Name limit 20";
        dt = db.executeSelectQuery(query, pm);
        return dt;
    }

    public ReturnDataTable get_subject_id(bl_common ur)
    {
        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("Name", ur.Desc + "%"),
                new MySqlParameter("class_id", ur.Class_code )
            };
        query = @"select * from subjects s where s.class_id=@class_id and subject_name like @Name ";
        dt = db.executeSelectQuery(query, pm);
        return dt;
    }
    public ReturnDataTable get_subject_id(olu_ba_layer ur)
    {
        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("Name", ur.Desc + "%"),
                new MySqlParameter("class_id", ur.Class_code )
            };
        query = @"select * from subjects s where s.class_id=@class_id and subject_name like @Name ";
        dt = db.executeSelectQuery(query, pm);
        return dt;
    }
    public ReturnDataTable get_topic_code(bl_common ur)
    {
        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("id", ur.Desc )
            };
        query = @"select Topic_id as id,Topic_Name as Name, Topic_Description as description from topics_wise_subject where Topic_id=@id group by Topic_id order by Topic_Name ";
        dt = db.executeSelectQuery(query, pm);
        return dt;
    }


    public ReturnDataTable get_class_code(olu_ba_layer ur)
    {
        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("Class_Name", ur.Class_id )
            };
        query = @"select * from classes where Class_Name=@Class_Name ";
        dt = db.executeSelectQuery(query, pm);
        return dt;
    }


    public ReturnDataTable get_class_videos(olu_ba_layer ur)
    {
        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("Subject_id", ur.Symptom_id )
            };
        query = @"select * from topics_wise_subject t
join video_topic_wise v on v.Topic_id=t.Topic_id
where t.Subject_id=@Subject_id";
        dt = db.executeSelectQuery(query, pm);
        return dt;
    }

}