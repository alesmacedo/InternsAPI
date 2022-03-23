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
        public InternEntity CreateIntern(InternEntity internEntity)
        {
            if (internEntity.Id == 0)
                throw new System.Exception("O Id não pode ser enviado no momento da criação.");

            return _internRepository.CreateIntern(internEntity);
        }

        public bool DeleteIntern(int id)
        {
            try
            {
                if (id == 0)
                    throw new System.Exception("O Id deve corresponder ao número desejado.");
                 _internRepository.DeleteIntern(id);
                return true;
                
            }
            catch
            {
                return false;
            }

           

        }
    }
}
