using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDiceNoToggle : MonoBehaviour
{

    public int _diceNumber = 1;
    public Sprite[] _diceSprites;
    private SpriteRenderer _diceSpriteRenderer;
    private bool _switchActive = false;
    private int _randomNo = 1;
    private int _tempNo=1;

    private void Awake()
    {
        _diceSpriteRenderer = GetComponent<SpriteRenderer>();
        _randomNo = 1;
        _diceNumber = 1;
        RandomNumber();
    }

    public void RandomNumber()
    {
        StartCoroutine(PlayParticleSystem());
        _randomNo = RandomRangeExcept(_tempNo);
        _diceNumber = _randomNo;
        _diceSpriteRenderer.sprite = _diceSprites[_randomNo-1];
    }

    private int RandomRangeExcept(int except)
    {
        int number;
        do
        {
            number = Random.Range(1, 7);
        } while (number == except);
        _tempNo = number;
        return number;
    }
    

    IEnumerator PlayParticleSystem()
    {
        _switchActive = true;
        yield return new WaitForSeconds(Random.Range(0.5f,3f));
        _switchActive = false;
    }

    public int GetDiceNo()
    {
        return _diceNumber;
    }
}
