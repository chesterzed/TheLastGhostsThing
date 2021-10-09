using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMover _mover;

    private int _moveDirectionX;
    private int _moveDirectionZ;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            _moveDirectionZ = 1;
        else if (Input.GetKey(KeyCode.S))
            _moveDirectionZ = -1;
        else _moveDirectionZ = 0;

        if (Input.GetKey(KeyCode.D))
            _moveDirectionX = 1;
        else if (Input.GetKey(KeyCode.A))
            _moveDirectionX = -1;
        else _moveDirectionX = 0;

        _mover.Move(_moveDirectionX, _moveDirectionZ);


        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            _mover.playerVisiblity();
        }
    }
}
