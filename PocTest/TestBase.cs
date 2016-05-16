using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Framework;
using NUnit.Framework;
using UIAccess;
using AuScGen.TestExecutionUtil;
using System.Drawing;
using System.Windows.Forms;
using AuScGen.CommonUtilityPlugin;
using TechTalk.SpecFlow;

namespace SpecFlowPoc.PocTest
{
    public class TestBase : IDisposable
    {
        private static ContainerAccess container = new ContainerAccess();
        private bool disposed = false;

        public TestBase()
        {
            Console.WriteLine("Test base Constructor");
            TestParameter.ParamFilePath = string.Format(@"{0}\{1}\", Directory.GetCurrentDirectory(), "TestParameter");
            //TestFixture();             
        }

        protected static string TestDataPath
        {
            get
            {
                return string.Format(@"{0}\TestData\", Directory.GetCurrentDirectory());
            }
        }

        public static int Timeout 
        {
            get
            {
                return SpecFlowPoc.PocPages.Config.PageClassSettings.Default.MaxTimeoutValue;
                
            }            
        }

        
        private static WebDriverPlugin aWebDriver;
        public WebDriverPlugin WebDriver
        {
            get
            {
                if (null == aWebDriver)
                {
                    aWebDriver = CreatePlugin<WebDriverPlugin>();
                    string path = string.Format(@"{0}\DownloadDirectory", Directory.GetCurrentDirectory());
                    aWebDriver.Browser = new WebDriverWrapper.Browser(Utils.BrowserUtil.GetBrowserTypeFromTestSettings
                                                                      , Config.TestSettings.Default.BinaryPath,path); 
                }
                return aWebDriver;
            }

            private set
            {
                aWebDriver = value;
            }
        }
        
        private TestExecute runner;
        public TestExecute Runner 
        { 
            get
            {
                if (null == runner)
                {
                    runner = new TestExecute();
                    Copy(Directory.GetCurrentDirectory() + @"\Report", Directory.GetCurrentDirectory() + @"\Reports");
                    runner.Print = new Utils.ScreenShot(WebDriver, Directory.GetCurrentDirectory() + @"\Reports");
                }
                return runner;
            }
        }

        private void Copy(string sourceDir, string targetDir)
        {
            if(!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);

                foreach (var file in Directory.GetFiles(sourceDir))
                    File.Copy(file, Path.Combine(targetDir, Path.GetFileName(file)));

                foreach (var directory in Directory.GetDirectories(sourceDir))                        
                    Copy(directory, Path.Combine(targetDir, Path.GetFileName(directory)));
            }
        }

        private static AuScGen.CommonUtilityPlugin.ExcelReader myExcel;
        public static AuScGen.CommonUtilityPlugin.ExcelReader Excel
        {
            get
            {
                if (null == myExcel)
                {
                    myExcel = CreatePlugin<AuScGen.CommonUtilityPlugin.ExcelReader>();
                }
                return myExcel;
            }

        }

        private AuScGen.CommonUtilityPlugin.MouseKeyBoardSimulator keyBoardSimulator;
        public AuScGen.CommonUtilityPlugin.MouseKeyBoardSimulator KeyBoardSimulator
        {
            get
            {
                if (null == keyBoardSimulator)
                {
                    keyBoardSimulator = CreatePlugin<AuScGen.CommonUtilityPlugin.MouseKeyBoardSimulator>();
                }
                return keyBoardSimulator;
            }

        }

        private AuScGen.CommonUtilityPlugin.DataAccess dataAccess;
        public AuScGen.CommonUtilityPlugin.DataAccess DBValidation
        {
            get
            {
                dataAccess = CreatePlugin<AuScGen.CommonUtilityPlugin.DataAccess>();
                dataAccess.ConectionString = Config.TestSettings.Default.DBConnection;
                dataAccess.DataCategory = AuScGen.CommonUtilityPlugin.DataCategory.SQLDB;                
                return dataAccess;
            }

        }

        private AutoITExtension autoIT;
        public AutoITExtension AutoIT
        {
            get
            {
                if(null == autoIT)
                {
                    autoIT = CreatePlugin<AutoITExtension>();
                }
                return autoIT;
            }        
        }
        
                

        private Page myPage;
        protected Page Page
        {
            get
            {
                if (null == myPage)
                {
                    myPage = new Page(this);
                }
                return myPage;
            }
        }



        //private SamplePage samplePage;
        //protected SamplePage SamplePage
        //{
        //    get
        //    {
        //        if (null == samplePage)
        //        {
        //            samplePage = new SamplePage(this);
        //        }
        //        return samplePage;
        //    }
        //}

        protected string AppUrl
        {
            get
            {
                return Config.TestSettings.Default.Url;
            }
        }

        protected string AUUrl
        {
            get
            {
                return Config.TestSettings.Default.AUUrl;
            }
        }

        protected string CurrentBrowser
        {
            get
            {
                return Config.TestSettings.Default.Browser;
            }
        }

        protected string AIUrl
        {
            get
            {
                return Config.TestSettings.Default.AIUrl;
            }
        }

        protected string SUUrl
        {
            get
            {
                return Config.TestSettings.Default.SUUrl;
            }
        }

        protected string BMCUrl
        {
            get
            {
                return Config.TestSettings.Default.BMCUrl;
            }
        }

        public Bitmap GetPageScreenPrint 
        { 
            get
            {
                Bitmap bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                            Screen.PrimaryScreen.Bounds.Height);
                
                    using (Graphics g = Graphics.FromImage(bmpScreenCapture))
                    {
                        g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                         Screen.PrimaryScreen.Bounds.Y,
                                         0, 0,
                                         bmpScreenCapture.Size,
                                         CopyPixelOperation.SourceCopy);
                    }

                    //bmpScreenCapture.Save(string.Format(@"{0}\{1}_{2}.png", LogFolder, methodName, Guid.NewGuid()));
                
                return bmpScreenCapture;
                //return WebDriver.Browser.TakeSreenShot();
            }
        }               

        protected AutoITExtension GetAutoIt(string windowTitle)
        {
            return new AutoITExtension(windowTitle);
        }

        [BeforeScenario]
        public virtual void TestFixtureSetupBase()
        {
            Runner.DoStepWithoutScreenShot(() => 
            {
                Console.WriteLine("Test Fixture Base");
                WebDriver.Browser.Maximize();
                WebDriver.Browser.Navigate(AppUrl); 
            });
            
        }

        [AfterScenario]
        public virtual void TestFixtureTeardownBase()
        {
            Runner.DoStepWithoutScreenShot(() => 
            {
                WebDriver.Browser.Quit();
                WebDriver = null;
            });
        }
        
        private static T CreatePlugin<T>() where T : IContainerPlugin
        {
            return container.GetPlugin<T>();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }
        public void Dispose()
        {
            //TestFixtureTearDown();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //public enum MainMenuItems
        //{
        //    AboutEDMC,Locations,InvestorRelations,Newsroom,Careers
        //}
    }
}
