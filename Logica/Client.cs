using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calzado_Ulacit.Logica
{
    internal class Client
    {
        private int cltId;
        private string cltName;
        private string cltLastName;
        private string cltAddress;
        private int cltPhoneNum;

        public Client(int cltId, string cltName, string cltAddress, int cltPhoneNum)
        {
            this.cltId = cltId;
            this.cltName = cltName;
            this.cltAddress = cltAddress;
            this.cltPhoneNum = cltPhoneNum;
        }

        public int CltId { get => cltId; set => cltId = value; }
        public string CltName { get => cltName; set => cltName = value; }
        public string CltAddress { get => cltAddress; set => cltAddress = value; }
        public int CltPhoneNum { get => cltPhoneNum; set => cltPhoneNum = value; }
    }
}
