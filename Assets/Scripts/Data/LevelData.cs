using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
  List<List<Brick>> brickRows;

  public LevelData()
  {
    brickRows = new List<List<Brick>>();
  }
  public void addRow(string[] rawRowData)
  {
    var row = new List<Brick>();

    foreach (string brickType in rawRowData)
    {
      row.Add(new Brick(brickType));
    }

    brickRows.Add(row);
  }

  public int getTotalNumberOfBricks()
  {
    int numberOfBricks = 0;
    foreach (List<Brick> row in brickRows)
    {
      foreach (Brick brick in row)
      {
        numberOfBricks++;
      }
    }

    return numberOfBricks;
  }

  public List<List<Brick>> getRows()
  {
    return brickRows;
  }
}
