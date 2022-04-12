using Aula1.Data;
using Aula1.Model;
using Microsoft.Extensions.Configuration;

namespace Aula1.DAL
{
    public class PostsDAL
    {
        IConfiguration _configuration;
        DefaultConnection _connection;
        public PostsDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new DefaultConnection(_configuration);
        }

        public void Insert(Post post) 
        {
            string query = "INSERT INTO posts (titulo, descricao) ";
            query += $"VALUES('{post.Titulo}', '{post.Descricao}')";
            _connection.ExecuteCommand(query);
        }

        public void Update(Post post)
        {
            string query = $"UPDATE posts SET titulo='{post.Titulo}', descricao='{post.Descricao}' WHERE id="+post.Id;
            _connection.ExecuteCommand(query);
        }

        public void Delete(int Id)
        {
            string query = "DELETE FROM posts WHERE id=" + Id;
            _connection.ExecuteCommand(query);
        }

        public List<Post> GetAll() 
        {
            var posts = new List<Post>();
            var result = _connection.ExecuteQuery("SELECT * FROM posts");
            while (result.Read())
            {
                posts.Add(new Post 
                {
                    Id = int.Parse(result["id"].ToString()),
                    Titulo = result["titulo"].ToString(),
                    Descricao = result["descricao"].ToString()
                });
            }
            return posts;
        }
    }
}
