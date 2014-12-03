using UnityEngine;
using System.Collections;

public enum TypeGUI
{
    COINS_MENU,
    COINS_GAME,
    POINTS_MENU,
    POITNS_GAME,
}

public class HUD : MonoBehaviour {

    private GUIText showInfo;
    public int fontSizePercent;
    private Player player;

    public TypeGUI typeGUI;

    void Start()
    {      
        showInfo = GetComponent<GUIText>();
        showInfo.fontSize = (Screen.width * fontSizePercent) / 100;

        if (typeGUI == TypeGUI.COINS_GAME || typeGUI == TypeGUI.POITNS_GAME)
        {
            player = GameObject.Find("Player").GetComponent<Player>();
        }
    }

    void Update()
    {
        switch (typeGUI)
        {
            case TypeGUI.COINS_GAME:
                showInfo.text = player.itens + "";
                break;
            case TypeGUI.COINS_MENU:
                showInfo.text = PlayerPrefs.GetInt("Coins") + "";
                break;
            case TypeGUI.POITNS_GAME:
                showInfo.text = player.points + "";
                break;
        }   
        
    }
}
