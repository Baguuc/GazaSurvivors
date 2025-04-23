using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public virtual void Dispose(Collider enemy) { }

    public virtual void Attack(List<GameObject> enemies) { }

    public virtual float GetDelay() { Debug.LogError("B��d, nie ustawiona przerwa mi�dzy atakami!"); return -1f; }
}
