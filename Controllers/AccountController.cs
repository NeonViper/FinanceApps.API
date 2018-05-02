using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceApp.API.Data;
using FinanceApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FinanceApp.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;

        }

        // GET api/account
        [HttpGet]
        public async Task<IActionResult> GetAccount()
        {
            var account = await _context.Accounts.FirstOrDefaultAsync();

            return Ok(account);
        }

        // GET api/account/update
        [HttpPost("update")]
        public async Task<IActionResult> UpdateAccount([FromBody]AccountUpdateRequest amount)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync();

            double newAmount = 0;

            if(amount != null)
                newAmount = Convert.ToDouble(amount.Amount);

            account.Balance += newAmount;
            account.Available -= newAmount;

            _context.Accounts.Update(account);

            await _context.SaveChangesAsync();

            return Ok(account);
        }

    }
}
