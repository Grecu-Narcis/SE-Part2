using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Iss.Database;

namespace RestApi_ISS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankAccountController : ControllerBase
    {
        private readonly DbContext context;

        public BankAccountController(DbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BankAccount>>> GetBankAccounts()
        {
            return await context.Set<BankAccount>().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccount>> GetBankAccount(int id)
        {
            var bankAccount = await context.Set<BankAccount>().FindAsync(id);

            if (bankAccount == null)
            {
                return NotFound();
            }

            return bankAccount;
        }

        [HttpPost]
        public async Task<ActionResult<BankAccount>> PostBankAccount(BankAccount bankAccount)
        {
            // if (!BankAccount.Validate(bankAccount))
            // {
            //    return BadRequest("Invalid bank account data.");
            // }
            context.Set<BankAccount>().Add(bankAccount);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBankAccount), new { id = bankAccount.Id }, bankAccount);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBankAccount(int id, BankAccount bankAccount)
        {
            if (id != bankAccount.Id)
            {
                return BadRequest("ID mismatch.");
            }

            // if (!BankAccount.Validate(bankAccount))
            // {
            //    return BadRequest("Invalid bank account data.");
            // }
            context.Entry(bankAccount).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankAccountExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankAccount(int id)
        {
            var bankAccount = await context.Set<BankAccount>().FindAsync(id);
            if (bankAccount == null)
            {
                return NotFound();
            }

            context.Set<BankAccount>().Remove(bankAccount);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool BankAccountExists(int id)
        {
            return context.Set<BankAccount>().Any(e => e.Id == id);
        }
    }
    // public class BankAccountsController : Controller
    // {
    //    private readonly DatabaseContext context;

    // public BankAccountsController(DatabaseContext context)
    //    {
    //        this.context = context;
    //    }

    // // GET: BankAccounts
    //    public async Task<IActionResult> Index()
    //    {
    //        return View(await context.BankAccount.ToListAsync());
    //    }

    // // GET: BankAccounts/Details/5
    //    public async Task<IActionResult> Details(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    // var bankAccount = await context.BankAccount
    //            .FirstOrDefaultAsync(m => m.Id == id);
    //        if (bankAccount == null)
    //        {
    //            return NotFound();
    //        }

    // return View(bankAccount);
    //    }

    // // GET: BankAccounts/Create
    //    public IActionResult Create()
    //    {
    //        return View();
    //    }

    // // POST: BankAccounts/Create
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("Id,Email,Name,Surname,PhoneNumber,County,City,Address,Number,HolderName,ExpiryDate")] BankAccount bankAccount)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            context.Add(bankAccount);
    //            await context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(bankAccount);
    //    }

    // // GET: BankAccounts/Edit/5
    //    public async Task<IActionResult> Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    // var bankAccount = await context.BankAccount.FindAsync(id);
    //        if (bankAccount == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(bankAccount);
    //    }

    // // POST: BankAccounts/Edit/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Name,Surname,PhoneNumber,County,City,Address,Number,HolderName,ExpiryDate")] BankAccount bankAccount)
    //    {
    //        if (id != bankAccount.Id)
    //        {
    //            return NotFound();
    //        }

    // if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                context.Update(bankAccount);
    //                await context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!BankAccountExists(bankAccount.Id))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(bankAccount);
    //    }

    // // GET: BankAccounts/Delete/5
    //    public async Task<IActionResult> Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    // var bankAccount = await context.BankAccount
    //            .FirstOrDefaultAsync(m => m.Id == id);
    //        if (bankAccount == null)
    //        {
    //            return NotFound();
    //        }

    // return View(bankAccount);
    //    }

    // // POST: BankAccounts/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        var bankAccount = await context.BankAccount.FindAsync(id);
    //        if (bankAccount != null)
    //        {
    //            context.BankAccount.Remove(bankAccount);
    //        }

    // await context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    // private bool BankAccountExists(int id)
    //    {
    //        return context.BankAccount.Any(e => e.Id == id);
    //    }
    // }
}
