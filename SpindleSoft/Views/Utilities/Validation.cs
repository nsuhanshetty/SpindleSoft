﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SpindleSoft.Utilities
{
    internal class Validation
    {
        #region 'Validation

        /// <summary>
        /// Converts the firsts Character to upper
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToTitleCase(string input)
        {
            if (!String.IsNullOrEmpty(input))
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

        public static bool IsNullOrEmpty(Control container, Boolean Recurse, string exception)
        {
            List<string> exceptionlist = new List<string>();
            exceptionlist.Add(exception);

            return IsNullOrEmpty(container, Recurse, exceptionlist);
        }
        //todo: add the following function to winform_abstract 
        //todo: rewrite the code to fetch using foreach() txt's first and image later - use linq with lambdha
        /// <summary>
        /// checks if the container sent has any controls with no value
        /// </summary>
        /// <param name="container"></param>
        /// <param name="Recurse">true -> if control has parent container else false </param>
        /// <param name="ExceptionControl">it consists the name of control that has to be treated as an exception by default it has</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(Control container, Boolean Recurse, List<string> ExceptionControl = null)
        {
            //todo: need to make it better
            if (ExceptionControl == null)
                ExceptionControl = new List<string>();

            foreach (Control ctrol in container.Controls)
            {
                if ((ctrol is TextBox || ctrol is RichTextBox) && (!ExceptionControl.Contains(ctrol.Name)))
                {
                    if (string.IsNullOrEmpty(ctrol.Text))
                    {
                        MessageBox.Show("Textbox " + ctrol.Name + " is Mandatory and cannot be empty.." + Environment.NewLine + "Please try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ctrol.Focus();
                        return true;
                    }
                }
                if (ctrol is PictureBox && (!ExceptionControl.Contains(ctrol.Name)))
                {
                    if (((PictureBox)ctrol).Image == null)
                    {
                        MessageBox.Show(ctrol.Name + " Image is Mandatory and cannot be empty." + Environment.NewLine + "Please insert and try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
                if (ctrol is ComboBox && (!ExceptionControl.Contains(ctrol.Name)))
                {
                    if ((string.IsNullOrEmpty(((ComboBox)ctrol).Text)) && (!ExceptionControl.Contains(ctrol.Name)))
                    {
                        MessageBox.Show("ComboBox " + ctrol.Name + " is Mandatory and cannot be empty." + Environment.NewLine + "Please insert and try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
                if (Recurse)
                {
                    if ((ctrol is TabPage || ctrol is Panel || ctrol is GroupBox) && (!ExceptionControl.Contains(ctrol.Name)) && IsNullOrEmpty(ctrol, Recurse, ExceptionControl))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// CheckForInternetConnection
        /// </summary>
        /// <returns>true/false based on connectivity</returns>
        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool InternetGetConnectedState(out int lpdwFlags, int dwReserved);

        //another way to test internet connectivity
        public static bool _InternetGetConnectedState()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    using (var stream = client.OpenRead("http://www.dropbox.com"))
                    {
                        Cursor.Current = Cursors.Arrow;
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion 'Validation
    }
}