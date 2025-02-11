using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarknessEffect : MonoBehaviour
{
    public Transform player;
    public Transform shadow;
    public Image darknessImage;
    public float maxDistance = 5f;
    public float maxDarkness = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.position, shadow.position);
        float alpha = Mathf.Clamp01(1 - (distance / maxDistance)) * maxDarkness;
        Color color = darknessImage.color;
        color.a = alpha;
        darknessImage.color = color;
    }
}
