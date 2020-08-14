using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for olu_ba_layer
/// </summary>
public class olu_ba_layer
{
    string user_id, client_id, date_time, first_name, middle_name, last_name, mobile, email_id, gender;
    string age, height, weight, nationality, martial_status, country, city, blood_group, address_1, address_2, address_3,
    pincode, state, gps_location, How_is_your_memory, For_what_is_it_poor, At_what_time_is_it_poor, Do_you_remember_what_you_read,
        Do_you_read_with_interest_and_pleasure, Can_you_apply_you_mind_easily, In_what_way_is_your_disposition_changed_during_sickness,
        Do_you_comprehend_easily, how_do_you_answer_the_questions_of_others, How_does_the_future_look_to_you,
        Have_you_any_delusions_of_any_kind, panjiyan_cate_id, required, category, category_id, mode, previous_medical_history
        ,bp,diabetic,aadhar,alternate_con,smoking,alcohalic,message;
    string sender_id, receiver_id, sending_date, receiving_date, isfile_,status,chat_id, user_idd, message_to, type, success;

    string rating,headline,review, payment,validity,subject, sent_method,c_year,c_month, user_type,logintimeformessage,followupchatid, follow_up_case_yes_no;
    bool isfile;
    string  s1, s, nid, aid,chatlogid,chatboxid,feedback_days,feedback_date,feedback_sent,start_date;
    string Payment_id, Payment_type, Payment_rupees, Payment_status;
    string entity, currency, order_id, invoice_id, international, method, amount_refunded, refund_status, captured, description, card_id,
        bank, wallet, vpa, email, contact, notes, fee, tax, error_code, error_description, created_at;

    string question1, question2, question3;

    string doc_name, remedy_name, potency_name, quantity;

    string class_id,subject_id,topic_id,video_id,stream_id,class_code, symptom_id, desc;
    public string Desc { get { return desc; } set { desc = value; } }
    public string Symptom_id { get { return symptom_id; } set { symptom_id = value; } }
    public string Class_code { get { return class_code; } set { class_code = value; } }
    public string Stream_id { get { return stream_id; } set { stream_id = value; } }
    public string Video_id { get { return video_id; } set { video_id = value; } }
    public string Subject_id { get { return subject_id; } set { subject_id = value; } }
    public string Topic_id { get { return topic_id; } set { topic_id = value; } }
    public string Class_id { get { return class_id; } set { class_id = value; } }
    public string Doc_name { get { return doc_name; } set { doc_name = value; } }

    public string Remedy_name { get { return remedy_name; } set { remedy_name = value; } }
    public string Potency_name { get { return potency_name; } set { potency_name = value; } }
    public string Quantity { get { return quantity; } set { quantity = value; } }
    public string Question1 { get { return question1; } set { question1 = value; } }

    public string Question2 { get { return question2; } set { question2 = value; } }
    public string Question3 { get { return question3; } set { question3 = value; } }

    public string Entity { get { return entity; } set { entity = value; } }
    public string Currency { get { return currency; } set { currency = value; } }
    public string Order_id { get { return order_id; } set { order_id = value; } }
    public string Invoice_id { get { return invoice_id; } set { invoice_id = value; } }
    public string International { get { return international; } set { international = value; } }

    public string Method { get { return method; } set { method = value; } }
    public string Amount_refunded { get { return amount_refunded; } set { amount_refunded = value; } }
    public string Refund_status { get { return refund_status; } set { refund_status = value; } }
    public string Captured { get { return captured; } set { captured = value; } }
    public string Description { get { return description; } set { description = value; } }
    public string Card_id { get { return card_id; } set { card_id = value; } }
    public string Bank { get { return bank; } set { bank = value; } }
    public string Wallet { get { return wallet; } set { wallet = value; } }
    public string Vpa { get { return vpa; } set { vpa = value; } }
    public string Email { get { return email; } set { email = value; } }
    public string Contact { get { return contact; } set { contact = value; } }
    public string Notes { get { return notes; } set { notes = value; } }
    public string Fee { get { return fee; } set { fee = value; } }
    public string Tax { get { return tax; } set { tax = value; } }
    public string Error_code { get { return error_code; } set { error_code = value; } }
    public string Error_description { get { return error_description; } set { error_description = value; } }
    public string Created_at { get { return created_at; } set { created_at = value; } }

    public string Payment_Id { get { return Payment_id; } set { Payment_id = value; } }
    public string Payment_Type { get { return Payment_type; } set { Payment_type = value; } }
    public string Payment_Rupees { get { return Payment_rupees; } set { Payment_rupees = value; } }
    public string Payment_Status { get { return Payment_status; } set { Payment_status = value; } }

    public string Follow_up_case_yes_no { get { return follow_up_case_yes_no; } set { follow_up_case_yes_no = value; } }

