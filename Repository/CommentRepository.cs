using System;
using api.Data;
using api.Dtos.Comment;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class CommentRepository(ApplicationDbContext context) : ICommentRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Comment> CreateAsync(Comment commentModel)
    {
       
       await _context.Comments.AddAsync(commentModel);
       await _context.SaveChangesAsync();
       return commentModel;
    }

    public async Task<Comment?> DeleteAsync(int id)
    {
        var commentModel = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

        if (commentModel == null){
            return null;
        }

        _context.Comments.Remove(commentModel);
        await _context.SaveChangesAsync();
        return commentModel;
    }

    public async Task<List<Comment>> GetAllAsync()
    {
        return await _context.Comments.Include(a => a.AppUser).ToListAsync();
    }

    public async Task<Comment?> GetByIdAsync(int id)
    {
       return await _context.Comments.Include(a => a.AppUser).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Comment?> UpdateAsync(int id, UpdateCommnetDto updateDto)
    {
         var existingCommnet =  await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (existingCommnet == null)
            {
                return null;
            }

            existingCommnet.Title = updateDto.Title;
            existingCommnet.Content = updateDto.Content;

           await  _context.SaveChangesAsync();
            return existingCommnet;
    }
}
