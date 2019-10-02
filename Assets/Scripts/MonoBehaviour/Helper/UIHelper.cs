using UnityEngine;
using UnityEngine.UI;

public class UIHelper : MonoBehaviour
{
  [SerializeField]
  private Button level1Button;
  [SerializeField]
  private Button level2Button;
  [SerializeField]
  private Button level3Button;

  public void hideAllButtons()
  {
    level1Button.gameObject.SetActive(false);
    level2Button.gameObject.SetActive(false);
    level3Button.gameObject.SetActive(false);
  }
  public void showAllButtons()
  {
    level1Button.gameObject.SetActive(true);
    level2Button.gameObject.SetActive(true);
    level3Button.gameObject.SetActive(true);
  }
}