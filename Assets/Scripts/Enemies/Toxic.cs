using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toxic : MonoBehaviour
{
    public Player player_class;
    public float timer, kd = 5, timer_life, kd_life = 5;

    void Start()
    {
        player_class = GameObject.FindWithTag("Player").GetComponent<Player>();

    }


    void Update()
    {
        if (timer_life <= kd_life)
        {
            timer_life += Time.deltaTime;
        }
        if (timer_life >= kd_life)
        {
            timer_life = 0;
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") { player_class.speed -= 2;player_class.toxicity = true; }
    }
}
