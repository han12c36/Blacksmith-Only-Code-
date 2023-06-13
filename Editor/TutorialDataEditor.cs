using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEditorInternal;
using Enums;

// 메인 캔버스 window상속으로 통일 + Button,Window 이름 기능과 일관성있게 이름 명확하게 다시 짖기
// 버튼이든 윈도우든 기획자가 봤을때 어디있는 버튼인지 알수있게 이름을 다시 지어야됨


[CustomEditor(typeof(TutorialData))]    
public class TutorialDataEditor : Editor
{
    private const string Path = Constants.TutorialDataPath;
    private const string ListEmptyWarningMessage_1 = Constants.ListEmptyWarningMessage_1;
    private const string ListEmptyWarningMessage_2 = Constants.ListEmptyWarningMessage_2;
    private const string InfoMessage_1  = Constants.InfoMessage_1;
    private const string InfoMessage_2  = Constants.InfoMessage_2;
    private const string InfoMessage_3  = Constants.InfoMessage_3;
    private const string InfoMessage_4  = Constants.InfoMessage_4;
    private const string InfoMessage_5  = Constants.InfoMessage_5;
    private const string InfoMessage_6  = Constants.InfoMessage_6;
    private const string InfoMessage_7  = Constants.InfoMessage_7;
    private const string InfoMessage_8  = Constants.InfoMessage_8;
    private const string InfoMessage_9  = Constants.InfoMessage_9;
    private const string InfoMessage_10 = Constants.InfoMessage_10;
    private const string InfoMessage_11 = Constants.InfoMessage_11;
    private const string InfoMessage_12 = Constants.InfoMessage_12;

    private const string npcPath = Paths.NPCDataPath;
    private const string ImagePath = Paths.NPCImageDataPath;

    TutorialData data;
    SerializedProperty dataList;
    //NpcDataList npcDataList;
    Sprite[] imageList;
    string[] buttons; string[] keys; string[] Windows; string[] npcNames; string[] images;

