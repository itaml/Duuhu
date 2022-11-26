using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject knife1;
    public GameObject knife2;
    public GameObject knife3;
    public GameObject knife_tp1;
    public GameObject knife_tp2;
    public GameObject knife_tp3;
    public GameObject knife_toxic1;
    public GameObject knife_toxic2;
    public GameObject knife_toxic3;
    public Text Score;
    public GameObject panel;
    public AudioClip death;

    public Player player_class;
    public Buttons buttons_class;

    private int status;
    public bool gameOver;
    public bool gameStart;
    public float timeKef;
    public float milsec;
    public const float sec = 1;
    public int seconds;
    public bool boom;

    void Start()
    {
        gameOver = false;
        gameStart = false;
    }


    void Update()
    {
        if (gameStart == true)
        {     
            Score.enabled = true;
            Score.text = "" + player_class.gem;
        }
        if (player_class.alive == false)
        {
            gameOver = true;
        }
        if (boom == true) { GetComponent<AudioSource>().PlayOneShot(death); }
        boom = false;
    }

    private void FixedUpdate()
    {
        if (gameStart == true)
        {
            if (milsec <= sec)
            {
                milsec += Time.deltaTime;
            }
            if (milsec >= sec)
            {
                milsec = 0;
                seconds++;
            }
        }
        if (gameOver == true && gameStart == true)
        {
            panel.SetActive(true);
        }

        if(seconds != 0 && milsec % timeKef == 0 && gameStart == true && gameOver != true)
        {

            if (seconds % 5 == 0 && status >3)
            {
                int rand = Random.Range(1, 4);
                if (rand == 1) { Create(knife3); }
                if (rand == 2) { Create_Tp(knife_tp3); }
                if (rand == 3) { Create(knife_toxic3); }
            }

            if(seconds % 4 == 0 && status > 2)
            {
                int rand = Random.Range(1, 7);
                if (rand == 1) { Create(knife2); }
                if (rand == 2) { Create_Tp(knife_tp2); }
                if (rand == 3) { Create(knife_toxic2); }
                if (rand == 4) { Create(knife3); }
                if (rand == 5) { Create_Tp(knife_tp3); }
                if (rand == 6) { Create(knife_toxic3); }
            }
            if (seconds % 3 == 0 && status > 1)
            {
                int rand = Random.Range(1, 7);
                if (rand == 1) { Create(knife1); }
                if (rand == 2) { Create(knife_toxic1); }
                if (rand == 3) { Create_Tp(knife_tp1); }
                if (rand == 4) { Create(knife2); }
                if (rand == 5) { Create(knife_toxic2); }
                if (rand == 6) { Create_Tp(knife_tp2); }
            }
            if (seconds % 2 == 0 && status > 0)
            {
                int rand = Random.Range(1, 7);
               if(rand != 4 || rand != 5 || rand != 6) { Create(knife1); }
               if (rand == 4 || rand == 5) { Create_Tp(knife_tp1); }
            }
        }


        if (gameStart == true)
        {

            if (player_class.gem <= 80)
            {
                timeKef = 0.20f;
                status = 4;
            }

            if (player_class.gem <= 40)
            {
                timeKef = 0.25f;
                status = 3;
            }

            if (player_class.gem <= 20)
            {
                timeKef = 0.33f;
                status = 2;
            }

            if (player_class.gem <= 10)
            {
                timeKef = 0.5f;
                status = 1;
            }
        }
    }

    public void Create(GameObject a)
    {
        Instantiate(a, new Vector3(Random.Range(-5.66f, 5.26f), 14.48884f, -0.39946f), Quaternion.Euler(0f, 0f, 0f));
    }
    public void Create_Tp(GameObject a)
    {
        if (Random.Range(1, 3) == 1) { Instantiate(a, new Vector3(Random.Range(-5.16f, -3.07f), 14.48884f, -0.39946f), Quaternion.Euler(0f, 0f, 0f)); }
        else { Instantiate(a, new Vector3(Random.Range(4.13f, 5.93f), 14.48884f, -0.39946f), Quaternion.Euler(0f, 0f, 0f)); }
    }

}
