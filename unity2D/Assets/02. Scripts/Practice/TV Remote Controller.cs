using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TVRemoteController : MonoBehaviour
{
    public GameObject videoScreen;
    public Button[] buttonUI;
    private VideoPlayer videoPlayer;
    public VideoClip[] clips;

    public int currClipIndex = 0; // 현재 영상 index

    public bool isMute = false;

    void Awake()
    {
        videoPlayer = videoScreen.GetComponent<VideoPlayer>();
        videoPlayer.clip = clips[0];
    }

    // 각 버튼을 눌렀을 때 실행할 함수 지정ㅈ
    void Start()
    {
        buttonUI[0].onClick.AddListener(OnScreenPower);
        buttonUI[1].onClick.AddListener(OnMute);
        buttonUI[2].onClick.AddListener(OnPrevChannel);
        buttonUI[3].onClick.AddListener(OnNextChannel);
    }

    // 전원 버튼 눌렀을 때 동작하는 함수
    public void OnScreenPower() 
    {
        videoScreen.SetActive(!videoScreen.activeSelf);

    }

    // 뮤트 버튼 눌렀을 때 동작하는 함수
    public void OnMute()
    {
        isMute = !isMute;
        videoPlayer.SetDirectAudioMute(0, isMute);

        // 
        // videoPlayer.SetDirectAudioMute(0, !videoPlayer.GetDirectAudioMute(0));
    }

    // 왼쪽 버튼 눌렀을 때 동작하는 함수
    public void OnNextChannel()
    {
        currClipIndex++;
        if (currClipIndex > 2)
            currClipIndex = 0;
        
        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }

    // 오른쪽 버튼 눌렀을 때 동작하는 함수
    public void OnPrevChannel()
    {
        currClipIndex--;
        if (currClipIndex < 0)
            currClipIndex = 2;

        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }
}
