using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Utils
{
    public class uDirectory
    {
        public static string Get_Current_Directory()
        {
            // Lấy đường dẫn thư mục hiện tại
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public static string Get_Solution_Directory()
        {
            // Lấy đường dẫn thư mục gốc của giải pháp
            var currentDirectory = Get_Current_Directory();
            var solutionDirectory = Path.GetFullPath(Path.Combine(currentDirectory, @"..\..\..\"));
            return solutionDirectory;
        }

        public static string Get_Data_Directory()
        {
            // Lấy đường dẫn solution hiện tại.
            // Trả về đường dẫn đến thư mục Data trong thư mục gốc của giải pháp
            return Path.Combine(Get_Solution_Directory(), "Data");
        }

        public static string Get_Data_Account_Directory()
        {
            // Lấy đường dẫn solution hiện tại.
            // Trả về đường dẫn đến thư mục DataAccount trong thư mục gốc của giải pháp
            string dataFolderPath = Get_Data_Directory();
            return Path.Combine(dataFolderPath, "Account");
        }

        public static string Get_Data_UserInfo_Directory()
        {
            string dataFolderPath = Get_Data_Directory();
            return Path.Combine(dataFolderPath, "UserInfo");
        }

        public static string Get_Data_UserInfo_Emails_Directory()
        {
            // Lấy đường dẫn solution hiện tại.
            // Trả về đường dẫn đến thư mục DataUserInfoEmails trong thư mục gốc của giải pháp
            string dataUserInfoFolderPath = Get_Data_UserInfo_Directory();
            return Path.Combine(dataUserInfoFolderPath, "Emails");
        }

        public static string Get_Data_UserInfo_Members()
        {
            string dataUserInfoFolderPath = Get_Data_UserInfo_Directory();
            return Path.Combine(dataUserInfoFolderPath, "Members");
        }


    }
}
