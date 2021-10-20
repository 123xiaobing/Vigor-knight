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

    public float superSkillTime;//���ܳ���ʱ��
    public float superSkillIceTime;//������ȴʱ��
    public bool isSuperSkill=false;//����ʩ�д���
    public bool isIce=false;//����������ȴ
    float nowTime;//��ǰʱ��

    private void Start()
    {
        startTimeBtwShots = startTimeBtwShots_Normal;
    }

    private void Update()
    {

        transform.position = new Vector3(player.rb.position.x + 0.117f, player.rb.position.y - 0.189f, transform.position.z);

        SuperSkill();//����
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


    void SuperSkill()//����
    {
        if(Input.GetMouseButton(1))
        {
            //�����ͷ�
            if(!isSuperSkill)
            {
                isSuperSkill = true;
                nowTime = Time.time;
                startTimeBtwShots = startTimeBtwShots_Skill;
                Debug.Log("���������ͷ�");
                
            }
        }
        if (isSuperSkill)
        {
            if (Time.time - nowTime > superSkillTime)
            {
                startTimeBtwShots = startTimeBtwShots_Normal;

                Debug.Log("����������ȴ");

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
        Debug.Log("������ȴ����");
        isSuperSkill = false;
        isIce = false;
    }
}
