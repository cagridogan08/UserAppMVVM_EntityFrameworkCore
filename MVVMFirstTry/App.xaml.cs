using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMFirstTry
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()

        {
            string connectionStr = "workstation id=default.mssql.somee.com;packet size=4096;user id=cagridogan08_SQLLogin_1;pwd=p5mcsnzrt3;data source=default.mssql.somee.com;persist security info=False;initial catalog=default";
            Application.Current.Properties["connectionStr"] = connectionStr;
        }
    }
}
