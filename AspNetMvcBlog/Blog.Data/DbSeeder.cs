using Blog.Data.Entity;

namespace Blog.Data
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
					new Category { Name = "Teknoloji", Slug = "teknoloji" },
					new Category { Name = "Spor", Slug = "spor" },
					new Category { Name = "Sağlık", Slug = "saglik" },
					new Category { Name = "Müzik", Slug = "muzik" }
				};

				context.Categories.AddRange(categories);
				context.SaveChanges();
			}
            if (!context.Users.Any())
            {
                context.Users.Add(new User { Name = "Admin" ,Email="admin@gmail.com",Password="admin",Phone="05366666666", City="Ankara"});
                context.SaveChanges();
            }
            if (!context.Posts.Any())
			{
				// Yazıları oluşturma
				var posts = new Post[]
				{
					new Post { Title = "Lorem Ipsum", Content = "Cras ut metus a risus iaculis scelerisque eu ac ante fusce non varius purus aenean nec magna felis fusce vestibulum velit mollis odio sollicitudin lacinia aliquam posuere, sapien elementum lobortis tincidunt, turpis dui ornare nisl, sollicitudin interdum turpis nunc eget sem nulla eu ultricies orci praesent id augue nec lorem pretium congue sit amet ac nunc fusce iaculis lorem eu diam hendrerit at mattis purus dignissim vivamus mauris tellus, fringilla vel dapibus a, blandit quis erat vivamus elementum aliquam luctus.", Categories=new List<Category>{context.Categories.FirstOrDefault(e => e.Id == 1) },UserId=1},
					new Post { Title = "Spor Haberleris", Content = "Yerli ve yabancı spor haberleri...", Categories=new List<Category>{context.Categories.FirstOrDefault(e => e.Id == 2) },UserId=1},
					new Post { Title = "Sağlık Haberleri", Content = "Yeni tedavi yöntemleri...", Categories=new List<Category>{context.Categories.FirstOrDefault(e => e.Id == 3) },UserId=1},
					new Post { Title = "Müzik Dünyasından Haberler", Content = "Yeni albümler ve konserler hakkında güncel bilgiler...",Categories=new List<Category>{context.Categories.FirstOrDefault(e => e.Id == 4) },UserId=1}
				};
				
				context.Posts.AddRange(posts);
				context.SaveChanges();
			}
            if (!context.Pages.Any())
            {
                // Yazıları oluşturma
                var pages = new Page[]
                {
                    new Page { Title = "Sayfa adı"}
                   
                };

                context.Pages.AddRange(pages);
                context.SaveChanges();
            }

        }
	}
}
