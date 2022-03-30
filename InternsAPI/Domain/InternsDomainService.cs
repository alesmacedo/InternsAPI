using InternsAPI.Repository;
using System;
using System.Collections.Generic;

namespace InternsAPI.Domain
{
    public class InternsDomainService
    {
        private readonly InternRepository _internRepository;
        public InternsDomainService()
        {
            _internRepository = new InternRepository();
        }

        public InternEntity GetIntern(int id)
        {
            if (id == 0)
                throw new System.Exception("Insira o Id desejado.");

            return _internRepository.GetIntern(id);
        }
        public InternEntity CreateIntern(InternEntity internEntity)
        {
            if (internEntity.Id != 0)
                throw new System.Exception("O Id não pode ser enviado no momento da criação.");

            return _internRepository.CreateIntern(internEntity);
        }
        public InternEntity UpdateIntern(InternEntity internEntity)
        {
            if (internEntity.Id == 0)
                throw new System.Exception("Informe o Id correto.");

            return _internRepository.UpdateIntern(internEntity);
            
        }
        public bool DeleteIntern(int id)
        {
            if (id == 0)
                throw new System.Exception("O Id deve corresponder ao número desejado.");
            
            _internRepository.DeleteIntern(id);

            return true; 
        }
    }
}
