using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowPoc.PocPages.Utils;
using UIAccess;
using UIAccess.WebControls;

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

        private Wait wait;
        public Wait Wait
        {
            get
            {
                if (null == wait)
                {
                    wait = new Wait(WebDriver, completeGuiMapPath);
                }
                return wait;
            }
        }

        protected virtual string GuiMapPath
        {
            get
            {
                return Directory.GetCurrentDirectory() + @"\GuiMaps\";
            }
        }

        public PageBase(WebDriverPlugin webDriverPlugin)
        {
            webDriver = webDriverPlugin;
        }

        public PageBase(WebDriverPlugin webDriverPlugin, string guiMapName)
            : this(webDriverPlugin)
        {
            completeGuiMapPath = string.Concat(GuiMapPath, guiMapName);
        }

        public PageBase(List<object> utils)
        {
            foreach (object util in utils)
            {
                if (util is WebDriverPlugin)
                {
                    webDriver = (WebDriverPlugin)util;
                }

                if (util is AuScGen.CommonUtilityPlugin.MouseKeyBoardSimulator)
                {
                    keyboardSimulator = (AuScGen.CommonUtilityPlugin.MouseKeyBoardSimulator)util;
                }

                if (util is AuScGen.CommonUtilityPlugin.AutoITExtension)
                {
                    autoIT = (AuScGen.CommonUtilityPlugin.AutoITExtension)util;
                }
            }
        }

        public PageBase(List<object> utils, string guiMapName)
            : this(utils)
        {
            completeGuiMapPath = string.Concat(GuiMapPath, guiMapName);
        }

        public bool IsPresent<T>(string logicalName, int waitBeforeCheck, int timeOut) where T : WebControl
        {
            return Wait.IsPresent<T>(logicalName, waitBeforeCheck, timeOut);
        }

        public T GetHtmlControl<T>(string GUIMap, string LogicalName) where T : WebControl
        {
            return Wait.GetHtmlControl<T>(GUIMap, LogicalName);
        }

        public T GetHtmlControl<T>(string logicalName) where T : WebControl
        {
            return GetHtmlControl<T>(completeGuiMapPath, logicalName);
        }

    }
}
