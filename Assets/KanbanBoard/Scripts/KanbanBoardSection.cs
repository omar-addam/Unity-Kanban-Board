using KanbanBoard.DataStructure;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KanbanBoard
{
    public class KanbanBoardSection : MonoBehaviour
    {

        #region Constants

        /// <summary>
        /// The name displayed on the header when not provided with a category.
        /// </summary>
        private const string OTHERS_CATEGORY = "Others";

        #endregion

        #region Initialization

        /// <summary>
        /// Initializes the content of the pipeline.
        /// </summary>
        /// <param name="items">All items to display in this board.</param>
        /// <param name="pipelines">All pipelines used to classify the items under separate columns.</param>
        /// <param name="dispalyHeader">State if we should display header or not.</param>
        /// <param name="category">Contains the information of the header. If null => Others.</param>
        public void Initialize(List<Item> items, List<Pipeline> pipelines, bool dispalyHeader = false, Category category = null)
        {
            Category = category;
            Data = items ?? new List<Item>();
            Pipelines = pipelines ?? new List<Pipeline>();

            InitializePipelines(dispalyHeader);
        }

        #endregion

        #region Fields/Properties

        /// <summary>
        /// The category being presented by this board.
        /// </summary>
        public Category Category { private set; get; }

        /// <summary>
        /// Items displayed in this board.
        /// </summary>
        public List<Item> Data { private set; get; }

        /// <summary>
        /// A single column will be created for each pipeline.
        /// </summary>
        public List<Pipeline> Pipelines { private set; get; }



        [Header("Category")]

        /// <summary>
        /// References the parent holding the category information.
        /// </summary>
        [SerializeField]
        [Tooltip("References the parent holding the category information.")]
        private GameObject CategoryParent;

        /// <summary>
        /// The UI element used to inform users that the board is expanded.
        /// </summary>
        [SerializeField]
        [Tooltip("The UI element used to inform users that the board is expanded.")]
        private GameObject ExpandedStatus;

        /// <summary>
        /// The UI element used to inform users that the board is collapsed.
        /// </summary>
        [SerializeField]
        [Tooltip("The UI element used to inform users that the board is collapsed.")]
        private GameObject CollapsedStatus;

        /// <summary>
        /// The UI element used to display the name of the category.
        /// </summary>
        [SerializeField]
        [Tooltip("The UI element used to display the name of the category.")]
        private Text CategoryNameText;

        /// <summary>
        /// The UI element used to display the number of items it contains.
        /// </summary>
        [SerializeField]
        [Tooltip("The UI element used to display the number of items it contains.")]
        private Text CategoryItemsCountText;



        [Header("Empty")]

        /// <summary>
        /// The UI element used to inform users that the board is empty.
        /// </summary>
        [SerializeField]
        [Tooltip("The UI element used to inform users that the board is empty.")]
        private Text EmptyUI;



        [Header("Board")]

        /// <summary>
        /// References the parent holding all the pipelines and their items. 
        /// </summary>
        [SerializeField]
        [Tooltip("References the parent holding all the pipelines and their items.")]
        private GameObject PipelinesParent;

        /// <summary>
        /// Template used for initiating columns. 
        /// </summary>
        [SerializeField]
        [Tooltip("Template used for initiating columns.")]
        private GameObject PipelineColumnTemplate;

        /// <summary>
        /// List of all columns created.
        /// </summary>
        private Dictionary<Guid, KanbanBoardColumn> Columns;

        #endregion

        #region Methods

        /// <summary>
        /// Displays the panels for each pipeline.
        /// </summary>
        private void InitializePipelines(bool displayHeader = false)
        {
            // Display header
            CategoryParent.SetActive(displayHeader);
            if (displayHeader)
            {
                CategoryNameText.text = Category?.Name ?? OTHERS_CATEGORY;
                CategoryItemsCountText.text = string.Format("{0} item{1}", Data.Count.ToString("N0"), Data.Count == 1 ? "" : "s");
            }

            // Empty
            if (Data.Count == 0)
            {
                EmptyUI.gameObject.SetActive(true);
                PipelinesParent.gameObject.SetActive(false);
            }

            // Not empty
            else
            {
                EmptyUI.gameObject.SetActive(false);
                PipelinesParent.gameObject.SetActive(true);

                // Clear all columns
                foreach (Transform entity in PipelinesParent.transform)
                    GameObject.Destroy(entity.gameObject);

                // Create columns
                Columns = new Dictionary<Guid, KanbanBoardColumn>();
                foreach (var pipeline in Pipelines)
                {
                    // Create a new entity instance
                    GameObject kanbanPipeline = Instantiate(PipelineColumnTemplate, PipelinesParent.transform);

                    // Extract script
                    KanbanBoardColumn script = kanbanPipeline.GetComponent<KanbanBoardColumn>();

                    // Add to list
                    Columns.Add(pipeline.Id, script);
                }

                // Populate the boards with their items
                foreach (var item in Data)
                    if (item.Pipeline != null
                        && Columns.ContainsKey(item.Pipeline.Id))
                        Columns[item.Pipeline.Id].Add(item);

                // Update column heights
                UpdateColumnHeights();
            }
        }

        /// <summary>
        /// Expands the board.
        /// </summary>
        public void Expand()
        {
            EmptyUI.gameObject.SetActive(false);
            PipelinesParent.gameObject.SetActive(false);
        }

        /// <summary>
        /// Collapse the board.
        /// </summary>
        public void Collapse()
        {
            EmptyUI.gameObject.SetActive(Data.Count == 0);
            PipelinesParent.gameObject.SetActive(Data.Count != 0);
        }

        /// <summary>
        /// Updates the height of board.
        /// </summary>
        private void UpdateColumnHeights()
        {
            // Compute max height
            float maxHeight = 0;
            foreach (var column in Columns.Values)
            {
                float height = column.GetColumnMinHeight();
                maxHeight = Math.Max(height, maxHeight);
            }

            // Set the height of the board
            foreach (var column in Columns.Values)
                column.SetColumnHeight(maxHeight);
        }

        #endregion

    }
}
