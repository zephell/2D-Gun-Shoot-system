using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System;

[CreateAssetMenu(menuName = "Guns/BurstFireGun")]
public class BurstFireGun : Gun
{
    [SerializeField] private int bulletCount;
    [SerializeField] private float distBetween;

    public override async void Shoot(GameObject parent, Vector3 origin, Vector3 dir)
    {
        for (int i = 0; i < bulletCount; i++)
        {
            Recoil(parent, dir);
            InstantiateBullet(origin, dir);
            await Task.Delay(TimeSpan.FromSeconds(distBetween));
        }
    }
}
