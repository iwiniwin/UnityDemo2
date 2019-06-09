using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
任务列表
 */
[System.Serializable]
public class Quest{
    // 任务状态
    public enum QUESTSTATUS {UNASSIGNED = 0, ASSIGNED = 1, COMPILETE = 2};
    public QUESTSTATUS status = QUESTSTATUS.UNASSIGNED;
    // 任务名
    public string questName = string.Empty;
}

public class QuestManager : MonoBehaviour
{
    public Quest[] Quests;
    private static QuestManager singletonInstance = null;
    public static QuestManager instanc{
        get{
            if (singletonInstance == null){
                GameObject questObject = new GameObject("Default");
                singletonInstance = questObject.AddComponent<QuestManager>();
            }
            return singletonInstance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(singletonInstance){
            DestroyImmediate(gameObject);
            return;
        }
        singletonInstance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Quest.QUESTSTATUS GetQuestStatus(string questName){
        foreach(Quest quest in singletonInstance.Quests){
            if (quest.questName.Equals(questName))
                return quest.status;
        }
        return Quest.QUESTSTATUS.UNASSIGNED;
    }

    public static void SetQuestStatus(string questName, Quest.QUESTSTATUS status){
        foreach (Quest item in singletonInstance.Quests)
        {
            if(item.questName.Equals(questName)){
                item.status = status;
                return;
            }
        }
    }

    public static void Reset(){
        if (singletonInstance == null) 
            return;
        foreach (Quest quest in singletonInstance.Quests)
        {
            quest.status = Quest.QUESTSTATUS.UNASSIGNED;
        }
    }
}
