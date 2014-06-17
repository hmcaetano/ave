using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDataMappers
{
    public interface IDataMapper<T> : IDisposable
    {
        T GetById(int id);
        IEnumerable<T> GetAll();// Devolve todos os elementos da tabela correspondente
        void Update(T val); // Actualiza a linha que tem PK igual à propriedade PK de val (ler cap. Requisitos)
        void Delete(T val); // Apaga a linha com PK igual à propriedade PK de val
        void Insert(T val); // Insere uma nova linha com os valores de val e actualiza val com a PK devolvida
        void BeginTrx();
        void Rollback();
        void Commit();
    }
}
