using AjaxControlToolkit;
using System;
using System.Collections.Generic;
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

public partial class Control_website_review : System.Web.UI.UserControl
{
    ReturnClass.ReturnBool rb = new ReturnClass.ReturnBool();
    ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnDataTable dtt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnDataTable dtnew = new ReturnClass.ReturnDataTable();
    olu_ba_layer bl = new olu_ba_layer();
    olu_da_layer dl = new olu_da_layer();
    Utilities util = new Utilities();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
            Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
            bind_rating();
          
        }
    }

    public void bind_rating()
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
        dt = dl.select_Insert_user_rating(bl);
        if (dt.table.Rows.Count > 0 && dt.table.Rows[0]["RatingCount"].ToString() != "0")
        {
            //Rating1.CurrentRating = Convert.ToInt32(dt.table.Rows[0]["AverageRating"]);
            //ViewState["Rating"] = Convert.ToInt32(dt.table.Rows[0]["AverageRating"]);
            //txt_Heading.Text = dt.table.Rows[0]["headline"].ToString();
            //txt_review.Text = dt.table.Rows[0]["review"].ToString();
            //  submit_review.Text = "Update Review";
            submit_review.Text = "Submit";            
            GridView2.DataSource = dt.table;
            GridView2.DataBind();
        }
        else
        {
            GridView2.DataSource = dt.table;
            GridView2.DataBind();
        }
        dtt = dl.select_user_rating();
        if (dtt.table.Rows.Count > 0)
        {
            lblRatingStatus.Text = string.Format("{0} Users have rated. Average Rating {1}", dtt.table.Rows[0]["RatingCount"], dtt.table.Rows[0]["AverageRating"]);
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["CheckRefresh"] = Session["CheckRefresh"];
    }
    protected void OnRatingChanged(object sender, RatingEventArgs e)
    {
        bl.Rating = e.Value;
        ViewState["Rating"] = bl.Rating;
        // Response.Redirect(Request.Url.AbsoluteUri);
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        bind_rating();
    }

    protected void submit_review_Click(object sender, EventArgs e)
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
                        }
                        else
                        {
                            if (Request.Cookies["User_Id"] != null)
                            {
                                Session["User_Id"] = Request.Cookies["User_Id"].Value;
                                bl.User_id = Request.Cookies["User_Id"].Value;
                            }
                        }
                        bl.Date_time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        bl.Client_id = util.GetClientIpAddress(this.Page);
                        bl.Review = txt_review.Text.Trim();
                        bl.Headline = txt_Heading.Text.Trim();
                        bl.Rating = ViewState["Rating"].ToString();
                        bl.Category = "";
                        bl.Status = "N";
                        if (submit_review.Text == "Update Review")
                        {
                            rb = dl.Update_user_rating(bl);
                        }
                        else
                        {
                            rb = dl.Insert_user_rating(bl);
                        }
                        if (rb.status)
                        {
                            Utilities.MessageBox_UpdatePanel_Redirect(updatepanel1, "Thanks for your review, Your Review is submitted at HogwartsInstitute", Request.Url.AbsoluteUri);
                        }
                        else
                        {
                            Utilities.MessageBox_UpdatePanel_Redirect(updatepanel1, "Thanks for your review, Your Review is submitted at HogwartsInstitute", Request.Url.AbsoluteUri);
                        }

                        //Thread Stamp_Action = new Thread(delegate ()
                        //{
                        //    dtnew = dl.select_receriver_name_for_user_for_review(bl.User_id);
                        //    if (dtnew.table.Rows.Count > 0)
                        //    {
                        //        bl.Type = null;
                        //        bl.First_name = dtnew.table.Rows[0]["applicant_first_name"].ToString();
                        //        bl.Message = "Hi " + bl.First_name + ", Thanks for your review, Your Review is submitted at cellsalts4health, We will update you when your review is approved";
                        //        //bl.Success = send_sms_to_user(dtnew.table.Rows[0]["applicant_mobile"].ToString(), bl.Message);
                        //        //rb = dl.sms_log(bl);
                        //        //bl.Type = null;
                        //        if (dtnew.table.Rows[0]["applicant_email"].ToString() != "" && dtnew.table.Rows[0]["applicant_email"].ToString() != null)
                        //        {
                        //            bl.Success = email_to_user_new(dtnew.table.Rows[0]["applicant_email"].ToString(), bl.Message);
                        //            rb = dl.sms_log(bl);
                        //        }
                        //    }
                        //    dtnew = dl.select_receriver_name_for_user_for_review("9986546496");
                        //    if (dtnew.table.Rows.Count > 0)
                        //    {
                        //        bl.Type = null;
                        //        bl.Message = "Hi " + dtnew.table.Rows[0]["applicant_first_name"].ToString() + ", One of our client Mr/Miss/Mrs : " + bl.First_name + " has submitted a Review at cellsalts4health, Please Login to your account and review it for approve.";
                        //        //bl.Success = send_sms_to_user(dtnew.table.Rows[0]["applicant_mobile"].ToString(), bl.Message);
                        //        //rb = dl.sms_log(bl);
                        //        // bl.Type = null;
                        //        if (dtnew.table.Rows[0]["applicant_email"].ToString() != "" && dtnew.table.Rows[0]["applicant_email"].ToString() != null)
                        //        {
                        //            bl.Success = email_to_user_new(dtnew.table.Rows[0]["applicant_email"].ToString(), bl.Message);
                        //            rb = dl.sms_log(bl);
                        //        }
                        //    }
                        //});
                        //Stamp_Action.IsBackground = true;
                        //Stamp_Action.Start();

                    }
                    else
                        Utilities.MessageBox_UpdatePanel(updatepanel1, "Page Refresh or Back button is now allowed");
                }
                else
                    Utilities.MessageBox_UpdatePanel(updatepanel1, "Page expired!!! Please re open this page in new window.");
            }
            catch (NullReferenceException ex)
            {
                Utilities.MessageBox_UpdatePanel_Redirect(updatepanel1, "Records could not be saved: Please Try Again", Request.Url.AbsoluteUri);

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
            MailAddress bcc = new MailAddress("snehamca2006@gmail.com");
            mail.Bcc.Add(bcc);
            mail.To.Add(email);
            mail.Subject = "Online Consultation";
            mail.Body = message;
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

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        StringBuilder htmlTable = new StringBuilder();

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label download_link = (Label)e.Row.FindControl("rating");
            Literal req33 = (Literal)e.Row.FindControl("Literal2");

            Int64 lol = Convert.ToInt64(download_link.Text);
            if (lol == 1)
            {
                htmlTable.AppendLine("<i class=\"fa fa-star\"></i><i class=\"fa fa-star-o\"></i><i class=\"fa fa-star-o\"></i><i class=\"fa fa-star-o\"></i><i class=\"fa fa-star-o\"></i>");
            }
            else if (lol == 2)
            {
                htmlTable.AppendLine("<i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i><i class=\"fa fa-star-o\"></i><i class=\"fa fa-star-o\"></i><i class=\"fa fa-star-o\"></i>");
            }
            else if (lol == 3)
            {
                htmlTable.AppendLine("<i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i><i class=\"fa fa-star-o\"></i><i class=\"fa fa-star-o\"></i>");
            }
            else if (lol == 4)
            {
                htmlTable.AppendLine("<i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i><i class=\"fa fa-star-o\"></i>");
            }
            else if (lol == 5)
            {
                htmlTable.AppendLine("<i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i>");
            }
            req33.Text = htmlTable.ToString();


            e.Row.Cells[1].Visible = false;


            DataRowView rowView = (DataRowView)e.Row.DataItem;

            string myDataKey = rowView["status"].ToString();
            if (myDataKey == "Y")
            {
                e.Row.Cells[5].BackColor = System.Drawing.Color.Green;
                e.Row.Cells[5].ForeColor = System.Drawing.Color.Black;
            }
            else if (myDataKey == "N")
            {
                e.Row.Cells[5].BackColor = System.Drawing.Color.LightBlue;
                e.Row.Cells[5].ForeColor = System.Drawing.Color.Black;
            }
            else if (myDataKey == "R")
            {
                e.Row.Cells[5].BackColor = System.Drawing.Color.IndianRed;
                e.Row.Cells[5].ForeColor = System.Drawing.Color.Black;
            }
        }
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[1].Visible = false;
        }
    }
}