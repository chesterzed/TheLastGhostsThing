using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject Hero;

    [SerializeField] private float _speedCamera;
    [SerializeField] private float PosY;
    [SerializeField] private float PosZ;

    private Vector3 _targetPos;
    private Vector3 _distance;

    private void Start()
    {
        Hero = GameObject.FindGameObjectWithTag("Player");
        _targetPos = new Vector3(Hero.transform.position.x, Hero.transform.position.y + PosY, Hero.transform.position.z - PosZ);
        transform.position = _targetPos;
    }

    void Update()
    {

        _targetPos = new Vector3(Hero.transform.position.x, Hero.transform.position.y + PosY, Hero.transform.position.z - PosZ);
        if (transform.position != _targetPos)
            _distance = transform.position - _targetPos;
            transform.position = Vector3.MoveTowards(transform.position, _targetPos,_distance.magnitude *_speedCamera * Time.deltaTime);
            
    }
}