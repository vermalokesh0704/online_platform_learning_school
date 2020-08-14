using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Control_testimonials : System.Web.UI.UserControl
{
    olu_ba_layer bl = new olu_ba_layer();
    olu_da_layer dl = new olu_da_layer();
    Utilities util = new Utilities();
    ReturnClass.ReturnDataTable dt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnDataTable dtt = new ReturnClass.ReturnDataTable();
    ReturnClass.ReturnBool rb = new ReturnClass.ReturnBool();
    protected void Page_Load(object sender, EventArgs e)
    {
        dt = dl.bind_testimonial();
        StringBuilder htmlTable = new StringBuilder();
        if (dt.table.Rows.Count > 0)
        {
            foreach (DataRow row in dt.table.Rows)
            {
                htmlTable.AppendLine("<div class=\"item\">");
                htmlTable.AppendLine("<div class=\"testimonial theme-bg bottom_pos\">");
                htmlTable.AppendLine("<div class=\"testimonial-avatar\">");
                htmlTable.AppendLine("<img src=\"Handler.ashx?id=" + row["file_id"].ToString() + "\" width=\"100\" height=\"104px\"  /> </div>");
                htmlTable.AppendLine("<div class=\"testimonial-info\">"+row["testimonial"] +"</div>");
                htmlTable.AppendLine("<div class=\"author-info\"><strong>" + row["name"] + " <br><span>Cell Salt User</span></strong> </div>");
                htmlTable.AppendLine("</div></div>");
                Literal1.Text = htmlTable.ToString();
            }
        }
    }
}