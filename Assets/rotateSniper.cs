using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateSniper : MonoBehaviour
{
    public Transform piv;
    public GameObject sniper;
    bool faceRight = true;

    void Flip()
    {
        sniper.GetComponent<SpriteRenderer>().flipY = !sniper.GetComponent<SpriteRenderer>().flipY;
        faceRight = !faceRight;
    }
    
    void Update()
    {
        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mp.z = Camera.main.nearClipPlane;
        if (Time.timeScale != 0)
        {
            float rotate = Mathf.Atan2(mp.y - piv.position.y, mp.x - piv.position.x) * Mathf.Rad2Deg;
            piv.rotation = Quaternion.Euler(new Vector3(0, 0, rotate));

            if (mp.x < piv.position.x && faceRight)
            {
                Flip();
            }
            else if (mp.x > piv.position.x && !faceRight)
            {
                Flip();
            }
        }
        
    }
}
