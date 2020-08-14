using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for upload_doc
/// </summary>
public class upload_doc
{
    public upload_doc()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    string action_id, provisional_no, file_id, document_name, mime_type, file_extn, client_ip, user_id, entry_datetime, panjiyan_category_id, panjiyan_category_id1, session;
    public string Action_id { get { return action_id; } set { action_id = value; } }
    public string Session { get { return session; } set { session = value; } }
    public string Provisional_no { get { return provisional_no; } set { provisional_no = value; } }
    public string File_id { get { return file_id; } set { file_id = value; } }
    public string Document_name { get { return document_name; } set { document_name = value; } }
    public string Mime_type { get { return mime_type; } set { mime_type = value; } }
    public string File_extn { get { return file_extn; } set { file_extn = value; } }
    public string Client_ip { get { return client_ip; } set { client_ip = value; } }
    public string User_id { get { return user_id; } set { user_id = value; } }
    public string Entry_datetime { get { return entry_datetime; } set { entry_datetime = value; } }
    public string Panjiyan_category_id { get { return panjiyan_category_id; } set { panjiyan_category_id = value; } }
    public string Panjiyan_category_id1 { get { return panjiyan_category_id1; } set { panjiyan_category_id1 = value; } }


    byte[] file_data;


    public byte[] File_Data { get { return file_data; } set { file_data = value; } }



    int society_document_id;
    byte[] document_data;




    public byte[] Document_data { get { return document_data; } set { document_data = value; } }
}