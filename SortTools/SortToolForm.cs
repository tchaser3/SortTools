/* Title:           Sort Tools
 * Date:            6-5-16
 * Author:          Terry Holmes
 *
 * Description:     This will sort the tool */

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
using ToolsDLL;
using KeyWordDLL;
using EventLogDLL;
using CSVFileDLL;

namespace SortTools
{
    public partial class SortToolForm : Form
    {
        //setting up the classes
        MessagesClass TheMessagesClass = new MessagesClass();
        EmployeeClass TheEmployeeClass = new EmployeeClass();
        ToolClass TheToolClass = new ToolClass();
        KeyWordClass TheKeyWordClass = new KeyWordClass();
        EventLogClass TheEventLogClass = new EventLogClass();
        PleaseWait PleaseWait = new PleaseWait();

        //setting up the data sets
        EmployeeDataSet TheEmployeeDataSet;
        ToolDataSet TheToolDataSet;

        //setting up the structures
        struct Tools
        {
            public string mstrToolID;
            public int mintEmployeeID;
            public string mstrType;
            public string mstrDescription;
            public string mstrActive;
        }

        //variables for tools
        Tools[] TheTools;
        int mintToolCounter;
        int mintToolUpperLimit;

        //setting up the employee structure
        struct Employees
        {
            public int mintEmployeeID;
            public string mstrFirstName;
            public string mstrLastName;
            public string mstrHomeOffice;
        }

        //variables for employee
        Employees[] TheEmployees;
        int mintEmployeeUpperLimit;

        Employees[] TheWarehouses;
        int mintWarehouseCounter;
        int mintWarehouseUpperLimit;

        Tools[] SearchResults;
        int mintResultCounter;
        int mintResultUpperLimit;

        //setting global variables
        string mstrErrorMessage;
        int mintWarehouseID;
        string mstrWarehouse;

        public SortToolForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this will close the application
            TheMessagesClass.CloseTheProgram();
        }

        private void SortToolForm_Load(object sender, EventArgs e)
        {
            //setting local variables
            bool blnFatalError = false;

            PleaseWait.Show();

            blnFatalError = LoadToolStructure();
            if (blnFatalError == false)
                blnFatalError = LoadEmployeeStructure();

            //creating the grid
            dgvSearchResults.ColumnCount = 4;
            dgvSearchResults.Columns[0].Name = "Tool ID";
            dgvSearchResults.Columns[0].Width = 100;
            dgvSearchResults.Columns[1].Name = "Tool Type";
            dgvSearchResults.Columns[1].Width = 100;
            dgvSearchResults.Columns[2].Name = "Description";
            dgvSearchResults.Columns[2].Width = 150;
            dgvSearchResults.Columns[3].Name = "Employee ID";
            dgvSearchResults.Columns[3].Width = 100;

            PleaseWait.Hide();

            if(blnFatalError == true)
            {
                TheMessagesClass.ErrorMessage(mstrErrorMessage);

                TheEventLogClass.CreateEventLogEntry("Sort Tools " + mstrErrorMessage);
            }
        }
        private bool LoadEmployeeStructure()
        {
            //setting local variables
            bool blnFatalError = false;
            int intCounter;
            int intNumberOfRecords;
            
            try
            {
                //loading the data set
                TheEmployeeDataSet = TheEmployeeClass.GetEmployeeInfo();

                //setting up for the loop
                intNumberOfRecords = TheEmployeeDataSet.employees.Rows.Count - 1;
                TheEmployees = new Employees[intNumberOfRecords + 1];
                TheWarehouses = new Employees[intNumberOfRecords + 1];
                mintEmployeeUpperLimit = intNumberOfRecords;
                mintWarehouseCounter = 0;
                cboWarehouse.Items.Add("SELECT");

                //beginning loop
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    //loading the employee structure
                    TheEmployees[intCounter].mintEmployeeID = Convert.ToInt32(TheEmployeeDataSet.employees.Rows[intCounter][0]);
                    TheEmployees[intCounter].mstrFirstName = Convert.ToString(TheEmployeeDataSet.employees.Rows[intCounter][1]).ToUpper();
                    TheEmployees[intCounter].mstrLastName = Convert.ToString(TheEmployeeDataSet.employees.Rows[intCounter][2]).ToUpper();
                    TheEmployees[intCounter].mstrHomeOffice = Convert.ToString(TheEmployeeDataSet.employees.Rows[intCounter][7]).ToUpper();

                    if(TheEmployees[intCounter].mstrLastName == "WAREHOUSE")
                    {
                        TheWarehouses[mintWarehouseCounter].mintEmployeeID = TheEmployees[intCounter].mintEmployeeID;
                        TheWarehouses[mintWarehouseCounter].mstrFirstName = TheEmployees[intCounter].mstrFirstName;
                        TheWarehouses[mintWarehouseCounter].mstrHomeOffice = TheEmployees[intCounter].mstrHomeOffice;
                        TheWarehouses[mintWarehouseCounter].mstrLastName = TheEmployees[intCounter].mstrLastName;
                        cboWarehouse.Items.Add(TheWarehouses[mintWarehouseCounter].mstrFirstName);
                        mintWarehouseUpperLimit = mintWarehouseCounter;
                        mintWarehouseCounter++;
                    }
                }

                mintWarehouseCounter = 0;
                cboWarehouse.SelectedIndex = 0;
            }
            catch (Exception Ex)
            {
                //message to user
                mstrErrorMessage = Ex.Message;

                //setting variables
                blnFatalError = true;
            }

