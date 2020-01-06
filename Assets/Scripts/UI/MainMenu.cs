
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{


    [SerializeField] RectTransform LevelSelect;
  public void PlayBtn()
    {
        LevelSelect.DOAnchorPos(Vector2.zero, 0.25f);
        transform.GetComponent<RectTransform>().DOAnchorPos(new Vector2(-1500f, 0), 0.25f);
    }
}
