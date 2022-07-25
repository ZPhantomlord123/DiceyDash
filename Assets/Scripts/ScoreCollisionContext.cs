using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCollisionContext : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ScoreContextText;

    public void ShowContext(int value)
    {
        StartCoroutine(ShowDuration(value));
    }

    IEnumerator ShowDuration(int value)
    {
        _ScoreContextText.text = value.ToString();
        yield return new WaitForSeconds(0.5f);
        _ScoreContextText.text = "";
    }
}
