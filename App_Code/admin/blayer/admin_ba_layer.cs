using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for admin_ba_layer
/// </summary>
public class admin_ba_layer
{
    public admin_ba_layer()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    int chkselectcount;
    public int Chkselectcount { get { return chkselectcount; } set { chkselectcount = value; } }
    string reason,user_id, client_id, date_time, applicant_id, applicant_mobile, type, message_to, mobile, first_name, message, success,status;
    public string User_id { get { return user_id; } set { user_id = value; } }
    public string Status { get { return status; } set { status = value; } }

    public string Client_id { get { return client_id; } set { client_id = value; } }
    public string Date_time { get { return date_time; } set { date_time = value; } }
    public string Applicant_id { get { return applicant_id; } set { applicant_id = value; } }

    public string Reason { get { return reason; } set { reason = value; } }
    public string Applicant_mobile { get { return applicant_mobile; } set { applicant_mobile = value; } }


    public string Type { get { return type; } set { type = value; } }
    public string Message_to { get { return message_to; } set { message_to = value; } }

    public string Mobile { get { return mobile; } set { mobile = value; } }

    public string First_name { get { return first_name; } set { first_name = value; } }
    public string Message { get { return message; } set { message = value; } }

    public string Success { get { return success; } set { success = value; } }
}