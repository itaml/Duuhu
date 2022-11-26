using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parts : MonoBehaviour
{
    Vector2 forceDir;
    int spin;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        spin = Random.Range(70, 200);
        forceDir.x = Random.Range(-100, 100);
        forceDir.y = Random.Range(-100, 100);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(forceDir);
        rb.AddTorque(spin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
