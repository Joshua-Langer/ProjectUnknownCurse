using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace LangerNetwork.Debugging
{
    public partial class DebugManager
    {
        public static bool debugMode;
        protected static StreamWriter streamWriter;
        protected static string fileName;

        public static void Log(string message, bool trace = true)
        {
            WriteToLog(message, LogType.Log, trace);
        }

        public static void LogWarning(string message, bool trace = true)
        {
            WriteToLog(message, LogType.Log, trace);
        }

        public static void LogError(string message, bool trace = true)
        {
            WriteToLog(message, LogType.Log, trace);
        }

        public static void LogFormat(params string[] list)
        {
            if (list.Length == 0)
                return;
            if (!debugMode)
                debugMode = ProjectConfigTemplate.singleton.globalDebugMode;
            string message = "[" + list[0] + "] ";
            for (int i = 1; i < list.Length; i++)
            {
                message += list[i] + " ";
            }
            WriteToLog(message, LogType.Log, false);
        }

        public static void WriteToLog(string message, LogType logType, bool trace = true)
        {
            if (!debugMode || String.IsNullOrWhiteSpace(message))
                return;
            string traceString = "";
            string logString = "";
            if (trace)
                traceString = new System.Diagnostics.StackTrace().ToString();
            logString = "<b>" + message + "</b>";
            if (trace)
                logString += "\n" + traceString;
            if (logType == LogType.Log)
                UnityEngine.Debug.Log(logString);
            else if (logType == LogType.Warning)
                UnityEngine.Debug.LogWarning(logString);
            else if (logType == LogType.Error)
                UnityEngine.Debug.LogError(logString);
            WriteToLogFile(message);
        }

        protected static void WriteToLogFile(string message)
        {
            if (!ProjectConfigTemplate.singleton.logMode || String.IsNullOrWhiteSpace(message))
                return;

            if (!Directory.Exists(Tools.GetPath(ProjectConfigTemplate.singleton.logFolder)))
                Directory.CreateDirectory(Tools.GetPath(ProjectConfigTemplate.singleton.logFolder));

            if (String.IsNullOrWhiteSpace(fileName))
                fileName = ProjectConfigTemplate.singleton.logFolder + "/" + ProjectConfigTemplate.singleton.logFilename + "_" + Tools.GetRandomAlphaString() + ".txt";

            using (streamWriter = new StreamWriter(Tools.GetPath(fileName), true))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }

    }
}
