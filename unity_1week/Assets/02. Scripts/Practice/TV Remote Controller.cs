using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TVRemoteController : MonoBehaviour
{
    public GameObject videoScreen;
    public Button[] buttonUI;
    private VideoPlayer videoPlayer;
    public VideoClip[] clips;

    public int currClipIndex = 0; // ���� ���� index

    public bool isMute = false;

    void Awake()
    {
        videoPlayer = videoScreen.GetComponent<VideoPlayer>();
        videoPlayer.clip = clips[0];
    }

    // �� ��ư�� ������ �� ������ �Լ� ������
    void Start()
    {
        buttonUI[0].onClick.AddListener(OnScreenPower);
        buttonUI[1].onClick.AddListener(OnMute);
        buttonUI[2].onClick.AddListener(OnPrevChannel);
        buttonUI[3].onClick.AddListener(OnNextChannel);
    }

    // ���� ��ư ������ �� �����ϴ� �Լ�
    public void OnScreenPower() 
    {
        videoScreen.SetActive(!videoScreen.activeSelf);

    }

    // ��Ʈ ��ư ������ �� �����ϴ� �Լ�
    public void OnMute()
    {
        isMute = !isMute;
        videoPlayer.SetDirectAudioMute(0, isMute);

        // 
        // videoPlayer.SetDirectAudioMute(0, !videoPlayer.GetDirectAudioMute(0));
    }

    // ���� ��ư ������ �� �����ϴ� �Լ�
    public void OnNextChannel()
    {
        currClipIndex++;
        if (currClipIndex > 2)
            currClipIndex = 0;
        
        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }

    // ������ ��ư ������ �� �����ϴ� �Լ�
    public void OnPrevChannel()
    {
        currClipIndex--;
        if (currClipIndex < 0)
            currClipIndex = 2;

        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }
}
