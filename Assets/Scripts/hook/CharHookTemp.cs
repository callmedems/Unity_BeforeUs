using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharHookTemp : MonoBehaviour{
    
   
    private Node selectedNode;

    private Rigidbody2D rb;
    
    //PARA EL HOOK, EL lINErENDERER Y DISTANCE JOINT
    private LineRenderer lineRend;
    private DistanceJoint2D distJoint;

    public static CharHookTemp instance;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        lineRend = GetComponent<LineRenderer>();
        distJoint = GetComponent<DistanceJoint2D>();

        //evitas que al inicio se ponga la línea que una al personaje con un objeto random del escenario
        lineRend.enabled = false; 
        distJoint.enabled = false;
        selectedNode = null;
        lineRend.positionCount = 2;


    }

    // Update is called once per frame
    void Update(){
        NodeBehavior();
    }
    public void SelectNode(Node node){ //le pasa el Node o la plataforma a la que se le enganchó el hook
        selectedNode = node;

        // Establece distancia inicial del hook
        distJoint.autoConfigureDistance = false;
        distJoint.distance = Vector2.Distance(transform.position, node.transform.position);

        // Aplica un impulso para iniciar el movimiento tipo "swing"
        rb.AddForce(Vector2.right * 5f, ForceMode2D.Impulse);
    }
    public void DeselectNode(){
        selectedNode = null;
    }
    private void NodeBehavior(){
        if(selectedNode == null){
            lineRend.enabled = false; 
            distJoint.enabled = false;
            return;
        }
        lineRend.enabled = true; 
        distJoint.enabled = true;

        //con esto le dices a la cuerda del personaje que se conecte al rigid body del node osea de la plataforma donde quieres que se conecte
        distJoint.connectedBody = selectedNode.GetComponent<Rigidbody2D>();

         //el line render conecta 2 puntos
            //con esto le dices el primer y segundo punto al que estará conectado el line render 
        lineRend.SetPosition(0, transform.position); //la primera posicion es  el personaje
        lineRend.SetPosition(1,selectedNode.transform.position); //la segunda posicion es el nodo
        


    }
}