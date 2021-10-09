using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] private Transform _enemy;


    private void Update()
    {
        transform.position = new Vector3(transform.position.x, _enemy.position.y, transform.position.z);
    }
}
