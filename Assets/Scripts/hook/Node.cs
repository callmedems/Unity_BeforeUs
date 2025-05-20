using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour
{
    private GameObject player;
    private CharHookTemp charHookTempScript;
    private Node node;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        player = GameObject.FindGameObjectWithTag("TempHook");
        node = null;
        charHookTempScript = player.GetComponent<CharHookTemp>();
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void OnMouseDown(){
        node = this;
        charHookTempScript.SelectNode(node);
    }
    public void OnMouseUp(){
        node = null;
        charHookTempScript.DeselectNode();

    }
}
