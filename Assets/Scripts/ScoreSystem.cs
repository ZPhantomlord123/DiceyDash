using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    private int _score = 0;
    private TextMeshProUGUI _scoreUI;
    [SerializeField] private TextMeshProUGUI _scoreCollisionContext;
    [SerializeField] private TextMeshProUGUI _dmgContext;

    private void Start()
    {
        _score = 0;
        _scoreUI = GetComponent<TextMeshProUGUI>();
    }

    public void IncrementScore(int amount)
    {
        StartCoroutine(ShowDuration(amount, Color.green));
        _score += amount;
        _scoreUI.text = _score.ToString();
    }

    public void DamageContext(int amount)
    {
        StartCoroutine(ShowDuration(amount, Color.red));
    }

    IEnumerator ShowDuration(int amount,Color c)
    {
        if (c == Color.green)
        {
            _scoreCollisionContext.text = "+" + amount.ToString();
            _scoreCollisionContext.color = c;
            _dmgContext.text = "+" + ((int)(amount/10)).ToString();
            _dmgContext.color = c;
        }
        else
        {
            _dmgContext.text = "-" + amount.ToString();
            _dmgContext.color = c;
        }
        yield return new WaitForSeconds(0.5f);
        _scoreCollisionContext.text = "";
        _dmgContext.text = "";
    }
}
