using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace BD_PROVA2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CadastrarClick(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCtps.Text) &&
                    !string.IsNullOrEmpty(txtPis.Text) &&
                    !string.IsNullOrEmpty(txtEleitor.Text) &&
                    !string.IsNullOrEmpty(txtSal.Text) &&
                    !string.IsNullOrEmpty(txtSetor.Text) &&
                    !string.IsNullOrEmpty(txtCargo.Text) &&
                    !string.IsNullOrEmpty(txtEmailC.Text) &&
                    !string.IsNullOrEmpty(txtEmail.Text) &&
                    !string.IsNullOrEmpty(txtDepend.Text) &&
                    !string.IsNullOrEmpty(txtEstadoCiv.Text) &&
                    !string.IsNullOrEmpty(txtContato.Text) &&
                    !string.IsNullOrEmpty(txtContato2.Text))
                {
                    CadastroColaboradores cadColaboradores = new CadastroColaboradores
                    {
                        Ctps = txtCtps.Text,
                        Pis = txtPis.Text,
                        TituloEleitor = txtEleitor.Text,
                        Setor = txtSetor.Text,
                        Cargo = txtCargo.Text,
                        EmailCorporativo = txtEmailC.Text,
                        EmailPessoal = txtEmail.Text,
                        EstadoCivil = txtEstadoCiv.Text,
                        Telefone1 = txtContato.Text,
                        Telefone2 = txtContato2.Text,
                        Reservista = txtReser.Checked,
                        Ativo = txtAtivo.Checked    
                    };

                    if (float.TryParse(txtSal.Text, out float salario))
                    {
                        cadColaboradores.Salario = salario;
                    }
                    else
                    {
                        MessageBox.Show("O campo Salário deve ser um número válido.");
                        return;
                    }

                    if (int.TryParse(txtDepend.Text, out int dependentes))
                    {
                        cadColaboradores.NumDependentes = dependentes;
                    }
                    else
                    {
                        MessageBox.Show("O campo Número de Dependentes deve ser um número válido.");
                        return;
                    }

                    // Tenta cadastrar no banco
                    if (cadColaboradores.cadastrarColaboradores())
                    {
                        MessageBox.Show("Colaborador cadastrado com sucesso!");
                        LimparCampos(); // Limpa os campos após o cadastro
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar o colaborador.");
                    }
                }
                else
                {
                    MessageBox.Show("Favor preencher todos os campos corretamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar colaborador: " + ex.Message);
            }
        }

        private void LimparCampos()
        {
            // Limpar campos de texto
            txtCtps.Text = "";
            txtPis.Text = "";
            txtEleitor.Text = "";
            txtSal.Text = "";
            txtSetor.Text = "";
            txtCargo.Text = "";
            txtEmailC.Text = "";
            txtEmail.Text = "";
            txtDepend.Text = "";
            txtEstadoCiv.Text = "";
            txtContato.Text = "";
            txtContato2.Text = "";

            // Desmarcar checkboxes
            txtAtivo.Checked = false;
            txtReser.Checked = false;
        }

        private void txtReser_CheckedChanged(object sender, EventArgs e)
        {
            // Implementação futura (se necessário)
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCtps.Text) &&
                    !string.IsNullOrEmpty(txtPis.Text) &&
                    !string.IsNullOrEmpty(txtEleitor.Text) &&
                    !string.IsNullOrEmpty(txtSal.Text) &&
                    !string.IsNullOrEmpty(txtSetor.Text) &&
                    !string.IsNullOrEmpty(txtCargo.Text) &&
                    !string.IsNullOrEmpty(txtEmailC.Text) &&
                    !string.IsNullOrEmpty(txtEmail.Text) &&
                    !string.IsNullOrEmpty(txtDepend.Text) &&
                    !string.IsNullOrEmpty(txtEstadoCiv.Text) &&
                    !string.IsNullOrEmpty(txtContato.Text) &&
                    !string.IsNullOrEmpty(txtContato2.Text))
                {
                    CadastroColaboradores cadColaboradores = new CadastroColaboradores();
                    cadColaboradores.Id = int.Parse(idCont.Text);
                    if (cadColaboradores.deletarColaborador())
                    {
                        MessageBox.Show("Colaborador excluido com sucesso.");
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel deletar colaborador");
                        LimparCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Pesquisar dados do funcionaro que será deletado.");
                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir colaborador" + ex.Message);
            }
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtCtps.Text.Equals(""))
                {
                    CadastroColaboradores cadColaboradores = new CadastroColaboradores();
                    cadColaboradores.Ctps = txtCtps.Text;

                    MySqlDataReader reader = cadColaboradores.localizarColaborador();

                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            // Atribuição dos valores aos campos
                            idCont.Text = reader["id"].ToString();
                            txtCtps.Text = reader["Ctps"].ToString();
                            txtPis.Text = reader["Pis"].ToString();
                            txtEleitor.Text = reader["TituloEleitor"].ToString();
                            txtSal.Text = reader["Salario"].ToString();
                            txtSetor.Text = reader["Setor"].ToString();
                            txtCargo.Text = reader["Cargo"].ToString();
                            txtEmailC.Text = reader["EmailCorporativo"].ToString();
                            txtEmail.Text = reader["EmailPessoal"].ToString();
                            txtDepend.Text = reader["NumDependentes"].ToString();
                            txtEstadoCiv.Text = reader["EstadoCivil"].ToString();
                            txtContato.Text = reader["Telefone1"].ToString();
                            txtContato2.Text = reader["Telefone2"].ToString();
                            txtReser.Checked = Convert.ToBoolean(reader["Reservista"]);
                            txtAtivo.Checked = Convert.ToBoolean(reader["Ativo"]);
                        }
                        else
                        {
                            MessageBox.Show("Colaborador não encontrado.");
                            LimparCampos();
                            txtCtps.Focus();
                            idCont.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Colaborador não encontrado.");
                        LimparCampos();
                        txtCtps.Focus();
                        idCont.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Preencher o campo Cpts para fazer a pesquisa");
                    LimparCampos();
                    txtCtps.Focus();
                    idCont.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao encontrar colaborador" + ex.Message);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCtps.Text) &&
                    !string.IsNullOrEmpty(txtPis.Text) &&
                    !string.IsNullOrEmpty(txtEleitor.Text) &&
                    !string.IsNullOrEmpty(txtSal.Text) &&
                    !string.IsNullOrEmpty(txtSetor.Text) &&
                    !string.IsNullOrEmpty(txtCargo.Text) &&
                    !string.IsNullOrEmpty(txtEmailC.Text) &&
                    !string.IsNullOrEmpty(txtEmail.Text) &&
                    !string.IsNullOrEmpty(txtDepend.Text) &&
                    !string.IsNullOrEmpty(txtEstadoCiv.Text) &&
                    !string.IsNullOrEmpty(txtContato.Text) &&
                    !string.IsNullOrEmpty(txtContato2.Text))
                {
                    CadastroColaboradores cadColaboradores = new CadastroColaboradores();
                    cadColaboradores.Id = int.Parse(idCont.Text);
                    cadColaboradores.Ctps = txtCtps.Text;
                    cadColaboradores.Pis = txtPis.Text;
                    cadColaboradores.TituloEleitor = txtEleitor.Text;
                    cadColaboradores.Setor = txtSetor.Text;
                    cadColaboradores.Cargo = txtCargo.Text;
                    cadColaboradores.EmailCorporativo = txtEmailC.Text;
                    cadColaboradores.EmailPessoal = txtEmail.Text;
                    cadColaboradores.EstadoCivil = txtEstadoCiv.Text;
                    cadColaboradores.Telefone1 = txtContato.Text;
                    cadColaboradores.Telefone2 = txtContato2.Text;
                    cadColaboradores.Reservista = txtReser.Checked;
                    cadColaboradores.Ativo = txtAtivo.Checked;
                    if (float.TryParse(txtSal.Text, out float salario))
                    {
                        cadColaboradores.Salario = salario;
                    }
                    else
                    {
                        MessageBox.Show("O campo Salário deve ser um número válido.");
                        return;
                    }

                    if (int.TryParse(txtDepend.Text, out int dependentes))
                    {
                        cadColaboradores.NumDependentes = dependentes;
                    }
                    else
                    {
                        MessageBox.Show("O campo Número de Dependentes deve ser um número válido.");
                        return;
                    }
                    if (cadColaboradores.atualizarColaborador())
                    {
                        MessageBox.Show("Dados atualizados.");
                        LimparCampos();
                        idCont.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel efetuar atualização.");
                        LimparCampos();
                        txtCtps.Focus();
                        idCont.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Localizar o usuario para atualização");
                    LimparCampos();
                    txtCtps.Focus();
                    idCont.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar colaborador" + ex.Message);
            }
        }
    }
}
