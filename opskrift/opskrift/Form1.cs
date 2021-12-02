
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace opskrift

{
    public partial class Form1 : Form
    {
        MySqlConnection connection = new MySqlConnection("SERVER= 192.168.16.146;PORT= 3306;DATABASE= Opskrift;UID= test2;PASSWORD= test2;");


        public Form1()
        {
            InitializeComponent();
            display_data();
            combobreaker();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();

                return true;

            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void Button1_Click(object sender, EventArgs e)
        {


            //open connection
            connection.Open();
            string text = "USE Opskrift;";
            string cm = "CREATE TABLE " + textBox1.Text + " ( Ingredienser varchar(255), Mål varchar(255), Portioner varchar(255), Bagetid varchar(255) );";

            string query = "Insert into " + textBox1.Text + "(ingredienser,mål, portioner, bagetid) values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "');";


            //create command and assign the query and connection from the constructor
            MySqlCommand cmd = new MySqlCommand(text, connection);
            cmd.ExecuteNonQuery();

            MySqlCommand cmd1 = new MySqlCommand(cm, connection);
            cmd1.ExecuteNonQuery();
            MySqlCommand cmd2 = new MySqlCommand(query, connection);
            cmd2.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Data Inserted Succesfully");
            
            combobreaker();

            //close connection

        }

        public void Button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            string newingrediens = textBox9.Text;
            string newmål = textBox8.Text;
            string newportion = textBox7.Text;
            string newbagetid = textBox6.Text;
            string query = "update Opskrift SET Ingredienser = '" + newingrediens + "', Mål = '" + newmål + "', Portioner = '" + newportion + "', Bagetid = '" + newbagetid + "' where Navn = '" + comboBox1.Text + "'";
            
            combobreaker();

            MySqlCommand cmd = new MySqlCommand(query, connection);

            cmd.ExecuteNonQuery();
            connection.Close();

        }

        public void Button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            string text = "USE Opskrift;";
            string query = "DROP TABLE " + comboBox2.Text + ";";

            MySqlCommand cmd1 = new MySqlCommand(text, connection);
            cmd1.ExecuteNonQuery();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            
            connection.Close();
            
            combobreaker();


        }

        public List<string>[] Select()
        {
            string query = "SELECT * FROM " + textBox1.Text;

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();
            list[5] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id"] + "");
                    list[1].Add(dataReader["ingredienser"] + "");
                    list[2].Add(dataReader["mål"] + "");
                    list[3].Add(dataReader["portioner"] + "");
                    list[4].Add(dataReader["bagetid"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        public void display_data()
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("show tables;", connection);
            MySqlDataReader mySql;
            mySql = cmd.ExecuteReader();
            cmd.CommandType = CommandType.Text;
            
            while(mySql.Read())
            {
                this.comboBox1.Items.Add(mySql.GetString(0));
                this.comboBox2.Items.Add(mySql.GetString(0));
                
            }
            connection.Close();
        }

        public void combobreaker()
        {

            textBox1.ResetText();
            textBox1.Clear();

            textBox2.ResetText();
            textBox2.Clear();

            textBox3.ResetText();
            textBox3.Clear();

            textBox4.ResetText();
            textBox4.Clear();

            textBox5.ResetText();
            textBox5.Clear();

            comboBox1.Items.Clear();
            comboBox1.ResetText();
            comboBox2.Items.Clear();
            comboBox2.ResetText();
            display_data();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
            
        
    }
}