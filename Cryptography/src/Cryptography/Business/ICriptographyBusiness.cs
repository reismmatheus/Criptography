using Cryptography.Repositories.Model;
using System.Collections.Generic;

namespace Cryptography.Business
{
    public interface ICriptographyBusiness
    {
        public string Add(CriptographyCard card);
        public CriptographyCard Get(int id);
        public List<CriptographyCard> GetAll();
    }
}
