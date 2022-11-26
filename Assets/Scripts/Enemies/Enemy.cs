using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player player_class;
    public Transform under;
    public GameObject fall;
    public GameObject enemy_blood;
    public Transform spawn;
    public GameObject toxic;
    public GameObject toxic_spawn;

    void Start()
    {
        player_class = GameObject.FindWithTag("Player").GetComponent<Player>();
    }



    void Update()
    {


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "1" || collision.gameObject.tag == "2" || collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player")
        {
            if (Random.Range(1,8) == 3)Instantiate(fall, spawn.position, transform.rotation);
            Instantiate(enemy_blood, under.position, transform.rotation);
            Destroy(gameObject);
        }

        if(gameObject.tag == "Knife1" && collision.gameObject.tag == "1" || collision.gameObject.tag == "2" || collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player") 
        { Instantiate(toxic,new Vector3 (gameObject.transform.position.x, -5.811f, gameObject.transform.position.z), transform.rotation); }
    }
}


