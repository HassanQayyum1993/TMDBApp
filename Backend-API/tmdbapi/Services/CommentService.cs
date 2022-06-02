using tmdbapi.Constants;
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
                return new CommentListViewModel { Status = Statuses.Success, Message = "", Comments = comments };
            }
            catch
            {
                return new Response { Status = Statuses.Error, Message = "Unable to get movie comments!" };
            }
        }
        public async Task<IResponse> GetCommentByIdAsync(int id)
        {
            try
            {
                var comment = await _unitOfWork.Comment.GetCommentByIdAsync(id);
                return new CommentViewModel { Status = Statuses.Success, Message = "", Comment = comment };
            }
            catch
            {
                return new Response { Status = Statuses.Error, Message = "Unable to get this comment!" };
            }
        }
        public async Task<IResponse> UpdateCommentAsync(int id, Comment comment)
        {
            try
            {
                if (id != comment.Id)
                {
                    return new Response { Status = Statuses.Success, Message = "Comment not found!" };
                }

                var result1 = await _unitOfWork.Comment.UpdateCommentAsync(id, comment);

                if (result1 == 1)
                {
                    var result2 = await _unitOfWork.CompleteAsync();
                    if (result2 == true)
                    {
                        return new Response { Status = Statuses.Success, Message = "Comment updated successfully!" };
                    }
                    else
                    {
                        return new Response { Status = Statuses.Error, Message = "Unable to update this comment!" };
                    }
                }
                else
                {
                    return new Response { Status = Statuses.NotFound, Message = "Comment not found!" };
                }
            }
            catch
            {
                return new Response { Status = Statuses.Error, Message = "Unable to update this comment!" };
            }
        }
        public async Task<IResponse> PostCommentAsync(Comment comment)
        {
            try
            {
                var result1 = await _unitOfWork.Comment.PostCommentAsync(comment);
                var result2 = await _unitOfWork.CompleteAsync();

                if (result1 == 1)
                {
                    if (result2 == true)
                    {
                        return new Response { Status = Statuses.Success, Message = "Comment added successfully!" };
                    }
                    else
                    {
                        return new Response { Status = Statuses.Error, Message = "Unable to add this comment!" };
                    }
                }
                else
                {
                    return new Response { Status = Statuses.Error, Message = "Unable to add this comment!" };
                }
            }
            catch
            {
                return new Response { Status = Statuses.Error, Message = "Unable to add this comment!" };
            }
        }
        public async Task<IResponse> DeleteCommentAsync(int id)
        {
            try
            {
                var result1 = await _unitOfWork.Comment.DeleteCommentAsync(id);
                var result2 = await _unitOfWork.CompleteAsync();

                if (result1 == 1)
                {
                    if (result2 == true)
                    {
                        return new Response { Status = Statuses.Success, Message = "Comment deleted successfully!" };
                    }
                    else
                    {
                        return new Response { Status = Statuses.Error, Message = "Unable to delete this comment!" };
                    }
                }
                else
                {
                    return new Response { Status = Statuses.NotFound, Message = "Cannot find the comment!" };
                }
            }
            catch
            {
                return new Response { Status = Statuses.Error, Message = "Unable to delete this comment!" };
            }
        }
    }
}
