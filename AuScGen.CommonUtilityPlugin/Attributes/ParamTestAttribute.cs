using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuScGen.CommonUtilityPlugin;

namespace AuScGen
{
    public class ParamAttribute : Attribute
    {   
        public ParamAttribute(string testName, string paramFileName)
        {
            TestParameter.ParamFileName = paramFileName;
            TestParameter.TestName = testName;
        }
    }
}
