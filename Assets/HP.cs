using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    int maxHp;
    public int hp;
    public Camera zoomCam;
    public Transform bar;

    // Start is called before the first frame update
    void Start()
    {
        maxHp = 100;
        hp = 100; 
    }

    // Update is called once per frame
    void Update()
    {
        bar.localPosition= new Vector3(Mathf.Lerp(-2.873f, - 0.55f, (hp * 1.0f)/maxHp),bar.localPosition.y,bar.localPosition.z);
        bar.localScale = new Vector3(Mathf.Lerp(0.06607038f, 4.543642f, (hp * 1.0f)/maxHp), bar.localScale.y, bar.localScale.z);
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;

        if (hp <= 0) {
            Die();
        }

    }

    void Die() {
        Time.timeScale = 0;
        float x = GameObject.FindWithTag("Player").transform.position.x;
        float y = GameObject.FindWithTag("Player").transform.position.y;
        Instantiate(zoomCam, new Vector3(x, y, -10f), Quaternion.identity);
    }
}
