using System;
using System.Collections.Generic;
using ControleAntonio.Domain;
using ControleAntonio.Domain.Repositories;
using System.Data.SqlClient;

namespace ControleAntonio.Infra.Data.DAO
{
    public class ContaDAO
    {
        //localhost\SQLEXPRESS casa
        //DESKTOP-QQ03OD8 uniplac
        private readonly string connectionString = @"server=localhost\SQLEXPRESS;initial catalog=CONTROLE_GASTOS_DB;integrated security=true";

        private void ConverterObjetoParaSql(ContaDeLuz conta, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("@numero", conta.NumeroLeitura);
            comando.Parameters.AddWithValue("@dataLeitura", conta.DataLeitura);
            comando.Parameters.AddWithValue("@dataPagamento", conta.DataPagamento);
            comando.Parameters.AddWithValue("@kwGastoMes", conta.KWGastoMes);
            comando.Parameters.AddWithValue("@valor", conta.Valor);
            comando.Parameters.AddWithValue("@mediaConsumo", conta.MediaConsumo);
        }

        private ContaDeLuz ConverterSqlParaObjeto(SqlDataReader leitor)
        {
            var numeroLeitura = Convert.ToInt64(leitor["NUMERO_LEITURA"].ToString());
            var dataLeitura = Convert.ToDateTime(leitor["DATA_LEITURA"].ToString());
            var dataPagamento = Convert.ToDateTime(leitor["DATA_PAGAMENTO"].ToString());
            var kwGastoMes = Convert.ToDouble(leitor["KW_GASTO_MES"].ToString());
            var valor = Convert.ToDouble(leitor["VALOR"].ToString());
            var mediaConsumo = Convert.ToDouble(leitor["MEDIA_CONSUMO"].ToString());

            return new ContaDeLuz(numeroLeitura, dataLeitura, dataPagamento, kwGastoMes, valor, mediaConsumo);
        }

        public void CadastrarConta(ContaDeLuz conta)
        {
            using (var conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    var sql = @"
                    INSERT INTO ContaDeLuz VALUES
                    (@numero,
                    @dataLeitura,
                    @dataPagamento,
                    @kwGastoMes,
                    @valor,
                    @mediaConsumo
                    );";

                    ConverterObjetoParaSql(conta, comando);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public ContaDeLuz BuscarPorNumero(long numero)
        {
            using (var conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM ContaDeLuz WHERE NUMERO_LEITURA = @numero";

                    comando.Parameters.AddWithValue("@numero", numero);

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    if (leitor.Read())
                    {
                        ContaDeLuz contaBuscada = ConverterSqlParaObjeto(leitor);
                        return contaBuscada;
                    }
                }
            }

            return null;
        }

        public ContaDeLuz BuscarPorMesAno(int mes, int ano)
        {
            using (var conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM ContaDeLuz WHERE MONTH(DATA_LEITURA) = @mes AND YEAR(DATA_LEITURA) = @ano";

                    comando.Parameters.AddWithValue("@mes", mes);
                    comando.Parameters.AddWithValue("@ano", ano);

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    if (leitor.Read())
                    {
                        ContaDeLuz contaBuscada = ConverterSqlParaObjeto(leitor);
                        return contaBuscada;
                    }
                }
            }

            return null;
        }

        public List<ContaDeLuz> BuscarTodos()
        {
            var listaContas = new List<ContaDeLuz>();

            using (var conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT * FROM ContaDeLuz";

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        ContaDeLuz contaBuscada = ConverterSqlParaObjeto(leitor);
                        listaContas.Add(contaBuscada);
                    }
                }

                return listaContas;
            }
        }

        public void AtualizarConta(ContaDeLuz conta)
        {
            using (var conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    var sql = @"
                    UPDATE ContaDeLuz SET
                    DATA_LEITURA = @dataLeitura,
                    DATA_PAGAMENTO = @dataPagamento,
                    KW_GASTO_MES = @kwGastoMes,
                    VALOR = @valor,
                    MEDIA_CONSUMO = @mediaConsumo
                    WHERE NUMERO_LEITURA = @numero";

                    ConverterObjetoParaSql(conta, comando);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void DeletarConta(ContaDeLuz conta)
        {
            using (var conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"DELETE FROM ContaDeLuz WHERE NUMERO_LEITURA = @numero";

                    comando.Parameters.AddWithValue("@numero", conta.NumeroLeitura);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void DeletarTodos()
        {
            using (var conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"DELETE FROM ContaDeLuz";

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}