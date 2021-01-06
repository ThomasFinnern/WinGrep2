using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Windows.Forms;

using DebugLog;
using LibStdFileDateTime;
using MainGlobal;
using ErrorCapture;
using NetGrep;
using ConfigBase;

namespace CmdLine2005
{
    public partial class clsCommandLine
    {
        //---------------------------------------------------------------------------------
        // Sources for Commands from Commandline
        //---------------------------------------------------------------------------------

        public void DoCmdTestAll() // string InPath, string InFileName)
        {
            try
            {
                //string OutTxt;
                //bool bErrFound;

                //Global.oDebugLog.WriteUserInfoTitle("- Do command TestAll");

                //bErrFound = clsTestAllNetGrepToken.TestAll(out OutTxt);

                //if (bErrFound)
                //{ 
                //    OutTxt += "\r\n !!! Error found !!!"; 
                //}
                //else 
                //{ }

                //OutTxt += "\r\n Tests done\r\n";
                //Global.oDebugLog.WriteUserInfoLine(OutTxt);
                //MessageBox.Show(OutTxt);

                SorryCmdNotImplementedYet("TestAll"); // See cmdTestClass_Click in form1
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        
        public void DoCmdTestClsConfigBase()
        {
            try
            {
                //string OutTxt = "";
                //bool bErrFound;

                Global.oDebugLog.WriteUserInfoTitle("- Do command TestClsConfigBase");

                //bErrFound = clsTestAllNetGrepToken.TestClsConfigBase(ref OutTxt);
                //if (bErrFound)
                //{ 
                //    OutTxt += " !!! Error found !!!"; 
                //}
                //else 
                //{ }

                //OutTxt += "\r\n Tests done\r\n";
                //Global.oDebugLog.WriteUserInfoLine(OutTxt);
                //MessageBox.Show(OutTxt);


                SorryCmdNotImplementedYet("TestClsConfigBase");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        public void DoCmdTestClsConfigNetGrep()
        {
            //string OutTxt = "";
            //bool bErrFound;

            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command TestClsConfigNetGrep");
            //    bErrFound = clsTestClsConfigNetGrep.TestClass (ref OutTxt);
            //    if (bErrFound)
            //    {
            //        OutTxt += " !!! Error found !!!";
            //    }
            //    else
            //    { }

            //    OutTxt += "\r\n Tests done\r\n";

                SorryCmdNotImplementedYet("TestClsConfigNetGrep");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }


        public void DoCmdTestClsConfigSpezialBase()
        {
            //string OutTxt = "";
            //bool bErrFound;

            try
            {
                Global.oDebugLog.WriteUserInfoTitle("- Do command TestClsConfigSpezialBase");

                //bErrFound = clsTestClsConfigSpezialBase.TestClass(ref OutTxt);
                //if (bErrFound)
                //{
                //    OutTxt += " !!! Error found !!!";
                //}
                //else
                //{ }

                //OutTxt += "\r\n Tests done\r\n";

                SorryCmdNotImplementedYet("TestClsConfigSpezialBase");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

        
        public void DoCmdTestClsGrepTokenListBase()
        {
            try
            {
                //string OutTxt = "";
                //bool bErrFound;

                Global.oDebugLog.WriteUserInfoTitle("- Do command TestClsGrepTokenListBase");

                //bErrFound = clsTestClsGrepTokenListBase.TestClass(ref OutTxt);
                //if (bErrFound)
                //{
                //    OutTxt += " !!! Error found !!!";
                //}
                //else
                //{ }

                //OutTxt += "\r\n Tests done\r\n";

                SorryCmdNotImplementedYet("TestClsGrepTokenListBase");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
        
        /*
        public void DoCmd()
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command x");
                SorryCmdNotImplementedYet("Name");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
        */
        /*
        public void DoCmd()
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command x");
                SorryCmdNotImplementedYet("Name");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
        */
        /*
        public void DoCmd()
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command x");
                SorryCmdNotImplementedYet("Name");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
        */
        /*
        public void DoCmd()
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command x");
                SorryCmdNotImplementedYet("Name");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
        */
        /*
        public void DoCmd()
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command x");
                SorryCmdNotImplementedYet("Name");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
        */
        /*
        public void DoCmd()
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command x");
                SorryCmdNotImplementedYet("Name");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
        */

        /*
        public void DoCmd()
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command x");
                SorryCmdNotImplementedYet("Name");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
        */

        /*
        public void DoCmd()
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command x");
                SorryCmdNotImplementedYet("Name");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
        */

        /*
        public void DoCmd()
        {
            try
            {
                Global.oDebugLog.WriteUserInfoTitle ("- Do command x");
                SorryCmdNotImplementedYet("Name");
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }
        */

       public void SorryCmdNotImplementedYet(string FunctionName)
        {
            try
            {
                string OutTxt = "";
                OutTxt = "Sorry function " + FunctionName + " is not implemented";
                Global.oDebugLog.MessageBox(OutTxt);
                
            }
            catch (Exception Ex)
            {
                clsErrorCapture ErrCapture = new clsErrorCapture(Ex);
                ErrCapture.ShowExeption();
            }
        }

     } // End class
} // End namespace

