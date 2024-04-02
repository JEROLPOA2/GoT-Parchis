using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{

    public PieceStates state;
    [SerializeField] public Vector3 spawn;

    public GameObject piecePosition;

    // Start is called before the first frame update
    void Start()
    {
        this.state = PieceStates.Jailed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
