using MySql.Data.MySqlClient;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

/// <summary>
/// Summary description for admin_da_layer
/// </summary>
public class admin_da_layer : ReturnClass
{
    ReturnDataTable dt = new ReturnDataTable();
    ReturnBool rb = new ReturnBool();
    db_maria_connection db = new db_maria_connection();
    string query = null;
    public admin_da_layer()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public ReturnDataTable select_pending_application_for_login()
    {

        query = @"select concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',
UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as name,u.applicant_mobile,u.applicant_email,u.user_type,date_format(u.date_time,'%W, %M %e, %Y @ %h:%i %p') as date_time,u.applicant_id,
(case when u.`applicant_verified`='N' then 'Pending' when u.`applicant_verified`='Y' then 'Approved' when u.`applicant_verified`='R' then 'Rejected' end) as status,
(case when u.`applicant_verified`='N' then 'Yellow' when u.`applicant_verified`='Y' then 'Green' when u.`applicant_verified`='R' then 'Red' end) as colorr
from user_login u join user_registration uu on uu.applicant_mobile=u.applicant_mobile
where  u.user_type='DOC' and u.applicant_verified in ('N','Y','R') and uu.applicant_mobile_verified='Y' and uu.applicant_active='Y' order by u.date_time";
        dt = db.executeSelectQuery(query);

        return dt;
    }


    public ReturnDataTable select_pending_application_for_login_total()
    {

        query = @"select concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',
UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as name,u.applicant_mobile,u.applicant_email,u.user_type,date_format(u.date_time,'%W, %M %e, %Y @ %h:%i %p') as date_time,u.applicant_id,
(case when u.`applicant_verified`='N' then 'Pending' when u.`applicant_verified`='Y' then 'Approved' when u.`applicant_verified`='R' then 'Rejected' end) as status,
(case when u.`applicant_verified`='N' then 'Yellow' when u.`applicant_verified`='Y' then 'Green' when u.`applicant_verified`='R' then 'Red' end) as colorr
from user_login u join user_registration uu on uu.applicant_mobile=u.applicant_mobile
where  u.user_type='DOC' and u.applicant_verified in ('N') and uu.applicant_mobile_verified='Y' and uu.applicant_active='Y' order by u.date_time";
        dt = db.executeSelectQuery(query);

        return dt;
    }


    public ReturnDataTable select_pending_application_for_login_total_count(string status)
    {

        query = @"select concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',
UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as name,u.applicant_mobile,u.applicant_email,u.user_type,date_format(u.date_time,'%W, %M %e, %Y @ %h:%i %p') as date_time,u.applicant_id,
(case when u.`applicant_verified`='N' then 'Pending' when u.`applicant_verified`='Y' then 'Approved' when u.`applicant_verified`='R' then 'Rejected' end) as status,
(case when u.`applicant_verified`='N' then 'Yellow' when u.`applicant_verified`='Y' then 'Green' when u.`applicant_verified`='R' then 'Red' end) as colorr,u.reason,
date_format(u.action_date,'%W, %M %e, %Y @ %h:%i %p') as action_date
from user_login u join user_registration uu on uu.applicant_mobile=u.applicant_mobile
where  u.user_type='DOC' and u.applicant_verified=@status and uu.applicant_mobile_verified='Y' and uu.applicant_active='Y' group by u.applicant_id order by u.date_time";
        MySqlParameter[] pmm = new MySqlParameter[]
               {
                new MySqlParameter("status",status),
               };
        dt = db.executeSelectQuery(query, pmm);

        return dt;
    }


