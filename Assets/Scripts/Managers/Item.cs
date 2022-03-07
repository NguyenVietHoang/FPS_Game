using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public delegate void OnEventCalled<T>(T data);
    public OnEventCalled<int> OnDestroyTime;

    [SerializeField]
    private ItemView view;
    public ItemData data;

    public List<MeshRenderer> renderers;
    public List<Collider> colliders;

    [HideInInspector]
    public int itemId;

    [SerializeField]
    private ParticleSystem particle;

    float remainingTime;
    bool destroyed;

    // Start is called before the first frame update
    void Start()
    {
        view.SetViewData(data);
        particle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(data != null && !destroyed)
        {
            remainingTime = remainingTime > 0 ? remainingTime - Time.deltaTime : 0;
            
            if(view != null )
            {
                view.UpdateTTLView(remainingTime);
            }

            if(remainingTime <= 0)
            {
                //Debug.Log("Time to Destroy " + data.Name);
                OnDestroyEvent();
            }
        }
    }

    public void OnDestroy()
    {
        //Debug.Log("Item " + data.Name + " was destroyed.");
    }

    public void SetData(int _itemId)
    { 
        itemId = _itemId;
        remainingTime = data.TTL;
        destroyed = false;       
    }

    private void DeactiveObj()
    {
        destroyed = true;

        foreach (var mesh in renderers)
        {
            mesh.enabled = false;
        }

        foreach (var col in colliders)
        {
            col.enabled = false;
        }
    }

    /// <summary>
    /// Call this event to set this Item in Destroyed mode
    /// </summary>
    public void OnDestroyEvent()
    {
        DeactiveObj();
        particle.Stop();
        OnDestroyTime?.Invoke(itemId);
    }
}
