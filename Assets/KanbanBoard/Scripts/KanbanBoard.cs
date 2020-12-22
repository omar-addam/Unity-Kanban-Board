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
        public void Initialize(DataStructure.Board board)
        {
            Board = board;
            DisplayPipelines();
            DisplayBoards();
        }

        #endregion

        #region Fields/Properties

        [Header("Data")]

        /// <summary>
        /// The data visualized in this kanban board.
        /// </summary>
        [SerializeField]
        private DataStructure.Board Board;
        


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



        [Header("Boards")]

        /// <summary>
        /// References the parent holding all boards.
        /// </summary>
        [SerializeField]
        [Tooltip("References the parent holding all boards.")]
        private GameObject BoardsParent;

        /// <summary>
        /// Template used for initiating boards.
        /// </summary>
        [SerializeField]
        [Tooltip("Template used for initiating boards.")]
        private GameObject BoardTemplate;

        #endregion

        #region Pipeline Methods

        /// <summary>
        /// Displays all pipelines.
        /// </summary>
        private void DisplayPipelines()
        {
            // Clear all current pipelines
            foreach (Transform entity in PipelinesParent.transform)
                GameObject.Destroy(entity.gameObject);

            // Display pipelines
            foreach (var pipeline in Board?.Pipelines)
            {
                // Create a new entity instance
                GameObject kanbanPipeline = Instantiate(PipelineTemplate, PipelinesParent.transform);

                // Extract the script
                KanbanPipeline script = kanbanPipeline.GetComponent<KanbanPipeline>();

                // Initialize data
                script.Initialize(pipeline);
            }
        }

        /// <summary>
        /// Display all boards
        /// </summary>
        private void DisplayBoards()
        {
            // Note: At the moment, we only support a single board. In the future, we will allow grouping and thus support multiple boards in the same kanban view.

            // Clear all boards
            foreach (Transform entity in BoardsParent.transform)
                GameObject.Destroy(entity.gameObject);

            // Create the board
            {
                // Create a new entity instance
                GameObject board = Instantiate(BoardTemplate, BoardsParent.transform);

                // Extract the script
                KanbanBoardSection script = board.GetComponent<KanbanBoardSection>();

                // Initialize data
                script.Initialize(Board?.Items, Board?.Pipelines);
            }
        }

        #endregion

    }
}
