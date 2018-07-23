using System;
using System.Collections.Generic;
using System.Text;

namespace CardManage.DTO
{
    public class CardDTO
    {
        public long Id { get; set; }

        public string CardNo { get; set; }

        public long OwnnerBankId { get; set; }

        public string OwnnerBankName { get; set; }

        public long OwnnerPersonId { get; set; }

        public string OwnnerPersonName { get; set; }
        /// <summary>
        /// 可用余额
        /// </summary>
        public decimal AvaliableBalance { get; set; }

        /// <summary>
        /// 已出账单
        /// </summary>
        public decimal Billing { get; set; }

        /// <summary>
        /// 未出账单
        /// </summary>
        public decimal NoBill { get; set; }

        public long TypeId { get; set; }

        public string TypeName { get; set; }

        public DateTime? UsefulLife { get; set; }

        public DateTime BillDay { get; set; }

        public DateTime RepayDay { get; set; }

        public string BackNum { get; set; }
    }
}
