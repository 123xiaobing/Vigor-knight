using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBoxControl : MonoBehaviour
{
    float showTime = 3f;//�ش̳��ֵ�ʱ��
    float disappearTime = 3f;//�ش���ʧ��ʱ��

    public GameObject[] sandBox; 

    float nowTime;
    private void Start()
    {
        nowTime = Time.time;
        
    }

    void Update()
    {
        if (Time.time - nowTime > showTime)
        {
            if (sandBox[0].activeSelf==true)
            {
                for (int i = 0; i < sandBox.Length; i++)
                {

                    sandBox[i].gameObject.SetActive(false);

                }
                nowTime += showTime;
            }
            else
            {
                for (int i = 0; i < sandBox.Length; i++)
                {
                    sandBox[i].gameObject.SetActive(true);
                }
                nowTime += disappearTime;
            }
                
            
            

        }


    }
}
