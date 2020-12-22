using KanbanBoard.DataStructure;
using System;
using UnityEngine;

namespace KanbanBoard
{
    public class KanbanBoard : MonoBehaviour
    {

        #region Initialization

        /// <summary>
        /// Initializes the data displayed in this board.
        /// </summary>
        public void Initialize(Board board)
        {
            Board = board;
        }

        #endregion

        #region Fields/Properties

        [Header("Data")]

        /// <summary>
        /// The data visualized in this kanban board.
        /// </summary>
        [SerializeField]
        private Board Board;
        


        [Header("Pipelines")]

        /// <summary>
        /// References the parent holding all pipeline stages.
        /// </summary>
        [SerializeField]
        [Tooltip("References the parent holding all pipeline stages.")]
        private GameObject PipelinesParent;

        /// <summary>
        /// Template used for initiating pipeline stages.
        /// </summary>
        [SerializeField]
        [Tooltip("Template used for initiating pipeline stages.")]
        private GameObject PipelineTemplate;

        #endregion

    }
}
