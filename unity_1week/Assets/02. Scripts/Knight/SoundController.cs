using UnityEngine;

public class SoundController : MonoBehaviour
{

    [SerializeField] private AudioSource bgmaudio;
    [SerializeField] private AudioSource eventAudio;

    [SerializeField] private AudioClip[] clips;

    void Start()
    {
        bgmaudio = GetComponent<AudioSource>();

        BgmSoundPlay("Town BGM");
    }

    public void BgmSoundPlay(string clipName)
    {
        foreach(var clip in clips)
        {
            if(clip.name == clipName)
            {
                bgmaudio.clip = clip;
                bgmaudio.Play();

                return;
            }
        }
        Debug.Log($"{clipName}을 찾지 못했습니다");
    }

    public void EventSoundPlay(string clipName)
    {
        foreach (var clip in clips)
        {
            if (clip.name == clipName)
            {
                eventAudio.PlayOneShot(clip);

                return;
            }
        }
        Debug.Log($"{clipName}을 찾지 못했습니다");
    }
}
