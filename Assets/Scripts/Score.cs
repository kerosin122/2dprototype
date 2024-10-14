using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textMeshPro; // Ссылка на TextMeshPro, в котором будет отображаться количество очков
    public TextMeshProUGUI textMeshPro
    {
        get
        {
            return _textMeshPro;

        }
        set
        {
            _textMeshPro.text = value.text;

        }
    }

    [SerializeField]
    private int _score = 0;
    public int score
    {
        get { return _score; }
        set { _score = value; }
    }
    public void ScoreChange(string text)

    {
        textMeshPro.text = text;

    }


}
