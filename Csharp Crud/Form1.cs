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
using Csharp_Crud.Controllers.Controllers;

namespace Csharp_Crud
{
    public partial class Form1 : Form
    {
        //string connection = "datasource=localhost;port=3306;user Id=root;password=;database=csharp;SSL Mode=None";
        //Database db = new Database();
        UserController crud = new UserController();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //CREATE
            try
            {
                Create();
                Read();
                MessageBox.Show("inserted");
                crud.name = txtName.Text = "";
                crud.age = txtAge.Text = "";
                crud.hobby = comboHobby.Text = "";

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error create" + ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try { 
            //UPDATE
            updateData();
            Read();
            crud.name = txtName.Text = "";
            crud.age = txtAge.Text = "";
            crud.hobby = comboHobby.Text = "";
                crud.id = txtID.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error up" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //DELETE
                Delete();
                Read();
        }
            catch(Exception ex)
            {
                MessageBox.Show("Error del" + ex.Message);
            }

}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Read();
        }

        public void Create()
        {
            crud.name = txtName.Text;
            crud.age = txtAge.Text;
            crud.hobby = comboHobby.Text;
            crud.create_data();
        }

        public void Read()
        {
            dataGridView1.DataSource = null;
            crud.read_data();
            dataGridView1.DataSource = crud.dt;
        }


        public void updateData()
        {

            crud.name = txtName.Text;
            crud.age = txtAge.Text;
            crud.hobby = comboHobby.Text;
            crud.id = txtID.Text;
            crud.update_data();
        }

        public void Delete()
        {
            crud.id = txtID.Text;
            crud.delete_data();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //GET SELECTED DATA
            DataGridView senderGrid = (DataGridView)sender;
            try
            {
                if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    txtID.Text = (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    txtName.Text = (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    txtAge.Text = (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    comboHobby.Text = (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        //SEARCH
        public void Search()
        {
           txtName.Text = crud.name;
            txtAge.Text = crud.age;
            comboHobby.Text = crud.hobby;
            txtID.Text = crud.id;
            crud.id = txtSearch.Text;
            crud.search_data();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Search();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
