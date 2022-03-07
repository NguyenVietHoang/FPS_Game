using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Range (0f, 5f)]
    public float speed;
    [Range(0f, 10f)]
    public float rotSpeed = 2f;

    [SerializeField]
    private GameObject playerMesh;

    [SerializeField]
    private SceneView sceneView;

    [SerializeField]
    private CameraControl cameraControl;

    [SerializeField]
    private PlayerAudioManager audioManager;

    private Animator anim;
    private Vector2 mvtSpd;
    private Rigidbody rb;

    private int score;

    private GameplayManager manager;
    CAMERA_MODE currentMode;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameplayManager.Instance;

        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        mvtSpd = Vector2.zero;

        score = 0;

        sceneView.SetViewData(manager.Name, score, manager.Address);

        currentMode = CAMERA_MODE.SIDE;
        SwitchCamera();

        audioManager.Audio_Run(false);
        audioMode = 0;
    }

    int audioMode = 0;
    // Update is called once per frame
    void Update()
    {
        float horizontal = FixInput(Input.GetAxis("Horizontal"), 0.25f);
        float vertical = FixInput(Input.GetAxis("Vertical"), 0.25f);
        mvtSpd = new Vector2(horizontal, vertical);

        //Transform the player
        if (mvtSpd != Vector2.zero)
        {
            transform.Rotate(0, rotSpeed * horizontal * Time.deltaTime, 0);

            transform.position += transform.forward * speed * Time.deltaTime * vertical;

            if (audioMode == 0 && vertical != 0)
            {
                    audioManager.Audio_Run(true);
                    audioMode = 1;
            }
            if(audioMode != 0 && vertical == 0)
            {
                audioManager.Audio_Run(false);
                audioMode = 0;                    
            }            
        }        
        else
        {
            if (audioMode != 0)
            {
                audioManager.Audio_Run(false);
                audioMode = 0;
            }
        }

        //Trigger the animation
        anim.SetFloat("Speed_f", Mathf.Abs(vertical));

        //Control Camera
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SwitchCamera();
        }
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
                OnTriggerItem(colItem);
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
#if !UNITY_EDITOR
        manager.OnScoreUpdate(score);
#endif
    }

    /// <summary>
    /// Switch Camera mode to Top down or Side View
    /// </summary>
    void SwitchCamera()
    {
        currentMode = (currentMode == CAMERA_MODE.SIDE) ? CAMERA_MODE.TOP_DOWN : CAMERA_MODE.SIDE;
        if (cameraControl != null)
        {
            cameraControl.SwitchCameraMode(currentMode);
        }
    }

    void OnTriggerItem(Item colItem)
    {
        //Trigger Add Score
        GetScore(colItem.data.Score);

        //Trigger Item Destroy Event
        colItem.OnDestroyEvent();

        //Trigger Audio
        audioManager.Audio_Collect();
        audioMode = 2;
    }
}
