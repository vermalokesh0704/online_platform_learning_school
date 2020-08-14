using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_login : System.Web.UI.Page
{
    bl_Usr_Registration bl = new bl_Usr_Registration();
    dl_Usr_Registration dl = new dl_Usr_Registration();
    ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnBool rb = new ReturnClass.ReturnBool();
    Utilities util = new Utilities();
    string role_id = null;
    int rno;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["useridd"] != null)
                txt_login.Text = Request.Cookies["useridd"].Value;
            if (Request.Cookies["pwd"] != null)
                Password.Attributes.Add("value", Request.Cookies["pwd"].Value);
            if (Request.Cookies["useridd"] != null && Request.Cookies["pwd"] != null)
                ChkContent.Checked = true;
            Session.Add("failed_attempt", "0");
            Random randomclass = new Random();
            Session["rno"] = randomclass.Next();
            rno = Convert.ToInt32(Session["rno"].ToString());
            Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["CheckRefresh"] = Session["CheckRefresh"];
    }
    protected void Login_Click(object sender, EventArgs e)
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
                        if (Session["rno"] == null)
                        {
                            Utilities.MessageBox_UpdatePanel(UpdatePanel2, "Page has expired!!! Please open this page in a new window..");
                        }
                        else
                        {
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
                                    if (!check_user())
                                    {
                                        Utilities.MessageBoxShow("Invaild User Id and Password..");
                                        fn_logintrail(false);
                                    }
                                    else
                                    {
                                        if (ChkContent.Checked == true)
                                        {
                                            Response.Cookies["useridd"].Value = txt_login.Text.Trim();
                                            Response.Cookies["pwd"].Value = Password.Text.Trim();
                                            Response.Cookies["useridd"].Expires = DateTime.Now.AddDays(365);
                                            Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(365);
                                        }
                                        else
                                        {
                                            Response.Cookies["useridd"].Expires = DateTime.Now.AddDays(-1);
                                            Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(-1);
                                        }
                                        fn_logintrail(true);
                                        FormsAuthentication.Initialize();
                                        String strRole = role_id;
                                        FormsAuthenticationTicket tkt = new FormsAuthenticationTicket(1, txt_login.Text, DateTime.Now, DateTime.Now.AddMinutes(30), false, strRole, FormsAuthentication.FormsCookiePath);
                                        Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(tkt)));
                                        if (Session["Default_page"] != null)
                                        {
                                            string str = Session["Default_page"].ToString();
                                            string newstr = str.Replace(".aspx", "");
                                            // Response.Redirect(Session["Default_page"].ToString(), false);
                                            Response.Redirect(newstr, false);
                                        }
                                        else
                                        {
                                            //  Response.Redirect("User/DashBoard.aspx", false);
                                        }
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
                    }
                    else
                        Utilities.MessageBox_UpdatePanel(UpdatePanel2, "Page Refresh or Back button is now allowed");
                }
                else
                    Utilities.MessageBox_UpdatePanel(UpdatePanel2, "Page expired!!! Please re open this page in new window.");
            }
            catch (NullReferenceException)
            {
                //  Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
                Response.Redirect("login.aspx");
            }
        }
    }


    public bool check_user()
    {
        bool fg = false;
        bl.Login_Id = txt_login.Text.Trim();
        bl.Password_Plain = Password.Text.Trim();
        bl.Password = bl.Password_Plain;
        bl.Seed = Session["rno"].ToString();
        bl.Verified = "Y";
        bl.Seed = Session["rno"].ToString();
        dt = dl.user_login(bl);
        if (dt.table.Rows.Count > 0)
        {
            bl.User_Id = dt.table.Rows[0]["applicant_mobile"].ToString();
            Session["User_Id"] = dt.table.Rows[0]["applicant_mobile"].ToString();
            Session["Email_ID"] = dt.table.Rows[0]["applicant_email"].ToString();
            Session["Role_ID"] = dt.table.Rows[0]["role_id"].ToString();
            Session["name"] = dt.table.Rows[0]["applicant_first_name"].ToString() + " " + dt.table.Rows[0]["applicant_last_name"].ToString();
            Session["display_name"] = dt.table.Rows[0]["applicant_first_name"].ToString();
            Session["applicant_first_name"] = dt.table.Rows[0]["applicant_first_name"].ToString();
            Session["applicant_last_name"] = dt.table.Rows[0]["applicant_last_name"].ToString();
            Session["extra_3"] = dt.table.Rows[0]["extra_3"].ToString();
            Session["class"] = dt.table.Rows[0]["class"].ToString();
            Session["stream"] = dt.table.Rows[0]["stream"].ToString();

            bl.Role_Id = dt.table.Rows[0]["role_id"].ToString();
            dt = dl.select_default_page(bl);
            if (dt.table.Rows.Count > 0)
            {
                Session["Default_page"] = dt.table.Rows[0]["Default_page"].ToString();
                Response.Cookies["Default_page"].Value = Session["Default_page"].ToString();
                Response.Cookies["Default_page"].Expires = DateTime.Now.AddDays(365);
            }
            dt = dl.select_last_login(bl);
            if (dt.table.Rows.Count > 0)
            {
                Session["last_login"] = dt.table.Rows[0]["login_time"].ToString();
                Session["login_time_new"] = dt.table.Rows[0]["login_time"].ToString();
                Response.Cookies["login_time_new"].Value = dt.table.Rows[0]["login_time"].ToString();
            }
            else
            {
                Session["last_login"] = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt");
                Session["login_time_new"] = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt");
                Response.Cookies["login_time_new"].Value = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss tt");
            }

            Response.Cookies["class"].Value = Session["class"].ToString();
            Response.Cookies["class"].Expires = DateTime.Now.AddDays(365);
            Response.Cookies["stream"].Value = Session["stream"].ToString();
            Response.Cookies["stream"].Expires = DateTime.Now.AddDays(365);
            Response.Cookies["extra_3"].Value = Session["extra_3"].ToString();
            Response.Cookies["extra_3"].Expires = DateTime.Now.AddDays(365);
            Response.Cookies["User_Id"].Value = Session["User_Id"].ToString();
            Response.Cookies["User_Id"].Expires = DateTime.Now.AddDays(365);
            Response.Cookies["Email_ID"].Value = Session["Email_ID"].ToString();
            Response.Cookies["Email_ID"].Expires = DateTime.Now.AddDays(365);
            Response.Cookies["Role_ID"].Value = Session["Role_ID"].ToString();
            Response.Cookies["Role_ID"].Expires = DateTime.Now.AddDays(365);
            Response.Cookies["name"].Value = Session["name"].ToString();
            Response.Cookies["name"].Expires = DateTime.Now.AddDays(365);
            Response.Cookies["display_name"].Value = Session["display_name"].ToString();
            Response.Cookies["display_name"].Expires = DateTime.Now.AddDays(365);
            Response.Cookies["last_login"].Value = Session["last_login"].ToString();
            Response.Cookies["last_login"].Expires = DateTime.Now.AddDays(365);
            Response.Cookies["applicant_first_name"].Value = Session["applicant_first_name"].ToString();
            Response.Cookies["applicant_first_name"].Expires = DateTime.Now.AddDays(365);
            Response.Cookies["applicant_last_name"].Value = Session["applicant_last_name"].ToString();
            Response.Cookies["applicant_last_name"].Expires = DateTime.Now.AddDays(365);

            fg = true;
        }
        //else
        //{
        //    Utilities.MessageBoxShow("Invalid User id or Password.");
        //}
        return fg;
    }

    public void fn_logintrail(bool flag)
    {
        LoginTrail lt1 = new LoginTrail();
        HttpBrowserCapabilities browser = Request.Browser;
        OperatingSystem os = Environment.OSVersion;
        lt1.User_Id = txt_login.Text.Trim();
        lt1.Client_Ip = util.GetClientIpAddress(this.Page);
        lt1.UserAgent = Request.UserAgent;
        if (lt1.UserAgent.Contains("Edge"))
            lt1.Client_Browser = "Microsoft Edge " + browser.Version;
        else
            lt1.Client_Browser = browser.Type;
        lt1.Client_Os = os.VersionString;


        rb = dl.LoginTrail_new(lt1);
    }

    protected void lnk_password_Click(object sender, EventArgs e)
    {
        Response.Redirect("Forget_Login_Password.aspx");
    }
}