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
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline.Id));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline.Id));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline.Id));
        board.Items.Add(new KanbanBoard.DataStructure.Item(reviewPipeline.Id));

        // Display board
        Board?.Initialize(board);
    }

    /// <summary>
    /// Generates a scroll bar sample sample and displays it on the board.
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
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline.Id));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline.Id));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline.Id));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline.Id));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline.Id));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline.Id));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline.Id));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline.Id));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline.Id));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline.Id));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline.Id));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline.Id));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline.Id));
        board.Items.Add(new KanbanBoard.DataStructure.Item(toDoPipeline.Id));
        board.Items.Add(new KanbanBoard.DataStructure.Item(reviewPipeline.Id));

        // Display board
        Board?.Initialize(board);
    }

    #endregion

}
