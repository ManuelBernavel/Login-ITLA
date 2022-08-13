﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationAndLogin
{
    public partial class Registration : Form
    {

        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;

        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dilel\Desktop\RegistrationAndLogin\Database.mdf;Integrated Security=True");
            cn.Open();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (txtmail.Text != string.Empty || txtpassword.Text != string.Empty || txtusername.Text != string.Empty)
            {
               
                    cmd = new SqlCommand("select * from LoginTable where username='" + txtusername.Text + "'", cn);
                    dr = cmd.ExecuteReader();
                    
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into LoginTable values(@username,@password,@mail,@phone)", cn);
                        cmd.Parameters.AddWithValue("username", txtusername.Text);
                        cmd.Parameters.AddWithValue("password", txtpassword.Text);
                        cmd.Parameters.AddWithValue("mail", txtmail.Text);
                        cmd.Parameters.AddWithValue("phone", txtphone.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Su cuenta ha sido creada con exito!.", "Listo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                

            }
            else
            {
                MessageBox.Show("Porfavor llene todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }
    }
}
