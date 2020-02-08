using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace EstudoSQLServer
{
    public partial class Form1 : Form
    {
        Thread t;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'estudoDBDataSet.Pessoa' table. You can move, or remove it, as needed.
            this.pessoaTableAdapter.Fill(this.estudoDBDataSet.Pessoa);

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvPessoas.SelectedRows.Count == 0)
            {
                
                MessageBox.Show("Selecione uma ou mais linhas para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                
                if (MessageBox.Show("Tem certeza que desaja excluir os registros selecionados?", "Cuidado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dgvPessoas.SelectedRows)
                    {
                        SqlServerConexao.delete(Convert.ToInt32(row.Cells[0].Value));
                        dgvPessoas.Rows.Remove(row);
                    }   
                }
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            frmAdicionar frmAdicionar = new frmAdicionar();

            if (!frmAdicionar.Visible)
            {
                frmAdicionar.Show();
            } else
            {
                frmAdicionar.Close();
                frmAdicionar.Show();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            dgvPessoas.DataSource = SqlServerConexao.select();
        }
    }
}
