using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    bool xb;
    bool yb;
    // Update is called once per frame
    void Update()
    {
        if (player.position.x >= -6.0f && player.position.x <= 6.0f) xb = true;
        else xb = false;

        if (player.position.y >= 1.1f) yb = true;
        else yb = false;

        if (yb && xb) {
            transform.position = new Vector3(player.position.x, player.position.y, -10f);
        } else if (yb) {
            if (player.position.x < 0f) transform.position = new Vector3(-6.0f, player.position.y, -10f);
            else transform.position = new Vector3(6.0f, player.position.y, -10f);
        } else if (xb) {
            transform.position = new Vector3(player.position.x, transform.position.y, -10f);
        } else {
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        }
    }
}
