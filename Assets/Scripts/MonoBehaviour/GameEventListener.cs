using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEventListener : MonoBehaviour, GamePhaseEventListener
{
  public abstract void gameOver();

  public abstract void gameStarted();

  public abstract void levelCompleted();
}
