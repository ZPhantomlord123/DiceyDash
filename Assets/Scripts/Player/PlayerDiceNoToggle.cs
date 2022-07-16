using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiceNoToggle : MonoBehaviour
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

    public void IncrementNumber()
    {
        StartCoroutine(PlayParticleSystem());
        if (_diceNumber < 6)
        {
            _diceNumber++;
            _diceSpriteRenderer.sprite = _diceSprites[_diceNumber-1];
        }
        else
        {
            _diceNumber = 1;
            _diceSpriteRenderer.sprite = _diceSprites[0];
        }
        print(_diceNumber);
    }

    public void DecrementNumber()
    {
        StartCoroutine(PlayParticleSystem());
        if (_diceNumber >1)
        {
            _diceNumber--;
            _diceSpriteRenderer.sprite = _diceSprites[_diceNumber-1];
        }
        else
        {
            _diceNumber = 6;
            _diceSpriteRenderer.sprite = _diceSprites[5];
        }
        print(_diceNumber);
    }

    IEnumerator PlayParticleSystem()
    {
        _switchActive = true;
        yield return new WaitForSeconds(0.5f);
        _switchActive = false;
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Vertical") == 1 && !_switchActive)
        {
            IncrementNumber();
        }
        else if(Input.GetAxisRaw("Vertical") == -1 && !_switchActive)
        {
            DecrementNumber();
        }
    }

    public int GetDiceNo()
    {
        return _diceNumber;
    }
}
