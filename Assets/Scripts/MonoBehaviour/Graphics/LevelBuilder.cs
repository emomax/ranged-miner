using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Brick;

public class LevelBuilder : MonoBehaviour
{

  [SerializeField]
  private GameObject brickPrefab;

  [SerializeField]
  private GameObject goldBrickPrefab;

  [SerializeField]
  private GameObject emeraldBrickPrefab;

  [SerializeField]
  private float distanceBetweenRows;
  [SerializeField]
  private float brickWidth;

  public void buildLevel(LevelData data)
  {
    float xOffset = 0.2f;
    float yOffset = 0f;

    int brickIndex = 0;
    foreach (var row in data.getRows())
    {
      float startingPointX = -((row.Count - 1) * (brickWidth + xOffset)) / 2f;

      for (int i = 0; i < row.Count; i++)
      {
        GameObject brickPrefab = getPrefabFor(row[i].getBrickType());
        GameObject brick = Instantiate(brickPrefab, this.transform);

        brick.transform.localPosition = new Vector3(startingPointX + i * (brickWidth + xOffset), yOffset, 0f);
        brick.GetComponent<IngameBrick>().setId(brickIndex);
        brick.gameObject.name = "brick-" + (brickIndex++).ToString();
      }

      yOffset -= distanceBetweenRows;
    }
  }

  private GameObject getPrefabFor(BrickType type)
  {
    switch (type)
    {
      case BrickType.BRITTLE:
        return brickPrefab;
      case BrickType.GOLD:
        return goldBrickPrefab;
      case BrickType.EMERALD:
        return emeraldBrickPrefab;
      default:
        throw new UnityException("Non-handled graphic for bricktype '" + type + "'");
    }
  }
}
