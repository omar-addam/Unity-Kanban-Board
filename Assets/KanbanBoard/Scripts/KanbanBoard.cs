using System;
using System.Collections.Generic;
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
        public void Initialize(DataStructure.Board board, bool groupByCategories = false)
        {
            Board = board;
            DisplayPipelines();
            DisplayBoards(groupByCategories);
        }

        /// <summary>
        /// Runs once every frame.
        /// </summary>
        private void Update()
        {
            UpdateHeaderPadding();
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

        #region Methods

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
        private void DisplayBoards(bool groupByCategories = false)
        {
            // Note: At the moment, we only support a single board. In the future, we will allow grouping and thus support multiple boards in the same kanban view.

            // Clear all boards
            foreach (Transform entity in BoardsParent.transform)
                GameObject.Destroy(entity.gameObject);

            // Create a single board
            if (!groupByCategories)
            {
                // Create a new entity instance
                GameObject board = Instantiate(BoardTemplate, BoardsParent.transform);

                // Extract the script
                KanbanBoardSection script = board.GetComponent<KanbanBoardSection>();

                // Initialize data
                script.Initialize(Board?.Items, Board?.Pipelines);
            }

            // Group by categories and create a board for each category
            else
            {
                // Categorise the items
                Dictionary<Guid, List<DataStructure.Item>> categorizedItems = new Dictionary<Guid, List<DataStructure.Item>>();
                List<DataStructure.Item> otherItems = new List<DataStructure.Item>();
                foreach (var category in Board?.Categories)
                    categorizedItems.Add(category.Id, new List<DataStructure.Item>());
                foreach (var item in Board?.Items)
                    if (item.Category != null
                        && categorizedItems.ContainsKey(item.Category.Id))
                        categorizedItems[item.Category.Id].Add(item);
                    else otherItems.Add(item);

                // Create boards for categories
                foreach (var category in Board?.Categories)
                {
                    // Create a new entity instance
                    GameObject board = Instantiate(BoardTemplate, BoardsParent.transform);

                    // Extract the script
                    KanbanBoardSection script = board.GetComponent<KanbanBoardSection>();

                    // Initialize data
                    script.Initialize(categorizedItems[category.Id], Board?.Pipelines, true, category);
                }

                // CReate a board for others
                if (otherItems.Count > 0)
                {
                    // Create a new entity instance
                    GameObject board = Instantiate(BoardTemplate, BoardsParent.transform);

                    // Extract the script
                    KanbanBoardSection script = board.GetComponent<KanbanBoardSection>();

                    // Initialize data
                    script.Initialize(otherItems, Board?.Pipelines, true, null);
                }
            }

            // Refresh layouts to scale properly
            foreach (var layuout in BoardsParent.GetComponentsInChildren<RectTransform>())
                LayoutRebuilder.ForceRebuildLayoutImmediate(layuout);
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
