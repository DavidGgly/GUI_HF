// <copyright file="MainRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RacersDB.Repository
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This is the main Repository layer class.
    /// </summary>
    /// <typeparam name="T">It is a T generic type.</typeparam>
    public abstract class MainRepository<T> : IRepository<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainRepository{T}"/> class.
        /// </summary>
        /// <param name="ctx">DbContext type.</param>
        protected MainRepository(DbContext ctx)
        {
            this.Ctx = ctx;
        }

        /// <summary>
        /// Gets or sets the DbContext type Context, which we are working on.
        /// </summary>
        protected DbContext Ctx { get; set; }

        /// <summary>
        /// Adding new instance to the database, type of T.
        /// </summary>
        /// <param name="newInstance">The exact instance, we'd like to add.</param>
        public void AddNew(T newInstance)
        {
            this.Ctx.Add(newInstance);
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Deleting an old instance from the database, type of T.
        /// </summary>
        /// <param name="oldInstance">The exact instance, we'd like to delete.</param>
        public void DeleteOld(T oldInstance)
        {
            this.Ctx.Remove(oldInstance);
            this.Ctx.SaveChanges();
        }

        /// <summary>
        /// Returns the IQueryable value of T generic type's database..
        /// </summary>
        /// <returns>Returns an IQueryable type Set of T generic type's database.</returns>
        public IQueryable<T> GetAll()
        {
            return this.Ctx.Set<T>();
        }

        /// <summary>
        /// Returns a T type instance, which ID equals the parameter.
        /// </summary>
        /// <param name="id">This is the ID, we're looking for.</param>
        /// <returns>Returns a T type instance.</returns>
        public abstract T GetById(int id);
    }
}