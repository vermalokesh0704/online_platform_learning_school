using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Control_refer_friend : System.Web.UI.UserControl
{
    string key = ConfigurationManager.AppSettings["enc_qrystring_key"].ToString();
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
            bind_list();
        }
    }

    public void bind_list()
    {
        if (Session["User_Id"] != null)
        {
            bl.User_id = Session["User_Id"].ToString();
        }
        else
        {
            if (Request.Cookies["User_Id"] != null)
            {
                bl.User_id = Request.Cookies["User_Id"].Value;
                Session["User_Id"] = Request.Cookies["User_Id"].Value;
            }
        }
        dt = dl.bind_refer_list(bl.User_id);
        Gridview1.DataSource= dt.table;
        Gridview1.DataBind();

    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["CheckRefresh"] = Session["CheckRefresh"];
    }
    protected void refer_friend_Click(object sender, EventArgs e)
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
                        bl.Date_time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        bl.Client_id = util.GetClientIpAddress(this.Page);
                        if (Session["User_Id"] != null)
                        {
                            bl.User_id = Session["User_Id"].ToString();
                        }
                        else
                        {
                            if (Request.Cookies["User_Id"] != null)
                            {
                                bl.User_id = Request.Cookies["User_Id"].Value;
                                Session["User_Id"] = Request.Cookies["User_Id"].Value;
                            }
                        }
                        if (Session["name"] != null)
                        {
                        }
                        else
                        {
                            if (Request.Cookies["name"] != null)
                            {
                                Session["name"] = Request.Cookies["name"].Value;
                            }
                        }
                        if (bl.Mobile != bl.User_id)
                        {
                            rb = dl.Insert_refer_friend_details(bl);
                            if (rb.status)
                            {
                                //Thread Stamp_Action = new Thread(delegate ()
                                //{
                                //    bl.Success = send_sms_to_user(bl.Mobile, bl.First_name);
                                //    rb = dl.sms_log(bl);
                                //    bl.Type = null;
                                //    if (bl.Email_id != "" && bl.Email_id != null)
                                //    {
                                //        //bl.Success = email_to_user(bl.First_name, bl.Email_id, bl.Mobile);
                                //        bl.Success = email_to_user_new(bl.First_name, bl.Email_id, bl.Mobile);
                                //        rb = dl.sms_log(bl);
                                //    }
                                //});
                                //Stamp_Action.IsBackground = true;
                                //Stamp_Action.Start();
                                txt_first_name.Text = null;
                                mobile_no.Text = null;
                                email_id.Text = null;
                                Utilities.MessageBoxShow_Redirect("Your Referal Link Has Been Sent Successfully", Request.Url.AbsoluteUri);
                            }
                            else
                            {
                                Utilities.MessageBoxShow("Page expired!!! Please re open this page in new window.");
                            }
                        }
                        else
                        {
                            Utilities.MessageBoxShow("You Cannot Use Your Own Mobile Number");
                        }

                    }
                    else
                        Utilities.MessageBoxShow("Page Refresh or Back button is now allowed");
                }
                else
                    Utilities.MessageBoxShow("Page expired!!! Please re open this page in new window.");
            }
            catch (NullReferenceException)
            {
                //  Utilities.MessageBoxShow_Redirect("Your Session Has Expired Please Login Again", "../Logout.aspx");
                Utilities.MessageBoxShow("Page expired!!! Please re open this page in new window.");
            }
        }
    }


    public string email_to_user_new(string name, string email, string mobile)
    {
        string uid = util.Encrypt_AES(Session["User_Id"].ToString(), key);
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("webmail.cellsalts4health.com");
            mail.From = new MailAddress("contact@cellsalts4health.com");
            mail.To.Add(email);
            mail.Subject = "Referal Link for cellsalts4health.com";
            mail.Body = "Hi " + name + ", Your Friend " + Session["name"].ToString() + " wants you to join cellsalts4health.com, here is the signup link https://cellsalts4health.com/Reports/signup.aspx?reco=" + Server.UrlEncode(uid) ;
            SmtpServer.Port = 587;
            MailAddress bcc = new MailAddress("snehamca2006@gmail.com");
            mail.Bcc.Add(bcc);
            bl.Message_to = "Hi " + name + ", Your Friend " + Session["name"].ToString() + " wants you to join cellsalts4health.com, here is the signup link https://cellsalts4health.com/Reports/signup.aspx?reco=" + Server.UrlEncode(uid);
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
    public string email_to_user(string name, string email, string mobile)
    {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        mail.From = new MailAddress("cellsalts4health@gmail.com");
        mail.To.Add(email);
        mail.Subject = "Referal Link for cellsalts4health.com";
        mail.Body = "Hi " + name + ", Your Friend " + Session["name"].ToString() + " wants you to join cellsalts4health.com, here is the signup link https://cellsalts4health.com/Reports/signup.aspx?reco=" + Session["User_Id"].ToString();
        SmtpServer.Port = 587;
        bl.Message_to = "Hi " + name + ", Your Friend " + Session["name"].ToString() + " wants you to join cellsalts4health.com, here is the signup link https://cellsalts4health.com/Reports/signup.aspx?reco=" + Session["User_Id"].ToString();
        bl.Type = "Email";
        MailAddress bcc = new MailAddress("snehamca2006@gmail.com");
        mail.Bcc.Add(bcc);
        SmtpServer.Credentials = new System.Net.NetworkCredential("cellsalts4health@gmail.com", "S@@nv!@2012");
        SmtpServer.EnableSsl = true;
        SmtpServer.Send(mail);
        return "Success";
    }
    public string send_sms_to_user(string mobile, string name)
    {
        string uid = util.Encrypt_AES(Session["User_Id"].ToString(), key);
        WebClient httpclient = new WebClient();
        httpclient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        httpclient.QueryString.Add("username", "cellsalts");
        httpclient.QueryString.Add("password", "health12");
        httpclient.QueryString.Add("type", "TEXT");
        httpclient.QueryString.Add("sender", "CELSLT");
        httpclient.QueryString.Add("mobile", mobile);
        httpclient.QueryString.Add("message", "Hi " + name + ", Your Friend " + Session["name"].ToString() + " wants you to join cellsalts4health.com, here is the signup link https://cellsalts4health.com/Reports/signup.aspx?reco=" + Server.UrlEncode(uid));
        bl.Message_to = "Hi " + name + ", Your Friend " + Session["name"].ToString() + " wants you to join cellsalts4health.com, here is the signup link https://cellsalts4health.com/Reports/signup.aspx?reco=" + Server.UrlEncode(uid);
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