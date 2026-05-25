using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application_06.Models; // <-- Make sure this line is here!

namespace Application_06.Services
{
    public class NotificationItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public string Type { get; set; } = "Info";
    }

    public class NotificationService
    {
        private readonly NotificationConfig _config;

        public NotificationService(NotificationConfig config)
        {
            _config = config;
        }

        public async Task<List<NotificationItem>> GetNotificationsAsync(int? numberOfNotifications = null)
        {
            await Task.Delay(300);

            int count = numberOfNotifications ?? _config.DefaultNumberOfNotifications;

            var list = new List<NotificationItem>();
            var types = new[] { "Success", "Info", "Warning" };
            var titles = new[] { "System Update", "New Message", "Storage Warning", "Security Alert", "Backup Completed" };
            var messages = new[] {
                "Your system has been successfully updated to the latest version.",
                "You have received a new direct message from the team lead.",
                "Your cloud storage utilization has reached 85% capacity.",
                "A login attempt was detected from a new device or location.",
                "The nightly automated database backup finished without errors."
            };

            for (int i = 0; i < count; i++)
            {
                list.Add(new NotificationItem // <-- Double check this has a capital 'A'
                {
                    Id = i + 1,
                    Title = titles[i % titles.Length],
                    Message = messages[i % messages.Length],
                    Timestamp = DateTime.Now.AddMinutes(-15 * i),
                    Type = types[i % types.Length]
                });
            }

            return list;
        }
    }
}