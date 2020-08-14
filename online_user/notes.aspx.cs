using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class online_user_notes : System.Web.UI.Page
{
    ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnDataTable dtt = new ReturnClass.ReturnDataTable();
    bl_common bl = new bl_common();
    da_common dl = new da_common();

    StringBuilder html1 = new StringBuilder();
    olu_ba_layer bll = new olu_ba_layer();
    olu_da_layer_new dll = new olu_da_layer_new();
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
                bll.Class_id = Session["class"].ToString();
            }
            else
            {
                if (Request.Cookies["class"] != null)
                {
                    Session["class"] = Request.Cookies["class"].Value;
                    bll.Class_id = Request.Cookies["class"].Value;
                }
            }
            if (Session["stream"] != null)
            {
                bll.Stream_id = Session["stream"].ToString();
            }
            else
            {
                if (Request.Cookies["stream"] != null)
                {
                    Session["stream"] = Request.Cookies["stream"].Value;
                    bll.Stream_id = Request.Cookies["stream"].Value;
                }
            }

            if (Session["Class_id"] != null)
            {
                bll.Class_code = Session["Class_id"].ToString();
                bl.Class_code = Session["Class_id"].ToString();
            }
            else
            {
                if (Request.Cookies["Class_id"] != null)
                {
                    Session["Class_id"] = Request.Cookies["Class_id"].Value;
                    bll.Class_code = Request.Cookies["Class_id"].Value;
                    bl.Class_code = Request.Cookies["Class_id"].Value;
                }
            }
            if (Request.QueryString["sub"] != null)
            {
                bll.Subject_id = Request.QueryString["sub"].ToString();
                if (bll.Subject_id == "Acc")
                {
                    bll.Subject = "Accountancy";
                }
                else if (bll.Subject_id == "Bio")
                {
                    bll.Subject = "Biology";
                }
                else if (bll.Subject_id == "Bus")
                {
                    bll.Subject = "Business Studies";
                }
                else if (bll.Subject_id == "Che")
                {
                    bll.Subject = "Chemistry";
                }
                else if (bll.Subject_id == "Com")
                {
                    bll.Subject = "Computer";
                }
                else if (bll.Subject_id == "Eco")
                {
                    bll.Subject = "Economics";
                }
                else if (bll.Subject_id == "Eng")
                {
                    bll.Subject = "English";
                }
                else if (bll.Subject_id == "Geo")
                {
                    bll.Subject = "Geography";
                }
                else if (bll.Subject_id == "Hin")
                {
                    bll.Subject = "Hindi";
                }
                else if (bll.Subject_id == "His")
                {
                    bll.Subject = "History";
                }
                else if (bll.Subject_id == "Inf")
                {
                    bll.Subject = "Informatics Practices";
                }
                else if (bll.Subject_id == "Mat")
                {
                    bll.Subject = "Mathematics";
                }
                else if (bll.Subject_id == "Phy")
                {
                    bll.Subject = "Physics";
                }
                else if (bll.Subject_id == "Sci")
                {
                    bll.Subject = "Science";
                }
                else if (bll.Subject_id == "Soc")
                {
                    bll.Subject = "Social Science";
                }
                class_name.Text = bll.Class_id + "th class " + bll.Subject + " notes";
                bl.Desc = bll.Subject_id;
                dt = dll.get_subject_id(bl);
                if (dt.table.Rows.Count > 0)
                {
                    Session["Subject_id"] = dt.table.Rows[0]["Subject_id"].ToString();
                    Response.Cookies["Subject_id"].Value = Session["Subject_id"].ToString();
                    Response.Cookies["Subject_id"].Expires = DateTime.Now.AddDays(365);
                    bl.Symptom_id = Session["Subject_id"].ToString();
                }




            }
            literal1.Text = null;
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
            bl.Desc = "A";
            dt = dll.get_topic_name(bl);
            if (dt.table.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.table.Rows)
                {
                    bl.Desc = dr["id"].ToString();
                    ////dtt = dl.get_diseases_by_name(bl);
                    html1.AppendLine("<div class=\"acd-group\">");
                    html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                    if (dt.table.Rows.Count > 0)
                    {
                        html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                        html1.AppendLine("<p>");
                        html1.AppendLine(dr["description"].ToString());
                        html1.AppendLine("</p>");
                        html1.AppendLine("<br>");
                        //foreach (DataRow drr in dtt.table.Rows)
                        //{

                        //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                        //    html1.AppendLine("<br>");
                        //    html1.AppendLine("<p>");
                        //    html1.AppendLine(drr["effect"].ToString());
                        //    html1.AppendLine("</p>");
                        //}
                        html1.AppendLine("</div>");
                    }
                    html1.AppendLine("</div>");
                }

                literal1.Text = html1.ToString();
            }
            else
            {
                literal1.Text = "No Topic found";
            }
            Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["CheckRefresh"] = Session["CheckRefresh"];
    }

    [WebMethod]
    public static List<string> GetMainManufactureService(string Desc)
    {
        List<string> MainManufacture_Service = new List<string>();
        ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
        bl_common bl = new bl_common();
        olu_da_layer_new dll = new olu_da_layer_new();
        if (HttpContext.Current.Session["Subject_id"] != null)
        {
            bl.Symptom_id = HttpContext.Current.Session["Subject_id"].ToString();
        }
        else
        {
            if (HttpContext.Current.Request.Cookies["Subject_id"] != null)
            {
                HttpContext.Current.Session["Class_id"] = HttpContext.Current.Request.Cookies["Subject_id"].Value;
                bl.Symptom_id = HttpContext.Current.Request.Cookies["Subject_id"].Value;
            }
        }
        bl.Desc = Desc;
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                MainManufacture_Service.Add(string.Format("{0}#{1}", dr["Name"], dr["id"]));
            }
        }
        else { }
        return MainManufacture_Service;
    }
    [WebMethod]
    public static string GetCurrentTime(string name)
    {
        string final = null;
        StringBuilder html1 = new StringBuilder();
        html1.AppendLine("<div class=\"acd-group\">");
        html1.AppendLine("<a class=\"acd-heading\">Mental States and Affections</a>");
        html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem.</div>");
        html1.AppendLine("</div>");
        final = html1.ToString();
        return final;
    }

    protected void a_link_Click(object sender, EventArgs e)
    {
        literal1.Text = null;
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
        bl.Desc = "A";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{

                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }

            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void b_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "B";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{

                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void c_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "C";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void d_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "D";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void e_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "E";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void f_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "F";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void g_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "G";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void h_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "H";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void i_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "I";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void j_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "J";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void k_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "K";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void l_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "L";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void m_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "M";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void n_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "N";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }


    protected void o_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "O";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void p_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "P";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void q_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "Q";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void r_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "R";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void s_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "S";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void t_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "T";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void u_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "U";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void v_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "V";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void w_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "W";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void x_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "X";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void y_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "Y";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }
    protected void z_link_Click(object sender, EventArgs e)
    {
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
        bl.Desc = "Z";
        dt = dll.get_topic_name(bl);
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.table.Rows)
            {
                bl.Desc = dr["id"].ToString();
                //dtt = dl.get_diseases_by_name(bl);
                html1.AppendLine("<div class=\"acd-group\">");
                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                if (dt.table.Rows.Count > 0)
                {
                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                    html1.AppendLine("<p>");
                    html1.AppendLine(dr["description"].ToString());
                    html1.AppendLine("</p>");
                    html1.AppendLine("<br>");
                    //foreach (DataRow drr in dtt.table.Rows)
                    //{
                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                    //    html1.AppendLine("<br>");
                    //    html1.AppendLine("<p>");
                    //    html1.AppendLine(drr["effect"].ToString());
                    //    html1.AppendLine("</p>");
                    //}
                    html1.AppendLine("</div>");
                }
                html1.AppendLine("</div>");
            }
            literal1.Text = html1.ToString();
        }
        else
        {
            literal1.Text = "No Topic found";
        }
    }

    protected void search_Click(object sender, EventArgs e)
    {
        // html1= null;
        if (Page.IsValid)
        {
            try
            {
                if (Session["CheckRefresh"] != null)
                {
                    if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                    {
                        Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
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
                        string lol = code.Value;
                        bl.Desc = lol;
                        dt = dll.get_topic_code(bl);
                        if (dt.table.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.table.Rows)
                            {
                                bl.Desc = dr["id"].ToString();
                                //dtt = dl.get_diseases_by_name(bl);
                                html1.AppendLine("<div class=\"acd-group\">");
                                html1.AppendLine("<a class=\"acd-heading\">" + dr["name"].ToString() + "</a>");
                                if (dt.table.Rows.Count > 0)
                                {
                                    html1.AppendLine("<div class=\"acd-des\" style=\"display: none;\">");
                                    html1.AppendLine("<p>");
                                    html1.AppendLine(dr["description"].ToString());
                                    html1.AppendLine("</p>");
                                    html1.AppendLine("<br>");
                                    //foreach (DataRow drr in dtt.table.Rows)
                                    //{
                                    //    html1.AppendLine("<b>" + drr["name"].ToString() + "</b>");
                                    //    html1.AppendLine("<br>");
                                    //    html1.AppendLine("<p>");
                                    //    html1.AppendLine(drr["effect"].ToString());
                                    //    html1.AppendLine("</p>");
                                    //}
                                    html1.AppendLine("</div>");
                                }
                                html1.AppendLine("</div>");
                            }
                            literal1.Text = html1.ToString();
                        }
                        else
                        {
                            literal1.Text = "No Topic found";
                        }
                    }
                    else
                        Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel7, "Page Refresh or Back button is now allowed", "ailments.aspx");
                }
                else
                    Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel7, "Page expired!!! Please re open this page in new window.", "ailments.aspx");
            }
            catch (NullReferenceException ex)
            {
                Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel7, "Page expired!!! Please re open this page in new window.", "ailments.aspx");
            }
        }
    }
}