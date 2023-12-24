using UnityEngine;

public class Character_Select : MonoBehaviour
{
    public GameObject[] uiElementsToHide; // ���� UI�� (Inspector���� �迭�� �Ҵ�)
    public GameObject[] uiElementsToShow; // ��Ÿ�� UI�� (Inspector���� �迭�� �Ҵ�)


    public void OnButtonClicked()
    {
        // ���� UI���� ��Ȱ��ȭ�մϴ�.
        if (uiElementsToHide != null)
        {
            foreach (GameObject ui in uiElementsToHide)
            {
                if (ui != null)
                    ui.SetActive(false);
            }
        }

        // ��Ÿ�� UI���� Ȱ��ȭ�մϴ�.
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
