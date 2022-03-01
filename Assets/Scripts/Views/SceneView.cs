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
    [SerializeField]
    private TextMeshProUGUI AddressTxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetViewData(string name, int score, string _address)
    {       
        NameTxt.text = name;
        UpdateScore(score);
        AddressTxt.text = _address;
    }

    public void UpdateScore(int score)
    {
        ScoreTxt.text = score.ToString();
    }

    public void UpdateAddress(string _address)
    {
        AddressTxt.text = _address;
    }
}
