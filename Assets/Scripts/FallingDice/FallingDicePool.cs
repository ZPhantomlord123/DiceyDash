using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDicePool : MonoBehaviour
{
    public static FallingDicePool _instance;
    [SerializeField] private List<GameObject> _fallingDicePool;
    [SerializeField] private GameObject _fallingDicePrefab;
    public int maxDice = 10;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _fallingDicePool = new List<GameObject>();
        for (int i = 0; i < maxDice; i++)
        {
            GameObject _diceInstance = Instantiate(_fallingDicePrefab);
            _diceInstance.SetActive(false);
            _fallingDicePool.Add(_diceInstance);
        }
    }

    public GameObject GetDice()
    {
        for (int i = 0; i < maxDice; i++)
        {
            if (!_fallingDicePool[i].activeInHierarchy)
            {
                _fallingDicePool[i].SetActive(true);
                return _fallingDicePool[i];
            }
        }
        return null;
    }
}
