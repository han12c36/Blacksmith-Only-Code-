using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Paths
{
    //Manager

    public const string GameManagerFilePath       = "Managers/GameManager";
    public const string SubManagerFilePath        = "Managers/SubManagers/";

    public const string PlayerPrefabsPath         = "UnitPrefabs/Player";
    public const string loadingCanvasPrefabsPath  = "UIPrefabs/LoadingCanvas";
    public const string MainCanvasPrefabsPath     = "UIPrefabs/MainCanvas/MainCanvas";
    public const string SystemCanvasPrefabsPath   = "UIPrefabs/SystemCanvas/SystemCanvas";
    public const string TutorialCanvasPrefabsPath = "UIPrefabs/TutorialCanvas/TutorialCanvas";
    public const string FadeCanvasPrefabsPath     = "UIPrefabs/FadeCanvas/FadeCanvas";

    public const string EffectDataFilePath        = "EffectDatas";

    //Sound

    public const string AudioFolderPath_BGM       = "AudioClips/BGM";
    public const string AudioFolderPath_Effect    = "AudioClips/Effect";

    //Canvas

    public const string MainCanvasPath            = "MainCanvas";
    public const string LoadingCanvasPath         = "LoadingCanvasGroup";
    public const string FadeCanvasPath            = "FadeCanvas";
    public const string SystemCanvasPath          = "SystemCanvas";
    public const string TutorialCanvasPath        = "TutorialCanvas";

    //TutorialData
    public const string TutorialDataPath          = "TutorialData";
    public const string NPCDataPath               = "Assets/Personal/YJM/NPC/Npc Data List.asset";
    public const string NPCImageDataPath          = "TutorialData/Images";
}

public static partial class Constants
{
    //LayerName
    public const string EnemyDectionTargetLayerName = "Player";

    //UI Header
    public const string PlayerData = "UserData";

    public const string Clock      = "Clock";
    public const string UserData   = "UserData";
    public const string Shop       = "Shop";
    public const string Inventory  = "Invertory";

    //UIMaxPosX
    public const float maxValue    = -1200;

    //<TutorialEditor>

    public const string TutorialDataPath = "Assets/Resources/UIPrefabs/MainCanvas/MainCanvas.prefab";

    //WarningMessage
    public const string ListEmptyWarningMessage_1 = "최적화를 위해 사용하지 않는 TutorialData는 삭제해 주세요 >< ";
    public const string ListEmptyWarningMessage_2 = 
        "삭제 방법 : Asset -> Resources -> TutorialData 안에 있는 폴더로 이동하여 대화 내용이 없는 에셋 삭제하기~";
    public const string InfoMessage_1  = "< 사용방법 > ";
    public const string InfoMessage_2  = " - 순서 : 몇번째로 실행할 튜토리얼인지 번호를 부여. 단, 순서는 0번쨰 부터 시작합니다.";
    public const string InfoMessage_3  = " - 대화 생성 : 대화 흐름을 만들수 있는 리스트를 생성합니다.";
    public const string InfoMessage_4  = " - 대화 추가 : 대화 생성 버튼과 동일한 기능입니다.";
    public const string InfoMessage_5  = " - 대화 삭제 : 가장 밑에 있는 대화 리스트를 삭제합니다.";
    public const string InfoMessage_6  = " - 대화 내용 : Text에 출력될 대화 입력 필드";
    public const string InfoMessage_7  = " - 트리거  : Trigger 체크시 학습할 이벤트 선택지 생성";
    public const string InfoMessage_8  = " - 타입 : 해당 대화에서 어떤 종류를 학습할 것인지 선택";
    public const string InfoMessage_9  = " - '타입' 우측 선택지 : 선택한 타입중 어떤 것을 학습할 것인지 선택";
    public const string InfoMessage_10 = " - 존재하지 않거나 불특정한 선택지가 필요할 경우는 해당 개발자에게 문의 plz";
    public const string InfoMessage_11 = " - NPC : 대화창에 표기할 NPC 선택";
    public const string InfoMessage_12 = " - 이벤트 : 대화가 시작될 때에 실행될 이벤트 선택";

    public const string TalkDataPropertyName = "talkDatas";
    public const string Sort       = "순서";
    public const string EntryEvent = "<<입장이벤트>>";
    public const string TalkList   = "<<대화 리스트>>";
    public const string CreateTalk = "대화 생성";

    public const string DataPropertyName         = "data";
    public const string TirggerPropertyName      = "trigger";
    public const string E_TriggerPropertyName    = "e_trigger";
    public const string Lock_TruggerPropertyName = "lock_trigger";

    public const string TalkContains = "대화 내용  ";
    public const string PlayerLock   = "플레이어 락";
    public const string PlayEvent    = "    이벤트 실행";
    public const string Trigger      = "    트리거";
    public const string NPC          = "NPC";
    public const string TYPE         = "타입";


    public const string AddTalk      = "대화 추가";
    public const string RemoveTalk   = "대화 삭제";
}


public static partial class Constants
{
    //GameManager

    public const string GameManagerName           = "GameManager";
    public const string DontDestroyManagerBoxName = "DontDestroyManagerBox";


    //SubManager

    //SceneController
    public const string Loading = "Loading...";
    public const float FadeTime = .8f;
    public const float loadingCanvasDurationTime = 2.0f;


    //SoundManager
    public const string SoundObjectName = "Sound";

    public const string BGM_Intro   = "Intro";
    public const string BGM_Smithy0 = "Smithy_0";
    public const string BGM_Smithy1 = "Smithy_2";
    public const string BGM_Mine    = "Mine_1";
    public const string BGM_Sell    = "Sell_0";

    //PoolingManager
    public const string Box   = "_Box";
    public const string Clone = "(Clone)";


    //CanvasManager
    public const string MainCanvasName     = "MainCanvas";
    public const string LoadingCanvasName  = "LoadingCanvas";
    public const string FadeCanvasName     = "FadeCanvas";
    public const string TutorialCanvasName = "TutorialCanvas";

    public const string MainCanvasKey      = "MainCanvas";
    public const string LoadingCanvasKey   = "LoadingCanvas";
    public const string FadeCanvasKey      = "FadeCanvas";
    public const string TutorialCanvasKey  = "TutorialCanvas";

    //MainCanvas

    public const string ChangeTimeMessage     = "시간을 넘긱시겠습니까??";
    public const string DefaultWarningMessage = "Warning //Massage...";

    //FadeCanvas

    public const float DefaultFadeInTime    = 3.0f;
    public const float DefaultFadeOutTime   = 2.0f;
    public const int FadeCanvasSortingOrder = 2;

    //UserData
    public const string DefaultUserName = "DefaultUserName";
    public const string TestUserName    = "TestUserName";
    public const string Level           = "Lv_ ";
    public const int DefaultLevel     = 1;
    public const int DefaultGold      = 1;
    public const int DefaultMaxLevel  = 99;
    public const int DefaultMaxGold   = 999999999;
    public const int DefaultViewRange = 2;

    //TutorialData
    public const string TutorialDataFileName = "Tutorial Data";
    public const string TutorialDataMenuName = "Scriptable Object/Tutorial Data";

    //UserInterface
    public const string UI        = "_UI";
    public const string Common_UI = "Common_UI";

}
