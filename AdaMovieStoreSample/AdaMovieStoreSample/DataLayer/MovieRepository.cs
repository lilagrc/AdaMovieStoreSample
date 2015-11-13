﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc.Html;
using AdaMovieStoreSample.Interfaces;
using AdaMovieStoreSample.Models;
using Dapper;

namespace AdaMovieStoreSample.DataLayer
{
    public class MovieRepository
    {
        private SqlConnection db = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName=C:\Users\AdaRockstar\Source\Repos\AdaMovieStoreSample\AdaMovieStoreSample\AdaMovieStoreSample\App_Data\VideoAPI.mdf;Integrated Security=True");

        public List<Movie> GetAll()
        {
            return this.db.Query<Movie>("select * from movies").ToList();
        }

        public Movie Find(int id)
        {
            var dbArgs = new DynamicParameters();
            dbArgs.Add("id", id);

            return this.db.Query<Movie>("select * from movies where id=@id", dbArgs).First();
        }

        public void Add(Movie movie)
        {
            db.Open();
            try
            {
                SqlCommand command = new SqlCommand(
                    "insert into movies (id, title, overview, release_date, inventory) values (@id, @title, @overview, @release_date, @inventory)",
                    this.db);
                command.Parameters.AddWithValue("@id", movie.Id);
                command.Parameters.AddWithValue("@title", movie.Title);
                command.Parameters.AddWithValue("@overview", movie.Overview);
                command.Parameters.AddWithValue("@release_date", movie.ReleaseDate);
                command.Parameters.AddWithValue("@inventory", movie.Inventory);

                command.ExecuteNonQuery();
            }
            finally
            {
                db.Close();
            }
        }

        public Movie Update(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Movie GetFullMovie(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
