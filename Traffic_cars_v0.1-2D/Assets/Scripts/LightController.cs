using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public GameObject redLight;
    public bool isOn;
    [SerializeField]
    private float timerSpeed = 1f; // TRY A NEW TIMER
    private float elapsed;

    // Start is called before the first frame update
    void Start()
    {
        redLight = GameObject.Find("RedLight");
        Debug.Log("RED LIGHT: " + redLight);
        isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(dynamicLightOn());
        //redLight.SetActive(true);

            elapsed += Time.deltaTime;
            if (elapsed >= timerSpeed)
            {
               
                elapsed = 0f;
                DynamicLight(isOn);
                isOn = false;
                Debug.Log("Timer reset inside" + isOn);
            }



    }
    void DynamicLight(bool isOn)
    {
        if (!isOn)
        {
            redLight.SetActive(false);
            StartCoroutine(dynamicLightOff());
            Debug.Log("NEED TO OFF");
        }
        else
            redLight.SetActive(true);
            Debug.Log("NEED TO ON");

    }

    IEnumerator dynamicLightOff()
    {
            yield return new WaitForSeconds(1f);
            isOn = true;
            Debug.Log("IS ON shloud down :" + isOn);

    }
}
