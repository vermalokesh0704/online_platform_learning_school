using MySql.Data.MySqlClient;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

/// <summary>
/// Summary description for dl_Usr_Registration
/// </summary>
public class dl_Usr_Registration : ReturnClass
{
    ReturnDataTable dt = new ReturnDataTable();
    ReturnBool rb = new ReturnBool();
    db_maria_connection db = new db_maria_connection();
    string query = null;

    public dl_Usr_Registration()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public ReturnDataTable select_class()
    {
        query = @"select * from incr where id in ('9','10','11','12')";
        dt = db.executeSelectQuery(query);
        return dt;
    }
    public ReturnDataTable select_stream()
    {
        query = @"select * from ddl_cat_list d where d.category='Stream' order by sort_order";
        dt = db.executeSelectQuery(query);
        return dt;
    }

    public ReturnDataTable check_user_mobile(bl_Usr_Registration ur)
    {
        query = "SELECT * FROM user_registration WHERE applicant_mobile=@applicant_mobile and applicant_mobile_verified=@applicant_mobile_verified";

        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("applicant_mobile",ur.Telephone_No),
                new MySqlParameter("applicant_mobile_verified","Y")

            };

        dt = db.executeSelectQuery(query, pm);

        return dt;
    }
    public ReturnDataTable check_user_email(bl_Usr_Registration ur)
    {
        query = "SELECT * FROM user_registration WHERE applicant_email=@applicant_email and applicant_email_verified=@applicant_email_verified";

        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("applicant_email",ur.Email),
                new MySqlParameter("applicant_email_verified","Y")

            };

        dt = db.executeSelectQuery(query, pm);

        return dt;
    }
    //public ReturnDataTable check_user_email(bl_Usr_Registration ur)
    //{
    //    query = "SELECT * FROM user_registration WHERE applicant_email=@applicant_email and applicant_email_verified=@applicant_email_verified";

    //    MySqlParameter[] pm = new MySqlParameter[]
    //        {
    //            new MySqlParameter("applicant_email",ur.Email),
    //            new MySqlParameter("applicant_email_verified","Y")

    //        };

    //    dt = db.executeSelectQuery(query, pm);

    //    return dt;
    //}


    public ReturnBool Update_user_signup_internally(bl_Usr_Registration ur)
    {
        using (TransactionScope transScope = new TransactionScope())
        {
            query = @"update user_registration set 	applicant_active=@applicant_active,applicant_mobile_verified=@applicant_mobile_verified 
where applicant_mobile=@applicant_mobile and applicant_mobile_verified=@applicant_mobile_verifiedd and
applicant_active=@applicant_activee and date_format(date_time,'%Y/%m/%d')=@date_time";

            MySqlParameter[] pm = new MySqlParameter[]
                {
                new MySqlParameter("applicant_mobile",ur.Cell_No),
                new MySqlParameter("applicant_active","Y"),
                new MySqlParameter("applicant_mobile_verified","Y"),
                new MySqlParameter("applicant_mobile_verifiedd","N"),
                new MySqlParameter("applicant_activee","N"),
                new MySqlParameter("date_time",ur.Action_Date)
                };

            rb = db.executeUpdateQuery(query, pm);
            if (rb.status == true)
            {
                query = @"update user_login set applicant_verified=@applicant_verified where 
applicant_mobile=@applicant_mobile and	
applicant_verified=@applicant_verifiedd and date_format(date_time,'%Y/%m/%d')=@date_time";

                MySqlParameter[] pmm = new MySqlParameter[]
                    {
                new MySqlParameter("applicant_mobile",ur.Cell_No),
                new MySqlParameter("applicant_verified","Y"),
                new MySqlParameter("applicant_verifiedd","N"),
                new MySqlParameter("date_time",ur.Action_Date)
                    };

                rb = db.executeUpdateQuery(query, pmm);
            }

            if (rb.status == true)
            {
                if (ur.User_type == "USER")
                {
                    query = @"insert into  user_profile_master (user_id,client_ip,date_time,profile_update) VALUES(@user_id,@client_ip,@date_time,@profile_update)";

                    MySqlParameter[] pmm = new MySqlParameter[]
                        {
                new MySqlParameter("user_id",ur.Cell_No),
                new MySqlParameter("client_ip",ur.ClientIp),
                new MySqlParameter("profile_update","N"),
                new MySqlParameter("date_time",ur.Action_Date)
                        };

                    rb = db.executeInsertQuery(query, pmm);
                }
                //else if (ur.User_type == "DOC")
                //{
                //    query = @"insert into  doctor_profile_master (user_id,client_ip,date_time,profile_update) VALUES(@user_id,@client_ip,@date_time,@profile_update)";

                //    MySqlParameter[] pmm = new MySqlParameter[]
                //        {
                //new MySqlParameter("user_id",ur.Cell_No),
                //new MySqlParameter("client_ip",ur.ClientIp),
                //new MySqlParameter("profile_update","N"),
                //new MySqlParameter("date_time",ur.Action_Date)
                //        };

                //    rb = db.executeInsertQuery(query, pmm);
                //}
                if (rb.status == true)
                {
                    query = @"update user_family_members set verified=@verified where 
mobile=@mobile and date_format(date_time,'%Y/%m/%d')=@date_time";

                    MySqlParameter[] pmm = new MySqlParameter[]
                        {
                new MySqlParameter("mobile",ur.Cell_No),
                new MySqlParameter("verified","Y"),
                new MySqlParameter("date_time",ur.Action_Date)
                        };

                    rb = db.executeUpdateQuery(query, pmm);
                }
            }

            if (rb.status == true)
            {
                transScope.Complete();
            }
        }
        return rb;
    }
    public ReturnBool Update_user_signup(bl_Usr_Registration ur)
    {
        using (TransactionScope transScope = new TransactionScope())
        {
            query = @"update user_registration set 	applicant_active=@applicant_active,applicant_mobile_verified=@applicant_mobile_verified 
where applicant_mobile=@applicant_mobile and applicant_mobile_verified=@applicant_mobile_verifiedd and
applicant_active=@applicant_activee and date_format(date_time,'%Y/%m/%d')=@date_time";

            MySqlParameter[] pm = new MySqlParameter[]
                {
                new MySqlParameter("applicant_mobile",ur.Cell_No),
                new MySqlParameter("applicant_active","Y"),
                new MySqlParameter("applicant_mobile_verified","Y"),
                new MySqlParameter("applicant_mobile_verifiedd","N"),
                new MySqlParameter("applicant_activee","N"),
                new MySqlParameter("date_time",ur.Action_Date)
                };

            rb = db.executeUpdateQuery(query, pm);
            if (rb.status == true)
            {
                
                query = @"update user_login set applicant_verified=@applicant_verified where 
applicant_mobile=@applicant_mobile and	
applicant_verified=@applicant_verifiedd and date_format(date_time,'%Y/%m/%d')=@date_time";

                
                MySqlParameter[] pmm = new MySqlParameter[]
                    {
                new MySqlParameter("applicant_mobile",ur.Cell_No),
                new MySqlParameter("applicant_verified",ur.ACK),
                new MySqlParameter("applicant_verifiedd","N"),
                new MySqlParameter("date_time",ur.Action_Date)
                    };

                rb = db.executeUpdateQuery(query, pmm);
            }

            if (rb.status == true)
            {
                if (ur.User_type == "USER")
                {
                    query = @"insert into  user_profile_master (user_id,client_ip,date_time,profile_update) VALUES(@user_id,@client_ip,@date_time,@profile_update)";

                    MySqlParameter[] pmm = new MySqlParameter[]
                        {
                new MySqlParameter("user_id",ur.Cell_No),
                new MySqlParameter("client_ip",ur.ClientIp),
                new MySqlParameter("profile_update","N"),
                new MySqlParameter("date_time",ur.Action_Date)
                        };

                    rb = db.executeInsertQuery(query, pmm);
                }
                else if (ur.User_type == "TEA")
                {
                    query = @"insert into  teacher_profile_master (user_id,client_ip,date_time,profile_update) VALUES(@user_id,@client_ip,@date_time,@profile_update)";

                    MySqlParameter[] pmm = new MySqlParameter[]
                        {
                new MySqlParameter("user_id",ur.Cell_No),
                new MySqlParameter("client_ip",ur.ClientIp),
                new MySqlParameter("profile_update","N"),
                new MySqlParameter("date_time",ur.Action_Date)
                        };

                    rb = db.executeInsertQuery(query, pmm);
                }

            }

            if (rb.status == true)
            {
                transScope.Complete();
            }
        }
        return rb;
    }

    public ReturnBool Insert_user_signup_internally(bl_Usr_Registration ur)
    {
        using (TransactionScope transScope = new TransactionScope())
        {
            query = @"insert into user_registration (applicant_first_name,applicant_last_name,applicant_email,applicant_mobile,
applicant_password,client_ip,applicant_active,applicant_mobile_verified,applicant_email_verified,date_time,role_id,user_type)
values(@applicant_first_name,@applicant_last_name,@applicant_email,@applicant_mobile,@applicant_password,@client_ip,
@applicant_active,@applicant_mobile_verified,@applicant_email_verified,@date_time,@role_id,@user_type)";

            MySqlParameter[] pm = new MySqlParameter[]
                {
                new MySqlParameter("applicant_first_name",ur.Name),
                new MySqlParameter("applicant_last_name",ur.Last_name),
                new MySqlParameter("applicant_email",ur.Email),
                new MySqlParameter("applicant_mobile",ur.Cell_No),
                new MySqlParameter("applicant_password",ur.Password),
                new MySqlParameter("client_ip",ur.ClientIp),
                new MySqlParameter("applicant_active",ur.Applicant_active),
                new MySqlParameter("applicant_mobile_verified",ur.Applicant_mobile_verified),
                new MySqlParameter("applicant_email_verified",ur.Applicant_email_verified),
                new MySqlParameter("date_time",ur.Action_Date),
                new MySqlParameter("role_id",ur.Role_Id),
                new MySqlParameter("user_type",ur.User_type)
                };

            rb = db.executeInsertQuery(query, pm);

            if (rb.status == true)
            {
                query = @"INSERT INTO user_login (applicant_mobile, applicant_email, applicant_first_name, 
              applicant_last_name, applicant_verified, client_ip, user_id, role_id,user_type,date_time,applicant_password,profile_update,refer_code,user_for) 
              VALUES (@applicant_mobile,@applicant_email,@applicant_first_name,@applicant_last_name,@applicant_verified,@client_ip,@user_id,@role_id,@user_type,@date_time,@applicant_password,@profile_update,@refer_code,@user_for)";

                MySqlParameter[] pmm = new MySqlParameter[]
                    {
                new MySqlParameter("applicant_mobile",ur.Cell_No),
                new MySqlParameter("applicant_email",ur.Email),
                new MySqlParameter("applicant_first_name",ur.Name),
                new MySqlParameter("applicant_last_name",ur.Last_name),
                new MySqlParameter("applicant_verified",ur.Applicant_active),
                new MySqlParameter("client_ip",ur.ClientIp),
                new MySqlParameter("user_id",ur.Cell_No),
                new MySqlParameter("role_id",ur.Role_Id),
                new MySqlParameter("user_type",ur.User_type),
                new MySqlParameter("date_time",ur.Action_Date),
                    new MySqlParameter("applicant_password",ur.Password),
                    new MySqlParameter("profile_update","N"),
                     new MySqlParameter("refer_code",ur.Refer_code),
                     new MySqlParameter("user_for",ur.Family_member)

                    };
                rb = db.executeInsertQuery(query, pmm);
            }
            if (rb.status == true)
            {
                query = @"INSERT INTO user_family_members (family_member, first_name, last_name, 
              mobile, email_id, client_ip, user_id, date_time,verified) 
              VALUES (@family_member,@first_name,@last_name,@mobile,@email_id,@client_ip,@user_id,@date_time,@verified)";

                MySqlParameter[] pmm = new MySqlParameter[]
                    {
                new MySqlParameter("family_member",ur.Family_member),
                new MySqlParameter("first_name",ur.Name),
                new MySqlParameter("last_name",ur.Last_name),
                new MySqlParameter("client_ip",ur.ClientIp),
                new MySqlParameter("user_id",ur.User_Id),
                new MySqlParameter("mobile",ur.Cell_No),
                new MySqlParameter("email_id",ur.Email),
                new MySqlParameter("date_time",ur.Action_Date),
                new MySqlParameter("verified","N"),

                    };
                rb = db.executeInsertQuery(query, pmm);
            }
            if (rb.status == true)
            {
                transScope.Complete();
            }
        }
        return rb;
    }

    public ReturnBool Insert_user_signup(bl_Usr_Registration ur)
    {
        using (TransactionScope transScope = new TransactionScope())
        {
            query = @"insert into user_registration (applicant_first_name,applicant_last_name,applicant_email,applicant_mobile,
applicant_password,client_ip,applicant_active,applicant_mobile_verified,applicant_email_verified,date_time,role_id,user_type,class,stream)
values(@applicant_first_name,@applicant_last_name,@applicant_email,@applicant_mobile,@applicant_password,@client_ip,
@applicant_active,@applicant_mobile_verified,@applicant_email_verified,@date_time,@role_id,@user_type,@class,@stream)";

            MySqlParameter[] pm = new MySqlParameter[]
                {
                new MySqlParameter("applicant_first_name",ur.Name),
                new MySqlParameter("applicant_last_name",ur.Last_name),
                new MySqlParameter("applicant_email",ur.Email),
                new MySqlParameter("applicant_mobile",ur.Cell_No),
                new MySqlParameter("applicant_password",ur.Password),
                new MySqlParameter("client_ip",ur.ClientIp),
                new MySqlParameter("applicant_active",ur.Applicant_active),
                new MySqlParameter("applicant_mobile_verified",ur.Applicant_mobile_verified),
                new MySqlParameter("applicant_email_verified",ur.Applicant_email_verified),
                new MySqlParameter("date_time",ur.Action_Date),
                new MySqlParameter("role_id",ur.Role_Id),
                new MySqlParameter("user_type",ur.User_type),
                new MySqlParameter("class",ur.Classes),
                new MySqlParameter("stream",ur.Stream)
                };

            rb = db.executeInsertQuery(query, pm);

            if (rb.status == true)
            {
                query = @"INSERT INTO user_login (applicant_mobile, applicant_email, applicant_first_name, 
              applicant_last_name, applicant_verified, client_ip, user_id, role_id,user_type,date_time,applicant_password,profile_update,refer_code,extra_3,class,stream) 
              VALUES (@applicant_mobile,@applicant_email,@applicant_first_name,@applicant_last_name,@applicant_verified,@client_ip,@user_id,@role_id,@user_type,@date_time,@applicant_password,@profile_update,@refer_code,@extra_3,@class,@stream)";

                MySqlParameter[] pmm = new MySqlParameter[]
                    {
                new MySqlParameter("applicant_mobile",ur.Cell_No),
                new MySqlParameter("applicant_email",ur.Email),
                new MySqlParameter("applicant_first_name",ur.Name),
                new MySqlParameter("applicant_last_name",ur.Last_name),
                new MySqlParameter("applicant_verified",ur.Applicant_active),
                new MySqlParameter("client_ip",ur.ClientIp),
                new MySqlParameter("user_id",ur.Cell_No),
                new MySqlParameter("role_id",ur.Role_Id),
                new MySqlParameter("user_type",ur.User_type),
                new MySqlParameter("date_time",ur.Action_Date),
                    new MySqlParameter("applicant_password",ur.Password),
                    new MySqlParameter("profile_update","N"),
                     new MySqlParameter("refer_code",ur.Refer_code),
                     new MySqlParameter("extra_3",ur.Country_code),
                new MySqlParameter("class",ur.Classes),
                new MySqlParameter("stream",ur.Stream)
                    };
                rb = db.executeInsertQuery(query, pmm);
            }
            if (rb.status == true)
            {
                transScope.Complete();
            }
        }
        return rb;
    }

    public ReturnDataTable user_login(bl_Usr_Registration ur)
    {
        query = "SELECT * FROM user_login WHERE applicant_email=@applicant or applicant_mobile=@applicant and applicant_verified=@applicant_verified and applicant_password=@applicant_password";
        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("applicant",ur.Login_Id),
                new MySqlParameter("applicant_verified",ur.Verified),
                 new MySqlParameter("applicant_password",ur.Password)
            };
        dt = db.executeSelectQuery(query, pm);
        return dt;
    }

    public ReturnDataTable select_default_page(bl_Usr_Registration ur)
    {
        query = "SELECT * FROM role WHERE Role_id=@Role_id";
        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("Role_id",ur.Role_Id)
            };
        dt = db.executeSelectQuery(query, pm);
        return dt;
    }

    public ReturnDataTable select_last_login(bl_Usr_Registration ur)
    {
        query = "SELECT date_format(login_time,'%Y-%m-%d %H:%i:%s') as login_time FROM login_trail WHERE user_id=@user_id order by login_time desc limit 1";
        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("user_id",ur.User_Id)
            };
        dt = db.executeSelectQuery(query, pm);
        return dt;
    }


   

    public ReturnBool LoginTrail_new(LoginTrail lt)
    {
        query = @" INSERT INTO login_trail (user_id,client_ip,client_os,client_browser, useragent) 
                  VALUES (@user_id, @client_ip, @client_os, @client_browser, @useragent)";
        MySqlParameter[] pr = new MySqlParameter[]{
            new MySqlParameter("user_id",lt.User_Id),
            new MySqlParameter("client_ip",lt.Client_Ip),
            new MySqlParameter("client_os",lt.Client_Os),
            new MySqlParameter("client_browser",lt.Client_Browser),
            new MySqlParameter("useragent", lt.UserAgent)
        };

        rb = db.executeInsertQuery(query, pr);
        return rb;
    }

    public ReturnBool sms_log(bl_Usr_Registration lt)
    {
        query = @" INSERT INTO sms_trail (mobile_no,client_ip,message,success, type) 
                  VALUES (@mobile_no,@client_ip,@message,@success, @type)";
        MySqlParameter[] pr = new MySqlParameter[]{
            new MySqlParameter("mobile_no",lt.Cell_No),
            new MySqlParameter("client_ip",lt.ClientIp),
            new MySqlParameter("message",lt.Message),
            new MySqlParameter("success",lt.Success),
            new MySqlParameter("type", lt.Type)
        };

        rb = db.executeInsertQuery(query, pr);
        return rb;
    }
    public ReturnDataTable user_login_details_for_forgot_password(bl_Usr_Registration ur)
    {
        query = "select * from user_login u where u.applicant_verified=@applicant_verified and u.user_id=@user_id";
        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("user_id",ur.Cell_No),
                new MySqlParameter("applicant_verified",ur.Verified)

            };
        dt = db.executeSelectQuery(query, pm);
        return dt;
    }


    public ReturnBool update_password(bl_Usr_Registration ur)
    {
        using (TransactionScope transScope = new TransactionScope())
        {
            query = @"insert into user_login_log select * from user_login where applicant_verified=@applicant_verified and user_id=@user_id";

            MySqlParameter[] pm = new MySqlParameter[]
                {
                new MySqlParameter("applicant_verified",ur.Verified),
                new MySqlParameter("user_id",ur.User_Id)

                };

            rb = db.executeInsertQuery(query, pm);

            if (rb.status == true)
            {
                query = @"update user_login set  applicant_password=@applicant_password where applicant_verified=@applicant_verified and user_id=@user_id";

                MySqlParameter[] pmm = new MySqlParameter[]
                    {
                new MySqlParameter("applicant_password",ur.Password),
                new MySqlParameter("applicant_verified",ur.Verified),
                new MySqlParameter("user_id",ur.User_Id)
                    };
                rb = db.executeUpdateQuery(query, pmm);
            }

            if (rb.status == true)
            {
                query = @"insert into user_registration_log select * from user_registration where applicant_active=@applicant_verified and applicant_mobile=@applicant_mobile";

                MySqlParameter[] pmm = new MySqlParameter[]
                    {
                new MySqlParameter("applicant_verified",ur.Verified),
                new MySqlParameter("applicant_mobile",ur.User_Id)
                    };
                rb = db.executeInsertQuery(query, pmm);
            }
            if (rb.status == true)
            {
                query = @"update user_registration set  applicant_password=@applicant_password where applicant_active=@applicant_verified and applicant_mobile=@applicant_mobile";

                MySqlParameter[] pmm = new MySqlParameter[]
                    {
                new MySqlParameter("applicant_password",ur.Password),
                new MySqlParameter("applicant_verified",ur.Verified),
                new MySqlParameter("applicant_mobile",ur.User_Id)
                    };
                rb = db.executeUpdateQuery(query, pmm);
            }
            if (rb.status == true)
            {
                transScope.Complete();
            }
        }
        return rb;
    }


    public ReturnDataTable bind_country_code()
    {
        query = "select concat(name,' - ',phonecode) as name,phonecode from countries";
        dt = db.executeSelectQuery(query);
        return dt;
    }

    public ReturnDataTable bind_location()
    {
        query = "select * from Locations";
        dt = db.executeSelectQuery(query);
        return dt;
    }

}