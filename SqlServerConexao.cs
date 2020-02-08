using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using EstudoSQLServer.estudoDBDataSetTableAdapters;

namespace EstudoSQLServer
{
    abstract class SqlServerConexao
    {
        private static SqlConnection conexao = new SqlConnection("Data Source=DESKTOP-5LSHH6H;Initial Catalog=estudoDB;Integrated Security=True");

        public static void Insert(List<String> dados)
        {
            string sqlCommandString = $"insert into Pessoa values (@0, @1, @2, @3, @4, @5, @6);";


            try
            {

                SqlCommand insertRegisto = new SqlCommand(sqlCommandString, conexao);

                conexao.Open();

                foreach (string valor in dados)
                {
                    insertRegisto.Parameters.Add(new SqlParameter($"@{dados.IndexOf(valor)}", valor));
                }

                insertRegisto.ExecuteNonQuery();

                conexao.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.ToString());
                conexao.Close();
            }
        }

        public static BindingSource select()
        {

            conexao.Open();

            PessoaTableAdapter pessoaTableAdapter = new PessoaTableAdapter();

            pessoaTableAdapter.Adapter.SelectCommand = new SqlCommand("select * from Pessoa", conexao);

            estudoDBDataSet.PessoaDataTable table = new estudoDBDataSet.PessoaDataTable();

            pessoaTableAdapter.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;

            conexao.Close();
            return bSource;

        }

        public static void delete(int id)
        {
            try
            {
                conexao.Open();

                SqlCommand delete = new SqlCommand($"delete from Pessoa where PessoaID = {id}", conexao);

                delete.ExecuteNonQuery();

                conexao.Close();
            } catch (SqlException error)
            {
                MessageBox.Show(error.ToString());
            }
            
        }
    }
}
