using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponOne: MonoBehaviour
{
    public playerControl player;
    public float offset;
    public GameObject bulletPrefab;
    public Transform shotPoint;

    private float timeBtwShots;

    public float startTimeBtwShots;

    public float rotZ;

    private void Update()
    {

        transform.position = new Vector3(player.rb.position.x + 0.117f, player.rb.position.y - 0.189f, transform.position.z);

        //if (isPistolShooting())
        //{
        //        //PoolManager.Release(bulletPrefab, shotPoint.position, transform.rotation);
        //GameObject bull= BulletsPool.bulletsPoolInstance.GetPooledObject();

        //bull.transform.position = shotPoint.position;
        //bull.transform.rotation = shotPoint.rotation;
        //timeBtwShots = startTimeBtwShots;
        //    }
        //ÊÖÇ¹Éä»÷
        if (timeBtwShots <= 0)
        {
            if (isPistolShooting())
            {
                Instantiate(bulletPrefab, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }
    public void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        if (player.transform.localScale.x == 1) transform.localScale = new Vector3(1, 1, 1);
        if (player.transform.localScale.x == -1) transform.localScale = new Vector3(-1, -1, 1);
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotZ + offset);

    }
    bool isPistolShooting()//ÊÖÇ¹Éä»÷
    {
        bool shotting = false;
        if (Input.GetMouseButton(0))
        {
            shotting = true;
        }
        return shotting;
    }
}
