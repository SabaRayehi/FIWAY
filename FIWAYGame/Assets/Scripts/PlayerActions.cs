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

}
