using System;
using System.Security.Cryptography;

namespace Framework.Core.Helpers
{
    public interface ISecurityHelper
    {
        Guid CreateCryptographicallySecureGuid();
    }
    public class SecurityHelper : ISecurityHelper
    {
        private readonly RandomNumberGenerator _rand = RandomNumberGenerator.Create();
        public Guid CreateCryptographicallySecureGuid()
        {
            var bytes = new byte[16];
            _rand.GetBytes(bytes);
            return new Guid(bytes);
        }
    }
}
