﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PushSharp.Apple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using Sequencing.WeatherApp.Models;
using System.Timers;
using Sequencing.WeatherApp.Controllers.DaoLayer;
using System.Threading;

namespace Sequencing.WeatherApp.Controllers.PushNotification
{
    public class IosPushMessageSender : PushMessageSender
    {
        private ApnsConfiguration config;
        private ApnsServiceBroker apnsBroker;
        public ILog logger = LogManager.GetLogger(typeof(IosPushMessageSender));
        private IPushNotificationService notificationService = new DefaultPushNotificationService();

        override public DeviceType GetDeviceType()
        {
            return DeviceType.IOS;
        }

        public IosPushMessageSender()
        {
            config = new ApnsConfiguration(PushSharp.Apple.ApnsConfiguration.ApnsServerEnvironment.Production,
                 Options.ApnsCertificateFile, Options.ApnsCertificatePassword);

            SetUpFeedbackServiceTimer(Options.APNSFeedbackServiceRunDelay);

            apnsBroker = new ApnsServiceBroker(config);

            apnsBroker.OnNotificationFailed += (notification, aggregateEx) =>
            {
                aggregateEx.Handle(ex =>
                {
                    if (ex is ApnsNotificationException)
                    {
                        var notificationException = (ApnsNotificationException)ex;

                        var apnsNotification = notificationException.Notification;
                        var statusCode = notificationException.ErrorStatusCode;

                        logger.Error($"Apple Notification Failed: ID={apnsNotification.Identifier}, Code={statusCode}, Token ={notification.DeviceToken}");
                    }
                    else
                    {
                        logger.Error($"Apple Notification Failed for some unknown reason : {ex.InnerException}, Token ={notification.DeviceToken}");
                    }

                    notificationService.Unsubscribe(notification.DeviceToken);

                    return true;
                });
            };

            apnsBroker.OnNotificationSucceeded += (notification) =>
            {
                logger.Info($"Notification Successfully Sent to: " + notification.DeviceToken);
            };

            apnsBroker.Start();
        }

        override public void SendPushNotification(string token, string message, Int64 userId)
        {
            var pushObj = new
            {
                aps = new
                {
                    alert = message,
                    sound = "default",
                    badge = 1
                }
            };

            apnsBroker.QueueNotification(new ApnsNotification
            {
                DeviceToken = token,
                Payload = JObject.Parse(JsonConvert.SerializeObject(pushObj))
            });
        }

        private void CheckAndRemoveExiredToken()
        {
            try
            {
                var fbs = new FeedbackService(config);
                fbs.FeedbackReceived += (string deviceToken, DateTime timestamp) =>
                {
                    notificationService.Unsubscribe(deviceToken);
                };
                fbs.Check();
            }
            catch(Exception e)
            {
                logger.Info("Unable to usubscibed user" + e.Message);
            }
        }

        private void SetUpFeedbackServiceTimer(Int64 delayInHours)
        {
            new System.Threading.Timer(x => { CheckAndRemoveExiredToken(); },
                null, 60 * 1000 /*initial delay*/, delayInHours * 60 * 1000 /*execution delay*/);
        }
    }
}