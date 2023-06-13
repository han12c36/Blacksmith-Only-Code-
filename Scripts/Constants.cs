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
    public const string ListEmptyWarningMessage_1 = "����ȭ�� ���� ������� �ʴ� TutorialData�� ������ �ּ��� >< ";
    public const string ListEmptyWarningMessage_2 = 
        "���� ��� : Asset -> Resources -> TutorialData �ȿ� �ִ� ������ �̵��Ͽ� ��ȭ ������ ���� ���� �����ϱ�~";
    public const string InfoMessage_1  = "< ����� > ";
    public const string InfoMessage_2  = " - ���� : ���°�� ������ Ʃ�丮������ ��ȣ�� �ο�. ��, ������ 0���� ���� �����մϴ�.";
    public const string InfoMessage_3  = " - ��ȭ ���� : ��ȭ �帧�� ����� �ִ� ����Ʈ�� �����մϴ�.";
    public const string InfoMessage_4  = " - ��ȭ �߰� : ��ȭ ���� ��ư�� ������ ����Դϴ�.";
    public const string InfoMessage_5  = " - ��ȭ ���� : ���� �ؿ� �ִ� ��ȭ ����Ʈ�� �����մϴ�.";
    public const string InfoMessage_6  = " - ��ȭ ���� : Text�� ��µ� ��ȭ �Է� �ʵ�";
    public const string InfoMessage_7  = " - Ʈ����  : Trigger üũ�� �н��� �̺�Ʈ ������ ����";
    public const string InfoMessage_8  = " - Ÿ�� : �ش� ��ȭ���� � ������ �н��� ������ ����";
    public const string InfoMessage_9  = " - 'Ÿ��' ���� ������ : ������ Ÿ���� � ���� �н��� ������ ����";
    public const string InfoMessage_10 = " - �������� �ʰų� ��Ư���� �������� �ʿ��� ���� �ش� �����ڿ��� ���� plz";
    public const string InfoMessage_11 = " - NPC : ��ȭâ�� ǥ���� NPC ����";
    public const string InfoMessage_12 = " - �̺�Ʈ : ��ȭ�� ���۵� ���� ����� �̺�Ʈ ����";

    public const string TalkDataPropertyName = "talkDatas";
    public const string Sort       = "����";
    public const string EntryEvent = "<<�����̺�Ʈ>>";
    public const string TalkList   = "<<��ȭ ����Ʈ>>";
    public const string CreateTalk = "��ȭ ����";

    public const string DataPropertyName         = "data";
    public const string TirggerPropertyName      = "trigger";
    public const string E_TriggerPropertyName    = "e_trigger";
    public const string Lock_TruggerPropertyName = "lock_trigger";

    public const string TalkContains = "��ȭ ����  ";
    public const string PlayerLock   = "�÷��̾� ��";
    public const string PlayEvent    = "    �̺�Ʈ ����";
    public const string Trigger      = "    Ʈ����";
    public const string NPC          = "NPC";
    public const string TYPE         = "Ÿ��";


    public const string AddTalk      = "��ȭ �߰�";
    public const string RemoveTalk   = "��ȭ ����";
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

    public const string ChangeTimeMessage     = "�ð��� �ѱ�ðڽ��ϱ�??";
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
