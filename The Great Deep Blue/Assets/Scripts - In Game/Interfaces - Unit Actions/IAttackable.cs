using UnityEngine;
using System.Collections;

public interface IAttackable {
	
	void Attack(RTSObject obj);
    void StopAttack();

}
