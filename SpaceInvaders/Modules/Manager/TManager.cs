using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.Modules.Game;
using System;
using System.Collections.Generic;

namespace SpaceInvaders.Modules.Manager
{
    class TManager<T> where T : GameObject
    {
        #region Variables
        public int ID { get; set; }

        private List<T> objectList = new List<T>();
        private List<Int32> DeleteList = new List<Int32>();
        #endregion

        #region Access Methods
        public Int32 ObjectCount
        {
            get { return objectList.Count; }
        }

        public T this[Int32 id]
        {
            get { return objectList[id]; }
            set { objectList[id] = value;}
        }
        #endregion

        #region Core
        public TManager()
        {
        }

        public TManager(T obj)
        {
            objectList = new List<T>();
            ID = 0;
        }

        public Int32 Add(T obj)
        {
            obj.BaseID = ID++;
            objectList.Add(obj);

            return obj.BaseID;
        }

        public void MarkForRemoval(Int32 id) 
        {
            DeleteList.Add(id);
        }

        /// <summary>
        /// Returns True if objected deleted.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool Delete(Int32 id)
        {
            bool deleted = true;

            foreach (T obj in objectList)
            {
                if (obj.BaseID == id)
                {
                    try
                    {
                        objectList.Remove(obj);
                        break;
                    }
                    catch (Exception e)
                    {
                        deleted = false;
                        Console.WriteLine("Failed to Delete Object!: " + e);
                        break;
                    }
                }
            }

            return deleted;
        }

        /// <summary>
        /// Update all managed objects.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
            if(objectList.Count > 0)
            {
                foreach(T obj in objectList)
                {
                    obj.Update(gameTime);
                }
            }

            //Remove objects
            if(DeleteList.Count > 0)
            {
                foreach(Int32 id in DeleteList)
                {
                    Delete(id);
                }

                DeleteList.Clear();
            }
        }

        /// <summary>
        /// Draw all managed objects.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Draw(GameTime gameTime)
        {
            if(objectList.Count > 0)
            {
                foreach(T obj in objectList)
                {
                    obj.Draw(gameTime);
                }
            }
        }
        #endregion
    }
}
