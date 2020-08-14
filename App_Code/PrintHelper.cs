﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for PrintHelper
/// </summary>
public class PrintHelper
{
   
    public static void PrintWebControl(Control ctrl)
    {

        PrintWebControl(ctrl, string.Empty);

    }
    private static string RenderControl(Control ctrl)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter writer = new HtmlTextWriter(sw);

        ctrl.RenderControl(writer);
        return sb.ToString();
    }
    public static void PrintWebControl(Control ctrl, string Script)
    {

        StringWriter stringWrite = new StringWriter();

        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

        if (ctrl is WebControl)
        {

            Unit w = new Unit(100, UnitType.Percentage); ((WebControl)ctrl).Width = w;

        }

        Page pg = new Page();

        pg.EnableEventValidation = false;

        if (Script != string.Empty)
        {

            pg.ClientScript.RegisterStartupScript(pg.GetType(), "PrintJavaScript", Script);

        }

        HtmlForm frm = new HtmlForm();

        pg.Controls.Add(frm);

        frm.Attributes.Add("runat", "server");

        frm.Controls.Add(ctrl);

        pg.DesignerInitialize();

        //pg.RenderControl(htmlWrite);

        //string strHTML = stringWrite.ToString();
        string strHTML = RenderControl(pg);
       
        HttpContext.Current.Response.Clear();

        HttpContext.Current.Response.Write(strHTML);

        HttpContext.Current.Response.Write("<script>window.print();</script>");

        HttpContext.Current.Response.End();

    }
}