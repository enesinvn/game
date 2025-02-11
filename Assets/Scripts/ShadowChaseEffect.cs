using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ShadowChaseEffect : MonoBehaviour
{
    public Transform player;          
    public Transform shadow;          
    public AudioSource heartbeatSound; 
    public Image screenFade;          

    public float maxDistance = 20f;   
    public float minDistance = 5f;    

    private void Update()
    {
        
        float distance = Vector3.Distance(player.position, shadow.position);

        
        float effectIntensity = Mathf.InverseLerp(maxDistance, minDistance, distance);
        
        Color fadeColor = screenFade.color;
        fadeColor.a = 1 - effectIntensity;  
        screenFade.color = fadeColor;
    }
}
