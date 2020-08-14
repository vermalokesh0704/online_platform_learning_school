using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPageonline_user_review : System.Web.UI.MasterPage
{
    Utilities util = new Utilities();
    protected void Page_Load(object sender, EventArgs e)
    {
        findview();
        string path = HttpContext.Current.Request.Url.AbsolutePath;
        if (path.Contains("User_Dashboard"))
        {
            pagename.Value = "Home";
        }
        else if (path.Contains("cell_salt"))
        {
            pagename.Value = "Cell";
        }
        else if (path.Contains("BioCombinations"))
        {
            pagename.Value = "Cell";
        }
        else if (path.Contains("birthchart"))
        {
            pagename.Value = "know_my_cell_salts";
        }
        else if (path.Contains("FACIAL_ANALYSIS"))
        {
            pagename.Value = "know_my_cell_salts";
        }
        else if (path.Contains("know_my_cell_salts_deficiencies"))
        {
            pagename.Value = "know_my_cell_salts";
        }
        else if (path.Contains("cellsalts4pets"))
        {
            pagename.Value = "Cell";
        }
        else if (path.Contains("cellsalts4sports"))
        {
            pagename.Value = "Cell";
        }
        else if (path.Contains("Dosage"))
        {
            pagename.Value = "Cell";
            HiddenField1.Value = "Dosage";
        }
        else if (path.Contains("Potency"))
        {
            pagename.Value = "Cell";
            HiddenField1.Value = "Potency";
        }
        else if (path.Contains("Dos_Donts"))
        {
            pagename.Value = "Cell";
        }
        else if (path.Contains("ailments"))
        {
            pagename.Value = "ailments";
        }
        else if (path.Contains("know_my_cell_salts"))
        {
            pagename.Value = "know_my_cell_salts";
        }
        else if (path.Contains("refer_friend"))
        {
            pagename.Value = "refer_friend";
        }
        else if (path.Contains("usefullvideos"))
        {
            pagename.Value = "Cell";
            HiddenField1.Value = "usefullvideos";
        }
        else if (path.Contains("Consult_online"))
        {
            pagename.Value = "Consult_online";
        }
        else if (path.Contains("FAQ"))
        {
            pagename.Value = "FAQ";
        }
        else if (path.Contains("meditation4health"))
        {
            pagename.Value = "meditation4health";
        }
        else if (path.Contains("Angelcardreading"))
        {
            pagename.Value = "meditation4health";
        }
        else if (path.Contains("Tarotcardreading"))
        {
            pagename.Value = "meditation4health";
        }
        try
        {
            Getnewmessage_new();
            GetFileUpload();
            if (Session["User_Id"] != null)
            {
                if (Session["Role_ID"] != null)
                {
                    if (Session["Role_ID"].ToString() == "01")
                    {
                        if (Session["display_name"] != null)
                        {
                            user_name.Value = "Hi " + Session["display_name"].ToString();
                        }
                        else
                        {
                            if (Request.Cookies["display_name"] != null)
                            {
                                user_name.Value = "Hi " + Request.Cookies["display_name"].Value;
                                Session["display_name"] = Request.Cookies["display_name"].Value;
                            }
                        }
                        if (Session["last_login"] != null)
                        {
                            last_login.Value = "Last Login: " + Session["last_login"].ToString();
                        }
                        else
                        {
                            if (Request.Cookies["last_login"] != null)
                            {
                                last_login.Value = "Last Login: " + Request.Cookies["last_login"].Value;
                                Session["last_login"] = Request.Cookies["last_login"].Value;
                            }
                        }
                        ipaddress.Value = "IP Address: " + util.GetClientIpAddress(this.Page);
                    }
                    else
                    {
                        if (Request.Cookies["Role_ID"] != null)
                        {
                            Session["Role_ID"] = Request.Cookies["Role_ID"].Value;
                            //user_name.Value = "Hi " + Session["display_name"].ToString();
                            //last_login.Value = "Last Login: " + Session["last_login"].ToString();
                            ipaddress.Value = "IP Address: " + util.GetClientIpAddress(this.Page);
                            if (Session["display_name"] != null)
                            {
                                user_name.Value = "Hi " + Session["display_name"].ToString();
                            }
                            else
                            {
                                if (Request.Cookies["display_name"] != null)
                                {
                                    user_name.Value = "Hi " + Request.Cookies["display_name"].Value;
                                    Session["display_name"] = Request.Cookies["display_name"].Value;
                                }
                            }
                            if (Session["last_login"] != null)
                            {
                                last_login.Value = "Last Login: " + Session["last_login"].ToString();
                            }
                            else
                            {
                                if (Request.Cookies["last_login"] != null)
                                {
                                    last_login.Value = "Last Login: " + Request.Cookies["last_login"].Value;
                                    Session["last_login"] = Request.Cookies["last_login"].Value;
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("../Logout.aspx");
                        }
                    }
                }
                else
                {

                    if (Request.Cookies["Role_ID"] != null)
                    {
                        Session["Role_ID"] = Request.Cookies["Role_ID"].Value;
                        //user_name.Value = "Hi " + Session["display_name"].ToString();
                        //last_login.Value = "Last Login: " + Session["last_login"].ToString();
                        ipaddress.Value = "IP Address: " + util.GetClientIpAddress(this.Page);
                        if (Session["display_name"] != null)
                        {
                            user_name.Value = "Hi " + Session["display_name"].ToString();
                        }
                        else
                        {
                            if (Request.Cookies["display_name"] != null)
                            {
                                user_name.Value = "Hi " + Request.Cookies["display_name"].Value;
                                Session["display_name"] = Request.Cookies["display_name"].Value;
                            }
                        }
                        if (Session["last_login"] != null)
                        {
                            last_login.Value = "Last Login: " + Session["last_login"].ToString();
                        }
                        else
                        {
                            if (Request.Cookies["last_login"] != null)
                            {
                                last_login.Value = "Last Login: " + Request.Cookies["last_login"].Value;
                                Session["last_login"] = Request.Cookies["last_login"].Value;
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("../Logout.aspx");
                    }
                }
            }
            else
            {
                if (Request.Cookies["User_Id"] != null)
                {
                    Session["User_Id"] = Request.Cookies["User_Id"].Value;
                    if (Session["Role_ID"].ToString() == "01")
                    {
                        if (Session["display_name"] != null)
                        {
                            user_name.Value = "Hi " + Session["display_name"].ToString();
                        }
                        else
                        {
                            if (Request.Cookies["display_name"] != null)
                            {
                                user_name.Value = "Hi " + Request.Cookies["display_name"].Value;
                                Session["display_name"] = Request.Cookies["display_name"].Value;
                            }
                        }
                        if (Session["last_login"] != null)
                        {
                            last_login.Value = "Last Login: " + Session["last_login"].ToString();
                        }
                        else
                        {
                            if (Request.Cookies["last_login"] != null)
                            {
                                last_login.Value = "Last Login: " + Request.Cookies["last_login"].Value;
                                Session["last_login"] = Request.Cookies["last_login"].Value;
                            }
                        }
                        //user_name.Value = "Hi " + Session["display_name"].ToString();
                        //last_login.Value = "Last Login: " + Session["last_login"].ToString();
                        ipaddress.Value = "IP Address: " + util.GetClientIpAddress(this.Page);
                    }
                    else
                    {
                        if (Request.Cookies["Role_ID"] != null)
                        {
                            Session["Role_ID"] = Request.Cookies["Role_ID"].Value;
                            if (Session["display_name"] != null)
                            {
                                user_name.Value = "Hi " + Session["display_name"].ToString();
                            }
                            else
                            {
                                if (Request.Cookies["display_name"] != null)
                                {
                                    user_name.Value = "Hi " + Request.Cookies["display_name"].Value;
                                    Session["display_name"] = Request.Cookies["display_name"].Value;
                                }
                            }
                            if (Session["last_login"] != null)
                            {
                                last_login.Value = "Last Login: " + Session["last_login"].ToString();
                            }
                            else
                            {
                                if (Request.Cookies["last_login"] != null)
                                {
                                    last_login.Value = "Last Login: " + Request.Cookies["last_login"].Value;
                                    Session["last_login"] = Request.Cookies["last_login"].Value;
                                }
                            }
                            //user_name.Value = "Hi " + Session["display_name"].ToString();
                            //last_login.Value = "Last Login: " + Session["last_login"].ToString();
                            ipaddress.Value = "IP Address: " + util.GetClientIpAddress(this.Page);
                        }
                        else
                        {
                            Response.Redirect("../Logout.aspx");
                        }
                    }
                }
                else
                {
                    Response.Redirect("../Logout.aspx");
                }
            }
        }
        catch { /*Response.Redirect("../Logout.aspx");*/ }
    }

    public void findview()
    {
        ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
        olu_da_layer dl = new olu_da_layer();
        dt = dl.select_visit_counter();
        if (dt.table.Rows.Count > 0)
        {
            divMyID.Attributes["data-to"] = dt.table.Rows[0]["visit_counter"].ToString();
        }
    }
    public void Getnewmessage()
    {
        olu_ba_layer bl = new olu_ba_layer();
        olu_da_layer dl = new olu_da_layer();
        ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
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
            if (Session["login_time_new"] != null)
            {
                bl.Logintimeformessage = Session["login_time_new"].ToString();
            }
            else
            {
                if (Request.Cookies["login_time_new"] != null)
                {
                    Session["login_time_new"] = Request.Cookies["login_time_new"].Value;
                    bl.Logintimeformessage = Request.Cookies["login_time_new"].Value;
                }
                else
                {

                }
            }

            dt = dl.newmessage_update(bl);
            if (dt.table.Rows.Count > 0)
            {
               // lbl_new_message.Text = dt.table.Rows.Count.ToString();
                Session["userlbl_new_message"] = dt.table.Rows.Count.ToString();
                Response.Cookies["userlbl_new_message"].Value = dt.table.Rows.Count.ToString();
                Response.Cookies["userlbl_new_message"].Expires = DateTime.Now.AddDays(365);
              //  newbadge.Visible = true;
            }
            else
            {
                if (Session["userlbl_new_message"] == null)
                {
                //    newbadge.Visible = false;
                }
                else
                {
                    int i = Convert.ToInt32(Session["userlbl_new_message"].ToString());
                    int f = i;
                    Session["userlbl_new_message"] = f.ToString();
                    Response.Cookies["userlbl_new_message"].Value = f.ToString();
                    Response.Cookies["userlbl_new_message"].Expires = DateTime.Now.AddDays(365);
                    if (f > 0)
                    {
                       // lbl_new_message.Text = f.ToString();
                    }
                    else
                    {
                     //   newbadge.Visible = false;
                    }
                }

            }
        }
        catch (NullReferenceException)
        {
            //         Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
        }
    }
    public void GetFileUpload()
    {
        olu_ba_layer bl = new olu_ba_layer();
        olu_da_layer dl = new olu_da_layer();
        ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
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
            bl.Panjiyan_category_id = "pic";
            dt = dl.Getfileupload(bl);
            if (dt.table.Rows.Count > 0)
            {

                Image1.Visible = true;
                byte[] bytes = (byte[])(dt.table.Rows[0][5]);
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                Image1.ImageUrl = "data:image/jpg;base64," + base64String;
            }
            else
            {
                bl.Panjiyan_category_id = "pic";
                dt = dl.Getfileuploadforprofilepic(bl);
                Image1.Visible = true;
                byte[] bytes = (byte[])(dt.table.Rows[0][5]);
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                Image1.ImageUrl = "data:image/jpg;base64," + base64String;
            }
        }
        catch (NullReferenceException)
        {
            //         Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
        }
    }
    public void Getnewmessage_new()
    {
        olu_ba_layer bl = new olu_ba_layer();
        olu_da_layer dl = new olu_da_layer();
        ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
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

            dt = dl.newmessage_update_new(bl);
            if (dt.table.Rows.Count > 0 && dt.table.Rows[0]["newmessage"].ToString() != "0")
            {
              //  lbl_new_message.Text = dt.table.Rows[0]["newmessage"].ToString();
            //    newbadge.Visible = true;
            }
            else
            {
               // newbadge.Visible = false;
            }
        }
        catch (NullReferenceException)
        {
            //         Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
        }
    }
}
