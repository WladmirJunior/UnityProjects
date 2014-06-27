using UnityEngine;
using System.Collections;

public enum LevelMode
{
    STATIC,
    MOVE_UP,
    MOVE_FRONT,
}

public class Level : MonoBehaviour {

    public float itemsAmount;
    public GameObject gui;
    public float timeFinishLevel = 0; // mudar para private

    public LevelMode levelMode;
    public float timeStartLevel;
    public float timeMove = 50;

    public float time2Star;
    public float time3Star;

    [HideInInspector]
    public bool  endLevel = false;
    private bool startLevel = false;

    private bool moveCamera = true;

    public bool MoveCamera
    {
        get { return moveCamera; }
        set { moveCamera = value; }
    }
    private Player player;

    public GameObject s1, s2, s3;

    void Start()
    {
        gui.SetActive(false);
        player = GetComponentInChildren<Player>();
        timeMove /= 100;
    }

    public Vector3 p, v, l, t;

    void OnDrawGizmos()
    {
        
        

        Gizmos.color = Color.red;
        Gizmos.DrawLine(p, v);
        Gizmos.DrawLine(l, t);
    }

    void FixedUpdate()
    {
        p = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height * 0.025F, Camera.main.nearClipPlane));
        v = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height * 0.025F, Camera.main.nearClipPlane));

        l = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.025F, 0, Camera.main.nearClipPlane));
        t = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.025F, Screen.height, Camera.main.nearClipPlane));
        //limitLevel.transform.position = new Vector3(l.x, limitLevel.transform.position.y, limitLevel.transform.position.z);

        switch (levelMode)
        {
            case LevelMode.STATIC:
                if (moveCamera)
                {
                    // Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(this.transform.position.x, this.transform.position.y , Camera.main.transform.position.z), 0.2f); // (transform.position.x, transform.position.y, Camera.main.transform.position.z);
                    Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, Camera.main.transform.position.z);
                }
            break;
            case LevelMode.MOVE_UP:

            if (!startLevel)
            {
                Invoke("StartLevel", timeStartLevel);
            }

                if (!endLevel && startLevel)
                {
                    Camera.main.transform.position = new Vector3(player.transform.position.x, Camera.main.transform.position.y + timeMove, Camera.main.transform.position.z);

                    if (player.transform.position.y + 8 < p.y)
                    {
                        player.controllable = false;
                        player.Stop();
                        Invoke("RestartLevel", 1);
                    }
                }
                else
                {
                    Camera.main.transform.position = new Vector3(player.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
                }

            break;
            case LevelMode.MOVE_FRONT:
                if (!endLevel)
                {
                    Camera.main.transform.position = new Vector3(Camera.main.transform.position.x + timeMove, player.transform.position.y, Camera.main.transform.position.z);

                    if (player.transform.position.x + 8 < l.x)
                    {
                        player.controllable = false;
                        player.Stop();
                        Invoke("RestartLevel", 1);
                    }
                }
            break;

        }

        if (player.life < 0)
        {
            Application.LoadLevel("Main");
            
        }

        if (player.itens == itemsAmount && !endLevel)
        {
            timeFinishLevel = Time.timeSinceLevelLoad;
            endLevel = true;
            EndLevel();
        }

    }

    void OnGUI()
    {

        GUI.Label(new Rect(500, 500, 100, 100), Time.timeSinceLevelLoad + "");

        //if (player.itens == itemsAmount)
        //{
        //    GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100), "Muito bem!!");
        //    Invoke("NextLevel", 2f);

        //}
    }

    void StartLevel()
    {
        startLevel = true;
    }

    void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void EndLevel()
    {
        player.controllable = false;
        player.Stop();
        gui.SetActive(true);

        if (timeFinishLevel <= time3Star)
        {
            s1.SetActive(true);
            s2.SetActive(true);
            s3.SetActive(true);
        }
        else if (timeFinishLevel > time3Star && timeFinishLevel <= time2Star)
        {
            s1.SetActive(true);
            s2.SetActive(true);
        }
        else
        {
            s1.SetActive(true);
        }        
    }

    void NextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
