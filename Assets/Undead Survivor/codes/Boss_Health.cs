using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Goldmetal.UndeadSurvivor
{
    public class Boss_Health : MonoBehaviour
    {

        Slider mySlider;

        void Awake()
        {
            mySlider = GetComponent<Slider>();
        }

        void Update()
        {
            float curBossHealth = GameManager.instance.bossHealth;
            float maxBossHealth = GameManager.instance.maxbossHealth;
            mySlider.value = curBossHealth / maxBossHealth;
        }
    }
}
