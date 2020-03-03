using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public GameObject Inventorytab;
    public float lastinterval;
    public GameObject[] obj;
    public int minutesOf1day = 6;
    public Text day_text;
    public int currentDay = 0; 
    public Text txt;
    int i;
    private Day_Nightcycle day;

    public void Game_Start()
    {
        SceneManager.LoadScene("Instruction");
        Invoke("StartGame", 5f);

    }
    public void Yes_Button()
    {
        SceneManager.LoadScene("Survivor");
    }

    public void No_Button()
    {
        Application.Quit();
    }
    void Start()
    {
        Inventorytab.SetActive(false);
    }
    public void DisplayFoodmenu(GameObject foodmenu)
    {
        bool active = foodmenu.activeSelf;
        foodmenu.SetActive(!active);
    }
    public void DisplayInfo(int i)
    {
      if(i==0)
        {
            bool active = obj[i].activeSelf;
            obj[i].SetActive(!active);
        }
      else if(i==1)
        {
            bool active = obj[i].activeSelf;
            obj[i].SetActive(!active);
        }
    }
    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Inventorytab.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            Inventorytab.SetActive(false);
        }


        lastinterval=Time.realtimeSinceStartup;
        
        int d = (int)(lastinterval * 100.0f);
        int minutes = d / (60 * 100);
        int seconds = (d % (60 * 100)) / 100;
        int hundredths = d % 100;
        string str = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, hundredths);
        txt.text = str;
        currentDay =((int)Time.realtimeSinceStartup / (minutesOf1day*60)) + 1;
        day_text.text = Convert.ToString(currentDay);
    }
    public void PopupDisplay(GameObject pop)
    {
        pop.SetActive(true);
    }
    public void PopupInactive(GameObject pop)
    {
        pop.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Survivor");
    }
}
