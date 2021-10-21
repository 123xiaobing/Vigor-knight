using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillcontrol : MonoBehaviour
{
    [SerializeField] float speed;
    public GameObject[] skill_1Balls;
    float skillStopTime1=4.5f;//BOSS第一个大招的间隔时间
    float nowTime1;//记录当前的时间

    public GameObject[] skill_2Balls;
    float skillStopTime2 =4.5f;
    float nowTime2;

    public GameObject[] skill_3Balls;
    float skillStopTime3 = 4.5f;
    float stopEachBall = 0.5f;//每个子弹发射后0.2s下一个子弹再发射
    float nowTime3;
    private void Start()
    {
        nowTime1 = Time.time;
        nowTime2 = Time.time+2.5f;
        nowTime3 = Time.time + 4f;
    }

    //生成BOSS时释放一次大招1
    //之后每4.5s再释放一次大招1

    //开始放第二个大招

    private void FixedUpdate()
    {
       //大招一
            for (int i = 0; i < 12; i++)//将大招发射出去
            {
                if (skill_1Balls[i])
                    skill_1Balls[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(30 * i) * speed, Mathf.Sin(30 * i) * speed);
            }
            if(Time.time-nowTime1>skillStopTime1)
            {
                for (int i = 0; i < 12; i++)
                {
                    if (skill_1Balls[i])
                    {
                        skill_1Balls[i].gameObject.SetActive(false);
                        skill_1Balls[i].gameObject.transform.position = transform.position;
                    }
                }
                for (int i = 0; i < 12; i++)//将大招发射出去
                {
                    skill_1Balls[i].gameObject.SetActive(true);
                    if (skill_1Balls[i])
                        skill_1Balls[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(30 * i) * speed, Mathf.Sin(+ 30 * i) * speed);
                }
                nowTime1 += skillStopTime1;
            }

        //大招二
        for (int i = 0; i < 12; i++)
        {
            if (skill_2Balls[i])
                skill_2Balls[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(25 + 30 * i) * speed, Mathf.Sin(25 + 30 * i) * speed);
        }
        if (Time.time - nowTime2 > skillStopTime2)
        {
            for (int i = 0; i < 12; i++)
            {
                if (skill_2Balls[i])
                {
                    skill_2Balls[i].gameObject.SetActive(false);
                    skill_2Balls[i].gameObject.transform.position = transform.position;
                }
            }
            for (int i = 0; i < 12; i++)//将大招发射出去
            {
                skill_2Balls[i].gameObject.SetActive(true);
                if (skill_2Balls[i])
                    skill_2Balls[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(25 + 30 * i) * speed, Mathf.Sin(25 + 30 * i) * speed);
            }
            nowTime2 += skillStopTime2;
        }


        //大招三
        for (int i = 0; i < 12; i++)
        {
            if (skill_3Balls[i])
                skill_3Balls[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(50 + 30 * i) * speed, Mathf.Sin(50 + 30 * i) * speed);
        }
        if (Time.time - nowTime3 > skillStopTime3)
        {
            for (int i = 0; i < 12; i++)
            {
                if (skill_3Balls[i])
                {
                    skill_3Balls[i].gameObject.SetActive(false);
                    skill_3Balls[i].gameObject.transform.position = transform.position;
                }
            }
            for (int i = 0; i < 12; i++)//将大招发射出去
            {
                skill_3Balls[i].gameObject.SetActive(true);
                if (skill_3Balls[i]) 
                {
                    if (Time.time - nowTime3 > skillStopTime3 + stopEachBall)
                    {
                        skill_3Balls[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(50 + 30 * i) * speed, Mathf.Sin(50 + 30 * i) * speed);
                        nowTime3 += stopEachBall;
                    }
                }
                    
            }
            nowTime3 += skillStopTime3;
        }

    }

}
