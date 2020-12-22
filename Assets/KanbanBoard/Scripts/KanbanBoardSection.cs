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
        public void Initialize(List<Item> items, List<Pipeline> pipelines)
        {
            Data = items ?? new List<Item>();
            Columns = pipelines ?? new List<Pipeline>();

            InitializePipelines();
        }

        #endregion

        #region Fields/Properties

        /// <summary>
        /// Items displayed in this board.
        /// </summary>
        public List<Item> Data { private set; get; }

        /// <summary>
        /// A single column will be created for each pipeline.
        /// </summary>
        public List<Pipeline> Columns { private set; get; }



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

        /// <summary>
        /// Template used for initiating columns. 
        /// </summary>
        [SerializeField]
        [Tooltip("Template used for initiating columns.")]
        private GameObject PipelineColumnTemplate;

        #endregion

        #region Methods

        /// <summary>
        /// Displays the panels for each pipeline.
        /// </summary>
        private void InitializePipelines()
        {
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
                Dictionary<Guid, GameObject> columns = new Dictionary<Guid, GameObject>();
                foreach (var pipeline in Columns)
                {
                    // Create a new entity instance
                    GameObject kanbanPipeline = Instantiate(PipelineColumnTemplate, PipelinesParent.transform);

                    // Add to list
                    columns.Add(pipeline.Id, kanbanPipeline);
                }
            }
        }

        #endregion

    }
}
