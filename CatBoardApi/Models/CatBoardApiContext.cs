using Microsoft.EntityFrameworkCore;

namespace CatBoardApi.Models
{
    public class CatBoardApiContext : DbContext
    {

        public DbSet<Board> Boards { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

        public CatBoardApiContext(DbContextOptions<CatBoardApiContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        builder.Entity<Board>()
            .HasData(
                new Board { BoardId = 1, Name = "Cat's Standing Up", Description = "Cats standing on their hind legs", BannerImage="https://images.unsplash.com/photo-1478098711619-5ab0b478d6e6?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1500&q=80"},
                new Board { BoardId = 2, Name = "Cat's Being Cute", Description = "Cats", BannerImage="https://image.shutterstock.com/image-photo/banner-cat-web-header-template-260nw-1030847524.jpg"},
                new Board { BoardId = 3, Name = "Cat Fight", Description = "Fighting cats", BannerImage="https://images.unsplash.com/photo-1577359472653-792a974e6be2?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1494&q=80"},
                new Board { BoardId = 4, Name = "Cats be cattin", Description = "Cats living like tomorrow doesn't matter.", BannerImage="https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQIUWQ0gHjMSzA0budASFKXc12BXQUGnm8xBl3d9U-_ObGfNCXS&usqp=CAU"}
            );
        builder.Entity<Post>()
            .HasData(
                new Post { PostId = 1, Title = "OMG", Body = "Cats standing on their hind legs", AuthorId = 1, BoardId = 1, ImageSource = "https://pbs.twimg.com/profile_images/1080545769034108928/CEzHCTpI_400x400.jpg"},
                new Post { PostId = 2, Title = "No no no", Body = "Cats", AuthorId = 1, BoardId = 2, ImageSource = "https://pbs.twimg.com/profile_images/1080545769034108928/CEzHCTpI_400x400.jpg"},
                new Post { PostId = 3, Title = "What!", Body = "Fighting cats", AuthorId = 1, BoardId = 1, ImageSource = "https://pbs.twimg.com/profile_images/1080545769034108928/CEzHCTpI_400x400.jpg"},
                new Post { PostId = 4, Title = "That cat can sit.", Body = "Cats living like tomorrow doesn't matter.", AuthorId = 1, BoardId = 2, ImageSource = "https://pbs.twimg.com/profile_images/1080545769034108928/CEzHCTpI_400x400.jpg"}
            );
        builder.Entity<User>()
            .HasData(
                new User { UserId = 1, Name = "John", Email = "123@gmail", Password = "1"},
                new User { UserId = 2, Name = "Markus", Email = "Cats@cats.com", Password = "1"},
                new User { UserId = 3, Name = "Lilly", Email = "ilovecats@gmail.com", Password = "1"},
                new User { UserId = 4, Name = "Jordan", Email = "dogseatcatpoo@yahoo.com", Password = "1"}
            );
        }
    }
}