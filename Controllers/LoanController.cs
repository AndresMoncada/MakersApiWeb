using MakersApiWeb.App.DTOs;
using MakersApiWeb.App.Handlers.LoanHandler.Params;
using MakersApiWeb.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MakersApiWeb.Controllers
{
    [Route("api/Loan")]
    [ApiController]
    public class LoanController : BaseController
    {
        // Create a loan
        [HttpPost]
        [ResponseCache(Duration = 100)]
        [Authorize]
        public async Task<ActionResult<LoanDto>> CreateLoan([FromBody] LoanInsCommand command)
        {
            var result = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetLoanById), new { id = result.Id }, result);
        }

        // Get all loans only admins    
        /*[HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<LoanDto>>> GetAllLoans()
        {
            var result = await Mediator.Send(new GetAllLoansQuery());
            return Ok(result);
        }*/

        // Get loan by id
        [HttpGet("{id}")]
        [ResponseCache(Duration = 100)]
        [Authorize]
        public async Task<ActionResult<LoanDto>> GetLoanById(int id)
        {
            var result = await Mediator.Send(new LoandQueryByIdCommand { IdLoan = id });
            if (result == null) return NotFound();
            return Ok(result);
        }

        // Approve a loan
        /*[HttpPut("{id}/approve")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveLoan(int id)
        {
            await Mediator.Send(new ApproveLoanCommand(id));
            return NoContent();
        }*/

        // Reject a loan 
        /*[HttpPut("{id}/reject")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RejectLoan(int id)
        {
            await Mediator.Send(new RejectLoanCommand(id));
            return NoContent();
        }*/

        // Get loans by user
        /*[HttpGet("user/{userId}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<LoanDto>>> GetLoansByUser(int userId)
        {
            var result = await Mediator.Send(new GetLoansByUserIdQuery(userId));
            return Ok(result);
        }*/
    }
}
