using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class SubManager : MonoBehaviour
{
    private int id = -1;
    public int ID => id;
    
    public bool isActivated = false;

    /// <summary>
    /// 사전에 열거형으로 생성될 매니저의 순서를 지정
    /// 생성되는 순서대로 id값을 부여
    /// ID == index, 인덱스로 매니저에 곧바로 접근 가능
    /// </summary>
    public static int GetID<T>() where T : SubManager
    {
        if (Enum.TryParse(typeof(T).ToString(), out Enums.ID result)) return (int)result;
        else return -1;
    }

    public static int GetType(SubManager subManager)
    {
        Type type = subManager.GetType();
        if (Enum.TryParse(type?.ToString(), out Enums.ID result)) return (int)result;
        else return -1;
    }

    public static T Get<T>() where T : SubManager
    {
        int id = GetID<T>();
        if (id < 0) return null;
        return (T)GameManager.subManagers[id];
    }

    public static void RegisterManager(GameObject parent)
    {
        SubManager[] originPrefabs = Resources.LoadAll<SubManager>(Paths.SubManagerFilePath) as SubManager[];

        GameManager.subManagers = new List<SubManager>();
        GameManager.ActivatedsubManagers = new List<SubManager>();

        for (int i = 0; i < originPrefabs.Length; i++)
        {
            GameManager.subManagers.Add(null);
            GameManager.ActivatedsubManagers.Add(null);
        }

        for (int i = 0; i < originPrefabs.Length; i++)
        {
            int grantedID = GetType(originPrefabs[i]);

            if(grantedID < 0) continue;

            SubManager subManager = Instantiate<SubManager>(originPrefabs[i]);
            subManager?.transform.SetParent(parent.transform);
            subManager.id = grantedID;
            GameManager.subManagers[subManager.id] = subManager;
        }

        foreach (SubManager manager in GameManager.subManagers)
            manager.SettingManagerForNextScene((int)GameManager.sceneCtrl.CurSceneIndex);
    }

    /// <summary>
    /// 현재 씬에서 활성화될 매니저와 아닌 매니저를 구분하기 위함
    /// </summary>
    /// <param name="activated">활성화 여부</param>
    public void SetActivated(bool activated) 
    {
        SubManager subManager = GameManager.subManagers[id];
        subManager.isActivated = activated;
        List<SubManager> activatedSubManager = GameManager.ActivatedsubManagers;

        if (activated) { if (activatedSubManager[id] == null) activatedSubManager[id] = subManager; }
        else { if (activatedSubManager[id] != null) activatedSubManager[id] = null; }

    }

    /// <summary>
    /// nextSceneIndex에 해당하는 매니저 세팅
    /// SceneController에 의해 씬이 바뀔 때마다 호출
    /// </summary>
    /// <param name="nextSceneIndex">로드할 씬</param>
    public abstract void SettingManagerForNextScene(int nextSceneIndex);

    /// <summary>
    /// nextSceneIndex에에 해당하는 씬이 로드가 완료되면 호출
    /// </summary>
    /// <param name="nextSceneIndex">로드할 씬</param>
    public virtual void SettingManagerForSceneCompleteLoaded(int nextSceneIndex) { }


    public virtual void Awake() { ManagerInitailized(); }

    public abstract void ManagerInitailized();

    public virtual void ManagerUpdate() { }

    public virtual void ManagerFixedUpdate() { }

    public virtual void ManagerLateUpdate() { }

    public virtual void ManagerCompleteLoaded() { }

}