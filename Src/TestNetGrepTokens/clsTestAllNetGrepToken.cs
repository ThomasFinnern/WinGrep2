using System;
using System.Collections.Generic;
using System.Text;

using DebugLog;
using ErrorCapture;

namespace NetGrep
{
    public class clsTestAllNetGrepToken
    {
        public static bool TestAll (out string OutTxt)
        {
            bool ErrFound = false;
            OutTxt = "";

            ErrFound |= TestClsConfigBase(ref OutTxt);
            ErrFound |= TestclsTestClsConfigNetGrep(ref OutTxt);
            ErrFound |= TestClsConfigSpezialBase(ref OutTxt);
            ErrFound |= TestClsGrepTokenListBase(ref OutTxt);

            return ErrFound;
        }

        public static bool TestClsConfigBase(ref string OutTxt)
        {
            return clsTestClsConfigBase.TestClass (ref OutTxt);
        }


        public static bool TestclsTestClsConfigNetGrep(ref string OutTxt)
        {
            return clsTestClsConfigNetGrep.TestClass(ref OutTxt);
        }

        public static bool TestClsConfigSpezialBase(ref string OutTxt)
        {
            return clsTestClsConfigSpezialBase.TestClass(ref OutTxt);
        }


        public static bool TestClsGrepTokenListBase(ref string OutTxt)
        {
            return clsTestClsGrepTokenListBase.TestClass(ref OutTxt);
        }


    }
}
