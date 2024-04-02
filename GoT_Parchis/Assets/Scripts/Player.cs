using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player: MonoBehaviour
{
    [SerializeField] private GameObject[] pieces = new GameObject[4];
    [SerializeField] private Vector3[] spawnPoints = new Vector3[4];
    [SerializeField] private LayerMask layersToHit;
    [SerializeField] private GameObject carcel;
    [SerializeField] private GameObject selectedPiece;
    [SerializeField] private PlayerStates state;


    //Events
    public static event System.Action OnMiddleClick;
    public static event System.Action OnEndTurn;
    

    //Event Listeners
    void OnEnable()
    {
        Dice.OnRollDice += MovePiece;
    }

    // Se utilizan eventos debido a que la accion es realizada por un objeto externo
    private void MovePiece()
    {
        if(this.state == PlayerStates.InTurn){
            this.state = PlayerStates.DiceRolled;
        }
        
    }

    private void Start(){

        //Se establece estado del jugador a la espera de su turno
        state = PlayerStates.Iddle;

        //Se generan puntos de aparicion respecto a la posicion de la base
        spawnPoints[0] = new Vector3(carcel.transform.position.x - 1, 0.8f, carcel.transform.position.z - 1);
        spawnPoints[1] = new Vector3(carcel.transform.position.x - 1, 0.8f, carcel.transform.position.z + 1);
        spawnPoints[2] = new Vector3(carcel.transform.position.x + 1, 0.8f, carcel.transform.position.z - 1);
        spawnPoints[3] = new Vector3(carcel.transform.position.x + 1, 0.8f, carcel.transform.position.z + 1);

        for(int i = 0; i < pieces.Length; i++){
            
            try{

                //Se le asigna un punto de aparicion a cada ficha y se cambia su posicion inicial a dicho punto
                pieces[i].GetComponent<Piece>().spawn = spawnPoints[i];
                pieces[i].transform.position = pieces[i].GetComponent<Piece>().spawn;
            }

            catch(Exception e){

            }
        
        }

    }

    private void Update(){

        if (Input.GetMouseButtonDown(2) && state == PlayerStates.InTurn)
        {

            // Si se presionó el botón del mouse central, emitir el evento de clic central
            if (OnMiddleClick != null)
            {
                OnMiddleClick();
            }
        }

        //Crea un rayo el cual se usa para seleccionar una de las fichas del jugador

        else if (state == PlayerStates.DiceRolled && Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.green, 0.5f);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layersToHit))
            {
                // Comprueba si el objeto golpeado es una ficha
                Piece piece = hit.collider.GetComponent<Piece>();
                
                if (piece != null && pieces.Contains(piece.gameObject))
                {
                    // Si es una ficha, puedes hacer lo que necesites con ella
                    selectedPiece = piece.gameObject;

                    // No se usan eventos debido a que el cambio es interno
                    state = PlayerStates.PieceSelected;

                }
            }
        }


        // Funcionalidad primitiva de mover ficha AUN LE FALTA MUCHO

        else if (state == PlayerStates.PieceSelected && Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 0.5f);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layersToHit))
            {
                // Comprueba si el objeto golpeado es una ficha
                GameObject box = hit.collider.gameObject;
                
                if (box != null)
                {
                    // Si es una ficha, puedes hacer lo que necesites con ella

                    selectedPiece.transform.position = box.transform.position;
                    selectedPiece.GetComponent<Piece>().piecePosition = box;

                    // Establecer las condiciones para permitirle al jugador seleccionar 
                    // otra ficha o terminar su turno

                    state = PlayerStates.DiceRolled;

                }
            }
        }


    }
}
