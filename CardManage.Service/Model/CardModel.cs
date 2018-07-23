using System;
using System.Collections.Generic;
using System.Text;

namespace CardManage.Service.Model
{
    public class CardModel
    {
        public long Id { get; set; }


        public long CardTypeId { get; set; }

        public virtual CardTypeModel CardType { get; set; }//延迟加载需要显示标注Public、Virtual，card是子类对象，override了Virtual属性的Get方法，if(card.CardType==null){执行查询}

        public string CardNo { get; set; }

        public long  OwnnerBankId { get; set; }

        public virtual BankModel OwnnerBank { get; set; }

        public long OwnnerPersonId { get; set; }

        public virtual PersonModel OwnnerPerson { get; set; }

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

        public DateTime? UsefulLife { get; set; }

        public DateTime BillDay { get; set; }

        public DateTime RepayDay { get; set; }

        public string BackNum { get; set; }
    }

    
}
