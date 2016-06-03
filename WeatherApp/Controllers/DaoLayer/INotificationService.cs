﻿using Sequencing.WeatherApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sequencing.WeatherApp.Controllers.DaoLayer
{
    public interface IPushNotificationService
    {
        void Subscribe(string deviceToken, DeviceType deviceType, string accessToken);
        void Unsubscribe(string token);
        void Send(Int64 userId, DeviceType deviceType, string token, string message);
        void Send(Int64 userId, string message);
        void SubscribeDeviceToken(Int64 userId, string token, DeviceType deviceType);
        bool IsUserSubscribed(Int64 userId);
        bool IsTokenSubscribed(string token);
        void RefreshDeviceToken(string oldId, string newId);
    }
}