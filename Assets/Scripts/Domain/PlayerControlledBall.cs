using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlledBall
{
  private IngameEventBridge eventBridge;

  public PlayerControlledBall(IngameEventBridge eventBridge)
  {
    this.eventBridge = eventBridge;
  }
}
