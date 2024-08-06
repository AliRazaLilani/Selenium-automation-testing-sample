using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliRaza
{
    public class BaseClass
    {
        /// <summary>
        /// Chrome Driver initialization
        /// </summary>
        public static ChromeDriver chromeDriver;
        //public string url = "https://www.saucedemo.com/";

        /// <summary>
        /// Chrome Driver function
        /// </summary>
        public void DriverInitiliaze()
        {
            chromeDriver = new ChromeDriver();
        }

        public void CloseDriver()
        {
            chromeDriver.Close();
        }

        public void OpenChromeWindow()
        {
            // Relative path , for same level data.json file , the file is in the same level as this class is
            chromeDriver.Manage().Window.Maximize();

        }
    }
}
