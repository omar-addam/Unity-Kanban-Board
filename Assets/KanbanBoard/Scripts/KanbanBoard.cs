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

        #endregion

    }
}
