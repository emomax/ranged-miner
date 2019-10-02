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
    animator.Play("game_won");
  }

  public void showGameOver()
  {
    animator.Play("game_over");
  }
}