using Aula1.DAL;
using Aula1.Model;
using Microsoft.Extensions.Configuration;

namespace Aula1
{
    internal class Program
    {
        private static IConfiguration _configuration;
        static void Main(string[] args)
        {
            ConfigureAppSettings();

            //int i = 1;
            //while (i <= 10) {
            //    InsertPost("titulo"+i, "descricao"+i);
            //    i++;
            //}

            //InsertPost("Ultimo teste", "de hoje");
            //GetlAll();
            //DeletePost(2);
            //UpdatePost(3,"titulo alterado", "descrição alterada");
            DateTime dt = DateTime.Now;
            Console.WriteLine(dt);
        }

        private static void GetlAll()
        {
            var postDal = new PostsDAL(_configuration);
            var posts = postDal.GetAll();
            foreach (var post in posts)
            {
                Console.WriteLine(post.Id + " - " + post.Titulo + " - " + post.Descricao);
            }
        }

        private static void InsertPost(string titulo, string descricao)
        {
            var postDal = new PostsDAL(_configuration);
            postDal.Insert(new Post { Descricao = descricao, Titulo = titulo });
        }

        private static void UpdatePost(int id, string titulo, string descricao)
        {
            var postDal = new PostsDAL(_configuration);
            postDal.Update(new Post { Id = id, Descricao = descricao, Titulo = titulo });
        }

        private static void DeletePost(int Id)
        {
            var postDal = new PostsDAL(_configuration);
            postDal.Delete(Id);
        }

        private static void ConfigureAppSettings()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();
        }


    }
}
