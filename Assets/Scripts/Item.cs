using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public delegate void OnEventCalled<T>(T data);
    public OnEventCalled<int> OnDestroyTime;

    public ItemView view;
    public ItemData data;
    public int itemId;

    float remainingTime;
    bool destroyed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(data != null)
        {
            remainingTime = remainingTime > 0 ? remainingTime - Time.deltaTime : 0;
            
            if(view != null && !destroyed)
            {
                view.UpdateTTLView(remainingTime);
            }

            if(remainingTime <= 0 && !destroyed)
            {
                //Debug.Log("Time to Destroy " + data.Name);
                destroyed = true;
                OnDestroyTime?.Invoke(itemId);                
            }
        }
    }

    public void OnDestroy()
    {
        //Debug.Log("Item " + data.Name + " was destroyed.");
    }

    public void SetData(int _itemId, ItemData _data, ItemView _view)
    {
        if(_data != null)
        {
            data = _data;
            itemId = _itemId;
            remainingTime = data.TTL;
            destroyed = false;
        }
        else
        {
            Debug.LogError("Error on Item Set Data: Data is null.");
        }

        if(_view != null)
        {
            view = _view;
        }
    }
}
