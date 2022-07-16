using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDiceCollisions : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
        }
        if(collision.gameObject.layer == 8)
        {
            this.gameObject.SetActive(false);
        }
    }
}
