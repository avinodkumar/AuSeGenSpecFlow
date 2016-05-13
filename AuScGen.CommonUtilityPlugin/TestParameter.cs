using EDMC.DataAccess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.CommonUtilityPlugin
{
    public class TestParameter
    {
        private static string ParamFile 
        { 
            get
            {
                return string.Format(@"{0}\{1}", ParamFilePath, ParamFileName);
            }
        }

        public static string  ParamFilePath { get; set; }

        public static string ParamFileName { get; set; }

        public static string TestName { get; set; }

        public static string GetParam(string key)
        {
            StackTrace trace = new StackTrace();
            var testName = trace.GetFrames().Where(frame => frame.GetMethod().Name.StartsWith("TC")).FirstOrDefault().GetMethod().Name;
            ParamFileName = string.Format("{0}.xml", trace.GetFrames().Where(frame => frame.GetMethod().Name.StartsWith("TC")).FirstOrDefault().GetMethod().ReflectedType.FullName.Split('.').LastOrDefault());
            return AuScGen.BaseSetings.GetParam(ParamFile, testName, key);
        }

        public static string GetExcelParam(string key)
        {
            StackTrace trace = new StackTrace();
            var testName = trace.GetFrames().Where(frame => frame.GetMethod().Name.StartsWith("TC")).FirstOrDefault().GetMethod().Name;
            ParamFileName = string.Format("{0}.xls", trace.GetFrames().Where(frame => frame.GetMethod().Name.StartsWith("TC")).FirstOrDefault().GetMethod().ReflectedType.FullName.Split('.').LastOrDefault());
            TestData data = new TestData(ParamFile);
            return data.GetTestData(testName).Where(oneDatum => oneDatum.Name.Equals(key)).FirstOrDefault().Data;
        }
    }
}
