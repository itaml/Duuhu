using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Player player_class;

    public int money;
    public Text Money_Score1;
    public Text Money_Score2;
    public Text Armor_Score;
    public AudioClip pick_audio2;
    public int scale_cost, x2_cost,speed_cost; public Text scale_cost_t, x2_cost_t, speed_cost_t;
    public GameObject star1, star2, star3, star4, star5, sta1, sta2, sta3, sta4, sta5, st1, st2, st3, st4, st5;
    public int has_2_x;
    public int has_scale;
    public int has_speed;
    public bool pressed;


    void Start()
    {
        if(PlayerPrefs.HasKey("scale") == false) { has_scale = 1; PlayerPrefs.SetInt("scale", has_scale); }
        if(PlayerPrefs.HasKey("x_2") == false) { has_2_x = 1; PlayerPrefs.SetInt("x_2", has_2_x); }
        if(PlayerPrefs.HasKey("speed") == false) { has_speed = 1; PlayerPrefs.SetInt("speed", has_speed); }
    }

    private void Update()
    {

        pressed = false;
        if (PlayerPrefs.GetInt("money") < 0) { PlayerPrefs.SetInt("money", 0); }

        if (PlayerPrefs.HasKey("money"))
        {
            money += PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", money);
        }
        else
        {
            PlayerPrefs.SetInt("money", money);
        }

        Money_Score1.text = "" + PlayerPrefs.GetInt("money");
        Money_Score2.text = "" + PlayerPrefs.GetInt("money");
        Armor_Score.text = "" + PlayerPrefs.GetInt("armor");
        player_class.armor = 0;
        money = 0;

        if(PlayerPrefs.GetInt("x_2") == 1) { x2_cost_t.text = "250"; }
        if (PlayerPrefs.GetInt("x_2") == 2) { x2_cost_t.text = "500"; sta1.SetActive(true); }
        if (PlayerPrefs.GetInt("x_2") == 3) { x2_cost_t.text = "1000"; sta1.SetActive(true); sta2.SetActive(true); }
        if (PlayerPrefs.GetInt("x_2") == 4) { x2_cost_t.text = "2000"; sta1.SetActive(true); sta2.SetActive(true); sta3.SetActive(true);  }
        if (PlayerPrefs.GetInt("x_2") == 5) { x2_cost_t.text = "4000"; sta1.SetActive(true); sta2.SetActive(true); sta3.SetActive(true); sta4.SetActive(true);  }
        if (PlayerPrefs.GetInt("x_2") == 6) { x2_cost_t.text = ""; sta1.SetActive(true); sta2.SetActive(true); sta3.SetActive(true); sta4.SetActive(true); sta5.SetActive(true); }

        if (PlayerPrefs.GetInt("scale") == 1) { scale_cost_t.text = "250"; }
        if (PlayerPrefs.GetInt("scale") == 2) { scale_cost_t.text = "500"; star1.SetActive(true); }
        if (PlayerPrefs.GetInt("scale") == 3) { scale_cost_t.text = "1000"; star1.SetActive(true); star2.SetActive(true);  }
        if (PlayerPrefs.GetInt("scale") == 4) { scale_cost_t.text = "2000"; star1.SetActive(true); star2.SetActive(true); star3.SetActive(true);  }
        if (PlayerPrefs.GetInt("scale") == 5) { scale_cost_t.text = "4000"; star1.SetActive(true); star2.SetActive(true); star3.SetActive(true); star4.SetActive(true);  }
        if (PlayerPrefs.GetInt("scale") == 6) { scale_cost_t.text = ""; star1.SetActive(true); star2.SetActive(true); star3.SetActive(true); star4.SetActive(true); star5.SetActive(true); }

        if (PlayerPrefs.GetInt("speed") == 1) { speed_cost_t.text = "250"; }
        if (PlayerPrefs.GetInt("speed") == 2) { speed_cost_t.text = "500"; st1.SetActive(true); }
        if (PlayerPrefs.GetInt("speed") == 3) { speed_cost_t.text = "1000"; st1.SetActive(true); st2.SetActive(true); }
        if (PlayerPrefs.GetInt("speed") == 4) { speed_cost_t.text = "2000"; st1.SetActive(true); st2.SetActive(true); st3.SetActive(true); }
        if (PlayerPrefs.GetInt("speed") == 5) { speed_cost_t.text = "4000"; st1.SetActive(true); st2.SetActive(true); st3.SetActive(true); st4.SetActive(true); }
        if (PlayerPrefs.GetInt("speed") == 6) { speed_cost_t.text = ""; st1.SetActive(true); st2.SetActive(true); st3.SetActive(true); st4.SetActive(true); st5.SetActive(true); }
    }

    public void X2Up()
    {
        if (PlayerPrefs.HasKey("x_2"))
        { 
            if (PlayerPrefs.GetInt("x_2") == 1 && PlayerPrefs.GetInt("money") >= 250 && pressed == false) { money -= 250; has_2_x = 2; PlayerPrefs.SetInt("x_2", has_2_x); pressed = true; GetComponent<AudioSource>().PlayOneShot(pick_audio2); }
            if (PlayerPrefs.GetInt("x_2") == 2 && PlayerPrefs.GetInt("money") >= 500 && pressed == false) { money -= 500; has_2_x = 3; PlayerPrefs.SetInt("x_2", has_2_x); pressed = true; GetComponent<AudioSource>().PlayOneShot(pick_audio2); }
            if (PlayerPrefs.GetInt("x_2") == 3 && PlayerPrefs.GetInt("money") >= 1000 && pressed == false) { money -= 1000; has_2_x = 4; PlayerPrefs.SetInt("x_2", has_2_x); pressed = true; GetComponent<AudioSource>().PlayOneShot(pick_audio2); }
            if (PlayerPrefs.GetInt("x_2") == 4 && PlayerPrefs.GetInt("money") >= 2000 && pressed == false) { money -= 2000; has_2_x = 5; PlayerPrefs.SetInt("x_2", has_2_x); pressed = true; GetComponent<AudioSource>().PlayOneShot(pick_audio2); }
            if (PlayerPrefs.GetInt("x_2") == 5 && PlayerPrefs.GetInt("money") >= 4000 && pressed == false) { money -= 4000; has_2_x = 6; PlayerPrefs.SetInt("x_2", has_2_x); pressed = true; GetComponent<AudioSource>().PlayOneShot(pick_audio2); }
        }

    }

    public void ScaleUp()
    {
        if (PlayerPrefs.HasKey("scale"))
        {
            if (PlayerPrefs.GetInt("scale") == 1 && PlayerPrefs.GetInt("money") >= 250 && pressed == false) { money -= 250; has_scale = 2; PlayerPrefs.SetInt("scale", has_scale); pressed = true; GetComponent<AudioSource>().PlayOneShot(pick_audio2); }
            if (PlayerPrefs.GetInt("scale") == 2 && PlayerPrefs.GetInt("money") >= 500 && pressed == false) { money -= 500; has_scale = 3; PlayerPrefs.SetInt("scale", has_scale); pressed = true; GetComponent<AudioSource>().PlayOneShot(pick_audio2); }
            if (PlayerPrefs.GetInt("scale") == 3 && PlayerPrefs.GetInt("money") >= 1000 && pressed == false) { money -= 1000; has_scale = 4; PlayerPrefs.SetInt("scale", has_scale); pressed = true; GetComponent<AudioSource>().PlayOneShot(pick_audio2); }
            if (PlayerPrefs.GetInt("scale") == 4 && PlayerPrefs.GetInt("money") >= 2000 && pressed == false) { money -= 2000; has_scale = 5; PlayerPrefs.SetInt("scale", has_scale); pressed = true; GetComponent<AudioSource>().PlayOneShot(pick_audio2); }
            if (PlayerPrefs.GetInt("scale") == 5 && PlayerPrefs.GetInt("money") >= 4000 && pressed == false) { money -= 4000; has_scale = 6; PlayerPrefs.SetInt("scale", has_scale); pressed = true; GetComponent<AudioSource>().PlayOneShot(pick_audio2); }
        }
    }

    public void SpeedUp()
    {
        if (PlayerPrefs.HasKey("speed"))
        {
            if (PlayerPrefs.GetInt("speed") == 1 && PlayerPrefs.GetInt("money") >= 250 && pressed == false) { money -= 250; has_speed = 2; PlayerPrefs.SetInt("speed", has_speed); pressed = true; GetComponent<AudioSource>().PlayOneShot(pick_audio2); }
            if (PlayerPrefs.GetInt("speed") == 2 && PlayerPrefs.GetInt("money") >= 500 && pressed == false) { money -= 500; has_speed = 3; PlayerPrefs.SetInt("speed", has_speed); pressed = true; GetComponent<AudioSource>().PlayOneShot(pick_audio2); }
            if (PlayerPrefs.GetInt("speed") == 3 && PlayerPrefs.GetInt("money") >= 1000 && pressed == false) { money -= 1000; has_speed = 4; PlayerPrefs.SetInt("speed", has_speed); pressed = true; GetComponent<AudioSource>().PlayOneShot(pick_audio2); }
            if (PlayerPrefs.GetInt("speed") == 4 && PlayerPrefs.GetInt("money") >= 2000 && pressed == false) { money -= 2000; has_speed = 5; PlayerPrefs.SetInt("speed", has_speed); pressed = true; GetComponent<AudioSource>().PlayOneShot(pick_audio2); }
            if (PlayerPrefs.GetInt("speed") == 5 && PlayerPrefs.GetInt("money") >= 4000 && pressed == false) { money -= 4000; has_speed = 6; PlayerPrefs.SetInt("speed", has_speed); pressed = true; GetComponent<AudioSource>().PlayOneShot(pick_audio2); }
        }
    }

    public void ArmorBuy()
    {  
        if(PlayerPrefs.GetInt("money") >= 200) { GetComponent<AudioSource>().PlayOneShot(pick_audio2); money -= 200;player_class.armor++; } 
    }

}
