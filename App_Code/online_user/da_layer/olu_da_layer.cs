using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for olu_da_layer
/// </summary>
public class olu_da_layer : ReturnClass
{

    ReturnDataTable dt = new ReturnDataTable();
    ReturnBool rb = new ReturnBool();
    db_maria_connection db = new db_maria_connection();
    string query = null;
    public ReturnDataTable bind_user_page(olu_ba_layer ur)
    {
        query = "select * from user_profile_master p where p.user_id=@user_id";
        MySqlParameter[] pm = new MySqlParameter[]
        {
                new MySqlParameter("user_id",ur.User_id)
        };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }
    public ReturnDataTable Ddl_cat_list(olu_ba_layer ur)
    {
        query = "select *,'' required from ddl_cat_list p where p.category=@category order by sort_order";
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

    public ReturnDataTable bind_age()
    {
        query = "select * from incr limit 100";

        dt = db.executeSelectQuery(query);

        return dt;
    }


    public ReturnDataTable bind_nationality()
    {
        query = "select * from countries_nationality order by nationality";

        dt = db.executeSelectQuery(query);

        return dt;
    }







    public ReturnDataTable bind_state(olu_ba_layer ur)
    {
        query = "select * from states where country_id=@country_id order by name";
        MySqlParameter[] pm = new MySqlParameter[]
        {
                new MySqlParameter("country_id",ur.Category)
        };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }
    public ReturnDataTable bind_city(olu_ba_layer ur)
    {
        query = "select * from cities where state_id=@state_id order by name";
        MySqlParameter[] pm = new MySqlParameter[]
        {
                new MySqlParameter("state_id",ur.Category)
        };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }

    public ReturnDataTable Getfileupload(olu_ba_layer ur)
    {
        query = @"select * from user_upload where user_id = @user_id and category_id=@category_id";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id),
                    new MySqlParameter("category_id",ur.Panjiyan_category_id)
       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }

