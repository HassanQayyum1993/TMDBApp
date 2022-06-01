using tmdbapi.Models;
using tmdbapi.Services.IServices;
using tmdbapi.UnitOfWork;
using tmdbapi.ViewModels;

namespace tmdbapi.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IResponse> GetCommentsByMovieIdAsync(int movieId)
        {
            try
            {
                var comments = await _unitOfWork.Comment.GetCommentsByMovieIdAsync(movieId);
                return new CommentListViewModel { Status = "Success", Message = "", Comments = comments };
            }
            catch
            {
                return new Response { Status = "Error", Message = "Unable to get movie comments!" };
            }
        }
        public async Task<IResponse> GetCommentByIdAsync(int id)
        {
            try
            {
                var comment = await _unitOfWork.Comment.GetCommentByIdAsync(id);

                if (comment == null)
                {
                    return new Response { Status = "Not Found", Message = "Cannot find the comment!" };
                }

                return new CommentViewModel { Status = "Success", Message = "", Comment = comment };
            }
            catch
            {
                return new Response { Status = "Error", Message = "Unable to get this comment!" };
            }
        }
        public async Task<IResponse> UpdateCommentAsync(int id, Comment comment)
        {
            try
            {
                if (id != comment.Id)
                {
                    return new Response { Status = "Error", Message = "Comment not found!" };
                }

                var result = await _unitOfWork.Comment.UpdateCommentAsync(id, comment);
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
            catch
            {
                return new Response { Status = "Error", Message = "Unable to update this comment!" };
            }
        }
        public async Task<IResponse> PostCommentAsync(Comment comment)
        {
            try
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
            catch
            {
                return new Response { Status = "Error", Message = "Unable to add this comment!" };
            }
        }
        public async Task<IResponse> DeleteCommentAsync(int id)
        {
            try
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
            catch
            {
                return new Response { Status = "Error", Message = "Unable to delete this comment!" };
            }
        }
    }
}
