using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace AutoSalon.Models
{
    public class AppSettings
    {
        public bool IsLoggedIn { get; set; }
        public int IdUser { get; set; }

        public void WriteBoolToJson(bool isLoggedIn, int IdUser)
        {
            var settings = new AppSettings { IsLoggedIn = isLoggedIn, IdUser = IdUser };
            RemoveIsLoggedIn();

            string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
            File.WriteAllText("application.json", json);
        }

        public static bool GetIsLoggedIn()
        {
            if (File.Exists("application.json"))
            {
                string json = File.ReadAllText("application.json");
                var settings = JsonConvert.DeserializeObject<AppSettings>(json);
                return settings?.IsLoggedIn ?? false;
            }
            return false;
        }

        public static int GetIdUser()
        {
            if (File.Exists("application.json"))
            {
                string json = File.ReadAllText("application.json");
                var settings = JsonConvert.DeserializeObject<AppSettings>(json);
                return settings.IdUser;
            }
            return 0;
        }

        public static void RemoveIsLoggedIn()
        {
            if (File.Exists("application.json"))
            {
                // Читаем содержимое файла
                var json = File.ReadAllText("application.json");
                var jsonObject = JObject.Parse(json);

                // Удаляем свойства IsLoggedIn и IdUser
                jsonObject.Remove("IsLoggedIn");
                jsonObject.Remove("IdUser");

                // Сохраняем обновлённый JSON обратно в файл
                File.WriteAllText("application.json", jsonObject.ToString(Formatting.Indented));
            }
        }
    }


}
