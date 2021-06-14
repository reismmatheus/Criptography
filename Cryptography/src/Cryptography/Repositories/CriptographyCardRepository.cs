using Cryptography.Context;
using Cryptography.Repositories.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cryptography.Repositories
{
    public class CriptographyCardRepository : ICriptographyCardRepository
    {
        private readonly CriptographyContext _context;
        public CriptographyCardRepository(CriptographyContext context)
        {
            _context = context;
        }

        public string Add(CriptographyCard criptographyCard)
        {
            _context.CriptographyCards.Add(criptographyCard);
            _context.SaveChanges();
            return criptographyCard.Id.ToString();
        }

        public CriptographyCard Get(int id)
        {
            return _context.CriptographyCards.FirstOrDefault(x => x.Id == id);
        }

        public List<CriptographyCard> GetAll()
        {
            return _context.CriptographyCards.ToList();
        }
    }
}
