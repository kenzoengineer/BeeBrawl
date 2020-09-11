using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SpriteFlipper : MonoBehaviour
{
    public AIPath aiPath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-2.3f, 2.3f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01) {
            transform.localScale = new Vector3(2.3f, 2.3f, 1f);
        }
    }
}
