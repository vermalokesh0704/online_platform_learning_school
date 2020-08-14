using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Control_chatting : System.Web.UI.UserControl
{
    string key = ConfigurationManager.AppSettings["enc_qrystring_key"].ToString();
    olu_ba_layer bl = new olu_ba_layer();
    olu_da_layer dl = new olu_da_layer();
    Utilities util = new Utilities();
    ReturnClass.ReturnDataTable dtnew = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnDataTable dtt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnDataTable dttt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnDataTable dtttt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnDataTable dtagain = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnDataTable dt1 = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnDataTable dt2 = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnBool rb = new ReturnClass.ReturnBool();
    int maincount, localcount, finalcount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
            if (Request.QueryString["uid"] != null && Request.QueryString["uid"].ToString() != "" && Request.QueryString["chid"].ToString() != null && Request.QueryString["chid"].ToString() != "")
            {
                chat();

            }
            else
            {
                Utilities.MessageBoxShow_Redirect("Cannot Find Chat, Please try again...", "Consult_online_new");
            }
        }
    }

    public void chat()
    {
        
        string subdec = null;
        DateTime date1_stamp = new DateTime();
        DateTime o = new DateTime();
        try
        {
            if (Session["User_Id"] != null)
            {
                bl.User_id = Session["User_Id"].ToString();
            }
            else
            {
                if (Request.Cookies["User_Id"] != null)
                {
                    Session["User_Id"] = Request.Cookies["User_Id"].Value;
                    bl.User_id = Request.Cookies["User_Id"].Value;
                }
            }
            bl.Sender_id = util.Decrypt_AES(Request.QueryString["sid"].ToString(), key);
            bl.Receiver_id = util.Decrypt_AES(Request.QueryString["uid"].ToString(), key);
            bl.Chat_id = util.Decrypt_AES(Request.QueryString["chid"].ToString(), key);
            dt1 = dl.select_chatbox_for_read(bl);
            if (dt1.table.Rows.Count > 0)
            {
                foreach (DataRow row in dt1.table.Rows)
                {
                    bl.Chatboxid = row["id"].ToString();
                    rb = dl.update_read_chat(bl);
                }
                dt2 = dl.newmessage_update_new(bl);
                if (dt2.table.Rows.Count > 0 && dt2.table.Rows[0]["newmessage"].ToString() != "0")
                {
                    ((Label)this.Page.Master.FindControl("lbl_new_message")).Text = dt2.table.Rows[0]["newmessage"].ToString();
                    ((Label)this.Page.Master.FindControl("lbl_new_message")).Visible = true;
                }
                else
                {
                    ((Label)this.Page.Master.FindControl("lbl_new_message")).Visible = false;
                }
            }

            dt = dl.select_chatbox(bl);
            StringBuilder htmlTable = new StringBuilder();
            int lol = 1;
            if (dt.table.Rows.Count > 0)
            {
                if (dt.table.Rows[0]["subject"].ToString() != "" || dt.table.Rows[0]["subject"] != null)
                {
                    try
                    {
                        Txt_subject.Text = util.Decrypt_AES(dt.table.Rows[0]["subject"].ToString(), key);
                        subdec = util.Decrypt_AES(dt.table.Rows[0]["subject"].ToString(), key);
                    }catch(Exception ex )
                    {
                        Txt_subject.Text = "";
                        subdec = "";
                    }
                }
                if (Txt_subject.Text == "")
                {
                    Txt_subject.Enabled = true;
                }
                else
                {
                    Txt_subject.Enabled = false;
                }
                if (Request.QueryString["sub"] != null && Request.QueryString["sub"].ToString() != "")
                {
                    try
                    {
                        Txt_subject.Text = util.Decrypt_AES(Request.QueryString["sub"].ToString(), key);
                        subdec = util.Decrypt_AES(Request.QueryString["sub"].ToString(), key);
                    }catch(Exception ex)
                    {
                        Txt_subject.Text = "";
                        subdec = "";
                    }
                }
                if (Txt_subject.Text == "")
                {
                    Txt_subject.Enabled = true;
                }
                else
                {
                    Txt_subject.Enabled = false;
                }
                if (dt.table.Rows[0]["feedback_sent"].ToString() == "N")
                {
                    bl.Feedback_days = dt.table.Rows[0]["feedback_days"].ToString();
                    bl.Feedback_date = dt.table.Rows[0]["feedback_date"].ToString();
                    date1_stamp = Convert.ToDateTime(dt.table.Rows[0]["feedback_date"].ToString());
                    DateTime answer = date1_stamp.AddDays(Convert.ToInt32(bl.Feedback_days));
                    o = DateTime.Now;
                    int result = DateTime.Compare(o, answer);
                    if (result >= 0)
                    {
                        rb = dl.update_feedback_chat(bl);
                        Thread Stamp_Action = new Thread(delegate ()
                        {
                            bl.User_type = "USER";
                            dtnew = dl.select_receriver_name_for_user(bl);
                            if (dtnew.table.Rows.Count > 0)
                            {
                                bl.Type = null;
                                bl.First_name = dtnew.table.Rows[0]["applicant_first_name"].ToString();
                                bl.Message = "Hi " + bl.First_name + ", We want to hear from you about your consultation for " + subdec + ". Please log in and update the chat with the feedback.";
                                bl.Success = send_sms_to_user(dtnew.table.Rows[0]["applicant_mobile"].ToString(), bl.Message);
                                rb = dl.sms_log(bl);
                                bl.Type = null;
                                if (dtnew.table.Rows[0]["applicant_email"].ToString() != "" && dtnew.table.Rows[0]["applicant_email"].ToString() != null)
                                {
                                    bl.Success = email_to_user_new(dtnew.table.Rows[0]["applicant_email"].ToString(), bl.Message);
                                    rb = dl.sms_log(bl);
                                }
                            }
                        });
                        Stamp_Action.IsBackground = true;
                        Stamp_Action.Start();
                    }
                }
                if (dt.table.Rows[0]["status1"].ToString() == "C")
                {
                    chhaatt.Visible = false;
                }

                foreach (DataRow row in dt.table.Rows)
                {
                    string type = row["sendertype"].ToString();

                    if (type == "USER")
                    {
                        htmlTable.AppendLine("<div class=\"process right\">");
                    }
                    else if (type == "DOC")
                    {
                        htmlTable.AppendLine("<div class=\"process left\">");
                    }

                    htmlTable.AppendLine("<div class=\"process-step\">");
                    htmlTable.AppendLine("<strong>" + row["senderinitial"].ToString() + "</strong>");
                    htmlTable.AppendLine("</div>");
                    if (type == "USER")
                    {
                        htmlTable.AppendLine("<div class=\"process-content rightt\">");
                    }
                    else if (type == "DOC")
                    {
                        htmlTable.AppendLine("<div class=\"process-content \" >");
                    }
                    htmlTable.AppendLine("<div class=\"process-icon\">");
                    htmlTable.AppendLine("<span class=\"flaticon-line\"></span>");
                    htmlTable.AppendLine("</div>");
                    htmlTable.AppendLine("<div class=\"process-info\">");
                    htmlTable.AppendLine("<h5 class=\"mb-20\">" + row["sendername"].ToString() + "</h5>");
                    //    htmlTable.AppendLine("<p><b>" + row["message"].ToString() + "</b></p>");
                    htmlTable.AppendLine("<p style=\"text-align: justify\"><b>" + util.Decrypt_AES(row["message"].ToString(), key) + "</b></p>");
                    if (row["isfile"].ToString() == "Y")
                    {
                        htmlTable.AppendLine("<p><a target=\"_blank\" href=\"Handler_chat.ashx?id=" + row["id"].ToString() + "&chid=" + Server.UrlEncode(util.Encrypt_AES(Request.QueryString["chid"].ToString(), key)) + "\">" + row["document_name"].ToString() + "</a></p>");
                    }
                    //  htmlTable.AppendLine("<p><i class=\"fa fa-clock-o\" aria-hidden=\"true\"></i> " + row["sendinddate"].ToString() + "</p>");
                    htmlTable.AppendLine("<p style=\" font-size: 11px;\"> " + row["sendinddate"].ToString() + "</p>");
                    htmlTable.AppendLine("</div>");
                    htmlTable.AppendLine("</div>");
                    if (type == "USER" && lol == 1)
                    {
                        htmlTable.AppendLine("<div class=\"border-area right-bottom\"></div>");
                    }
                    else if (type == "DOC" && lol == 1)
                    {
                        htmlTable.AppendLine("<div class=\"border-area left-bottom\"></div>");
                    }
                    else if (type == "USER" && lol != 1)
                    {
                        htmlTable.AppendLine("<div class=\"border-area right-bottom\"></div>");
                        htmlTable.AppendLine("<div class=\"border-area right-top\"></div>");
                    }
                    else if (type == "DOC" && lol != 1)
                    {
                        htmlTable.AppendLine("<div class=\"border-area left-top\"></div>");
                        htmlTable.AppendLine("<div class=\"border-area left-bottom\"></div>");
                    }
                    htmlTable.AppendLine("</div>");
                    Literal1.Text = htmlTable.ToString();
                    lol++;
                }
            }
            else if (util.Decrypt_AES(Request.QueryString["chid"].ToString(), key) == "0")
            {
                bl.Sender_id = util.Decrypt_AES(Request.QueryString["sid"].ToString(), key);
                bl.Receiver_id = util.Decrypt_AES(Request.QueryString["uid"].ToString(), key);
                if (Request.QueryString["followupchid"] != null && Request.QueryString["followupchid"].ToString() != "")
                {
                    bl.Followupchatid = util.Decrypt_AES(Request.QueryString["followupchid"].ToString(), key);
                    bl.Follow_up_case_yes_no = "Y";
                }
                else
                {
                    bl.Follow_up_case_yes_no = "N";
                }

                if (Request.QueryString["payment_id"] != null && Request.QueryString["payment_id"].ToString() != "")
                {
                    bl.Payment_Id = Request.QueryString["payment_id"].ToString();
                }
                else
                {
                    bl.Payment_Id = "";
                }

                bl.Status = "A";
                //   bl.Payment = "400";
                int k = 0;
                if (Request.QueryString["payment_rupee"] != null)
                {
                    k = Convert.ToInt32(Request.QueryString["payment_rupee"].ToString());
                    if (k != 0)
                    {
                        k = k / 100;
                    }
                    
                }
                bl.Payment = k.ToString();
                bl.Validity = "7";
                if (Session["User_Id"] != null)
                {
                    bl.User_id = Session["User_Id"].ToString();
                }
                else
                {
                    if (Request.Cookies["User_Id"] != null)
                    {
                        Session["User_Id"] = Request.Cookies["User_Id"].Value;
                        bl.User_id = Request.Cookies["User_Id"].Value;
                    }
                }
                bl.Client_id = util.GetClientIpAddress(this.Page);
                bl.Date_time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                bl.Action_id = Get_trans_action(bl.Category_id);
                bl.Sent_method = "Chat";
                bl.Chat_id = INTSUB_ID_from();
                rb = dl.insert_chat_with_doctor_log(bl);
                if (rb.status)
                {

                    dt = dl.select_sender_name(bl);
                    if (dt.table.Rows.Count > 0)
                    {
                        bl.First_name = dt.table.Rows[0]["applicant_first_name"].ToString();
                        bl.Email_id = dt.table.Rows[0]["applicant_email"].ToString();
                    }
                   
                    Thread Stamp_Action = new Thread(delegate ()
                {
                    bl.User_type = "DOC";
                    dt = dl.select_receriver_name(bl);
                    if (dt.table.Rows.Count > 0)
                    {
                        bl.Message = "Hi " + bl.First_name + ", Your online consultation is confirmed, Thanks. ";
                        bl.Success = send_sms_to_user(bl.Sender_id, bl.Message);
                        rb = dl.sms_log(bl);
                        bl.Type = null;
                        //bl.Message = "Hi " + bl.First_name + ", Your case online consultation at cellsalts4health is submitted to " + dt.table.Rows[0]["applicant_first_name"].ToString() + ", we will update you when he accepts it and if requires more details to prescribe the remedy. ";
                        //bl.Success = send_sms_to_user(bl.Sender_id, bl.Message);
                        //rb = dl.sms_log(bl);
                        //bl.Type = null;
                        if (bl.Email_id != "" && bl.Email_id != null)
                        {
                            //bl.Success = email_to_user_new(bl.Email_id, bl.Message);
                            //rb = dl.sms_log(bl);
                            if (k != 0)
                            {
                                bl.Type = null;
                                string datetime = DateTime.Now.ToString("dd-MMMM-yyyy");
                                bl.Message = get_message(datetime, bl.Chat_id, bl.First_name, k.ToString());
                                bl.Success = email_to_user_new_pay(bl.Email_id, bl.Message);
                                rb = dl.sms_log(bl);
                            }
                        }
                        bl.First_name = dt.table.Rows[0]["applicant_first_name"].ToString();
                        bl.Message = "Hi " + bl.First_name + ", A new case is assigned to you for online consultation at cellsalts4health, Please login and check the details";
                        bl.Success = send_sms_to_user(bl.Receiver_id, bl.Message);
                        rb = dl.sms_log(bl);
                        bl.Type = null;
                        if (dt.table.Rows[0]["applicant_email"].ToString() != "" && dt.table.Rows[0]["applicant_email"].ToString() != null)
                        {
                            bl.Success = email_to_user_new(dt.table.Rows[0]["applicant_email"].ToString(), bl.Message);
                            rb = dl.sms_log(bl);
                        }
                    }
                });
                    Stamp_Action.IsBackground = true;
                    Stamp_Action.Start();
                    if (Request.QueryString["sub"] != null && Request.QueryString["sub"].ToString() != "")
                    {
                        Response.Redirect("chatting.aspx?uid=" + Server.UrlEncode(Request.QueryString["uid"].ToString()) + "&chid=" + Server.UrlEncode(util.Encrypt_AES(bl.Chat_id, key)) + "&sid=" + Server.UrlEncode(Request.QueryString["sid"].ToString()) + "&sub=" + Server.UrlEncode(Request.QueryString["sub"].ToString()));
                    }
                    else
                    {
                        Response.Redirect("chatting.aspx?uid=" + Server.UrlEncode(Request.QueryString["uid"].ToString()) + "&chid=" + Server.UrlEncode(util.Encrypt_AES(bl.Chat_id, key)) + "&sid=" + Server.UrlEncode(Request.QueryString["sid"].ToString()) + "&sub=");
                    }

                }
            }
            else
            {
                if (Request.QueryString["sub"] != null && Request.QueryString["sub"].ToString() != "")
                {
                    try
                    { 
                    Txt_subject.Text = util.Decrypt_AES(Request.QueryString["sub"].ToString(), key);
                    subdec = util.Decrypt_AES(Request.QueryString["sub"].ToString(), key);
                    }
                    catch (Exception ex)
                    {
                        Txt_subject.Text = "";
                        subdec = "";
                    }
                }
                if (Txt_subject.Text == "")
                {
                    Txt_subject.Enabled = true;
                }
                else
                {
                    Txt_subject.Enabled = false;
                }
                //htmlTable.AppendLine("<div class=\"table-responsive\">");
                //htmlTable.AppendLine("<table class=\"table table-1 table-bordered table-striped table-2\" style=\"border-color:#20B2AA; table-layout:fixed;font-size:10px;\" > ");
                //htmlTable.AppendLine("<tbody>");
                //htmlTable.AppendLine("<tr>");
                //htmlTable.AppendLine("<td colspan=8 style=\"background:#20B2AA;color:black;width:30px;font-weight:bolder;\"> No Chat Found </td>");
                //htmlTable.AppendLine("</tr>");
                //htmlTable.AppendLine("</tbody>");
                //htmlTable.AppendLine("</table>");
                //htmlTable.AppendLine("</div>");
                //Literal1.Text = htmlTable.ToString();
            }
        }
        catch (Exception ex)
        {
            // Utilities.MessageBoxShow_Redirect("Cannot Find Chat, Please try again...", "Consult_online_new.aspx");
            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "log.txt", ex.ToString());
            Utilities.MessageBoxShow_Redirect("Cannot Find Chat, Please try again...", "../Logout.aspx");
        }

    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["CheckRefresh"] = Session["CheckRefresh"];
    }
    protected void message_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                if (Session["CheckRefresh"] != null)
                {
                    if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                    {
                        Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                        if (Session["User_Id"] != null)
                        {
                            bl.User_id = Session["User_Id"].ToString();
                            // bl.Sender_id = Session["User_Id"].ToString();
                        }
                        else
                        {
                            if (Request.Cookies["User_Id"] != null)
                            {
                                Session["User_Id"] = Request.Cookies["User_Id"].Value;
                                bl.User_id = Request.Cookies["User_Id"].Value;
                                //   bl.Sender_id = Request.Cookies["User_Id"].Value;
                            }
                        }
                        bl.Receiver_id = util.Decrypt_AES(Request.QueryString["uid"].ToString(), key);
                        bl.Sender_id = util.Decrypt_AES(Request.QueryString["sid"].ToString(), key);
                        bl.Status = "A";
                        bl.Date_time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        bl.Sending_date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        bl.Client_id = util.GetClientIpAddress(this.Page);
                        string description = txt_Message.Text.Trim();
                        description = description.Replace("\r\n", "<br/>");
                        // bl.Message = util.Encrypt_AES(txt_Message.Text.Trim(), key);
                        bl.Message = util.Encrypt_AES(description, key);
                        bl.Category_id = util.Decrypt_AES(Request.QueryString["chid"].ToString(), key);
                        bl.Action_id = Get_trans_action(bl.Category_id);
                        bl.Subject = util.Encrypt_AES(Txt_subject.Text.Trim(), key);
                        bl.Sent_method = "Chat";
                        Int32 maxLimit = 10485760;
                        if (FileUpload1.HasFile)
                        {
                            bl.Isfile = true;
                            bl.Isfile_ = "Y";
                            string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                            double size = FileUpload1.PostedFile.ContentLength;
                            string contenttypee = FileUpload1.PostedFile.ContentType.ToLower();

                            if (FileUpload1.PostedFile.ContentLength > maxLimit)
                            {
                                Utilities.MessageBoxShow("File Is too Big...Maximum Size allowed is 5 Mb");
                            }
                            else if (contenttypee == "application/pdf" || contenttypee == "application/x-pdf" || contenttypee == "application/x-unknown" || contenttypee == "image/gif" || contenttypee == "image/png" || contenttypee == "image/jpg" || contenttypee == "image/jpeg")
                            {
                                bl.File_extn = Path.GetExtension(FileUpload1.PostedFile.FileName).ToString();
                                Stream fs = default(Stream);
                                fs = FileUpload1.PostedFile.InputStream;
                                BinaryReader br1 = new BinaryReader(fs);
                                bl.Document_data = br1.ReadBytes(FileUpload1.PostedFile.ContentLength);
                                bl.Document_name = FileUpload1.PostedFile.FileName;
                                if (ext == ".pdf")
                                {
                                    bl.Mime_type = "application/pdf";
                                }
                                else
                                {
                                    bl.Mime_type = contenttypee;
                                }
                            }
                            else
                            {
                                Utilities.MessageBoxShow("Only .pdf .jpeg .gif .jpg .png files are allowed, try again");
                            }
                        }
                        else
                        {
                            bl.Isfile_ = "N";
                            bl.Isfile = false;
                        }
                        rb = dl.chatbox_insert(bl);
                        if (rb.status)
                        {

                            dtagain = dl.select_sender_name(bl);
                            if (dtagain.table.Rows.Count > 0)
                            {
                                bl.Middle_name = dtagain.table.Rows[0]["applicant_first_name"].ToString();
                                bl.Email_id = dtagain.table.Rows[0]["applicant_email"].ToString();
                            }
                            txt_Message.Text = null;
                            Thread Stamp_Action = new Thread(delegate ()
                            {
                                bl.User_type = "DOC";
                                dtttt = dl.select_receriver_name(bl);
                                if (dtagain.table.Rows.Count > 0)
                                {
                                    if(bl.Action_id=="2")
                                    {
                                        bl.Message = "Hi " + bl.Middle_name + ", Your case online consultation at cellsalts4health is submitted to " + dtttt.table.Rows[0]["applicant_first_name"].ToString() + ", we will update you when he accepts it and if requires more details to prescribe the remedy. ";
                                        bl.Success = send_sms_to_user(bl.Sender_id, bl.Message);
                                        rb = dl.sms_log(bl);
                                        bl.Type = null;
                                        bl.Success = email_to_user_new(bl.Email_id, bl.Message);
                                        rb = dl.sms_log(bl);
                                        bl.Type = null;
                                    }

                                    bl.First_name = dtttt.table.Rows[0]["applicant_first_name"].ToString();
                                    bl.Message = "Hi " + bl.First_name + ", " + bl.Middle_name + " has messaged you. Please login and check.";
                                    bl.Success = send_sms_to_user(bl.Receiver_id, bl.Message);
                                    rb = dl.sms_log(bl);
                                    if (dtttt.table.Rows[0]["applicant_email"].ToString() != "" && dtttt.table.Rows[0]["applicant_email"].ToString() != null)
                                    {
                                        bl.Success = email_to_user_new(dtttt.table.Rows[0]["applicant_email"].ToString(), bl.Message);
                                        rb = dl.sms_log(bl);
                                    }
                                }
                            });
                            Stamp_Action.IsBackground = true;
                            Stamp_Action.Start();
                            //   chat();
                        }
                        chat();


                    }
                    else
                        Utilities.MessageBoxShow("Page Refresh or Back button is now allowed");
                }
                else
                    Utilities.MessageBoxShow("Page expired!!! Please re open this page in new window.");
            }
            catch (NullReferenceException)
            {
                //  Utilities.MessageBoxShow_Redirect("Records could not be saved: Please Try Again", "chatting.aspx");
                Utilities.MessageBoxShow_Redirect("Records could not be saved: Please Try Again", "../Logout.aspx");

            }
        }
    }
    public string send_sms_to_user(string mobile, string message)
    {
        WebClient httpclient = new WebClient();
        httpclient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        httpclient.QueryString.Add("username", "cellsalts");
        httpclient.QueryString.Add("password", "health12");
        httpclient.QueryString.Add("type", "TEXT");
        httpclient.QueryString.Add("sender", "CELSLT");
        httpclient.QueryString.Add("mobile", mobile);
        httpclient.QueryString.Add("message", message);
        bl.Message_to = message;
        bl.Mobile = mobile;
        bl.Type = "TEXT";
        string baseurl = "https://app.indiasms.com/sendsms/sendsms.php";
        Stream data = httpclient.OpenRead(baseurl);
        StreamReader reader = new StreamReader(data);
        string s = reader.ReadToEnd();
        data.Close();
        reader.Close();
        return (s);
    }
    public string email_to_user_new(string email, string message)
    {
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("webmail.cellsalts4health.com");
            mail.From = new MailAddress("contact@cellsalts4health.com");
            mail.To.Add(email);
            mail.Subject = "Online Consultation";
            mail.Body = message;
            MailAddress bcc = new MailAddress("snehamca2006@gmail.com");
            mail.Bcc.Add(bcc);
            SmtpServer.Port = 587;
            bl.Message_to = message;
            bl.Type = "Email";
            mail.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
            SmtpServer.Credentials = new System.Net.NetworkCredential("contact@cellsalts4health.com", "uxvN5$63");
            //  SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }
        catch (Exception ex)
        {

        }


        return "Success";
    }


    public string email_to_user_new_pay(string email, string message)
    {
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("webmail.cellsalts4health.com");
            mail.From = new MailAddress("contact@cellsalts4health.com");
            mail.To.Add(email);
            mail.Subject = "Online Consultation";
            mail.Body = message;
            mail.IsBodyHtml = true;
            SmtpServer.Port = 587;
            MailAddress bcc = new MailAddress("snehamca2006@gmail.com");
            mail.Bcc.Add(bcc);
            bl.Message_to = message;
            bl.Type = "Email";
            mail.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
            SmtpServer.Credentials = new System.Net.NetworkCredential("contact@cellsalts4health.com", "uxvN5$63");
            //  SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }
        catch (Exception ex)
        {

        }


        return "Success";
    }
    public string Get_trans_action(string chat_id)
    {
        bl.Chat_id = chat_id;

        dt = dl.Select_Action_trans(bl);
        if (dt.table.Rows.Count > 0)
        {
            bl.Action_id = dt.table.Rows[0]["id"].ToString();
        }
        bl.Action_id = Convert.ToString(Convert.ToInt16(bl.Action_id) + 1);
        return bl.Action_id;
    }

    public string INTSUB_ID_from()
    {
        ReturnClass.ReturnDataTable rdt = new ReturnClass.ReturnDataTable();
        try
        {
            bl.C_year = DateTime.Now.ToString("yyyy");
            bl.C_month = DateTime.Now.ToString("MM");
            rdt = dl.INTSUB_id(bl);
            if (rdt.table.Rows.Count > 0)
            {
                bl.S1 = rdt.table.Rows[0]["pid"].ToString();
                if (bl.S1 == "")
                {
                    bl.S = "0";
                    bl.Nid = Convert.ToString(Convert.ToInt32(bl.S) + 1);
                }
                else
                    bl.Nid = Convert.ToString(Convert.ToInt32(bl.S1) + 1);
            }
            else
            {
                bl.S = "0";
                bl.Nid = Convert.ToString(Convert.ToInt32(bl.S) + 1);
            }
            bl.Aid = DateTime.Now.ToString("yy") + bl.C_month + "9" + "1" + bl.Nid.PadLeft(4, '0');
        }
        catch { bl.Aid = "" + "" + DateTime.Now.ToString("yy") + bl.C_month + "9" + "0001"; }
        return bl.Aid;
    }


    public string get_message(string datetime, string consultation_id, string name, string money)
    {
        string msg = "";

        StringBuilder htmlTable = new StringBuilder();
        htmlTable.AppendLine("<div style=\"width:80%;padding-left:50px;padding-right:10px;\">");
        htmlTable.AppendLine("<div style=\"width:100%;padding-left:20px;background-image: linear-gradient(to right, #20B2AA , white);\">");
        htmlTable.AppendLine("<h1 style=\"color:white; position: relative;\" ><p>Your online consultation is confirmed   <a href=\"https://www.cellsalts4health.com/\">  <img style='width:50px;height:50px;padding-top:20px;padding-left:20px;' src='https://www.cellsalts4health.com/images/logonew.png'></img></a></p></h1>");
        htmlTable.AppendLine("</div>");
        htmlTable.AppendLine("<div style=\"padding-left:20px;\">");
        htmlTable.AppendLine("<p>Date: " + datetime + "</p>");
        htmlTable.AppendLine("<p>Order No: " + consultation_id + "</p>");
        htmlTable.AppendLine("<h4><p><b>PATIENT DETAILS</b></p></h4>");
        htmlTable.AppendLine("<p> " + name + " </p>");
        htmlTable.AppendLine("<h4><p><b>ORDER DETAILS</b></p></h4>");
        htmlTable.AppendLine("<table style=\"table-layout:fixed;font-size:14px;width:100%;\" border=\"1\"> ");
        htmlTable.AppendLine("<thead>");
        htmlTable.AppendLine("<tr>");
        htmlTable.AppendLine("<th style=\"color:black;font-weight:bolder; font-size:16px;text-align:center; \" >ITEM</th>");
        htmlTable.AppendLine("<th style=\"color:black;font-weight:bolder;font-size:16px;text-align:center;\" >CONSULTATION FEE </th>");
        htmlTable.AppendLine("<th style=\"color:black;font-weight:bolder;font-size:16px;text-align:center;\" >TOTAL</th>");
        htmlTable.AppendLine("</tr>");
        htmlTable.AppendLine("</thead>");
        htmlTable.AppendLine("<tbody>");
        htmlTable.AppendLine("<tr>");
        htmlTable.AppendLine("<td  style=\"color:black;text-align:left\"> ONLINE CONSULTATION AT CELLSALTS4HEALTH " + datetime + ":</td>");
        htmlTable.AppendLine("<td  style=\"color:black;text-align:right\"> " + money + "</td>");
        htmlTable.AppendLine("<td  style=\"color:black;text-align:right\"> " + money + " </td>");
        htmlTable.AppendLine("</tr>");
        htmlTable.AppendLine("</tbody>");
        htmlTable.AppendLine("</table><br>");
        htmlTable.AppendLine("<hr style=\"height:1px; background-color: black;border: 0; width: 100 %;\">");
        htmlTable.AppendLine("<p style=\"float:left\">TOTAL PAY (INR)</p>");
        htmlTable.AppendLine("<p style=\"float:right\">   " + money + "</p>");
        htmlTable.AppendLine("<br>");
        htmlTable.AppendLine("<br>");
        htmlTable.AppendLine("<p>Write to us at contact@cellsalts4health.com for any concerns regarding your order.</p><br>");
        htmlTable.AppendLine("</div>");
        htmlTable.AppendLine("</div>");
        msg = htmlTable.ToString();

        return msg;
    }
}