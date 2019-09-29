using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IngameEventBridge
{
  private List<IngameEventListener> listeners;

  public IngameEventBridge()
  {
    listeners = new List<IngameEventListener>();
  }

  public void registerListener(IngameEventListener listener)
  {
    listeners.Add(listener);
  }

  public void playerBouncedAgainst(int brickIndex)
  {
    foreach (var listener in listeners)
    {
      listener.playerBouncedAgainst(brickIndex);
    }
  }
}
