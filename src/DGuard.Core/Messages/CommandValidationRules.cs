using System;
using FluentValidation.Results;
using MediatR;

namespace DGuard.Core.Messages
{
    public static class CommandValidationRules
    {
        public static bool TerCnpjValido(string cnpj)
        {
            return Core.DomainObjects.Cnpj.Validar(cnpj);
        }
        public static bool TerTelefoneValido(string telefone)
        {
            return Core.DomainObjects.Telefone.Validate(telefone);
        }
        public static bool HaveValidIP(string ip)
        {
            return Core.DomainObjects.IP.Validate(ip);
        }
    }
}