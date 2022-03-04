using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public GameObject redLight; // GET REDLIGHT
    private float sizeCar; // TRY TO CATCH SIZE CAR
    public bool onRed = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        redLight = GameObject.Find("RedLight"); // GET RED LIGHT
        sizeCar = GetComponent<BoxCollider2D>().size.y; // GET SIZE OF CAR IN Y AXES
     
    }


    // Update is called once per frame
    void Update()
    {
        // IF IT OFF RED LIGHT
        if (!onRed)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }

        // Cast a ray straight down 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

        // If it hits something...
        if (hit.collider != null)
        {
            //rb.constraints = RigidbodyConstraints2D.FreezeAll; // SOTP MOVE 
          
        }

    }
    // TRIGGER ENTER
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RedLight"))
        {
            // AVTIVE RED LIGHT
            onRed = true;
            transform.Translate(Vector2.zero);
          
        }
        
    }
    // TRIGGER EXIT
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RedLight"))
        {
            // AVTIVE RED LIGHT
            onRed = false;
          
        }

    }

}
