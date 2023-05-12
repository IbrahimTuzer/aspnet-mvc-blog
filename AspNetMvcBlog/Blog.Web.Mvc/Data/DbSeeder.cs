using Blog.Web.Mvc.Data.Entity;

namespace Blog.Web.Mvc.Data
{
	public class DbSeeder
	{
		public static void Seed(AppDbContext context)
		{
			if (!context.Categories.Any())
			{
				// Kategorileri oluşturma
				var categories = new Category[]
				{
					new Category { Name = "Teknoloji" },
					new Category { Name = "Spor" },
					new Category { Name = "Sağlık" },
					new Category { Name = "Müzik" }
				};

				context.Categories.AddRange(categories);
				context.SaveChanges();
			}

			if (!context.Posts.Any())
			{
				// Yazıları oluşturma
				var posts = new Post[]
				{
					new Post { Title = "Lorem Ipsum", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."},
					new Post { Title = "Spor Haberleri", Content = "Yerli ve yabancı spor haberleri..."},
					new Post { Title = "Sağlık Haberleri", Content = "Yeni tedavi yöntemleri..."},
					new Post { Title = "Müzik Dünyasından Haberler", Content = "Yeni albümler ve konserler hakkında güncel bilgiler..."}
				};

				context.Posts.AddRange(posts);
				context.SaveChanges();
			}
		}
	}
}
