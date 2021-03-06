﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace budgetTracker
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Declaring variables
        static int i = 1;
        static int j = 1;

        //upon clicking save salary button the number in the text box will be stored in a label
        protected void saveSalaryButton_Click(object sender, EventArgs e)
        {
            monthlySalaryLabel.Text = salaryInput.Text;
            salaryInput.Text = String.Empty;
        }

        //This function adds a new label for every expense
        private void addExpenseNameLabel()
        {
            Label lbl = new Label();
            lbl.ID = "expense" + i.ToString();
            lbl.Text = expenseNameInput.Text;
            this.Controls.Add(lbl);
            expenseNameInput.Text = String.Empty;
            i++;
        }

        //This function adds a new amount label for every expense
        private void addExpenseAmountLabel()
        {
            Label lbl = new Label();
            lbl.ID = "expenseAmount" + j.ToString();
            lbl.Text = "$" + expenseAmountInput.Text;
            this.Controls.Add(lbl);
            j++;
        }

        //This function updates the remianing monthly budget
        private void updateRemainingBudget()
        {
            decimal monthlySalary;
            decimal expenseAmount;
            decimal.TryParse(monthlySalaryLabel.Text, out monthlySalary);
            decimal.TryParse(expenseAmountInput.Text, out expenseAmount);
            decimal newMonthlySalary = (monthlySalary - expenseAmount);
            monthlySalaryLabel.Text = "$" + newMonthlySalary.ToString() + " Left this month";
            expenseAmountInput.Text = String.Empty;
        }

        protected void addExpenseButton_Click(object sender, EventArgs e)
        {
            addExpenseNameLabel();
            addExpenseAmountLabel();
            updateRemainingBudget();
        }
    }
}