using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEventListener : MonoBehaviour
{
  public abstract void playerBouncedAgainst(int index);
}
