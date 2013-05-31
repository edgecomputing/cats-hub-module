using System;
using System.Collections.Generic;

namespace DRMFSS.BLL
{
    public partial class LedgerType
    {
        public LedgerType()
        {
            this.Ledgers = new List<Ledger>();
        }

        public int LedgerTypeID { get; set; }
        public string Name { get; set; }
        public string Direction { get; set; }
        public virtual ICollection<Ledger> Ledgers { get; set; }
    }
}
