using System;

namespace PersonalBlog.Service.ResultMessages;

public static class Messages
{
    public static class Article
    {
        public static string Add(string articleTitle) => $"{articleTitle} article added successfully";

        public static string Update(string articleTitle) => $"{articleTitle} article updated successfully";
        public static string Delete(string articleTitle) => $"{articleTitle} article deleted successfully";
        public static string UndoDelete(string articleTitle) => $"{articleTitle} article undo deleted successfully";
    }

    public static class Category
    {
        public static string Add(string categoryName) => $"{categoryName} category added successfully";
        public static string Update(string categoryName) => $"{categoryName} category updated successfully";
        public static string Delete(string categoryName) => $"{categoryName} category deleted successfully";
        public static string UndoDelete(string categoryName) => $"{categoryName} category undo deleted successfully";
    }

    public static class User 
    {
        public static string Add(string userName) => $"{userName} user added successfully";
        public static string Update(string userName) => $"{userName} user updated successfully";
        public static string Delete(string userName) => $"{userName} user deleted successfully";
        public static string UndoDelete(string userName) => $"{userName} user undo deleted successfully";
    }

}
