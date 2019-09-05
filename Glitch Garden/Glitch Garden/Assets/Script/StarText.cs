using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarText : MonoBehaviour
{
    [SerializeField] int star = 100;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        text.text = star.ToString();
    }

    public void AddStar(int amount)
    {
        star += amount;
        UpdateDisplay();
    }

    public bool SpendStar(int amount)
    {
        if (star >= amount)
        {
            star -= amount;
            UpdateDisplay();
            return true;
        }
        else
        {
            return false;
        }
    }
}
