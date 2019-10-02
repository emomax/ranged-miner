using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunner : MonoBehaviour
{
  private RangedMinerBreakoutGame application;

  [SerializeField]
  private List<GameEventListener> listeners;

  [SerializeField]
  private Animator cameraAnimator;

  // In-Game stuff
  [SerializeField]
  private LevelHelper levelHelper;
  [SerializeField]
  private BouncyBall ball;
  [SerializeField]
  private PlayerControlledPaddle paddle;

  // UI Handling

  [SerializeField]
  private UIHelper uiHelper;
  [SerializeField]
  private ProgressIndicationHandler progressIndicationHandler;

  void Start()
  {

    application = new RangedMinerBreakoutGame();
  }

  public void loadLevel(int levelId)
  {
    LevelData levelData = getLevelDataFor(levelId);
    application.loadLevel(levelData);
    levelHelper.buildLevel(levelData);

    application.start();

    cameraAnimator.Play("transition_to-in_game");
    uiHelper.hideAllButtons();

    StartCoroutine(readyForStart());
  }

  private LevelData getLevelDataFor(int levelId)
  {
    LevelData levelData = new LevelData();

    if (levelId == 1)
    {
      levelData.addRow(new string[] { "b", "b", "b", "b", "b" });
      levelData.addRow(new string[] { "b", "b", "b", "b" });
      levelData.addRow(new string[] { "b", "b", "b", "b", "b" });
    }
    else if (levelId == 2)
    {
      levelData.addRow(new string[] { "b", "b", "b", "b", "b", "b" });
      levelData.addRow(new string[] { "b", "g", "g", "g", "b" });
      levelData.addRow(new string[] { "b", "b", "b", "b", "b", "b" });
    }
    else if (levelId == 3)
    {
      levelData.addRow(new string[] { "b", "b", "b", "b", "b", "b" });
      levelData.addRow(new string[] { "b", "g", "e", "g", "b" });
      levelData.addRow(new string[] { "b", "g", "e", "e", "g", "b" });
      levelData.addRow(new string[] { "b", "g", "e", "g", "b" });
      levelData.addRow(new string[] { "b", "b", "b", "b", "b", "b" });
    }
    else
    {
      throw new UnityException("Unhandled level: '" + levelId + "'");
    }

    return levelData;
  }

  private IEnumerator readyForStart()
  {
    Debug.Log("Ready for start!");
    yield return new WaitForSeconds(1.2f);
    ball.shoot();
  }

  public void playerCollidedWith(int indexOfBrick)
  {
    application.playerBouncedAgainst(indexOfBrick);

    if (application.isLevelCompleted())
    {
      gameWon();
    }
  }

  private void gameWon()
  {
    Time.timeScale = 0.5f;
    progressIndicationHandler.showGameWon();
    StartCoroutine(transitionToMenu());
  }

  // Triggered by LoseZone upon player entering it.
  public void gameOver()
  {
    application.playerHitLoseZone();
    progressIndicationHandler.showGameOver();
    StartCoroutine(transitionToMenu());
  }

  private IEnumerator transitionToMenu()
  {
    yield return new WaitForSeconds(1.2f);
    cameraAnimator.Play("transition_to-main_menu");

    yield return new WaitForSeconds(1f);
    ball.reset();
    paddle.reset();
    levelHelper.resetLevel();
    uiHelper.showAllButtons();

    Time.timeScale = 1f;
  }
}