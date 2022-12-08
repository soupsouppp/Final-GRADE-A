using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoiceMale : MonoBehaviour
{
    public GameObject TextBox;
    public TextMeshProUGUI Text;

    public GameObject Choice1;
    public GameObject Choice2;

    


    public int choiceMade;

    public void Dialog1()
    {
        Text.text = "Student Name: Xena Valdez \nAge: 17 \nGrade: 11th \nSignning in to the female dorm at 8:50 PM, please head upstairs to your dorm.";
        choiceMade = 1;

    }

    public void Dialog2()
    {
        Text.text = "I will only sign you in because I know it is hard to be a women miss Xena. You have 10 minutes, the gate will unlock for you when you return. Do not miss the attendance check.";
        choiceMade = 2;
       
    }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Text = TextBox.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Text = TextBox.GetComponentInChildren<TextMeshProUGUI>();

        if (choiceMade >= 1)
        {
            Choice1.SetActive(false);
            Choice2.SetActive(false);
            
        }
    }
}
