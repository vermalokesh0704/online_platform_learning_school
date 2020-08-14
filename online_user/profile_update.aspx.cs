using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class online_user_profile_update : System.Web.UI.Page
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
            Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
            bind_gender();
            bind_country();
            bind_state();
            bind_city();
            bind_age();
            bind_blood();
            bind_martial();
            bind_nationality();
            bind_ddl();
            GetFileUpload();
            GetFileUpload_report();
            bind_page();
            

        }

    }

    public void bind_ddl()
    {
        try
        {
            bl.Category = "yes_no";
            dtt = dl.Ddl_cat_list(bl);
            ddl_smoking.Items.Clear();
            ddl_smoking.DataSource = dtt.table;
            ddl_smoking.DataTextField = "name";
            ddl_smoking.DataValueField = "id";
            ddl_smoking.DataBind();
            ddl_smoking.Items.Insert(0, new ListItem("Select Smoking", "0"));

            ddl_alcpohal.Items.Clear();
            ddl_alcpohal.DataSource = dtt.table;
            ddl_alcpohal.DataTextField = "name";
            ddl_alcpohal.DataValueField = "id";
            ddl_alcpohal.DataBind();
            ddl_alcpohal.Items.Insert(0, new ListItem("Select Alcoholic", "0"));

            bl.Category = "bp";
            dtt = dl.Ddl_cat_list(bl);
            ddl_bp.Items.Clear();
            ddl_bp.DataSource = dtt.table;
            ddl_bp.DataTextField = "name";
            ddl_bp.DataValueField = "id";
            ddl_bp.DataBind();
            ddl_bp.Items.Insert(0, new ListItem("Select Blood Pressure", "0"));

            bl.Category = "diabatic";
            dtt = dl.Ddl_cat_list(bl);
            ddl_diabetic.Items.Clear();
            ddl_diabetic.DataSource = dtt.table;
            ddl_diabetic.DataTextField = "name";
            ddl_diabetic.DataValueField = "id";
            ddl_diabetic.DataBind();
            ddl_diabetic.Items.Insert(0, new ListItem("Select Diabetic", "0"));


        }
        catch (NullReferenceException)
        {
            //   Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
        }
    }
    public void bind_blood()
    {
        try
        {
            bl.Category = "blood_group";
            dtt = dl.Ddl_cat_list(bl);
            ddl_blood.Items.Clear();
            ddl_blood.DataSource = dtt.table;
            ddl_blood.DataTextField = "name";
            ddl_blood.DataValueField = "id";
            ddl_blood.DataBind();
            ddl_blood.Items.Insert(0, new ListItem("Select Blood Group", "0"));
        }
        catch (NullReferenceException)
        {
            //   Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
        }
    }
    public void bind_martial()
    {
        try
        {
            bl.Category = "martial_status";
            dtt = dl.Ddl_cat_list(bl);
            ddl_martial.Items.Clear();
            ddl_martial.DataSource = dtt.table;
            ddl_martial.DataTextField = "name";
            ddl_martial.DataValueField = "id";
            ddl_martial.DataBind();
            ddl_martial.Items.Insert(0, new ListItem("Select Martial Status", "0"));
        }
        catch (NullReferenceException)
        {
            //   Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
        }
    }
    public void bind_nationality()
    {
        try
        {
            dtt = dl.bind_nationality();
            ddl_nationality.Items.Clear();
            ddl_nationality.DataSource = dtt.table;
            ddl_nationality.DataTextField = "nationality";
            ddl_nationality.DataValueField = "num_code";
            ddl_nationality.DataBind();
            ddl_nationality.Items.Insert(0, new ListItem("Select Nationality", "0"));
        }
        catch (NullReferenceException)
        {
            //   Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
        }
    }
    public void bind_page()
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
        dt = dl.bind_profile_detail_part1(bl);
        if (dt.table.Rows.Count > 0)
        {
            if (dt.table.Rows[0]["part_1"].ToString() == "Y")
            {
                submit_part1.Text = "Update";
                bl.Mode = "2";
                txt_first_name.Text = dt.table.Rows[0]["first_name"].ToString();
                txt_middle_name.Text = dt.table.Rows[0]["middle_name"].ToString();
                txt_last_name.Text = dt.table.Rows[0]["last_name"].ToString();
                ddl_gender.SelectedValue = dt.table.Rows[0]["gender"].ToString();
                mobile_no.Text = dt.table.Rows[0]["mobile"].ToString();
                email_id.Text = dt.table.Rows[0]["email_id"].ToString();
                ddl_country.SelectedValue = dt.table.Rows[0]["country"].ToString();
                bl.Country = dt.table.Rows[0]["country"].ToString();
                bind_state();
                ddl_state.SelectedValue = dt.table.Rows[0]["state"].ToString();
                bl.State = dt.table.Rows[0]["state"].ToString();
                bind_city();
                ddl_city.SelectedValue = dt.table.Rows[0]["city"].ToString();
                txt_address.Text = dt.table.Rows[0]["address_1"].ToString();
                pincode.Text = dt.table.Rows[0]["pincode"].ToString();
                ddl_age.SelectedValue = dt.table.Rows[0]["age"].ToString();
                height.Text = dt.table.Rows[0]["height"].ToString();
                weight.Text = dt.table.Rows[0]["weight"].ToString();
                ddl_nationality.SelectedValue = dt.table.Rows[0]["nationality"].ToString();
                ddl_martial.SelectedValue = dt.table.Rows[0]["martial_status"].ToString();
                ddl_blood.SelectedValue = dt.table.Rows[0]["blood_group"].ToString();
                txt_previous_medical.Text = dt.table.Rows[0]["previous_medical_history"].ToString();

                ddl_alcpohal.SelectedValue = dt.table.Rows[0]["alcoholic"].ToString();
                ddl_bp.SelectedValue = dt.table.Rows[0]["bp"].ToString();
                ddl_diabetic.SelectedValue = dt.table.Rows[0]["diabetic"].ToString();
                ddl_smoking.SelectedValue = dt.table.Rows[0]["smoking"].ToString();
                aadhar_no.Text = dt.table.Rows[0]["aadhar_no"].ToString();
                alternate_contact.Text = dt.table.Rows[0]["alternate_number"].ToString();
            }
            else
            {
                if (Request.Cookies["applicant_first_name"] != null)
                {
                    txt_first_name.Text = Request.Cookies["applicant_first_name"].Value;
                }
                if (Request.Cookies["applicant_last_name"] != null)
                {
                    txt_last_name.Text = Request.Cookies["applicant_last_name"].Value;
                }
                if (Request.Cookies["User_Id"] != null)
                {
                    mobile_no.Text = Request.Cookies["User_Id"].Value;
                }
                if (Request.Cookies["Email_ID"] != null)
                {
                    email_id.Text = Request.Cookies["Email_ID"].Value;
                }
                submit_part1.Text = "Save";
                bl.Mode = "1";
            }
        }
        else
        {
            if (Request.Cookies["applicant_first_name"] != null)
            {
                txt_first_name.Text = Request.Cookies["applicant_first_name"].Value;
            }
            if (Request.Cookies["applicant_last_name"] != null)
            {
                txt_last_name.Text = Request.Cookies["applicant_last_name"].Value;
            }
            if (Request.Cookies["User_Id"] != null)
            {
                mobile_no.Text = Request.Cookies["User_Id"].Value;
            }
            if (Request.Cookies["Email_ID"] != null)
            {
                email_id.Text = Request.Cookies["Email_ID"].Value;
            }
            submit_part1.Text = "Save";
            bl.Mode = "1";
        }

    }
    public void bind_age()
    {
        try
        {
            dtt = dl.bind_age();
            ddl_age.Items.Clear();
            ddl_age.DataSource = dtt.table;
            ddl_age.DataTextField = "Id";
            ddl_age.DataValueField = "Id";
            ddl_age.DataBind();
            ddl_age.Items.Insert(0, new ListItem("Select Age", "0"));
        }
        catch (NullReferenceException)
        {
            //   Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
        }
    }
    public void bind_country()
    {
        try
        {
            dtt = dl.bind_country();
            ddl_country.Items.Clear();
            ddl_country.DataSource = dtt.table;
            ddl_country.DataTextField = "Name";
            ddl_country.DataValueField = "Id";
            ddl_country.DataBind();
            ddl_country.Items.Insert(0, new ListItem("Select Country", "0"));
        }
        catch (NullReferenceException)
        {
            //   Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
        }
    }
    public void bind_state()
    {
        try
        {
            bl.Category = ddl_country.SelectedValue;
            dtt = dl.bind_state(bl);
            ddl_state.Items.Clear();
            ddl_state.DataSource = dtt.table;
            ddl_state.DataTextField = "Name";
            ddl_state.DataValueField = "Id";
            ddl_state.DataBind();
            ddl_state.Items.Insert(0, new ListItem("Select State", "0"));
        }
        catch (NullReferenceException)
        {
            //  Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
        }
    }
    public void bind_city()
    {
        try
        {
            bl.Category = ddl_state.SelectedValue;
            dtt = dl.bind_city(bl);
            ddl_city.Items.Clear();
            ddl_city.DataSource = dtt.table;
            ddl_city.DataTextField = "Name";
            ddl_city.DataValueField = "Id";
            ddl_city.DataBind();
            ddl_city.Items.Insert(0, new ListItem("Select City", "0"));
        }
        catch (NullReferenceException)
        {
            //   Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
        }
    }
    public void bind_gender()
    {
        try
        {
            bl.Category = "gender";
            dtt = dl.Ddl_cat_list(bl);
            ddl_gender.Items.Clear();
            ddl_gender.DataSource = dtt.table;
            ddl_gender.DataTextField = "Name";
            ddl_gender.DataValueField = "Id";
            ddl_gender.DataBind();
            ddl_gender.Items.Insert(0, new ListItem("Select Gender", "0"));
        }
        catch (NullReferenceException)
        {
            //   Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["CheckRefresh"] = Session["CheckRefresh"];
    }
    protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_state();
    }

    protected void ddl_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_city();
    }
    protected void submit_part1_Click(object sender, EventArgs e)
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

                        bl.First_name = txt_first_name.Text.Trim();
                        bl.Middle_name = txt_middle_name.Text.Trim();
                        bl.Last_name = txt_last_name.Text.Trim();
                        bl.Gender = ddl_gender.SelectedValue;
                        bl.Mobile = mobile_no.Text.Trim();
                        bl.Email_id = email_id.Text.Trim();
                        bl.Country = ddl_country.SelectedValue;
                        bl.State = ddl_state.SelectedValue;
                        bl.City = ddl_city.SelectedValue;
                        bl.Address_1 = txt_address.Text.Trim();
                        bl.Pincode = pincode.Text.Trim();
                        bl.Age = ddl_age.SelectedValue;
                        bl.Height = height.Text.Trim();
                        bl.Weight = weight.Text.Trim();
                        bl.Nationality = ddl_nationality.SelectedValue;
                        bl.Martial_status = ddl_martial.SelectedValue;
                        bl.Blood_group = ddl_blood.SelectedValue;
                        bl.Previous_medical_history = txt_previous_medical.Text.Trim();

                        bl.Alcohalic = ddl_alcpohal.SelectedValue;
                        bl.Bp = ddl_bp.SelectedValue;
                        bl.Diabetic = ddl_diabetic.SelectedValue;
                        bl.Smoking = ddl_smoking.SelectedValue;
                        bl.Aadhar = aadhar_no.Text.Trim();
                        bl.Alternate_con = alternate_contact.Text.Trim();

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
                        if (submit_part1.Text == "Save")
                        {
                            bl.Mode = "1";
                        }
                        else if (submit_part1.Text == "Update")
                        {
                            bl.Mode = "2";
                        }
                        rb = dl.Insert_user_profile_part1_details(bl);
                        if (rb.status)
                        {
                            //   Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Record Saved Succesfully", "profile_update_part2.aspx");
                            Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Profile Updated Succesfully", "User_Dashboard");
                        }
                        else
                        {
                            Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Records could not be saved: Please Try Again", "profile_update");
                        }




                    }
                    else
                        Utilities.MessageBox_UpdatePanel(UpdatePanel2, "Page Refresh or Back button is now allowed");
                }
                else
                    Utilities.MessageBox_UpdatePanel(UpdatePanel2, "Page expired!!! Please re open this page in new window.");
            }
            catch (NullReferenceException)
            {
                //Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
                Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Records could not be saved: Please Try Again", "profile_update");

            }
        }
    }
    public void GetFileUpload()
    {
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
        }
        catch (NullReferenceException)
        {
            //         Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
        }
    }

    public void GetFileUpload_report()
    {
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
            bl.Panjiyan_category_id = "repo";
            dt = dl.Getfileupload(bl);
            if (dt.table.Rows.Count > 0)
            {
                GridView2.DataSource = dt.table;
                GridView2.DataBind();
            }
            else
            {
                GridView2.DataSource = dt.table;
                GridView2.DataBind();
            }
        }
        catch (NullReferenceException)
        {
            //         Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
        }
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    ReturnClass.ReturnBool rb = new ReturnClass.ReturnBool();
                    Utilities util = new Utilities();
                    Int32 maxLimit = 10485760;
                    string content_type;
                    if (FileUpload1.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                        double size = FileUpload1.PostedFile.ContentLength;
                        string contenttype = FileUpload1.PostedFile.ContentType.ToLower();

                        if (FileUpload1.PostedFile.ContentLength > maxLimit)
                        {
                            Utilities.MessageBoxShow("File Is too Big...Maximum Size allowed is 5 Mb");
                        }
                        else if (contenttype == "image/png" || contenttype == "image/jpg" || contenttype == "image/jpeg")
                        {
                            try
                            {
                                bl.File_extn = Path.GetExtension(FileUpload1.PostedFile.FileName).ToString();
                                Stream fs = default(Stream);
                                fs = FileUpload1.PostedFile.InputStream;
                                BinaryReader br1 = new BinaryReader(fs);
                                bl.Document_data = br1.ReadBytes(FileUpload1.PostedFile.ContentLength);
                                //  FileUpload1.SaveAs(Server.MapPath("images/use_img.png"));
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
                                bl.Document_name = "Profile Picture";
                                bl.Client_id = util.GetClientIpAddress(this.Page);
                                bl.Panjiyan_category_id = "pic";
                                if (ext == ".pdf")
                                {
                                    bl.Mime_type = "application/pdf";
                                }
                                else
                                {
                                    bl.Mime_type = contenttype;
                                }

                                dt = dl.Getfileupload(bl);
                                if (dt.table.Rows.Count > 0)
                                {
                                    rb = dl.Update_Upload_details(bl);
                                }
                                else
                                {
                                    rb = dl.Upload_details(bl);
                                }
                                if (rb.status == true)
                                {
                                    Utilities.MessageBox_UpdatePanel(UpdatePanel2, "Document Upload Successfully");
                                }
                                else
                                {

                                    Utilities.MessageBoxShow("Document Upload Failed");

                                }
                                GetFileUpload();

                            }

                            catch (Exception ex)
                            {
                                Utilities.MessageBoxShow("File Can Not Be Saved");
                            }
                        }
                        else
                        {
                            Utilities.MessageBoxShow("Only  .jpg .png  .jpeg  files are allowed, try again");
                        }
                    }
                }
                else
                {
                    Utilities.MessageBox_UpdatePanel(UpdatePanel2, " पेज रिफ्रेश करना वर्जित है ");
                }
            }
            catch (NullReferenceException)
            {
                //   Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                if (Session["CheckRefresh"].ToString() == ViewState["CheckRefresh"].ToString())
                {
                    Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                    ReturnClass.ReturnBool rb = new ReturnClass.ReturnBool();
                    Utilities util = new Utilities();
                    Int32 maxLimit = 10485760;
                    string content_type;
                    if (FileUpload2.HasFile)
                    {
                        string ext = System.IO.Path.GetExtension(FileUpload2.FileName);
                        double size = FileUpload2.PostedFile.ContentLength;
                        string contenttype = FileUpload2.PostedFile.ContentType.ToLower();

                        if (FileUpload2.PostedFile.ContentLength > maxLimit)
                        {
                            Utilities.MessageBoxShow("File Is too Big...Maximum Size allowed is 5 Mb");
                        }
                        //  else if (contenttype == "image/png" || contenttype == "image/jpg" || contenttype == "image/jpeg")
                        else if (contenttype == "application/pdf" || contenttype == "application/x-pdf" || contenttype == "application/x-unknown" || contenttype == "image/gif" || contenttype == "image/png" || contenttype == "image/jpg" || contenttype == "image/jpeg")
                        {
                            try
                            {
                                bl.File_extn = Path.GetExtension(FileUpload2.PostedFile.FileName).ToString();
                                Stream fs = default(Stream);
                                fs = FileUpload2.PostedFile.InputStream;
                                BinaryReader br1 = new BinaryReader(fs);
                                bl.Document_data = br1.ReadBytes(FileUpload2.PostedFile.ContentLength);
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
                                //bl.Document_name = "Medical Report";
                                bl.Document_name = FileUpload2.PostedFile.FileName;
                                bl.Client_id = util.GetClientIpAddress(this.Page);
                                bl.Panjiyan_category_id = "repo";
                                if (ext == ".pdf")
                                {
                                    bl.Mime_type = "application/pdf";
                                }
                                else
                                {
                                    bl.Mime_type = contenttype;
                                }

                                dt = dl.Getfileupload(bl);
                                if (dt.table.Rows.Count > 0)
                                {
                                    rb = dl.Update_Upload_details(bl);
                                }
                                else
                                {
                                    rb = dl.Upload_details(bl);
                                }
                                if (rb.status == true)
                                {
                                    Utilities.MessageBox_UpdatePanel(UpdatePanel2, "Document Upload Successfully");
                                }
                                else
                                {

                                    Utilities.MessageBoxShow("Document Upload Failed");

                                }
                                GetFileUpload_report();

                            }

                            catch (Exception ex)
                            {
                                Utilities.MessageBoxShow("File Can Not Be Saved");
                            }
                        }
                        else
                        {
                            Utilities.MessageBoxShow("Only .pdf .gif .jpg .png  .jpeg  files are allowed, try again");
                        }
                    }
                }
                else
                {
                    Utilities.MessageBox_UpdatePanel(UpdatePanel2, " पेज रिफ्रेश करना वर्जित है ");
                }
            }
            catch (NullReferenceException)
            {
                //   Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
            }

        }
    }

    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        GetFileUpload_report();
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            LinkButton l = (LinkButton)e.Row.FindControl("LinkButton1");
            l.Attributes.Add("onclick", "javascript:return " +
            "confirm('Are you sure you want to delete this record')");
        }
    }

    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridView2.EditIndex = -1;
    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Delete")
        {
            try
            {
                string file_id = Convert.ToString(e.CommandArgument);
                bl.File_id = file_id;
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
                rb = dl.delete_file_upload(bl);
                if (rb.status == true)
                {
                    Utilities.MessageBox_UpdatePanel(UpdatePanel2, "Deleted Successfully");
                }
                else
                {
                    Utilities.MessageBox_UpdatePanel(UpdatePanel2, "Not Deleted ");
                }
                GetFileUpload_report();
            }
            catch (NullReferenceException)
            {
                //   Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
            }
        }
    }

    protected void Download_report_Click(object sender, EventArgs e)
    {
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
            int id = Convert.ToInt32(((LinkButton)sender).CommandArgument);
            string lol = "../online_user/Download_User.aspx?fn=" + id + "&provisional_no=" + bl.User_id;
            ScriptManager.RegisterStartupScript(this.UpdatePanel2, this.UpdatePanel2.GetType(), "key", "window.open(" + "'" + lol + " ','_blank'); ", true);
        }
        catch (NullReferenceException)
        {
            //   Utilities.MessageBox_UpdatePanel_Redirect(UpdatePanel2, "Your Session Has Expired Please Login Again", "../Logout.aspx");
        }
    }
}