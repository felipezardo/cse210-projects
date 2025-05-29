
using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    // Class representing a comment
    public class Comment
    {
        public string CommenterName { get; set; }
        public string CommentText { get; set; }

        public Comment(string commenterName, string commentText)
        {
            CommenterName = commenterName;
            CommentText = commentText;
        }
    }

    // Class representing a video
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }
        private List<Comment> comments;

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
            comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return comments.Count;
        }

        public List<Comment> GetComments()
        {
            return comments;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>();

            Video video1 = new Video("C# Basics Tutorial", "CodeAcademy", 600);
            video1.AddComment(new Comment("Alice", "Great explanation!"));
            video1.AddComment(new Comment("Bob", "Very helpful."));
            video1.AddComment(new Comment("Carol", "Loved it!"));
            videos.Add(video1);

            Video video2 = new Video("How to Bake a Cake", "EasyCooking", 900);
            video2.AddComment(new Comment("Dan", "Tried it and it was delicious!"));
            video2.AddComment(new Comment("Eva", "Looks easy, I will try."));
            video2.AddComment(new Comment("Frank", "Awesome recipe!"));
            videos.Add(video2);

            Video video3 = new Video("Top 10 Movies", "MovieMania", 1200);
            video3.AddComment(new Comment("Grace", "Agree with most of them."));
            video3.AddComment(new Comment("Hannah", "You missed some classics."));
            video3.AddComment(new Comment("Ian", "Nice selection!"));
            videos.Add(video3);

            foreach (Video video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
                Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
                Console.WriteLine("Comments:");
                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
                }
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
