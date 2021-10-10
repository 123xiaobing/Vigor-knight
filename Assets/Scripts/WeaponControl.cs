using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public playerControl player;
    public float offset;
    public GameObject bulletPrefab;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots;


    private void Update()
    {
       
        transform.position = new Vector3(player.rb.position.x+0.117f, player.rb.position.y-0.189f, transform.position.z);
        if (timeBtwShots <= 0)
        {
            if (isShooting())
            {
                Instantiate(bulletPrefab, shotPoint.position, transform.rotation);
                // bullet.GetComponent<bulletInit>().Shoot();
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        if (player.transform.localScale.x == 1) transform.localScale = new Vector3(1,1,1);
        if (player.transform.localScale.x == -1) transform.localScale = new Vector3(-1, -1, 1);
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        

    }

    bool isShooting()
    {
        bool shotting = false;
        if (Input.GetMouseButtonDown(0))
        {
            shotting = true;
        }
        return shotting;
    }

}
