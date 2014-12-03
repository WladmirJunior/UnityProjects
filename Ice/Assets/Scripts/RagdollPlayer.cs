using UnityEngine;
using System.Collections;

public class RagdollPlayer : MonoBehaviour {

    public Color[] colors;
	
	void Start () {
        GetComponentInChildren<SkinnedMeshRenderer>().materials[5].color = colors[PlayerPrefs.GetInt("item_equipped_number")];
	}
	
}
