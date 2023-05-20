using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public int speed;

    private Rigidbody2D monsterBody;

    private void Awake()
    {
        monsterBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        monsterBody.velocity = new Vector2(speed, monsterBody.velocity.y);
    }
}
