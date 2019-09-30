using System;
using System.Data;
using System.Data.SqlClient;

namespace BDProjeto.Repositorio
{
    public class bd : IDisposable
    { 
        private readonly SqlConnection conexao;

        public  bd()
        {
            conexao = new SqlConnection(@"data source = Cliente; Integrated Security= SSPI; Initial Catalog= Ecommerce");
            conexao.Open();

        }

        //Metodo Insert
        public void ExecutaComando(string strQuery)
        {
            var cmdComando = new SqlCommand
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = conexao

            };
            cmdComando.ExecuteNonQuery();

        }
        //Metodo Select

        public SqlDataReader ExecutaComandoComRetorno(string strQuery)
        {
            var cmdComandoSelect = new SqlCommand(strQuery, conexao);
            return cmdComandoSelect.ExecuteReader();
        }


        //Fechar conexao
        public void Dispose()
        {
            if (conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }

        }


    }
}
