﻿using MicroRabbit.MVC.Models;
using MicroRabbit.MVC.Models.DTOs;
using MicroRabbit.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MicroRabbit.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransferService _transferService;
        public HomeController(ITransferService transferService , ILogger<HomeController> logger)
        {
            _transferService = transferService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(TransferViewModel transferViewModel)
        {
            TransferDto transferDto = new TransferDto
            {
                ToAccount = transferViewModel.ToAccount,
                FromAccount = transferViewModel.FromAccount,
                TransferAmount = transferViewModel.TransferAmount
            };

            await _transferService.Transfer(transferDto);  
            return View("Index"); 
        }
    }
}