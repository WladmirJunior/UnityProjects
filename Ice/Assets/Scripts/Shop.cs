using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {

    public Texture[] images;

    Vector2 scrollPosition = Vector2.zero;
    
    public float widthPercent = 0.2F;
    public float widthButton;
    public float iniX, iniY;
    public float scrollWidth, scrollHeight;
    public int fontSizePercent = 8;

    public int[] price;

    public GUIStyle equip, sel, use;

    void Start()
    {
        if (!PlayerPrefs.GetString("shop_start").Equals("true"))
        {
            PlayerPrefs.SetString("Shop-Item-1", "equipped");
            PlayerPrefs.SetString("Shop-Item-2", "sale");
            PlayerPrefs.SetString("Shop-Item-3", "sale");
            PlayerPrefs.SetString("Shop-Item-4", "sale");
            PlayerPrefs.SetString("Shop-Item-5", "sale");

            PlayerPrefs.SetString("item_equipped", "Shop-Item-1");
            PlayerPrefs.SetInt("item_equipped_number", 0);
            PlayerPrefs.SetString("shop_start", "true");
        }

        //equip.fontSize = (Screen.width * fontSizePercent) / 100;
        // 120
        //equip.padding = new RectOffset((Screen.width) / 7, 0, 0, 0);

        sel.fontSize = (Screen.width * fontSizePercent) / 100;
        sel.padding = new RectOffset( 0, (Screen.width) / 18, 0, 0);

        //use.fontSize = (Screen.width * fontSizePercent) / 100;
        //use.padding = new RectOffset((Screen.width) / 7,0, 0, 0);
    }

    void Update()
    {
        scrollWidth = Screen.width;
        scrollHeight = Screen.height;


        widthButton = scrollWidth * widthPercent;
        //iniX = scrollWidth * 0.06F;
        //iniY = scrollHeight * 0.05F;
    }

    void OnGUI()
    {

        sel.fontSize = Screen.width / 30;
        equip.contentOffset = new Vector2(widthButton * 0.25F, widthButton * -0.005F);

        //scrollPosition = GUI.BeginScrollView(new Rect(iniX, iniY, scrollWidth, scrollHeight), scrollPosition, new Rect(iniX, iniY, Screen.width * 0.9F, Screen.height * 1.6F), new GUIStyle(), new GUIStyle());
        scrollPosition = GUI.BeginScrollView(new Rect(iniX, iniY, scrollWidth, scrollHeight), scrollPosition, new Rect(iniX, iniY, Screen.width * 2.05F, Screen.height * 0.9F));

        #region Button Item 1


        GUI.DrawTexture(new Rect(iniX + scrollWidth * 0.05F, iniY + scrollWidth * 0.1F, widthButton, widthButton), images[0]);
        switch (PlayerPrefs.GetString("Shop-Item-1"))
        {
            case "sale":
                //GUI.Button(new Rect(iniX + scrollWidth * 0.11F, iniY + scrollWidth * 0.35F, widthButton / 1.5F, widthButton / 5F), "0548", equip);
                break;
            case "bought":
                if (GUI.Button(new Rect(iniX + scrollWidth * 0.065F, iniY + scrollWidth * 0.415F, widthButton/ 1.1F , widthButton / 6F), "", use))
                {
                    string equipped = PlayerPrefs.GetString("item_equipped");
                    PlayerPrefs.SetString(equipped, "bought");

                    PlayerPrefs.SetString("Shop-Item-1", "equipped");
                    PlayerPrefs.SetString("item_equipped", "Shop-Item-1");
                    PlayerPrefs.SetInt("item_equipped_number", 0);
                }
                break;
            case "equipped":
                GUI.Button(new Rect(iniX + scrollWidth * 0.065F, iniY + scrollWidth * 0.415F, widthButton/ 1.1F , widthButton / 6F), "", equip);
                
                break;
        }   
        
        #endregion

        #region Button Item 2

        GUI.DrawTexture(new Rect(iniX + scrollWidth * 0.45F, iniY + scrollWidth * 0.1F, widthButton, widthButton), images[1]);

        switch (PlayerPrefs.GetString("Shop-Item-2"))
        {
            case "sale":
                //GUI.Button(new Rect(iniX + scrollWidth * 0.065F, iniY + scrollWidth * 0.415F, widthButton/ 1.1F , widthButton / 6F
                if (GUI.Button(new Rect(iniX + scrollWidth * 0.465F, iniY + scrollWidth * 0.415F, widthButton / 1.1F, widthButton / 6F), price[1] + "", sel))
                {
                    if (PlayerPrefs.GetInt("Coins") >= price[1])
                    {
                        print("Pode comprar");
                        PlayerPrefs.SetInt("Coins", (PlayerPrefs.GetInt("Coins") - price[1]));

                        string equipped = PlayerPrefs.GetString("item_equipped");
                        PlayerPrefs.SetString(equipped, "bought");

                        PlayerPrefs.SetString("Shop-Item-2", "equipped");
                        PlayerPrefs.SetString("item_equipped", "Shop-Item-2");
                        PlayerPrefs.SetInt("item_equipped_number", 1);
                    }

                    else { print("nao Pode comprar"); }
                }
                break;
            case "bought":
                if (GUI.Button(new Rect(iniX + scrollWidth * 0.465F, iniY + scrollWidth * 0.415F, widthButton / 1.1F, widthButton / 6F), "", use))
                {
                    string equipped = PlayerPrefs.GetString("item_equipped");
                    PlayerPrefs.SetString(equipped, "bought");

                    PlayerPrefs.SetString("Shop-Item-2", "equipped");
                    PlayerPrefs.SetString("item_equipped", "Shop-Item-2");
                    PlayerPrefs.SetInt("item_equipped_number", 1);
                }
                break;
            case "equipped":
                GUI.Button(new Rect(iniX + scrollWidth * 0.465F, iniY + scrollWidth * 0.415F, widthButton / 1.1F, widthButton / 6F),"", equip);
                break;
        }  

        #endregion

        #region Button Item 3

        GUI.DrawTexture(new Rect(iniX + scrollWidth * 0.85F, iniY + scrollWidth * 0.1F, widthButton, widthButton), images[2]);
        switch (PlayerPrefs.GetString("Shop-Item-3"))
        {
            case "sale":
               
                if (GUI.Button(new Rect(iniX + scrollWidth * 0.865F, iniY + scrollWidth * 0.415F, widthButton / 1.1F, widthButton / 6F), price[2] + "", sel))
                {
                    if (PlayerPrefs.GetInt("Coins") >= price[2])
                    {
                        print("Pode comprar");
                        PlayerPrefs.SetInt("Coins", (PlayerPrefs.GetInt("Coins") - price[2]));

                        string equipped = PlayerPrefs.GetString("item_equipped");
                        PlayerPrefs.SetString(equipped, "bought");

                        PlayerPrefs.SetString("Shop-Item-3", "equipped");
                        PlayerPrefs.SetString("item_equipped", "Shop-Item-3");
                        PlayerPrefs.SetInt("item_equipped_number", 2);
                    }

                    else { print("nao Pode comprar"); }
                }

                break;
            case "bought":
                if (GUI.Button(new Rect(iniX + scrollWidth * 0.865F, iniY + scrollWidth * 0.415F, widthButton / 1.1F, widthButton / 6F), "", use))
                {
                    string equipped = PlayerPrefs.GetString("item_equipped");
                    PlayerPrefs.SetString(equipped, "bought");

                    PlayerPrefs.SetString("Shop-Item-3", "equipped");
                    PlayerPrefs.SetString("item_equipped", "Shop-Item-3");
                    PlayerPrefs.SetInt("item_equipped_number", 2);
                }
                break;
            case "equipped":
                GUI.Button(new Rect(iniX + scrollWidth * 0.865F, iniY + scrollWidth * 0.415F, widthButton / 1.1F, widthButton / 6F), "", equip);
                break;
        }  
        
        

        #endregion

        #region Button Item 4

        GUI.DrawTexture(new Rect(iniX + scrollWidth * 1.25F, iniY + scrollWidth * 0.1F, widthButton, widthButton), images[3]);
        switch (PlayerPrefs.GetString("Shop-Item-4"))
        {
            case "sale":

                if (GUI.Button(new Rect(iniX + scrollWidth * 1.265F, iniY + scrollWidth * 0.415F, widthButton / 1.1F, widthButton / 6F), price[3] + "", sel))
                {
                    if (PlayerPrefs.GetInt("Coins") >= price[3])
                    {
                        print("Pode comprar");
                        PlayerPrefs.SetInt("Coins", (PlayerPrefs.GetInt("Coins") - price[3]));

                        string equipped = PlayerPrefs.GetString("item_equipped");
                        PlayerPrefs.SetString(equipped, "bought");

                        PlayerPrefs.SetString("Shop-Item-4", "equipped");
                        PlayerPrefs.SetString("item_equipped", "Shop-Item-4");
                        PlayerPrefs.SetInt("item_equipped_number", 3);
                    }

                    else { print("nao Pode comprar"); }
                }

                break;
            case "bought":                
                if (GUI.Button(new Rect(iniX + scrollWidth * 1.265F, iniY + scrollWidth * 0.415F, widthButton / 1.1F, widthButton / 6F), "", use))
                {
                    string equipped = PlayerPrefs.GetString("item_equipped");
                    PlayerPrefs.SetString(equipped, "bought");

                    PlayerPrefs.SetString("Shop-Item-4", "equipped");
                    PlayerPrefs.SetString("item_equipped", "Shop-Item-4");
                    PlayerPrefs.SetInt("item_equipped_number", 3);
                }
                break;
            case "equipped":
                GUI.Button(new Rect(iniX + scrollWidth * 1.265F, iniY + scrollWidth * 0.415F, widthButton / 1.1F, widthButton / 6F), "", equip);
                break;
        }  
        

        #endregion

        #region Button Item 5

        GUI.DrawTexture(new Rect(iniX + scrollWidth * 1.65F, iniY + scrollWidth * 0.1F, widthButton, widthButton), images[4]);
        switch (PlayerPrefs.GetString("Shop-Item-5"))
        {
            case "sale":

                if (GUI.Button(new Rect(iniX + scrollWidth * 1.665F, iniY + scrollWidth * 0.415F, widthButton / 1.1F, widthButton / 6F), price[4] + "", sel))
                {
                    if (PlayerPrefs.GetInt("Coins") >= price[4])
                    {
                        print("Pode comprar");
                        PlayerPrefs.SetInt("Coins", (PlayerPrefs.GetInt("Coins") - price[4]));

                        string equipped = PlayerPrefs.GetString("item_equipped");
                        PlayerPrefs.SetString(equipped, "bought");

                        PlayerPrefs.SetString("Shop-Item-5", "equipped");
                        PlayerPrefs.SetString("item_equipped", "Shop-Item-5");
                        PlayerPrefs.SetInt("item_equipped_number", 4);
                    }

                    else { print("nao Pode comprar"); }
                }

                break;
            case "bought":
                //GUI.Button(new Rect(iniX + scrollWidth * 1.265F, iniY + scrollWidth * 0.415F, widthButton / 1.1F, widthButton / 6F)
                if (GUI.Button(new Rect(iniX + scrollWidth * 1.665F, iniY + scrollWidth * 0.415F, widthButton / 1.1F, widthButton / 6F), "", use))
                {
                    string equipped = PlayerPrefs.GetString("item_equipped");
                    PlayerPrefs.SetString(equipped, "bought");

                    PlayerPrefs.SetString("Shop-Item-5", "equipped");
                    PlayerPrefs.SetString("item_equipped", "Shop-Item-5");
                    PlayerPrefs.SetInt("item_equipped_number", 4);
                }
                break;
            case "equipped":
                GUI.Button(new Rect(iniX + scrollWidth * 1.665F, iniY + scrollWidth * 0.415F, widthButton / 1.1F, widthButton / 6F), "", equip);
                break;
        }  
        
        

        #endregion

        GUI.EndScrollView();

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //scrollPosition.y += Input.GetTouch(0).deltaPosition.y;
            scrollPosition.x += -Input.GetTouch(0).deltaPosition.x;
        }
    }
}
