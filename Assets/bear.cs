using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bear : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    float speed = 10 * Time.deltaTime;
    float xaxis = Input.GetAxisRaw("Horizontal") * speed;
    float zaxis = Input.GetAxisRaw("Vertical") * speed;

    if (xaxis != 0|| zaxis != 0)
    {
        transform.position += new Vector3(xaxis, 0f, zaxis);
        anim.SetTrigger("WalkForward");
        anim.ResetTrigger("Combat Idle");
        }
    else
        {
        anim.SetTrigger("Combat Idle");
        anim.ResetTrigger("WalkForward");
        }

    if (Input.GetKeyDown(KeyCode.Space))
    {
        anim.ResetTrigger("WalkForward");
        anim.ResetTrigger("Combat Idle");
        anim.SetTrigger("Attack1");
    }
    else {
        anim.SetTrigger("Combat Idle");
        if (!Input.GetKey(KeyCode.Space)) {
            anim.ResetTrigger("Attack1");

        }
        }
    }
}
