using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Presistance
{
    public class DataSeed(ApplicationDbContext _dbContext) : IDataSeeding
    {
        void IDataSeeding.DataSeed()
        {
            try
            {
                if (_dbContext.Database.GetPendingMigrations().Any())
                {
                    _dbContext.Database.Migrate();
                }

                if (!_dbContext.Users.Any())
                {
                    var users = File.ReadAllText(@"..\Infrastructure\Presistance\Data\DataSeed\Users.json");
                    var userData = JsonSerializer.Deserialize<List<User>>(users);
                    if (userData is not null && userData.Any())
                    {
                        _dbContext.Users.AddRange(userData);
                        _dbContext.SaveChanges(); 
                    }
                }

                if (!_dbContext.Posts.Any())
                {
                    var PostsData = File.ReadAllText(@"..\Infrastructure\Presistance\Data\DataSeed\Posts.json");
                    var posts = JsonSerializer.Deserialize<List<Post>>(PostsData);
                    if (posts is not null && posts.Any())
                    {
                        _dbContext.Posts.AddRange(posts);
                        _dbContext.SaveChanges(); 
                    }
                }

                if (!_dbContext.Friendships.Any())
                {
                    var FrindData = File.ReadAllText(@"..\Infrastructure\Presistance\Data\DataSeed\Friendships.json");

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        Converters = { new JsonStringEnumConverter() }
                    };

                    var frind = JsonSerializer.Deserialize<List<Friendship>>(FrindData, options);
                    if (frind is not null && frind.Any())
                    {
                        _dbContext.Friendships.AddRange(frind);
                        _dbContext.SaveChanges(); 
                    }
                }

                if (!_dbContext.Comments.Any())
                {
                    var CommentData = File.ReadAllText(@"..\Infrastructure\Presistance\Data\DataSeed\Comments.json");
                    var comment = JsonSerializer.Deserialize<List<Comment>>(CommentData);
                    if (comment is not null && comment.Any())
                    {
                        _dbContext.Comments.AddRange(comment);
                        _dbContext.SaveChanges(); 
                    }
                }

                if (!_dbContext.Likes.Any())
                {
                    var likeData = File.ReadAllText(@"..\Infrastructure\Presistance\Data\DataSeed\Likes.json");
                    var like = JsonSerializer.Deserialize<List<Like>>(likeData);
                    if (like is not null && like.Any())
                    {
                        _dbContext.Likes.AddRange(like);
                        _dbContext.SaveChanges(); 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
