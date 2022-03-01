using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Range (0f, 5f)]
    public float speed;

    [SerializeField]
    private SceneView sceneView;

    private Animator anim;
    private Vector2 mvtSpd;
    private Rigidbody rb;

    private int score;

    private GameplayManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameplayManager.Instance;

        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        mvtSpd = Vector2.zero;

        score = 0;

        sceneView.SetViewData("Nick", score, manager.address);      
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = FixInput(Input.GetAxis("Horizontal"), 0.25f);
        float vertical = FixInput(Input.GetAxis("Vertical"), 0.25f);
        mvtSpd = new Vector2(horizontal, vertical);

        //Translate the player
        if (mvtSpd != Vector2.zero)
        {
            Vector3 newPos = transform.position;
            newPos.x += mvtSpd.x * speed * Time.deltaTime;
            newPos.z += mvtSpd.y * speed * Time.deltaTime;

            transform.LookAt(newPos, Vector3.up);
            transform.position = newPos;
        }       

        //Trigger the animation
        anim.SetFloat("Speed_f", Mathf.Max(Mathf.Abs(horizontal), Mathf.Abs(vertical)));
     
    }

    float FixInput(float input, float min_threshold)
    {
        if (Mathf.Abs(input) > 0 && Mathf.Abs(input) < min_threshold)
        {
            return min_threshold;
        }
        else
            return input;
    }

    private void FixedUpdate()
    {
        //Eliminate forces (optional)
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            Item colItem = other.gameObject.GetComponent<Item>();
            if(colItem != null)
            {
                Debug.Log("Collide with item: " + other.name);
                GetScore(colItem.data.Score);
                colItem.OnDestroyEvent();
            }
            else
            {
                Debug.LogError("Collide with Null Item.");
            }
        }
    }

    void GetScore(int _score)
    {
        score += _score;
        sceneView.UpdateScore(score);
    }
}
