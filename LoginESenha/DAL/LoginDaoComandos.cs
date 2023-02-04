using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginESenha.DAL
{
    class LoginDaoComandos
    {
        public bool tem = false;
        public String mensagem = "";
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao();
        SqlDataReader dr;
        public bool verificarLogin(String login, String senha)
        {
            //procurar no banco login e senha
            cmd.CommandText = "select * from logins where email = @login and senha = @senha";
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);

            try
            {
                cmd.Connection = con.conectar();
                dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    tem = true;
                }
                con.desconectar();
                dr.Close();
            }
            catch (SqlException)
            {
                this.mensagem = "Erro com o Banco de Dados!";
            }
            //comandos SQL para verificar se tem no banco
            return tem;
        }

        public String cadastrar(String email, String senha, String ConfSenha)
        {
            tem = false;
            // comandos para inserir
            if (senha.Equals(ConfSenha))
            {
                cmd.CommandText = "insert into logins values (@e, @S);";
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@e", senha);

                try
                {
                    cmd.Connection = con.conectar();
                    cmd.ExecuteNonQuery();
                    con.desconectar();
                    this.mensagem = "Cadastrado com sucesso!";
                    tem = true;
                }
                catch (SqlException)
                {
                    this.mensagem = "Erro no Banco de Dados";
                }
            }
            else
            {
                this.mensagem = "Senhas não correspondem!";
            }
            return mensagem;
        }
    }
}
