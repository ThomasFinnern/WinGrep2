using System;
using System.Collections.Generic;
using System.Text;

namespace NetGrep
{
    class clsReplaceInFiles
    {
        public clsSearchProperties GrepProperties;
        public List<clsFileResults> Files2LineResults = new List<clsFileResults>();

        public void DoReplaceInFiles(
            clsSearchProperties InGrepProperties,
            List<clsFileResults> InFiles2LinesResults)
        {
            GrepProperties = InGrepProperties;
            Files2LineResults = InFiles2LinesResults;

            foreach (clsFileResults FileResultInfo in Files2LineResults)
            {
                clsReplaceInFile ReplaceInFile = new clsReplaceInFile();
                ReplaceInFile.DoReplaceInFile(InGrepProperties, FileResultInfo);
            }

            return;
        }
    }
}
