using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Image currentHealthbar;

    private float startPoint = 100;
    private float maxPoint = 100;

    public void Start()
    {
        updateBar();
    }


    private void updateBar()
    {
        float ratio = startPoint / maxPoint;
        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    public void TakeDamage(float damage){
        startPoint -= damage;
        if(startPoint < 0){
            startPoint = 0;
        }
        updateBar();
    }
}
