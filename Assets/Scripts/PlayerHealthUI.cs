using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private float _playerHealth = 100f;
    [SerializeField] private TextMeshProUGUI _playerHealthGUIValue;
    [SerializeField] private Image _playerHealthGUI;

    private void Start()
    {
        _playerHealthGUIValue.text = _playerHealth + "%";
        _playerHealthGUI.fillAmount = (int)_playerHealth;
    }

    public void TakeDamage(float amount)
    {
        _playerHealth -= amount;
        _playerHealthGUIValue.text = _playerHealth + "%";
        _playerHealthGUI.fillAmount = (int)_playerHealth;
        if (_playerHealth <= 0f)
        {
            _playerHealth = 0f;
            //GameOver
            Time.timeScale = 0f;
        }
        
    }

    public void Heal(float amount)
    {
        _playerHealth += amount;
        if (_playerHealth >= 100f)
        {
            _playerHealth = 100f;
        }
        _playerHealthGUIValue.text = _playerHealth + "%";
        _playerHealthGUI.fillAmount = (int)_playerHealth;
    }

    private void Update()
    {
        
    }
}
