using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_Forget_Login_Password : System.Web.UI.Page
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

        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["CheckRefresh"] = Session["CheckRefresh"];
    }
    protected void forgot_Click(object sender, EventArgs e)
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

                        bool cptch_expired = false;
                        try
                        {
                            Captcha1.ValidateCaptcha(txt_captcha.Text.Trim());
                        }
                        catch { cptch_expired = true; }
                        txt_captcha.Text = "";

                        if (!cptch_expired)
                        {
                            if (Captcha1.UserValidated)
                            {
                                Captcha1.DataBind();
                                bl.Cell_No = txt_login.Text.Trim();
                                bl.Verified = "Y";
                                dt = dl.user_login_details_for_forgot_password(bl);
                                if (dt.table.Rows.Count > 0)
                                {
                                    Session["Mobile_No"] = bl.Cell_No;
                                    Session["Reset_Method"] = "Y";
                                    Random randomclass = new Random();
                                    Int32 rno1 = randomclass.Next(1000000, 9999999);
                                    string random = Convert.ToString(rno1);
                                    string rno = random.ToString();
                                    bl.Success = send_sms(rno, bl.Cell_No);
                                    rb = dl.sms_log(bl);
                                    
                                    Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "OTP has been sent to Your Mobile Number", "OtpVerification_Reg.aspx");
                                }
                                else
                                {
                                    Utilities.MessageBox_UpdatePanel(UpdatePanel2, "Please check your mobile number.");
                                }
                            }
                            else
                            {
                                Utilities.MessageBox_UpdatePanel(UpdatePanel2, "Invalid Captcha!!! Please enter same characters as you see in image.");
                            }
                        }
                        else
                        {
                            Utilities.MessageBox_UpdatePanel(UpdatePanel2, "Captcha Expired!!! Please re open this page in new window.");
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
                Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
            }
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
        httpclient.QueryString.Add("message", "OTP for cellsalts forgot password is: " + otp + ". Do not share it with anyone");
        bl.Message = "OTP for cellsalts forgot password is: " + otp + ". Do not share it with anyone";
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