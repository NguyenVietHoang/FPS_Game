using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioModel AudioModel;
    [SerializeField]
    private float TimeToReach = 0.2f;
    [SerializeField]
    private AudioSource BackgroundSource;
    [SerializeField]
    private AudioSource CollectSource;
    [SerializeField]
    private AudioSource WalkSource;
    // Start is called before the first frame update
    void Start()
    {
        BackgroundSource.clip = AudioModel.BackgroundClips[0];
        WalkSource.clip = AudioModel.WalkClips[0];
    }

    public void Audio_Run(bool state)
    {
        if(state)
        {
            AudioModel.OnWalk.TransitionTo(TimeToReach);            
            WalkSource.Play();
        }
        else
        {
            AudioModel.OnIdle.TransitionTo(TimeToReach);
            WalkSource.Stop();
        }
    }

    public void Audio_Collect()
    {
        AudioModel.OnCollect.TransitionTo(TimeToReach);
        AudioClip collectClip = AudioModel.CollectAudios[Random.Range(0, AudioModel.CollectAudios.Count)];
        CollectSource.PlayOneShot(collectClip);
    }
}
