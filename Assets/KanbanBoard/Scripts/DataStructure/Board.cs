using System;
using System.Collections.Generic;
using UnityEngine;

namespace KanbanBoard.DataStructure
{
    [Serializable]
    public class Board
    {

        #region Constructors

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Board()
            : this(new List<Pipeline>(), new List<Item>())
        {
        }

        /// <summary>
        /// Default constructor.
        /// <param name="pipelines">List of all pipelines in the board.</param>
        /// <param name="items">List of all items in the board.</param>
        /// </summary>
        public Board(List<Pipeline> pipelines, List<Item> items)
        {
            _Pipelines = pipelines;
            _Items = items;
        }

        /// <summary>
        /// Clone constructor.
        /// </summary>
        /// <param name="board">Instance to clone.</param>
        public Board(Board board)
            : this()
        {
            // Clone the pipelines
            foreach (var pipeline in board.Pipelines)
                _Pipelines.Add(new Pipeline(pipeline));

            // Clone the items
            foreach (var item in board.Items)
                _Items.Add(new Item(item));
        }

        #endregion

        #region Properties

        /// <summary>
        /// List of all pipelines in the board.
        /// </summary>
        [SerializeField]
        [Tooltip("List of all pipelines in the board.")]
        private List<Pipeline> _Pipelines;

        /// <summary>
        /// List of all pipelines in the board.
        /// </summary>
        public List<Pipeline> Pipelines { get { return _Pipelines; } }



        /// <summary>
        /// List of all items in the board.
        /// </summary>
        [SerializeField]
        [Tooltip("List of all items in the board.")]
        private List<Item> _Items;

        /// <summary>
        /// List of all items in the board.
        /// </summary>
        public List<Item> Items { get { return _Items; } }

        #endregion

        #region Methods

        /// <summary>
        /// Displays the number of pipelines and items.
        /// </summary>
        public override string ToString()
        {
            return string.Format("#Pipelines: {0} | #Items: {1}", _Pipelines?.Count, _Items?.Count);
        }

        #endregion

    }
}