using DGuard.Core.Utils;

namespace DGuard.Core.DomainObjects
{
    public class Telefone
    {
        public const int TelefoneMaxLength = 11;//00000000000
        public string Numero { get; private set; }

        //Construtor do EntityFramework
        protected Telefone() { }

        public Telefone(string numero)
        {
            if (!Validate(numero)) throw new DomainException("Telefone inválido");
            Numero = numero.OnlyNumbers(numero);
        }

        public static bool Validate(string telefone)
        {
            telefone = telefone.OnlyNumbers(telefone);

            if (telefone.Length != TelefoneMaxLength) return false;

            return true;
        }
    }
}