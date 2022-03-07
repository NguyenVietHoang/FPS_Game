using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemView : MonoBehaviour
{
    [SerializeField]
    private Canvas Canvas;
    [SerializeField]
    private TextMeshProUGUI NameTxt;
    [SerializeField]
    private TextMeshProUGUI DescTxt;
    [SerializeField]
    private TextMeshProUGUI ScoreTxt;
    [SerializeField]
    private TextMeshProUGUI TTLText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCamera();        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCamera();
    }

    /// <summary>
    /// Update view data using Item Data 
    /// </summary>
    /// <param name="data"></param>
    public void SetViewData(ItemData data)
    {
        if(data != null)
        {
            NameTxt.text = data.Name;
            DescTxt.text = data.Description;
            ScoreTxt.text = data.Score.ToString();
            UpdateTTLView(data.TTL);
        }
    }

    /// <summary>
    /// Update the Canvas camera as the Current Camera
    /// </summary>
    public void UpdateCamera()
    {
        if (Camera.current != null)
        {
            Canvas.worldCamera = Camera.current;
            Vector3 dir = transform.position - Camera.current.transform.position;
            transform.forward = dir;
        }
    }

    /// <summary>
    /// Update the remaining time of the Object on the view
    /// </summary>
    /// <param name="remainingTime"></param>
    public void UpdateTTLView(float remainingTime)
    {
        TTLText.text = Mathf.RoundToInt(remainingTime).ToString();
    }
}
