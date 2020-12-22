using KanbanBoard.DataStructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KanbanBoard
{
    public class KanbanItem : MonoBehaviour
    {

        #region Initialization

        /// <summary>
        /// Initializes the card.
        /// </summary>
        public void Initialize(Item item)
        {
            Data = item;
        }

        #endregion

        #region Fields/Properties

        /// <summary>
        /// Item being represented by this card.
        /// </summary>
        public Item Data { private set; get; }

        #endregion

    }
}
