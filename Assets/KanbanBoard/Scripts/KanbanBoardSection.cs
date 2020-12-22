using KanbanBoard.DataStructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KanbanBoard
{
    public class KanbanBoardSection : MonoBehaviour
    {

        #region Initialization
        /// <summary>
        /// Initializes the content of the pipeline.
        /// </summary>
        public void Initialize(List<Item> items)
        {
            Data = items;
        }

        #endregion

        #region Fields/Properties

        /// <summary>
        /// Items displayed in this board.
        /// </summary>
        public List<Item> Data { private set; get; }

        /// <summary>
        /// The UI element used to inform users that the board is empty.
        /// </summary>
        [SerializeField]
        [Tooltip("The UI element used to inform users that the board is empty.")]
        private Text EmptyUI;

        /// <summary>
        /// References the parent holding all the pipelines and their items. 
        /// </summary>
        [SerializeField]
        [Tooltip("References the parent holding all the pipelines and their items.")]
        private GameObject PipelinesParent;

        #endregion

    }
}
