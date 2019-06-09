using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public string questName = string.Empty;
    private AudioSource audio;
    private SpriteRenderer  renderer;
    private Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        renderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();

        gameObject.SetActive(false);

        if (QuestManager.GetQuestStatus(questName) == Quest.QUESTSTATUS.ASSIGNED){
            gameObject.SetActive(true);
        }


    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            if(!gameObject.activeSelf){
                QuestManager.SetQuestStatus(questName, Quest.QUESTSTATUS.COMPILETE);
                renderer.enabled = collider.enabled = false;
                if(audio != null){
                    audio.Play();
                }
            }
        }
    }
}
