using Cryptography.Repositories;
using Cryptography.Repositories.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.Business
{
    public class CriptographyBusiness : ICriptographyBusiness
    {
        private string _criptographyKey;
        private readonly ICriptographyCardRepository _criptographyCardRepository;
        public CriptographyBusiness(ICriptographyCardRepository criptographyCardRepository)
        {
            _criptographyKey = Startup.CriptographyKey;
            _criptographyCardRepository = criptographyCardRepository;
        }

        public string Add(CriptographyCard card)
        {
            var newCard = new CriptographyCard
            {
                CreditCardToken = Encrypt(card.CreditCardToken),
                UserDocument = Encrypt(card.UserDocument),
                Value = card.Value
            };
            var insert = _criptographyCardRepository.Add(newCard);
            return insert;
        }

        public CriptographyCard Get(int id)
        {
            var card = _criptographyCardRepository.Get(id);
            if(card == null)
            {
                return card;
            }
            var newCard = DecryptCard(card);
            return newCard;
        }

        public List<CriptographyCard> GetAll()
        {
            var cards = new List<CriptographyCard>();
            _criptographyCardRepository.GetAll().ForEach(x =>
            {
                cards.Add(DecryptCard(x));
            });
            return cards;
        }

        private CriptographyCard DecryptCard(CriptographyCard card)
        {
            card.CreditCardToken = Decrypt(card.CreditCardToken);
            card.UserDocument = Decrypt(card.UserDocument);
            return card;
        }
        private string Encrypt(string clearText)
        {
            var clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (var encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(_criptographyKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        private string Decrypt(string cipherText)
        {
            cipherText = cipherText.Replace(" ", "+");
            var cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                var pdb = new Rfc2898DeriveBytes(_criptographyKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}
