using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for bl_common
/// </summary>
public class bl_common
{
    string desc_text,category, symptom_id,cellsalt_id, cellsalt_single,desc,user_id,client_ip,date_time,u_category,y_category, file_id,class_code;

    public string Class_code { get { return class_code; } set { class_code = value; } }
    public string File_id { get { return file_id; } set { file_id = value; } }
    public string U_category { get { return u_category; } set { u_category = value; } }
    public string Y_category { get { return y_category; } set { y_category = value; } }
    public string Date_time { get { return date_time; } set { date_time = value; } }
    public string Client_ip { get { return client_ip; } set { client_ip = value; } }
    public string User_id { get { return user_id; } set { user_id = value; } }
    public string Desc { get { return desc; } set { desc = value; } }
    public string Desc_text { get { return desc_text; } set { desc_text = value; } }
    public string Cellsalt_single { get { return cellsalt_single; } set { cellsalt_single = value; } }
    public string Cellsalt_id { get { return cellsalt_id; } set { cellsalt_id = value; } }

    public string Category { get { return category; } set { category = value; } }
    public string Symptom_id { get { return symptom_id; } set { symptom_id = value; } }
}