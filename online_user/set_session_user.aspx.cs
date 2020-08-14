using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class online_user_set_session_user : System.Web.UI.Page
{
    olu_ba_layer bl = new olu_ba_layer();
    olu_da_layer dl = new olu_da_layer();
    ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnBool rb = new ReturnClass.ReturnBool();
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
            dt = dl.bind_user_page(bl);
            if (dt.table.Rows.Count > 0)
            {
                if (dt.table.Rows[0]["part_1"].ToString() == "Y")
                {
                    Response.Redirect("User_Dashboard.aspx");
                    //if (dt.table.Rows[0]["part_2"].ToString() == "Y")
                    //{
                    //    if (dt.table.Rows[0]["part_3"].ToString() == "Y")
                    //    {
                    //        Response.Redirect("User_Dashboard.aspx");
                    //    }
                    //    else
                    //    {
                    //        Response.Redirect("profile_update_part3.aspx");
                    //    }
                    //}
                    //else
                    //{
                    //    Response.Redirect("profile_update_part2.aspx");
                    //}

                }
                else
                {
                    Response.Redirect("profile_update.aspx");
                }

            }
        }
    }
}