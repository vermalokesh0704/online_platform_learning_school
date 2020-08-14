using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage_admin : System.Web.UI.MasterPage
{
    Utilities util = new Utilities();
    protected void Page_Load(object sender, EventArgs e)
    {
        findview();
        Getnewmessage();
        string path = HttpContext.Current.Request.Url.AbsolutePath;
        if (path.Contains("Default"))
        {
            pagename.Value = "Home";
        }
        else if (path.Contains("pending_review"))
        {
            pagename.Value = "review";
        }
        else if (path.Contains("pending_testimonial"))
        {
            pagename.Value = "testimonial";
        }
        else if (path.Contains("pending_login"))
        {
            pagename.Value = "login";
        }
        else if (path.Contains("transction_report"))
        {
            pagename.Value = "transction";
        }
        else if (path.Contains("medicine_order"))
        {
            pagename.Value = "order";
        }


        try
        {
            GetFileUpload();
            if (Session["User_Id"] != null)
            {
                if (Session["Role_ID"] != null)
                {
                    if (Session["Role_ID"].ToString() == "10")
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
                    if (Session["Role_ID"].ToString() == "10")
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
            //bl.Panjiyan_category_id = "pic";
            //dt = dl.Getfileupload(bl);
            //if (dt.table.Rows.Count > 0)
            //{

            //    Image1.Visible = true;
            //    byte[] bytes = (byte[])(dt.table.Rows[0][5]);
            //    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            //    Image1.ImageUrl = "data:image/jpg;base64," + base64String;
            //}
            //else
            //{
                bl.Panjiyan_category_id = "pic";
                dt = dl.Getfileuploadforprofilepic(bl);
                Image1.Visible = true;
                byte[] bytes = (byte[])(dt.table.Rows[0][5]);
                string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                Image1.ImageUrl = "data:image/jpg;base64," + base64String;
         //   }
        }
        catch (NullReferenceException)
        {
            //         Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
        }
    }


    public void Getnewmessage()
    {
        admin_ba_layer bl = new admin_ba_layer();
        admin_da_layer dl = new admin_da_layer();
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

            dt = dl.bind_Review_total();
            if (dt.table.Rows.Count > 0)
            {
                lbl_new_message_review.Text = dt.table.Rows.Count.ToString();
                lbl_new_message_review1.Text = dt.table.Rows.Count.ToString();
            }
            else
            {
                lbl_new_message_review.Text = "0";
                lbl_new_message_review1.Text = "0";
            }

            dt = dl.bind_testimonial_total();
            if (dt.table.Rows.Count > 0)
            {
                lbl_new_message_testimonial.Text = dt.table.Rows.Count.ToString();
                lbl_new_message_testimonial1.Text = dt.table.Rows.Count.ToString();
            }
            else
            {
                lbl_new_message_testimonial.Text = "0";
                lbl_new_message_testimonial1.Text = "0";
            }

            //dt = dl.select_pending_application_for_login_total();
            //if (dt.table.Rows.Count > 0)
            //{
            //    lbl_new_message_login.Text = dt.table.Rows.Count.ToString();
            //    lbl_new_message_login1.Text = dt.table.Rows.Count.ToString();
            //}
            //else
            //{
            //    lbl_new_message_login.Text = "0";
            //    lbl_new_message_login1.Text = "0";
            //}

            //dt = dl.transction_report();
            //if (dt.table.Rows.Count > 0)
            //{
            //    lbl_new_message_transction.Text = dt.table.Rows.Count.ToString();
            //}
            //else
            //{
            //    lbl_new_message_transction.Text = "0";
            //}

            dt = dl.bind_order_medicine();
            if (dt.table.Rows.Count > 0)
            {
              //  lbl_order.Text = dt.table.Rows.Count.ToString();
            }
            else
            {
              //  lbl_order.Text = "0";
            }
        }
        catch (NullReferenceException)
        {
            //         Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
        }
    }
}
