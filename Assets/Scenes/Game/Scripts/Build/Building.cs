using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "ScriptableObjects/BuildingScriptableObject")]
public class Building : ScriptableObject
{
    public GameObject SimpleObject;
    public GameObject WorldObject;

    public int CostSilver;
    public int CostGold;

    public Vector2 size;
}
