using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SpindleSoft.Utilities
{
    internal class Validation
    {
        #region 'Validation

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
            else
                return "";
        }

        /// <summary>
        /// checks if the container sent has any controls with no value
        /// </summary>
        /// <param name="container"></param>
        /// <param name="Recurse">true -> if control has parent container else false </param>
        /// <param name="ExceptionControl">it consists the name of control that has to be treated as an exception by default it has</param>
        /// <returns></returns>
        public static bool controlIsInEdit(Control controls, bool Recurse)
        {
            foreach (Control ctrol in controls.Controls)
            {
                if ((ctrol.Name.Substring(0, 3).ToLower() == "txt") && ctrol.Text != "")
                    return true;

                if (Recurse)
                {
                    if ((ctrol is TabPage || ctrol is Panel || ctrol is GroupBox) && controlIsInEdit(ctrol, Recurse))
                        return true;
                }
            }
            //else
            return false;
        }

        public static void CheckIsNumber(System.Windows.Forms.KeyPressEventArgs e)
        {
            //string allowedChars = "0123456789." & ControlChars.Back;
            string allowedChars = "0123456789." + (char)Keys.Back;
            if (allowedChars.IndexOf(e.KeyChar) == -1)
                //invalid character
                e.Handled = true;
        }

        #endregion 'Validation
    }
}