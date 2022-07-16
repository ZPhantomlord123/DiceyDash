using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private PlayerHealthUI _playerHealthUI;
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
                        break;
                    case 2:
                        _playerHealthUI.Heal(15);
                        break;
                    case 3:
                        _playerHealthUI.Heal(20);
                        break;
                    case 4:
                        _playerHealthUI.Heal(25);
                        break;
                    case 5:
                        _playerHealthUI.Heal(30);
                        break;
                    case 6:
                        _playerHealthUI.Heal(40);
                        break;

                }
                print("heal");
            }
            else
            {
                switch (collision.gameObject.GetComponent<FallingDiceNoToggle>().GetDiceNo())
                {
                    case 1:
                        _playerHealthUI.TakeDamage(10);
                        break;
                    case 2:
                        _playerHealthUI.TakeDamage(15);
                        break;
                    case 3:
                        _playerHealthUI.TakeDamage(20);
                        break;
                    case 4:
                        _playerHealthUI.TakeDamage(25);
                        break;
                    case 5:
                        _playerHealthUI.TakeDamage(30);
                        break;
                    case 6:
                        _playerHealthUI.TakeDamage(40);
                        break;
                }
            }
        }
    }
}
