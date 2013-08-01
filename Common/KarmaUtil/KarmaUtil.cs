using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace KarmaUtil
{
    public static class Utils
    {
        public static string FormatLog(string text)
        {
            string logText = GetCurrentUTCTimeStamp() + ": " + text;
            return System.Environment.NewLine + logText;
        }

        public static string  GetCurrentUTCTimeStamp()
        {
            return DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();
        }

        public static string GetAuthToken(string username, string apikey)
        {
            return Karma.CloudAPI.Identity.Identity.Authenticate(username, apikey);
        }

        public static string ComputeMD5Hash(string input)
        {
             string SECRET = "WHAT GOES AROUND COMES AROUND";
             input = string.Format("{0}{1}",input,SECRET);

            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public enum Environments
        {
            TEST,
            ORD,
            SYD,
            LON
        }

        public enum DeployableEntity
        {
            API,
            CP,
            WinServices,
            DBChanges
        }

        public enum Queues
        {
            KARMA_DEPLOY_ORD,
            KARMA_DEPLOY_TEST,
            KARMA_DEPLOY_SYD,
            KARMA_DEPLOY_LON,
            KARMA_DEPLOY_STAGING,
            KARMA_DEPLOY_PREPROD
        }
    }
}
