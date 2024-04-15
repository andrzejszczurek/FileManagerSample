using FileManagerSample.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileManagerSample.Services
{
    internal class FileService
    {
        private static string _fileName = "users.json";

        // AppDomain.CurrentDomain.BaseDirectory wskazuje na /bin/Debug/net8.0, nasz plik w projekcie znajduje
        // się trzy katalogi wyżej, żeby w ścieżce dopliku dostać się 'wyżej' używamy '..'
        private static string _usersFilePath = 
            @$"{AppDomain.CurrentDomain.BaseDirectory}/../../../Files/{_fileName}";

        public void SaveIntoProjektDirectory(User user)
        {
            // podając tylko nazwę pliku zostanie on tworzony w katalogu, gdzie buduje się projekt
            // czyli /bin/Debug/net8.0/user.json
            Save(user, _usersFilePath);
        }

        public void SaveIntoBinDirectory(User user)
        {
            Save(user, _fileName);
        }

        public List<User> LoadFromProjektDirectory()
        {
            return Load(_usersFilePath);
        }

        public List<User> LoadFromBinDirectory()
        {
            return Load(_fileName);
        }

        private void Save(User user, string path)
        {
            var users = Load(path);

            // dodanie nowego usera do listy
            // Tutaj należałoby jeszcze sprawdzić czy taki user już nie istanieje + inne walidacje
            // teraz każdorazowe uruchomienie programu, będzie podwajać uzytkowników w pliku
            users.Add(user);

            // zamiana listy userów znowu do postaci json
            var userAsJson = JsonConvert.SerializeObject(users, Formatting.Indented);

            // zapis całej listy użytkowników do pliku
            File.WriteAllText(path, userAsJson);
        }

        private List<User> Load(string path)
        {
            // sprawdzamy czy taki plik już istnieje, jeżeli nie to File.ReadAllText spowoduje błąd
            // jak pliku nie ma to znaczy, że nie ma z czego czytać, więc zwracamy pustą listę

            if (!File.Exists(path))
            {
                return new List<User>();
            }

            // wczytanie z pliku wszystkich userów
            var usersJson = File.ReadAllText(path);

            // jeżeli plik jest pusty to także zwracamy pustą listę
            if (string.IsNullOrWhiteSpace(usersJson))
            {
                return new List<User>();
            }

            // zamiana userów w formie json na listę obietów user 
            var users = JsonConvert.DeserializeObject<List<User>>(usersJson);

            return users;
        }
    }
}
