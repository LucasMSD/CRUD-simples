using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EstudoSQLServer
{
    public partial class frmAdicionar : Form
    {


        public frmAdicionar()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (camposEstaoPreenchidos())
            {
                List<String> dados = pegarDados();
                
                SqlServerConexao.Insert(dados);
                this.Close();
            } else
            {
                MessageBox.Show("Preencha todos os campos", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public bool camposEstaoPreenchidos()
        {
            bool tudoCerto = true;
            if (txtPrimeiroNome.Text == "") 
            {
                txtPrimeiroNome.BackColor = Color.IndianRed;
                tudoCerto = false;
            } else 
            {
                txtPrimeiroNome.BackColor = Color.White;
            }

            if (txtSobrenome.Text == "") {
                txtSobrenome.BackColor = Color.IndianRed;
                tudoCerto = false;
            }  else 
            {
                txtSobrenome.BackColor = Color.White;
            }

            if (mkbNascimento.Text == "") 
            {
                mkbNascimento.BackColor = Color.IndianRed;
                tudoCerto = false;
            } else
            {
                mkbNascimento.BackColor = Color.White;
                MessageBox.Show(mkbNascimento.Text);
            }

            if (cboEstadoCivil.Text == "")
            {
                cboEstadoCivil.BackColor = Color.IndianRed;
                tudoCerto = false;
            } else
            {
                cboEstadoCivil.BackColor = Color.White;
            }

            if (txtCidade.Text == "")
            {
                txtCidade.BackColor = Color.IndianRed;
                tudoCerto = false;
            } else
            {
                txtCidade.BackColor = Color.White;
            }

            if (cboUF.Text == "")
            {
                cboUF.BackColor = Color.IndianRed;
                tudoCerto = false;
            } else
            {
                cboUF.BackColor = Color.White;
            }

            if (txtEmail.Text == "")
            {
                txtEmail.BackColor = Color.IndianRed;
                tudoCerto = false;
            } else
            {
                txtEmail.BackColor = Color.White;
            }

            return tudoCerto;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private List<String> pegarDados()
        {
            List<String> dados = new List<String>();

            dados.Add(txtPrimeiroNome.Text);
            dados.Add(txtSobrenome.Text);
            dados.Add(mkbNascimento.Text);
            dados.Add(cboEstadoCivil.Text);
            dados.Add(txtCidade.Text);
            dados.Add(cboUF.Text);
            dados.Add(txtEmail.Text);

            return dados;
        }
    }
}
