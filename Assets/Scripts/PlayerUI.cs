using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public playerControl player;

    [Header("UI")]
    public Image HealthPIC;
    public Image DefencePIC;
    public Image MagicPIC;

    public Text healthText;
    public Text defenceText;
    public Text magicText;


  
    void Update()
    {
        UIChange();
    }

    public void UIChange()
    {
        HealthPIC.fillAmount = (float)player.healthNum / (float)player.MaxHealth;
        
        healthText.text = player.healthNum.ToString() + "/" + player.MaxHealth.ToString();

        DefencePIC.fillAmount = (float)player.defenceNum / (float)player.MaxDefence;
        defenceText.text = player.defenceNum.ToString() + "/" + player.MaxDefence.ToString();

        MagicPIC.fillAmount = (float)player.magicNum /(float)player.MaxMagic;
        magicText.text = player.magicNum.ToString() + "/" + player.MaxMagic.ToString();
    }
}
