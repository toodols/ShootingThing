using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ShooterInfo")]
public class ShooterInfo : ScriptableObject
{
    public GameObject bulletPrefab;
    public GameObject shooterPrefab;

}