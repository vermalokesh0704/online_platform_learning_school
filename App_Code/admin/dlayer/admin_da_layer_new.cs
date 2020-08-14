using MySql.Data.MySqlClient;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;


public class admin_da_layer_new : ReturnClass
{
    ReturnDataTable dt = new ReturnDataTable();
    ReturnBool rb = new ReturnBool();
    db_maria_connection db = new db_maria_connection();
    string query = null;
    public admin_da_layer_new()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public ReturnClass.ReturnDataTable INTSUB_class_id(olu_ba_layer co)
    {
        query = "SELECT IFNULL(MAX(CAST(SUBSTRING(Class_id,7,4) as UNSIGNED INTEGER)),0) as pid  from classes   WHERE year(date_time) = @c_year AND month(date_time)=@c_month ";
        MySqlParameter[] pr = new MySqlParameter[]{
            new MySqlParameter("c_year",co.C_year),
            new MySqlParameter("c_month",co.C_month),
        };
        dt = db.executeSelectQuery(query, pr);
        return dt;
    }

    public ReturnClass.ReturnDataTable INTSUB_subject_id(olu_ba_layer co)
    {
        query = "SELECT IFNULL(MAX(CAST(SUBSTRING(Subject_id,7,4) as UNSIGNED INTEGER)),0) as pid  from subjects   WHERE year(date_time) = @c_year AND month(date_time)=@c_month ";
        MySqlParameter[] pr = new MySqlParameter[]{
            new MySqlParameter("c_year",co.C_year),
            new MySqlParameter("c_month",co.C_month),
        };
        dt = db.executeSelectQuery(query, pr);
        return dt;
    }

    public ReturnClass.ReturnDataTable INTSUB_topic_id(olu_ba_layer co)
    {
        query = "SELECT IFNULL(MAX(CAST(SUBSTRING(Topic_id,7,4) as UNSIGNED INTEGER)),0) as pid  from topics_wise_subject   WHERE year(date_time) = @c_year AND month(date_time)=@c_month ";
        MySqlParameter[] pr = new MySqlParameter[]{
            new MySqlParameter("c_year",co.C_year),
            new MySqlParameter("c_month",co.C_month),
        };
        dt = db.executeSelectQuery(query, pr);
        return dt;
    }

    public ReturnClass.ReturnDataTable INTSUB_video_id(olu_ba_layer co)
    {
        query = "SELECT IFNULL(MAX(CAST(SUBSTRING(video_id,7,4) as UNSIGNED INTEGER)),0) as pid  from video_topic_wise   WHERE year(date_time) = @c_year AND month(date_time)=@c_month ";
        MySqlParameter[] pr = new MySqlParameter[]{
            new MySqlParameter("c_year",co.C_year),
            new MySqlParameter("c_month",co.C_month),
        };
        dt = db.executeSelectQuery(query, pr);
        return dt;
    }

    public ReturnBool Insert_class(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
            new MySqlParameter("Class_id", ur.Class_id),
                    new MySqlParameter("Class_Name", ur.Category),
                new MySqlParameter("client_ip", ur.Client_id),
                new MySqlParameter("user_id", ur.User_id),
                 new MySqlParameter("date_time",ur.Date_time)        
                      };