    public ReturnDataTable check_Getfileupload(olu_ba_layer ur)
    {
        query = @"select * from user_upload where user_id = @user_id and category_id=@category_id and action_id=@action_id";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id),
                    new MySqlParameter("category_id",ur.Panjiyan_category_id),
                     new MySqlParameter("action_id",ur.Category_id)
       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }

    public ReturnClass.ReturnBool Update_Upload_details(olu_ba_layer fu)
    {
        query = @"Update user_upload set document_name=@document_name,mime_type=@mime_type,file_extn=@file_extn,file_data=@file_data,client_ip=@client_ip,action_id=@action_id where user_id=@user_id and category_id=@category_id";
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
    public ReturnClass.ReturnBool Upload_details(olu_ba_layer fu)
    {
        query = @"INSERT INTO user_upload (user_id,document_name,mime_type,file_extn,file_data,client_ip,category_id,action_id)
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


    public ReturnDataTable bind_profile_detail_part1(olu_ba_layer ur)
    {
        query = @"select * from user_profile_details d join user_profile_master dd on dd.user_id = d.user_id where dd.user_id = @user_id";
        MySqlParameter[] pm = new MySqlParameter[]
        {
                new MySqlParameter("user_id",ur.User_id)
        };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }


    public ReturnBool Insert_user_profile_part1_details(olu_ba_layer ur)
    {
        using (TransactionScope transScope = new TransactionScope())
        {
            if (ur.Mode == "1")
            {
                query = @"insert into user_profile_details (first_name,middle_name,last_name,gender,mobile,email_id,
country,state,city,address_1,pincode,age,height,weight,user_id,client_ip,date_time,nationality,martial_status,blood_group,previous_medical_history,aadhar_no,alternate_number,alcoholic,bp,diabetic,smoking)
values(@first_name,@middle_name,@last_name,@gender,@mobile,@email_id,@country,@state,@city,@address,@pincode,@age,@height,@weight,@user_id,@client_ip,@date_time,@nationality,@martial_status,@blood_group,@previous_medical_history,@aadhar_no,@alternate_number,@alcoholic,@bp,@diabetic,@smoking)";

                MySqlParameter[] pm = new MySqlParameter[]
                    {
                new MySqlParameter("first_name",ur.First_name),
                new MySqlParameter("middle_name",ur.Middle_name),
                new MySqlParameter("last_name",ur.Last_name),
                new MySqlParameter("gender",ur.Gender),
                new MySqlParameter("mobile",ur.Mobile),
                new MySqlParameter("email_id",ur.Email_id),
                new MySqlParameter("country",ur.Country),
                new MySqlParameter("state",ur.State),
                new MySqlParameter("city",ur.City),
                new MySqlParameter("address",ur.Address_1),
                new MySqlParameter("pincode",ur.Pincode),
                 new MySqlParameter("age",ur.Age),
                  new MySqlParameter("height",ur.Height),
                   new MySqlParameter("weight",ur.Weight),
                      new MySqlParameter("user_id",ur.User_id),
                      new MySqlParameter("client_ip",ur.Client_id),
                      new MySqlParameter("date_time",ur.Date_time),
                           new MySqlParameter("nationality",ur.Nationality),
                new MySqlParameter("martial_status",ur.Martial_status),
                new MySqlParameter("blood_group",ur.Blood_group),
                new MySqlParameter("previous_medical_history",ur.Previous_medical_history),
                new MySqlParameter("aadhar_no",ur.Aadhar),
                new MySqlParameter("alternate_number",ur.Alternate_con),
                new MySqlParameter("alcoholic",ur.Alcohalic),
                new MySqlParameter("bp",ur.Bp),
                new MySqlParameter("diabetic",ur.Diabetic),
                new MySqlParameter("smoking",ur.Smoking)
                    };

                rb = db.executeInsertQuery(query, pm);

                if (rb.status == true)
                {
                    //query = @"update user_profile_master set part_1=@part_1  where user_id=@user_id";
                    query = @"update user_profile_master set part_1=@part_1,part_2=@part_1,part_3=@part_1  where user_id=@user_id";
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
                query = @"update user_profile_details set first_name=@first_name,middle_name=@middle_name,last_name=@last_name,gender=@gender,mobile=@mobile,email_id=@email_id,
country=@country,state=@state,city=@city,address_1=@address,pincode=@pincode,age=@age,height=@height,weight=@weight,client_ip=@client_ip,date_time=@date_time,nationality=@nationality,martial_status=@martial_status,blood_group=@blood_group,previous_medical_history=@previous_medical_history,aadhar_no=@aadhar_no,alternate_number=@alternate_number,alcoholic=@alcoholic,bp=@bp,diabetic=@diabetic,smoking=@smoking where user_id=@user_id";

                MySqlParameter[] pm = new MySqlParameter[]
                    {
                new MySqlParameter("first_name",ur.First_name),
                new MySqlParameter("middle_name",ur.Middle_name),
                new MySqlParameter("last_name",ur.Last_name),
                new MySqlParameter("gender",ur.Gender),
                new MySqlParameter("mobile",ur.Mobile),
                new MySqlParameter("email_id",ur.Email_id),
                new MySqlParameter("country",ur.Country),
                new MySqlParameter("state",ur.State),
                new MySqlParameter("city",ur.City),
                new MySqlParameter("address",ur.Address_1),
                new MySqlParameter("pincode",ur.Pincode),
                   new MySqlParameter("age",ur.Age),
                  new MySqlParameter("height",ur.Height),
                   new MySqlParameter("weight",ur.Weight),
                      new MySqlParameter("user_id",ur.User_id),
                      new MySqlParameter("client_ip",ur.Client_id),
                      new MySqlParameter("date_time",ur.Date_time),
                           new MySqlParameter("nationality",ur.Nationality),
                new MySqlParameter("martial_status",ur.Martial_status),
                new MySqlParameter("blood_group",ur.Blood_group),
                new MySqlParameter("previous_medical_history",ur.Previous_medical_history),
                  new MySqlParameter("aadhar_no",ur.Aadhar),
                new MySqlParameter("alternate_number",ur.Alternate_con),
                new MySqlParameter("alcoholic",ur.Alcohalic),
                new MySqlParameter("bp",ur.Bp),
                new MySqlParameter("diabetic",ur.Diabetic),
                new MySqlParameter("smoking",ur.Smoking)
                    };

                rb = db.executeUpdateQuery(query, pm);

                if (rb.status == true)
                {
                    query = @"update user_profile_master set part_1=@part_1,part_2=@part_2,part_3=@part_3  where user_id=@user_id";
                    MySqlParameter[] pmm = new MySqlParameter[]
                        {
                new MySqlParameter("part_1","Y"),
                 new MySqlParameter("part_2","Y"),
                  new MySqlParameter("part_3","Y"),
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


    public ReturnDataTable bind_user_profile_details_part2(olu_ba_layer ur)
    {
        query = @"select * from user_profile_details_part2 u
join ddl_cat_list d on d.id = u.panjiyan_cate_id where user_id = @user_id and d.category = @category order by u.panjiyan_id";
        MySqlParameter[] pm = new MySqlParameter[]
        {
                new MySqlParameter("user_id",ur.User_id),
                 new MySqlParameter("category",ur.Category)
        };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }
    public ReturnDataTable bind_user_profile_details_part1(olu_ba_layer ur)
    {
        query = @"select * from user_profile_details_part1 u
join ddl_cat_list d on d.id = u.panjiyan_cate_id where user_id = @user_id and d.category = @category order by u.panjiyan_id";
        MySqlParameter[] pm = new MySqlParameter[]
        {
                new MySqlParameter("user_id",ur.User_id),
                 new MySqlParameter("category",ur.Category)
        };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }


    public ReturnBool Insert_user_profile_part2_details(olu_ba_layer ur, GridView com2)
    {

        using (TransactionScope transScope = new TransactionScope())
        {
            query = @"update user_profile_details set nationality=@nationality,martial_status=@martial_status,blood_group=@blood_group,previous_medical_history=@previous_medical_history,How_is_your_memory=@How_is_your_memory,
For_what_is_it_poor=@For_what_is_it_poor,At_what_time_is_it_poor=@At_what_time_is_it_poor,Do_you_remember_what_you_read=@Do_you_remember_what_you_read,Do_you_read_with_interest_and_pleasure=@Do_you_read_with_interest_and_pleasure,Can_you_apply_you_mind_easily=@Can_you_apply_you_mind_easily,
In_what_way_is_your_disposition_changed_during_sickness=@In_what_way_is_your_disposition_changed_during_sickness,Do_you_comprehend_easily=@Do_you_comprehend_easily,how_do_you_answer_the_questions_of_others=@how_do_you_answer_the_questions_of_others,
How_does_the_future_look_to_you=@How_does_the_future_look_to_you,Have_you_any_delusions_of_any_kind=@Have_you_any_delusions_of_any_kind,client_ip=@client_ip,date_time=@date_time where user_id=@user_id";

            MySqlParameter[] pm = new MySqlParameter[]
                {
                new MySqlParameter("nationality",ur.Nationality),
                new MySqlParameter("martial_status",ur.Martial_status),
                new MySqlParameter("blood_group",ur.Blood_group),
                new MySqlParameter("previous_medical_history",ur.Previous_medical_history),
                new MySqlParameter("How_is_your_memory",ur.HOw_is_your_memory),
                new MySqlParameter("For_what_is_it_poor",ur.FOr_what_is_it_poor),
                new MySqlParameter("At_what_time_is_it_poor",ur.AT_what_time_is_it_poor),
                new MySqlParameter("Do_you_remember_what_you_read",ur.DO_you_remember_what_you_read),
                new MySqlParameter("Do_you_read_with_interest_and_pleasure",ur.DO_you_read_with_interest_and_pleasure),
                new MySqlParameter("Can_you_apply_you_mind_easily",ur.CAn_you_apply_you_mind_easily),
                new MySqlParameter("In_what_way_is_your_disposition_changed_during_sickness",ur.IN_what_way_is_your_disposition_changed_during_sickness),
                   new MySqlParameter("Do_you_comprehend_easily",ur.DO_you_comprehend_easily),
                  new MySqlParameter("how_do_you_answer_the_questions_of_others",ur.How_do_you_answer_the_questions_of_others),
                   new MySqlParameter("How_does_the_future_look_to_you",ur.HOw_does_the_future_look_to_you),
                   new MySqlParameter("Have_you_any_delusions_of_any_kind",ur.HAve_you_any_delusions_of_any_kind),
                      new MySqlParameter("user_id",ur.User_id),
                      new MySqlParameter("client_ip",ur.Client_id),
                      new MySqlParameter("date_time",ur.Date_time)

                };

            rb = db.executeUpdateQuery(query, pm);

            if (rb.status == true)
            {
                query = @"update user_profile_master set part_2=@part_2 where user_id=@user_id";
                MySqlParameter[] pmm = new MySqlParameter[]
                    {
                new MySqlParameter("part_2","Y"),
                new MySqlParameter("user_id",ur.User_id)
                    };
                rb = db.executeUpdateQuery(query, pmm);
            }
            if (rb.status == true)
            {
                foreach (GridViewRow row in com2.Rows)
                {
                    if (rb.status == true)
                    {
                        CheckBox chk = (row.Cells[3].FindControl("chk") as CheckBox);
                        ur.Category = (row.Cells[1].FindControl("lbl_Nivesh") as Label).Text;

                        if (chk.Checked)
                        {
                            ur.Required = "Y";
                        }
                        else
                        {
                            ur.Required = "N";

                        }
                        dt = check_panjiyan_number_from(ur);
                        if (dt.table.Rows.Count > 0)
                        {

                            MySqlParameter[] pm22 = new MySqlParameter[]{
                new MySqlParameter("panjiyan_cate_id", ur.Category),
                    new MySqlParameter("required", ur.Required),
                new MySqlParameter("client_ip", ur.Client_id),
                new MySqlParameter("user_id", ur.User_id),
                 new MySqlParameter("datetime",ur.Date_time)
                      };
                            query = @"Update user_profile_details_part1 SET required=@required,client_ip=@client_ip,datetime=@datetime where user_id=@user_id and panjiyan_cate_id=@panjiyan_cate_id ";
                            rb = db.executeUpdateQuery(query, pm22);
                        }
                        else
                        {
                            MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("panjiyan_cate_id", ur.Category),
                    new MySqlParameter("required", ur.Required),
                new MySqlParameter("client_ip", ur.Client_id),
                new MySqlParameter("user_id", ur.User_id),
                 new MySqlParameter("datetime",ur.Date_time)
                      };

                            query = @"INSERT INTO user_profile_details_part1(panjiyan_cate_id,required,client_ip,user_id,datetime)
               VALUES(@panjiyan_cate_id,@required,@client_ip,@user_id,@datetime)";
                            rb = db.executeInsertQuery(query, pm11);

                        }
                    }
                }
            }

            if (rb.status == true)
            {
                transScope.Complete();
            }
        }


        return rb;
    }


    public ReturnBool Insert_user_profile_part3_details(olu_ba_layer ur, GridView com2)
    {

        using (TransactionScope transScope = new TransactionScope())
        {

            query = @"update user_profile_master set part_3=@part_3 where user_id=@user_id";
            MySqlParameter[] pmm = new MySqlParameter[]
                {
                new MySqlParameter("part_3","Y"),
                new MySqlParameter("user_id",ur.User_id)
                };
            rb = db.executeUpdateQuery(query, pmm);
            if (rb.status == true)
            {
                foreach (GridViewRow row in com2.Rows)
                {
                    if (rb.status == true)
                    {
                        CheckBox chk = (row.Cells[3].FindControl("chk") as CheckBox);
                        ur.Category = (row.Cells[1].FindControl("lbl_Nivesh") as Label).Text;

                        if (chk.Checked)
                        {
                            ur.Required = "Y";
                        }
                        else
                        {
                            ur.Required = "N";

                        }
                        dt = check_panjiyan_number_from(ur);
                        if (dt.table.Rows.Count > 0)
                        {

                            MySqlParameter[] pm22 = new MySqlParameter[]{
                new MySqlParameter("panjiyan_cate_id", ur.Category),
                    new MySqlParameter("required", ur.Required),
                new MySqlParameter("client_ip", ur.Client_id),
                new MySqlParameter("user_id", ur.User_id),
                 new MySqlParameter("datetime",ur.Date_time)
                      };
                            query = @"Update user_profile_details_part2 SET required=@required,client_ip=@client_ip,datetime=@datetime where user_id=@user_id and panjiyan_cate_id=@panjiyan_cate_id ";
                            rb = db.executeUpdateQuery(query, pm22);
                        }
                        else
                        {
                            MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("panjiyan_cate_id", ur.Category),
                    new MySqlParameter("required", ur.Required),
                new MySqlParameter("client_ip", ur.Client_id),
                new MySqlParameter("user_id", ur.User_id),
                 new MySqlParameter("datetime",ur.Date_time)
                      };

                            query = @"INSERT INTO user_profile_details_part2(panjiyan_cate_id,required,client_ip,user_id,datetime)
               VALUES(@panjiyan_cate_id,@required,@client_ip,@user_id,@datetime)";
                            rb = db.executeInsertQuery(query, pm11);

                        }
                    }
                }
            }

            if (rb.status == true)
            {
                transScope.Complete();
            }
        }


        return rb;
    }


    public ReturnClass.ReturnDataTable check_panjiyan_number_from(olu_ba_layer st)
    {
        MySqlParameter[] pr1 = new MySqlParameter[]{
new MySqlParameter("Category", st.Category),
new MySqlParameter("user_id", st.User_id)
};

        string query = " SELECT panjiyan_id FROM user_profile_details_part1 where panjiyan_cate_id=@Category and user_id=@user_id";
        dt = db.executeSelectQuery(query, pr1);
        return dt;
    }

    public ReturnDataTable Getfileuploadforprofilepic(olu_ba_layer ur)
    {
        query = @"select * from user_upload where user_id = @user_id and category_id=@category_id";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id","100"),
                    new MySqlParameter("category_id",ur.Panjiyan_category_id)
       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }

    public ReturnClass.ReturnDataTable Download(olu_ba_layer ur)
    {
        string qr = "SELECT document_name,file_data,file_extn from user_upload WHERE file_id=@file_id and user_id=@provisional_no";
        MySqlParameter[] pm = new MySqlParameter[]{
                new MySqlParameter("file_id", ur.File_id),
                new MySqlParameter("provisional_no", ur.Provisional_no)
                      };

        dt = db.executeSelectQuery(qr, pm);
        return dt;
    }

    public ReturnClass.ReturnBool delete_file_upload(olu_ba_layer fu)
    {

        MySqlParameter[] t1 = new MySqlParameter[]{
        new MySqlParameter("user_id",fu.User_id),
         new MySqlParameter("file_id",fu.File_id)
         };

        rb = db.executeDeleteQuery("delete from user_upload where user_id=@user_id  and file_id=@file_id  ", t1);
        return rb;
    }

    public ReturnDataTable bind_family_member_grid(olu_ba_layer ur)
    {
        query = @"select concat(u.first_name,' ',u.last_name) as name,u.mobile,u.email_id,date_format(u.date_time,'%d/%M/%Y') as date_time,d.name as family_member
 from user_family_members u 
 join ddl_cat_list d on d.id=u.family_member and d.category='relation'
 where u.user_id=@user_id";
        MySqlParameter[] pm = new MySqlParameter[]
        {
                new MySqlParameter("user_id",ur.User_id)
        };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }

    public ReturnDataTable bind_testimonial()
    {
        query = @"select t.testimonial,concat('Dr. ',u.applicant_first_name,' ',u.applicant_last_name) as name,u.user_id from testimonial t
join user_login u on u.user_id=t.user_id and u.user_type='DOC' where t.`status`='Y'
";
        dt = db.executeSelectQuery(query);


        return dt;
    }

    public ReturnDataTable bind_testimonial_file_id(olu_ba_layer ur)
    {
        query = @"select file_id from doctor_upload d where d.user_id=@user_id and d.category_id='pic'";
        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_idd)
       };
        dt = db.executeSelectQuery(query, pm);
        return dt;
    }


    public ReturnDataTable bind_review_user_file_id(olu_ba_layer ur)
    {
        query = @"select file_id from user_upload d where d.user_id=@user_id and d.category_id='pic'";
        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_idd)
       };
        dt = db.executeSelectQuery(query, pm);
        return dt;
    }



    public ReturnDataTable bind_doctor_profile_pic(olu_ba_layer st)
    {
        query = @"select d.file_data from doctor_upload d where d.file_id=@file_id and d.category_id='pic'";
        MySqlParameter[] pm = new MySqlParameter[]
         {
                new MySqlParameter("file_id",st.File_id)
         };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }

    public ReturnDataTable bind_user_profile_pic(olu_ba_layer st)
    {
        query = @"select d.file_data from user_upload d where d.file_id=@file_id and d.category_id='pic'";
        MySqlParameter[] pm = new MySqlParameter[]
         {
                new MySqlParameter("file_id",st.File_id)
         };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }


    public ReturnDataTable bind_user_chat_file(olu_ba_layer st)
    {
        query = @"select d.file_data,d.mime_type from chatbox d where d.id=@file_id and d.category_id=@category_id";
        MySqlParameter[] pm = new MySqlParameter[]
         {
                new MySqlParameter("file_id",st.File_id),
                new MySqlParameter("category_id",st.Category_id)
         };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }


    public ReturnBool Insert_user_rating(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                    new MySqlParameter("rating", ur.Rating),
                new MySqlParameter("client_ip", ur.Client_id),
                new MySqlParameter("user_id", ur.User_id),
                 new MySqlParameter("date_time",ur.Date_time),
                   new MySqlParameter("review",ur.Review),
                     new MySqlParameter("headline",ur.Headline),
                     new MySqlParameter("category",ur.Category),
                       new MySqlParameter("status",ur.Status)

                      };

        query = @"INSERT INTO website_review(rating,client_ip,user_id,date_time,headline,review,category,status)
               VALUES(@rating,@client_ip,@user_id,@date_time,@headline,@review,@category,@status)";
        rb = db.executeInsertQuery(query, pm11);
        return rb;
    }

    public ReturnBool Update_user_rating(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                    new MySqlParameter("rating", ur.Rating),
                new MySqlParameter("client_ip", ur.Client_id),
                new MySqlParameter("user_id", ur.User_id),
                 new MySqlParameter("date_time",ur.Date_time),
                   new MySqlParameter("review",ur.Review),
                     new MySqlParameter("headline",ur.Headline),
                      new MySqlParameter("category",ur.Category),
                     new MySqlParameter("status",ur.Status)
                      };

        query = @"Update website_review set rating=@rating,client_ip=@client_ip,date_time=@date_time,headline=@headline,review=@review,category=@category,status=@status where user_id=@user_id";
        rb = db.executeInsertQuery(query, pm11);
        return rb;
    }

    public ReturnDataTable select_user_rating()
    {
        //        query = @"SELECT IFNULL(AVG(t.Rating), 0) AverageRating, COUNT(t.Rating) RatingCount,t.user_id,t.headline,t.review,
        //concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as name FROM website_review t
        //join user_login u on u.user_id=t.user_id and u.user_type='USER' group by t.user_id";
        query = @"SELECT IFNULL(ROUND(AVG(t.Rating),1), 0) AverageRating, COUNT(t.Rating) RatingCount,t.user_id,t.headline,t.review,
concat(UCASE(MID(u.applicant_first_name, 1, 1)), LCASE(MID(u.applicant_first_name, 2))) as name,u.user_type FROM website_review t
    join user_login u on u.user_id = t.user_id where t.`status`='Y' group by t.user_id";


        dt = db.executeSelectQuery(query);

        return dt;
    }

    public ReturnDataTable select_Insert_user_rating(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("user_id", ur.User_id)
                      };
        query = @"SELECT IFNULL(ROUND(AVG(Rating),1), 0) AverageRating, COUNT(Rating) RatingCount,headline,review,IFNULL(ROUND(Rating), 0) Rating,
