using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for doc_ba_layer
/// </summary>
public class doc_ba_layer
{
    string user_id, client_id, date_time, first_name, middle_name, last_name, registration, mobile, email_id, state, working_hour_from_timing, working_hour_to_timing,
        alternate_contact, land_line, pratice_at, country, city, address, pincode, gstin_no, doctor_consultation_fee,mode,
        first_time_fee, working_hour_from, working_hour_to, consultation_fee, follow_up, free_checkup, degree_name,category_id,
        university_name, college_name, degree_from, degree_to, complition_time, percentage, upload, profile_upload,gender,category,message,type, success, message_to;
    string monday, tuesday, wednesday, thursday, friday, saturday, sunday, degree_id, review, logintimeformessage, status;
    string bank_name, branch_name, ifsc_code, account_number,internship_from, internship_to, internship_details,total_experience,citizenship,about_me;

    public string Internship_from { get { return internship_from; } set { internship_from = value; } }
    public string Internship_to { get { return internship_to; } set { internship_to = value; } }
    public string Internship_details { get { return internship_details; } set { internship_details = value; } }
    public string Total_experience { get { return total_experience; } set { total_experience = value; } }
    public string Citizenship { get { return citizenship; } set { citizenship = value; } }
    public string About_me { get { return about_me; } set { about_me = value; } }

    public string Bank_name { get { return bank_name; } set { bank_name = value; } }
    public string Branch_name { get { return branch_name; } set { branch_name = value; } }
    public string Ifsc_code { get { return ifsc_code; } set { ifsc_code = value; } }
    public string Account_number { get { return account_number; } set { account_number = value; } }
    public string Status { get { return status; } set { status = value; } }
    public string Logintimeformessage { get { return logintimeformessage; } set { logintimeformessage = value; } }
    public string Review { get { return review; } set { review = value; } }
    public string Monday { get { return monday; } set { monday = value; } }
    public string Tuesday { get { return tuesday; } set { tuesday = value; } }
    public string Wednesday { get { return wednesday; } set { wednesday = value; } }
    public string Thursday { get { return thursday; } set { thursday = value; } }
    public string Friday { get { return friday; } set { friday = value; } }
    public string Saturday { get { return saturday; } set { saturday = value; } }
    public string Sunday { get { return sunday; } set { sunday = value; } }
    public string Degree_id { get { return degree_id; } set { degree_id = value; } }
    public string Category_id { get { return category_id; } set { category_id = value; } }
    public string Mode { get { return mode; } set { mode = value; } }
    public string Success { get { return success; } set { success = value; } }
    public string Type { get { return type; } set { type = value; } }
    public string Working_hour_from_timing { get { return working_hour_from_timing; } set { working_hour_from_timing = value; } }
    public string Working_hour_to_timing { get { return working_hour_to_timing; } set { working_hour_to_timing = value; } }
    public string Message_to { get { return message_to; } set { message_to = value; } }
    public string Message { get { return message; } set { message = value; } }
    public string Category { get { return category; } set { category = value; } }
    public string Gender { get { return gender; } set { gender = value; } }
    public string User_id { get { return user_id; } set { user_id = value; } }
    public string Client_id { get { return client_id; } set { client_id = value; } }
    public string Date_time { get { return date_time; } set { date_time = value; } }
    public string First_name { get { return first_name; } set { first_name = value; } }
    public string Middle_name { get { return middle_name; } set { middle_name = value; } }
    public string Last_name { get { return last_name; } set { last_name = value; } }
    public string Registration { get { return registration; } set { registration = value; } }
    public string Mobile { get { return mobile; } set { mobile = value; } }
    public string Email_id { get { return email_id; } set { email_id = value; } }
    public string Alternate_contact { get { return alternate_contact; } set { alternate_contact = value; } }
    public string Land_line { get { return land_line; } set { land_line = value; } }
    public string Pratice_at { get { return pratice_at; } set { pratice_at = value; } }
    public string Country { get { return country; } set { country = value; } }
    public string State { get { return state; } set { state = value; } }
    public string City { get { return city; } set { city = value; } }
    public string Address { get { return address; } set { address = value; } }
    public string Pincode { get { return pincode; } set { pincode = value; } }
    public string Gstin_no { get { return gstin_no; } set { gstin_no = value; } }
    public string Doctor_consultation_fee { get { return doctor_consultation_fee; } set { doctor_consultation_fee = value; } }
    public string First_time_fee { get { return first_time_fee; } set { first_time_fee = value; } }
    public string Working_hour_from { get { return working_hour_from; } set { working_hour_from = value; } }
    public string Working_hour_to { get { return working_hour_to; } set { working_hour_to = value; } }
    public string Consultation_fee { get { return consultation_fee; } set { consultation_fee = value; } }
    public string Follow_up { get { return follow_up; } set { follow_up = value; } }
    public string Free_checkup { get { return free_checkup; } set { free_checkup = value; } }
    public string Degree_name { get { return degree_name; } set { degree_name = value; } }
    public string University_name { get { return university_name; } set { university_name = value; } }
    public string College_name { get { return college_name; } set { college_name = value; } }
    public string Degree_from { get { return degree_from; } set { degree_from = value; } }
    public string Degree_to { get { return degree_to; } set { degree_to = value; } }
    public string Complition_time { get { return complition_time; } set { complition_time = value; } }
    public string Percentage { get { return percentage; } set { percentage = value; } }
    public string Upload { get { return upload; } set { upload = value; } }
    public string Profile_upload { get { return profile_upload; } set { profile_upload = value; } }


    string action_id, provisional_no, file_id, document_name, mime_type, file_extn, client_ip, entry_datetime, panjiyan_category_id, panjiyan_category_id1, session;
    public string Action_id { get { return action_id; } set { action_id = value; } }
    public string Session { get { return session; } set { session = value; } }
    public string Provisional_no { get { return provisional_no; } set { provisional_no = value; } }
    public string File_id { get { return file_id; } set { file_id = value; } }
    public string Document_name { get { return document_name; } set { document_name = value; } }
    public string Mime_type { get { return mime_type; } set { mime_type = value; } }
    public string File_extn { get { return file_extn; } set { file_extn = value; } }
    public string Entry_datetime { get { return entry_datetime; } set { entry_datetime = value; } }
    public string Panjiyan_category_id { get { return panjiyan_category_id; } set { panjiyan_category_id = value; } }
    public string Panjiyan_category_id1 { get { return panjiyan_category_id1; } set { panjiyan_category_id1 = value; } }
    byte[] file_data;
    byte[] document_data;
    public byte[] Document_data { get { return document_data; } set { document_data = value; } }
    public byte[] File_Data { get { return file_data; } set { file_data = value; } }


}