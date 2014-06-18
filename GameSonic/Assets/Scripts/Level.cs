using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    public float ItemsAmount;

    private Player player;

    void Start()
    {
        player = GetComponentInChildren<Player>();
    }

    void Update()
    {
        if (player.life < 0)
        {
            Application.LoadLevel("Main");
        }
    }

    void OnGUI()
    {
        if (player.itens == ItemsAmount)
        {
            GUI.Label(new Rect(Screen.width/2-50, Screen.height/2 - 50, 100, 100), "Muito bem!!");
            Invoke("NextLevel", 2f);

        }
    }

    void NextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
