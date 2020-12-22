using System;
using UnityEngine;

namespace KanbanBoard.DataStructure
{
    [Serializable]
    public class Item
    {

        #region Constructors

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Item()
            : this(Guid.NewGuid())
        {
        }

        /// <summary>
        /// Minimal constructor.
        /// </summary>
        /// <param name="pipelineId">The pipeline stage this item is currently at.</param>
        public Item(Guid pipelineId)
            : this(Guid.NewGuid(), pipelineId)
        {
        }

        /// <summary>
        /// Default constructor.
        /// <param name="id">Unique identifier used to track a board item.</param>
        /// <param name="pipelineId">The pipeline stage this item is currently at.</param>
        /// </summary>
        public Item(Guid id, Guid pipelineId)
        {
            _Id = id;
            _PipelineId = pipelineId;
        }

        /// <summary>
        /// Clone constructor.
        /// </summary>
        /// <param name="item">Instance to clone.</param>
        public Item(Item item)
            : this(item.Id, item.PipelineId)
        {
        }

        #endregion

        #region Fields/Properties

        /// <summary>
        /// Unique identifier used to track a board item.
        /// </summary>
        [SerializeField]
        [Tooltip("Unique identifier used to track a board item.")]
        private Guid _Id;

        /// <summary>
        /// Unique identifier used to track a board item.
        /// </summary>
        public Guid Id { get { return _Id; } }



        /// <summary>
        /// The pipeline stage this item is currently at.
        /// </summary>
        [SerializeField]
        [Tooltip("The pipeline stage this item is currently at.")]
        private Guid _PipelineId;

        /// <summary>
        /// The pipeline stage this item is currently at.
        /// </summary>
        public Guid PipelineId { get { return _PipelineId; } }

        #endregion

        #region Methods

        /// <summary>
        /// Uses the id of the item for hash coding.
        /// </summary>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Uses the id of the item for comparison.
        /// </summary>
        public override bool Equals(object obj)
        {
            Item item = obj as Item;
            return item?.Id == Id;
        }

        /// <summary>
        /// Displays the id of the item.
        /// </summary>
        public override string ToString()
        {
            return Id.ToString();
        }

        #endregion

    }
}
