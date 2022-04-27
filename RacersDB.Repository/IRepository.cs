// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RacersDB.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Hides Data layer.
    /// </summary>
    /// <typeparam name="T">It can be Race/Racer or Racetrack class.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Adding new instance to the database, type of T.
        /// </summary>
        /// <param name="newInstance">The type T object, which is going to be added to the DB.</param>
        public void AddNew(T newInstance);

        /// <summary>
        /// Deleting an old instance from the database, based on the ID of the element.
        /// </summary>
        /// <param name="oldInstance">The instance, which should be deleted from the DB.</param>
        public void DeleteOld(T oldInstance);

        /// <summary>
        /// Returns a reference to all instances in database, type T.
        /// </summary>
        /// <returns>An IQueryable type, which can be read by a foreach loop, for example.</returns>
        public IQueryable<T> GetAll();

        /// <summary>
        /// Returns a T type instance, which ID equals the parameter.
        /// </summary>
        /// <param name="id">This is the ID, we're looking for.</param>
        /// <returns>Returns a T type instance.</returns>
        public abstract T GetById(int id);
    }
}
