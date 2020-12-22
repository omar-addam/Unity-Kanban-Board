using System;
using UnityEngine;
using UnityEngine.UI;

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
        /// References the scroll view of boards.
        /// </summary>
        [SerializeField]
        [Tooltip("References the scroll view of boards.")]
        private ScrollRect BoardsScrollView;

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

            // Refresh layouts to scale properly
            foreach (var layuout in BoardsParent.GetComponentsInChildren<RectTransform>())
                LayoutRebuilder.ForceRebuildLayoutImmediate(layuout);

            UpdateHeaderPadding();
        }

        /// <summary>
        /// Updates the padding of the header based on the visibility of the scrollbar.
        /// </summary>
        public void UpdateHeaderPadding()
        {
            RectTransform header = PipelinesParent.GetComponent<RectTransform>();

            // Check if scroll bar is visible
            // and if we should update header
            if (BoardsScrollView.verticalScrollbar.gameObject.activeSelf
                && header.offsetMin.x == -header.offsetMax.x)
            {
                header.offsetMax = new Vector2
                    (
                        -header.offsetMin.x - BoardsScrollView.verticalScrollbar.GetComponent<RectTransform>().sizeDelta.x,
                        header.offsetMax.y
                    );
            }

            else if (!BoardsScrollView.verticalScrollbar.gameObject.activeSelf
                && header.offsetMin.x != -header.offsetMax.x)
            {
                header.offsetMax = new Vector2(-header.offsetMin.x, header.offsetMax.y);
            }
        }

        #endregion

    }
}
