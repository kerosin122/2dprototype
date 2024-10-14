using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shade : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }



   public void Timer(float time)
{
    StartCoroutine(RestoreTransparency(time));
}

private IEnumerator RestoreTransparency(float time)
{
    // Запоминаем начальную прозрачность
    float initialAlpha = spriteRenderer.color.a;
    
    
    Color color = spriteRenderer.color;
    color.a = 0.5f;
    spriteRenderer.color = color;
    
    // Ждем указанное время
    yield return new WaitForSeconds(time);
    
    // Возвращаем прозрачность к начальному значению
    color.a = initialAlpha;
    spriteRenderer.color = color;
}

  
}