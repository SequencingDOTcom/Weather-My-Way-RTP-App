//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sequencing.WeatherApp.Models
{
    using System;
    using System.Collections.Generic;

    public partial class SendInfo
    {
        public SendInfo()
        { 
        }

        public SendInfo(string name)
        {
            this.UserName = name;
            this.WeekendMode = WeekEndMode.All;
            this.TimeWeekDay = "6 AM";
            this.TimeWeekEnd = "8 AM";
        }

        public long Id { get; set; }
        public string UserName { get; set; }
        public Nullable<bool> SendEmail { get; set; }
        public Nullable<bool> SendSms { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public Nullable<System.DateTime> LastSendDt { get; set; }
        public string City { get; set; }
        public string DataFileName { get; set; }
        public string DataFileId { get; set; }
        public string TimeWeekDay { get; set; }
        public string TimeWeekEnd { get; set; }
        public string TimeZoneValue { get; set; }
        public Nullable<decimal> TimeZoneOffset { get; set; }
        public Nullable<WeekEndMode> WeekendMode { get; set; }
        public Nullable<TemperatureMode> Temperature { get; set; }
        public string SmsId { get; set; }
        public Nullable<bool> SmsUseFrom2 { get; set; }
        public Nullable<bool> SendRoost { get; set; }
        public string LastWeatherUpdate { get; set; }
        public Nullable<System.DateTime> WeatherUpdateDt { get; set; }


        public void Merge(SendInfo from)
        {
            SendInfo to = this;

            if (from.City != null)
                to.City = from.City;

            if (from.DataFileId != null)
                to.DataFileId = from.DataFileId;

            if (from.DataFileName != null)
                to.DataFileName = from.DataFileName;

            if (from.LastSendDt != null)
                to.LastSendDt = from.LastSendDt;

            if (from.SendRoost != null)
                to.SendRoost = from.SendRoost;

            if (from.SendSms != null)
                to.SendSms = from.SendSms;

            if (from.SmsId != null)
                to.SmsId = from.SmsId;

            if (from.SendEmail != null)
                to.SendEmail = from.SendEmail;

            if (from.SmsUseFrom2 != null)
                to.SmsUseFrom2 = from.SmsUseFrom2;

            if (from.Temperature != null)
                to.Temperature = from.Temperature;

            if (from.TimeWeekDay != null)
                to.TimeWeekDay = from.TimeWeekDay;

            if (from.TimeWeekEnd != null)
                to.TimeWeekEnd = from.TimeWeekEnd;

            if (from.TimeZoneOffset != null)
                to.TimeZoneOffset = from.TimeZoneOffset;

            if (from.TimeZoneValue != null)
                to.TimeZoneValue = from.TimeZoneValue;

            if (from.UserEmail != null)
                to.UserEmail = from.UserEmail;

            if (from.UserPhone != null)
                to.UserPhone = from.UserPhone;

            if (from.WeatherUpdateDt != null)
                to.WeatherUpdateDt = from.WeatherUpdateDt;

            if (from.WeekendMode != null)
                to.WeekendMode = from.WeekendMode;

            if (from.LastWeatherUpdate != null)
                to.LastWeatherUpdate = from.LastWeatherUpdate;
        }
    }
}
