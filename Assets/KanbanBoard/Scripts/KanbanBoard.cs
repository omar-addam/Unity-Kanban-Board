using System;
using UnityEngine;

namespace KanbanBoard
{
    public class KanbanBoard : MonoBehaviour
    {

        #region Fields/Properties

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