(case when status='N' then 'Pending' when status='Y' then 'Approved' when status='R' then 'Rejected' end) as status_name,status FROM website_review where user_id=@user_id group by id";
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }


    public ReturnDataTable select_doc_for_consult()
    {

        //        query = @"select concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',
        //UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as name,
        //u.user_id,d.country,d.state,c.name as country_name,s.name as state_name,ifnull(concat('Rs. ',pd.doctor_consultation_fee),'Not Available') as doctor_consultation_fee ,ifnull(concat('Rs. ',pd.first_time_fee),'Not Available') as first_time_fee,ifnull(concat('Rs. ',pd.followup_fee),'Not Available') as followup_fee,ifnull(concat('Rs. ',pd.free_checkup),'Not Available') as free_checkup from user_login u
        //left join doctor_profile_details d on d.user_id=u.user_id 
        //left join payment_information_of_doctor pd on pd.user_id=u.user_id 
        //left join countries c on c.id=d.country
        //left join states s on s.country_id=d.country and s.id=d.state
        //left join chat_with_doctor_log l on l.recipient=u.user_id
        //where u.user_type='DOC' and u.extra_1='Y' and u.applicant_verified='Y' group by u.user_id order by l.entry_datetime desc";
        query = @"select concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',
UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as name,
u.user_id,d.country,d.state,c.name as country_name,s.name as state_name,ifnull(concat('Rs. ',pd.doctor_consultation_fee),'Not Available') as doctor_consultation_fee ,ifnull(concat('Rs. ',pd.first_time_fee),'Not Available') as first_time_fee,ifnull(concat('Rs. ',pd.followup_fee),'Not Available') as followup_fee,ifnull(concat('Rs. ',pd.free_checkup),'Not Available') as free_checkup,u.extra_2,
concat('Rs. ',pd.to_be_paid_by_user) as payname,pd.to_be_paid_by_user as pay ,(pd.to_be_paid_by_user * 100) as paymentfinal,d.registration
   from user_login u
left join doctor_profile_details d on d.user_id=u.user_id 
left join payment_information_of_doctor pd on pd.user_id=u.user_id 
left join countries c on c.id=d.country
left join states s on s.country_id=d.country and s.id=d.state
where u.user_type='DOC' and u.extra_1='Y' and u.applicant_verified='Y' group by u.user_id order by u.applicant_first_name";
        dt = db.executeSelectQuery(query);

        return dt;
    }


    public ReturnDataTable select_user_for_consult(olu_ba_layer ur)
    {

        query = @"select *,concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as sendername,co.name as countryname,s.name as statename,DATE_FORMAT(c.start_date,'%W, %M %e, %Y @ %h:%i %p') as sendinddate,c.status,c.start_date
 from chat_with_doctor_log c 
join user_login u on u.user_id=c.payee
left join user_profile_details uu on uu.user_id=c.payee
left join countries co on co.id=uu.country
left join states s on s.country_id=uu.country and s.id=uu.state
where c.recipient=@recipient and (c.follow_up_case_yes_no='N' or c.follow_up_case_yes_no is null)  group by c.id order by c.entry_datetime desc";
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("recipient", ur.User_id)
                      };
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }


    public ReturnDataTable select_user_for_consult_for_followup(olu_ba_layer ur)
    {

        query = @"select *,concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as sendername,co.name as countryname,s.name as statename,DATE_FORMAT(c.start_date,'%W, %M %e, %Y @ %h:%i %p') as sendinddate,c.status,c.start_date
 from chat_with_doctor_log c 
join user_login u on u.user_id=c.payee
left join user_profile_details uu on uu.user_id=c.payee
left join countries co on co.id=uu.country
left join states s on s.country_id=uu.country and s.id=uu.state
where c.recipient=@recipient and c.follow_up_case_yes_no='Y' and c.follow_up_case=@follow_up_case  group by c.id order by c.entry_datetime desc";
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("recipient", ur.User_id),
                new MySqlParameter("follow_up_case", ur.Chat_id)
                      };
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }
    public ReturnDataTable select_doctor_qualification(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("user_id", ur.User_idd)
                      };
        query = @"select * from doctor_qualification d where d.user_id=@user_id";
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }
    public ReturnClass.ReturnBool chatbox_insert(olu_ba_layer fu)
    {
        using (TransactionScope transScope = new TransactionScope())
        {

            if (fu.Isfile)
            {
                query = @"INSERT INTO chatbox (sender_id,receiver_id,message,sending_date,entry_date,status,user_id,client_ip,file_data,isfile,document_name,mime_type,file_extn,category_id,read_chat)
VALUES(@sender_id,@receiver_id,@message,@sending_date,@entry_date,@status,@user_id,@client_ip,@file_data,@isfile,@document_name,@mime_type,@file_extn,@category_id,@read_chat)";
                MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("sender_id", fu.Sender_id),
                new MySqlParameter("receiver_id", fu.Receiver_id),
                  new MySqlParameter("message", fu.Message),
                new MySqlParameter("sending_date", fu.Sending_date),
                new MySqlParameter("entry_date", fu.Date_time),
                 new MySqlParameter ("status", fu.Status),
                   new MySqlParameter ("user_id", fu.User_id),
                   new MySqlParameter ("client_ip", fu.Client_id),
                   new MySqlParameter ("file_data", fu.Document_data),
                   new MySqlParameter ("isfile", fu.Isfile_),
                   new MySqlParameter ("document_name", fu.Document_name),
                   new MySqlParameter ("mime_type", fu.Mime_type),
                   new MySqlParameter ("file_extn", fu.File_extn),
                   new MySqlParameter ("category_id", fu.Category_id),
                   new MySqlParameter ("read_chat", "N")

            };
                rb = db.executeInsertQuery(query, pm11);

            }
            else
            {
                query = @"INSERT INTO chatbox (sender_id,receiver_id,message,sending_date,entry_date,status,user_id,client_ip,isfile,category_id,Action_id,subject,read_chat)
VALUES(@sender_id,@receiver_id,@message,@sending_date,@entry_date,@status,@user_id,@client_ip,@isfile,@category_id,@Action_id,@subject,@read_chat)";
                MySqlParameter[] pm1 = new MySqlParameter[]{
            new MySqlParameter("sender_id", fu.Sender_id),
                new MySqlParameter("receiver_id", fu.Receiver_id),
                  new MySqlParameter("message", fu.Message),
                new MySqlParameter("sending_date", fu.Sending_date),
                new MySqlParameter("entry_date", fu.Date_time),
                 new MySqlParameter ("status", fu.Status),
                   new MySqlParameter ("user_id", fu.User_id),
                   new MySqlParameter ("client_ip", fu.Client_id),
                   new MySqlParameter ("isfile", fu.Isfile_),
                   new MySqlParameter ("category_id", fu.Category_id),
                                       new MySqlParameter("Action_id",fu.Action_id),
                                         new MySqlParameter("Subject",fu.Subject),
                                           new MySqlParameter ("read_chat", "N")

            };
                rb = db.executeInsertQuery(query, pm1);

            }

            if (rb.status)
            {
                query = "Update chat_with_doctor_log set status = @Status, Action_id = @Action_id,Subject=@Subject,user_id=@User_Id,message=@message,entry_datetime=@entry_datetime where id=@id ";

                MySqlParameter[] pm = new MySqlParameter[] {

                    new MySqlParameter("Status",fu.Status),
                    new MySqlParameter("Action_id",fu.Action_id),
                    new MySqlParameter("Subject",fu.Subject),
                    new MySqlParameter("User_Id",fu.User_id),
                    new MySqlParameter("id",fu.Category_id),
                    new MySqlParameter("message",fu.Message),
                    new MySqlParameter("entry_datetime",fu.Date_time)


                    };
                rb = db.executeUpdateQuery(query, pm);
            }

            if (rb.status)
            {
                query = "INSERT INTO chat_send_receive(chat_id,Action_Id,S_Ofc_Mapping_Id,Sent_method,R_Ofc_Mapping_Id,Client_Ip,User_Id) " +
                                                     "values(@chat_id,@act_id,@user_off_id,@Sent_method,@off_id,@client_ip,@User_Id)";

                MySqlParameter[] pm2 = new MySqlParameter[] {

                          new MySqlParameter("chat_id",fu.Category_id),
                          new MySqlParameter("act_id",fu.Action_id),
                          new MySqlParameter("user_off_id",fu.Sender_id),
                          new MySqlParameter("Sent_method",fu.Sent_method),
                          new MySqlParameter("off_id",fu.Receiver_id),
                          new MySqlParameter("client_ip",fu.Client_id),
                          new MySqlParameter("User_Id",fu.User_id)

                    };
                rb = db.executeInsertQuery(query, pm2);
            }

            if (rb.status)
            {
                query = " Insert into chat_registration_transaction (chat_id ,Office_Mapping_Id ,Action_id,message ,Status ,login_id ,client_ip ,Entry_Datetime) " +
                                                      " values(@chat_id, @off_id, @act_id, @message, @Status, @login_id, @client_ip,@date) ";

                MySqlParameter[] pm3 = new MySqlParameter[] {

                          new MySqlParameter("chat_id",fu.Category_id),
                          new MySqlParameter("off_id",fu.Sender_id),
                          new MySqlParameter("act_id",fu.Action_id),
                          new MySqlParameter("message",fu.Message),
                          new MySqlParameter("Status",fu.Status),
                          new MySqlParameter("login_id",fu.User_id),
                          new MySqlParameter("client_ip",fu.Client_id),
                          new MySqlParameter("date",fu.Date_time)

                    };

                rb = db.executeInsertQuery(query, pm3);

            }

            if (rb.status)
            {
                if (fu.Feedback_days != "0" && fu.Feedback_days != null)
                {
                    query = "Update chat_with_doctor_log set feedback_days = @feedback_days, feedback_date = @feedback_date,feedback_sent=@feedback_sent where id=@id ";

                    MySqlParameter[] pm = new MySqlParameter[] {

                    new MySqlParameter("feedback_days",fu.Feedback_days),
                    new MySqlParameter("feedback_date",fu.Date_time),
                    new MySqlParameter("id",fu.Category_id),
                     new MySqlParameter("feedback_sent","N")

                    };
                    rb = db.executeUpdateQuery(query, pm);
                }
            }

            if (rb.status == true)
            {
                transScope.Complete();
            }
        }
        return rb;
    }

    public ReturnDataTable select_chat_id(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("user_id", ur.User_id),
                new MySqlParameter("recipient", ur.User_idd)
                      };
        query = @"select * from chat_with_doctor_log c where c.payee=@recipient and c.`status`='A' and c.recipient=@user_id";
        dt = db.executeSelectQuery(query, pm11);


        return dt;
    }
    public ReturnDataTable select_chat_id_new(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("user_id", ur.User_id),
                new MySqlParameter("recipient", ur.Receiver_id)
                      };
        query = @"select * from chat_with_doctor_log c where c.payee=@user_id and c.`status`='A' and c.recipient=@recipient";
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }


    public ReturnDataTable select_chatbox(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("receiver_id", ur.Receiver_id),
                   new MySqlParameter("category_id", ur.Chat_id)
                      };
        query = @"select *,u.user_type as sendertype,uu.user_type as receivertype,
concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as sendername,
concat(UCASE(MID(uu.applicant_first_name,1,1)),LCASE(MID(uu.applicant_first_name,2)),' ',UCASE(MID(uu.applicant_last_name,1,1)),LCASE(MID(uu.applicant_last_name,2))) as receivername,concat(UCASE(MID(u.applicant_first_name,1,1)),UCASE(MID(u.applicant_last_name,1,1)) )as senderinitial,concat(UCASE(MID(uu.applicant_first_name,1,1)),UCASE(MID(uu.applicant_last_name,1,1)) )as receiverinitial,DATE_FORMAT(c.sending_date,'%W, %M %e, %Y @ %h:%i %p') as sendinddate,d.subject,d.feedback_days,d.feedback_date,d.feedback_sent,d.status as status1,d.start_date
 from chatbox c 
join user_login u on u.user_id=c.sender_id
join user_login uu on uu.user_id=c.receiver_id
join chat_with_doctor_log d on d.id=c.category_id
where c.category_id=@category_id  group by c.id order by c.id ";
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }


    public ReturnDataTable select_chatbox_for_read(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
               // new MySqlParameter("receiver_id", ur.User_id),
                new MySqlParameter("receiver_id", ur.Sender_id),
                   new MySqlParameter("category_id", ur.Chat_id)
                      };
        query = @"select *,u.user_type as sendertype,uu.user_type as receivertype,
concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as sendername,
concat(UCASE(MID(uu.applicant_first_name,1,1)),LCASE(MID(uu.applicant_first_name,2)),' ',UCASE(MID(uu.applicant_last_name,1,1)),LCASE(MID(uu.applicant_last_name,2))) as receivername,concat(UCASE(MID(u.applicant_first_name,1,1)),UCASE(MID(u.applicant_last_name,1,1)) )as senderinitial,concat(UCASE(MID(uu.applicant_first_name,1,1)),UCASE(MID(uu.applicant_last_name,1,1)) )as receiverinitial,DATE_FORMAT(c.sending_date,'%W, %M %e, %Y @ %h:%i %p') as sendinddate,d.subject
 from chatbox c 
join user_login u on u.user_id=c.sender_id
join user_login uu on uu.user_id=c.receiver_id
join chat_with_doctor_log d on d.id=c.category_id
where c.category_id=@category_id  and c.receiver_id=@receiver_id and c.read_chat='N'  group by c.id order by c.id";
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }

    public ReturnDataTable select_chatbox_for_read_for_doc(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("receiver_id", ur.User_id),
                   new MySqlParameter("category_id", ur.Chat_id)
                      };
        query = @"select *,u.user_type as sendertype,uu.user_type as receivertype,
concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as sendername,
concat(UCASE(MID(uu.applicant_first_name,1,1)),LCASE(MID(uu.applicant_first_name,2)),' ',UCASE(MID(uu.applicant_last_name,1,1)),LCASE(MID(uu.applicant_last_name,2))) as receivername,concat(UCASE(MID(u.applicant_first_name,1,1)),UCASE(MID(u.applicant_last_name,1,1)) )as senderinitial,concat(UCASE(MID(uu.applicant_first_name,1,1)),UCASE(MID(uu.applicant_last_name,1,1)) )as receiverinitial,DATE_FORMAT(c.sending_date,'%W, %M %e, %Y @ %h:%i %p') as sendinddate,d.subject
 from chatbox c 
join user_login u on u.user_id=c.sender_id
join user_login uu on uu.user_id=c.receiver_id
join chat_with_doctor_log d on d.id=c.category_id
where c.category_id=@category_id  and c.receiver_id=@receiver_id and c.read_chat='N'  group by c.id order by c.id ";
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }


    public ReturnDataTable select_chatbox_for_user(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("user_id", ur.User_id)
                      };
        //        query = @"select concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',
        //UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as name,
        //u.user_id,d.country,d.state,c.name as country_name,s.name as state_name,ifnull(concat('Rs. ',pd.doctor_consultation_fee),'Not Available') as doctor_consultation_fee ,ifnull(concat('Rs. ',pd.first_time_fee),'Not Available') as first_time_fee,ifnull(concat('Rs. ',pd.followup_fee),'Not Available') as followup_fee,ifnull(concat('Rs. ',pd.free_checkup),'Not Available') as free_checkup,l.subject,DATE_FORMAT(l.start_date,'%W, %M %e, %Y @ %h:%i %p') as sendinddate,l.id,
        //(select concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',
        //UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2)))  from user_login u where u.user_id=l.payee ) as uname,l.payee from user_login u
        //left join doctor_profile_details d on d.user_id=u.user_id 
        //left join payment_information_of_doctor pd on pd.user_id=u.user_id 
        //left join countries c on c.id=d.country
        //left join states s on s.country_id=d.country and s.id=d.state
        //join chat_with_doctor_log l on l.recipient=u.user_id
        //where u.user_type='DOC' and u.extra_1='Y' and u.applicant_verified='Y' and l.chat_created_by=@user_id order by l.start_date desc";

        query = @"select concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',
UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as name,
u.user_id,d.country,d.state,c.name as country_name,s.name as state_name,ifnull(concat('Rs. ',pd.doctor_consultation_fee),'Not Available') as doctor_consultation_fee ,ifnull(concat('Rs. ',pd.first_time_fee),'Not Available') as first_time_fee,ifnull(concat('Rs. ',pd.followup_fee),'Not Available') as followup_fee,ifnull(concat('Rs. ',pd.free_checkup),'Not Available') as free_checkup,l.subject,DATE_FORMAT(l.start_date,'%W, %M %e, %Y @ %h:%i %p') as sendinddate,l.id,
(select concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',
UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2)))  from user_login u where u.user_id=l.payee ) as uname,l.payee,l.status,l.start_date ,
concat('Rs. ',pd.to_be_paid_by_user) as payname,pd.to_be_paid_by_user as pay ,(pd.to_be_paid_by_user * 100) as paymentfinal,d.registration from user_login u
left join doctor_profile_details d on d.user_id=u.user_id 
left join payment_information_of_doctor pd on pd.user_id=u.user_id 
left join countries c on c.id=d.country
left join states s on s.country_id=d.country and s.id=d.state
join chat_with_doctor_log l on l.recipient=u.user_id
where u.user_type='DOC' and u.extra_1='Y' and u.applicant_verified='Y' and (l.chat_created_by=@user_id or l.payee=@user_id) and (l.follow_up_case_yes_no='N' or l.follow_up_case_yes_no is null) order by l.entry_datetime desc";
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }

    public ReturnDataTable select_chatbox_for_user_followup_case(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("user_id", ur.User_id),
                new MySqlParameter("follow_up_case", ur.Chat_id)

                      };
        query = @"select concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',
UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as name,
u.user_id,d.country,d.state,c.name as country_name,s.name as state_name,ifnull(concat('Rs. ',pd.doctor_consultation_fee),'Not Available') as doctor_consultation_fee ,ifnull(concat('Rs. ',pd.first_time_fee),'Not Available') as first_time_fee,ifnull(concat('Rs. ',pd.followup_fee),'Not Available') as followup_fee,ifnull(concat('Rs. ',pd.free_checkup),'Not Available') as free_checkup,l.subject,DATE_FORMAT(l.start_date,'%W, %M %e, %Y @ %h:%i %p') as sendinddate,l.id,
(select concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',
UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2)))  from user_login u where u.user_id=l.payee ) as uname,l.payee,l.status,l.start_date,d.registration from user_login u
left join doctor_profile_details d on d.user_id=u.user_id 
left join payment_information_of_doctor pd on pd.user_id=u.user_id 
left join countries c on c.id=d.country
left join states s on s.country_id=d.country and s.id=d.state
join chat_with_doctor_log l on l.recipient=u.user_id
where u.user_type='DOC' and u.extra_1='Y' and u.applicant_verified='Y' and (l.chat_created_by=@user_id or l.payee=@user_id) and l.follow_up_case_yes_no='Y'  and l.follow_up_case=@follow_up_case  order by l.entry_datetime desc";
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }

    public ReturnDataTable select_chatbox_for_user_followup_case_update(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("user_id", ur.User_id),
                new MySqlParameter("follow_up_case", ur.Chat_id)

                      };
        query = @"select concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',
UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as name,
u.user_id,d.country,d.state,c.name as country_name,s.name as state_name,ifnull(concat('Rs. ',pd.doctor_consultation_fee),'Not Available') as doctor_consultation_fee ,ifnull(concat('Rs. ',pd.first_time_fee),'Not Available') as first_time_fee,ifnull(concat('Rs. ',pd.followup_fee),'Not Available') as followup_fee,ifnull(concat('Rs. ',pd.free_checkup),'Not Available') as free_checkup,l.subject,DATE_FORMAT(l.start_date,'%W, %M %e, %Y @ %h:%i %p') as sendinddate,l.id,
(select concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',
UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2)))  from user_login u where u.user_id=l.payee ) as uname,l.payee,l.status,l.start_date from user_login u
left join doctor_profile_details d on d.user_id=u.user_id 
left join payment_information_of_doctor pd on pd.user_id=u.user_id 
left join countries c on c.id=d.country
left join states s on s.country_id=d.country and s.id=d.state
join chat_with_doctor_log l on l.recipient=u.user_id
where u.user_type='DOC' and u.extra_1='Y' and u.applicant_verified='Y' and (l.chat_created_by=@user_id or l.payee=@user_id) and l.follow_up_case_yes_no='Y'  and l.follow_up_case=@follow_up_case and l.status in ('A','C') order by l.entry_datetime desc";
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }
    public ReturnDataTable select_chatbox_for_user_followup_case_updateapp(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("user_id", ur.User_id),
                new MySqlParameter("follow_up_case", ur.Chat_id)

                      };
        query = @"select concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',
UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as name,
u.user_id,d.country,d.state,c.name as country_name,s.name as state_name,ifnull(concat('Rs. ',pd.doctor_consultation_fee),'Not Available') as doctor_consultation_fee ,ifnull(concat('Rs. ',pd.first_time_fee),'Not Available') as first_time_fee,ifnull(concat('Rs. ',pd.followup_fee),'Not Available') as followup_fee,ifnull(concat('Rs. ',pd.free_checkup),'Not Available') as free_checkup,l.subject,DATE_FORMAT(l.start_date,'%W, %M %e, %Y @ %h:%i %p') as sendinddate,l.id,
(select concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',
UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2)))  from user_login u where u.user_id=l.payee ) as uname,l.payee,l.status,l.start_date from user_login u
left join doctor_profile_details d on d.user_id=u.user_id 
left join payment_information_of_doctor pd on pd.user_id=u.user_id 
left join countries c on c.id=d.country
left join states s on s.country_id=d.country and s.id=d.state
join chat_with_doctor_log l on l.recipient=u.user_id
where u.user_type='DOC' and u.extra_1='Y' and u.applicant_verified='Y' and (l.chat_created_by=@user_id or l.payee=@user_id) and l.follow_up_case_yes_no='Y'  and l.follow_up_case=@follow_up_case and l.status='A' order by l.entry_datetime desc";
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }

    public ReturnClass.ReturnBool insert_chat_with_doctor_log(olu_ba_layer fu)
    {
        using (TransactionScope transScope = new TransactionScope())
        {

            query = @"INSERT INTO chat_with_doctor_log (id,payee,recipient,payment,validity,start_date,status,client_ip,user_id,Action_id,entry_datetime,chat_created_by,follow_up_case,follow_up_case_yes_no,payment_id)
VALUES(@id,@payee,@recipient,@payment,@validity,@start_date,@status,@client_ip,@user_id,@Action_id,@entry_datetime,@chat_created_by,@follow_up_case,@follow_up_case_yes_no,@payment_id)";
            MySqlParameter[] pm11 = new MySqlParameter[]{
                     new MySqlParameter("id", fu.Chat_id),
                new MySqlParameter("payee", fu.Sender_id),
                new MySqlParameter("recipient", fu.Receiver_id),
                  new MySqlParameter("payment", fu.Payment),
                new MySqlParameter("validity", fu.Validity),
                new MySqlParameter("start_date", fu.Date_time),
                 new MySqlParameter ("status", fu.Status),
                   new MySqlParameter ("user_id", fu.User_id),
                   new MySqlParameter ("client_ip", fu.Client_id),
                        new MySqlParameter("Action_id",fu.Action_id),
                        new MySqlParameter("entry_datetime",fu.Date_time),
                         new MySqlParameter("chat_created_by",fu.User_id),
                         new MySqlParameter("follow_up_case",fu.Followupchatid),
                         new MySqlParameter("follow_up_case_yes_no",fu.Follow_up_case_yes_no),
                         new MySqlParameter("payment_id",fu.Payment_Id)




            };
            rb = db.executeInsertQuery(query, pm11);

            if (rb.status)
            {
                query = "INSERT INTO chat_send_receive(chat_id,Action_Id,S_Ofc_Mapping_Id,Sent_method,R_Ofc_Mapping_Id,Client_Ip,User_Id) " +
                                                     "values(@chat_id,@act_id,@user_off_id,@Sent_method,@off_id,@client_ip,@User_Id)";

                MySqlParameter[] pm2 = new MySqlParameter[] {

                          new MySqlParameter("chat_id",fu.Chat_id),
                          new MySqlParameter("act_id",fu.Action_id),
                          new MySqlParameter("user_off_id",fu.Sender_id),
                          new MySqlParameter("Sent_method",fu.Sent_method),
                          new MySqlParameter("off_id",fu.Receiver_id),
                          new MySqlParameter("client_ip",fu.Client_id),
                          new MySqlParameter("User_Id",fu.User_id)

                    };
                rb = db.executeInsertQuery(query, pm2);
            }

            if (rb.status)
            {
                query = " Insert into chat_registration_transaction (chat_id ,Office_Mapping_Id ,Action_id,message ,Status ,login_id ,client_ip ,Entry_Datetime) " +
                                                      " values(@chat_id, @off_id, @act_id, @message, @Status, @login_id, @client_ip,@date) ";

                MySqlParameter[] pm3 = new MySqlParameter[] {

                          new MySqlParameter("chat_id",fu.Chat_id),
                          new MySqlParameter("off_id",fu.Sender_id),
                          new MySqlParameter("act_id",fu.Action_id),
                          new MySqlParameter("message",fu.Message),
                          new MySqlParameter("Status",fu.Status),
                          new MySqlParameter("login_id",fu.User_id),
                          new MySqlParameter("client_ip",fu.Client_id),
                          new MySqlParameter("date",fu.Date_time)

                    };

                rb = db.executeInsertQuery(query, pm3);

            }

            if (rb.status == true)
            {
                transScope.Complete();
            }
        }
        return rb;
    }

    public ReturnDataTable select_chat_log_max_id()
    {
        query = @"select max(id) as id from chat_with_doctor_log ";
        dt = db.executeSelectQuery(query);

        return dt;
    }
    public ReturnBool sms_log(olu_ba_layer lt)
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

    public ReturnDataTable select_receriver_name(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("user_id", ur.Receiver_id),
                  new MySqlParameter("user_type", ur.User_type)

                      };
        query = @"select * from user_login u 
 join user_registration uu on uu.applicant_mobile=u.user_id where u.user_id=@user_id and uu.user_type=@user_type and u.applicant_verified='Y' and uu.applicant_active='Y' ;";
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }


    public ReturnDataTable select_receriver_name_for_user(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("user_id", ur.Sender_id),
                  new MySqlParameter("user_type", ur.User_type)

                      };
        query = @"select * from user_login u 
 join user_registration uu on uu.applicant_mobile=u.user_id where u.user_id=@user_id and uu.user_type=@user_type and u.applicant_verified='Y' and uu.applicant_active='Y' ;";
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }


    public ReturnDataTable select_sender_name(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("user_id", ur.Sender_id)

                      };
        query = @" select * from user_login u join user_registration uu on uu.applicant_mobile=u.user_id where u.user_id=@user_id and uu.user_type='USER' and u.applicant_verified='Y' and uu.applicant_active='Y'";
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }

    public ReturnClass.ReturnDataTable Select_Action_trans(olu_ba_layer ur)
    {

        query = "Select IFNULL(Max(CAST(Action_id as UNSIGNED INTEGER)), 0) AS id from chat_Registration_Transaction where chat_id =@chat_id";
        MySqlParameter[] pm = new MySqlParameter[] {

            new MySqlParameter("chat_id",ur.Chat_id)

            };

        dt = db.executeSelectQuery(query, pm);
        return dt;
    }

    public ReturnClass.ReturnDataTable INTSUB_id(olu_ba_layer co)
    {
        query = "SELECT IFNULL(MAX(CAST(SUBSTRING(id,7,4) as UNSIGNED INTEGER)),0) as pid  from chat_with_doctor_log   WHERE year(entry_datetime) = @c_year AND month(entry_datetime)=@c_month ";
        MySqlParameter[] pr = new MySqlParameter[]{
            new MySqlParameter("c_year",co.C_year),
            new MySqlParameter("c_month",co.C_month),
        };
        dt = db.executeSelectQuery(query, pr);
        return dt;
    }

    public ReturnDataTable newmessage_update(olu_ba_layer ur)
    {
        query = @"select count(*) as newmessage from chat_with_doctor_log l
join chatbox c on c.category_id=l.id where l.chat_created_by=@user_id and c.sending_date>@lastlogintime and c.user_id!=@user_id group by c.id order by c.sending_date desc ";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id),
                    new MySqlParameter("lastlogintime",ur.Logintimeformessage)
       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }


    public ReturnDataTable newmessage_update_new(olu_ba_layer ur)
    {
        query = @"select count(*) as newmessage from chat_with_doctor_log l
join chatbox c on c.category_id=l.id where l.chat_created_by=@user_id and c.read_chat='N' and c.user_id!=@user_id ";

        MySqlParameter[] pm = new MySqlParameter[]
       {
                new MySqlParameter("user_id",ur.User_id),
                    new MySqlParameter("lastlogintime",ur.Logintimeformessage)
       };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }


    public ReturnDataTable select_newmessage_update_for_each(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("user_id",ur.User_id),
                    new MySqlParameter("lastlogintime",ur.Logintimeformessage),
                    new MySqlParameter("id",ur.Chatlogid)
                      };
        query = @"select count(*) as newmessage from chat_with_doctor_log l
join chatbox c on c.category_id=l.id where l.chat_created_by=@user_id and c.sending_date>@lastlogintime and c.user_id!=@user_id  and l.id=@id group by l.id order by c.sending_date desc  ";
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }

    public ReturnDataTable select_newmessage_update_for_each_new(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("user_id",ur.User_id),
                    new MySqlParameter("lastlogintime",ur.Logintimeformessage),
                    new MySqlParameter("id",ur.Chatlogid)
                      };
        query = @"select count(*) as newmessage from chat_with_doctor_log l
join chatbox c on c.category_id=l.id where l.chat_created_by=@user_id and c.read_chat='N' and c.user_id!=@user_id  and l.id=@id ";
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }

    public ReturnDataTable select_newmessage_update_for_each_doctor(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("user_id",ur.User_id),
                    new MySqlParameter("lastlogintime",ur.Logintimeformessage),
                    new MySqlParameter("id",ur.Chatlogid)
                      };
        query = @"select count(*) as newmessage from chat_with_doctor_log l
join chatbox c on c.category_id=l.id where l.recipient=@user_id and c.sending_date>@lastlogintime and c.user_id!=@user_id  and l.id=@id group by l.id order by c.sending_date desc  ";
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }

    public ReturnDataTable select_newmessage_update_for_each_doctor_new(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("user_id",ur.User_id),
                    new MySqlParameter("lastlogintime",ur.Logintimeformessage),
                    new MySqlParameter("id",ur.Chatlogid)
                      };
        query = @"select count(*) as newmessage from chat_with_doctor_log l
