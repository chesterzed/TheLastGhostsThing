using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float visibleHealth = 1f;

    [SerializeField] private Rigidbody rb;

    private bool _visible = true;


    private void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    private void FlipAX(bool fl)
    {
        GetComponent<SpriteRenderer>().flipX = fl;
    }

    public void Move(int directionX, int directionZ)
    {
        if (directionX < 0)
            FlipAX(true);
        else if (directionX > 0)
            FlipAX(false);
        rb.velocity = new Vector3(directionX * _moveSpeed, 0, directionZ * _moveSpeed);
    }

    public void playerUnSeen()
    {
        visibleHealth += (Time.deltaTime / 2);
    }

    public void playerVisiblity()
    {
        if (_visible)
        {
            visibleHealth = 1f;
        }
        else
        {
            visibleHealth = 0.3f;
        }
    }
}