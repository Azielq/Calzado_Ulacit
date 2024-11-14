using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calzado_Ulacit.Logica
{
    internal class Client
    {
        private string cltName;
        private string cltLastName;
        private string cltAddress;
        private int cltPhoneNum;

        public Client(string cltName, string cltLastName, string cltAddress, int cltPhoneNum)
        {
            this.cltName = cltName;
            this.cltLastName = cltLastName;
            this.cltAddress = cltAddress;
            this.cltPhoneNum = cltPhoneNum;
        }

        public string CltName { get => cltName; set => cltName = value; }
        public string CltLastName { get => cltLastName; set => cltLastName = value; }
        public string CltAddress { get => cltAddress; set => cltAddress = value; }
        public int CltPhoneNum { get => cltPhoneNum; set => cltPhoneNum = value; }
    }
}
