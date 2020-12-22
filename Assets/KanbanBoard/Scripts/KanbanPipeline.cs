using KanbanBoard.DataStructure;
using UnityEngine;
using UnityEngine.UI;

namespace KanbanBoard
{
    public class KanbanPipeline : MonoBehaviour
    {

        #region Initialization

        /// <summary>
        /// Executes once on start.
        /// </summary>
        private void Awake()
        {
            TitleUI = GetComponentInChildren<Text>();
        }

        /// <summary>
        /// Initializes the content of the pipeline.
        /// </summary>
        public void Initialize(Pipeline pipeline)
        {
            Data = pipeline;

            TitleUI.text = pipeline.Name;
        }

        #endregion

        #region Fields/Properties

        /// <summary>
        /// The UI element displaying the title of the pipleine.
        /// </summary>
        private Text TitleUI;

        /// <summary>
        /// The pipeline data visualized by this component.
        /// </summary>
        public Pipeline Data { private set; get; }

        #endregion

    }
}
