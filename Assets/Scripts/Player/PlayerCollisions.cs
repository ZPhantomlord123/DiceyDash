using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private PlayerHealthUI _playerHealthUI;
    [SerializeField] private ScoreSystem _scoreSystem;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FallingDice"))
        {
            if(gameObject.GetComponent<PlayerDiceNoToggle>().GetDiceNo() == collision.gameObject.GetComponent<FallingDiceNoToggle>().GetDiceNo())
            {
                switch (collision.gameObject.GetComponent<FallingDiceNoToggle>().GetDiceNo())
                {
                    case 1:
                        _playerHealthUI.Heal(10);
                        _scoreSystem.IncrementScore(10);
                        break;
                    case 2:
                        _playerHealthUI.Heal(15);
                        _scoreSystem.IncrementScore(150);
                        break;
                    case 3:
                        _playerHealthUI.Heal(20);
                        _scoreSystem.IncrementScore(200);
                        break;
                    case 4:
                        _playerHealthUI.Heal(25);
                        _scoreSystem.IncrementScore(250);
                        break;
                    case 5:
                        _playerHealthUI.Heal(30);
                        _scoreSystem.IncrementScore(300);
                        break;
                    case 6:
                        _playerHealthUI.Heal(50);
                        _scoreSystem.IncrementScore(500);
                        break;

                }
                print("heal"+ gameObject.GetComponent<PlayerDiceNoToggle>().GetDiceNo() + "," + collision.gameObject.GetComponent<FallingDiceNoToggle>().GetDiceNo());
            }
            else
            {
                switch (collision.gameObject.GetComponent<FallingDiceNoToggle>().GetDiceNo())
                {
                    case 1:
                        _playerHealthUI.TakeDamage(10);
                        _scoreSystem.DamageContext(10);
                        break;
                    case 2:
                        _playerHealthUI.TakeDamage(15);
                        _scoreSystem.DamageContext(15);
                        break;
                    case 3:
                        _playerHealthUI.TakeDamage(20);
                        _scoreSystem.DamageContext(20);
                        break;
                    case 4:
                        _playerHealthUI.TakeDamage(25);
                        _scoreSystem.DamageContext(25);
                        break;
                    case 5:
                        _playerHealthUI.TakeDamage(30);
                        _scoreSystem.DamageContext(30);
                        break;
                    case 6:
                        _playerHealthUI.TakeDamage(40);
                        _scoreSystem.DamageContext(40);
                        break;
                }
            }
        }
    }
}
