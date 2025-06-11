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
            

            audioSource.loop = true; // �ݺ� ���
            audioSource.volume = 1f; // �Ҹ� ���� (0 ~ 1)

            audioSource.Play(); // ����
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

