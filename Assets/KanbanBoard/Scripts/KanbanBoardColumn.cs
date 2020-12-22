using KanbanBoard.DataStructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KanbanBoard
{
    public class KanbanBoardColumn : MonoBehaviour
    {

        #region Initialization

        /// <summary>
        /// Executes once on start.
        /// </summary>
        private void Awake()
        {
            Data = new List<Item>();
        }

        #endregion

        #region Fields/Properties

        /// <summary>
        /// Items displayed in this column.
        /// </summary>
        public List<Item> Data { private set; get; }

        #endregion

        #region Method

        /// <summary>
        /// Adds item to the column.
        /// </summary>
        public void Add(Item item)
        {
            Data.Add(item);
        }

        #endregion

    }
}
