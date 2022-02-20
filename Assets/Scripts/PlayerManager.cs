using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Range (0f, 5f)]
    public float speed;

    private Animator anim;
    private Vector2 mvtSpd;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        mvtSpd = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        mvtSpd = new Vector2(horizontal, vertical);
        
        //Translate the player
        if (mvtSpd != Vector2.zero)
        {
            //Debug.Log("Get Input: " + mvtSpd);           
            Vector3 dir = new Vector3(mvtSpd.x, transform.forward.y, mvtSpd.y);

            //Face the user to the direction of the input.
            transform.forward = Vector3.Normalize(dir);
            Vector3 newPos = transform.position;
            newPos.x += horizontal * speed * Time.deltaTime;
            newPos.z += vertical * speed * Time.deltaTime;

            transform.position = newPos;
        }

        //Trigger the animation
        anim.SetFloat("Speed_f", Mathf.Max(Mathf.Abs(horizontal), Mathf.Abs(vertical)));
    }

}
