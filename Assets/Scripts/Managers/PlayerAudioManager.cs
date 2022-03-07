using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioModel audioModel;
    [SerializeField]
    private float timeToReach = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Audio_Run(bool state)
    {
        if(state)
        {
            audioModel.OnWalk.TransitionTo(timeToReach);            
            audioModel.WalkSource.Play();
        }
        else
        {
            audioModel.OnIdle.TransitionTo(timeToReach);
            audioModel.WalkSource.Stop();
        }
    }

    public void Audio_Collect()
    {
        audioModel.OnCollect.TransitionTo(timeToReach);
        AudioClip collectClip = audioModel.CollectAudios[Random.Range(0, audioModel.CollectAudios.Count)];
        audioModel.CollectSource.PlayOneShot(collectClip);
    }
}
