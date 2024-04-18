/* Title:           Logon
 * Date:            6-5-16
 * Author:          Terry Holmes
 *
 * Description:     This form is used to logon in */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagesDLL;
using EmployeeDLL;
using EventLogDLL;
using DataValidationDLL;
using LastTransactionDLL;

namespace SortTools
{
    public partial class Logon : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        EmployeeClass TheEmployeeClass = new EmployeeClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        DataValidationClass TheDataValidationClass = new DataValidationClass();
        LastTransactionClass TheLastTransactionClass = new LastTransactionClass();

        public static int mintWarehouseEmployeeID;
        public static string mstrFirstName;
        public static string mstrLastName;
        int mintNumberOfMisses;

        public Logon()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this will close the program
            TheMessagesClass.CloseTheProgram();
        }

        private void btnLogon_Click(object sender, EventArgs e)
        {
            //setting local variables
            string strEmployeeID;
            string strLastName;
            bool blnFatalError = false;
            bool blnThereIsAProblem = false;
            string strErrorMessage = "";
            bool blnVerifyEmployee = false;

            //beginning data validation
            strEmployeeID = txtEmployeeID.Text;
            strLastName = txtLogonLastName.Text;
            blnFatalError = TheDataValidationClass.VerifyIntegerData(strEmployeeID);
            if(blnFatalError == true)
            {
                blnThereIsAProblem = true;
                strErrorMessage = strErrorMessage + "Employee ID Was not an Integer\n";
            }
            blnFatalError = TheDataValidationClass.VerifyTextData(strLastName);
            if(blnFatalError == true)
            {
                blnThereIsAProblem = true;
                strErrorMessage = strErrorMessage + "The Last Name Was Not Entered\n";
            }
            if(blnThereIsAProblem == true)
            {
                TheMessagesClass.ErrorMessage(strErrorMessage);
                return;
            }

            //loading variables
            mintWarehouseEmployeeID = Convert.ToInt32(txtEmployeeID.Text);
            mstrLastName = txtLogonLastName.Text;

            blnVerifyEmployee = TheEmployeeClass.VerifyLogon(mintWarehouseEmployeeID, mstrLastName);

            if (blnVerifyEmployee == true)
            {
                mstrFirstName = TheEmployeeClass.FindEmployeeFirstNamewithID(mintWarehouseEmployeeID);

                TheMessagesClass.InformationMessage(mstrFirstName + " " + mstrLastName + " Has Logged In");
                TheLastTransactionClass.CreateLastTransactionEntry(mintWarehouseEmployeeID, mstrFirstName + " " + mstrLastName + " Has Logged In");

                SortToolForm SortToolForm = new SortToolForm();
                SortToolForm.Show();
                this.Hide();
            }
            else
            {
                TheMessagesClass.InformationMessage("Login Information Was Not Found");
                mintNumberOfMisses++;

                if(mintNumberOfMisses == 3)
                {
                    TheMessagesClass.ErrorMessage("The Have Been Three Attemps to Login\n The Application Will Close");
                    TheEventLogClass.CreateEventLogEntry("There Has Been Three Attempts to Open Sort Tools");
                    Application.Exit();
                }
            }
        }

        private void Logon_Load(object sender, EventArgs e)
        {
            mintNumberOfMisses = 0;
        }
    }
}
