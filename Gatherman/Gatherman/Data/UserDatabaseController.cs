using Gatherman.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Gatherman.Data
{
    public class UserDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public UserDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Utilisateurs>();
        }
        public Utilisateurs GetUtilisateurs()
        {
            lock (locker)
            {
                if (database.Table<Utilisateurs>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Utilisateurs>().First();
                }
            }
        }
        public int SaveUtilisateur(Utilisateurs utilisateur)
        {
            lock (locker)
            {
                if(utilisateur.Id != 0)
                {
                    database.Update(utilisateur);
                    return utilisateur.Id;
                }
                else
                {
                    Console.WriteLine("Id utilisateur " + utilisateur.Id);
                    Console.WriteLine("Id nom " + utilisateur.NomUtilisateur);
                    Console.WriteLine("Id password " + utilisateur.MotDePasse);

                    return database.Insert(utilisateur);
                }
            }
        }
        public int DeteteUtilisateur(int id)
        {
            lock (locker)
            {
                return database.Delete<Utilisateurs>(id);
            }
        }
    }
}