        query = @"INSERT INTO classes(Class_id,Class_Name,client_ip,user_id,date_time)
               VALUES(@Class_id,@Class_Name,@client_ip,@user_id,@date_time)";
        rb = db.executeInsertQuery(query, pm11);
        return rb;
    }

    public ReturnBool update_class(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                    new MySqlParameter("Class_Name", ur.Category),
                new MySqlParameter("Class_id", ur.Class_id)
                      };

        query = @"update classes set Class_Name=@Class_Name where Class_id=@Class_id";
        rb = db.executeInsertQuery(query, pm11);
        return rb;
    }

    public ReturnBool delete_class(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("Class_id", ur.Class_id)
                      };

        query = @"delete from  classes  where Class_id=@Class_id";
        rb = db.executeInsertQuery(query, pm11);
        return rb;
    }
    

    public ReturnDataTable select_class()
    {
        query = @"select * from classes";
        dt = db.executeSelectQuery(query);
        return dt;
    }



    public ReturnBool Insert_subject(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
              new MySqlParameter("Subject_id", ur.Subject_id),
                    new MySqlParameter("class_id", ur.Class_id),
                    new MySqlParameter("Subject_Name", ur.Category),
                new MySqlParameter("client_ip", ur.Client_id),
                new MySqlParameter("user_id", ur.User_id),
                 new MySqlParameter("date_time",ur.Date_time)
                      };

        query = @"INSERT INTO subjects(Subject_id,class_id,Subject_Name,client_ip,user_id,date_time)
               VALUES(@Subject_id,@class_id,@Subject_Name,@client_ip,@user_id,@date_time)";
        rb = db.executeInsertQuery(query, pm11);
        return rb;
    }

    public ReturnBool update_subject(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                    new MySqlParameter("Subject_Name", ur.Category),
                new MySqlParameter("Subject_id", ur.Subject_id),
                 new MySqlParameter("class_id", ur.Class_id)
                      };

        query = @"update subjects set Subject_Name=@Subject_Name,class_id=@class_id where Subject_id=@Subject_id";
        rb = db.executeInsertQuery(query, pm11);
        return rb;
    }

    public ReturnBool delete_subject(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("Subject_id", ur.Subject_id)
                      };

        query = @"delete from  subjects  where Subject_id=@Subject_id";
        rb = db.executeInsertQuery(query, pm11);
        return rb;
    }


    public ReturnDataTable select_subject()
    {
        query = @"select s.Subject_id,s.class_id,s.Subject_Name,c.Class_Name,concat(c.Class_Name,' - ',s.Subject_Name) as subjectname from subjects s
join classes c on c.Class_id=s.class_id";
        dt = db.executeSelectQuery(query);
        return dt;
    }



    public ReturnBool Insert_topic(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
            new MySqlParameter("Topic_id", ur.Topic_id),
                    new MySqlParameter("Subject_id", ur.Subject_id),
                    new MySqlParameter("Topic_Name", ur.Headline),
                    new MySqlParameter("Topic_Description",ur.Description),
                new MySqlParameter("client_ip", ur.Client_id),
                new MySqlParameter("user_id", ur.User_id),
                 new MySqlParameter("date_time",ur.Date_time)
                 
                      };

        query = @"INSERT INTO topics_wise_subject(Topic_id,Subject_id,Topic_Name,Topic_Description,client_ip,user_id,date_time)
               VALUES(@Topic_id,@Subject_id,@Topic_Name,@Topic_Description,@client_ip,@user_id,@date_time)";
        rb = db.executeInsertQuery(query, pm11);
        return rb;
    }

    public ReturnBool update_topic(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                    new MySqlParameter("Topic_Name", ur.Headline),
                    new MySqlParameter("Subject_id", ur.Subject_id),
                    new MySqlParameter("Topic_Description", ur.Description),
                new MySqlParameter("Topic_id", ur.Topic_id)
                
                      };

        query = @"update topics_wise_subject set Topic_Name=@Topic_Name,Topic_Description=@Topic_Description,Subject_id=@Subject_id where Topic_id=@Topic_id";
        rb = db.executeInsertQuery(query, pm11);
        return rb;
    }

    public ReturnBool delete_topic(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("Topic_id", ur.Topic_id)
                      };

        query = @"delete from  topics_wise_subject  where Topic_id=@Topic_id";
        rb = db.executeInsertQuery(query, pm11);
        return rb;
    }


    public ReturnDataTable select_topic()
    {
        query = @"select t.Topic_id,t.Subject_id,t.Topic_Name,t.Topic_Description,s.Subject_Name,concat(c.Class_Name,' - ',s.Subject_Name) as subjectname from topics_wise_subject t
join subjects s on s.Subject_id=t.Subject_id
join classes c on c.Class_id=s.class_id";
        dt = db.executeSelectQuery(query);
        return dt;
    }

    public ReturnDataTable select_topic_for_video()
    {
        query = @"select t.Topic_id,t.Subject_id,t.Topic_Name,t.Topic_Description,s.Subject_Name,concat(c.Class_Name,' - ',s.Subject_Name,' - ',t.Topic_Name) as topicname from topics_wise_subject t
join subjects s on s.Subject_id=t.Subject_id
join classes c on c.Class_id=s.class_id";
        dt = db.executeSelectQuery(query);
        return dt;
    }


    public ReturnBool Insert_Video(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
            new MySqlParameter("video_id", ur.Video_id),
            new MySqlParameter("Topic_id", ur.Topic_id),
                    new MySqlParameter("video_heading", ur.Headline),
                    new MySqlParameter("video_description", ur.Description),
                    new MySqlParameter("video_url",ur.User_type),
                    new MySqlParameter("contentType",ur.Mime_type),
                    new MySqlParameter("path",ur.Panjiyan_category_id),
                    new MySqlParameter("extension",ur.File_extn),
                new MySqlParameter("client_ip", ur.Client_id),
                new MySqlParameter("user_id", ur.User_id),
                 new MySqlParameter("date_time",ur.Date_time)

                      };

        query = @"INSERT INTO video_topic_wise(video_id,Topic_id,video_heading,video_description,video_url,contentType,path,extension,client_ip,user_id,date_time)
               VALUES(@video_id,@Topic_id,@video_heading,@video_description,@video_url,@contentType,@path,@extension,@client_ip,@user_id,@date_time)";
        rb = db.executeInsertQuery(query, pm11);
        return rb;
    }

    public ReturnBool update_Video(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
            new MySqlParameter("video_id", ur.Video_id),
            new MySqlParameter("Topic_id", ur.Topic_id),
                    new MySqlParameter("video_heading", ur.Headline),
                    new MySqlParameter("video_description", ur.Description),
                    new MySqlParameter("video_url",ur.User_type),
                    new MySqlParameter("contentType",ur.Mime_type),
                    new MySqlParameter("path",ur.Panjiyan_category_id),
                    new MySqlParameter("extension",ur.File_extn)
         
                      };

        query = @"update video_topic_wise set Topic_id=@Topic_id,video_heading=@video_heading,video_description=@video_description,video_url=@video_url,contentType=@contentType,path=@path,extension=@extension where video_id=@video_id";
        rb = db.executeInsertQuery(query, pm11);
        return rb;
    }

    public ReturnBool delete_Video(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("video_id", ur.Video_id)
                      };

        query = @"delete from  video_topic_wise  where video_id=@video_id";
        rb = db.executeInsertQuery(query, pm11);
        return rb;
    }


    public ReturnDataTable select_Video()
    {
        query = @"select v.video_id,v.Topic_id,v.video_heading,v.video_description,v.video_url,v.video_url,v.contentType,v.path,v.extension,t.Topic_Name,
concat(c.Class_Name,' - ', s.Subject_Name,' - ',t.Topic_Name) as topicname from video_topic_wise v
join topics_wise_subject t on t.Topic_id=v.Topic_id
join subjects s on s.Subject_id=t.Subject_id
join classes c on c.Class_id=s.class_id";
        dt = db.executeSelectQuery(query);
        return dt;
    }


}