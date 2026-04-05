using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace modul6_103082400036
{
    public class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo(string title)
        {
            // Prekondisi (i, ii): Judul maks 200 karakter dan tidak null
            Debug.Assert(title != null && title.Length <= 200, "Judul video maksimal 200 karakter dan tidak berupa null");
            if (title == null || title.Length > 200) throw new ArgumentException("Judul video tidak valid.");

            Random rnd = new Random();
            this.id = rnd.Next(10000, 99999);
            this.title = title;
            this.playCount = 0;
        }

        public void IncreasePlayCount(int count)
        {
            // Prekondisi (iii, iv): Penambahan maks 25.000.000 dan tidak negatif
            Debug.Assert(count <= 25000000 && count >= 0, "Input penambahan play count maksimal 25.000.000 dan tidak negatif");
            if (count > 25000000 || count < 0) throw new ArgumentOutOfRangeException("Input penambahan tidak valid.");

            // Exception (i): Memastikan tidak terjadi overflow
            checked
            {
                playCount += count;
            }
        }

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
            // Prekondisi (v, vi): Username maks 100 karakter dan tidak null
            Debug.Assert(username != null && username.Length <= 100, "Username maksimal 100 karakter dan tidak berupa null");
            if (username == null || username.Length > 100) throw new ArgumentException("Username tidak valid.");

            Random rnd = new Random();
            this.id = rnd.Next(10000, 99999);
            this.Username = username;
            this.uploadedVideos = new List<SayaTubeVideo>();
        }

        public int GetTotalVideoPlayCount()
        {
            int total = 0;
            foreach (var video in uploadedVideos)
            {
                total += video.GetPlayCount();
            }
            return total;
        }

        public void AddVideo(SayaTubeVideo video)
        {
            // Prekondisi (vii, viii): Video tidak null dan playcount kurang dari integer maksimum
            Debug.Assert(video != null && video.GetPlayCount() < int.MaxValue, "Video tidak boleh null dan play count kurang dari int maksimum");
            if (video == null || video.GetPlayCount() >= int.MaxValue) throw new ArgumentException("Video tidak valid untuk ditambahkan.");

            uploadedVideos.Add(video);
        }

        public void PrintAllVideoPlaycount()
        {
            Console.WriteLine($"User: {Username}");

            // Postkondisi (i): Jumlah video maksimal yang di-print adalah 8
            int batas = uploadedVideos.Count < 8 ? uploadedVideos.Count : 8;
            for (int i = 0; i < batas; i++)
            {
                Console.WriteLine($"Video {i + 1} judul: {uploadedVideos[i].GetTitle()}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try // Blok try-catch untuk menampung exception
            {
                SayaTubeUser user = new SayaTubeUser("I Gede Putu Artha Jaya Winangun");

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

                user.AddVideo(v1); user.AddVideo(v2); user.AddVideo(v3);
                user.AddVideo(v4); user.AddVideo(v5); user.AddVideo(v6);
                user.AddVideo(v7); user.AddVideo(v8); user.AddVideo(v9);
                user.AddVideo(v10);

                // Menguji Prekondisi input play count
                v1.IncreasePlayCount(25000000);

                Console.WriteLine("=== Detail Video Individual ===");
                v1.PrintVideoDetails();

                Console.WriteLine("\n=== Daftar Video Setelah Postcondition (Maks 8) ===");
                user.PrintAllVideoPlaycount();

                Console.WriteLine($"\nTotal Keseluruhan Play Count: {user.GetTotalVideoPlayCount()}");

                Console.WriteLine("\n=== Menguji Exception & Overflow ===");
                // For loop untuk mempercepat batas maksimum integer
                for (int i = 0; i < 90; i++)
                {
                    v1.IncreasePlayCount(25000000);
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Error tertangkap: " + ex.Message + " (Terjadi Overflow pada nilai Play Count!)");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error umum tertangkap: " + ex.Message);
            }
        }
    }
}