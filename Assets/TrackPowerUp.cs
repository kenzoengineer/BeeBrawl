using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPowerUp : MonoBehaviour
{
    public Transform powerup;
    public Transform player;

    // Update is called once per frame
    void FixedUpdate()
    {
        float m = (powerup.position.y - player.position.y) / (powerup.position.x - player.position.x);

        //derived from (x^2/9) + (y^2/5) = 1, which is an ellipse with rad 9 and 5
        float x1 = Mathf.Sqrt((45)/(5 + 9 * Mathf.Pow(m,2)));
        float x2 = Mathf.Sqrt((45) / (5 + 9 * Mathf.Pow(m, 2))) * -1;

        float y;
        float x;
        //point will be in QI or QIV, meaning x must be +ive, meaning we will use x1
        if (powerup.position.x > player.position.x) {
            x = x1;
            y = m * x1;
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
        } else { //point will be in QII or QIII, meaning x must be -ive, meaning we will use x2
            x = x2;
            y = m * x2;
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
        }

        gameObject.transform.position = new Vector3(x + player.position.x, y + player.position.y, 0);
        //print(m + " " + x + " " + y);

        //transform z rotation so it points to the powerup
        gameObject.transform.eulerAngles = new Vector3(
            gameObject.transform.eulerAngles.x,
            gameObject.transform.eulerAngles.y,
            90f + Mathf.Rad2Deg * Mathf.Atan(m)
            );

        Debug.DrawLine(player.position,powerup.position);
        
    }
}
