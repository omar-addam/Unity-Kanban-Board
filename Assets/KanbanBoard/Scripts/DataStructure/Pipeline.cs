using System;
using UnityEngine;

namespace KanbanBoard.DataStructure
{
    [Serializable]
    public class Pipeline
    {

        #region Constructors

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Pipeline()
            : this(Guid.NewGuid(), "N/A")
        {
        }

        /// <summary>
        /// Minimal constructor.
        /// </summary>
        /// <param name="name">Then name of the pipeline stage.</param>
        public Pipeline(string name)
            : this(Guid.NewGuid(), name)
        {
        }

        /// <summary>
        /// Default constructor.
        /// <param name="id">Unique identifier used by items to link them to this pipeline.</param>
        /// <param name="name">Then name of the pipeline stage.</param>
        /// </summary>
        public Pipeline(Guid id, string name)
        {
            _Id = id;
            _Name = name;
        }

        /// <summary>
        /// Clone constructor.
        /// </summary>
        /// <param name="item">Instance to clone.</param>
        public Pipeline(Pipeline item)
            : this(item.Id, item.Name)
        {
        }

        #endregion

        #region Fields/Properties

        /// <summary>
        /// Unique identifier used by items to link them to this pipeline.
        /// </summary>
        [SerializeField]
        [Tooltip("Unique identifier used by items to link them to this pipeline.")]
        private Guid _Id;

        /// <summary>
        /// Unique identifier used by items to link them to this pipeline.
        /// </summary>
        public Guid Id { get { return _Id; } }



        /// <summary>
        /// The name of the pipeline stage.
        /// </summary>
        [SerializeField]
        [Tooltip("The name of the pipeline stage.")]
        private string _Name;

        /// <summary>
        /// The pipeline stage this item is currently at.
        /// </summary>
        public string Name { get { return _Name; } }

        #endregion

        #region Methods

        /// <summary>
        /// Uses the id of the pipeline for hash coding.
        /// </summary>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Uses the id of the pipeline for comparison.
        /// </summary>
        public override bool Equals(object obj)
        {
            Item item = obj as Item;
            return item?.Id == Id;
        }

        /// <summary>
        /// Displays the name of the pipeline.
        /// </summary>
        public override string ToString()
        {
            return Name;
        }

        #endregion

    }
}
