using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Tp : Enemy
{
    public Spawner spawner_class;

    void Start()
    {
        spawner_class = GameObject.Find("Spawner").GetComponent<Spawner>();
    }

    void Update()
    { }

    private void FixedUpdate()
    {
        float lastY = gameObject.transform.position.y;
        float lastX = gameObject.transform.position.x;
        if (spawner_class.seconds % 1 == 0 && spawner_class.milsec % 0.25 == 0 && spawner_class.gameStart == true) 
        { 
            gameObject.transform.position = new Vector2(-lastX, lastY);
        }
    }
}
