using System;
using UnityEngine;

public class ProgressIndicationHandler : MonoBehaviour
{
  private Animator animator;

  void Start()
  {
    animator = this.GetComponent<Animator>();
  }

  public void showGameWon()
  {
    animator.Play("level_completed-show");
  }

  public void showGameOver()
  {
    // animator.Play("game_over");
  }

  public void countDown()
  {
    animator.Play("count_down");
  }
}