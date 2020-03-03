using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 0.5f;
    private Rigidbody2D rb2d;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(speed, speed);

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));


    }

    // Update is called once per frame
    void Update(){
        if (transform.position.x > screenBounds.x *-2 || transform.position.y > screenBounds.y *-2) {
            //Destroy(this.gameObject);
        }
    }
}
