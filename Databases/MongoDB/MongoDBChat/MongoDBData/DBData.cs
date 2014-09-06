using System;
using System.Linq;
using MongoDB.Driver;
using MongoDBModels;
using System.Collections.Generic;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;


namespace MongoDBData
{

    public class DBData
    {
        const string DatabaseHost = "mongodb://dbadmin:chatpass@ds063929.mongolab.com:63929/crowdchat";
        const string DatabaseName = "crowdchat";
        private MongoDatabase db;

        public DBData()
        {
            db = GetDatabase(DatabaseName, DatabaseHost);
        }

        public MongoCollection<Post> GetAllPosts()
        {
            var posts = db.GetCollection<Post>("Posts");
            return posts;
        }

        public IList<Post> GetPostsSince(DateTime time)
        {
            var postSinceQuery = Query<Post>.Where(log => log.CreatedOn > time);
            return this.GetAllPosts().Find(postSinceQuery).ToList();
        }

        public void AddPost(User user, string text)
        {
            var posts = db.GetCollection<Post>("Posts");
            var post = new Post
            {
                CreatedBy = user,
                CreatedOn = DateTime.Now,
                Text = text
            };
            posts.Insert<Post>(post);
        }

        public User AddUser(string name)
        {
            var users = db.GetCollection<User>("Users");
            var newUser = new User { Username = name };
            users.Insert<User>(newUser);
            return newUser;
        }

        public User FindUserByName(string name)
        {
            var users = db.GetCollection<User>("Users").AsQueryable<User>();
            IQueryable<User> user = users.Where(u => u.Username == name);
            return user.FirstOrDefault();
        }

        private MongoDatabase GetDatabase(string name, string fromHost)
        {
            var mongoClient = new MongoClient(fromHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(name);
        }
    }
}
