using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

/// <summary>
/// Summary description for doc_da_layer
/// </summary>
public class doc_da_layer : ReturnClass
{

    ReturnDataTable dt = new ReturnDataTable();
    ReturnBool rb = new ReturnBool();
    db_maria_connection db = new db_maria_connection();
    string query = null;
    public ReturnDataTable bind_doctor_page(doc_ba_layer ur)
    {
        query = "select * from doctor_profile_master p where p.user_id=@user_id";
        MySqlParameter[] pm = new MySqlParameter[]
        {
                new MySqlParameter("user_id",ur.User_id)
        };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }
    public ReturnDataTable Ddl_cat_list(doc_ba_layer ur)
    {
        query = "select * from ddl_cat_list p where p.category=@category order by sort_order";
        MySqlParameter[] pm = new MySqlParameter[]
        {
                new MySqlParameter("category",ur.Category)
        };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }

    public ReturnDataTable bind_country()
    {
        query = "select * from countries order by name";

        dt = db.executeSelectQuery(query);

        return dt;
    }

    public ReturnDataTable bind_working_timing(doc_ba_layer ur)
    {
        query = "select * from ddl_cat_list where category=@category order by sort_order";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("category",ur.Category)
       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }



    public ReturnDataTable bind_state(doc_ba_layer ur)
    {
        query = "select * from states where country_id=@country_id order by name";
        MySqlParameter[] pm = new MySqlParameter[]
        {
                new MySqlParameter("country_id",ur.Category)
        };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }
    public ReturnDataTable bind_city(doc_ba_layer ur)
    {
        query = "select * from cities where state_id=@state_id order by name";
        MySqlParameter[] pm = new MySqlParameter[]
        {
                new MySqlParameter("state_id",ur.Category)
        };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }
    public ReturnBool Insert_contact_us_details(doc_ba_layer ur)
    {

        query = @"insert into contact_us (Name,email_id,message,mobile_no,client_ip,user_id,date_time)
values(@Name,@email_id,@message,@mobile_no,@client_ip,@user_id,@date_time)";

        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("Name",ur.First_name),
                new MySqlParameter("email_id",ur.Email_id),
                new MySqlParameter("message",ur.Message),
                new MySqlParameter("mobile_no",ur.Mobile),
                new MySqlParameter("client_ip",ur.Client_id),
                new MySqlParameter("user_id",ur.User_id),
                new MySqlParameter("date_time",ur.Date_time)

            };

        rb = db.executeInsertQuery(query, pm);