    private void OnEnable()
    {
        data = target as TutorialData;
        dataList = serializedObject.FindProperty(Constants.TalkDataPropertyName);

        GameObject canvas = AssetDatabase.LoadAssetAtPath<GameObject>(Path);
        Button[] allBtn = canvas.GetComponentsInChildren<Button>();
        Window[] allWindow = canvas.GetComponentsInChildren<Window>();

        //npcDataList = AssetDatabase.LoadAssetAtPath<NpcDataList>(npcPath);
        imageList = Resources.LoadAll<Sprite>(ImagePath);
        MoveSpriteByFilename(imageList, "", 0);

        buttons = new string[allBtn.Length];
        for (int i = 0; i < buttons.Length; i++) buttons[i] = allBtn[i].name;
        keys = new string[(int)KeyCode.Mouse6]; 
        for (int i = 0; i < keys.Length; i++) keys[i] = ((KeyCode)i).ToString();
        //PublicLibrary.CustomSortArrayByName(keys);

        Windows = new string[allWindow.Length];
        for (int i = 0; i < Windows.Length; i++) Windows[i] = allWindow[i].name;
        //npcNames = new string[npcDataList.npcs.Count];
        //for (int i = 0; i < npcDataList.npcs.Count; i++) npcNames[i] = npcDataList.npcs[i].npc_name;

        images = new string[imageList.Length];
        for (int i = 0; i < imageList.Length; i++) images[i] = imageList[i].name;
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.Space(10);
        serializedObject.Update();
        data.registerOrder = EditorGUILayout.IntField(Constants.Sort, data.registerOrder);
        DrawEnterEvent();
        DrawList();
        serializedObject.ApplyModifiedProperties();
        EditorGUILayout.HelpBox(
            "\n" +
            InfoMessage_1 + "\n" + "\n" +
            InfoMessage_2 + "\n" + "\n" +
            InfoMessage_3 + "\n" + "\n" +
            InfoMessage_4 + "\n" + "\n" +
            InfoMessage_5 + "\n" + "\n" +
            InfoMessage_6 + "\n" + "\n" +
            InfoMessage_7 + "\n" + "\n" +
            InfoMessage_8 + "\n" + "\n" +
            InfoMessage_9 + "\n" + "\n" +
            InfoMessage_11 + "\n" + "\n" +
            InfoMessage_12 + "\n" + "\n"
            , MessageType.Info);

        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(data);
        }
    }

    private void DrawEnterEvent()
    {
        EditorGUILayout.LabelField(Constants.EntryEvent);
        EditorGUILayout.BeginHorizontal();
        data.e_StartEvent = (StartEvent_Type)EditorGUILayout.EnumPopup(data.e_StartEvent, GUILayout.ExpandWidth(false), GUILayout.Width(80));

        switch (data.e_StartEvent)
        {
            case StartEvent_Type.Button:
                {
                    data.startEvent_index = EditorGUILayout.Popup(data.startEvent_index, buttons, GUILayout.ExpandWidth(false));

                    GameObject canvas = AssetDatabase.LoadAssetAtPath<GameObject>(Path);
                    Button[] allBtn = canvas.GetComponentsInChildren<Button>();
                    data.startEvent_str = allBtn[data.startEvent_index].name;
                    Debug.Log(allBtn[data.startEvent_index].name);
                    // data.e_StartEvent += () => {  };
                }
                break;
            case StartEvent_Type.Window:
                {
                    data.startEvent_index = EditorGUILayout.Popup(data.startEvent_index, Windows, GUILayout.ExpandWidth(false));

                    GameObject canvas = AssetDatabase.LoadAssetAtPath<GameObject>(Path);
                    Window[] allWindow = canvas.GetComponentsInChildren<Window>();
                    data.startEvent_str = allWindow[data.startEvent_index].name;
                    Debug.Log(allWindow[data.startEvent_index].name);
                }
                break;
            case StartEvent_Type.Kill:
                break;
            case StartEvent_Type.Scene:
                data.startEvent_index = int.Parse(EditorGUILayout.TextArea(data.startEvent_index.ToString(), GUILayout.MinHeight(20)));
                break;
        }
        EditorGUILayout.Space(10);
        EditorGUILayout.EndHorizontal();
    }

    private void DrawList()
    {
        EditorGUILayout.LabelField(Constants.TalkList);

        if (dataList.arraySize == 0)
        {
            EditorGUILayout.Space(10);
            EditorGUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button(Constants.CreateTalk, GUILayout.Width(90), GUILayout.Height(30)))
            {
                dataList.InsertArrayElementAtIndex(0);
                serializedObject.ApplyModifiedProperties();
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space(50);
            EditorGUILayout.HelpBox( 
                "\n" + 
                ListEmptyWarningMessage_1 + "\n" + "\n" +
                ListEmptyWarningMessage_2 +
                "\n",
                MessageType.Warning);
        }

        if (dataList.isExpanded)
        {
            EditorGUI.indentLevel++;

            for (int i = 0; i < dataList.arraySize; i++)
            {
                SerializedProperty element = dataList.GetArrayElementAtIndex(i);
                SerializedProperty stringData = element.FindPropertyRelative(Constants.DataPropertyName);
                SerializedProperty boolData = element.FindPropertyRelative(Constants.E_TriggerPropertyName);
                SerializedProperty boolData_event = element.FindPropertyRelative(Constants.E_TriggerPropertyName);
                SerializedProperty boolData_LockPlayer 
                    = element.FindPropertyRelative(Constants.Lock_TruggerPropertyName);

                EditorGUILayout.BeginVertical();

                EditorGUILayout.LabelField(Constants.TalkContains + (i + 1));
                data.talkDatas[i].data = EditorGUILayout.TextArea(stringData.stringValue, GUILayout.MinHeight(40));

                //JM
                EditorGUILayout.BeginHorizontal();

                GUILayout.Label(Constants.PlayerLock, GUILayout.Width(120));
                //boolData_LockPlayer.boolValue = EditorGUILayout.Toggle(boolData_LockPlayer.boolValue, GUILayout.Width(50));

                data.talkDatas[i].lock_trigger = EditorGUILayout.Toggle(data.talkDatas[i].lock_trigger, GUILayout.Width(50));


                GUILayout.Label(Constants.PlayEvent, GUILayout.Width(55));
                boolData_event.boolValue = EditorGUILayout.Toggle(boolData_event.boolValue, GUILayout.Width(50));

                //팝업
                if(boolData_event.boolValue)
                {
                    data.talkDatas[i].etype = (T_EType)EditorGUILayout.EnumPopup(data.talkDatas[i].etype, GUILayout.ExpandWidth(false), GUILayout.Width(80));

                    switch (data.talkDatas[i].etype)
                    {
                        case T_EType.None:
                            break;
                        case T_EType.Sprite:
                            int gind = EditorGUILayout.Popup(data.talkDatas[i].spriteIndex, images, GUILayout.ExpandWidth(false), GUILayout.Width(80));
                            Debug.Log(gind);
                            data.talkDatas[i].spriteIndex = gind;
                            data.talkDatas[i].t_sprite = imageList[gind];
                            break;
                        case T_EType.Window:
                            break;
                    }
                }
                else
                {
                    switch (data.talkDatas[i].etype)
                    {
                        case T_EType.None:
                            break;
                        case T_EType.Sprite:
                            data.talkDatas[i].spriteIndex = 0;
                            data.talkDatas[i].t_sprite = imageList[0];
                            break;
                        case T_EType.Window:
                            break;
                    }
                }
                //

                EditorGUILayout.EndHorizontal();
                //
                EditorGUILayout.EndVertical();

                EditorGUILayout.BeginVertical();
                EditorGUILayout.BeginHorizontal();

                GUILayout.Label(Constants.Trigger, GUILayout.Width(55));
                boolData.boolValue = EditorGUILayout.Toggle(boolData.boolValue, GUILayout.Width(50));

                if (boolData.boolValue)
                {
                    EditorGUILayout.Space(2);
                    EditorGUILayout.LabelField(Constants.NPC, GUILayout.Width(48));

                    //int ind = EditorGUILayout.Popup(data.talkDatas[i].npc.id, npcNames, GUILayout.ExpandWidth(false), GUILayout.Width(80));
                    //data.talkDatas[i].npc = npcDataList.npcs[ind];


                    EditorGUILayout.Space(2);
                    EditorGUILayout.LabelField(Constants.TYPE, GUILayout.Width(48));
                    data.talkDatas[i].type = (T_Type)EditorGUILayout.EnumPopup(data.talkDatas[i].type, GUILayout.ExpandWidth(false), GUILayout.Width(80));


                    switch (data.talkDatas[i].type)
                    {
                        case T_Type.None:
                            break;
                        case T_Type.Button:
                            data.talkDatas[i].select = EditorGUILayout.Popup(data.talkDatas[i].select, buttons, GUILayout.ExpandWidth(false));
                            break;
                        case T_Type.Key:
                            data.talkDatas[i].select = EditorGUILayout.Popup(data.talkDatas[i].select, keys, GUILayout.ExpandWidth(false));
                            break;
                        case T_Type.Window:
                            data.talkDatas[i].select = EditorGUILayout.Popup(data.talkDatas[i].select, Windows, GUILayout.ExpandWidth(false));
                            break;
                        default:
                            break;
                    }
                    serializedObject.ApplyModifiedProperties();
                }

                EditorGUILayout.EndHorizontal();    

                EditorGUILayout.EndVertical();

                if (i == dataList.arraySize - 1)
                {
                    EditorGUILayout.Space(15);
                    EditorGUILayout.BeginHorizontal();
                    GUILayout.FlexibleSpace();
                    if (GUILayout.Button(Constants.AddTalk, GUILayout.Width(90), GUILayout.Height(30)))
                    {
                        dataList.InsertArrayElementAtIndex(i + 1);
                        serializedObject.ApplyModifiedProperties();
                    }
                    if (GUILayout.Button(Constants.RemoveTalk, GUILayout.Width(90), GUILayout.Height(30)))
                    {
                        dataList.DeleteArrayElementAtIndex(i);
                        serializedObject.ApplyModifiedProperties();
                    }

                    EditorGUILayout.EndHorizontal();
                }

                EditorGUILayout.Space(15);
            }

            EditorGUI.indentLevel--;
        }
    }
    private void MoveElementToName<T>(T[] array, T value, int newIndex)
    {
        int currentIndex = System.Array.IndexOf(array, value);

        if (currentIndex < 0 || currentIndex == newIndex) return;

        System.Array.Sort(array, (a, b) => {
            if (a.Equals(value))
            {
                return newIndex.CompareTo(currentIndex);
            }
            if (b.Equals(value))
            {
                return currentIndex.CompareTo(newIndex);
            }
            return 0;
        });
    }
    public static void MoveSpriteByFilename(Sprite[] array, string filename, int newIndex)
    {
        int currentIndex = -1;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i].name == filename)
            {
                currentIndex = i;
                break;
            }
        }

        if (currentIndex < 0 || currentIndex == newIndex) return;

        Sprite sprite = array[currentIndex];
        int offset = newIndex > currentIndex ? 1 : -1;
        for (int i = currentIndex; i != newIndex; i += offset)
        {
            array[i] = array[i + offset];
        }
        array[newIndex] = sprite;
    }
}