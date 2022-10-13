using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Gun Parameters")]
    public GameObject bulletPrefab;
    public Transform bulletSpawnTransform;
    public float bulletSpeed = 50;
    public float bulletDestroyTime = 5; 

    public void Fire()
    {
        GameObject spawnedBullet = Instantiate(bulletPrefab, bulletSpawnTransform.position, bulletSpawnTransform.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = bulletSpeed * bulletSpawnTransform.forward;
        Destroy(spawnedBullet, bulletDestroyTime);
    }
}
