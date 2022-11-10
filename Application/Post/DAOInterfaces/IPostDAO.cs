using Shared.DTOs;
using Shared.Models;
public interface IPostDAO
{
    Task<Post> CreateAsync(Post post);
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDTO searchParameters);
    Task UpdateAsync(Post post);
    Task<Post> GetByIdAsync(int id);
    }