join chatbox c on c.category_id=l.id where l.recipient=@user_id and c.read_chat='N' and c.user_id!=@user_id  and l.id=@id  ";
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }


    public ReturnBool update_read_chat(olu_ba_layer lt)
    {
        query = @" update  chatbox set read_chat=@read_chat_yes where read_chat=@read_chat and category_id=@category_id and id=@id and receiver_id=@receiver_id";
        MySqlParameter[] pr = new MySqlParameter[]{
            new MySqlParameter("category_id",lt.Chat_id),
            new MySqlParameter("read_chat","N"),
            new MySqlParameter("read_chat_yes","Y"),
            new MySqlParameter("id",lt.Chatboxid),
              new MySqlParameter("receiver_id",lt.Sender_id)

        };

        rb = db.executeInsertQuery(query, pr);
        return rb;
    }
    public ReturnBool update_read_chat_for_doc(olu_ba_layer lt)
    {
        query = @" update  chatbox set read_chat=@read_chat_yes where read_chat=@read_chat and category_id=@category_id and id=@id and receiver_id=@receiver_id";
        MySqlParameter[] pr = new MySqlParameter[]{
            new MySqlParameter("category_id",lt.Chat_id),
            new MySqlParameter("read_chat","N"),
            new MySqlParameter("read_chat_yes","Y"),
            new MySqlParameter("id",lt.Chatboxid),
              new MySqlParameter("receiver_id",lt.User_id)

        };

        rb = db.executeInsertQuery(query, pr);
        return rb;
    }


    public ReturnBool update_feedback_chat(olu_ba_layer lt)
    {
        query = @" update  chat_with_doctor_log set feedback_sent=@feedback_sent_yes where feedback_sent=@feedback_sent and id=@id";
        MySqlParameter[] pr = new MySqlParameter[]{
            new MySqlParameter("feedback_sent","N"),
            new MySqlParameter("feedback_sent_yes","Y"),
            new MySqlParameter("id",lt.Chat_id)

        };

        rb = db.executeInsertQuery(query, pr);
        return rb;
    }


    public ReturnBool update_feedback_chat_status(olu_ba_layer lt)
    {
        query = @" update  chat_with_doctor_log set status=@status_close where status=@status and id=@id";
        MySqlParameter[] pr = new MySqlParameter[]{
            new MySqlParameter("status","A"),
            new MySqlParameter("status_close","C"),
            new MySqlParameter("id",lt.Chat_id)

        };

        rb = db.executeInsertQuery(query, pr);
        return rb;
    }

    public ReturnDataTable select_visit_counter()
    {
        query = @"SELECT * from website_visit_counter";
        dt = db.executeSelectQuery(query);
        return dt;
    }

    public ReturnBool update_visit_counter()
    {
        query = @" Update website_visit_counter set visit_counter=visit_counter+1";
        rb = db.executeUpdateQuery(query);
        return rb;
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


    public ReturnBool payment_information(olu_ba_layer lt)
    {
        query = @" insert into payment_information (user_id,payment_id,payment_type,payment_rupees,payment_status,client_ip,entry_date_time,entity, currency, order_id, invoice_id, international, method, amount_refunded, refund_status, captured, description, card_id,
        bank, wallet, vpa, email, contact,fee, tax, error_code, error_description, created_at,Receiver_id,Sender_id) 
values(@user_id,@payment_id,@payment_type,@payment_rupees,@payment_status,@client_ip,@entry_date_time,
@entity, @currency, @order_id, @invoice_id, @international, @method, @amount_refunded, @refund_status, @captured, @description, @card_id,
        @bank, @wallet, @vpa, @email, @contact, @fee, @tax, @error_code, @error_description, @created_at,@Receiver_id,@Sender_id)";
        MySqlParameter[] pr = new MySqlParameter[]{
            new MySqlParameter("user_id",lt.User_id),
            new MySqlParameter("payment_id",lt.Payment_Id),
            new MySqlParameter("payment_type",lt.Payment_Type),
            new MySqlParameter("payment_rupees",lt.Payment_Rupees),
            new MySqlParameter("payment_status",lt.Payment_Status),
            new MySqlParameter("client_ip",lt.Client_id),
            new MySqlParameter("entry_date_time",lt.Date_time),

            new MySqlParameter("entity",lt.Entity),
            new MySqlParameter("currency",lt.Currency),
            new MySqlParameter("order_id",lt.Order_id),
            new MySqlParameter("invoice_id",lt.Invoice_id),
            new MySqlParameter("international",lt.International),
            new MySqlParameter("method",lt.Method),
            new MySqlParameter("amount_refunded",lt.Amount_refunded),
            new MySqlParameter("refund_status",lt.Refund_status),
            new MySqlParameter("captured",lt.Captured),
            new MySqlParameter("description",lt.Description),
            new MySqlParameter("card_id",lt.Card_id),
            new MySqlParameter("bank",lt.Bank),
            new MySqlParameter("wallet",lt.Wallet),
            new MySqlParameter("vpa",lt.Vpa),
            new MySqlParameter("email",lt.Email),
            new MySqlParameter("contact",lt.Contact),
            new MySqlParameter("fee",lt.Fee),
            new MySqlParameter("tax",lt.Tax),
            new MySqlParameter("error_code",lt.Error_code),
            new MySqlParameter("error_description",lt.Error_description),
            new MySqlParameter("created_at",lt.Created_at),
            new MySqlParameter("Receiver_id",lt.Receiver_id),
            new MySqlParameter("Sender_id",lt.Sender_id)





        };

        rb = db.executeInsertQuery(query, pr);
        return rb;
    }


    public ReturnDataTable selectpdfd()
    {
        query = "select file_data from doctor_upload u where u.file_id='5'";

        dt = db.executeSelectQuery(query);

        return dt;
    }

    public ReturnDataTable transction_report(olu_ba_layer il)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("user_id", il.User_id),


                      };
        //        query = @"select c.id, p.payment_id,p.Sender_id ,p.Receiver_id,p.payment_type,p.payment_rupees,p.payment_status,DATE_FORMAT(p.entry_date_time,'%W, %M %e, %Y @ %h:%i %p') as created_at,p.method,p.card_id,p.bank,p.vpa,p.email,p.contact,
        //concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as payee,
        //concat(UCASE(MID(uu.applicant_first_name,1,1)),LCASE(MID(uu.applicant_first_name,2)),' ',UCASE(MID(uu.applicant_last_name,1,1)),LCASE(MID(uu.applicant_last_name,2))) as payer,(cast(ifnull(p.payment_rupees/100,0) as UNSIGNED INTEGER)) as payment_in_rupees from payment_information p
        //join user_login u on u.user_id=p.Sender_id
        //join user_login uu on uu.user_id=p.Receiver_id
        //join chat_with_doctor_log c on c.payment_id=p.payment_id
        //where p.Sender_id=@user_id";


        query = @"select  p.payment_id,p.Sender_id ,p.Receiver_id,p.payment_type,p.payment_rupees,p.payment_status,DATE_FORMAT(p.entry_date_time,'%W, %M %e, %Y @ %h:%i %p') as created_at,p.method,p.card_id,p.bank,p.vpa,p.email,p.contact,
concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as payee,
(cast(ifnull(p.payment_rupees/100,0) as UNSIGNED INTEGER)) as payment_in_rupees,
(case when p.payment_type='Consultation Fees' then c.id when p.payment_type='Meditation Fee' then m.reference_id when p.payment_type='Angel Card Reading Fees' then a.reference_id when p.payment_type='Follow Up Consultation Fees' then c.id end ) as id
 from payment_information p
