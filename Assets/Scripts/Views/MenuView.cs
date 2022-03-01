using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuView : MonoBehaviour
{
    public delegate void OnButtonCliked();
    public OnButtonCliked OnLoginClicked;

    [SerializeField]
    private Canvas Canvas;
    [SerializeField]
    private TextMeshProUGUI MsgTxt;
    [SerializeField]
    private Button LoginBtn;

    // Start is called before the first frame update
    public void Init()
    {
        SetLoginBtnEvent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetLoginBtnEvent()
    {
        LoginBtn.onClick.RemoveAllListeners();
        LoginBtn.onClick.AddListener(OnLogin);
    }

    void OnLogin()
    {
        Debug.Log("Clicked on Login Button.");
        OnLoginClicked?.Invoke();
        StartCoroutine(OnLoginDelay());
    }

    IEnumerator OnLoginDelay()
    {
        LoginBtn.interactable = false;
        yield return new WaitForSeconds(5.0f);
        LoginBtn.interactable = true;
    }

    public void SetMessage(string _msg)
    {
        MsgTxt.text = _msg;
    }
}
