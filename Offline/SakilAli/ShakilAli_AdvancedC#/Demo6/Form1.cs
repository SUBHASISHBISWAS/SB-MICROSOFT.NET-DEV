using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool flag;

        private void Start_Click(object sender, EventArgs e)
        {
            flag = true ;
            
            Task.Factory.StartNew( () =>
                {
                    int count = 0;
                    while (flag)
                    {
                        count++;

                        // switch the thread
                        Display.Invoke( new Action ( () =>
                            {
                                Display.Text = count.ToString();
                            } ) );

                       // Display.Text = count.ToString();
                    }
                });
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            flag = false;
        }


        private async void DataBtn_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("remoteServer:///", FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[1000];

            //int count = await fs.ReadAsync (buffer, 0, 1000 );
            // count = await fs.ReadAsync (buffer, 0, 1000 );
            // count = await fs.ReadAsync (buffer, 0, 1000 );

            // uses IO Completion port of Windows OS ( Network Device Driver )
            fs.BeginRead(buffer,0, 1000, (result) => {
             
                int count = fs.EndRead(result);
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine(buffer[i]);
                }

            }, null);


            SqlConnection connection = new SqlConnection("remote machine");
            SqlCommand command = new SqlCommand();
            command.CommandText = "select query";
            command.Connection = connection;
            // uses IO Completion port of Windows OS ( Network Device Driver )
            command.BeginExecuteReader((result) => {

                SqlDataReader reader = command.EndExecuteReader(result);
                while (reader.Read())
                {
                    Console.WriteLine(reader["ColumnName"]);
                }
            }, null);
        }
    }
}




