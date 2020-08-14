using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    upload_doc fu = new upload_doc();
    Utilities util = new Utilities();
    ReturnClass.ReturnBool rb = new ReturnClass.ReturnBool();
    ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
    da_upload_doc da = new da_upload_doc();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Session["CheckRefresh"] = Server.UrlDecode(System.DateTime.Now.ToString());
            
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["CheckRefresh"] = Session["CheckRefresh"];
    }
   

   
    
}