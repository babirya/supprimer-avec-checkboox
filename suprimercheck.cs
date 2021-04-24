using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO; 


namespace developers
{
    public partial class suprimercheck : Form
    {
        public suprimercheck()
        {
            InitializeComponent();
        }

        ado d = new ado();

        public void remplir()
        {
            // this  one for eviter repitation 
            if (d.dt.Rows.Count != null)
            {
                d.dt.Rows.Clear();
            }

            d.conecter();
            d.cmd.CommandText = "select * from developers ";
            d.cmd.Connection = d.con;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            dataGridView1.DataSource = d.dt;
            d.dr.Close();


        }  
        // 1 un procedure pour ajouter un colone de type checkbook 

           void ajouterColone()
          {
              DataGridViewCheckBoxColumn check = new DataGridViewCheckBoxColumn();

              check.Name = "suppression";
              dataGridView1.Columns.Add(check);  


          } 

        // 2  un procedure pour la supprission  

           void supprimer()
           {
                foreach(DataGridViewRow r in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean( r.Cells["suppression"].Value) == true)
                    {
                        d.cmd.CommandText = "delete from developers where id = '"+r.Cells["id"].Value.ToString()+"' ";
                        d.cmd.Connection = d.con;
                        d.cmd.ExecuteNonQuery(); 
                    }
                }

                MessageBox.Show("supprission est bien fait ");
                remplir(); 


           }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void suprimercheck_Load(object sender, EventArgs e)
        {
             remplir();
             ajouterColone(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            supprimer(); 
        }
    }
}
