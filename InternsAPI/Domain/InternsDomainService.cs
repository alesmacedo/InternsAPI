using InternsAPI.Repository;

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
            if (internEntity.Id != 0)
                throw new System.Exception("O Id não pode ser enviado no momento da criação.");

            return _internRepository.CreateIntern(internEntity);
        }
    }
}
