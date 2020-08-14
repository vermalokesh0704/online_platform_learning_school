using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for da_common
/// </summary>
public class da_common : ReturnClass
{
    ReturnDataTable dt = new ReturnDataTable();
    ReturnBool rb = new ReturnBool();
    db_maria_connection db = new db_maria_connection();
    string query = null;


    public ReturnDataTable bind_checkbox(bl_common ur)
    {
        query = "select * from symptoms s where s.affected_area_id=@affected_area_id order by name";

        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("affected_area_id",ur.Category)
            };

        dt = db.executeSelectQuery(query, pm);

        return dt;
    }

    public ReturnDataTable bind_checkbox_by_name(bl_common ur)
    {
        query = "select * from symptoms s where s.affected_area_id=@affected_area_id and  name like @Name order by name";

        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("affected_area_id",ur.Category),
                 new MySqlParameter("Name", ur.Desc_text + "%")
            };

        dt = db.executeSelectQuery(query, pm);

        return dt;
    }

    public ReturnDataTable bind_Remedy(bl_common ur)
    {
        query = "select * from cellsalt_symptom c where c.symptom_id in (" + ur.Symptom_id + ") order by symptom_id desc";
        dt = db.executeSelectQuery(query);
        return dt;
    }

    public ReturnDataTable bind_Remedy_cellsalt(bl_common ur)
    {
        query = "select * from cellsalts i where i.id in (" + ur.Cellsalt_id + ") group by id";
        dt = db.executeSelectQuery(query);
        return dt;
    }

    public ReturnDataTable bind_Remedy_cellsalt_single(bl_common ur)
    {
        query = "select * from cellsalts i where i.id=@id group by id";
        MySqlParameter[] pm = new MySqlParameter[]
        {
                new MySqlParameter("id",ur.Cellsalt_single)
        };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }


    public ReturnDataTable bind_Remedy_cellsalt_by_id(bl_common ur)
    {
        query = "select * from cellsalts i where i.id=@id group by id";
        MySqlParameter[] pm = new MySqlParameter[]
          {
                new MySqlParameter("id",ur.Cellsalt_id)
          };
        dt = db.executeSelectQuery(query, pm);
        return dt;
    }

    public ReturnDataTable get_diseases_name(bl_common ur)
    {
        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("Name", ur.Desc + "%")
            };
        query = @"select id,Name,description from diseases where  Name like @Name group by id order by Name limit 20";
        dt = db.executeSelectQuery(query, pm);
        return dt;
    }

    public ReturnDataTable get_symptoms_name(bl_common ur)
    {
        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("Name", ur.Desc + "%")
            };
        query = @"select id,name,description from symptoms  where name like @Name group by id order by Name limit 20";
        dt = db.executeSelectQuery(query, pm);
        return dt;
    }

    public ReturnDataTable get_diseases_code(bl_common ur)
    {
        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("id", ur.Desc )
            };
        query = @"select id,Name,description from diseases where id=@id group by id order by Name ";
        dt = db.executeSelectQuery(query, pm);
        return dt;
    }


    public ReturnDataTable get_affrected_code(bl_common ur)
    {
        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("id", ur.Desc )
            };
        query = @"select s.affected_area_id from symptoms s where s.id=@id order by name; ";
        dt = db.executeSelectQuery(query, pm);
        return dt;
    }

    public ReturnDataTable get_diseases_by_name(bl_common ur)
    {
        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("id", ur.Desc)
            };
        query = @"select cc.name, dc.effect from diseases d
join disease_cellsalts dc on dc.disease_id= d.id
join cellsalts cc on cc.id= dc.cellsalt_id
 where d.id=@id group by cc.id order by cc.name";
        dt = db.executeSelectQuery(query, pm);
        return dt;
    }
    public ReturnDataTable check_profile_update(bl_Usr_Registration ur)
    {
        query = "select * from user_login s where s.user_id=@user_id";

        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("user_id",ur.User_Id)
            };

        dt = db.executeSelectQuery(query, pm);

        return dt;
    }

    public ReturnBool Update_user_profile(bl_Usr_Registration ur)
    {
       
            query = @"update user_login set profile_update=@profile_update where user_id=@user_id";

            MySqlParameter[] pm = new MySqlParameter[]
                {
                new MySqlParameter("user_id",ur.User_Id),
                new MySqlParameter("profile_update","Y")
                };

            rb = db.executeUpdateQuery(query, pm);
            
        return rb;
    }


    public ReturnBool Insert_know_my_cell_slat_quries(bl_common ur)
    {

        query = @"insert into know_my_cekk_salt_queries (user_id,client_ip,date_time,Symptom_id,u_category,y_category) VALUES(@user_id,@client_ip,@date_time,@Symptom_id,@u_category,@y_category)";

        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("user_id",ur.User_id),
                new MySqlParameter("client_ip",ur.Client_ip),
                new MySqlParameter("date_time",ur.Date_time),
                new MySqlParameter("Symptom_id",ur.Symptom_id),
                new MySqlParameter("u_category",ur.U_category),
                new MySqlParameter("y_category",ur.Y_category)
            };

        rb = db.executeUpdateQuery(query, pm);

        return rb;
    }

    public ReturnDataTable know_my_cell_salt_query_details(bl_common ur)
    {
        query = @"select *,date_format(date_time,'%d/%m/%Y %h:%i:%s %p') as datetime from know_my_cekk_salt_queries where user_id=@user_id order by date_time desc;";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id)

       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }

    public ReturnDataTable know_my_cell_salt_query_details_by_id(bl_common ur)
    {
        query = @"select *,date_format(date_time,'%d/%m/%Y %h:%i:%s %p') as datetime from know_my_cekk_salt_queries where user_id=@user_id and id=@id order by date_time desc;";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id),
                 new MySqlParameter("id",ur.File_id)

       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }

    public ReturnDataTable get_petscorner_name(bl_common ur)
    {
        query = @"select id,Name,description from pets_corner group by id order by Name ";
        dt = db.executeSelectQuery(query);
        return dt;
    }


    public ReturnDataTable get_sportscorner_name(bl_common ur)
    {
        query = @"select id,Name,description from sports_corner group by id order by Name ";
        dt = db.executeSelectQuery(query);
        return dt;
    }

    public ReturnDataTable get_pets_by_corner_name(bl_common ur)
    {
        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("id", ur.Desc)
            };
        query = @"select cc.name, dc.effect from pets_corner d
join pets_corner_cellsalts dc on dc.disease_id= d.id
join cellsalts cc on cc.id= dc.cellsalt_id
 where d.id=@id group by cc.id order by cc.name";
        dt = db.executeSelectQuery(query, pm);
        return dt;
    }


    public ReturnDataTable get_sports_by_corner_name(bl_common ur)
    {
        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("id", ur.Desc)
            };
        query = @"select cc.name, dc.effect from pets_corner d
join sports_corner_cellsalts dc on dc.disease_id= d.id
join cellsalts cc on cc.id= dc.cellsalt_id
 where d.id=@id group by cc.id order by cc.name";
        dt = db.executeSelectQuery(query, pm);
        return dt;
    }
}