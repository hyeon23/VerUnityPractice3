using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 direction;
    WaitForSeconds destroyBullet = new WaitForSeconds(5f);

    public void Shoot(Vector3 dir)
    {
        direction = dir;
        StartCoroutine(DestroyBulletCoroutine()); //Destroy(gameObject, 5f);
        
    }

    private void DestroyBullet()
    {
        ObjectPool.ReturnObject(this);
    }

    public IEnumerator DestroyBulletCoroutine()
    {
        yield return destroyBullet;
        DestroyBullet();
    }

    void Update()
    {
        transform.Translate(direction);
    }
}
