using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using Vigie.Risques.Tpm.Core.Services.Contracts;
using Xamarin.Forms;
using Vigie.Risques.Tpm.Core.Services;
using Sword.Swl.Framework.Xamarin.Models;
using Sword.Swl.Framework.Xamarin.Services.Contracts;

[assembly: Dependency(typeof(AppCenterLogService))]
namespace Vigie.Risques.Tpm.Core.Services
{
    public class AppCenterLogService : ILog
    {
        private const string _contextKey = "Context";
        private const string _logLevelKey = "LogLevel";

        private readonly string _context;

        public bool IsLogLevelEnabled(LogLevel logLevel)
        {
            return true;
        }

        public AppCenterLogService(string context = null)
        {
            _context = context;
        }

        public bool Log(LogLevel logLevel, Func<string> messageFunc, Exception exception = null, params object[] formatParameters)
        {
            string message = messageFunc();

            Console.WriteLine($"{logLevel}: {message}");

            if (exception != null)
            {
                Console.WriteLine(exception.ToString());
            }

            if (logLevel >= LogLevel.Info)
            {
                if (exception == null)
                {
                    AnalyticsLog(logLevel, message, null);
                }
                else
                {
                    CrashLog(exception, null);
                }
            }

            return true;
        }

        private bool AnalyticsLog(LogLevel logLevel, string eventName, object[] parameters)
        {
            return LogCore(() => Analytics.TrackEvent(eventName, PrepareProperties(parameters, logLevel)));
        }

        private bool CrashLog(Exception exception, object[] parameters)
        {
            return LogCore(() => Crashes.TrackError(exception, PrepareProperties(parameters, null)));
        }

        private Dictionary<string, string> PrepareProperties(IEnumerable<object> parameters, LogLevel? logLevel = null)
        {
            var properties = new Dictionary<string, string>();

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    foreach (var propInfo in parameter.GetType().GetProperties())
                    {
                        if (!properties.ContainsKey(propInfo.Name))
                        {
                            properties.Add(propInfo.Name, propInfo.GetValue(parameter).ToString());
                        }
                    }
                }
            }

            AddDefaultProperties(properties, logLevel);

            return properties;
        }

        private void AddDefaultProperties(Dictionary<string, string> properties, LogLevel? logLevel)
        {
            if (properties == null)
            {
                properties = new Dictionary<string, string>();
            }

            if (logLevel.HasValue && !properties.ContainsKey(_logLevelKey))
            {
                properties.Add(_logLevelKey, logLevel.Value.ToString());
            }

            if (!string.IsNullOrEmpty(_context) && !properties.ContainsKey(_contextKey))
            {
                properties.Add(_contextKey, _context);
            }
        }

        private static bool LogCore(Action logAction)
        {
            try
            {
                logAction();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }
    }
}
