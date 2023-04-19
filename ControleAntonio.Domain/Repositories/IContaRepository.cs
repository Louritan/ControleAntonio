using System.Collections.Generic;

namespace ControleAntonio.Domain.Repositories
{
    public interface IContaRepository
    {
        bool VerificarSeExisteContaNumero(long numero);
        bool VerificarSeExisteContaData(int mes, int ano);
        ContaDeLuz BuscarContaNumero(long numero);
        ContaDeLuz BuscarContaData(int mes, int ano);
        void DeletarConta(ContaDeLuz conta);
        void DeletarTodos();
        void AtualizarConta(ContaDeLuz conta);
        List<ContaDeLuz> BuscarTodos();
        void CadastrarConta(ContaDeLuz conta);
    }
}