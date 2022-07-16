using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDiceSpawner : MonoBehaviour
{
    public float frequency = 1f;
    private bool _cannotSpawn = false;
    private void SpawnDice()
    {
        if (!_cannotSpawn)
        {
            var _instance = FallingDicePool._instance.GetDice();
            _instance.transform.position = new Vector2(Random.Range(-2.42f,2.42f),4.5f);
            _instance.GetComponent<Rigidbody2D>().gravityScale = Random.Range(0.1f, 1.5f);
            StartCoroutine(Delay());
        }
        
    }

    IEnumerator Delay()
    {
        _cannotSpawn = true;
        yield return new WaitForSeconds(frequency);
        _cannotSpawn = false;
        frequency = Random.Range(0, 2) == 1 ? 0.5f : 1f;
    }

    private void Update()
    {
        if (!_cannotSpawn)
        {
            SpawnDice();
        }
        
    }
}
