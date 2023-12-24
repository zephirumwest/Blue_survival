using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Goldmetal.UndeadSurvivor
{
    public class Boss : MonoBehaviour
    {
        public GameObject uiElementsToShow;
        public GameObject uiElementsToHide;

        void Update()
        {         
            if (GameManager.instance.bossSpawn)
                uiElementsToShow.SetActive(true);

            if (!GameManager.instance.bossSpawn)
                uiElementsToHide.SetActive(false);
        }
    }
}
