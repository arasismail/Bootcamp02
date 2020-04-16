using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bootcamp02.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp02.Controllers
{
    public class MessageController : Controller
    {
        private readonly MessageService _messageService;
        public MessageController(MessageService messageService)
        {
            _messageService = messageService;
        }
        public IActionResult Index()
        {
            string message = _messageService.GetMessage();
            return View("Index", message);
        }
    }
}