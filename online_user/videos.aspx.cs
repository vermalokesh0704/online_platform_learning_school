using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class online_user_videos : System.Web.UI.Page
{
    olu_ba_layer bl = new olu_ba_layer();
    olu_da_layer_new dl = new olu_da_layer_new();
    Utilities util = new Utilities();
    ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnDataTable dtt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnBool rb = new ReturnClass.ReturnBool();
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

            if (Session["Class_id"] != null)
            {
                bl.Class_code = Session["Class_id"].ToString();
                bl.Class_code = Session["Class_id"].ToString();
            }
            else
            {
                if (Request.Cookies["Class_id"] != null)
                {
                    Session["Class_id"] = Request.Cookies["Class_id"].Value;
                    bl.Class_code = Request.Cookies["Class_id"].Value;
                    bl.Class_code = Request.Cookies["Class_id"].Value;
                }
            }
            if (Request.QueryString["sub"] != null)
            {
                bl.Subject_id = Request.QueryString["sub"].ToString();
                if (bl.Subject_id == "Acc")
                {
                    bl.Subject = "Accountancy";
                }
                else if (bl.Subject_id == "Bio")
                {
                    bl.Subject = "Biology";
                }
                else if (bl.Subject_id == "Bus")
                {
                    bl.Subject = "Business Studies";
                }
                else if (bl.Subject_id == "Che")
                {
                    bl.Subject = "Chemistry";
                }
                else if (bl.Subject_id == "Com")
                {
                    bl.Subject = "Computer";
                }
                else if (bl.Subject_id == "Eco")
                {
                    bl.Subject = "Economics";
                }
                else if (bl.Subject_id == "Eng")
                {
                    bl.Subject = "English";
                }
                else if (bl.Subject_id == "Geo")
                {
                    bl.Subject = "Geography";
                }
                else if (bl.Subject_id == "Hin")
                {
                    bl.Subject = "Hindi";
                }
                else if (bl.Subject_id == "His")
                {
                    bl.Subject = "History";
                }
                else if (bl.Subject_id == "Inf")
                {
                    bl.Subject = "Informatics Practices";
                }
                else if (bl.Subject_id == "Mat")
                {
                    bl.Subject = "Mathematics";
                }
                else if (bl.Subject_id == "Phy")
                {
                    bl.Subject = "Physics";
                }
                else if (bl.Subject_id == "Sci")
                {
                    bl.Subject = "Science";
                }
                else if (bl.Subject_id == "Soc")
                {
                    bl.Subject = "Social Science";
                }
                class_name.Text = bl.Class_id + "th class " + bl.Subject + " videos";
                bl.Desc = bl.Subject_id;
                dt = dl.get_subject_id(bl);
                if (dt.table.Rows.Count > 0)
                {
                    Session["Subject_id"] = dt.table.Rows[0]["Subject_id"].ToString();
                    Response.Cookies["Subject_id"].Value = Session["Subject_id"].ToString();
                    Response.Cookies["Subject_id"].Expires = DateTime.Now.AddDays(365);
                    bl.Symptom_id = Session["Subject_id"].ToString();
                }
            }

            this.BindDataList();

            Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["CheckRefresh"] = Session["CheckRefresh"];
    }
    private void BindDataList()
    {
        StringBuilder html1 = new StringBuilder();
        if (Session["Subject_id"] != null)
        {
            bl.Symptom_id = Session["Subject_id"].ToString();
        }
        else
        {
            if (Request.Cookies["Subject_id"] != null)
            {
                Session["Class_id"] = Request.Cookies["Subject_id"].Value;
                bl.Symptom_id = Request.Cookies["Subject_id"].Value;
            }
        }
        dt = dl.get_class_videos(bl);
        if (dt.table.Rows.Count > 0)
        {
            int cout = 1;
            // gvCustomers.DataSource = dt.table;
            // gvCustomers.DataBind();

            foreach (DataRow dr in dt.table.Rows)
            {
                if (cout == 1 || cout == 4 || cout == 7 || cout == 10 || cout == 13 || cout == 16 || cout == 19 || cout == 22 || cout == 25 || cout == 28 || cout == 31 || cout == 34 || cout == 37 || cout == 40 || cout == 44 || cout == 47 || cout == 50)
                {
                    html1.AppendLine("<div class=\"row\">");
                }
                html1.AppendLine("<div class=\"col-md-4 col-sm-4\">");
                html1.AppendLine("<div class=\"blog-box blog-2 blog-border\"> ");
                html1.AppendLine("<div class=\"popup-video-image border-video popup-gallery\">");
                html1.AppendLine("<img class=\"img-responsive\" src=\"../images/subjects/05.jpg\" alt=\"\">");
                html1.AppendLine("<a class=\"popup-youtube\" href=" + dr["path"].ToString() + "#toolbar=0> <i class=\"fa fa-play\"></i> </a>");
                html1.AppendLine("<div class=\"video-attribute\">");
              //  html1.AppendLine("<span class=\"length\">01:06</span>");
                html1.AppendLine("<span class=\"quality\">HD</span>");
                html1.AppendLine("</div></div>");
                html1.AppendLine("<div class=\"blog-info\" style=\"height:250px;\">"); 
                html1.AppendLine("<span class=\"tag\"><a href=\"#\">" + dr["video_heading"].ToString() + "</a></span>");
                html1.AppendLine("<h4 class=\"mt-20\"> <a href=\"#\"> " + dr["video_description"].ToString() + "</a></h4>");
                html1.AppendLine("<span> By Anmol Thakur - <i>" + dr["date_time"].ToString() + "</i></span>");
                html1.AppendLine("</div></div></div>");
                if (cout == 3 || cout == 6 || cout == 9 || cout == 12 || cout == 15 || cout == 18 || cout == 21 || cout == 24 || cout == 27 || cout == 30 || cout == 33 || cout == 36 || cout == 39 || cout == 42 || cout == 45 || cout == 48 || cout == 51)
                {
                    html1.AppendLine("</div><br>");
                }
                cout = cout + 1;
            }
            videos.Text = html1.ToString();
        }
        else
        {
            html1.AppendLine("No Topic Found");
            videos.Text = html1.ToString();
        }
    }
}