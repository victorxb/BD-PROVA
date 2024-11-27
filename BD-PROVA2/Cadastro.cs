using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BD_PROVA2
{
    internal class CadastroColaboradores
    {
        private int id;
        private string ctps;
        private string pis;
        private string tituloEleitor;
        private bool reservista;
        private string estadoCivil;
        private int numDependentes;
        private bool ativo;
        private string setor;
        private string cargo;
        private float salario;
        private string telefone1;
        private string telefone2;
        private string emailPessoal;
        private string emailCorporativo;

        public int Id
        {
            get { return id; }
            set { id = value;  }
        }

        public string Ctps
        {
            get { return ctps; }
            set { ctps = value; }
        }
        public string Pis
        {
            get { return pis; }
            set { pis = value; }
        }

        public string TituloEleitor
        {
            get { return tituloEleitor; }
            set { tituloEleitor = value; }
        }

        public bool Reservista
        {
            get { return reservista; }
            set { reservista = value; }
        }

        public string EstadoCivil
        {
            get { return estadoCivil; }
            set { estadoCivil = value; }
        }

        public int NumDependentes
        {
            get { return numDependentes; }
            set { numDependentes = value; }
        }

        public bool Ativo
        {
            get { return ativo; }
            set { ativo = value; }
        }

        public string Setor
        {
            get { return setor; }
            set { setor = value; }
        }

        public string Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        public float Salario
        {
            get { return salario; }
            set { salario = value; }
        }

        public string Telefone1
        {
            get { return telefone1; }
            set { telefone1 = value; }
        }

        public string Telefone2
        {
            get { return telefone2; }
            set { telefone2 = value; }
        }

        public string EmailPessoal
        {
            get { return emailPessoal; }
            set { emailPessoal = value; }
        }

        public string EmailCorporativo
        {
            get { return emailCorporativo; }
            set { emailCorporativo = value; }
        }

        public bool cadastrarColaboradores()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MysqlConexaoBanco.Open();

                string insert = $"INSERT INTO Colaboradores (Ctps, Pis, TituloEleitor, Reservista, EstadoCivil, NumDependentes, Ativo, Setor, Cargo, Salario, Telefone1, Telefone2, EmailPessoal, EmailCorporativo) " +
                $"VALUES ('{Ctps}', '{Pis}', '{TituloEleitor}', {(Reservista ? 1 : 0)}, '{EstadoCivil}', {NumDependentes}, {(Ativo ? 1 : 0)}, '{Setor}', '{Cargo}', {Salario}, '{Telefone1}', '{Telefone2}', '{EmailPessoal}', '{EmailCorporativo}')";
                MySqlCommand comandoSql = MysqlConexaoBanco.CreateCommand();
                comandoSql.CommandText = insert;
            
                comandoSql.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados ao cadastrar " + ex.Message);
                return false;
            }
        }

        public MySqlDataReader localizarColaborador()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MysqlConexaoBanco.Open();

                string select = $"SELECT Id, Ctps, Pis, TituloEleitor, Reservista, EstadoCivil, NumDependentes, Ativo, Setor, Cargo, Salario, Telefone1, Telefone2, EmailPessoal, EmailCorporativo FROM Colaboradores WHERE Ctps = {Ctps};";


                MySqlCommand comandoSql = MysqlConexaoBanco.CreateCommand();
                comandoSql.CommandText = select;

                MySqlDataReader reader = comandoSql.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados na hora de visualizar" + ex.Message);
                return null;

            }
        }

        public bool atualizarColaborador()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MysqlConexaoBanco.Open();

                string update = $"UPDATE Colaboradores SET Ctps = '{Ctps}', Pis = '{Pis}', TituloEleitor = '{TituloEleitor}', Reservista = {(Reservista ? 1 : 0)}, EstadoCivil = '{EstadoCivil}', NumDependentes = {NumDependentes}, Ativo = {(Ativo ? 1 : 0)}, Setor = '{Setor}', Cargo = '{Cargo}', Salario = {Salario}, Telefone1 = '{Telefone1}', Telefone2 = '{Telefone2}', EmailPessoal = '{EmailPessoal}', EmailCorporativo = '{EmailCorporativo}' WHERE Id = {Id}";

                MySqlCommand commandoSql = MysqlConexaoBanco.CreateCommand();
                commandoSql.CommandText = update;

                commandoSql.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no banco de dados na hora de atualizar" + ex.Message);
                return false;
            }
        }
        public bool deletarColaborador()
        {
            try
            {
                MySqlConnection MysqlConexaoBanco = new MySqlConnection(ConexaoBanco.bancoServidor);
                MysqlConexaoBanco.Open();

                string delete = $"delete from Colaboradores where id = '{Id}';";
                MySqlCommand comandoSql = MysqlConexaoBanco.CreateCommand();

                comandoSql.CommandText= delete;
                comandoSql.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro no banco de dados na hora de deletar" + ex.Message);
                return false;
            }
        }
    }
}
