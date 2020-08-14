using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for bl_Usr_Registration
/// </summary>
public class bl_Usr_Registration
{

    string family_member,applicant_active, applicant_mobile_verified, applicant_email_verified, seed;
   

        string applicant_id, name,last_name, address, address1, state, district, applied_for_state, change_pwd, active, role_id, created_by, tashil, tashilname, village, villagename, area, dic, dicname, ext, category, activity, operation, ancillary, month, year, organization, ent_address;
        string pincode, pincode1, telephone_no, telephone1_no, fax_no, fax1_no, client_ip, districtname, password_plain, statename, user_id, em1_memorandum_no, Ack, issue_date, power_req_status;
        string cell_no, cell1_no, aadhar_no, email, email1, website, website1, password, verified, conf_password, provisinal_no, em1_provisinal_no, mime_type, docname1, docname2, docname3, docname4, organization_type, queryrelated, querydetails, query_reference_no, subject, remark, login_id;
        byte[] pdfbytes;
        string random_no, stake_in_other, em1_app_no, amnd_no, action_id, action_date, send_mapping_id, receive_mapping_id, status, action, emp_id, district_code, eM1_Applicant_Id, em1_applicant_type, applicant_type, cast, gender;
        string blacklistedProduct_Id, amndmessage, approve, office_code,user_type,message, success,type, refer_code, message_to,country_code;
        string stream,classes;
        Utilities util = new Utilities();
    public string Stream { get { return stream; } set { stream = value; } }
    public string Classes { get { return classes; } set { classes = value; } }
    public string Family_member { get { return family_member; } set { family_member = value; } }
    public string Country_code { get { return country_code; } set { country_code = value; } }
    public string Message_to { get { return message_to; } set { message_to = value; } }
    public string Refer_code { get { return refer_code; } set { refer_code = value; } }
    public string Message { get { return message; } set { message = value; } }
    public string Success { get { return success; } set { success = value; } }
    public string Type { get { return type; } set { type = value; } }
    public string Seed { get { return seed; } set { seed = value; } }
    public string User_type { get { return user_type; } set { user_type = value; } }
    public string Applicant_active { get { return applicant_active; } set { applicant_active = value; } }
    public string Applicant_mobile_verified { get { return applicant_mobile_verified; } set { applicant_mobile_verified = value; } }
    public string Applicant_email_verified { get { return applicant_email_verified; } set { applicant_email_verified = value; } }
    public string Last_name { get { return last_name; } set { last_name = value; } }
    public string Subject { get { return subject; } set { subject = value; } }
        public string Provisinal_No { get { return provisinal_no; } set { provisinal_no = value; } }
        public string Applicant_Id { get { return applicant_id; } set { applicant_id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string Address1 { get { return address1; } set { address1 = value; } }
        public string State { get { return state; } set { state = value; } }
        public string District { get { return district; } set { district = value; } }
        public string PinCode { get { return pincode; } set { pincode = value; } }
        public string PinCode1 { get { return pincode1; } set { pincode1 = value; } }
        public string Verified { get { return verified; } set { verified = value; } }
        public string Telephone_No { get { return telephone_no; } set { telephone_no = value; } }
        public string Telephone1_No { get { return telephone1_no; } set { telephone1_no = value; } }
        public string Fax_No { get { return fax_no; } set { fax_no = value; } }
        public string Fax1_No { get { return fax1_no; } set { fax1_no = value; } }
        public string Cell_No { get { return cell_no; } set { cell_no = value; } }
        public string Cell1_No { get { return cell1_no; } set { cell1_no = value; } }
        public string Adhar_No { get { return aadhar_no; } set { aadhar_no = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Email1 { get { return email1; } set { email1 = value; } }
        public string Website { get { return website; } set { website = value; } }
        public string Website1 { get { return website1; } set { website1 = value; } }
        public string Password { get { return password; } set { password = util.GenerateMd5Hash(value); } }
        public string Password_Plain { get { return password_plain; } set { password_plain = value; } }
        public string Confirm_Password { get { return conf_password; } set { conf_password = util.GenerateMd5Hash(value); } }
        public string Applied_for_State { get { return applied_for_state; } set { applied_for_state = value; } }
        public string ClientIp { get { return client_ip; } set { client_ip = value; } }
        public string DistrictName { get { return districtname; } set { districtname = value; } }
        public string Change_Pwd { get { return change_pwd; } set { change_pwd = value; } }
        public string Active { get { return active; } set { active = value; } }
        public string Role_Id { get { return role_id; } set { role_id = value; } }
        public string Created_By { get { return created_by; } set { created_by = value; } }
        public string Tashil { get { return tashil; } set { tashil = value; } }
        public string TashilName { get { return tashilname; } set { tashilname = value; } }
        public string Village { get { return village; } set { village = value; } }
        public string VillageName { get { return villagename; } set { villagename = value; } }
        public string Area { get { return area; } set { area = value; } }
        public string DIC { get { return dic; } set { dic = value; } }
        public string DICName { get { return dicname; } set { dicname = value; } }
        public byte[] PDFBytes { get { return pdfbytes; } set { pdfbytes = value; } }
        public string Extention { get { return ext; } set { ext = value; } }
        public string Category { get { return category; } set { category = value; } }
        public string Activity { get { return activity; } set { activity = value; } }
        public string Operation { get { return operation; } set { operation = value; } }
        public string Ancillary { get { return ancillary; } set { ancillary = value; } }
        public string Month { get { return month; } set { month = value; } }
        public string Year { get { return year; } set { year = value; } }
        public string Organization { get { return organization; } set { organization = value; } }
        public string StateName { get { return statename; } set { statename = value; } }
        public string User_Id { get { return user_id; } set { user_id = value; } }

        public string Em1_provisinal_no { get { return em1_provisinal_no; } set { em1_provisinal_no = value; } }

        public string Docname1 { get { return docname1; } set { docname1 = value; } }
        public string Mime_type { get { return mime_type; } set { mime_type = value; } }
        public string Docname2 { get { return docname2; } set { docname2 = value; } }
        public string Docname3 { get { return docname3; } set { docname3 = value; } }
        public string Docname4 { get { return docname4; } set { docname4 = value; } }
        public string Organization_Type { get { return organization_type; } set { organization_type = value; } }
        public string Em1_Memorandum_No { get { return em1_memorandum_no; } set { em1_memorandum_no = value; } }
        public string ACK { get { return Ack; } set { Ack = value; } }
        public string Issue_Date { get { return issue_date; } set { issue_date = value; } }
        public string Power_Req_Status { get { return power_req_status; } set { power_req_status = value; } }
        public string QueryRelated { get { return queryrelated; } set { queryrelated = value; } }
        public string QueryDetails { get { return querydetails; } set { querydetails = value; } }
        public string Query_Reference_no { get { return query_reference_no; } set { query_reference_no = value; } }
        public string Remark { get { return remark; } set { remark = value; } }
        public string Login_Id { get { return login_id; } set { login_id = value; } }
        public string Random_No { get { return random_no; } set { random_no = value; } }
        public string Stake_In_Other { get { return stake_in_other; } set { stake_in_other = value; } }
        public string EM1_App_No { get { return em1_app_no; } set { em1_app_no = value; } }
        public string Amnd_No { get { return amnd_no; } set { amnd_no = value; } }
        public string Address_PL { get { return ent_address; } set { ent_address = value; } }


        public string Action_Id { get { return action_id; } set { action_id = value; } }
        public string Action_Date { get { return action_date; } set { action_date = value; } }
        public string S_Mapping_Id { get { return send_mapping_id; } set { send_mapping_id = value; } }
        public string R_Mapping_Id { get { return receive_mapping_id; } set { receive_mapping_id = value; } }
        public string Status { get { return status; } set { status = value; } }
        public string Action { get { return action; } set { action = value; } }
        public string Emp_Id { get { return emp_id; } set { emp_id = value; } }
        public string District_Code { get { return district_code; } set { district_code = value; } }
        public string EM1_Applicant_Id { get { return eM1_Applicant_Id; } set { eM1_Applicant_Id = value; } }
        public string ApplicantCategory { get { return applicant_type; } set { applicant_type = value; } }
        public string Em1_ApplicantType { get { return em1_applicant_type; } set { em1_applicant_type = value; } }
        public string Cast { get { return cast; } set { cast = value; } }
        public string Gender { get { return gender; } set { gender = value; } }

        public string BlacklistedProduct_Id { get { return blacklistedProduct_Id; } set { blacklistedProduct_Id = value; } }
        public string AmndMessage { get { return amndmessage; } set { amndmessage = value; } }
        public string Approve { get { return approve; } set { approve = value; } }
        public string Office_Code { get { return office_code; } set { office_code = value; } }
    }
public class LoginTrail
{
    string user_id, client_ip, client_os, client_browser, useragent;

    public string User_Id { get { return user_id; } set { user_id = value; } }
    public string Client_Ip { get { return client_ip; } set { client_ip = value; } }
    public string Client_Os { get { return client_os; } set { client_os = value; } }
    public string Client_Browser { get { return client_browser; } set { client_browser = value; } }
    public string UserAgent { get { return useragent; } set { useragent = value; } }
}
