using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FallingDice"))
        {
            if(gameObject.GetComponent<PlayerDiceNoToggle>().GetDiceNo() == collision.gameObject.GetComponent<FallingDiceNoToggle>().GetDiceNo())
            {
                print("heal");
            }
            else
            {
                print("take dmg");
            }
        }
    }
}
