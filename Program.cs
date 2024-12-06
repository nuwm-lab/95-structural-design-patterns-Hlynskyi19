using System;

namespace SocialMediaAdapter
{
    // Існуючий інтерфейс, який використовується у системі
    public interface ISocialMediaClient
    {
        void PostMessage(string message);
    }

    // Реалізація існуючого інтерфейсу для Facebook
    public class FacebookClient : ISocialMediaClient
    {
        public void PostMessage(string message)
        {
            Console.WriteLine($"Facebook: {message}");
        }
    }

    // Новий API соціальної мережі Instagram, який потрібно адаптувати
    public class InstagramAPI
    {
        public void PostToFeed(string content)
        {
            Console.WriteLine($"Instagram: {content}");
        }
    }

    // Адаптер для Instagram, що реалізує існуючий інтерфейс
    public class InstagramAdapter : ISocialMediaClient
    {
        private readonly InstagramAPI instagramAPI;

        public InstagramAdapter(InstagramAPI api)
        {
            instagramAPI = api;
        }

        public void PostMessage(string message)
        {
            instagramAPI.PostToFeed(message); // Адаптуємо метод PostToFeed до PostMessage
        }
    }

    // Клієнтська частина системи
    public class SocialMediaManager
    {
        private readonly ISocialMediaClient socialMediaClient;

        public SocialMediaManager(ISocialMediaClient client)
        {
            socialMediaClient = client;
        }

        public void Share(string message)
        {
            socialMediaClient.PostMessage(message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Існуючий клієнт Facebook
            ISocialMediaClient facebookClient = new FacebookClient();
            SocialMediaManager facebookManager = new SocialMediaManager(facebookClient);
            facebookManager.Share("Публікація у Facebook.");

            // Новий клієнт Instagram через адаптер
            InstagramAPI instagramAPI = new InstagramAPI();
            ISocialMediaClient instagramAdapter = new InstagramAdapter(instagramAPI);
            SocialMediaManager instagramManager = new SocialMediaManager(instagramAdapter);
            instagramManager.Share("Публікація в Instagram.");
        }
    }
}