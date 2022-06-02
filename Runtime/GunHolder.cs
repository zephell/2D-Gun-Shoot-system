using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolder : MonoBehaviour
{
    [SerializeField] private Gun gun;
    
    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 dir = ((Vector2)cam.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position).normalized;
            gun.Shoot(gameObject, transform.position, dir);
        }
    }
}
