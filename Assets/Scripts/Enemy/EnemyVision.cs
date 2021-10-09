using UnityEngine;
using System.Collections;
using UnityEngine.AI;



public class EnemyVision : MonoBehaviour
{
    [SerializeField] private string _targetTag = "Player";

    [SerializeField] private int _rays = 8;
    [SerializeField] private int _distance = 15;

    [SerializeField] private float _angle = 35;

    [SerializeField] private Vector3 _offset;

    [SerializeField] private Transform _target;


    void Start()
    {
        _target = GameObject.FindGameObjectWithTag(_targetTag).transform;
    }

    bool GetRaycast(Vector3 dir)
    {
        bool result = false;
        RaycastHit hit = new RaycastHit();
        Vector3 pos = transform.position + _offset;
        if (Physics.Raycast(pos, dir, out hit, _distance))
        {
            if (hit.transform == _target)
            {
                result = true;
                Debug.DrawLine(pos, hit.point, Color.green);
            }
            else
            {
                Debug.DrawLine(pos, hit.point, Color.blue);
            }
        }
        else
        {
            Debug.DrawRay(pos, dir * _distance, Color.red);
        }
        return result;
    }

    bool RayToScan()
    {
        bool result = false;
        bool a = false;
        bool b = false;
        float j = 0;
        for (int i = 0; i < _rays; i++)
        {
            var x = Mathf.Sin(j);
            var y = Mathf.Cos(j);

            j += _angle * Mathf.Deg2Rad / _rays;

            Vector3 dir = transform.TransformDirection(new Vector3(x, 0, y));
            if (GetRaycast(dir)) a = true;

            if (x != 0)
            {
                dir = transform.TransformDirection(new Vector3(-x, 0, y));
                if (GetRaycast(dir)) b = true;
            }
        }

        if (a || b) result = true;
        return result;
    }

    void Update()


    {
        if (Vector3.Distance(transform.position, _target.position) < _distance)
        {
            if (RayToScan())
            {
                // Контакт с целью
            }
        }
    }
}