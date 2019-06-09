using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private RectTransform rectTransform;

    public float maxSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        if (PlayerControl.playerInstance != null){
            rectTransform.sizeDelta = new Vector2(Mathf.Clamp(PlayerControl.health, 0, 100), rectTransform.sizeDelta.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float healthUpdate = 0f;

        if (PlayerControl.playerInstance != null){
            // 用来将生命值随着当前的长度平滑，渐进地转换到目标长度
            healthUpdate = Mathf.MoveTowards(rectTransform.rect.width, PlayerControl.health, maxSpeed);

            // Debug.Log(rectTransform.rect.width);

            rectTransform.sizeDelta = new Vector2(Mathf.Clamp(healthUpdate, 0, 100), rectTransform.sizeDelta.y);
        }
    }
}
