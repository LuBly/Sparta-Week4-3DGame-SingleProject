using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEquipmentController : MonoBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightHand;
    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform rightFoot;

    private Dictionary<EquipType, Transform> positionDictionary;
    private Dictionary<EquipType, ItemData> equipDictionary;
    private void Awake()
    {
        equipDictionary = new Dictionary<EquipType, ItemData>() 
        {
            {EquipType.Head, null},
            {EquipType.LeftHand, null},
            {EquipType.RightHand, null},
            {EquipType.LeftFoot, null},
            {EquipType.RightFoot, null},
        };
        positionDictionary = new Dictionary<EquipType, Transform>() 
        {
            {EquipType.Head, head},
            {EquipType.LeftHand, leftHand},
            {EquipType.RightHand, rightHand},
            {EquipType.LeftFoot, leftFoot},
            {EquipType.RightFoot, rightFoot},
        };
    }

    public void EquipItem(EquipItemData equipItemData)
    {
        if(equipItemData != null)
        {
            //equip함수 수행
            // 이미 착용중인 아이템이라면 return
            if (equipDictionary[equipItemData.equipType] == equipItemData) return;


            equipDictionary[equipItemData.equipType] = equipItemData;
            Instantiate(equipItemData.equipPrefab, positionDictionary[equipItemData.equipType]);
        }
    }
}