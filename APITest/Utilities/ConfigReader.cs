using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Utilities
{
    internal class ConfigReader
    {
        public static void InitConfigSetting()
        {
            Settings.AppSetting = new Helper().JsonFileRead(Settings.AppSettingPath);

            Settings.EmployeeBaseUrl = Settings.AppSetting?["EmployeeBaseUrl"];

            Settings.BankBaseUrl = Settings.AppSetting?["BankBaseUrl"];

            Settings.IntialAmountKey = Settings.AppSetting?["IntialAmountKey"];

        }
    }
}
