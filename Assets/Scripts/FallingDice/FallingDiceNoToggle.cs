using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDiceNoToggle : MonoBehaviour
{

    private static int _diceNumber = 1;
    public Sprite[] _diceSprites;
    private SpriteRenderer _diceSpriteRenderer;
    private bool _switchActive = false;

    private void Awake()
    {
        _diceSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _diceSpriteRenderer.sprite = _diceSprites[0];
    }

    public void RandomNumber()
    {
        StartCoroutine(PlayParticleSystem());
        var _randomNo = Random.Range(1, 7);
        _diceNumber = _randomNo;
        _diceSpriteRenderer.sprite = _diceSprites[_randomNo-1];
    }

    IEnumerator PlayParticleSystem()
    {
        _switchActive = true;
        yield return new WaitForSeconds(Random.Range(0.5f,3f));
        _switchActive = false;
    }

    private void Update()
    {
        if (!_switchActive)
        {
            RandomNumber();
        }
    }
    public int GetDiceNo()
    {
        return _diceNumber;
    }
}
