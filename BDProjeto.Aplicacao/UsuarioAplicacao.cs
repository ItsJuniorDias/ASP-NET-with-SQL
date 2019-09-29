using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDProjeto.Dominio;
using BDProjeto.Repositorio;

namespace BDProjeto.Aplicacao
{
    public class UsuarioAplicacao
    {
        public bd BD;
        public string strQuery;

        public void Insert(Usuarios usuarios)
        {
            var strQuery = "";
            strQuery += "Insert into usuarios (nome, cargo, data)";
            strQuery += string.Format(" Values ('{0}', '{1}', '{2}')", usuarios.nome, usuarios.cargo, usuarios.data);

            using (BD = new bd())
            {
                BD.ExecutaComando(strQuery);

            }
        }

        public void Alterar(Usuarios usuarios)
        {
            var strQuery = "";
            strQuery += "UPDATE usuarios SET ";
            strQuery += string.Format("nome= '{0}',", usuarios.nome);
            strQuery += string.Format("cargo= '{0}',", usuarios.cargo);
            strQuery += string.Format("data= '{0}'", usuarios.data);
            strQuery += string.Format("WHERE id = {0}", usuarios.id);

            using (BD = new bd())
            {
                BD.ExecutaComando(strQuery);

            }
        }

        public void Salvar(Usuarios usuarios)
        {
            if (usuarios.id > 0)
            {
                Alterar(usuarios);
            }
            else
            {
                Insert(usuarios);
            }
        }

        public void Excluir(int id)
        {
            using (BD = new bd())
            {
                strQuery = string.Format("DELETE FROM usuarios WHERE id = {0}", id);
                BD.ExecutaComando(strQuery);

            }

        }

        public List<Usuarios> ListarTodos()
        {
            using (var BD = new bd())
            {
                var strQuery = "SELECT  * FROM usuarios";
                var retorno =  BD.ExecutaComandoComRetorno(strQuery);
                return ReaderLista(retorno);
            }
        }
        public Usuarios ListarPorId(int id)
        {
            using (var bd = new bd())
            {
                var strQuery = string.Format("SELECT  * FROM usuarios WHERE id = {0}", id);
                var retorno = bd.ExecutaComandoComRetorno(strQuery);
                return ReaderLista(retorno).FirstOrDefault();
            }
        }


        public List<Usuarios> ReaderLista(SqlDataReader reader)
        {
            var usuarios = new List<Usuarios>();
            while (reader.Read())
            {
                var TempoObjeto = new Usuarios()
                {
                    id = int.Parse(reader["id"].ToString()),
                    nome = reader["nome"].ToString(),
                    cargo = reader["cargo"].ToString(),
                    data = DateTime.Parse(reader["data"].ToString()),
                };
                usuarios.Add(TempoObjeto);
            }
            reader.Close();
            return usuarios;
        }

    
    }
}
