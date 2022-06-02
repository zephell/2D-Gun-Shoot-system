using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : ScriptableObject
{
    public string gunName;
    public Vector2 originOffset;

    public GameObject bullet;
    public float bulletSpeed;
    public float discardForce;
    public virtual void Shoot(GameObject parent, Vector3 origin, Vector3 dir) { }

    public void Recoil(GameObject parent, Vector3 dir)
    {
        Rigidbody2D rb = parent.GetComponent<Rigidbody2D>();
        rb.AddForce(-dir * discardForce, ForceMode2D.Impulse);
    }

    public void InstantiateBullet(Vector3 origin, Vector3 dir)
    {
        Vector3 offsettedOrigin = origin + originOffset.y * dir + originOffset.x * -(Vector3)Vector2.Perpendicular(dir);
        Bullet newBullet = Instantiate(bullet, offsettedOrigin, Quaternion.LookRotation(Vector3.forward, dir)).GetComponent<Bullet>();
        newBullet.bulletSpeed = bulletSpeed;
        newBullet.dir = dir;
    }
}
