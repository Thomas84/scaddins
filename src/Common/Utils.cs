﻿/*
 * Created by SharpDevelop.
 * User: derob
 * Date: 28/06/2015
 * Time: 10:24 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Security;
using System.Diagnostics;

namespace SCaddins.Common
{
    /// <summary>
    /// Description of Utils.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Start a console program - Hidden.
        /// </summary>
        /// <param name="exePath">The program to start.</param>
        /// <param name="args">The args to send to the program.</param>
        [SecurityCritical]
        public static void StartHiddenConsoleProg(string exePath, string args)
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.FileName = exePath;
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.Arguments = args;
            var p = new Process();
            p = System.Diagnostics.Process.Start(startInfo);
            p.WaitForExit();
        }
    }
}
