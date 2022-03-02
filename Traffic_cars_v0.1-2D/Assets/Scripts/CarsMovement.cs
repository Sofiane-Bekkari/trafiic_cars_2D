using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // MOVE CARS
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

        // Cast a ray straight down.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

        // If it hits something...
        if (hit.collider != null)
        {
            transform.Translate(Vector2.down * -moveSpeed * Time.deltaTime);
            Debug.Log("HIT SOME THING");
        }
    }
}
