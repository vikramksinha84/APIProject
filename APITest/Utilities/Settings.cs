using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Utilities
{
    internal  class Settings
    {
        public static string? EmployeeBaseUrl { get; set; }

        public static string? BaseUrl { get; set; }

        public RestResponse? Response { get; set; }

        public RestRequest? Request { get; set; }

        public RestClient? RestClient { get; set; } //= new RestClient(BaseUrl);

        public Helper? Lib = new Helper();

        public static Dictionary<string, string>? AppSetting { get; set; } = null;

        public static  string? AppSettingPath = new Helper().SolutionPath() + "\\appsettings.json";

        public static string? BankBaseUrl { get; set; }

    }
}
