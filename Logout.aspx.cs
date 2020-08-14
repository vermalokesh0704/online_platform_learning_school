using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session.Abandon();
        Session.Clear();
        Session.RemoveAll(); try
        {
            //Response.Cookies["User"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Request.Cookies.Clear();
            }

            HttpCookie aCookie;
            string cookieName;
            int limit = Request.Cookies.Count;
            for (int i = 0; i < limit; i++)
            {
                cookieName = Request.Cookies[i].Name;
                aCookie = new HttpCookie(cookieName);
                aCookie.Expires = DateTime.Now.AddDays(-1); // make it expire yesterday
                Response.ClearHeaders();
                Response.Cookies.Add(aCookie); // overwrite it
                //Response.Cache.SetCacheability(HttpCacheability.Private);
                //Response.Cache.SetNoStore();
                //Response.AddHeader("Cache-Control", "no-cache, no-store, max-age=0, must-revalidate");
                //Response.AddHeader("Pragma", "no-cache");
            }
        }
        catch { }

        Response.Redirect("Reports/Login.aspx");
    }
}