using UnityEngine;

namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource audioSource;

        public AudioClip bgmClip;
        public AudioClip jumpClip;

        private void Start()
        {
            SetBGMSound();
        }

        public void SetBGMSound()
        {
            audioSource.clip = bgmClip; // ����� �ҽ��� ���� ���� ����
            audioSource.playOnAwake = true; // ������ �� �ڵ� ���
            audioSource.loop = true; // �ݺ� ���
            audioSource.volume = 1f; // �Ҹ� ���� (0 ~ 1)

            audioSource.Play(); // ����
        }

        public void OnjumpSound()
        {
            audioSource.PlayOneShot(jumpClip);
        }

    }
}

