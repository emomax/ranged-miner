using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A tad ugly to use abstract class instead of interface..
// .. and all I can say is that it's easier handling 
// serialized classes within Unity. And sorry.
[System.Serializable]
public abstract class GamePhaseEventListener
{
  public abstract void gameOver();
  public abstract void gameStarted();
  public abstract void levelCompleted();
}
