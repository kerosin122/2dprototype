using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField]
    private GameObject playerui;
    [SerializeField]
    private GameObject winui;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HeroController>() != null)
        {

            Time.timeScale = 0;
            playerui.SetActive(false);
            winui.SetActive(true);

        }
    }
}
