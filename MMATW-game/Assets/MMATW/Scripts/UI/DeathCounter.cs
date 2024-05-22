using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeathCounter : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    public int enemyDeath = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DrawUI()
    {
        textMeshProUGUI.text = enemyDeath.ToString();
    }
}
