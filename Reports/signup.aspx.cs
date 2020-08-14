using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Threading;
using System.Configuration;
using System.Collections.Specialized;

public partial class Reports_signup : System.Web.UI.Page
{
    
    string key = ConfigurationManager.AppSettings["enc_qrystring_key"].ToString();
    bl_Usr_Registration bl = new bl_Usr_Registration();
    dl_Usr_Registration dl = new dl_Usr_Registration();
    ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnDataTable dtt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnBool rb = new ReturnClass.ReturnBool();
    Utilities util = new Utilities();
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!IsPostBack)
        {
            Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
            //  bind_country();
            bind_class();
            bind_stream();
        }
    }

    public void bind_stream()
    {
        try
        {
            dtt = dl.select_stream();
            ddl_stream.Items.Clear();
            ddl_stream.DataSource = dtt.table;
            ddl_stream.DataTextField = "name";
            ddl_stream.DataValueField = "id";
            ddl_stream.DataBind();
            ddl_stream.Items.Insert(0, new ListItem("Select Stream", "0"));
        }
        catch (NullReferenceException)
        {
            //   Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
        }
    }
    public void bind_class()
    {
        try
        {
            dtt = dl.select_class();
            ddl_class.Items.Clear();
            ddl_class.DataSource = dtt.table;
            ddl_class.DataTextField = "id";
            ddl_class.DataValueField = "id";
            ddl_class.DataBind();
            ddl_class.Items.Insert(0, new ListItem("Select Class", "0"));
        }
        catch (NullReferenceException)
        {
            //   Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
        }
    }
    //public void bind_country()
    //{
    //    try
    //    {
    //        dt = dl.bind_country_code();
    //        ddl_code.Items.Clear();
    //        ddl_code.DataSource = dt.table;
    //        ddl_code.DataTextField = "name";
    //        ddl_code.DataValueField = "phonecode";
    //        ddl_code.DataBind();
    //        ddl_code.Items.Insert(0, new ListItem("Select", "0"));
    //    }
    //    catch (NullReferenceException)
    //    {
    //        //   Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
    //    }
    //}
    protected void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["CheckRefresh"] = Session["CheckRefresh"];
    }
    protected void Signup_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {

            try
            {
                if (ChkContent.Checked)
                {
                    if (Session["CheckRefresh"] != null)
                    {
                        if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                        {
                            Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                            Captcha1.ValidateCaptcha(txt_captcha.Text.Trim());
                            txt_captcha.Text = "";
                            if (Captcha1.UserValidated)
                            {
                                Captcha1.DataBind();
                                bl.Name = txt_first_Name.Text.Trim();
                            bl.Last_name = txt_last_Name.Text.Trim();
                            bl.Cell_No = Mobile.Text.Trim();
                            bl.Email = Email.Text.Trim();
                            bl.Password_Plain = Password.Text.Trim();
                            bl.Password = bl.Password_Plain;
                            bl.Applicant_active = "N";
                            bl.Applicant_mobile_verified = "N";
                            bl.Applicant_email_verified = "N";
                            bl.Action_Date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                            bl.ClientIp = util.GetClientIpAddress(this.Page);
                            bl.User_type = user_type.SelectedValue;
                                //   bl.Country_code = ddl_code.SelectedValue;
                                bl.Classes = ddl_class.SelectedValue;
                                bl.Stream = ddl_stream.SelectedValue;
                            bl.Country_code = "91";
                            if (bl.User_type == "USER")
                            {
                                bl.Role_Id = "01";
                            }
                            else if (bl.User_type == "TEA")
                            {
                                bl.Role_Id = "02";
                            }
                            //if (Request.QueryString["reco"] != null)
                            //{
                            //    string uid = util.Encrypt_AES(Request.QueryString["reco"].ToString(), key);
                            //    //   bl.Refer_code = Request.QueryString["reco"].ToString();
                            //    bl.Refer_code = uid;
                            //}
                            //else
                            //{
                                bl.Refer_code = DBNull.Value.ToString();
                            //}
                            Session["User_type"] = bl.User_type;
                            rb = dl.Insert_user_signup(bl);
                            if (rb.status)
                            {
                                Session["Mobile_No"] = bl.Cell_No;
                                Random randomclass = new Random();
                                Int32 rno1 = randomclass.Next(1000000, 9999999);
                                string random = Convert.ToString(rno1);
                                string rno = random.ToString();
                                    Session["OTP"] = rno;
                                    //Thread Stamp_Action = new Thread(delegate ()
                                    //{
                                    //    bl.Success = send_sms(rno, bl.Cell_No);
                                    //    rb = dl.sms_log(bl);
                                    //    bl.Type = null;
                                    //    bl.Success = email_to_user(rno, bl.Email);
                                    //    rb = dl.sms_log(bl);
                                    //});
                                    //Stamp_Action.IsBackground = true;
                                    //Stamp_Action.Start();

                                    Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Please verify your number with otp to complete the registration process "+ rno, "otp_verification.aspx");

                            }
                            else
                            {
                                Utilities.MessageBox_UpdatePanel(UpdatePanel2, "Records could not be saved: Please Try Again");

                            }
                            }
                            else
                            {
                                Utilities.MessageBox_UpdatePanel(UpdatePanel2, "Invalid Captcha!!! Please enter same characters as you see in image.");
                            }
                        }
                        else
                            Utilities.MessageBox_UpdatePanel(UpdatePanel2, "Page Refresh or Back button is now allowed");
                    }
                    else
                        Utilities.MessageBox_UpdatePanel(UpdatePanel2, "Page expired!!! Please re open this page in new window.");
                }
                else
                    Utilities.MessageBox_UpdatePanel(UpdatePanel2, "Please check I agree to terms ");
            }
            catch (NullReferenceException)
            {
                Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
            }
        }
        //else
        //{
        //    //   Utilities.MessageBox_UpdatePanel(UpdatePanel2, "( *  ) Indicates  Mandatory Fields, Please Fill");
        //}


    }
    public string email_to_user(string otp, string email)
    {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("webmail.cellsalts4health.com");
        mail.From = new MailAddress("contact@cellsalts4health.com");
        mail.To.Add(email);
        mail.Subject = "OTP for cellsalts registration";
        mail.Body = "OTP for cellsalts registration is: " + otp + ".Do not share it with anyone.";
        SmtpServer.Port = 587;
        bl.Message_to = "OTP for cellsalts registration is: " + otp + ".Do not share it with anyone.";
        bl.Type = "Email";
        mail.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
        SmtpServer.Credentials = new System.Net.NetworkCredential("contact@cellsalts4health.com", "uxvN5$63");
      //  SmtpServer.EnableSsl = true;
        SmtpServer.Send(mail);
         return "Success";
    }
    public string send_sms(string otp, string mobile_no)
    {
        WebClient httpclient = new WebClient();
        httpclient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        httpclient.QueryString.Add("username", "cellsalts");
        httpclient.QueryString.Add("password", "health12");
        httpclient.QueryString.Add("type", "TEXT");
        httpclient.QueryString.Add("sender", "CELSLT");
        httpclient.QueryString.Add("mobile", mobile_no);
        httpclient.QueryString.Add("message", "OTP for cellsalts registration is: " + otp + ". Do not share it with anyone.");
        bl.Message = "OTP for cellsalts registration is: " + otp + ". Do not share it with anyone.";
        bl.Type = "TEXT";
        Session["OTP"] = otp;
        string baseurl = "https://app.indiasms.com/sendsms/sendsms.php";
        Stream data = httpclient.OpenRead(baseurl);
        StreamReader reader = new StreamReader(data);
        string s = reader.ReadToEnd();
        data.Close();
        reader.Close();
        return (s);
    }

  
    [WebMethod]
    public static string Check_user_mobile(string mobile)
    {
        string retval = "";
        ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
        dl_Usr_Registration db = new dl_Usr_Registration();
        bl_Usr_Registration ur = new bl_Usr_Registration();
        ur.Telephone_No = mobile;
        dt = db.check_user_mobile(ur);
        if (dt.table.Rows.Count > 0)
        {
            retval = "false";
        }
        else
        {
            retval = "true";
        }
        return retval;
    }


    [WebMethod]
    public static string Check_user_email(string email)
    {
        string retval = "";
        ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
        dl_Usr_Registration db = new dl_Usr_Registration();
        bl_Usr_Registration ur = new bl_Usr_Registration();
        ur.Email = email;
        dt = db.check_user_email(ur);
        if (dt.table.Rows.Count > 0)
        {
            retval = "false";
        }
        else
        {
            retval = "true";
        }
        return retval;
    }

    //protected void ddl_code_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddl_code.SelectedValue != "91")
    //    {
    //        RegularExpressionValidator1.Enabled = false;
    //        RegularExpressionValidator1.IsValid = false;
    //        RegularExpressionValidator1.ValidationGroup = "xxx";
    //        Mobile.Text = "";
    //    }
    //    else
    //    {
    //        RegularExpressionValidator1.Enabled = true;
    //        RegularExpressionValidator1.IsValid = true;
    //        RegularExpressionValidator1.ValidationGroup = "a";
    //        Mobile.Text = "";
    //    }
    //}

    protected void ddl_class_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddl_class.SelectedValue=="9" || ddl_class.SelectedValue == "10")
        {
            ddl_stream.SelectedValue = "ALL";
            ddl_stream.Enabled = false;
            RequiredFieldValidator3.IsValid = false;
            RequiredFieldValidator3.Enabled = false;
            RequiredFieldValidator3.ValidationGroup = "abc";

        }
        else
        {
            ddl_stream.SelectedValue = "0";
            ddl_stream.Items[5].Attributes["disabled"] = "disabled";
            ddl_stream.Enabled = true;
            RequiredFieldValidator3.IsValid = true;
            RequiredFieldValidator3.Enabled = true;
            RequiredFieldValidator3.ValidationGroup = "a";
        }
    }
}