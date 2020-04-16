using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccessDbPlaygroundForm
{
    public partial class FormMain : Form
    {
        private string connStr;

        private BindingList<Studente> listStud;

        public FormMain()
        {
            InitializeComponent();
            listStud = new BindingList<Studente>();
        }

        private void btnSetConnectionString_Click(object sender, EventArgs e)
        {
            connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=TestStudenti.accdb";
        }

        private void btnReadStudents_Click(object sender, EventArgs e)
        {
            if (connStr != null)
            {
                OleDbConnection connection = new OleDbConnection(connStr);
                using (connection)
                {
                    OleDbCommand command = new OleDbCommand(
                      "SELECT Cognome, Nome FROM Studenti ORDER BY Cognome, Nome;",
                      connection);
                    connection.Open();

                    OleDbDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        listStud.Clear();
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}\t{1}", reader.GetString(0),
                                reader.GetString(1));
                            listStud.Add(new Studente(reader.GetString(0), reader.GetString(1)));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                        MessageBox.Show("No Students...");
                    }
                    reader.Close();
                }
                listBoxTest.DataSource = listStud;
            }
            else
            {
                MessageBox.Show("Set Connection String First");
            }
        }
    }
}
