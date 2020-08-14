using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Control_contact_us : System.Web.UI.UserControl
{
    doc_ba_layer bl = new doc_ba_layer();
    doc_da_layer dl = new doc_da_layer();
    Utilities util = new Utilities();
    ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnBool rb = new ReturnClass.ReturnBool();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["CheckRefresh"] = Session["CheckRefresh"];
    }
    protected void submit_part1_Click(object sender, EventArgs e)
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
                        bl.First_name = txt_first_name.Text.Trim();
                        bl.Mobile = mobile_no.Text.Trim();
                        bl.Email_id = email_id.Text.Trim();
                        bl.Message = txt_address.Text.Trim();
                        bl.Date_time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        bl.Client_id = util.GetClientIpAddress(this.Page);
                        if (Session["User_Id"] != null)
                        {
                            bl.User_id = Session["User_Id"].ToString();
                        }
                        else
                        {
                            bl.User_id = DBNull.Value.ToString();
                        }
                        rb = dl.Insert_contact_us_details(bl);
                        if (rb.status)
                        {
                            //Thread Stamp_Action = new Thread(delegate ()
                            //{
                            //    bl.Success = send_sms_to_user(bl.Mobile);
                            //    rb = dl.sms_log(bl);
                            //    bl.Type = null;
                            //    bl.Success = send_sms_to_admin(bl.First_name, bl.Email_id, bl.Mobile, bl.Message);
                            //    rb = dl.sms_log(bl);
                            //    bl.Type = null;
                            //    bl.Success = send_sms_to_admin_2(bl.First_name, bl.Email_id, bl.Mobile, bl.Message);
                            //    rb = dl.sms_log(bl);
                            //    bl.Type = null;
                            //    bl.Success = email_to_admin(bl.First_name, bl.Email_id, bl.Mobile, bl.Message);
                            //    rb = dl.sms_log(bl);
                            //    bl.Type = null;
                            //    bl.Success = email_to_user(bl.First_name, bl.Email_id, bl.Mobile, bl.Message);
                            //    rb = dl.sms_log(bl);
                            //});
                            //Stamp_Action.IsBackground = true;
                            //Stamp_Action.Start();

                           
                            txt_address.Text = null;
                            txt_first_name.Text = null;
                            mobile_no.Text = null;
                            email_id.Text = null;
                            Utilities.MessageBox_UpdatePanel(UpdatePanel2, "We have received your message! we will contact you shortly.");
                        }
                        else
                        {
                            Utilities.MessageBox_UpdatePanel(UpdatePanel2, "Page expired!!! Please re open this page in new window.");
                        }
                    }
                    else
                        Utilities.MessageBox_UpdatePanel(UpdatePanel2, "Page Refresh or Back button is now allowed");
                }
                else
                    Utilities.MessageBox_UpdatePanel(UpdatePanel2, "Page expired!!! Please re open this page in new window.");
            }
            catch (NullReferenceException)
            {
                //   Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
                Utilities.MessageBox_UpdatePanel(UpdatePanel2, "Page expired!!! Please re open this page in new window.");
            }
        }
    }

    public string email_to_user(string name, string email, string mobile, string message)
    {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        mail.From = new MailAddress("cellsalts4health@gmail.com");
        mail.To.Add(email);
        mail.Subject = "Contact Us";
        mail.Body = "We've received your message! we'll contact you shortly";
        SmtpServer.Port = 587;
        bl.Message_to = "We've received your message! we'll contact you shortly";
        bl.Type = "Email";
        SmtpServer.Credentials = new System.Net.NetworkCredential("cellsalts4health@gmail.com", "S@@nv!@2012");
        SmtpServer.EnableSsl = true;
        SmtpServer.Send(mail);
        return "Success";
    }
    public string email_to_admin(string name,string email,string mobile,string message)
    {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        mail.From = new MailAddress("cellsalts4health@gmail.com");
       mail.To.Add("snehamca2006@gmail.com");
       mail.To.Add("anujsrivastava956@gmail.com");
        mail.Subject = "Contact Us";
        mail.Body = "Name :" + name + " Email id: " + email + " Mobile No: " + mobile + " Message :" + message;
        SmtpServer.Port = 587;
        bl.Message_to = "Name :" + name + " Email id: " + email + " Mobile No: " + mobile + " Message :" + message;
        bl.Type = "Email";
          SmtpServer.Credentials = new System.Net.NetworkCredential("cellsalts4health@gmail.com", "S@@nv!@2012");
        SmtpServer.EnableSsl = true;
        SmtpServer.Send(mail);
        return "Success";
    }

    public string send_sms_to_user(string mobile)
    {
        WebClient httpclient = new WebClient();
        httpclient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        httpclient.QueryString.Add("username", "cellsalts");
        httpclient.QueryString.Add("password", "health12");
        httpclient.QueryString.Add("type", "TEXT");
        httpclient.QueryString.Add("sender", "CELSLT");
        httpclient.QueryString.Add("mobile", mobile);
        httpclient.QueryString.Add("message", "We've received your message! we'll contact you shortly");
        bl.Message_to = "We've received your message! we'll contact you shortly";
        bl.Type = "TEXT";
        string baseurl = "https://app.indiasms.com/sendsms/sendsms.php";
        Stream data = httpclient.OpenRead(baseurl);
        StreamReader reader = new StreamReader(data);
        string s = reader.ReadToEnd();
        data.Close();
        reader.Close();
        return (s);
    }

    public string send_sms_to_admin(string name, string email, string mobile, string message)
    {
        WebClient httpclient = new WebClient();
        httpclient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        httpclient.QueryString.Add("username", "cellsalts");
        httpclient.QueryString.Add("password", "health12");
        httpclient.QueryString.Add("type", "TEXT");
        httpclient.QueryString.Add("sender", "CELSLT");
        httpclient.QueryString.Add("mobile", "9986546496");
        httpclient.QueryString.Add("message", "Contact Us:-  Name :" + name + " Email id: " + email + " Mobile No: " + mobile + " Message :" + message);
        bl.Message_to = "Contact Us:- Name :" + name + " Email id: " + email + " Mobile No: " + mobile + " Message :" + message;
        bl.Type = "TEXT";
        string baseurl = "https://app.indiasms.com/sendsms/sendsms.php";
        Stream data = httpclient.OpenRead(baseurl);
        StreamReader reader = new StreamReader(data);
        string s = reader.ReadToEnd();
        data.Close();
        reader.Close();
        return (s);
    }


    public string send_sms_to_admin_2(string name, string email, string mobile, string message)
    {
        WebClient httpclient = new WebClient();
        httpclient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        httpclient.QueryString.Add("username", "cellsalts");
        httpclient.QueryString.Add("password", "health12");
        httpclient.QueryString.Add("type", "TEXT");
        httpclient.QueryString.Add("sender", "CELSLT");
        httpclient.QueryString.Add("mobile", "9588968360");
        httpclient.QueryString.Add("message", "Contact Us:-  Name :" + name + " Email id: " + email + " Mobile No: " + mobile + " Message :" + message);
        bl.Message_to = "Contact Us:- Name :" + name + " Email id: " + email + " Mobile No: " + mobile + " Message :" + message;
        bl.Type = "TEXT";
        string baseurl = "https://app.indiasms.com/sendsms/sendsms.php";
        Stream data = httpclient.OpenRead(baseurl);
        StreamReader reader = new StreamReader(data);
        string s = reader.ReadToEnd();
        data.Close();
        reader.Close();
        return (s);
    }
}