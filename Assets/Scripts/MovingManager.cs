using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovingManager : MonoBehaviour
{

    public Rigidbody rb;
    public GameManager gameManager;
    public float forwardForce = 4500f;
    public float sidewaysForce = 80f;

    private bool leftMove = false;
    private bool rightMove = false;
    public static bool tap;
    private int timesPlayed;


    public int index;
    public Transform player;
    public GameObject carholder;

    public float x;
    public float y;
    public float z;

    public float xPref;
    public float yPref;
    public float zPref;

    // Start is called before the first frame update
    void Start()
    {
        timesPlayed = PlayerPrefs.GetInt("TimesPlayed");
    }

    // Update is called once per frame
    // We marked this as "Fixed"Update because we are using it to mess with physics
    void FixedUpdate()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        player = carholder.transform.GetChild(index);
        rb = player.GetComponent<Rigidbody>();
        x = player.position.x;
        y = player.position.y;
        z = player.position.z;

        PlayerPrefs.SetFloat("XPosition", x);
        PlayerPrefs.SetFloat("YPosition", y);
        PlayerPrefs.SetFloat("ZPosition", z);

        xPref = PlayerPrefs.GetFloat("XPosition", 0);
        yPref = PlayerPrefs.GetFloat("YPosition", 0);
        zPref = PlayerPrefs.GetFloat("ZPosition", 0);


        tap = false;
        if (!GameManager.isGameStarted)
        {
            return;
        }

        //add a forward force, we gebruiken Time.deltaTime om de snelheid waarmee het object beweegt de zelfde is op pc met hogere frame's want add force rekend per frame
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("q") || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -4.1f)
        {
            GameManager.gameOver = true;
        }



        //swipecontrols
        if (leftMove)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (rightMove)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

    }

    public void tapPress()
    {
        tap = true;
        timesPlayed++;
        PlayerPrefs.SetInt("TimesPlayed", timesPlayed);
    }

    public void leftPress()
    {
        leftMove = true;
        rightMove = false;
    }
    public void rightPress()
    {
        leftMove = false;
        rightMove = true;
    }

    public void leftStop()
    {
        leftMove = false;
        rightMove = false;
    }

    public void rightStop()
    {
        leftMove = false;
        rightMove = false;
    }
}
