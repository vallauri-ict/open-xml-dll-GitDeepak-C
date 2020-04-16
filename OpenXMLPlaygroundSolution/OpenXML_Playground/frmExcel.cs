using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenXML_DLLProject;

namespace OpenXML_Playground
{
    public partial class frmExcel : Form
    {
        public frmExcel()
        {
            InitializeComponent();
        }

        private void btnSimpleTest_Click(object sender, EventArgs e)
        {
            TestModelList tmList = new TestModelList();
            tmList.testData = new List<TestModel>();
            TestModel tm = new TestModel();
            tm.TestId = 1;
            tm.TestName = "Test1";
            tm.TestDesc = "Tested 1 time";
            tm.TestDate = DateTime.Now.Date;
            tmList.testData.Add(tm);

            TestModel tm1 = new TestModel();
            tm1.TestId = 2;
            tm1.TestName = "Test2";
            tm1.TestDesc = "Tested 2 times";
            tm1.TestDate = DateTime.Now.AddDays(-1);
            tmList.testData.Add(tm1);

            TestModel tm2 = new TestModel();
            tm2.TestId = 3;
            tm2.TestName = "Test3";
            tm2.TestDesc = "Tested 3 times";
            tm2.TestDate = DateTime.Now.AddDays(-2);
            tmList.testData.Add(tm2);

            TestModel tm3 = new TestModel();
            tm3.TestId = 4;
            tm3.TestName = "Test4";
            tm3.TestDesc = "Tested 4 times";
            tm3.TestDate = DateTime.Now.AddDays(-3);
            tmList.testData.Add(tm);

            openXmlUtilitiesExcel.CreateExcelFile(tmList, @"");
        }
    }
}