using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestGiver : MonoBehaviour
{
    public string questName = string.Empty;
    // ui文本盒的引用
    public Text captions = null;
    public Canvas canvas = null;
    // Start is called before the first frame update

    public string[] captionText;

    private void Start() {
        canvas.enabled = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && QuestManager.GetQuestStatus(questName) == Quest.QUESTSTATUS.UNASSIGNED){
            canvas.enabled = true;
            Quest.QUESTSTATUS status = QuestManager.GetQuestStatus(questName);
            captions.text = captionText[(int)status];
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        Quest.QUESTSTATUS status = QuestManager.GetQuestStatus(questName);
        if(status == Quest.QUESTSTATUS.UNASSIGNED){
            QuestManager.SetQuestStatus(questName, Quest.QUESTSTATUS.ASSIGNED);
            captions.text = captionText[(int)Quest.QUESTSTATUS.ASSIGNED];
        }else if(status == Quest.QUESTSTATUS.COMPILETE){
            Application.LoadLevel(5);
        }
    }
}
