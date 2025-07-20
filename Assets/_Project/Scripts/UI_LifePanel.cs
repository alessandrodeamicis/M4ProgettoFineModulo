using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LifePanel : MonoBehaviour
{
    private Image _fillableLifeBar;

    private void Start()
    {
        GameObject lifeBarGameObject = GameObject.FindGameObjectWithTag("LifeBar");
        if (lifeBarGameObject != null)
        {
            _fillableLifeBar = lifeBarGameObject.GetComponent<Image>();
        }
    }
    public void UpdateGraphics(int currentHp, int maxHp)
    {
        _fillableLifeBar.fillAmount = (float)currentHp / maxHp;
    }
}
