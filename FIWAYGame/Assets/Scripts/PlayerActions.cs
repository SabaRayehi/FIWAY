using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public enum Action {
    Jump = 0,
    Rush = 1
}

public class PlayerActions : MonoBehaviour
{
    public Queue<Action> actions;

    private void OnEnable()
    {
        actions = new Queue<Action>();
    }

    public bool JumpAction(Rigidbody2D rb, Vector2 vect)
    {
        rb.AddForce(vect);
        return true;

    }
    public bool RushAction(Rigidbody2D rb, Vector2 vect)
    {
        rb.AddForce(vect, ForceMode2D.Impulse);
        return true;
    }
   
}
