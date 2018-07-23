using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardManage.DTO;
using CardManage.IService;
using CardManage.Service;
using Microsoft.AspNetCore.Mvc;

namespace CardManage.Web.Controllers
{
    public class CardController : Controller
    {
        ICardService cardService = new CardService();
    }
}