    public string Followupchatid { get { return followupchatid; } set { followupchatid = value; } }
    public string Start_date { get { return start_date; } set { start_date = value; } }
    public string Feedback_date { get { return feedback_date; } set { feedback_date = value; } }
    public string Feedback_sent { get { return feedback_sent; } set { feedback_sent = value; } }
    public string Feedback_days { get { return feedback_days; } set { feedback_days = value; } }
    public string Chatboxid { get { return chatboxid; } set { chatboxid = value; } }
    public string Chatlogid { get { return chatlogid; } set { chatlogid = value; } }
    public string Logintimeformessage { get { return logintimeformessage; } set { logintimeformessage = value; } }
    public string User_type { get { return user_type; } set { user_type = value; } }
    public string S1 { get { return s1; } set { s1 = value; } }
    public string S { get { return s; } set { s = value; } }
    public string Nid { get { return nid; } set { nid = value; } }
    public string Aid { get { return aid; } set { aid = value; } }
    public string C_year { get { return c_year; } set { c_year = value; } }
    public string C_month { get { return c_month; } set { c_month = value; } }
    public string Sent_method { get { return sent_method; } set { sent_method = value; } }
    public string Subject { get { return subject; } set { subject = value; } }
    public string Success { get { return success; } set { success = value; } }
    public string Type { get { return type; } set { type = value; } }
    public string Message_to { get { return message_to; } set { message_to = value; } }
    public string Payment { get { return payment; } set { payment = value; } }
    public string Validity { get { return validity; } set { validity = value; } }
    public string Chat_id { get { return chat_id; } set { chat_id = value; } }
    public string Status { get { return status; } set { status = value; } }
    public string Sender_id { get { return sender_id; } set { sender_id = value; } }
    public string Receiver_id { get { return receiver_id; } set { receiver_id = value; } }
    public string Sending_date { get { return sending_date; } set { sending_date = value; } }
    public string Receiving_date { get { return receiving_date; } set { receiving_date = value; } }
    public string Isfile_ { get { return isfile_; } set { isfile_ = value; } }
    public bool Isfile { get { return isfile; } set { isfile = value; } }
    public string Message { get { return message; } set { message = value; } }
    public string Headline { get { return headline; } set { headline = value; } }
    public string Review { get { return review; } set { review = value; } }
    public string Rating { get { return rating; } set { rating = value; } }
    public string Bp { get { return bp; } set { bp = value; } }
    public string Diabetic { get { return diabetic; } set { diabetic = value; } }
    public string Aadhar { get { return aadhar; } set { aadhar = value; } }
    public string Alternate_con { get { return alternate_con; } set { alternate_con = value; } }
    public string Smoking { get { return smoking; } set { smoking = value; } }
    public string Alcohalic { get { return alcohalic; } set { alcohalic = value; } }
    public string Mode { get { return mode; } set { mode = value; } }
    public string Category { get { return category; } set { category = value; } }
    public string Gender { get { return gender; } set { gender = value; } }
    public string User_idd { get { return user_idd; } set { user_idd = value; } }
    public string User_id { get { return user_id; } set { user_id = value; } }
    public string Client_id { get { return client_id; } set { client_id = value; } }
    public string Date_time { get { return date_time; } set { date_time = value; } }
    public string First_name { get { return first_name; } set { first_name = value; } }
    public string Middle_name { get { return middle_name; } set { middle_name = value; } }
    public string Last_name { get { return last_name; } set { last_name = value; } }
    public string Mobile { get { return mobile; } set { mobile = value; } }
    public string Email_id { get { return email_id; } set { email_id = value; } }
    ////
    public string Age { get { return age; } set { age = value; } }
    public string Height { get { return height; } set { height = value; } }
    public string Weight { get { return weight; } set { weight = value; } }
    public string Nationality { get { return nationality; } set { nationality = value; } }
    public string Martial_status { get { return martial_status; } set { martial_status = value; } }
    public string Country { get { return country; } set { country = value; } }
    public string City { get { return city; } set { city = value; } }
    
        public string Previous_medical_history { get { return previous_medical_history; } set { previous_medical_history = value; } }
    public string Blood_group { get { return blood_group; } set { blood_group = value; } }
    public string Address_1 { get { return address_1; } set { address_1 = value; } }
    public string Address_2 { get { return address_2; } set { address_2 = value; } }
    public string Address_3 { get { return address_3; } set { address_3 = value; } }
    public string Pincode { get { return pincode; } set { pincode = value; } }
    public string State { get { return state; } set { state = value; } }
    public string Gps_location { get { return gps_location; } set { gps_location = value; } }
    public string HOw_is_your_memory { get { return How_is_your_memory; } set { How_is_your_memory = value; } }
    public string FOr_what_is_it_poor { get { return For_what_is_it_poor; } set { For_what_is_it_poor = value; } }
    public string AT_what_time_is_it_poor { get { return At_what_time_is_it_poor; } set { At_what_time_is_it_poor = value; } }
    public string DO_you_remember_what_you_read { get { return Do_you_remember_what_you_read; } set { Do_you_remember_what_you_read = value; } }
    public string DO_you_read_with_interest_and_pleasure { get { return Do_you_read_with_interest_and_pleasure; } set { Do_you_read_with_interest_and_pleasure = value; } }
    public string CAn_you_apply_you_mind_easily { get { return Can_you_apply_you_mind_easily; } set { Can_you_apply_you_mind_easily = value; } }
    public string IN_what_way_is_your_disposition_changed_during_sickness { get { return In_what_way_is_your_disposition_changed_during_sickness; } set { In_what_way_is_your_disposition_changed_during_sickness = value; } }
    public string DO_you_comprehend_easily { get { return Do_you_comprehend_easily; } set { Do_you_comprehend_easily = value; } }
    public string How_do_you_answer_the_questions_of_others { get { return how_do_you_answer_the_questions_of_others; } set { how_do_you_answer_the_questions_of_others = value; } }
    public string HOw_does_the_future_look_to_you { get { return How_does_the_future_look_to_you; } set { How_does_the_future_look_to_you = value; } }
    public string HAve_you_any_delusions_of_any_kind { get { return Have_you_any_delusions_of_any_kind; } set { Have_you_any_delusions_of_any_kind = value; } }
    public string Panjiyan_cate_id { get { return panjiyan_cate_id; } set { panjiyan_cate_id = value; } }
    public string Required { get { return required; } set { required = value; } }
    public string Category_id { get { return category_id; } set { category_id = value; } }

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