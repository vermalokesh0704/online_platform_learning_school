﻿using AjaxControlToolkit;
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

public partial class Admin_Add_subject : System.Web.UI.Page
{
    ReturnClass.ReturnBool rb = new ReturnClass.ReturnBool();
    ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnDataTable dtt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnDataTable dtnew = new ReturnClass.ReturnDataTable();
    olu_ba_layer bl = new olu_ba_layer();
    admin_da_layer_new dl = new admin_da_layer_new();
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
            bind_class();
            bind_subject();

        }
    }
    public void bind_class()
    {
        try
        {
            dtt = dl.select_class();
            ddl_class.Items.Clear();
            ddl_class.DataSource = dtt.table;
            ddl_class.DataTextField = "Class_Name";
            ddl_class.DataValueField = "Class_id";
            ddl_class.DataBind();
            ddl_class.Items.Insert(0, new ListItem("Select Class", "0"));
        }
        catch (NullReferenceException)
        {
            //   Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
        }
    }
    public void bind_subject()
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
        dt = dl.select_subject();
        GridView2.DataSource = dt.table;
        GridView2.DataBind();

    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["CheckRefresh"] = Session["CheckRefresh"];
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        bind_subject();
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
                        bl.Category = txt_Heading.Text.Trim();
                        bl.Class_id = ddl_class.SelectedValue;
                        bl.Subject_id = INTSUB_ID_from();
                        rb = dl.Insert_subject(bl);
                        if (rb.status)
                        {
                            txt_Heading.Text = "";
                            bind_class();
                            bind_subject();
                            Utilities.MessageBox_UpdatePanel(updatepanel1, "Subject Added Successfully");
                        }
                        else
                        {
                            Utilities.MessageBox_UpdatePanel(updatepanel1, "Failed to save, Please try again");
                        }
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

    public string INTSUB_ID_from()
    {
        ReturnClass.ReturnDataTable rdt = new ReturnClass.ReturnDataTable();
        try
        {
            bl.C_year = DateTime.Now.ToString("yyyy");
            bl.C_month = DateTime.Now.ToString("MM");
            rdt = dl.INTSUB_subject_id(bl);
            if (rdt.table.Rows.Count > 0)
            {
                bl.S1 = rdt.table.Rows[0]["pid"].ToString();
                if (bl.S1 == "")
                {
                    bl.S = "0";
                    bl.Nid = Convert.ToString(Convert.ToInt32(bl.S) + 1);
                }
                else
                    bl.Nid = Convert.ToString(Convert.ToInt32(bl.S1) + 1);
            }
            else
            {
                bl.S = "0";
                bl.Nid = Convert.ToString(Convert.ToInt32(bl.S) + 1);
            }
            bl.Aid = DateTime.Now.ToString("yy") + bl.C_month + "9" + "2" + bl.Nid.PadLeft(4, '0');
        }
        catch { bl.Aid = "" + "" + DateTime.Now.ToString("yy") + bl.C_month + "9" + "0001"; }
        return bl.Aid;
    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView2.EditIndex)
        {

            (e.Row.Cells[3].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
        }
        if (e.Row.RowType == DataControlRowType.Header)
        {
            //            e.Row.Cells[1].Visible = false;
        }

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex == GridView2.EditIndex )
        {
            DropDownList ddl_class = (e.Row.FindControl("ddl_class") as DropDownList);
            dtt = dl.select_class();
            ddl_class.Items.Clear();
            ddl_class.DataSource = dtt.table;
            ddl_class.DataTextField = "Class_Name";
            ddl_class.DataValueField = "Class_id";
            ddl_class.DataBind();
            ddl_class.Items.Insert(0, new ListItem("Select Class", "0"));
            DataRowView rowView = (DataRowView)e.Row.DataItem;
            string myDataKey = rowView["class_id"].ToString();
            ddl_class.SelectedValue= myDataKey;
            
        }
       
    }

    protected void OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView2.EditIndex = e.NewEditIndex;
        this.bind_subject();
    }
    protected void OnRowCancelingEdit(object sender, EventArgs e)
    {
        GridView2.EditIndex = -1;
        this.bind_subject();
    }

    protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        bl.Subject_id = GridView2.DataKeys[e.RowIndex].Values[0].ToString();
        rb = dl.delete_subject(bl);
        if (rb.status)
        {
            this.bind_subject();
            Utilities.MessageBox_UpdatePanel(updatepanel1, "Subject deleted Successfully");
           
        }
        else
        {
            Utilities.MessageBox_UpdatePanel(updatepanel1, "Failed to delete, Please try again");
        }
    }


    protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView2.Rows[e.RowIndex];
        bl.Class_id = (row.FindControl("ddl_class") as DropDownList).SelectedValue;
        bl.Subject_id = GridView2.DataKeys[e.RowIndex].Values[0].ToString();
        bl.Category = (row.FindControl("txtName") as TextBox).Text;
        rb = dl.update_subject(bl);
        if (rb.status)
        {
            GridView2.EditIndex = -1;
            this.bind_subject();
            Utilities.MessageBox_UpdatePanel(updatepanel1, "Subject Updated Successfully");
          
        }
        else
        {
            Utilities.MessageBox_UpdatePanel(updatepanel1, "Failed to update, Please try again");
        }
    }
}