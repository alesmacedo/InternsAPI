using InternsAPI.Domain;
using System;

namespace InternsAPI.Repository
{
    public class InternRepository
    {
        public InternRepository()
        {

        }

        public InternEntity CreateIntern(InternEntity internEntity)
        {
            //Adicionar lógica para salvar no banco
            internEntity.Id = new Random().Next(1, 100);

            return internEntity;
        }

    }
}
