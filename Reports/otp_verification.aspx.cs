using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_otp_verification : System.Web.UI.Page
{
    bl_Usr_Registration bl = new bl_Usr_Registration();
    dl_Usr_Registration dl = new dl_Usr_Registration();
    ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnBool rb = new ReturnClass.ReturnBool();
    Utilities util = new Utilities();
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
    protected void Signup_Click(object sender, EventArgs e)
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
                        if (Session["OTP"] != null)
                        {
                            if (Session["OTP"].ToString() == otp.Text.Trim())
                            {
                                bl.Action_Date = DateTime.Now.ToString("yyyy/MM/dd");
                                bl.Cell_No = Session["Mobile_No"].ToString();
                                bl.ClientIp = util.GetClientIpAddress(this.Page);
                                bl.User_type = Session["User_type"].ToString();
                                if(bl.User_type== "TEA")
                                {
                                    bl.ACK = "N";
                                }
                                else
                                {
                                    bl.ACK = "Y";
                                }
                                rb = dl.Update_user_signup(bl);
                                if (rb.status)
                                {
                                    if (bl.User_type == "TEA")
                                    {
                                        Utilities.MessageBoxShow_Redirect("Your Profile has been registered successfully, Your Login Request is submitted at Hogwarts Institute, We will update you when your profile is approved", "login.aspx");
                                    }
                                    else
                                    {
                                        Utilities.MessageBoxShow_Redirect("Your Profile has been registered successfully, Please login with your registered mobile/email", "login.aspx");
                                    }
                                }
                            }
                            else
                            {
                                Utilities.MessageBoxShow("Wrong OTP, Please Try Again");
                                otp.Text = null;
                            }
                        }
                        else
                        {
                            Utilities.MessageBoxShow_Redirect("Your OTP has expired. Please Re Register again.", "../Logout.aspx");
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
                Utilities.MessageBoxShow_Redirect("Your Session Has Expired Please Login Again", "../Logout.aspx");
            }
        }
    }

    protected void Resend_Click(object sender, EventArgs e)
    {
         
        bl.Cell_No = Session["Mobile_No"].ToString();
        bl.Success = send_sms(Session["OTP"].ToString(), Session["Mobile_No"].ToString());
        rb = dl.sms_log(bl);
        if(rb.status)
        {
            Utilities.MessageBoxShow( "otp resend successfully");
        }
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
        httpclient.QueryString.Add("message", "OTP for cellsalts registration is: " + otp + ". Do not share it with anyone");
        bl.Message = "This is your cell salt registration otp :" + otp;
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
}