using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class online_user_User_Dashboard : System.Web.UI.Page
{
    ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnBool rb = new ReturnClass.ReturnBool();
    ReturnClass.ReturnDataTable dtt_single = new ReturnClass.ReturnDataTable();
    bl_Usr_Registration bl = new bl_Usr_Registration();
    da_common dl = new da_common();
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.HtmlControls.HtmlGenericControl currdiv = (System.Web.UI.HtmlControls.HtmlGenericControl)Master.FindControl("rightheader");
        currdiv.Visible = false;
        if (!IsPostBack)
        {
            Bind();
            // testimonial();
            Review();
            bind_class_id();
            Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
        }
    }


    public void bind_class_id()
    {
        olu_ba_layer bl = new olu_ba_layer();
        olu_da_layer_new dl = new olu_da_layer_new();
        
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
        if (Session["class"] != null)
        {
            bl.Class_id = Session["class"].ToString();
        }
        else
        {
            if (Request.Cookies["class"] != null)
            {
                Session["class"] = Request.Cookies["class"].Value;
                bl.Class_id = Request.Cookies["class"].Value;
            }
        }
        if (Session["stream"] != null)
        {
            bl.Stream_id = Session["stream"].ToString();
        }
        else
        {
            if (Request.Cookies["stream"] != null)
            {
                Session["stream"] = Request.Cookies["stream"].Value;
                bl.Stream_id = Request.Cookies["stream"].Value;
            }
        }
               
        dt = dl.get_class_code(bl);
        if (dt.table.Rows.Count > 0)
        {
            Session["Class_id"] = dt.table.Rows[0]["Class_id"].ToString();
            Response.Cookies["Class_id"].Value = Session["Class_id"].ToString();
            Response.Cookies["Class_id"].Expires = DateTime.Now.AddDays(365);
        }

    }
    public void Review()
    {
        olu_ba_layer bl = new olu_ba_layer();
        olu_da_layer dl = new olu_da_layer();
        ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
        ReturnClass.ReturnDataTable dtt = new ReturnClass.ReturnDataTable();
        ReturnClass.ReturnBool rb = new ReturnClass.ReturnBool();
        dt = dl.select_user_rating();
        StringBuilder htmlTable = new StringBuilder();
        string file_id = null;
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow row in dt.table.Rows)
            {
                bl.User_idd = row["user_id"].ToString();
                if (row["user_type"].ToString() == "USER")
                {
                    dtt = dl.bind_review_user_file_id(bl);
                    if (dtt.table.Rows.Count > 0)
                    {
                        file_id = dtt.table.Rows[0]["file_id"].ToString();
                    }
                    else
                    {
                        file_id = "8";
                    }
                }
                else
                {
                    bl.User_idd = row["user_id"].ToString();
                    dtt = dl.bind_testimonial_file_id(bl);
                    if (dtt.table.Rows.Count > 0)
                    {
                        file_id = dtt.table.Rows[0]["file_id"].ToString();

                    }
                    else
                    {
                        file_id = "7";
                    }
                }
                htmlTable.AppendLine(" <div class=\"product left clearfix mb-40\">");
                htmlTable.AppendLine("<div class=\"product-image\">");
                if (row["user_type"].ToString() == "USER")
                {
                    htmlTable.AppendLine("<img class=\"img-responsive llol\" alt=\"\" src=\"Handler_user.ashx?id=" + file_id + "\" width=\"35px\" height=\"35px\" /></div>");
                }
                else
                {
                    htmlTable.AppendLine("<img class=\"img-responsive llol\" alt=\"\" src=\"Handler.ashx?id=" + file_id + "\" width=\"35px\" height=\"35px\" /></div>");
                }
                htmlTable.AppendLine("<div class=\"product-description\">");
                htmlTable.AppendLine(" <div class=\"product-title\">");
                int lol = Convert.ToInt32(row["AverageRating"]);
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
                htmlTable.AppendLine("</div>");
                //     htmlTable.AppendLine("<h5>" + row["name"] + " </h5></div>");
                htmlTable.AppendLine("<div class=\"product-price\">");
                htmlTable.AppendLine("<b>" + row["headline"] + " - </b><ins>" + row["review"] + "</ins></div>");
                htmlTable.AppendLine("<div class=\"product-rate\">");
                htmlTable.AppendLine("<h5>" + row["name"] + " </h5></div>");
                //int lol =Convert.ToInt32(row["AverageRating"]);
                //if (lol == 1)
                //    {
                //    htmlTable.AppendLine("<i class=\"fa fa-star\"></i><i class=\"fa fa-star-o\"></i><i class=\"fa fa-star-o\"></i><i class=\"fa fa-star-o\"></i><i class=\"fa fa-star-o\"></i>");
                //}
                //else if (lol == 2)
                //{
                //    htmlTable.AppendLine("<i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i><i class=\"fa fa-star-o\"></i><i class=\"fa fa-star-o\"></i><i class=\"fa fa-star-o\"></i>");
                //}
                //else if (lol == 3)
                //{
                //    htmlTable.AppendLine("<i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i><i class=\"fa fa-star-o\"></i><i class=\"fa fa-star-o\"></i>");
                //}
                //else if (lol == 4)
                //{
                //    htmlTable.AppendLine("<i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i><i class=\"fa fa-star-o\"></i>");
                //}
                //else if (lol == 5)
                //{
                //    htmlTable.AppendLine("<i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i><i class=\"fa fa-star\"></i>");
                //}
                //    htmlTable.AppendLine("</div></div></div>");
                htmlTable.AppendLine("</div></div>");
                Literal2.Text = htmlTable.ToString();
            }
        }

    }
    public void testimonial()
    {
        olu_ba_layer bl = new olu_ba_layer();
        olu_da_layer dl = new olu_da_layer();
        ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
        ReturnClass.ReturnDataTable dtt = new ReturnClass.ReturnDataTable();
        ReturnClass.ReturnBool rb = new ReturnClass.ReturnBool();
        dt = dl.bind_testimonial();
        StringBuilder htmlTable = new StringBuilder();
        string file_id = null;
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow row in dt.table.Rows)
            {
                bl.User_id = row["user_id"].ToString();
                dtt = dl.bind_testimonial_file_id(bl);
                if (dtt.table.Rows.Count > 0)
                {
                    file_id = dtt.table.Rows[0]["file_id"].ToString();

                }
                else
                {
                    file_id = "7";
                }
                htmlTable.AppendLine("<div class=\"grid-item photography branding\">");
                htmlTable.AppendLine("<div class=\"item\">");
                htmlTable.AppendLine("<div class=\"testimonial theme-bg bottom_pos\">");
                htmlTable.AppendLine("<div class=\"testimonial-avatar\">");
                htmlTable.AppendLine("<img src=\"online_user/Handler.ashx?id=" + file_id + "\" width=\"100\" height=\"104px\"  /> </div>");
                htmlTable.AppendLine("<div class=\"testimonial-info\">" + row["testimonial"] + "</div>");
                htmlTable.AppendLine("<div class=\"author-info\"><strong>" + row["name"] + " <br><span>Cell Salts User</span></strong> </div>");
                htmlTable.AppendLine("</div></div></div>");
                //     Literal1.Text = htmlTable.ToString();
            }
        }

    }
    public void Bind()
    {
        try
        {
            // bl.User_Id = Session["User_Id"].ToString();
            if (Session["User_Id"] != null)
            {
                bl.User_Id = Session["User_Id"].ToString();
            }
            else
            {
                if (Request.Cookies["User_Id"] != null)
                {
                    Session["User_Id"] = Request.Cookies["User_Id"].Value;
                    bl.User_Id = Request.Cookies["User_Id"].Value;
                }
            }
            dt = dl.check_profile_update(bl);
            if (dt.table.Rows.Count > 0)
            {
                if (dt.table.Rows[0]["profile_update"].ToString() == "N")
                {
                    rb = dl.Update_user_profile(bl);
                    hidden1.Value = "Y";

                }
                else
                {
                    hidden1.Value = "N";
                }
            }
            else
            {
              //  Utilities.MessageBoxShow_Redirect("Page expired!!! Please re open this page in new window.", "../Logout.aspx");
            }
        }
        catch
        {
            //Utilities.MessageBoxShow_Redirect("Page expired!!! Please re open this page in new window.", "../Logout.aspx");
            Response.Redirect("User_Dashboard.aspx");
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["CheckRefresh"] = Session["CheckRefresh"];
    }
}