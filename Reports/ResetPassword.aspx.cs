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

public partial class Reports_ResetPassword : System.Web.UI.Page
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
    protected void reset_Click(object sender, EventArgs e)
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
                        bl.Password_Plain = Password.Text.Trim();
                        bl.Password = bl.Password_Plain;
                        bl.Action_Date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        bl.ClientIp = util.GetClientIpAddress(this.Page);
                        bl.User_Id = Session["Mobile_No"].ToString();
                        bl.Verified = "Y";
                        rb = dl.update_password(bl);
                        if (rb.status == true)
                        {
                            Utilities.MessageBoxShow_Redirect("Your password changed successfully. Please login using your New Password.", "login.aspx");
                        }
                        else
                        {
                            Utilities.MessageBoxShow_Redirect("Your password has not been changed...", "ResetPassword.aspx");
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
        else
            Utilities.MessageBoxShow("( *  ) Indicates  Mandatory Fields, Please Fill");
    }
}