        return rb;
    }


    public ReturnBool Insert_refer_friend_details(doc_ba_layer ur)
    {

        query = @"insert into refer_friend (Name,email_id,mobile_no,client_ip,user_id,date_time)
values(@Name,@email_id,@mobile_no,@client_ip,@user_id,@date_time)";

        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("Name",ur.First_name),
                new MySqlParameter("email_id",ur.Email_id),
                new MySqlParameter("mobile_no",ur.Mobile),
                new MySqlParameter("client_ip",ur.Client_id),
                new MySqlParameter("user_id",ur.User_id),
                new MySqlParameter("date_time",ur.Date_time)

            };

        rb = db.executeInsertQuery(query, pm);



        return rb;
    }


    public ReturnBool sms_log(doc_ba_layer lt)
    {
        query = @" INSERT INTO sms_trail (mobile_no,client_ip,message,success, type) 
                  VALUES (@mobile_no,@client_ip,@message,@success, @type)";
        MySqlParameter[] pr = new MySqlParameter[]{
            new MySqlParameter("mobile_no",lt.Mobile),
            new MySqlParameter("client_ip",lt.Client_id),
            new MySqlParameter("message",lt.Message_to),
            new MySqlParameter("success",lt.Success),
            new MySqlParameter("type", lt.Type)
        };

        rb = db.executeInsertQuery(query, pr);
        return rb;
    }

    public ReturnBool Insert_doc_profile_part1_details(doc_ba_layer ur)
    {
        using (TransactionScope transScope = new TransactionScope())
        {
            if (ur.Mode == "1")
            {
                query = @"insert into doctor_profile_details (first_name,middle_name,last_name,gender,registration,mobile,email_id,alternate_contact,
landline,practice_at,country,state,city,address,pincode,gst_no,user_id,client_ip,date_time)
values(@first_name,@middle_name,@last_name,@gender,@registration,@mobile,@email_id,@alternate_contact,@landline,@practice_at,@country,@state,@city,@address,@pincode,@gst_no,@user_id,@client_ip,@date_time)";

                MySqlParameter[] pm = new MySqlParameter[]
                    {
                new MySqlParameter("first_name",ur.First_name),
                new MySqlParameter("middle_name",ur.Middle_name),
                new MySqlParameter("last_name",ur.Last_name),
                new MySqlParameter("gender",ur.Gender),
                new MySqlParameter("registration",ur.Registration),
                new MySqlParameter("mobile",ur.Mobile),
                new MySqlParameter("email_id",ur.Email_id),
                new MySqlParameter("alternate_contact",ur.Alternate_contact),
                new MySqlParameter("landline",ur.Land_line),
                new MySqlParameter("practice_at",ur.Pratice_at),
                new MySqlParameter("country",ur.Country),
                new MySqlParameter("state",ur.State),
                new MySqlParameter("city",ur.City),
                new MySqlParameter("address",ur.Address),
                new MySqlParameter("pincode",ur.Pincode),
                     new MySqlParameter("gst_no",ur.Gstin_no),
                      new MySqlParameter("user_id",ur.User_id),
                      new MySqlParameter("client_ip",ur.Client_id),
                      new MySqlParameter("date_time",ur.Date_time)

                    };

                rb = db.executeInsertQuery(query, pm);

                if (rb.status == true)
                {
                    query = @"update doctor_profile_master set part_1=@part_1 where user_id=@user_id";
                    MySqlParameter[] pmm = new MySqlParameter[]
                        {
                new MySqlParameter("part_1","Y"),
                new MySqlParameter("user_id",ur.User_id)
                        };
                    rb = db.executeUpdateQuery(query, pmm);
                }
            }
            else if (ur.Mode == "2")
            {
                query = @"update doctor_profile_details set first_name=@first_name,middle_name=@middle_name,last_name=@last_name,gender=@gender,registration=@registration,mobile=@mobile,email_id=@email_id,alternate_contact=@alternate_contact,
landline=@landline,practice_at=@practice_at,country=@country,state=@state,city=@city,address=@address,pincode=@pincode,gst_no=@gst_no,client_ip=@client_ip,date_time=@date_time where user_id=@user_id";

                MySqlParameter[] pm = new MySqlParameter[]
                    {
                new MySqlParameter("first_name",ur.First_name),
                new MySqlParameter("middle_name",ur.Middle_name),
                new MySqlParameter("last_name",ur.Last_name),
                new MySqlParameter("gender",ur.Gender),
                new MySqlParameter("registration",ur.Registration),
                new MySqlParameter("mobile",ur.Mobile),
                new MySqlParameter("email_id",ur.Email_id),
                new MySqlParameter("alternate_contact",ur.Alternate_contact),
                new MySqlParameter("landline",ur.Land_line),
                new MySqlParameter("practice_at",ur.Pratice_at),
                new MySqlParameter("country",ur.Country),
                new MySqlParameter("state",ur.State),
                new MySqlParameter("city",ur.City),
                new MySqlParameter("address",ur.Address),
                new MySqlParameter("pincode",ur.Pincode),
                     new MySqlParameter("gst_no",ur.Gstin_no),
                      new MySqlParameter("user_id",ur.User_id),
                      new MySqlParameter("client_ip",ur.Client_id),
                      new MySqlParameter("date_time",ur.Date_time)

                    };

                rb = db.executeUpdateQuery(query, pm);

                if (rb.status == true)
                {
                    query = @"update doctor_profile_master set part_1=@part_1 where user_id=@user_id";
                    MySqlParameter[] pmm = new MySqlParameter[]
                        {
                new MySqlParameter("part_1","Y"),
                new MySqlParameter("user_id",ur.User_id)
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
    public ReturnDataTable bind_profile_detail_part1(doc_ba_layer ur)
    {
        query = @"select * from doctor_profile_details d join doctor_profile_master dd on dd.user_id = d.user_id where dd.user_id = @user_id";
        MySqlParameter[] pm = new MySqlParameter[]
        {
                new MySqlParameter("user_id",ur.User_id)
        };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }


    public ReturnBool Insert_doctor_working_days_details(doc_ba_layer ur)
    {

        query = @"insert into doctor_working_days (user_id,panjiyan_cate_id,client_ip,datetime)
values(@user_id,@panjiyan_cate_id,@client_ip,@datetime)";

        MySqlParameter[] pm = new MySqlParameter[]
            {
                new MySqlParameter("user_id",ur.User_id),
                new MySqlParameter("panjiyan_cate_id",ur.Category_id),
                new MySqlParameter("client_ip",ur.Client_id),
                new MySqlParameter("datetime",ur.Date_time)

            };

        rb = db.executeInsertQuery(query, pm);



        return rb;
    }
    public ReturnDataTable bind_working_days(doc_ba_layer ur)
    {
        query = @"select * from doctor_working_days where user_id = @user_id ";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id)
       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }

    public ReturnDataTable bind_payment_information_of_doctor(doc_ba_layer ur)
    {
        query = @"select * from payment_information_of_doctor where user_id = @user_id ";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id)
       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }


    public ReturnBool Insert_doc_profile_part2_details(doc_ba_layer ur)
    {
        using (TransactionScope transScope = new TransactionScope())
        {
            if (ur.Mode == "1")
            {
                query = @"insert into doctor_working_days (user_id,monday,tuesday,wednesday,thursday,friday,saturday,sunday,
client_ip,date_time)
values(@user_id,@monday,@tuesday,@wednesday,@thursday,@friday,@saturday,@sunday,@client_ip,@date_time)";

                MySqlParameter[] pm = new MySqlParameter[]
                    {
                new MySqlParameter("user_id",ur.User_id),
                new MySqlParameter("monday",ur.Monday),
                new MySqlParameter("tuesday",ur.Tuesday),
                new MySqlParameter("wednesday",ur.Wednesday),
                new MySqlParameter("thursday",ur.Thursday),
                new MySqlParameter("friday",ur.Friday),
                new MySqlParameter("saturday",ur.Saturday),
                new MySqlParameter("sunday",ur.Sunday),
                new MySqlParameter("client_ip",ur.Client_id),
                new MySqlParameter("date_time",ur.Date_time)

              
                    };

                rb = db.executeInsertQuery(query, pm);

                if (rb.status == true)
                {
                    query = @"update doctor_profile_master set part_2=@part_2 where user_id=@user_id";
                    MySqlParameter[] pmm = new MySqlParameter[]
                        {
                new MySqlParameter("part_2","Y"),
                new MySqlParameter("user_id",ur.User_id)
                        };
                    rb = db.executeUpdateQuery(query, pmm);
                }

                if (rb.status == true)
                {
                    query = @"Insert into payment_information_of_doctor 
        (doctor_consultation_fee,first_time_fee,consultation_fee,followup_fee,free_checkup,user_id,client_ip,date_time) values(@doctor_consultation_fee,@first_time_fee,@consultation_fee,@followup_fee,@free_checkup,@user_id,@client_ip,@date_time)";
                    MySqlParameter[] pmm = new MySqlParameter[]
                        {
                new MySqlParameter("doctor_consultation_fee",ur.Doctor_consultation_fee),
                new MySqlParameter("first_time_fee",ur.First_time_fee),
                new MySqlParameter("consultation_fee",ur.Consultation_fee),
                new MySqlParameter("followup_fee",ur.Follow_up),
                new MySqlParameter("free_checkup",ur.Free_checkup),
                new MySqlParameter("user_id",ur.User_id),
                new MySqlParameter("client_ip",ur.Client_id),
                new MySqlParameter("date_time",ur.Date_time),
                        };
                    rb = db.executeInsertQuery(query, pmm);
                }
                if (rb.status == true)
                {
                    query = @"update doctor_profile_details set working_hour_from=@working_hour_from,workin_from_meridian=@workin_from_meridian,working_hour_to=@working_hour_to,working_to_meridian=@working_to_meridian,client_ip=@client_ip,date_time=@date_time,experience=@experience,about_me=@about_me,citizenship=@citizenship,intern_ship_details=@intern_ship_details,internship_from=@internship_from,internship_to=@internship_to where user_id=@user_id";

                    MySqlParameter[] pmm = new MySqlParameter[]
                        {
                 new MySqlParameter("working_hour_from",ur.Working_hour_from),
                  new MySqlParameter("workin_from_meridian",ur.Working_hour_from_timing),
                   new MySqlParameter("working_hour_to",ur.Working_hour_to),
                    new MySqlParameter("working_to_meridian",ur.Working_hour_to_timing),
                      new MySqlParameter("user_id",ur.User_id),
                      new MySqlParameter("client_ip",ur.Client_id),
                      new MySqlParameter("date_time",ur.Date_time),
                        new MySqlParameter("experience",ur.Total_experience),
                new MySqlParameter("about_me",ur.About_me),
                new MySqlParameter("citizenship",ur.Citizenship),
                new MySqlParameter("intern_ship_details",ur.Internship_details),
                new MySqlParameter("internship_from",ur.Internship_from),
                new MySqlParameter("internship_to",ur.Internship_to)

                        };

                    rb = db.executeUpdateQuery(query, pmm);
                }
            }
            else if (ur.Mode == "2")
            {
                query = @"update doctor_working_days set monday=@monday,tuesday=@tuesday,wednesday=@wednesday,thursday=@thursday,friday=@friday,saturday=@saturday,sunday=@sunday,
client_ip=@client_ip,date_time=@date_time where user_id=@user_id";

                MySqlParameter[] pm = new MySqlParameter[]
                     {
                  new MySqlParameter("user_id",ur.User_id),
                new MySqlParameter("monday",ur.Monday),
                new MySqlParameter("tuesday",ur.Tuesday),
                new MySqlParameter("wednesday",ur.Wednesday),
                new MySqlParameter("thursday",ur.Thursday),
                new MySqlParameter("friday",ur.Friday),
                new MySqlParameter("saturday",ur.Saturday),
                new MySqlParameter("sunday",ur.Sunday),
                new MySqlParameter("client_ip",ur.Client_id),
                new MySqlParameter("date_time",ur.Date_time)
                     };

                rb = db.executeUpdateQuery(query, pm);

                if (rb.status == true)
                {
                    query = @"update doctor_profile_master set part_2=@part_2 where user_id=@user_id";
                    MySqlParameter[] pmm = new MySqlParameter[]
                        {
                new MySqlParameter("part_2","Y"),
                new MySqlParameter("user_id",ur.User_id)
                        };
                    rb = db.executeUpdateQuery(query, pmm);
                }
                if (rb.status == true)
                {
                    query = @"update payment_information_of_doctor set doctor_consultation_fee=@doctor_consultation_fee,first_time_fee=@first_time_fee,consultation_fee=@consultation_fee,followup_fee=@followup_fee,free_checkup=@free_checkup,client_ip=@client_ip,date_time=@date_time where user_id=@user_id";
                    MySqlParameter[] pmm = new MySqlParameter[]
                         {
                new MySqlParameter("doctor_consultation_fee",ur.Doctor_consultation_fee),
                new MySqlParameter("first_time_fee",ur.First_time_fee),
                new MySqlParameter("consultation_fee",ur.Consultation_fee),
                new MySqlParameter("followup_fee",ur.Follow_up),
                new MySqlParameter("free_checkup",ur.Free_checkup),
                new MySqlParameter("user_id",ur.User_id),
                new MySqlParameter("client_ip",ur.Client_id),
                new MySqlParameter("date_time",ur.Date_time),
                         };
                    rb = db.executeUpdateQuery(query, pmm);
                }
                if (rb.status == true)
                {
                    query = @"update doctor_profile_details set working_hour_from=@working_hour_from,workin_from_meridian=@workin_from_meridian,working_hour_to=@working_hour_to,working_to_meridian=@working_to_meridian,client_ip=@client_ip,date_time=@date_time,experience=@experience,about_me=@about_me,citizenship=@citizenship,intern_ship_details=@intern_ship_details,internship_from=@internship_from,internship_to=@internship_to where user_id=@user_id";

                    MySqlParameter[] pmm = new MySqlParameter[]
                        {
                 new MySqlParameter("working_hour_from",ur.Working_hour_from),
                  new MySqlParameter("workin_from_meridian",ur.Working_hour_from_timing),
                   new MySqlParameter("working_hour_to",ur.Working_hour_to),
                    new MySqlParameter("working_to_meridian",ur.Working_hour_to_timing),
                      new MySqlParameter("user_id",ur.User_id),
                      new MySqlParameter("client_ip",ur.Client_id),
                      new MySqlParameter("date_time",ur.Date_time),
                        new MySqlParameter("experience",ur.Total_experience),
                new MySqlParameter("about_me",ur.About_me),
                new MySqlParameter("citizenship",ur.Citizenship),
                new MySqlParameter("intern_ship_details",ur.Internship_details),
                new MySqlParameter("internship_from",ur.Internship_from),
                new MySqlParameter("internship_to",ur.Internship_to)

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

    public ReturnBool delete_doctor_qualification(doc_ba_layer ur)
    {
        query = @"delete from doctor_qualification where user_id = @user_id and id=@id ";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id),
                 new MySqlParameter("id",ur.Degree_id)
       };
        rb = db.executeDeleteQuery(query, pm);

        return rb;
    }


    public ReturnBool delete_doctor_experience(doc_ba_layer ur)
    {
        query = @"delete from doctor_work_experience where user_id = @user_id and id=@id ";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id),
                 new MySqlParameter("id",ur.Degree_id)
       };
        rb = db.executeDeleteQuery(query, pm);

        return rb;
    }


    public ReturnBool delete_doctor_certifications(doc_ba_layer ur)
    {
        query = @"delete from doctor_other_certification where user_id = @user_id and id=@id ";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id),
                 new MySqlParameter("id",ur.Degree_id)
       };
        rb = db.executeDeleteQuery(query, pm);

        return rb;
    }

    public ReturnDataTable bind_doctor_qualification(doc_ba_layer ur)
    {
        query = @"select *,'' as RowNumber from doctor_qualification where user_id = @user_id ";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id)
       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }

    public ReturnDataTable bind_doctor_experience(doc_ba_layer ur)
    {
        query = @"select *,'' as RowNumber from doctor_work_experience where user_id = @user_id ";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id)
       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }

    public ReturnDataTable bind_doctor_certifications(doc_ba_layer ur)
    {
        query = @"select *,'' as RowNumber from doctor_other_certification where user_id = @user_id ";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id)
       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }


    public ReturnDataTable bind_doctor_qualification_by_id(doc_ba_layer ur)
    {
        query = @"select * from doctor_qualification where user_id = @user_id and id=@id";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id),
                    new MySqlParameter("id",ur.Degree_id)
       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }


    public ReturnDataTable bind_doctor_experience_by_id(doc_ba_layer ur)
    {
        query = @"select * from doctor_work_experience where user_id = @user_id and id=@id";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id),
                    new MySqlParameter("id",ur.Degree_id)
       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }


    public ReturnDataTable bind_doctor_certifications_by_id(doc_ba_layer ur)
    {
        query = @"select * from doctor_other_certification where user_id = @user_id and id=@id";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id),
                    new MySqlParameter("id",ur.Degree_id)
       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }


    public ReturnBool Insert_doc_qualification_details(doc_ba_layer ur)
    {
        using (TransactionScope transScope = new TransactionScope())
        {
            if (ur.Mode == "1")
            {
                query = @"insert into doctor_qualification (degree_name,client_ip,date_time,upload,user_id,university_name,college_name,degree_from,degree_to,complition_time,percentage)
values(@degree_name,@client_ip,@date_time,@upload,@user_id,@university_name,@college_name,@degree_from,@degree_to,@complition_time,@percentage)";

                MySqlParameter[] pm = new MySqlParameter[]
                    {
                new MySqlParameter("degree_name",ur.Degree_name),
                new MySqlParameter("user_id",ur.User_id),
                new MySqlParameter("upload","N"),
                new MySqlParameter("client_ip",ur.Client_id),
                new MySqlParameter("date_time",ur.Date_time),
                new MySqlParameter("university_name",ur.University_name),
                new MySqlParameter("college_name",ur.College_name),
                new MySqlParameter("degree_from",ur.Degree_from),
                new MySqlParameter("degree_to",ur.Degree_to),
                new MySqlParameter("complition_time",ur.Complition_time),
                new MySqlParameter("percentage",ur.Percentage)
                    };

                rb = db.executeInsertQuery(query, pm);


            }
            else if (ur.Mode == "2")
            {
                query = @"update doctor_qualification set degree_name=@degree_name,client_ip=@client_ip,date_time=@date_time,university_name=@university_name,college_name=@college_name,degree_from=@degree_from,degree_to=@degree_to,complition_time=@complition_time,percentage=@percentage where user_id=@user_id and id=@id";

                MySqlParameter[] pm = new MySqlParameter[]
                     {
                new MySqlParameter("user_id",ur.User_id),
                new MySqlParameter("id",ur.Degree_id),
                new MySqlParameter("degree_name",ur.Degree_name),
                new MySqlParameter("client_ip",ur.Client_id),
                new MySqlParameter("date_time",ur.Date_time),
                 new MySqlParameter("university_name",ur.University_name),
                new MySqlParameter("college_name",ur.College_name),
                new MySqlParameter("degree_from",ur.Degree_from),
                new MySqlParameter("degree_to",ur.Degree_to),
                new MySqlParameter("complition_time",ur.Complition_time),
                new MySqlParameter("percentage",ur.Percentage)
                     };

                rb = db.executeUpdateQuery(query, pm);


            }
            if (rb.status == true)
            {
                transScope.Complete();
            }
        }


        return rb;
    }


    public ReturnBool Insert_doc_experience_details(doc_ba_layer ur)
    {
        using (TransactionScope transScope = new TransactionScope())
        {
            if (ur.Mode == "1")
            {
                query = @"insert into doctor_work_experience (designation,client_ip,date_time,hospital_name,user_id,working_from,working_to)
values(@designation,@client_ip,@date_time,@hospital_name,@user_id,@working_from,@working_to)";

                MySqlParameter[] pm = new MySqlParameter[]
                    {
                new MySqlParameter("designation",ur.Degree_name),
                new MySqlParameter("user_id",ur.User_id),
                new MySqlParameter("client_ip",ur.Client_id),
                new MySqlParameter("date_time",ur.Date_time),
                new MySqlParameter("hospital_name",ur.University_name),
                new MySqlParameter("working_from",ur.Degree_from),
                new MySqlParameter("working_to",ur.Degree_to),
                    };

                rb = db.executeInsertQuery(query, pm);


            }
            else if (ur.Mode == "2")
            {
                query = @"update doctor_work_experience set designation=@designation,client_ip=@client_ip,date_time=@date_time,hospital_name=@hospital_name,working_from=@working_from,working_to=@working_to where user_id=@user_id and id=@id";

                MySqlParameter[] pm = new MySqlParameter[]
                     {
                new MySqlParameter("user_id",ur.User_id),
                new MySqlParameter("id",ur.Degree_id),
                new MySqlParameter("designation",ur.Degree_name),
                new MySqlParameter("client_ip",ur.Client_id),
                new MySqlParameter("date_time",ur.Date_time),
                 new MySqlParameter("hospital_name",ur.University_name),
                new MySqlParameter("working_from",ur.Degree_from),
                new MySqlParameter("working_to",ur.Degree_to),
                     };

                rb = db.executeUpdateQuery(query, pm);


            }
            if (rb.status == true)
            {
                transScope.Complete();
            }
        }


        return rb;
    }


    public ReturnBool Insert_doc_certifications_details(doc_ba_layer ur)
    {
        using (TransactionScope transScope = new TransactionScope())
        {
            if (ur.Mode == "1")
            {
                query = @"insert into doctor_other_certification (certification_name,client_ip,date_time,user_id,duration_from,duration_to)
values(@certification_name,@client_ip,@date_time,@user_id,@duration_from,@duration_to)";

                MySqlParameter[] pm = new MySqlParameter[]
                    {
                new MySqlParameter("certification_name",ur.Degree_name),
                new MySqlParameter("user_id",ur.User_id),
                new MySqlParameter("client_ip",ur.Client_id),
                new MySqlParameter("date_time",ur.Date_time),
                new MySqlParameter("duration_from",ur.Degree_from),
                new MySqlParameter("duration_to",ur.Degree_to),
                    };

                rb = db.executeInsertQuery(query, pm);


            }
            else if (ur.Mode == "2")
            {
                query = @"update doctor_other_certification set certification_name=@certification_name,client_ip=@client_ip,date_time=@date_time,duration_from=@duration_from,duration_to=@duration_to where user_id=@user_id and id=@id";

                MySqlParameter[] pm = new MySqlParameter[]
                     {
                new MySqlParameter("user_id",ur.User_id),
                new MySqlParameter("id",ur.Degree_id),
                new MySqlParameter("certification_name",ur.Degree_name),
                new MySqlParameter("client_ip",ur.Client_id),
                new MySqlParameter("date_time",ur.Date_time),
                new MySqlParameter("duration_from",ur.Degree_from),
                new MySqlParameter("duration_to",ur.Degree_to),
                     };

                rb = db.executeUpdateQuery(query, pm);


            }
            if (rb.status == true)
            {
                transScope.Complete();
            }
        }


        return rb;
    }

    public ReturnClass.ReturnBool Upload_details(doc_ba_layer fu)
    {
        query = @"INSERT INTO doctor_upload (user_id,document_name,mime_type,file_extn,file_data,client_ip,category_id,action_id)
VALUES(@user_id,@document_name,@mime_type,@file_extn,@file_data,@client_ip,@category_id,@action_id)";
        MySqlParameter[] pm1 = new MySqlParameter[]{
                new MySqlParameter("user_id", fu.User_id),
                new MySqlParameter("document_name", fu.Document_name),
                  new MySqlParameter("mime_type", fu.Mime_type),
                new MySqlParameter("file_data", fu.Document_data),
                new MySqlParameter("client_ip", fu.Client_id),
                 new MySqlParameter ("category_id", fu.Panjiyan_category_id),
                   new MySqlParameter ("file_extn", fu.File_extn),
                   new MySqlParameter ("action_id", fu.Category_id)


            };
        rb = db.executeInsertQuery(query, pm1);
        return rb;
    }
    public ReturnClass.ReturnBool Update_Upload_details(doc_ba_layer fu)
    {
        query = @"Update doctor_upload set document_name=@document_name,mime_type=@mime_type,file_extn=@file_extn,file_data=@file_data,client_ip=@client_ip,action_id=@action_id where user_id=@user_id and category_id=@category_id";
        MySqlParameter[] pm1 = new MySqlParameter[]{
                new MySqlParameter("user_id", fu.User_id),
                new MySqlParameter("document_name", fu.Document_name),
                  new MySqlParameter("mime_type", fu.Mime_type),
                new MySqlParameter("file_data", fu.Document_data),
                new MySqlParameter("client_ip", fu.Client_id),
                 new MySqlParameter ("category_id", fu.Panjiyan_category_id),
                   new MySqlParameter ("file_extn", fu.File_extn),
                   new MySqlParameter ("action_id", fu.Category_id)

            };
        rb = db.executeInsertQuery(query, pm1);
        return rb;
    }


    public ReturnDataTable Getfileupload(doc_ba_layer ur)
    {
        query = @"select * from doctor_upload where user_id = @user_id and category_id=@category_id";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id),
                    new MySqlParameter("category_id",ur.Panjiyan_category_id)
       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }


    public ReturnDataTable Getfileuploadforprofilepic(doc_ba_layer ur)
    {
        query = @"select * from doctor_upload where user_id = @user_id and category_id=@category_id";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id","100"),
                    new MySqlParameter("category_id",ur.Panjiyan_category_id)
       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }


    public ReturnDataTable Get_educationfileupload(doc_ba_layer ur)
    {
        query = @"select distinct q.id,q.degree_name, q.university_name,q.college_name,(select document_name from doctor_upload where action_id=q.id and category_id='cert' limit 1) as document_name,(select file_id from doctor_upload where action_id=q.id and category_id='cert' limit 1) as file_id,q.user_id
 from doctor_qualification q
left join doctor_upload u on u.user_id=q.user_id and q.id=u.action_id
where q.user_id=@user_id group by q.id";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id)

       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }


    public ReturnDataTable Get_experiencefileupload(doc_ba_layer ur)
    {
        query = @"select distinct q.id,q.designation, q.hospital_name ,(select document_name from doctor_upload where action_id=q.id and category_id='cert_work' limit 1) as document_name,(select file_id from doctor_upload where action_id=q.id and category_id='cert_work' limit 1) as file_id,q.user_id
 from doctor_work_experience q
left join doctor_upload u on u.user_id=q.user_id and q.id=u.action_id
where q.user_id=@user_id group by q.id";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id)

       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }


    public ReturnDataTable Get_certificationfileupload(doc_ba_layer ur)
    {
        query = @"select distinct q.id,q.certification_name,(select document_name from doctor_upload where action_id=q.id and category_id='cert_other' limit 1) as document_name,(select file_id from doctor_upload where action_id=q.id and category_id='cert_other' limit 1) as file_id,q.user_id
 from doctor_other_certification q
left join doctor_upload u on u.user_id=q.user_id and q.id=u.action_id
where q.user_id=@user_id group by q.id";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id)

       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }

    public ReturnClass.ReturnDataTable Download(doc_ba_layer ur)
    {
        string qr = "SELECT document_name,file_data,file_extn from doctor_upload WHERE file_id=@file_id and user_id=@provisional_no";
        MySqlParameter[] pm = new MySqlParameter[]{
                new MySqlParameter("file_id", ur.File_id),
                new MySqlParameter("provisional_no", ur.Provisional_no)
                      };

        dt = db.executeSelectQuery(qr, pm);
        return dt;
    }

    public ReturnClass.ReturnBool delete_file_upload(doc_ba_layer fu)
    {

        MySqlParameter[] t1 = new MySqlParameter[]{
        new MySqlParameter("user_id",fu.User_id),
         new MySqlParameter("file_id",fu.File_id)
         };

        rb = db.executeDeleteQuery("delete from doctor_upload where user_id=@user_id  and file_id=@file_id  ", t1);
        return rb;
    }

    public ReturnDataTable check_Getfileupload(doc_ba_layer ur)
    {
        query = @"select * from doctor_upload where user_id = @user_id and category_id=@category_id and action_id=@action_id";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id),
                    new MySqlParameter("category_id",ur.Panjiyan_category_id),
                     new MySqlParameter("action_id",ur.Category_id)
       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }

    public ReturnBool Insert_doc_profile_part3_details(doc_ba_layer ur)
    {
        using (TransactionScope transScope = new TransactionScope())
        {
            if (ur.Mode == "1")
            {
                query = @"insert into doctor_account_details (user_id,client_ip,bank_name,branch_name,ifsc_code,account_number,entry_date_time) values (@user_id,@client_ip,@bank_name,@branch_name,@ifsc_code,@account_number,@entry_date_time)";
                MySqlParameter[] pmm = new MySqlParameter[]
                    {
                new MySqlParameter("user_id",ur.User_id),
                new MySqlParameter("client_ip",ur.Client_id),
                new MySqlParameter("bank_name",ur.Bank_name),
                new MySqlParameter("branch_name",ur.Branch_name),
                new MySqlParameter("ifsc_code",ur.Ifsc_code),
                new MySqlParameter("account_number",ur.Account_number),
                new MySqlParameter("entry_date_time",ur.Date_time)
                    };
                rb = db.executeInsertQuery(query, pmm);
            }
            else if (ur.Mode == "2")
            {
                query = @"update doctor_account_details set client_ip=@client_ip,bank_name=@bank_name,branch_name=@branch_name,ifsc_code=@ifsc_code,account_number=@account_number,entry_date_time=@entry_date_time where user_id=@user_id";
                MySqlParameter[] pmm = new MySqlParameter[]
                    {
                new MySqlParameter("user_id",ur.User_id),
                new MySqlParameter("client_ip",ur.Client_id),
                new MySqlParameter("bank_name",ur.Bank_name),
                new MySqlParameter("branch_name",ur.Branch_name),
                new MySqlParameter("ifsc_code",ur.Ifsc_code),
                new MySqlParameter("account_number",ur.Account_number),
                new MySqlParameter("entry_date_time",ur.Date_time)
                    };
                rb = db.executeUpdateQuery(query, pmm);
            }
            if (rb.status == true)
            {
                query = @"update doctor_profile_master set part_3=@part_3 where user_id=@user_id";
                MySqlParameter[] pmm = new MySqlParameter[]
                    {
                new MySqlParameter("part_3","Y"),
                new MySqlParameter("user_id",ur.User_id)
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
    public ReturnDataTable select_testimonial_details(doc_ba_layer ur)
    {
        query = @"select * from testimonial t where t.user_id=@user_id";
        MySqlParameter[] pmm = new MySqlParameter[]
            {
                new MySqlParameter("user_id",ur.User_id)
            };
        dt = db.executeSelectQuery(query, pmm);
        return dt;
    }

    public ReturnBool Insert_testimonial(doc_ba_layer ur)
    {
        query = @"insert into testimonial (user_id,client_ip,date_time,testimonial,category,status)values(@user_id,@client_ip,@date_time,@testimonial,@category,@status)";
        MySqlParameter[] pmm = new MySqlParameter[]
            {
                new MySqlParameter("client_ip",ur.Client_id),
                new MySqlParameter("user_id",ur.User_id),
                  new MySqlParameter("date_time",ur.Date_time),
                  new MySqlParameter("testimonial",ur.Review),
                  new MySqlParameter("category",ur.Category),
                    new MySqlParameter("status",ur.Status)
            };
        rb = db.executeUpdateQuery(query, pmm);
        return rb;
    }

    public ReturnBool Update_testimonial(doc_ba_layer ur)
    {
        query = @"update testimonial set client_ip=@client_ip,date_time=@date_time,testimonial=@testimonial,category=@category,status=@status where user_id=@user_id ";
        MySqlParameter[] pmm = new MySqlParameter[]
            {
                new MySqlParameter("client_ip",ur.Client_id),
                new MySqlParameter("user_id",ur.User_id),
                  new MySqlParameter("date_time",ur.Date_time),
                  new MySqlParameter("testimonial",ur.Review),
                  new MySqlParameter("category",ur.Category),
                   new MySqlParameter("status",ur.Status)
            };
        rb = db.executeUpdateQuery(query, pmm);
        return rb;
    }

    public ReturnDataTable bind_refer_list(string userid)
    {
        query = @"select r.Name,r.mobile_no,r.email_id,DATE_FORMAT(r.date_time,'%W, %M %e, %Y @ %h:%i %p') as sendinddate from refer_friend r
where r.user_id = @user_id";
        MySqlParameter[] pm = new MySqlParameter[]
        {
                new MySqlParameter("user_id",userid)
        };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }
    public ReturnDataTable newmessage_update(doc_ba_layer ur)
    {
        query = @"select count(*) as newmessage from chat_with_doctor_log l
join chatbox c on c.category_id=l.id where l.recipient=@user_id and c.sending_date>@lastlogintime and c.user_id!=@user_id group by c.id order by c.sending_date desc ";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id),
                    new MySqlParameter("lastlogintime",ur.Logintimeformessage)
       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }


    public ReturnDataTable newmessage_update_new(doc_ba_layer ur)
    {
        query = @"select count(*) as newmessage from chat_with_doctor_log l
join chatbox c on c.category_id=l.id where l.recipient=@user_id and c.read_chat='N' and c.user_id!=@user_id ";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id),
                    new MySqlParameter("lastlogintime",ur.Logintimeformessage)
       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }
    public ReturnDataTable select_receriver_name_for_user_for_review(string Sender_id)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("user_id", Sender_id),


                      };
        query = @"select * from user_login u 
 join user_registration uu on uu.applicant_mobile=u.user_id where u.user_id=@user_id and u.applicant_verified='Y' and uu.applicant_active='Y' ;";
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }
    public ReturnClass.ReturnDataTable Get_BankDetails()
    {
        ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
        db_maria_connection db = new db_maria_connection();
        try
        {
            string query = null;
            query = "select * from bank_list order by bank_Name";
            dt = db.executeSelectQuery(query);
        }
        catch (Exception ex)
        {
            dt.status = false;
            dt.message = ex.Message;
        }
        return dt;
    }

    public ReturnDataTable bind_doctor_account_details(doc_ba_layer ur)
    {
        query = @"select * from doctor_account_details where user_id = @user_id ";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id)
       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }

}