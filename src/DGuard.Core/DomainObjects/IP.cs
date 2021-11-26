using DGuard.Core.Utils;
using System;

namespace DGuard.Core.DomainObjects
{
    public class IP
    {
        public const int IPMaxLength = 11;
        public string Number { get; private set; }

        //Construtor do EntityFramework
        protected IP() { }

        public IP(string numero)
        {
            if (!Validate(numero)) throw new DomainException("IP inválido");
            Number = numero;
        }

        public static bool Validate(string ip)
        {
            //  Split string by ".", check that array length is 3
            char chrFullStop = '.';
            string[] arrOctets = ip.Split(chrFullStop);
            if (arrOctets.Length != 4)
            {
                return false;
            }
            //  Check each substring checking that the int value is less than 255 and that is char[] length is !> 2
            Int16 MAXVALUE = 255;
            Int32 temp; // Parse returns Int32
            foreach (String strOctet in arrOctets)
            {
                if (strOctet.Length > 3)
                {
                    return false;
                }

                temp = int.Parse(strOctet);
                if (temp > MAXVALUE)
                {
                    return false;
                }
            }
            return true;
        }
    }
}