using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject pl1; public GameObject pl2;
    public GameObject player;
    public Text Duuhu;
    new public Light light;
    public GameObject shop1;
    public GameObject shop2;
    public GameObject gem_1;
    public GameObject gem_2;
    public GameObject player_blood;
    public GameObject armor_effect;
    Rigidbody2D rb;
    public GameObject dead_body;
    public AudioClip pick_audio;

    public bool alive;
    public float speed;
    public bool check;
    public bool stop;
    public int gem;
    public bool stay;
    public bool solid;
    public int kef;
    public int armor;
    public bool armored;
    public bool left, right;
    public bool toxicity;
    public float timer, kd = 5;

    public Buffs buffs_class;
    public Buttons buttons_class;
    public Spawner spawner_class;
    public Shop shop_class;
    public Cumera cam_class;

    void Start()
    {
        light = GetComponentInChildren<Light>();
        kef = 1;
        alive = true;
        rb = GetComponent<Rigidbody2D>();
        player = gameObject;
    }


    void Update()
    {
        cam_class.enabled = true;
        if (spawner_class.gameStart == true)
        {
            Duuhu.enabled = false;
        }

        if(PlayerPrefs.GetInt("armor") != 0) { armored = true; light.color = Color.yellow; armor_effect.SetActive(true); armor_effect.transform.position = transform.position; }
        else {  armored = false; light.color = Color.white;armor_effect.SetActive(false); }

        if (PlayerPrefs.HasKey("armor"))
        {
            armor += PlayerPrefs.GetInt("armor");
            PlayerPrefs.SetInt("armor", armor);
        }
        else
        {
            PlayerPrefs.SetInt("armor", armor);
        }

        if (toxicity == true)
        {
            if (timer <= kd)
            {
                timer += Time.deltaTime;
            }
            if (timer >= kd)
            {
                timer = 0;
                for (float i = speed; i < 6; i++) { speed++; }
                toxicity = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (check == true) { rb.velocity = new Vector2(speed, rb.velocity.y); }
        if (check == false) { rb.velocity = new Vector2(-speed, rb.velocity.y); }
        if (stop == true) { rb.velocity = new Vector2(0, 0); }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject) { solid = true; }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Drop")
        {
            int random = Random.Range(1, 4);
            if (random == 1) { buffs_class.X2(); { buffs_class.x2_b.SetActive(true); } }
            else if (random == 2) { buffs_class.Scale(); buffs_class.scale_b.SetActive(true); }
            else if (random == 3) { buffs_class.Speed(); buffs_class.speed_b.SetActive(true); }
        }
        if (collision.gameObject.tag == "1")
        {
            gem_1.SetActive(false);
            gem_2.SetActive(true);
            gem_2.transform.position = new Vector3(Random.Range(2.47f, 5.26f), -5.4f, 0f);
            check = !check;
            gem += (1 * kef);
            shop_class.money += (1 * kef);
            GetComponent<AudioSource>().PlayOneShot(pick_audio);
        }

        if (collision.gameObject.tag == "2")
        {
            gem_2.SetActive(false);
            gem_1.SetActive(true);
            gem_1.transform.position = new Vector3(Random.Range(-5.66f, -2.47f), -5.4f, 0f);
            check = !check;
            gem += (1 * kef);
            shop_class.money += (1 * kef);
            GetComponent<AudioSource>().PlayOneShot(pick_audio);
        }
        if(collision.gameObject.name == "Shop1") { PlayerPrefs.SetInt("dead", buttons_class.Dead = 2); speed = 6; check = false; stay = true;}
        if (collision.gameObject.name == "Shop2") { PlayerPrefs.SetInt("dead", buttons_class.Dead = 2); speed = 6; check = true; stay = true;}
        if (collision.gameObject.tag == "Tp" ) { transform.position = new Vector3(-0.28f, -5.267f, -0.67f); transform.rotation = new Quaternion(0f, 0f, 1f, 0f); }
        if (collision.gameObject.tag == "Ground" && stay == true) { Duuhu.enabled = true; speed = 0; stay = false; }
        if (collision.gameObject.tag == "Ground") 
        {
          cam_class.enabled = false; gameObject.tag = "Player"; pl1.tag = "Default";pl2.tag = "Default"; rb.gravityScale = 20;
        }
        if (collision.gameObject) { buttons_class.y_can_swipe = true; }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject) { solid = false; }
        if (collision.gameObject.tag == "Ground") { Duuhu.enabled = false; }
        if (collision.gameObject.tag == "Shop") { shop1.SetActive(false); shop2.SetActive(false); }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Stop1") { speed = 0; shop1.SetActive(true); }
        if (collision.gameObject.name == "Stop2") { speed = 0; shop2.SetActive(true); }
        if (collision.gameObject.name == "Tp1") { speed = 0; cam_class.enabled = false; gameObject.tag = "Default"; pl1.tag = "Player"; rb.gravityScale = 1; }
        if (collision.gameObject.name == "Tp2") { speed = 0; cam_class.enabled = false; gameObject.tag = "Default"; pl2.tag = "Player"; rb.gravityScale = 1;  }

        if ((collision.gameObject.tag == "Knife" || collision.gameObject.tag == "Knife1") && armored == false)
        {
            spawner_class.boom = true;
            Destroy(gameObject);
            alive = false;
            Instantiate(dead_body, transform.position, transform.rotation);
            Instantiate(player_blood, transform.position, transform.rotation);
            ShowAd();
        }
        if (collision.gameObject.tag == "Knife" && armored == true) { armor--; }
    }

    public void Stop()
    {
        stop = !stop;
    }

    public void ShowAd()
    {
        Application.ExternalCall("ShowAd");
    }


}
