using UnityEngine;

namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource audioSource;

        public AudioClip introBgmClip;
        public AudioClip colliderClip;

        public AudioClip playBgmClip;
        public AudioClip jumpClip;

        public void SetBGMSound(string bgmName)
        {
            if(bgmName == "Intro")
                audioSource.clip = introBgmClip;
            else if(bgmName == "Play")
                audioSource.clip = playBgmClip;
            

            audioSource.loop = true; // 반복 기능
            audioSource.volume = 1f; // 소리 음량 (0 ~ 1)

            audioSource.Play(); // 시작
        }

        public void OnjumpSound()
        {
            audioSource.PlayOneShot(jumpClip);
        }

        public void OnColliderSound()
        {
            audioSource.PlayOneShot(colliderClip);
        }
    }
}

