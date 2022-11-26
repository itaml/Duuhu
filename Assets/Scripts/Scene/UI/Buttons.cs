using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Player player_class;
    public Spawner spawner_class;

    public Transform player;
    public GameObject Play_Button;
    public GameObject Stop_Button;
    public GameObject Strelki;
    public Shop shop_class;

    public bool shop_b_activated;
    public bool y_can_swipe;

    public int Dead = 0;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if((Mathf.Abs(eventData.delta.x)) > (Mathf.Abs(eventData.delta.y)) && player_class.solid == true && spawner_class.gameStart == false && y_can_swipe == true)
        {
            y_can_swipe = false;
            if (eventData.delta.x > 0) { player_class.speed = 6; player_class.check = true;  }
            else { player_class.speed = 6; player_class.check = false; }
        }
        else
        {
            if(eventData.delta.y > 0) { }
            else { }
        }
    }

    public void OnDrag(PointerEventData eventData)
    { }

    void Start()
    {
        player_class.check = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("dead") == 1) { Strelki.SetActive(true); }
        else { Strelki.SetActive(false); }
        if (spawner_class.gameOver == true) { Stop_Button.SetActive(false); }
    }


    public void Restart()
    {
        SceneManager.LoadScene("Duuhu");
        if (PlayerPrefs.HasKey("dead")) { }
        else {
            Dead = 1;
            PlayerPrefs.SetInt("dead", Dead);
        }
    }

    public void Reward(string placement)
    {
        if(placement == "coin")
        {
            player_class.gem += 500;
            shop_class.money += 500;
        }
    }

    public void Continue()
    {
        if (PlayerPrefs.GetInt("money") >= 50) {  }
    }

    public void Play()
    {
        if (spawner_class.gameStart == false && player_class.stay == false && PlayerPrefs.GetInt("dead") != 1)
        {
            player_class.speed += 6;
            Play_Button.SetActive(false);
            spawner_class.gameStart = true;
            if (Random.Range(1, 3) == 1) { player_class.gem_1.SetActive(true); player_class.check = false; }
            else { player_class.gem_2.SetActive(true); player_class.check = true; }
        }
    }

    public void Save()
    {
    }

    public void Stop()
    {
        if(spawner_class.gameStart == true) player_class.Stop();
    }


}
