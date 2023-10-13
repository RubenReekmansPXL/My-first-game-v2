using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public MovingManager movement;
    public GameObject explosionsAll;
    public GameObject fireAll;
    public Vector3 position;
    public float x;
    public float y;
    public float z;
    public AudioManager audioManager;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            GameManager.gameOver = true;
            //hier moet if komen met playerprefs

            if (PlayerPrefs.GetString("Vibrate").Equals("false"))
            {
                audioManager.Vibrate();
            }

            FindObjectOfType<AudioManager>().PlaySound("Crash");

            Explode();
        }
    }

    void Explode()
    {
        x = PlayerPrefs.GetFloat("XPosition", 0);
        y = PlayerPrefs.GetFloat("YPosition", 0);
        z = PlayerPrefs.GetFloat("ZPosition", 0);

        position.x = x;
        position.y = y;
        position.z = z + 2;

        GameObject explosion = Instantiate(explosionsAll, position, Quaternion.identity);
        explosion.GetComponent<ParticleSystem>().Play();

        GameObject fire = Instantiate(fireAll, position, Quaternion.identity);
        fire.GetComponent<ParticleSystem>().Play();

    }


}
