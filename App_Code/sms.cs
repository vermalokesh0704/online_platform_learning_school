using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.IO;

/// <summary>
/// Summary description for sms
/// </summary>
public class sms
{
    //string user_name = "jndcg.auth", password = "Bd*68Lh%24", sender = "NICSMS";
    string user_name = "cpmg.sms", password = "M@r16%23NMa", sender = "NICSMS";

    

    public string send_normal_sms(string mob_no, string msgt)
    {
        Int16 concat;
        int lt = msgt.Length;
        if (lt < 160)
        {
            concat = 0;
        }
        else
        {
            concat = 1;
        }
        string msg_rpt = null, body = null;
        string s = msgt;
        body = "username=" + user_name + "&pin=" + password + "&signature=" + sender + "&mnumber=91" + mob_no + "&message=" + msgt;// +"&concat=" + concat; 
        try
        {
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://smsgw72.nic.in/sendsms_nic/sendmsg.php?" + body);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://smsgw.sms.gov.in/failsafe/HttpLink?" + body);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            String ver = response.ProtocolVersion.ToString();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            return msg_rpt = reader.ReadToEnd();
        }
        catch
        {
            return msg_rpt = "failure";
        }
    }

    public string send_unicode_sms(string mob_no, string msg)
    {
        // This method is for sending unicode sms which manages the sms id & part according to its length 
        string msg_rpt = null, body;
        string msg_text = "", msg_body1 = "";
        string s = msg;
        int len = 1, counter = 1, single_sms_length = 268;
        //body = "username=" + user_name + "&pin=" + password + "&signature=" + sender + "&mnumber=" + mob_no + "&udhi=1&dcs=8&msg=";
        body = "username=" + user_name + "&pin=" + password + "&signature=" + sender + "&mnumber=" + mob_no + "&msgType=UC&message=";
        int msg_length = s.Length;
        len = s.Length;// / 269;
        try
        {
            //for (int i = 1; i <= len; i++)
            //{
            int lt = s.Length;
            string mt = s;
            foreach (char c in s)
            {
                //if (counter <= single_sms_length)
                //{
                msg_body1 += c;
                counter++;
                //}
                //else
                //{
                //    break;
                //}
            }
            //msg_text = "050003FA0" + len + "0" + i + msg_body1;
            msg_text = msg_body1;
            int l = msg_text.Length;
            //HttpWebRequest request_large = (HttpWebRequest)WebRequest.Create("http://smsgw.nic.in/sendsms_nic/sendmsg.php?" + body + msg_text);
            HttpWebRequest request_large = (HttpWebRequest)WebRequest.Create("https://smsgw.sms.gov.in/failsafe/HttpLink?" + body + msg_text);
            HttpWebResponse response_large = (HttpWebResponse)request_large.GetResponse();
            String ver_large = response_large.ProtocolVersion.ToString();
            StreamReader reader_large = new StreamReader(response_large.GetResponseStream());
            msg_rpt = reader_large.ReadToEnd();
            //single_sms_length += 268;
            //if (s.Length > 268)
            //{
            //    s = s.Remove(1, 268);
            //}
            msg_body1 = "";

            //}
            return msg_rpt;
        }
        catch (Exception f)
        {
            return msg_rpt = "failure";
        }
    }

    //=====sms sending=======
    //public string send_unicode_sms(string mob_no, string msg)
    //{
    //    // This method is for sending unicode sms which manages the sms id & part according to its length 
    //    string msg_rpt = null, body;
    //    string msg_text = "", msg_body1 = "";
    //    string s = msg;
    //    int len = 1, counter = 1, single_sms_length = 268;
    //    //body = "username=" + user_name + "&pin=" + password + "&signature=" + sender + "&mnumber=" + mob_no + "&udhi=1&dcs=8&msg=";
    //    body = "username=" + user_name + "&pin=" + password + "&signature=" + sender + "&mnumber=" + mob_no + "&msgType=UC&message=";
    //    int msg_length = s.Length;
    //    len += s.Length / 269;
    //    try
    //    {
    //        for (int i = 1; i <= len; i++)
    //        {
    //            int lt = s.Length;
    //            string mt = s;
    //            foreach (char c in s)
    //            {
    //                if (counter <= single_sms_length)
    //                {
    //                    msg_body1 += c;
    //                    counter++;
    //                }
    //                else
    //                {
    //                    break;
    //                }
    //            }
    //            msg_text = "050003FA0" + len + "0" + i + msg_body1;
    //            int l = msg_text.Length;
    //            //HttpWebRequest request_large = (HttpWebRequest)WebRequest.Create("http://smsgw.nic.in/sendsms_nic/sendmsg.php?" + body + msg_text);
    //            HttpWebRequest request_large = (HttpWebRequest)WebRequest.Create("http://smsgw.sms.gov.in/failsafe/HttpLink?" + body + msg_text);
    //            HttpWebResponse response_large = (HttpWebResponse)request_large.GetResponse();
    //            String ver_large = response_large.ProtocolVersion.ToString();
    //            StreamReader reader_large = new StreamReader(response_large.GetResponseStream());
    //            msg_rpt = reader_large.ReadToEnd();
    //            single_sms_length += 268;
    //            if (s.Length > 268)
    //            {
    //                s = s.Remove(1, 268);
    //            }
    //            msg_body1 = "";

    //        }
    //        return msg_rpt;
    //    }
    //    catch (Exception f)
    //    {
    //        return msg_rpt = "failure";
    //    }
    //}

    public string convert_hex(string msg)
    {
        // This method is for sending unicode sms which manages the sms id & part according to its length
        string get_msg_len = "";
        string s = msg;
        foreach (char c in s)
        {
            int tmp = c;
            get_msg_len += String.Format("{0:x4}", (uint)System.Convert.ToUInt16(tmp.ToString()));
        }

        return get_msg_len;
    }

    public string HexToString(string HexValue)
    {
        string StrValue = "";
        while (HexValue.Length > 0)
        {
            StrValue += System.Convert.ToChar(System.Convert.ToUInt32(HexValue.Substring(0, 4), 16)).ToString();
            HexValue = HexValue.Substring(4, HexValue.Length - 4);
        }
        return StrValue;
    }

}