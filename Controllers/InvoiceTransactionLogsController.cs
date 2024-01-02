using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IdioAPI.Models;

namespace IdioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceTransactionLogsController : ControllerBase
    {
        private readonly IdioDbContext _context;

        public InvoiceTransactionLogsController(IdioDbContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceTransactionLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceTransactionLog>>> GetInvoiceTransactionLogs()
        {
            return await _context.InvoiceTransactionLogs.ToListAsync();
        }

        // GET: api/GetTransactionsPerInvoice/6
        [HttpGet]
        [Route("byInvoice/{invoiceId:long}")]
        public async Task<ActionResult<IEnumerable<InvoiceTransactionLog>>> GetTransactionsPerInvoice(long invoiceId)
        {
            var invoiceTransactionLog =  await _context.InvoiceTransactionLogs.Where(t=>t.InvoiceId == invoiceId).OrderBy(t=>t.Id).ToListAsync();

            if (invoiceTransactionLog == null)
            {
                return NotFound();
            }

            return invoiceTransactionLog;
        }

        // GET: api/InvoiceTransactionLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceTransactionLog>> GetInvoiceTransactionLog(long id)
        {
            var invoiceTransactionLog = await _context.InvoiceTransactionLogs.FindAsync(id);

            if (invoiceTransactionLog == null)
            {
                return NotFound();
            }

            return invoiceTransactionLog;
        }

        // PUT: api/InvoiceTransactionLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceTransactionLog(long id, InvoiceTransactionLog invoiceTransactionLog)
        {
            if (id != invoiceTransactionLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoiceTransactionLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceTransactionLogExists(id))
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

        // POST: api/InvoiceTransactionLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InvoiceTransactionLog>> PostInvoiceTransactionLog(InvoiceTransactionLog invoiceTransactionLog)
        {
            _context.InvoiceTransactionLogs.Add(invoiceTransactionLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceTransactionLog", new { id = invoiceTransactionLog.Id }, invoiceTransactionLog);
        }

        // DELETE: api/InvoiceTransactionLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceTransactionLog(long id)
        {
            var invoiceTransactionLog = await _context.InvoiceTransactionLogs.FindAsync(id);
            if (invoiceTransactionLog == null)
            {
                return NotFound();
            }

            _context.InvoiceTransactionLogs.Remove(invoiceTransactionLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceTransactionLogExists(long id)
        {
            return _context.InvoiceTransactionLogs.Any(e => e.Id == id);
        }
    }
}
