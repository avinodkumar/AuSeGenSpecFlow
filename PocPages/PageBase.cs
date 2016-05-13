using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAccess;

namespace SpecFlowPoc.PocPages
{
    public class PageBase
    {
        private string completeGuiMapPath;

        private AuScGen.CommonUtilityPlugin.DataAccess access;

        public AuScGen.CommonUtilityPlugin.DataAccess DBAccess
        {
            get
            {
                return access;
            }
        }

        private WebDriverPlugin webDriver;

        public WebDriverPlugin WebDriver
        {
            get
            {
                return webDriver;
            }
        }


        /// <summary>
        /// The keyboard simulator
        /// </summary>
        private AuScGen.CommonUtilityPlugin.MouseKeyBoardSimulator keyboardSimulator;
        /// <summary>
        /// Gets the key board simulator.
        /// </summary>
        /// <value>
        /// The key board simulator.
        /// </value>
        protected AuScGen.CommonUtilityPlugin.MouseKeyBoardSimulator KeyboardSimulator
        {
            get
            {
                return keyboardSimulator;
            }
        }

        /// <summary>
        /// The automatic it
        /// </summary>
        private AuScGen.CommonUtilityPlugin.AutoITExtension autoIT;
        /// <summary>
        /// Gets the automatic it.
        /// </summary>
        /// <value>
        /// The automatic it.
        /// </value>
        public AuScGen.CommonUtilityPlugin.AutoITExtension AutoIT
        {
            get
            {
                return autoIT;
            }
        }

    }
}
