using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Enums;
using System;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private SceneIndex curScene;
    private bool isLoading;
    private float curLoading_i;
    private float loadingCanvasDurationTime = Constants.loadingCanvasDurationTime;

    public SceneIndex CurSceneIndex => curScene;

    protected void Awake()
    {
        curScene = (SceneIndex)SceneManager.GetActiveScene().buildIndex;

        //UserInterfaces.ChangeUI(curScene, curScene);
    }

    /// <summary>
    /// 외부에서 index로 씬 전환
    /// 원활한 게임 진행을 위해 로드 중에도 플레이가 가능한 비동기 방식 채택
    /// </summary>
    public void LoadScene(int nextSceneIndex)
    {
        if ((int)curScene == nextSceneIndex || isLoading) return;
        GameManager.coroutineHelper.StopAllCoroutines();
        GameManager.coroutineHelper.StartCoroutine(LoadSceneProcess(FinishLoad, nextSceneIndex));
    }

    /// <summary>
    /// 해당씬과 현재활성화되어 있는 씬을 비교연산하여 처리
    /// </summary>
    private void FinishLoad(LoadingCanvas loadingCanvas, SceneIndex nextSceneIndex)
    {
        curScene = nextSceneIndex;
        loadingCanvas.gameObject.SetActive(false);

        CanvasManager canvasManager = SubManager.Get<CanvasManager>();

        FadeCanvas fadeCanvas = canvasManager.GetCanvas<FadeCanvas>(Constants.FadeCanvasKey);

        GameManager.coroutineHelper.StartCoroutine(fadeCanvas.FadeOut(0.8f));

        isLoading = false;

        StartCoroutine(WaitForSceneCompletedChanged());
    }

    /// <summary>
    /// 매니저가 완료될 때까지 씬 전환을 Blocking하기 위함
    /// </summary>
    IEnumerator WaitForSceneCompletedChanged()
    {
        while((int)curScene != SceneManager.GetActiveScene().buildIndex)
        {
            yield return null;
        }

        foreach (SubManager manager in GameManager.subManagers)
            manager.SettingManagerForSceneCompleteLoaded((int)curScene);
    }

    /// <summary>
    /// 비동기 씬 전환 처리
    /// </summary>
    IEnumerator LoadSceneProcess(Action<LoadingCanvas,SceneIndex> action,int nextSceneIndex)
    {
        CanvasManager canvasManager = SubManager.Get<CanvasManager>();
        FadeCanvas fadeCanvas = canvasManager.GetCanvas<FadeCanvas>(Constants.FadeCanvasKey);
        LoadingCanvas loadingCanvas = canvasManager.GetCanvas<LoadingCanvas>(Constants.LoadingCanvasKey);

        yield return GameManager.coroutineHelper.StartCoroutine(fadeCanvas.FadeIn(Constants.FadeTime));

        //loadingCanvas.Initialize();
        //loadingCanvas.Play(2.5f);

        isLoading = true;

        UserInterfaces.ChangeUI(curScene,(SceneIndex)nextSceneIndex);

        SettingManagerForNextScene(nextSceneIndex);

        AsyncOperation operation = SceneManager.LoadSceneAsync(nextSceneIndex);
        operation.allowSceneActivation = false;

        float timer = 0f;
        while (!operation.isDone)
        {
            yield return null;

            timer += Time.deltaTime;

            if (operation.progress < 0.9f)
            {
                curLoading_i = Mathf.Lerp(curLoading_i, operation.progress, timer);
                if (curLoading_i >= operation.progress) timer = 0f;
            }
            else
            {
                curLoading_i = Mathf.Lerp(curLoading_i, 1f, timer);

                if (curLoading_i == 1.0f && timer >= loadingCanvasDurationTime)
                {
                    curLoading_i = 0.0f;
                    operation.allowSceneActivation = true;
                    break;
                }
            }
            string percent = ((int)(curLoading_i * 100.0f)).ToString();
            loadingCanvas.LoadingText.text = Constants.Loading;
        }
        //loadingCanvas.Stop();

        action?.Invoke(loadingCanvas,(SceneIndex)nextSceneIndex);
    }

    private void SettingManagerForNextScene(int nextSceneIndex)
    {
        foreach (SubManager manager in GameManager.subManagers)
            manager.SettingManagerForNextScene(nextSceneIndex);
    }

    //==========================================================================================
    //LoadScene
    public void GoStage(SceneIndex sceneIndex) { GameManager.sceneCtrl.LoadScene((int)sceneIndex); }
    public void GoIntroScene() { GoStage(SceneIndex.Intro); }
    public void GoSmithyScene() { GoStage(SceneIndex.Smithy); }
    public void GoWorkShopScene() { GoStage(SceneIndex.Workshop); }
    public void GoMineScene() { GoStage(SceneIndex.Mine); }
    public void GoSellScene() { GoStage(SceneIndex.Sell); }

    //==========================================================================================
}