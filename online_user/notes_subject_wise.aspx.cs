using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class online_user_notes_subject_wise : System.Web.UI.Page
{
    olu_ba_layer bl = new olu_ba_layer();
    olu_da_layer dl = new olu_da_layer();
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

            if(bl.Class_id=="9" || bl.Class_id == "10")
            {
                class_9_10.Visible = true;
                pcm_pcb_11_12.Visible = false;
                commerce_11_12.Visible = false;
            }
            else if ((bl.Class_id == "11" || bl.Class_id == "12") && bl.Stream_id== "COM")
            {
                class_9_10.Visible = false;
                pcm_pcb_11_12.Visible = false;
                commerce_11_12.Visible = true;
            }
            else if ((bl.Class_id == "11" || bl.Class_id == "12") && bl.Stream_id == "PCB")
            {
                class_9_10.Visible = false;
                pcm_pcb_11_12.Visible = true;
                commerce_11_12.Visible = false;
                bio.Visible = true;
                math.Visible = false;
            }
            else if ((bl.Class_id == "11" || bl.Class_id == "12") && bl.Stream_id == "PCM")
            {
                class_9_10.Visible = false;
                pcm_pcb_11_12.Visible = true;
                commerce_11_12.Visible = false;
                bio.Visible = false;
                math.Visible = true;
            }
            class_name.Text = " of Class "+ bl.Class_id + "th";

            Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
        }

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["CheckRefresh"] = Session["CheckRefresh"];
    }

}