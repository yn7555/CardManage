using CardManage.DTO;
using CardManage.IService;
using CardManage.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CardManage.Test
{
    [TestClass]
    public class CardServiceTest
    {
        private ICardService cardService = new CardService();

        [TestMethod]
        public void TestAddCard()
        {
            CardDTO dto = new CardDTO()
            {
                CardNo = "333",
                TypeId = 1,
                OwnnerBankId = 1,
                OwnnerPersonId = 1,
                AvaliableBalance = 90000,
                Billing = 20000,
                NoBill = 5000,
                UsefulLife = Convert.ToDateTime("2021-12-31"),
                BillDay = Convert.ToDateTime("2018-7-21"),
                RepayDay= Convert.ToDateTime("2018-8-1"),
                BackNum="XXX"
            };
            var t = cardService.AddCard(dto);
            t.Wait();
        }

        [TestMethod]
        public void TestModifyCard()
        {
            CardDTO dto = new CardDTO()
            {
                Id=1,
                CardNo = "222",
                TypeId = 1,
                OwnnerBankId = 1,
                OwnnerPersonId = 1,
                AvaliableBalance = 1234567,
                Billing = 321,
                NoBill = 123,
                UsefulLife = Convert.ToDateTime("2021-12-31"),
                BillDay = Convert.ToDateTime("2018-7-21"),
                RepayDay = Convert.ToDateTime("2018-8-1"),
                BackNum = "XXX"
            };
            var t = cardService.ModifyCard(dto);
            t.Wait();
        }


        [TestMethod]
        public void TestDelCards()
        {
            long[] ids = { 1 };
            var t = cardService.DelCards(ids);
            t.Wait();
        }

        [TestMethod]
        public void TestGetAllCards()
        {
            var t= cardService.GetAllCards();
            t.Wait();
            var res = t.Result;
        }
    }
}