            //returning value
            return blnFatalError;
        }
        //private method to load the tool grid
        private bool LoadToolStructure()
        {
            //setting local variables
            bool blnFatalError = false;
            int intCounter;
            int intNumberOfRecords;
            string strActive;
            
            try
            {
                //loading data set
                TheToolDataSet = TheToolClass.GetToolInfo();

                //setting up for the loop
                intNumberOfRecords = TheToolDataSet.tools.Rows.Count - 1;
                TheTools = new Tools[intNumberOfRecords + 1];
                SearchResults = new Tools[intNumberOfRecords + 1];
                mintToolCounter = 0;

                //running loop
                for(intCounter = 0; intCounter <= intNumberOfRecords; intCounter++)
                {
                    strActive = Convert.ToString(TheToolDataSet.tools.Rows[intCounter][10]).ToUpper();

                    if(strActive == "YES")
                    {
                        TheTools[mintToolCounter].mintEmployeeID = Convert.ToInt32(TheToolDataSet.tools.Rows[intCounter][2]);
                        TheTools[mintToolCounter].mstrActive = strActive;
                        TheTools[mintToolCounter].mstrDescription = Convert.ToString(TheToolDataSet.tools.Rows[intCounter][6]).ToUpper();
                        TheTools[mintToolCounter].mstrToolID = Convert.ToString(TheToolDataSet.tools.Rows[intCounter][1]).ToUpper();
                        TheTools[mintToolCounter].mstrType = Convert.ToString(TheToolDataSet.tools.Rows[intCounter][5]).ToUpper();
                        mintToolUpperLimit = mintToolCounter;
                        mintToolCounter++;
                    }
                }

                mintToolCounter = 0;
            }
            catch (Exception Ex)
            {
                //message to user
                mstrErrorMessage = Ex.Message;

                //setting variables
                blnFatalError = true;
            }

            //returning value
            return blnFatalError;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            //setting local variables
            int intEmployeeCounter = 0;
            int intToolCounter = 0;
            bool blnItemNotFound = true;

            dgvSearchResults.Rows.Clear();

            //setting up for the loop
            mintResultCounter = 0;

            //beginning the first loop
            for(intToolCounter = 0; intToolCounter <= mintToolUpperLimit; intToolCounter++)
            {
                //setting bool variable
                blnItemNotFound = true;

                //checking to see if the tool belongs to the warehouse
                if(TheTools[intToolCounter].mintEmployeeID == mintWarehouseID)
                {
                    blnItemNotFound = false;
                }
                else
                {
                    //setting up for the employee loop
                    for(intEmployeeCounter = 0; intEmployeeCounter <= mintEmployeeUpperLimit; intEmployeeCounter++)
                    {
                        if(TheTools[intToolCounter].mintEmployeeID == TheEmployees[intEmployeeCounter].mintEmployeeID)
                        {
                            if(TheEmployees[intEmployeeCounter].mstrHomeOffice == mstrWarehouse)
                            {
                                blnItemNotFound = false;
                            }
                        }
                    }
                }
                
                if(blnItemNotFound == false)
                {
                    SearchResults[mintResultCounter].mintEmployeeID = TheTools[intToolCounter].mintEmployeeID;
                    SearchResults[mintResultCounter].mstrActive = TheTools[intToolCounter].mstrActive;
                    SearchResults[mintResultCounter].mstrDescription = TheTools[intToolCounter].mstrDescription;
                    SearchResults[mintResultCounter].mstrToolID = TheTools[intToolCounter].mstrToolID;
                    SearchResults[mintResultCounter].mstrType = TheTools[intToolCounter].mstrType;
                    mintResultUpperLimit = mintResultCounter;
                    mintResultCounter++;
                }

            }

            mintResultCounter = 0;
            LoadComboBox();
        }
        private void LoadComboBox()
        {
            //setting local variables
            int intCounter;
            string[] NewGridRow;

            for(intCounter = 0; intCounter <= mintResultUpperLimit; intCounter++)
            {
                NewGridRow = new string[] { SearchResults[intCounter].mstrToolID, SearchResults[intCounter].mstrType, SearchResults[intCounter].mstrDescription, Convert.ToString(SearchResults[intCounter].mintEmployeeID) };
                dgvSearchResults.Rows.Add(NewGridRow);
            }
        }
        private void cboWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this will set the warehouse id
            int intCounter;
            string strWarehouseForSearch;

            if(cboWarehouse.Text != "SELECT")
            {
                //getting the warehouse name
                strWarehouseForSearch = cboWarehouse.Text;

                for(intCounter = 0; intCounter <= mintWarehouseUpperLimit; intCounter++)
                {
                    if(strWarehouseForSearch == TheWarehouses[intCounter].mstrFirstName)
                    {
                        mintWarehouseID = TheWarehouses[intCounter].mintEmployeeID;
                        mstrWarehouse = strWarehouseForSearch;
                    }
                }
            }
        }

        private void btnExportToCSV_Click(object sender, EventArgs e)
        {
            //setting local variables
            int intCounter;

            //try catch for exceptions
            try
            {
                //creating the file writer
                ReadWirteCSV.CsvFileWriter TheReconCSV = new ReadWirteCSV.CsvFileWriter("f:\\warehouse\\whsetrac\\tools.CSV");

                //calling the writer
                using (TheReconCSV)
                {
                    for (intCounter = 0; intCounter <= mintResultUpperLimit; intCounter++)
                    {
                        //creating a new row
                        ReadWirteCSV.CsvRow NewCSVRow = new ReadWirteCSV.CsvRow();

                        NewCSVRow.Add(SearchResults[intCounter].mstrToolID);
                        NewCSVRow.Add(SearchResults[intCounter].mstrType);
                        NewCSVRow.Add(Convert.ToString(SearchResults[intCounter].mstrDescription));
                        NewCSVRow.Add(Convert.ToString(SearchResults[intCounter].mintEmployeeID));
                        
                        //writing the new row
                        TheReconCSV.WriteRow(NewCSVRow);
                    }
                }

                //output to user
                TheMessagesClass.InformationMessage("The File Has Been Created And Saved Under\n WHSETrac folder contained in the Warehouse Folder");
            }
            catch (Exception Ex)
            {
                //message to user
                TheMessagesClass.ErrorMessage(Ex.Message);

                //event log entry
                TheEventLogClass.CreateEventLogEntry("Exporting CSV File " + Ex.Message);
            }
        }
    }
}
