using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class el3mod : MonoBehaviour
{
     public float interval = 10f; // الوقت بين الظهور والاختفاء

    private void Start()
    {
        // يبدأ تكرار show/hide كل مدة
        InvokeRepeating("ToggleVisibility", interval, interval);
    }

    void ToggleVisibility()
    {
        // يغيّر حالة الظهور
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
