using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Vector3 offset;
    public Vector3 rotation;
    public int index;
    public Transform player;
    public GameObject carholder;
    public Vector3 extraOffset;



    // Update is called once per frame
    void Update()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        player = carholder.transform.GetChild(index);
        if (player.name.Equals("Sedan") || player.name.Equals("Mustang") || player.name.Equals("Jeep"))
        {
            transform.position = player.position + offset + extraOffset;
        }
        else
        {
            transform.position = player.position + offset;
        }

        transform.rotation = Quaternion.Euler(rotation);
    }
}