    public ReturnBool update_pending_login_application(admin_ba_layer ur)
    {

        using (TransactionScope transScope = new TransactionScope())
        {
            query = @"update user_login set applicant_verified=@applicant_verified,client_ip=@client_ip,reason=@reason,extra_1=@extra_1 where applicant_mobile=@applicant_mobile and applicant_id=@applicant_id";
            MySqlParameter[] pmm = new MySqlParameter[]
                {
                new MySqlParameter("applicant_verified",ur.Status),
                 new MySqlParameter("extra_1",ur.Status),
                new MySqlParameter("applicant_verifiedd","N"),
                new MySqlParameter("applicant_mobile",ur.Applicant_mobile),
                 new MySqlParameter("applicant_id",ur.Applicant_id),
                 new MySqlParameter("client_ip",ur.Client_id),
                  new MySqlParameter("reason",ur.Reason)
                };
            rb = db.executeUpdateQuery(query, pmm);

            if (ur.Status == "Y")
            {
                if (rb.status == true)
                {
                    ReturnDataTable dt = find_payment_informatyion_of_doctor(ur);
                    if (dt.table.Rows.Count > 0)
                    {
                        query = @"update payment_information_of_doctor set to_be_paid_by_user=@to_be_paid_by_user,client_ip=@client_ip where user_id=@applicant_mobile ";
                        MySqlParameter[] pmmm = new MySqlParameter[]
                            {
                new MySqlParameter("to_be_paid_by_user",ur.Type),
                new MySqlParameter("applicant_mobile",ur.Applicant_mobile),
                 new MySqlParameter("client_ip",ur.Client_id)
                            };
                        rb = db.executeUpdateQuery(query, pmmm);
                    }
                    else
                    {
                        query = @"insert into payment_information_of_doctor (user_id,to_be_paid_by_user,client_ip) values(@user_id,@to_be_paid_by_user,@client_ip)  ";
                        MySqlParameter[] pmmm = new MySqlParameter[]
                            {
                new MySqlParameter("to_be_paid_by_user",ur.Type),
                new MySqlParameter("user_id",ur.Applicant_mobile),
                 new MySqlParameter("client_ip",ur.Client_id)
                            };
                        rb = db.executeInsertQuery(query, pmmm);
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

    public ReturnDataTable find_payment_informatyion_of_doctor(admin_ba_layer bl)
    {
        query = @"select * from payment_information_of_doctor where user_id=@user_id ";
        MySqlParameter[] pmm = new MySqlParameter[]
              {
                new MySqlParameter("user_id",bl.Applicant_mobile),
              };
        dt = db.executeSelectQuery(query, pmm);
        return dt;
    }
    public ReturnDataTable bind_testimonial()
    {
        query = @"select t.testimonial,concat('Dr. ',u.applicant_first_name,' ',u.applicant_last_name) as name,u.user_id,
date_format(t.date_time,'%W, %M %e, %Y @ %h:%i %p') as date_time,u.applicant_mobile,u.applicant_email,u.user_type,t.id as applicant_id,
(case when t.`status`='N' then 'Pending' when t.`status`='Y' then 'Approved' when t.`status`='R' then 'Rejected' end) as status,
(case when t.`status`='N' then 'Yellow' when t.`status`='Y' then 'Green' when t.`status`='R' then 'Red' end) as colorr
 from testimonial t
join user_login u on u.user_id=t.user_id and u.user_type='DOC' where t.`status` in ('N','Y','R') ";
        dt = db.executeSelectQuery(query);
        return dt;
    }



    public ReturnDataTable bind_testimonial_total_count(string status)
    {
        query = @"select t.testimonial,concat('Dr. ',u.applicant_first_name,' ',u.applicant_last_name) as name,u.user_id,
date_format(t.date_time,'%W, %M %e, %Y @ %h:%i %p') as date_time,u.applicant_mobile,u.applicant_email,u.user_type,t.id as applicant_id,
(case when t.`status`='N' then 'Pending' when t.`status`='Y' then 'Approved' when t.`status`='R' then 'Rejected' end) as status,
(case when t.`status`='N' then 'Yellow' when t.`status`='Y' then 'Green' when t.`status`='R' then 'Red' end) as colorr,t.reason,
date_format(t.action_date,'%W, %M %e, %Y @ %h:%i %p') as action_date
 from testimonial t
join user_login u on u.user_id=t.user_id and u.user_type='DOC' where t.`status`=@status ";
        MySqlParameter[] pmm = new MySqlParameter[]
              {
                new MySqlParameter("status",status),
              };
        dt = db.executeSelectQuery(query, pmm);
        return dt;
    }


    public ReturnDataTable bind_testimonial_total()
    {
        query = @"select t.testimonial,concat('Dr. ',u.applicant_first_name,' ',u.applicant_last_name) as name,u.user_id,
date_format(t.date_time,'%W, %M %e, %Y @ %h:%i %p') as date_time,u.applicant_mobile,u.applicant_email,u.user_type,t.id as applicant_id,
(case when t.`status`='N' then 'Pending' when t.`status`='Y' then 'Approved' when t.`status`='R' then 'Rejected' end) as status
 from testimonial t
join user_login u on u.user_id=t.user_id and u.user_type='DOC' where t.`status` in ('N') ";
        dt = db.executeSelectQuery(query);
        return dt;
    }


    public ReturnBool update_pending_testimonial_application(admin_ba_layer ur)
    {
        query = @"update testimonial set status=@status,client_ip=@client_ip,reason=@reason where user_id=@user_id and id=@applicant_id";
        MySqlParameter[] pmm = new MySqlParameter[]
            {
                new MySqlParameter("status",ur.Status),
                new MySqlParameter("statuss","N"),
                new MySqlParameter("user_id",ur.Applicant_mobile),
                 new MySqlParameter("applicant_id",ur.Applicant_id),
                 new MySqlParameter("client_ip",ur.Client_id),
                   new MySqlParameter("reason",ur.Reason)
            };
        rb = db.executeUpdateQuery(query, pmm);
        return rb;
    }


    public ReturnDataTable bind_Review()
    {
        query = @"SELECT IFNULL(AVG(t.Rating), 0) AverageRating, COUNT(t.Rating) RatingCount,t.user_id,t.headline,t.review,
concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',
UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as name,
date_format(t.date_time,'%W, %M %e, %Y @ %h:%i %p') as date_time,u.applicant_mobile,u.applicant_email,u.user_type,t.id as applicant_id,
(case when t.`status`='N' then 'Pending' when t.`status`='Y' then 'Approved' when t.`status`='R' then 'Rejected' end) as status,
(case when t.`status`='N' then 'Yellow' when t.`status`='Y' then 'Green' when t.`status`='R' then 'Red' end) as colorr
 FROM website_review t
 join user_login u on u.user_id = t.user_id where t.`status` in ('N','Y','R')  group by t.user_id ";
        dt = db.executeSelectQuery(query);
        return dt;
    }


    public ReturnDataTable bind_Review_total_count(string status)
    {
        query = @"SELECT IFNULL(AVG(t.Rating), 0) AverageRating, COUNT(t.Rating) RatingCount,t.user_id,t.headline,t.review,
concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',
UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as name,
date_format(t.date_time,'%W, %M %e, %Y @ %h:%i %p') as date_time,u.applicant_mobile,u.applicant_email,u.user_type,t.id as applicant_id,
(case when t.`status`='N' then 'Pending' when t.`status`='Y' then 'Approved' when t.`status`='R' then 'Rejected' end) as status,
(case when t.`status`='N' then 'Yellow' when t.`status`='Y' then 'Green' when t.`status`='R' then 'Red' end) as colorr,t.reason,
date_format(t.action_date,'%W, %M %e, %Y @ %h:%i %p') as action_date
 FROM website_review t
 join user_login u on u.user_id = t.user_id where t.`status` =@status  group by t.user_id ";
        MySqlParameter[] pmm = new MySqlParameter[]
            {
                new MySqlParameter("status",status),
            };
        dt = db.executeSelectQuery(query, pmm);
        return dt;
    }


    public ReturnDataTable bind_Review_total()
    {
        query = @"SELECT IFNULL(AVG(t.Rating), 0) AverageRating, COUNT(t.Rating) RatingCount,t.user_id,t.headline,t.review,
concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',
UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as name,
date_format(t.date_time,'%W, %M %e, %Y @ %h:%i %p') as date_time,u.applicant_mobile,u.applicant_email,u.user_type,t.id as applicant_id,
(case when t.`status`='N' then 'Pending' when t.`status`='Y' then 'Approved' when t.`status`='R' then 'Rejected' end) as status
 FROM website_review t
 join user_login u on u.user_id = t.user_id where t.`status` in ('N')  group by t.user_id ";
        dt = db.executeSelectQuery(query);
        return dt;
    }


    public ReturnBool update_pending_review_application(admin_ba_layer ur)
    {
        query = @"update website_review set status=@status,client_ip=@client_ip,reason=@reason where user_id=@user_id and id=@applicant_id";
        MySqlParameter[] pmm = new MySqlParameter[]
            {
                new MySqlParameter("status",ur.Status),
                new MySqlParameter("statuss","N"),
                new MySqlParameter("user_id",ur.Applicant_mobile),
                 new MySqlParameter("applicant_id",ur.Applicant_id),
                 new MySqlParameter("client_ip",ur.Client_id),
                  new MySqlParameter("reason",ur.Reason)
            };
        rb = db.executeUpdateQuery(query, pmm);
        return rb;
    }


    public ReturnBool sms_log(admin_ba_layer lt)
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


    public ReturnDataTable transction_report()
    {

        query = @"select p.payment_id,p.Sender_id ,p.Receiver_id,p.payment_type,p.payment_rupees,p.payment_status,DATE_FORMAT(p.entry_date_time,'%W, %M %e, %Y @ %h:%i %p') as created_at,p.method,p.card_id,p.bank,p.vpa,p.email,p.contact,
concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as payee,
concat(UCASE(MID(uu.applicant_first_name,1,1)),LCASE(MID(uu.applicant_first_name,2)),' ',UCASE(MID(uu.applicant_last_name,1,1)),LCASE(MID(uu.applicant_last_name,2))) as payer,(cast(ifnull(p.payment_rupees/100,0) as UNSIGNED)) as payment_in_rupees from payment_information p
join user_login u on u.user_id=p.Sender_id
join user_login uu on uu.user_id=p.Receiver_id";
        dt = db.executeSelectQuery(query);

        return dt;
    }
    public ReturnDataTable bind_order_medicine()
    {
        query = @"select o.order_id,date_format(o.entry_datetime,'%W, %M %e, %Y @ %h:%i %p') as entry_time,o.name_of_remedy,o.quantity,o.potency,o.name_of_doctor,
concat(cc.name,', ',s.name,', ',ci.name,', ',o.address,', ',o.pincode) as address,(case when o.`status`='P' then 'Pending' else 'Pending' end) as status,o.name  
from order_medicine o 
join countries cc on cc.id=o.country
join states s on s.id = o.state
join cities ci on ci.id = o.city
where o.status in ('P')";
        dt = db.executeSelectQuery(query);

        return dt;
    }

    public ReturnDataTable transction_report_total_count(string status)
    {
        //        query = @"select p.payment_id,p.Sender_id ,p.Receiver_id,p.payment_type,p.payment_rupees,p.payment_status,DATE_FORMAT(p.entry_date_time,'%W, %M %e, %Y @ %h:%i %p') as created_at,p.method,p.card_id,p.bank,p.vpa,p.email,p.contact,
        //concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as payee,
        //concat(UCASE(MID(uu.applicant_first_name,1,1)),LCASE(MID(uu.applicant_first_name,2)),' ',UCASE(MID(uu.applicant_last_name,1,1)),LCASE(MID(uu.applicant_last_name,2))) as payer,(cast(ifnull(p.payment_rupees/100,0) as UNSIGNED)) as payment_in_rupees from payment_information p
        //join user_login u on u.user_id=p.Sender_id
        //join user_login uu on uu.user_id=p.Receiver_id where p.payment_status=@status";

        query = @"select p.payment_id,p.Sender_id ,p.Receiver_id,p.payment_type,p.payment_rupees,p.payment_status,DATE_FORMAT(p.entry_date_time,'%W, %M %e, %Y @ %h:%i %p') as created_at,p.method,p.card_id,p.bank,p.vpa,p.email,p.contact,
concat(UCASE(MID(u.applicant_first_name,1,1)),LCASE(MID(u.applicant_first_name,2)),' ',UCASE(MID(u.applicant_last_name,1,1)),LCASE(MID(u.applicant_last_name,2))) as payee,
(cast(ifnull(p.payment_rupees/100,0) as UNSIGNED)) as payment_in_rupees from payment_information p
join user_login u on u.user_id=p.Sender_id
where p.payment_status=@status group by p.payment_id";
        MySqlParameter[] pmm = new MySqlParameter[]
            {
                new MySqlParameter("status",status),
            };
        dt = db.executeSelectQuery(query, pmm);
        return dt;
    }
}