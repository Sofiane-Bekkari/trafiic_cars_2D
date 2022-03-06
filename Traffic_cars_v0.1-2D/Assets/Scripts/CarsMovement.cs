using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarsMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public GameObject redLight; // GET REDLIGHT
    public TileDirections tilDirections; // GET REDLIGHT
    private Rigidbody2D rb;
    public TextMeshProUGUI goalPoint;
    public TextMeshProUGUI winGame;
    public TextMeshProUGUI textScore;
    public int carPoint = 1;
    public int score = 0;
    private float sizeCar; // TRY TO CATCH SIZE CAR is not userd for now
    public bool onRed = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        redLight = GameObject.Find("RedLight"); // GET RED LIGHT
        tilDirections = GameObject.Find("tile").GetComponent<TileDirections>();
        sizeCar = GetComponent<BoxCollider2D>().size.y; // GET SIZE OF CAR IN Y AXIS
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
            //rb.constraints = RigidbodyConstraints2D.FreezeAll; // STOP MOVE 
          
        }
        

    }
   
    // ON collision 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // NOT SURE!
    }
    // TRIGGER ENTER
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RedLight"))
        {
            // ON RED LIGHT
            onRed = true;
            transform.Translate(Vector2.zero);
          
        }
        if (collision.gameObject.CompareTag("Tile") && tilDirections.isTurnDown)
        {
            StartCoroutine(delayOnTurn(tilDirections.currentRetation));
        }
        if (collision.gameObject.CompareTag("Tile") && tilDirections.isTurnUp)
        {
            StartCoroutine(delayOnTurn(tilDirections.currentRetation2));
            
        }
        if (collision.gameObject.CompareTag("StationBlue") || collision.gameObject.CompareTag("StationGreen"))
        {
           

            goalPoint.gameObject.SetActive(true);
            StartCoroutine(delayText());
            Debug.Log("CAR HIT STATION" + score);

        }


    }
    // TRIGGER EXIT
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RedLight"))
        {
            // OFF RED LIGHT
            onRed = false;
          
        }
        if (collision.gameObject.CompareTag("StationBlue") || collision.gameObject.CompareTag("StationGreen"))
        {
            
            Destroy(gameObject);
            Debug.Log("Destroy");

        }
     
    }

    // DELAY ON TURN
    IEnumerator delayOnTurn(Vector3 direction)
    {
        yield return new WaitForSeconds(1f);
        transform.Rotate(direction); // GIVEN DIRECTION
        Debug.Log("COLLISION: DOWN/UP works");

    }
    // DELAY TEXT
    IEnumerator delayText()
    {
        yield return new WaitForSeconds(1.5f);
        goalPoint.gameObject.SetActive(false);

    }
    // COUNT CARS REACH STATIONS
    public void CountCar(int addNum)
    {
       
            score += addNum;
            textScore.text = "SCORE: " + score; // DISPLAY TO SCREEN
            if (score >= 3)
            {
                winGame.gameObject.SetActive(true);
            }
            Debug.Log(score);

    }

}


