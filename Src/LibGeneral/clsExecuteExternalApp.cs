using System;
using System.Collections.Generic;
using System.Text;

using System.Diagnostics;


namespace SetupWwmNet
{
    class clsExecuteExternalApp
    {
        public static int ExecuteApplicationHidden (string AppPathName, string Arguments)
        {
            // todo: debug log outTxt "start ...

            ProcessStartInfo Psi = new ProcessStartInfo (AppPathName, Arguments);
            // Psi.WindowStyle = ProcessWindowStyle.Hidden;
            Psi.WindowStyle = ProcessWindowStyle.Normal;
            Psi.UseShellExecute = false; // no default exe matching app start 
            
            Psi.RedirectStandardError = false;
            Psi.RedirectStandardOutput = false;
            Psi.RedirectStandardInput = false;
            
            Process proc = Process.Start (Psi);            
            proc.WaitForExit();

            // todo: debug log outTxt "result ...

            return proc.ExitCode;
        }
    }
}
