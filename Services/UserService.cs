using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MockAuthPlayground.Models;

namespace MockAuthPlayground.Services;

public class UserService
{
    private const string FilePath = "users.txt";

    private string Base64Encode(string text)
    {
        return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(text));
    }

    private string Base64Decode(string encodedText)
    {
        return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(encodedText));
    }

    private List<User> LoadUsers()
    {
        List<User> users = new List<User>();

        if (!File.Exists(FilePath))
            return users;

        string[] lines = File.ReadAllLines(FilePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');

            User user = new User
            {
                Id = int.Parse(parts[0]),
                Username = parts[1],
                Password = parts[2],
                Funds = int.Parse(parts[3])
            };

            users.Add(user);

        }

        return users;
    }


    private void SaveUsers(List<User> users)
    {
        List<string> lines = new List<string>();
        
        foreach (User user in users)
        {
            string line = $"{user.Id},{user.Username},{user.Password},{user.Funds}";
            lines.Add(line);
        }
        
        File.WriteAllLines(FilePath, lines);
    }

    public void Register(string username, string password)
    {
        List<User> users = LoadUsers();

        int newId = users.Count + 1;
        
        User newUser = new User
        {
            Id = newId,
            Username = username,
            Password = Base64Encode(password),
            Funds = 100
        };

        users.Add(newUser);
        SaveUsers(users);
    }

    public User? Login(string username, string password)
    {
        List<User> users = LoadUsers();
        
        string base64EncodedPassword = Base64Encode(password);
        
        User? found = users.FirstOrDefault(user => user.Username == username && user.Password == base64EncodedPassword); // find user where username and password matches, return the user if found and null if not
        
        return found;
    }

    //public void ChangeUsername(User user, string newUsername){ }

    //public void ChangePassword(User user, string newPassword){ }

    //public void TransferFunds(User sender, User recipient, int amount){ }
}