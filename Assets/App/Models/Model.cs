using System;
using System.Collections.Generic;
using Assets.App.Interfaces;
namespace Assets.App.Models
{
    public abstract class Model<TEntity> where TEntity : IEntity
    {
        public Guid Id { get; set; }

        protected abstract TEntity ToEntity();
        protected abstract void FromEntity(TEntity entity);

        protected abstract Dictionary<Guid, TEntity> GetStore();

        /// <summary>
        /// Saves this model to the underlying store.
        /// </summary>
        /// <remarks>
        /// If the model's Id is empty, it will be generated and assigned to the model.
        /// </remarks>
        /// <returns>True on success, false on failure.</returns>
        public bool Save()
        {
            try
            {
                var store = GetStore();

                if (Id == Guid.Empty || !store.TryGetValue(Id, out var existing))
                {
                    var entity = ToEntity();
                    Id = entity.Id;
                    store[Id] = entity;
                }
                else
                {
                    var entity = ToEntity();
                    store[Id] = entity;
                }

                return true;
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogError($"Save failed: {e.Message}");
                return false;
            }
        }


        /// <summary>
        /// Finds and returns a model with the given id.
        /// </summary>
        /// <typeparam name="TModel">The type of model to find.</typeparam>
        /// <param name="id">The id of the model to find.</param>
        /// <returns>A model with the given id, or null if not found.</returns>
        public static TModel Find<TModel>(Guid id)
            where TModel : Model<TEntity>, new()
        {
            var instance = new TModel();
            var store = instance.GetStore();

            if (!store.TryGetValue(id, out var entity))
                return null;

            instance.Id = id;
            instance.FromEntity(entity);
            return instance;
        }
    }

}