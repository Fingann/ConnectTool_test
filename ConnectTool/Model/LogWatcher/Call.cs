using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectTool.Model.LogWatcher
{

    public class Calls
    {
        public Call[] CallsLog { get; set; }
    }

    public class Call
    {
        public string accessNo { get; set; }
        public string accessToken { get; set; }
        public string adhocAktiv { get; set; }
        public string AuthenticateCode { get; set; }
        public string AuthenticatePwd { get; set; }
        public string AuthenticateToken { get; set; }
        public string AuthenticateUser { get; set; }
        public string bNumDesc { get; set; }
        public string call_tag { get; set; }
        public string callerDescription { get; set; }
        public string CatalogPhoneSearchDone { get; set; }
        public string catalogPhoneSearchResult { get; set; }
        public string catalogToSearch { get; set; }
        public string ciq_active { get; set; }
        public string ciq_destination { get; set; }
        public string ContactFirstName_1 { get; set; }
        public string ContactLastName_1 { get; set; }
        public string crmdb_contact_name { get; set; }
        public string crmdb_lastcall_agent_names { get; set; }
        public string crmdb_lastcall_log_id { get; set; }
        public string crmdb_lastcall_start { get; set; }
        public string crmdb_more_calls { get; set; }
        public string crmKml { get; set; }
        public string current_state { get; set; }
        public string dtmftone_detection_mode { get; set; }
        public string eh_wav_caller_hangup { get; set; }
        public string eh_wav_ciq_call_caller { get; set; }
        public string eh_wav_ciq_unavailable { get; set; }
        public string eh_wav_hold { get; set; }
        public string eh_wav_screened { get; set; }
        public string eh_wav_unavailable { get; set; }
        public string lindorf_serviceid { get; set; }
        public string LogCallExit { get; set; }
        public string min { get; set; }
        public string NumOfContacts { get; set; }
        public string popup_name { get; set; }
        public string propertyValue { get; set; }
        public string qSize { get; set; }
        public string queueaverage_speak_time { get; set; }
        public string recordingActive { get; set; }
        public string result { get; set; }
        public string service { get; set; }
        public string serviceAdHoc { get; set; }
        public string setBackgroundColor { get; set; }
        public string system_absolute_uri { get; set; }
        public string system_accessno { get; set; }
        public string system_base_uri { get; set; }
        public string system_call_progress { get; set; }
        public string system_CalledPartyNumber { get; set; }
        public string system_caller_ano { get; set; }
        public string system_caller_progress { get; set; }
        public string system_CallingPartyNumber { get; set; }
        public string system_CallingPartyNumberRestriction { get; set; }
        public string system_country { get; set; }
        public string system_custkey { get; set; }
        public string system_DefaultCallingPartyNumber { get; set; }
        public string system_deny_recording { get; set; }
        public string system_encoding { get; set; }
        public string system_guid { get; set; }
        public string system_hostip { get; set; }
        public string system_hostname { get; set; }
        public string system_iq_cc_uri { get; set; }
        public string system_iqid { get; set; }
        public string system_is_out_of_the_blue { get; set; }
        public string system_kml { get; set; }
        public string system_last_called { get; set; }
        public string system_last_user_id { get; set; }
        public string system_last_user_num { get; set; }
        public string system_name { get; set; }
        public string system_numbers { get; set; }
        public string system_queue_agents { get; set; }
        public string system_queue_available_agents { get; set; }
        public string system_queue_estimate { get; set; }
        public string system_queue_id { get; set; }
        public string system_queue_key { get; set; }
        public string system_queue_place { get; set; }
        public string system_queue_time { get; set; }
        public string system_queue_wait_by_last_calls { get; set; }
        public string system_queue_wait_by_last_minutes { get; set; }
        public string system_RedirectingNumber { get; set; }
        public string system_RemoveSecretAnoIfAdditional { get; set; }
        public string system_secret_caller { get; set; }
        public string system_secret_number { get; set; }
        public string system_session_id { get; set; }
        public string system_version { get; set; }
        public string textColor { get; set; }
        public string timeBeforeOverflow { get; set; }
        public string xhcKmlData { get; set; }
        public string xml_in_data { get; set; }
        public string agent_number { get; set; }
        public string system_last_event_args { get; set; }
        public string system_speaktime { get; set; }
        public string ciq_iqid { get; set; }
        public string ciq_originating { get; set; }
        public string ciq_queue_key { get; set; }
        public string ciq_source { get; set; }
        public string system_first_session_id { get; set; }
        public string system_parent_session_id { get; set; }
        public string system_service_uri { get; set; }
        public string system_prev_user_num { get; set; }
        public string LookupLindorf { get; set; }
        public string Record_1_areaField { get; set; }
        public string Record_1_birthday { get; set; }
        public string Record_1_boxCity { get; set; }
        public string Record_1_boxCountry { get; set; }
        public string Record_1_boxNumber { get; set; }
        public string Record_1_boxText { get; set; }
        public string Record_1_boxZipCode { get; set; }
        public string Record_1_coord_x { get; set; }
        public string Record_1_coord_y { get; set; }
        public string Record_1_country { get; set; }
        public string Record_1_firstName { get; set; }
        public string Record_1_gender { get; set; }
        public string Record_1_houseNum { get; set; }
        public string Record_1_houseStairwell { get; set; }
        public string Record_1_orgnr { get; set; }
        public string Record_1_phoneFax { get; set; }
        public string Record_1_phoneLandline { get; set; }
        public string Record_1_phoneMobil { get; set; }
        public string Record_1_recordType { get; set; }
        public string Record_1_streetName { get; set; }
        public string Record_1_surName { get; set; }
        public string Record_1_zipCode { get; set; }
        public string Record_1_zipLoc { get; set; }
        public string Return_matchFound { get; set; }
        public string Return_numOfRecords { get; set; }
        public string system_caller_transfered { get; set; }
        public string system_AdditionalCallingPartyNumber { get; set; }
        public string system_OriginalCalledNumber { get; set; }

        public override string ToString()
        {
            return popup_name;
        }
    }
}