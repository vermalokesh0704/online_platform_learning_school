using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Control_doctor_pagestatus : System.Web.UI.UserControl
{
    doc_ba_layer bl = new doc_ba_layer();
    doc_da_layer dl = new doc_da_layer();
    ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnBool rb = new ReturnClass.ReturnBool();
    Utilities util = new Utilities();
    protected void Page_Load(object sender, EventArgs e)
    {
        string provi = "", current = "p1";
        string path = HttpContext.Current.Request.Url.AbsolutePath;
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
                    bl.User_id = Request.Cookies["User_Id"].Value;
                    Session["User_Id"] = Request.Cookies["User_Id"].Value;
                }
            }
        }

        dt = dl.bind_doctor_page(bl);
        if (path.Contains("profile_update"))
            current = "p1";
        if (path.Contains("profile_update_part2"))
            current = "p2";
        if (path.Contains("profile_update_part3"))
            current = "p3";

        if (dt.table.Rows.Count > 0)
        {
            if (dt.table.Rows[0]["part_1"].ToString() == "Y")
            {
                if (current == "p1")
                {
                    button1.Attributes.Add("class", "btn btn-info btn-circle active");
                }
                else
                {
                    button1.Attributes.Add("class", "btn btn-success btn-circle active");
                }
            }
            else
            {
                if (current == "p1")
                {
                    button1.Attributes.Add("class", "btn btn-info btn-circle active");
                }
                else
                {
                    button1.Attributes.Add("class", "btn btn-danger btn-circle active1");
                }
            }
            if (dt.table.Rows[0]["part_2"].ToString() == "Y")
            {
                if (current == "p2")
                {
                    button2.Attributes.Add("class", "btn btn-info btn-circle active");
                }
                else
                {
                    button2.Attributes.Add("class", "btn btn-success btn-circle active");
                }
            }
            else
            {
                if (current == "p2")
                {
                    button2.Attributes.Add("class", "btn btn-info btn-circle active");
                }
                else
                {
                    button2.Attributes.Add("class", "btn btn-danger btn-circle active1");
                }
            }
            if (dt.table.Rows[0]["part_3"].ToString() == "Y")
            {
                if (current == "p3")
                {
                    button3.Attributes.Add("class", "btn btn-info btn-circle active");
                }
                else
                {
                    button3.Attributes.Add("class", "btn btn-success btn-circle active");
                }
            }
            else
            {
                if (current == "p3")
                {
                    button3.Attributes.Add("class", "btn btn-info btn-circle active");
                }
                else
                {
                    button3.Attributes.Add("class", "btn btn-danger btn-circle active1");
                }
            }
        }
    }
}