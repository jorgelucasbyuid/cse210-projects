using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Vídeo 1
        Video video1 = new Video("C# Abstraction and Classes Explained", "Tech Academy", 720);
        video1.AddComment(new Comment("Alice", "Great explanation of abstraction!"));
        video1.AddComment(new Comment("Bob", "This made OOP concepts so much clearer."));
        video1.AddComment(new Comment("Charlie", "Thanks for the step-by-step examples."));
        videos.Add(video1);

        // Vídeo 2
        Video video2 = new Video("Top 10 Hidden Gems in Chile", "Travel Channel", 900);
        video2.AddComment(new Comment("David", "Valparaíso and Viña look incredible!"));
        video2.AddComment(new Comment("Elena", "Definitely adding the Andes to my travel plan."));
        video2.AddComment(new Comment("Fernando", "Awesome video editing and storytelling."));
        videos.Add(video2);

        // Vídeo 3
        Video video3 = new Video("Data Analysis with Python for Beginners", "Code Insights", 1050);
        video3.AddComment(new Comment("Grace", "Super helpful breakdown of data structures."));
        video3.AddComment(new Comment("Hector", "Saved me hours on my university project!"));
        video3.AddComment(new Comment("Isabela", "Clear and straight to the point."));
        videos.Add(video3);

        // Vídeo 4
        Video video4 = new Video("20-Minute Full Body HIIT Routine", "FitLife", 1200);
        video4.AddComment(new Comment("Jack", "That was intense! Loved the workout."));
        video4.AddComment(new Comment("Karen", "Great pace and easy to follow."));
        video4.AddComment(new Comment("Leo", "Adding this to my weekly training schedule."));
        videos.Add(video4);

        // Iterar e exibir as informações de cada vídeo
        foreach (Video video in videos)
        {
            video.DisplayVideo();
        }
    }
}