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
            : this(new Pipeline())
        {
        }

        /// <summary>
        /// Minimal constructor.
        /// </summary>
        /// <param name="pipeline">The pipeline stage this item is currently at.</param>
        public Item(Pipeline pipeline)
            : this(Guid.NewGuid(), pipeline)
        {
        }

        /// <summary>
        /// Default constructor.
        /// <param name="id">Unique identifier used to track a board item.</param>
        /// <param name="pipeline">The pipeline stage this item is currently at.</param>
        /// </summary>
        public Item(Guid id, Pipeline pipeline)
        {
            _Id = id;
            _Pipeline = pipeline;
        }

        /// <summary>
        /// Clone constructor.
        /// </summary>
        /// <param name="item">Instance to clone.</param>
        public Item(Item item)
            : this(item.Id, item.Pipeline)
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
        private Pipeline _Pipeline;

        /// <summary>
        /// The pipeline stage this item is currently at.
        /// </summary>
        public Pipeline Pipeline { get { return _Pipeline; } }

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
