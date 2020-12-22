using KanbanBoard.DataStructure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace KanbanBoard
{
    public class KanbanBoardColumn : MonoBehaviour
    {

        #region Initialization

        /// <summary>
        /// Executes once on start.
        /// </summary>
        private void Awake()
        {
            Data = new List<Item>();
        }

        #endregion

        #region Fields/Properties

        /// <summary>
        /// Items displayed in this column.
        /// </summary>
        public List<Item> Data { private set; get; }

        #endregion

        #region Method

        /// <summary>
        /// Adds item to the column.
        /// </summary>
        public void Add(Item item)
        {
            Data.Add(item);
        }

        /// <summary>
        /// Gets the minimum required height to fit all its items.
        /// </summary>
        public float GetColumnMinHeight()
        {
            // Get layout
            VerticalLayoutGroup layout = GetComponent<VerticalLayoutGroup>();

            // Initialize height
            float height = layout.padding.top + layout.padding.bottom
                + layout.spacing * (Data.Count - 1);

            // Go through all the items
            foreach (Transform transform in gameObject.transform)
            {
                var rectTransform = transform.GetComponent<RectTransform>();
                height += rectTransform.sizeDelta.y;
            }

            return height;
        }

        /// <summary>
        /// Sets the height of the column.
        /// </summary>
        public void SetColumnHeight(float height)
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(0, height);
        }

        #endregion

    }
}
