using System;
using UnityEngine;

namespace KanbanBoard.DataStructure
{
    [Serializable]
    public class Category
    {

        #region Constructors

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Category()
            : this(Guid.NewGuid(), "N/A")
        {
        }

        /// <summary>
        /// Minimal constructor.
        /// </summary>
        /// <param name="name">Then name of the category.</param>
        public Category(string name)
            : this(Guid.NewGuid(), name)
        {
        }

        /// <summary>
        /// Default constructor.
        /// <param name="id">Unique identifier used by items to link them to this category.</param>
        /// <param name="name">Then name of the category.</param>
        /// </summary>
        public Category(Guid id, string name)
        {
            _Id = id;
            _Name = name;
        }

        /// <summary>
        /// Clone constructor.
        /// </summary>
        /// <param name="item">Instance to clone.</param>
        public Category(Category item)
            : this(item.Id, item.Name)
        {
        }

        #endregion

        #region Fields/Properties

        /// <summary>
        /// Unique identifier used by items to link them to this category.
        /// </summary>
        [SerializeField]
        [Tooltip("Unique identifier used by items to link them to this category.")]
        private Guid _Id;

        /// <summary>
        /// Unique identifier used by items to link them to this category.
        /// </summary>
        public Guid Id { get { return _Id; } }



        /// <summary>
        /// The name of the category.
        /// </summary>
        [SerializeField]
        [Tooltip("The name of the category.")]
        private string _Name;

        /// <summary>
        /// The name of the category.
        /// </summary>
        public string Name { get { return _Name; } }

        #endregion

        #region Methods

        /// <summary>
        /// Uses the id of the category for hash coding.
        /// </summary>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Uses the id of the category for comparison.
        /// </summary>
        public override bool Equals(object obj)
        {
            Item item = obj as Item;
            return item?.Id == Id;
        }

        /// <summary>
        /// Displays the name of the category.
        /// </summary>
        public override string ToString()
        {
            return Name;
        }

        #endregion

    }
}
