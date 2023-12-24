using UnityEngine;

public class Character_Select : MonoBehaviour
{
    public GameObject[] uiElementsToHide; // 숨길 UI들 (Inspector에서 배열로 할당)
    public GameObject[] uiElementsToShow; // 나타낼 UI들 (Inspector에서 배열로 할당)


    public void OnButtonClicked()
    {
        // 숨길 UI들을 비활성화합니다.
        if (uiElementsToHide != null)
        {
            foreach (GameObject ui in uiElementsToHide)
            {
                if (ui != null)
                    ui.SetActive(false);
            }
        }

        // 나타낼 UI들을 활성화합니다.
        if (uiElementsToShow != null)
        {
            foreach (GameObject ui in uiElementsToShow)
            {
                if (ui != null)
                    ui.SetActive(true);
            }
        }
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
    }
}
