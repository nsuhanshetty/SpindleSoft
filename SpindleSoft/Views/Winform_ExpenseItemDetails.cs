﻿using SpindleSoft.Builders;
using SpindleSoft.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SpindleSoft.Views
{
    public partial class Winform_ExpenseItemDetails : Winform_DetailsFormat
    {
        List<string> namesList = new List<string>();
        public Expense Expense { get; set; }
        int index = 0;

        public ExpenseItem ExpenseItem { get; set; }

        public Winform_ExpenseItemDetails(int _index, ExpenseItem item = null, bool _inEdit = false)
        {
            this.index = _index;
            this.ExpenseItem = item;
            this.InEdit = _inEdit;

            InitializeComponent();
            if (!InEdit)
            {
                WinFormControls_InEdit(this);
                this.Enabled = true;
                this.ControlBox = true;
            }
        }

        /// <summary>
        /// reset and update controls based the type preference.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbFixed_CheckedChanged(object sender, EventArgs e)
        {

            namesList = ExpenseBuilder.GetExpenseNames(rdbFixed.Checked);
            LoadExpenseNames(namesList);

            nudAmount.Value = 0;
            txtComment.Text = "";
        }

        private void LoadExpenseNames(List<string> namesList)
        {
            cmbName.DataSource = null;
            cmbName.DataSource = namesList;

            AutoCompleteStringCollection namesListCol = new AutoCompleteStringCollection();
            namesListCol.AddRange(namesList.ToArray());
            cmbName.AutoCompleteCustomSource = namesListCol;
            cmbName.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbName.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (this.ExpenseItem != null)
                cmbName.SelectedIndex = namesList.IndexOf(this.ExpenseItem.Name);
        }

        protected override void SaveToolStrip_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbName.Text))
            {
                errorProvider1.SetError(cmbName, "Expense Name is Mandatory");
                return;
            }

            UpdateStatus("Saving Expenses", 25);
            if (Expense == null)
                ExpenseItem = new ExpenseItem(rdbFixed.Checked,
                                                  int.Parse(nudAmount.Value.ToString()),
                                                  cmbName.Text,
                                                  txtComment.Text,
                                                  this.Expense);
            else
            {
                ExpenseItem.Comment = txtComment.Text;
                ExpenseItem.Name = cmbName.Text;
                ExpenseItem.Amount = int.Parse(nudAmount.Value.ToString());
                ExpenseItem.Type = rdbFixed.Checked ? "Fixed" : "Variable";
            }

            Winform_ExpenseDetails expenseDetails = Application.OpenForms["Winform_ExpenseDetails"] as Winform_ExpenseDetails;
            if (expenseDetails != null)
                expenseDetails.UpdateExpenseItems(ExpenseItem, index);

            UpdateStatus("Expense Item Saved", 100);
            this.Close();
        }

        protected override void CancelToolStrip_Click(object sender, EventArgs e)
        {
            if (Utilities.Validation.controlIsInEdit(this, true))
            {
                DialogResult dr = MessageBox.Show("Do you want to Exit?", "Exit", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;
            }

            this.Close();
        }

        private void cmbName_Validated(object sender, EventArgs e)
        {
            cmbName.Text = Utilities.Validation.ToTitleCase(cmbName.Text);
        }

        private void Winform_ExpenseItemDetails_Load(object sender, EventArgs e)
        {
            if (ExpenseItem != null)
            {
                if (ExpenseItem.Type == "Fixed")
                    rdbFixed.Checked = true;
                else
                    rdbVariable.Checked = true;

                if (namesList.IndexOf(this.ExpenseItem.Name) == -1)
                    namesList.Add(this.ExpenseItem.Name);

                nudAmount.Value = this.ExpenseItem.Amount;
                txtComment.Text = this.ExpenseItem.Comment;
                this.Expense = this.ExpenseItem.Expense;
            }
            else
            {
                namesList = ExpenseBuilder.GetExpenseNames(rdbFixed.Checked);
            }

            LoadExpenseNames(namesList);
        }
    }
}
