using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject[] redLights;
    public bool isOn;
    [SerializeField]
    private float timerSpeed = 1f; // TRY A NEW TIMER
    private float elapsed;

    // Start is called before the first frame update
    void Start()
    {
        redLights = GameObject.FindGameObjectsWithTag("RedLight");
        //Debug.Log("RED LIGHT: " + redLights.Length);
        isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        // TIMER      
        elapsed += Time.deltaTime;
        if (elapsed >= timerSpeed)
        {
            elapsed = 0f;
            DynamicLight(isOn);
            isOn = false;
            Debug.Log("Timer reset inside" + isOn);
         
        }

    }
    // TURNING ON/OFF DYNAMIC
    void DynamicLight(bool isOn)
    {
        if (!isOn)
        {
            for (int i = 0; i < redLights.Length; i ++)
            {
                //redLights[i].SetActive(false);
                StartCoroutine(dynamicLightOff(i)); // add i
            }
            //Debug.Log("NEED TO OFF");
        }
        else
            for (int i = 0; i < redLights.Length; i++)
            {
                redLights[i].SetActive(true) ;
            }
            //Debug.Log("NEED TO ON");

    }
    // FOR GET SOME DELAY
    IEnumerator dynamicLightOff(int i)
    {
            yield return new WaitForSeconds(0f); // need some adjustment 
            redLights[i].SetActive(false); // new line
            isOn = true;
    }
}
