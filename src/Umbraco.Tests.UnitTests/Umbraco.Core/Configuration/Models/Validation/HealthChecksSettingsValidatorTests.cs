﻿using System;
using NUnit.Framework;
using Umbraco.Core.Configuration;
using Umbraco.Core.Configuration.Models;
using Umbraco.Core.Configuration.Models.Validation;

namespace Umbraco.Tests.UnitTests.Umbraco.Core.Configuration.Models.Validation
{
    [TestFixture]
    public class HealthChecksSettingsValidationTests
    {
        [Test]
        public void Returns_Success_ForValid_Configuration()
        {
            var validator = new HealthChecksSettingsValidator(new NCronTabParser());
            var options = BuildHealthChecksSettings();
            var result = validator.Validate("settings", options);
            Assert.True(result.Succeeded);
        }

        [Test]
        public void Returns_Fail_For_Configuration_With_Invalid_Notification_FirstRunTime()
        {
            var validator = new HealthChecksSettingsValidator(new NCronTabParser());
            var options = BuildHealthChecksSettings(firstRunTime: "0 3 *");
            var result = validator.Validate("settings", options);
            Assert.False(result.Succeeded);
        }

        private static HealthChecksSettings BuildHealthChecksSettings(string firstRunTime = "0 3 * * *")
        {
            return new HealthChecksSettings
            {
                Notification = new HealthChecksNotificationSettings
                {
                    Enabled = true,
                    FirstRunTime = firstRunTime,
                    Period = TimeSpan.FromHours(1),
                }
            };
        }
    }
}
