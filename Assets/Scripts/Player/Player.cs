using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float visibleHealth = 1f;

    private float _regenerationPauseTimer;

    private void Update()
    {
        
    }


    private void playerSeen()
    {
        visibleHealth -= (Time.deltaTime/3);
        if (visibleHealth <= 0)
        {
            //restart
        }
    }


}
