using Microsoft.AspNetCore.Mvc;
using PenalSystem.DTOs;
using PenalSystem.Interfaces;

namespace PenalSystem.Controllers;

[ApiController]
[Route("books")]
public class BookController : ControllerBase
{
    private readonly ILogger<BookController> _logger;
    private readonly IBookService _bookService;

    public BookController(IBookService bookService, ILogger<BookController> logger)
    {
        _bookService = bookService;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBookActivityAsync(BookCreateDTO bookCreateDTO, CancellationToken cancellation = default)
    {
        var result = await _bookService.CreateActivityAsync(bookCreateDTO, cancellation);
        if (result.HasErrors())
        {
            return BadRequest(new {result.Messages});
        }

        return Ok("Activity created.");
    }

    [HttpGet("{prisonerId}")]
    public async Task<IActionResult> GetBookActivitiesByPrisonerIdAsync(Guid prisonerId, CancellationToken cancellation = default)
    {
        var list = await _bookService.GetActivitiesByPrisonerIdAsync(prisonerId, cancellation);
        return Ok(list);
    }

    [HttpGet]
    public async Task<IActionResult> GetBooksAsync(CancellationToken cancellation = default)
    {
        var list = await _bookService.GetActivitiesAsync(cancellation);
        return Ok(list);
    }
}