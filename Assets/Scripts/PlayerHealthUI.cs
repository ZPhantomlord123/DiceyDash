using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private float _playerHealth = 100f;
    [SerializeField] private TextMeshProUGUI _playerHealthGUIValue;
    [SerializeField] private Image _playerHealthGUI;
    [SerializeField] private GameObject _gameOverPanel;
    private void Start()
    {
        _playerHealth = 100f;
        _playerHealthGUIValue.text = _playerHealth + "%";
        _playerHealthGUI.fillAmount = (int)_playerHealth;
        _gameOverPanel.SetActive(false);
    }

    public void TakeDamage(float amount)
    {
        AudioManager.instance.Play("Hit",1f);
        _playerHealth -= amount;
        if (_playerHealth <= 0)
        {
            _playerHealth = 0;
        }
        _playerHealthGUIValue.text = _playerHealth + "%";
        _playerHealthGUI.fillAmount = _playerHealth/100;
        if (_playerHealth <= 0f)
        {
            _playerHealth = 0f;
            AudioManager.instance.Play("GameOver",1f);
            _gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }

    public void Heal(float amount)
    {
        AudioManager.instance.Play("Context",Random.Range(0.6f,1.2f));
        _playerHealth += amount;
        if (_playerHealth >= 100f)
        {
            _playerHealth = 100f;
        }
        _playerHealthGUIValue.text = _playerHealth + "%";
        _playerHealthGUI.fillAmount = _playerHealth/100;
    }

    private void Update()
    {
        if(Time.timeScale==0f && Input.GetKeyDown(KeyCode.Space))
        {
            _gameOverPanel.SetActive(false);
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
