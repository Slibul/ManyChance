using BepInEx;
using BepInEx.Configuration;
using Characters.Gear;
using GameResources;
using Hardmode.Darktech;
using HarmonyLib;
using Services;
using Singletons;
using System;
using System.Collections.Generic;
using System.Xml;
using UI.TestingTool;

namespace MachineChance;

public class MachineChanced
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(ManufacturingMachineInteractive), nameof(ManufacturingMachineInteractive.ActivateMachine))] // 상자 Initialize 메서드를 가져옴
    static void Rarye(ref List<GearReference> ____gearList,ref Gear.Type ____type) // 작동 x
    {
        ____gearList = new List<GearReference>();
        switch (Plugin.Rare.Value)
        {
            case Plugin.Rarity.commond:
                ____gearList.AddRange(Singleton<Service>.Instance.gearManager.GetGearListByRarity(____type, Rarity.Common));
                break;
            case Plugin.Rarity.rare:
                ____gearList.AddRange(Singleton<Service>.Instance.gearManager.GetGearListByRarity(____type, Rarity.Rare));
                break;
            case Plugin.Rarity.uniqe:
                ____gearList.AddRange(Singleton<Service>.Instance.gearManager.GetGearListByRarity(____type, Rarity.Unique));
                break;
            case Plugin.Rarity.Legend:
                ____gearList.AddRange(Singleton<Service>.Instance.gearManager.GetGearListByRarity(____type, Rarity.Legendary));
                break;
            default:
                ____gearList.AddRange(Singleton<Service>.Instance.gearManager.GetGearListByRarity(____type, Rarity.Common));
                ____gearList.AddRange(Singleton<Service>.Instance.gearManager.GetGearListByRarity(____type, Rarity.Rare));
                ____gearList.AddRange(Singleton<Service>.Instance.gearManager.GetGearListByRarity(____type, Rarity.Unique));
                ____gearList.AddRange(Singleton<Service>.Instance.gearManager.GetGearListByRarity(____type, Rarity.Legendary));
                break;
        }

    }
}

