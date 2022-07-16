using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _playerMoveSpeed;
    [SerializeField] private float _playerJumpPower;
    private Rigidbody2D _playerRb;

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Jump()
    {
        _playerRb.velocity = (new Vector2(0,1) *_playerJumpPower);
    }

    private void Move()
    {
        var _x = Input.GetAxisRaw("Horizontal");
        _playerRb.velocity = new Vector3(_x * _playerMoveSpeed, _playerRb.velocity.y, 0);
    }
}
