using System.Collections;
using tmdbapi.Models;
using tmdbapi.Repos.IRepos;
using tmdbapi.Services.IServices;
using tmdbapi.UnitOfWork;
using tmdbapi.ViewModels;

namespace tmdbapi.Services
{
    public class CommentService: ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IResponse> GetCommentsByMovieIdAsync(int movieId)
        {
            var comments = await _unitOfWork.Comment.GetCommentsByMovieIdAsync(movieId);
            return new CommentListViewModel { Status="Success", Message="", Comments=comments};
        }
        public async Task<IResponse> GetCommentByIdAsync(int id)
        {
            var comment = await _unitOfWork.Comment.GetCommentByIdAsync(id);

            if (comment == null)
            {
                return new Response { Status="Not Found", Message="Cannot find the comment!" };
            }

            return new CommentViewModel { Status="Success", Message="", Comment=comment };
        }
        public async Task<IResponse> PutCommentAsync(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return new Response { Status="Error", Message="Comment not found!" };
            }

            var result = await _unitOfWork.Comment.PutCommentAsync(id, comment);
            await _unitOfWork.CompleteAsync();
            if (result == 1)
            {
                return new Response { Status = "Success", Message = "Comment updated successfully!" };

            }
            else
            {
                return new Response { Status = "Error", Message = "Comment not found!" };
            }
        }
        public async Task<IResponse> PostCommentAsync(Comment comment)
        {

            var result = await _unitOfWork.Comment.PostCommentAsync(comment);
            await _unitOfWork.CompleteAsync();

            if (result == 1)
            {
                return new Response { Status = "Success", Message = "Comment added successfully!" };
            }
            else
            {
                return new Response { Status = "Error", Message = "Unable to add this comment!" };
            }
        }
        public async Task<IResponse> DeleteCommentAsync(int id)
        {
            var result = await _unitOfWork.Comment.DeleteCommentAsync(id);
            await _unitOfWork.CompleteAsync();

            if (result == 0)
            {
                return new Response { Status = "Not Found", Message = "Cannot find the Comment!" };
            }
            else
            {
                return new Response { Status = "Success", Message = "Comment deleted successfully!" };
            }
        }
    }
}