join user_login u on u.user_id=p.Sender_id
left join chat_with_doctor_log c on c.payment_id=p.payment_id
left join angelcardreadingform a on a.payment_id = p.payment_id
left join meditation4healthform m on m.payment_id = p.payment_id
where p.Sender_id=@user_id group by p.payment_id ";
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }


    public ReturnBool Insert_meditation_form_details(olu_ba_layer ur)
    {
        using (TransactionScope transScope = new TransactionScope())
        {

            query = @"insert into meditation4healthform (reference_id,first_name,middle_name,last_name,gender,mobile,email_id,
country,state,city,address,pincode,user_id,client_ip,date_time,category,money,message,payment_id)
values(@reference_id,@first_name,@middle_name,@last_name,@gender,@mobile,@email_id,
@country,@state,@city,@address,@pincode,@user_id,@client_ip,@date_time,@category,@money,@message,@payment_id)";

            MySqlParameter[] pm = new MySqlParameter[]
                {
                      new MySqlParameter("reference_id",ur.Receiver_id),
                new MySqlParameter("first_name",ur.First_name),
                new MySqlParameter("middle_name",ur.Middle_name),
                new MySqlParameter("last_name",ur.Last_name),
                new MySqlParameter("gender",ur.Gender),
                new MySqlParameter("mobile",ur.Mobile),
                new MySqlParameter("email_id",ur.Email_id),
                new MySqlParameter("country",ur.Country),
                new MySqlParameter("state",ur.State),
                new MySqlParameter("city",ur.City),
                new MySqlParameter("address",ur.Address_1),
                new MySqlParameter("pincode",ur.Pincode),
                      new MySqlParameter("user_id",ur.User_id),
                      new MySqlParameter("client_ip",ur.Client_id),
                      new MySqlParameter("date_time",ur.Date_time),
                           new MySqlParameter("category",ur.Category),
                new MySqlParameter("money",ur.Mode),
                new MySqlParameter("message",ur.Address_2),
                  new MySqlParameter("payment_id",ur.Payment_Id)
                };

            rb = db.executeInsertQuery(query, pm);
            if (rb.status == true)
            {
                transScope.Complete();
            }
        }


        return rb;
    }


    public ReturnBool Insert_angel_form_details(olu_ba_layer ur)
    {
        using (TransactionScope transScope = new TransactionScope())
        {

            query = @"insert into angelcardreadingform (reference_id,first_name,middle_name,last_name,gender,mobile,email_id,
country,state,city,address,pincode,user_id,client_ip,date_time,category,money,question1,question2,question3,payment_id)
values(@reference_id,@first_name,@middle_name,@last_name,@gender,@mobile,@email_id,
@country,@state,@city,@address,@pincode,@user_id,@client_ip,@date_time,@category,@money,@question1,@question2,@question3,@payment_id)";

            MySqlParameter[] pm = new MySqlParameter[]
                {
                      new MySqlParameter("reference_id",ur.Receiver_id),
                new MySqlParameter("first_name",ur.First_name),
                new MySqlParameter("middle_name",ur.Middle_name),
                new MySqlParameter("last_name",ur.Last_name),
                new MySqlParameter("gender",ur.Gender),
                new MySqlParameter("mobile",ur.Mobile),
                new MySqlParameter("email_id",ur.Email_id),
                new MySqlParameter("country",ur.Country),
                new MySqlParameter("state",ur.State),
                new MySqlParameter("city",ur.City),
                new MySqlParameter("address",ur.Address_1),
                new MySqlParameter("pincode",ur.Pincode),
                      new MySqlParameter("user_id",ur.User_id),
                      new MySqlParameter("client_ip",ur.Client_id),
                      new MySqlParameter("date_time",ur.Date_time),
                           new MySqlParameter("category",ur.Category),
                new MySqlParameter("money",ur.Mode),
                  new MySqlParameter("question1",ur.Question1),
                    new MySqlParameter("question2",ur.Question2),
                      new MySqlParameter("question3",ur.Question3),
                       new MySqlParameter("payment_id",ur.Payment_Id)
                };

            rb = db.executeInsertQuery(query, pm);
            if (rb.status == true)
            {
                transScope.Complete();
            }
        }


        return rb;
    }

    public ReturnBool Insert_tarot_form_details(olu_ba_layer ur)
    {
        using (TransactionScope transScope = new TransactionScope())
        {

            query = @"insert into tarotcardreadingform (reference_id,first_name,middle_name,last_name,gender,mobile,email_id,
country,state,city,address,pincode,user_id,client_ip,date_time,category,money,question1,question2,question3,payment_id)
values(@reference_id,@first_name,@middle_name,@last_name,@gender,@mobile,@email_id,
@country,@state,@city,@address,@pincode,@user_id,@client_ip,@date_time,@category,@money,@question1,@question2,@question3,@payment_id)";

            MySqlParameter[] pm = new MySqlParameter[]
                {
                      new MySqlParameter("reference_id",ur.Receiver_id),
                new MySqlParameter("first_name",ur.First_name),
                new MySqlParameter("middle_name",ur.Middle_name),
                new MySqlParameter("last_name",ur.Last_name),
                new MySqlParameter("gender",ur.Gender),
                new MySqlParameter("mobile",ur.Mobile),
                new MySqlParameter("email_id",ur.Email_id),
                new MySqlParameter("country",ur.Country),
                new MySqlParameter("state",ur.State),
                new MySqlParameter("city",ur.City),
                new MySqlParameter("address",ur.Address_1),
                new MySqlParameter("pincode",ur.Pincode),
                      new MySqlParameter("user_id",ur.User_id),
                      new MySqlParameter("client_ip",ur.Client_id),
                      new MySqlParameter("date_time",ur.Date_time),
                           new MySqlParameter("category",ur.Category),
                new MySqlParameter("money",ur.Mode),
                  new MySqlParameter("question1",ur.Question1),
                    new MySqlParameter("question2",ur.Question2),
                      new MySqlParameter("question3",ur.Question3),
                       new MySqlParameter("payment_id",ur.Payment_Id)
                };

            rb = db.executeInsertQuery(query, pm);
            if (rb.status == true)
            {
                transScope.Complete();
            }
        }


        return rb;
    }
    public ReturnClass.ReturnDataTable Select_com_id(string year, string month)
    {
        ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
        query = @"select ifnull(max(CAST(SUBSTRING(cd.reference_id,7,4)as unsigned)),0) as comp_id from meditation4healthform cd 
                 where  DATE_FORMAT(cd.date_time,'%y')=@year and DATE_FORMAT(cd.date_time,'%m')=@month ";
        MySqlParameter[] pm = new MySqlParameter[] {
        new MySqlParameter("year", year),
        new MySqlParameter("month", month)

        };

        dt = db.executeSelectQuery(query, pm);
        return dt;
    }


    public ReturnClass.ReturnDataTable Select_com_id_for_angel(string year, string month)
    {
        ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
        query = @" select ifnull(max(CAST(SUBSTRING(cd.reference_id,7,4)as unsigned)),0) as comp_id from angelcardreadingform cd 
                 where  DATE_FORMAT(cd.date_time,'%y')=@year and DATE_FORMAT(cd.date_time,'%m')=@month ";
        MySqlParameter[] pm = new MySqlParameter[] {
        new MySqlParameter("year", year),
        new MySqlParameter("month", month)

        };

        dt = db.executeSelectQuery(query, pm);
        return dt;
    }

    public ReturnClass.ReturnDataTable Select_com_id_for_tarot(string year, string month)
    {
        ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
        query = @" select ifnull(max(CAST(SUBSTRING(cd.reference_id,7,4)as unsigned)),0) as comp_id from tarotcardreadingform cd 
                 where  DATE_FORMAT(cd.date_time,'%y')=@year and DATE_FORMAT(cd.date_time,'%m')=@month ";
        MySqlParameter[] pm = new MySqlParameter[] {
        new MySqlParameter("year", year),
        new MySqlParameter("month", month)

        };

        dt = db.executeSelectQuery(query, pm);
        return dt;
    }
    public ReturnDataTable bind_doctor_profile(olu_ba_layer ur)
    {
        query = "select * from doctor_profile_details p where p.user_id=@user_id";
        MySqlParameter[] pm = new MySqlParameter[]
        {
                new MySqlParameter("user_id",ur.User_id)
        };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }


    public ReturnDataTable select_check_for_oct_offer(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("user_id", ur.User_id)
                      };
        query = @"select date_format(u.date_time,'%Y/%m/%d') as date_time from user_login u where u.user_id=@user_id and u.applicant_verified='Y' and u.user_type='USER'";
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }


    public ReturnDataTable select_count_chat_log(olu_ba_layer ur)
    {
        MySqlParameter[] pm11 = new MySqlParameter[]{
                new MySqlParameter("user_id", ur.User_id)
                      };
        query = @"select * from chat_with_doctor_log c where c.user_id=@user_id";
        dt = db.executeSelectQuery(query, pm11);

        return dt;
    }

    public ReturnBool Insert_order_medicine(olu_ba_layer ur)
    {
        using (TransactionScope transScope = new TransactionScope())
        {

            query = @"insert into order_medicine (order_id,user_id,client_ip,entry_datetime,name_of_remedy,quantity,
country,state,city,address,pincode,gender,mobile,email_id,potency,name_of_doctor,name,action_id,status)
values(@order_id,@user_id,@client_ip,@entry_datetime,@name_of_remedy,@quantity,@country,@state,@city,@address,@pincode,@gender,@mobile,@email_id,@potency,@name_of_doctor,@name,@action_id,@status)";

            MySqlParameter[] pm = new MySqlParameter[]
                {
                new MySqlParameter("order_id",ur.Order_id),
                  new MySqlParameter("user_id",ur.User_id),
                      new MySqlParameter("client_ip",ur.Client_id),
                      new MySqlParameter("entry_datetime",ur.Date_time),
                new MySqlParameter("name_of_remedy",ur.Remedy_name),
                new MySqlParameter("quantity",ur.Quantity),
                    new MySqlParameter("country",ur.Country),
                new MySqlParameter("state",ur.State),
                new MySqlParameter("city",ur.City),
                new MySqlParameter("address",ur.Address_1),
                new MySqlParameter("pincode",ur.Pincode),
                new MySqlParameter("gender",ur.Gender),
                new MySqlParameter("mobile",ur.Mobile),
                new MySqlParameter("email_id",ur.Email_id),
                 new MySqlParameter("potency",ur.Potency_name),
                  new MySqlParameter("name_of_doctor",ur.Doc_name),
                   new MySqlParameter("name",ur.First_name),
                           new MySqlParameter("action_id",ur.Action_id),
                new MySqlParameter("status",ur.Status)
                };

            rb = db.executeInsertQuery(query, pm);
            if (rb.status == true)
            {
                transScope.Complete();
            }

        }
        return rb;
    }

    public ReturnClass.ReturnDataTable Select_com_id_for_order_medicine(string year, string month)
    {
        ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
        query = " select ifnull(max(substr(cd.order_id,5,4)),0) as comp_id from order_medicine cd "
                + " where  DATE_FORMAT(cd.entry_datetime,'%y')=@year and DATE_FORMAT(cd.entry_datetime,'%m')=@month ";
        MySqlParameter[] pm = new MySqlParameter[] {
        new MySqlParameter("year", year),
        new MySqlParameter("month", month)

        };

        dt = db.executeSelectQuery(query, pm);
        return dt;
    }

    public ReturnDataTable bind_order_medicine(olu_ba_layer ur)
    {
        query = @"select o.order_id,date_format(o.entry_datetime,'%W, %M %e, %Y @ %h:%i %p') as entry_time,o.name_of_remedy,o.quantity,o.potency,o.name_of_doctor,
concat(cc.name,', ',s.name,', ',ci.name,', ',o.address,', ',o.pincode) as address,(case when o.`status`='P' then 'Pending' else 'Pending' end) as status,o.name  
from order_medicine o 
join countries cc on cc.id=o.country
join states s on s.id = o.state
join cities ci on ci.id = o.city
where o.user_id=@user_id";
        MySqlParameter[] pm = new MySqlParameter[]
        {
                new MySqlParameter("user_id",ur.User_id)
        };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }

    public ReturnDataTable bind_order_medicine_by_order_id(olu_ba_layer ur)
    {
        query = @"select o.order_id,date_format(o.entry_datetime,'%W, %M %e, %Y @ %h:%i %p') as entry_time,o.name_of_remedy,o.quantity,o.potency,o.name_of_doctor,
concat(cc.name,', ',s.name,', ',ci.name,', ',o.address,', ',o.pincode) as address,(case when o.`status`='P' then 'Pending' else 'Pending' end) as status,o.name ,o.email_id,o.mobile 
from order_medicine o 
join countries cc on cc.id=o.country
join states s on s.id = o.state
join cities ci on ci.id = o.city
where o.user_id=@user_id and o.order_id=@order_id";
        MySqlParameter[] pm = new MySqlParameter[]
        {
                new MySqlParameter("user_id",ur.User_id),
                new MySqlParameter("order_id",ur.Order_id)
        };
        dt = db.executeSelectQuery(query, pm);

        return dt;
    }
}