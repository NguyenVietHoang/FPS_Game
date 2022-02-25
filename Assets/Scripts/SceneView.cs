using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneView : MonoBehaviour
{
    [SerializeField]
    private Canvas Canvas;
    [SerializeField]
    private TextMeshProUGUI NameTxt;
    [SerializeField]
    private TextMeshProUGUI ScoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetViewData(string name, int score)
    {       
        NameTxt.text = name;
        UpdateScore(score);
    }

    public void UpdateScore(int score)
    {
        ScoreTxt.text = score.ToString();
    }
}
