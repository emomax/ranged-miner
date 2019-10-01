using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface GamePhaseEventListener
{
  void gameOver();
  void gameStarted();
  void levelCompleted();
}
