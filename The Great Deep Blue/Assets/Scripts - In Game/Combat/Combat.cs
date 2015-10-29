using UnityEngine;
using System.Collections;

public abstract class Combat : MonoBehaviour, IAttackable {

    protected RTSObject m_Parent;
    protected Vector3 m_Position = new Vector3();

    public abstract Vector3 target { get; }

    public Weapon weapon { get; protected set; }

    public abstract void Attack(RTSObject obj);

    public abstract void Stop();

    public abstract void AssignDetails(Item item);

}
