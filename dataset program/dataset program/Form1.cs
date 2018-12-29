using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace dataset_program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlDataAdapter adapter;
        DataSet ds;
        string con = "Data Source=NETDEVELOPER-PC;Initial Catalog=TBS;Integrated Security=True";
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            adapter = new SqlDataAdapter("select * from login", con);
            ds = new DataSet();
            adapter.Fill(ds,"employee");
             new SqlCommandBuilder(adapter);
             dataGrid1.DataSource = ds;
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                comboBox1.Items.Add(ds.Tables[0].Rows[i][0]);
            }
          int j = ds.Tables[0].Rows.Count - 1;
            if (j >= 0)
            {
                textBox1.Text = ds.Tables[0].Rows[0][0].ToString();
                textBox2.Text = ds.Tables[0].Rows[0][1].ToString();
                textBox3.Text = ds.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                MessageBox.Show("No found data", "TCS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e) //insert_button
        {
            try
            {
                DataRow row;
                row = ds.Tables[0].NewRow();
                row[0] = long.Parse(textBox1.Text);
                row[1] = textBox2.Text;
                row[2] = textBox3.Text;
                ds.Tables[0].Rows.Add(row);
                comboBox1.Items.Add(int.Parse(textBox1.Text));
                adapter.Update(ds, "employee");
                MessageBox.Show("inserted successfully");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox1.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
        }

        private void button2_Click(object sender, EventArgs e)//delete_button
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    if (textBox1.Text.Equals(ds.Tables[0].Rows[i][0].ToString()))
                    {
                        comboBox1.Items.Remove(ds.Tables[0].Rows[i][0]);
                        ds.Tables[0].Rows[i].Delete();

                    }
                }

                adapter.Update(ds, "employee");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                comboBox1.Focus();
            }
            else
            {
                MessageBox.Show("No found data");
            }
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)//added the id when we insert
        {

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                if (comboBox1.SelectedItem.ToString().Equals(ds.Tables[0].Rows[i][0].ToString()))
                {
                    textBox1.Text = ds.Tables[0].Rows[i][0].ToString();
                    textBox2.Text = ds.Tables[0].Rows[i][1].ToString();
                    textBox3.Text = ds.Tables[0].Rows[i][2].ToString();
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)//update_button
        {

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                if (comboBox1.SelectedItem.ToString().Equals(ds.Tables[0].Rows[i][0].ToString()))
                {
                    ds.Tables[0].Rows[i][0] = int.Parse(textBox1.Text);
                    ds.Tables[0].Rows[i][1] = textBox2.Text;
                    ds.Tables[0].Rows[i][2] = textBox3.Text;
                    comboBox1.Items[i] = ds.Tables[0].Rows[i][0];
                }
            }
             adapter.Update(ds, "employee");
             MessageBox.Show("update successfully");
        }

        private void button4_Click_1(object sender, EventArgs e)//first_button
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                textBox1.Text = ds.Tables[0].Rows[0][0].ToString();
                textBox2.Text = ds.Tables[0].Rows[0][1].ToString();
                textBox3.Text = ds.Tables[0].Rows[0][2].ToString();
            }
            else
            {
                MessageBox.Show("No found data", "TCS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button5_Click(object sender, EventArgs e)//last_button
        {
            int i = ds.Tables[0].Rows.Count - 1;
            if (i >= 0)
            {
                textBox1.Text = ds.Tables[0].Rows[i][0].ToString();
                textBox2.Text = ds.Tables[0].Rows[i][1].ToString();
                textBox3.Text = ds.Tables[0].Rows[i][2].ToString();
            }
            else 
            {
                MessageBox.Show("No found data","TCS",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void button6_Click(object sender, EventArgs e)//previous_button
        {
            int c = ds.Tables[0].Rows.Count -1;
            for (int i = c; i >=1; i--)
            {
                if (ds.Tables[0].Rows[i][0].ToString().Equals(textBox1.Text))
                {
                    i--;
                    textBox1.Text = ds.Tables[0].Rows[i][0].ToString();
                    textBox2.Text = ds.Tables[0].Rows[i][1].ToString();
                    textBox3.Text = ds.Tables[0].Rows[i][2].ToString();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)//next_button
        {
            int c = ds.Tables[0].Rows.Count - 1;
            for (int i = 0; i<c; i++)
            {
                if (ds.Tables[0].Rows[i][0].ToString().Equals(textBox1.Text))
                {
                    i++;
                    textBox1.Text = ds.Tables[0].Rows[i][0].ToString();
                    textBox2.Text = ds.Tables[0].Rows[i][1].ToString();
                    textBox3.Text = ds.Tables[0].Rows[i][2].ToString();
                }
            }
        }
    }
}
