

using api.Dtos.Comment;
using api.Extensions;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api.Controllers;

[Route("api/comment")]
[ApiController]
public class CommentController(ICommentRepository comment, IStockRepository stock, UserManager<AppUser> userManager) : ControllerBase
{
    private readonly ICommentRepository _commentRepo = comment;
    private readonly IStockRepository _stockRepo = stock;
    private readonly UserManager<AppUser> _userManager = userManager;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var comments = await _commentRepo.GetAllAsync();
        var commentDto = comments.Select(e => e.ToCommentDto());
        return Ok(commentDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var comment = await _commentRepo.GetByIdAsync(id);

        if (comment == null)
        {
            return NotFound();
        }

        return Ok(comment);
    }

    [HttpPost("{stockId:int}")]
    public async Task<IActionResult> Create([FromRoute] int stockId, CreateCommnetDto commentDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        Console.WriteLine("stockId :" + stockId);
        if (!await _stockRepo.StockExists(stockId))
        {
            return BadRequest("Stock does not exist");
        }

        var username = User.GetUsername();
        var appUser = await _userManager.FindByNameAsync(username);


        var commentModel = commentDto.ToCommentFromCreate(stockId);
        commentModel.AppUserId = appUser.Id;
        await _commentRepo.CreateAsync(commentModel);
        return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDto());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommnetDto updateDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var commentModel = await _commentRepo.UpdateAsync(id, updateDto);
        if (commentModel == null)
        {
            return NotFound("Comment not found");
        }
        return Ok(commentModel.ToCommentDto());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Detele([FromRoute] int id)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var commentModel = await _commentRepo.DeleteAsync(id);
        if (commentModel == null)
        {
            return NotFound("commnet does not exist");
        }

        return NoContent();
    }
}


