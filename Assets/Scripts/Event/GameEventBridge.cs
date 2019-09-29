using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventBridge : MonoBehaviour
{
  public void registerListener(GameEventListener game)
  {
    // TODO add the listener to our listeners here.
  }

  public void playerBouncedAgainst(int v)
  {
    // TODO propagate event to listeners
  }
}
