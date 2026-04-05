using System;
using System.Collections.Generic;

namespace modul6_103082400036
{
    public class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo(string title)
        {
            Random rnd = new Random();
            this.id = rnd.Next(10000, 99999);
            this.title = title;
            this.playCount = 0;
        }

        public void IncreasePlayCount(int count)
        {
            playCount += count;
        }

        // Method 1 
        public void PrintVideoDetails()
        {
            Console.WriteLine($"ID Video: {id} | Judul: {title} | Play Count: {playCount}");
        }

        public string GetTitle()
        {
            return title;
        }

        public int GetPlayCount()
        {
            return playCount;
        }
    }

    public class SayaTubeUser
    {
        private int id;
        private List<SayaTubeVideo> uploadedVideos;
        public string Username;

        public SayaTubeUser(string username)
        {
            Random rnd = new Random();
            this.id = rnd.Next(10000, 99999);
            this.Username = username;
            this.uploadedVideos = new List<SayaTubeVideo>();
        }

        // Method 2 
        public int GetTotalVideoPlayCount()
        {
            int total = 0;
            foreach (var video in uploadedVideos)
            {
                total += video.GetPlayCount();
            }
            return total;
        }

        // Method 3
        public void AddVideo(SayaTubeVideo video)
        {
            uploadedVideos.Add(video);
        }

        // Method 4 
        public void PrintAllVideoPlaycount()
        {
            Console.WriteLine($"User: {Username}");
            for (int i = 0; i < uploadedVideos.Count; i++)
            {
                Console.WriteLine($"Video {i + 1} judul: {uploadedVideos[i].GetTitle()}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. Inisialisasi User
            SayaTubeUser user = new SayaTubeUser("I Gede Putu Artha Jaya Winangun");

            // 2. Menambahkan 10 video (format: Review Film <judul> oleh <nama>)
            SayaTubeVideo v1 = new SayaTubeVideo("Review Film Interstellar oleh I Gede Putu Artha Jaya Winangun");
            SayaTubeVideo v2 = new SayaTubeVideo("Review Film Inception oleh I Gede Putu Artha Jaya Winangun");
            SayaTubeVideo v3 = new SayaTubeVideo("Review Film The Dark Knight oleh I Gede Putu Artha Jaya Winangun");
            SayaTubeVideo v4 = new SayaTubeVideo("Review Film The Matrix oleh I Gede Putu Artha Jaya Winangun");
            SayaTubeVideo v5 = new SayaTubeVideo("Review Film Avengers oleh I Gede Putu Artha Jaya Winangun");
            SayaTubeVideo v6 = new SayaTubeVideo("Review Film Spider-Man oleh I Gede Putu Artha Jaya Winangun");
            SayaTubeVideo v7 = new SayaTubeVideo("Review Film Iron Man oleh I Gede Putu Artha Jaya Winangun");
            SayaTubeVideo v8 = new SayaTubeVideo("Review Film The Batman oleh I Gede Putu Artha Jaya Winangun");
            SayaTubeVideo v9 = new SayaTubeVideo("Review Film Joker oleh I Gede Putu Artha Jaya Winangun");
            SayaTubeVideo v10 = new SayaTubeVideo("Review Film Oppenheimer oleh I Gede Putu Artha Jaya Winangun");

            user.AddVideo(v1); 
            user.AddVideo(v2); 
            
            user.AddVideo(v3);
            user.AddVideo(v4); 
            user.AddVideo(v5); 
            user.AddVideo(v6);
            user.AddVideo(v7); 
            user.AddVideo(v8); 
            user.AddVideo(v9);
            user.AddVideo(v10);

            // 3. Menambah play count
            v1.IncreasePlayCount(100);
            v2.IncreasePlayCount(250);

            // 4. Memanggil PrintVideoDetails
            Console.WriteLine("=== Detail Video Individual ===");
            v1.PrintVideoDetails();
            v2.PrintVideoDetails();

            // 5. Memanggil PrintAllVideoPlaycount & GetTotalVideoPlayCount
            Console.WriteLine("\n=== Daftar Semua Video ===");
            user.PrintAllVideoPlaycount();
            Console.WriteLine($"\nTotal Play Count Keseluruhan: {user.GetTotalVideoPlayCount()}");
        }
    }
}