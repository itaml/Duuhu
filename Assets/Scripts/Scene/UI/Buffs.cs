using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    public GameObject x2_b;
    public GameObject scale_b;
    public GameObject speed_b;

    public Spawner spawner_class;
    public Player player_class;
    public Shop shop_class;

    public bool buff_active;
    public float timer_buff_x2, kd_buff_x2, timer_buff_speed, kd_buff_speed, timer_buff_scale, kd_buff_scale;
    
    void Start()
    { }

    
    void Update()
    {
        if(PlayerPrefs.GetInt("x_2") == 1) { kd_buff_x2 = 5; }
        if (PlayerPrefs.GetInt("x_2") == 2) { kd_buff_x2 = 8; }
        if (PlayerPrefs.GetInt("x_2") == 3) { kd_buff_x2 = 11; }
        if (PlayerPrefs.GetInt("x_2") == 4) { kd_buff_x2 = 14; }
        if (PlayerPrefs.GetInt("x_2") == 5) { kd_buff_x2 = 16; }
        if (PlayerPrefs.GetInt("x_2") == 6) { kd_buff_x2 = 20; }

        if (PlayerPrefs.GetInt("scale") == 1) { kd_buff_scale = 5; }
        if (PlayerPrefs.GetInt("scale") == 2) { kd_buff_scale = 8; }
        if (PlayerPrefs.GetInt("scale") == 3) { kd_buff_scale = 11; }
        if (PlayerPrefs.GetInt("scale") == 4) { kd_buff_scale = 14; }
        if (PlayerPrefs.GetInt("scale") == 5) { kd_buff_scale = 16; }
        if (PlayerPrefs.GetInt("scale") == 6) { kd_buff_scale = 20; }

        if (PlayerPrefs.GetInt("speed") == 1) { kd_buff_speed = 5; }
        if (PlayerPrefs.GetInt("speed") == 2) { kd_buff_speed = 8; }
        if (PlayerPrefs.GetInt("speed") == 3) { kd_buff_speed = 11; }
        if (PlayerPrefs.GetInt("speed") == 4) { kd_buff_speed = 14; } 
        if (PlayerPrefs.GetInt("speed") == 5) { kd_buff_speed = 16; }
        if (PlayerPrefs.GetInt("speed") == 6) { kd_buff_speed = 20; }

        if (spawner_class.gameOver == true) 
        { 
            x2_b.SetActive(false);
            scale_b.SetActive(false);
            speed_b.SetActive(false);
        }


            if (timer_buff_x2 <= kd_buff_x2) //таймер действия бафа х2
        {
            timer_buff_x2 += Time.deltaTime;
        }
        if (timer_buff_x2 >= kd_buff_x2)
        {
            timer_buff_x2 = 0;
            if (player_class.kef == 2) { player_class.kef = 1; x2_b.SetActive(false); } 
        }


        if (timer_buff_scale <= kd_buff_scale) //таймеп бафа уменьшения
        {
            timer_buff_scale += Time.deltaTime;
        }
        if (timer_buff_scale >= kd_buff_scale)
        {
            timer_buff_scale = 0;
            if (player_class.player.transform.localScale != new Vector3(0.3340826f, 0.3340826f, 0.3340826f))
            { player_class.player.transform.localScale = new Vector3(0.3340826f, 0.3340826f, 0.3340826f); scale_b.SetActive(false); }
        }

        if (timer_buff_speed <= kd_buff_speed) //таймеп бафа скорости
        {
            timer_buff_speed += Time.deltaTime;
        }
        if (timer_buff_speed >= kd_buff_speed)
        {
            timer_buff_speed = 0;
            if (spawner_class.gameStart == true) { player_class.speed = 6; speed_b.SetActive(false); }
        }


    }

    public void X2 ()
    {
            x2_b.SetActive(false);
            buff_active = false;
            player_class.kef += 1; timer_buff_x2 = 0;
    }

    public void Speed()
    {
           player_class.speed += 2; timer_buff_speed = 0;
    }

    public void Scale()
    {
            scale_b.SetActive(false);
            buff_active = false;
            player_class.player.transform.localScale = player_class.player.transform.localScale / 1.5f;
            timer_buff_scale = 0;
    }
}