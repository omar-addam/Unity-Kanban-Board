using System;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{

    #region Initialization

    /// <summary>
    /// Executes once on start.
    /// </summary>
    private void Awake()
    {
        GenerateEmptySample();
    }

    #endregion

    #region Fields/Properties

    /// <summary>
    /// References the kanban board in the scene.
    /// </summary>
    public KanbanBoard.KanbanBoard Board;

    #endregion

    #region Methods

    /// <summary>
    /// Generates an empty sample and displays it on the board.
    /// </summary>
    public void GenerateEmptySample()
    {
        // Create a new board
        KanbanBoard.DataStructure.Board board = new KanbanBoard.DataStructure.Board();

        // Populate with pipelines
        KanbanBoard.DataStructure.Pipeline toDoPipeline = new KanbanBoard.DataStructure.Pipeline("TO DO");
        KanbanBoard.DataStructure.Pipeline inProgressPipeline = new KanbanBoard.DataStructure.Pipeline("IN PROGRESS");
        KanbanBoard.DataStructure.Pipeline reviewPipeline = new KanbanBoard.DataStructure.Pipeline("REVIEW");
        KanbanBoard.DataStructure.Pipeline donePipeline = new KanbanBoard.DataStructure.Pipeline("DONE");
        board.Pipelines.AddRange(new List<KanbanBoard.DataStructure.Pipeline>()
        {
            toDoPipeline, inProgressPipeline, reviewPipeline, donePipeline
        });

        // Display board
        Board?.Initialize(board);
    }

    /// <summary>
    /// Generates a small sample and displays it on the board.
    /// </summary>
    public void GenerateSmallSample()
    {
        // Create a new board
        KanbanBoard.DataStructure.Board board = new KanbanBoard.DataStructure.Board();

        // Populate with pipelines
        KanbanBoard.DataStructure.Pipeline toDoPipeline = new KanbanBoard.DataStructure.Pipeline("TO DO");
        KanbanBoard.DataStructure.Pipeline inProgressPipeline = new KanbanBoard.DataStructure.Pipeline("IN PROGRESS");
        KanbanBoard.DataStructure.Pipeline reviewPipeline = new KanbanBoard.DataStructure.Pipeline("REVIEW");
        KanbanBoard.DataStructure.Pipeline donePipeline = new KanbanBoard.DataStructure.Pipeline("DONE");
        board.Pipelines.AddRange(new List<KanbanBoard.DataStructure.Pipeline>()
        {
            toDoPipeline, inProgressPipeline, reviewPipeline, donePipeline
        });

        // Populate with items
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline));
        board.Items.Add(new KanbanBoard.DataStructure.Item(reviewPipeline));

        // Display board
        Board?.Initialize(board);
    }

    /// <summary>
    /// Generates a scroll bar sample and displays it on the board.
    /// </summary>
    public void GenerateScrollBarSample()
    {
        // Create a new board
        KanbanBoard.DataStructure.Board board = new KanbanBoard.DataStructure.Board();

        // Populate with pipelines
        KanbanBoard.DataStructure.Pipeline toDoPipeline = new KanbanBoard.DataStructure.Pipeline("TO DO");
        KanbanBoard.DataStructure.Pipeline inProgressPipeline = new KanbanBoard.DataStructure.Pipeline("IN PROGRESS");
        KanbanBoard.DataStructure.Pipeline reviewPipeline = new KanbanBoard.DataStructure.Pipeline("REVIEW");
        KanbanBoard.DataStructure.Pipeline donePipeline = new KanbanBoard.DataStructure.Pipeline("DONE");
        board.Pipelines.AddRange(new List<KanbanBoard.DataStructure.Pipeline>()
        {
            toDoPipeline, inProgressPipeline, reviewPipeline, donePipeline
        });

        // Populate with items
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline));
        board.Items.Add(new KanbanBoard.DataStructure.Item(reviewPipeline));

        // Display board
        Board?.Initialize(board);
    }

    /// <summary>
    /// Generates a categories sample and displays it on the board.
    /// </summary>
    public void GenerateCategoriesSample()
    {
        // Create a new board
        KanbanBoard.DataStructure.Board board = new KanbanBoard.DataStructure.Board();

        // Populate with pipelines
        KanbanBoard.DataStructure.Pipeline toDoPipeline = new KanbanBoard.DataStructure.Pipeline("TO DO");
        KanbanBoard.DataStructure.Pipeline inProgressPipeline = new KanbanBoard.DataStructure.Pipeline("IN PROGRESS");
        KanbanBoard.DataStructure.Pipeline reviewPipeline = new KanbanBoard.DataStructure.Pipeline("REVIEW");
        KanbanBoard.DataStructure.Pipeline donePipeline = new KanbanBoard.DataStructure.Pipeline("DONE");
        board.Pipelines.AddRange(new List<KanbanBoard.DataStructure.Pipeline>()
        {
            toDoPipeline, inProgressPipeline, reviewPipeline, donePipeline
        });

        // Populate with categories
        KanbanBoard.DataStructure.Category category1 = new KanbanBoard.DataStructure.Category("Category 1");
        KanbanBoard.DataStructure.Category category2 = new KanbanBoard.DataStructure.Category("Category 2");
        board.Categories.AddRange(new List<KanbanBoard.DataStructure.Category>()
        {
            category1, category2
        });

        // Populate with items
        board.Items.Add(new KanbanBoard.DataStructure.Item(Guid.NewGuid(), toDoPipeline, category1));
        board.Items.Add(new KanbanBoard.DataStructure.Item(Guid.NewGuid(), toDoPipeline, category1));
        board.Items.Add(new KanbanBoard.DataStructure.Item(Guid.NewGuid(), toDoPipeline, null));
        board.Items.Add(new KanbanBoard.DataStructure.Item(Guid.NewGuid(), toDoPipeline, category2));
        board.Items.Add(new KanbanBoard.DataStructure.Item(Guid.NewGuid(), toDoPipeline, category2));
        board.Items.Add(new KanbanBoard.DataStructure.Item(Guid.NewGuid(), toDoPipeline, category1));
        board.Items.Add(new KanbanBoard.DataStructure.Item(Guid.NewGuid(), reviewPipeline, null));
        board.Items.Add(new KanbanBoard.DataStructure.Item(Guid.NewGuid(), toDoPipeline, null));
        board.Items.Add(new KanbanBoard.DataStructure.Item(Guid.NewGuid(), toDoPipeline, category1));
        board.Items.Add(new KanbanBoard.DataStructure.Item(Guid.NewGuid(), toDoPipeline, null));
        board.Items.Add(new KanbanBoard.DataStructure.Item(Guid.NewGuid(), donePipeline, null));
        board.Items.Add(new KanbanBoard.DataStructure.Item(Guid.NewGuid(), toDoPipeline, category2));
        board.Items.Add(new KanbanBoard.DataStructure.Item(Guid.NewGuid(), toDoPipeline, category2));
        board.Items.Add(new KanbanBoard.DataStructure.Item(Guid.NewGuid(), toDoPipeline, category2));
        board.Items.Add(new KanbanBoard.DataStructure.Item(Guid.NewGuid(), reviewPipeline, category1));

        // Display board
        Board?.Initialize(board, true);
    }

    #endregion

}
