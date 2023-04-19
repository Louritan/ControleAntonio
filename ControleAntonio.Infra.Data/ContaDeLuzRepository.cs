using System;
using System.Collections.Generic;
using ControleAntonio.Domain;
using ControleAntonio.Domain.Repositories;
using ControleAntonio.Infra.Data.DAO;

namespace ControleAntonio.Infra.Data
{
    public class ContaDeLuzRepository : IContaRepository
    {
        private readonly ContaDAO contaDAO;

        public ContaDeLuzRepository()
        {
            contaDAO = new ContaDAO();
        }

        public bool VerificarSeExisteContaNumero(long numero)
        {
            var contaBuscada = contaDAO.BuscarPorNumero(numero);
            bool existe = contaBuscada != null;
            return existe;
        }

        public bool VerificarSeExisteContaData(int mes, int ano)
        {
            var contaBuscada = contaDAO.BuscarPorMesAno(mes, ano);
            bool existe = contaBuscada != null;
            return existe;
        }

        public ContaDeLuz BuscarContaData(int mes, int ano)
        {
            return contaDAO.BuscarPorMesAno(mes, ano);
        }

        public ContaDeLuz BuscarContaNumero(long numero)
        {
            return contaDAO.BuscarPorNumero(numero);
        }

        public void DeletarConta(ContaDeLuz conta)
        {
            contaDAO.DeletarConta(conta);
        }

        public void DeletarTodos()
        {
            contaDAO.DeletarTodos();
        }

        public void AtualizarConta(ContaDeLuz conta)
        {
            contaDAO.AtualizarConta(conta);
        }

        public List<ContaDeLuz> BuscarTodos()
        {
            return contaDAO.BuscarTodos();
        }

        public void CadastrarConta(ContaDeLuz conta)
        {
            contaDAO.CadastrarConta(conta);
        }
    }
}