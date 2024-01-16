using PROJECT1.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PROJECT1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ProductsList();
            CatogoryList();
        }

        private void ProductListByCategory(int categoryId)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgwProduct.DataSource = context.Products.Where(p=>p.CategoryId==categoryId).ToList();
                //list product in datagridview acording to combobox1.valuemember(categoryId)
            }
        }
        private void ProductListByProductName(string key)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgwProduct.DataSource = context.Products.Where(p => p.ProductName.ToLower().Contains(key.ToLower())).ToList();
                //list product in datagridview acording to the text in seachbox (every letter accept in lower case ) 
            }
        }
        private void ProductListByProductId(int key)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgwProduct.DataSource = context.Products.Where(p => p.ProductId==key).ToList();
                //searching product by id
            }
        }

        private void ProductsList()
        {
            using (NorthwindContext context = new NorthwindContext()) //DIRECTLY RUN NORTHWIND, DO NOT WAIT GARBAGE COLLECTOR
            {
                dgwProduct.DataSource = context.Products.ToList();  //SELECT * FROM PRODUCTS
            }
        }
        private void CatogoryList()
        {
            using (NorthwindContext context = new NorthwindContext()) //DIRECTLY RUN NORTHWİND, DO NOT WAIT GARBAGE COLLECTOR
            {
                comboBox1.DataSource = context.Categories.ToList();  //SELECT * FROM PRODUCTS
                comboBox1.DisplayMember = "CategoryName";
                comboBox1.ValueMember = "CategoryId";//every category contect to product with their Id (PİRİMARY KEY/FOREIGN KEY)
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ProductListByCategory(Convert.ToInt32(comboBox1.SelectedValue));//have to use int format 
            }
            catch
            {

            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string key = txtSearch.Text;
            if (string.IsNullOrEmpty(key))
            {
                ProductsList();
            }
            else 
            {
                ProductListByProductName(key);
            }
        }

        private void txtSeacrhID_TextChanged(object sender, EventArgs e)
        {

            try
            {

                if (txtSeacrhID.Text.Length>0)
                {
                    int key = Convert.ToInt32(txtSeacrhID.Text);

                    ProductListByProductId(key);

                }
                else 
                {
                    ProductsList();
                }
                
            }
            catch 
            {

            }
             
        }
    }
}
