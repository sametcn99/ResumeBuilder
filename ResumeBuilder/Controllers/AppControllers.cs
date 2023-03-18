using Microsoft.Win32;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ResumeBuilder.Controllers
{
    internal class AppControllers
    {
        //fields
        /*
        The class also contains various fields, such as "phoneNumber",
        "regexNumber", "numberWithNoCountryCode","regexNumberWithNoCountryCode", "titlesTR", "titlesEN", "savingOption",
        and "languageOption", which are used to store various data used in the application.
        */
        public static string phoneNumber;
        public static string regexNumber;
        public static string numberWithNoCountryCode;
        public static string regexNumberWithNoCountryCode;
        public string[] titlesTR = { "IS DENEYIMI", "EGITIM BILGILERI", "SERTIFIKALAR", "KISISEL PROJELER", "DIL", "ILGI ALANI/ HOBI", "YETENEK" };
        public string[] titlesEN = { "JOB", "EDUCATION", "CERTIFICATES", "PERSONAL PROJECTS", "LANGUAGES", "INTERESTS", "SKILLS" };
        public static int savingOption { get; set; }
        public static int languageOption { get; set; }

        //methods
        //The "OpenURL" method opens a URL in the default web browser.
        public void OpenURL(string url)
        {
            string key = @"htmlfile\shell\open\command";
            RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(key, false);
            string Default_Browser_Path = ((string)registryKey.GetValue(null, null)).Split('"')[1];
            Process p = new Process();
            p.StartInfo.FileName = Default_Browser_Path;
            p.StartInfo.Arguments = url;
            p.Start();
        }
        
        //The "validatePhoneNumber" method validates a phone number by checking if it has the correct format and length.
        public static bool validatePhoneNumber(string areaCode1, string phoneNumber1)
        {
            try
            {
                phoneNumber = $"+{areaCode1} {phoneNumber1.Trim()}";
                regexNumberWithNoCountryCode = Regex.Replace(phoneNumber1.Trim(), @"[^0-9]+", "");
                numberWithNoCountryCode = phoneNumber1.Trim();
                regexNumber = areaCode1.Trim() + Regex.Replace(phoneNumber1, @"[^0-9]+", "");
                if (regexNumberWithNoCountryCode.Length == 10)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Phone Number is wrong.");
                    return false;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Select Country first!");
                return false;
            }
        }

        //The "GetKeyFromValue" method returns the key associated with a given value in a dictionary.
        public static string GetKeyFromValue(string valueVar)
        {
            foreach (string keyVar in CountryCodes.countryCodesMapping.Keys)
            {
                //MessageBox.Show(keyVar, valueVar);
                if (CountryCodes.countryCodesMapping[keyVar] == valueVar.ToString().Trim())
                {
                    //MessageBox.Show(keyVar);
                    return keyVar;
                }
            }
            return null;
        }

        //The "regex" method removes all non-numeric characters from a string.
        public static string regex(string input)
        {
            input = Regex.Replace(input, @"[^0-9]+", "");
            return input;
        }

        //The "DropDownWidth" method calculates the maximum width of the items in a ComboBox control.
        public static int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0;
            int temp = 0;
            Label label1 = new Label();

            foreach (var obj in myCombo.Items)
            {
                label1.Text = obj.ToString();
                temp = label1.PreferredWidth;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            label1.Dispose();
            return maxWidth;
        }
    }
}
