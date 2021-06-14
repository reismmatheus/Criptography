using Cryptography.Repositories.Model;
using System.Collections.Generic;

namespace Cryptography.Repositories
{
    public interface ICriptographyCardRepository
    {
        public string Add(CriptographyCard criptographyCard);
        public CriptographyCard Get(int id);
        public List<CriptographyCard> GetAll();
    }
}