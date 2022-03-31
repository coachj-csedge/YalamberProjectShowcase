using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update

    public TMPro.TMP_Text HudText;
    public TMPro.TMP_Text Health;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(int newScore)
    {
        HudText.text = newScore.ToString();
    }

    public void UpdateHealth(int newHealth)
    {
        Health.text = newHealth.ToString();
    }
    
}
