using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PortalController : MonoBehaviour
{
    public enum SceneType { TOWN, ADVENTURE }
    public SceneType sceneType = SceneType.TOWN;

    public GameObject portalEffect;
    public Map_FadeRoutine fade;
    public GameObject loadingImage;

    public GameObject joyStick;
    public GameObject setting;
    public GameObject inventory;

    public Image progressBar;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PortalRoutine());
        }
    }

    IEnumerator PortalRoutine()
    {
        Debug.Log(sceneType);
        if (sceneType == SceneType.TOWN)
        {
            joyStick.SetActive(false);
            setting.SetActive(false);
        }
        else {
            inventory.SetActive(false);
        }

        portalEffect.SetActive(true);
        yield return StartCoroutine(fade.Fade(3f, Color.white, true)); // 페이드 온


        loadingImage.SetActive(true); // 로딩 화면 활성화
        yield return StartCoroutine(fade.Fade(3f, Color.white, false)); // 페이드 오프

        while (progressBar.fillAmount < 1f)
        {
            progressBar.fillAmount += Time.deltaTime * 0.3f;

            yield return null;
        }
        
        // 씬 변경
        if (sceneType == SceneType.TOWN)
        {
            sceneType = SceneType.ADVENTURE;
            SceneManager.LoadScene(1);
        }
        else
        {
            sceneType = SceneType.TOWN;
            SceneManager.LoadScene(0);

        }

    }
}