using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTwo : MonoBehaviour
{
    public playerControl player;
    public float offset;
    public GameObject bulletPrefab;
    public Transform shotPoint;

    private float timeBtwShots;

    float startTimeBtwShots;
    public float startTimeBtwShots_Normal;
    public float startTimeBtwShots_Skill;

    public float superSkillTime;//技能持续时间
    public float superSkillIceTime;//技能冷却时间
    public bool isSuperSkill=false;//正在施行大招
    public bool isIce=false;//大招正在冷却
    float nowTime;//当前时间

    private void Start()
    {
        startTimeBtwShots = startTimeBtwShots_Normal;
    }

    private void Update()
    {

        transform.position = new Vector3(player.rb.position.x + 0.117f, player.rb.position.y - 0.189f, transform.position.z);

        SuperSkill();//大招
        if (timeBtwShots <= 0)
        {
            if (isPistolShooting()&&player.magicNum>=2)
            {
                Instantiate(bulletPrefab, shotPoint.position, transform.rotation);
                player.magicNum -= 2;
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
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        if (player.transform.localScale.x == 1) transform.localScale = new Vector3(1, 1, 1);
        if (player.transform.localScale.x == -1) transform.localScale = new Vector3(-1, -1, 1);
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotZ + offset);




    }
    bool isPistolShooting()
    {
        bool shotting = false;
        if (Input.GetMouseButton(0))
        {
            shotting = true;
        }
        return shotting;
    }


    void SuperSkill()//技能
    {
        if(Input.GetMouseButton(1))
        {
            //技能释放
            if(!isSuperSkill)
            {
                isSuperSkill = true;
                nowTime = Time.time;
                startTimeBtwShots = startTimeBtwShots_Skill;
                Debug.Log("技能正在释放");
                
            }
        }
        if (isSuperSkill)
        {
            if (Time.time - nowTime > superSkillTime)
            {
                startTimeBtwShots = startTimeBtwShots_Normal;

                Debug.Log("技能正在冷却");

                if (!isIce)
                {
                    isIce = true;
                    Invoke("IceSkill", superSkillIceTime);
                    
                }
            }
           
        }
       
    }

    void IceSkill()
    {
        Debug.Log("技能冷却结束");
        isSuperSkill = false;
        isIce = false;
    }
}
