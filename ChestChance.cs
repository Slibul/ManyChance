using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using System;
using System.Xml;

namespace ChestChance;

public class ChestChanced
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(RarityPossibilities), nameof(RarityPossibilities.Evaluate), new Type[] { typeof(System.Random),typeof(int[]) })] // ���� Initialize �޼��带 ������
    static void Rarye(ref Rarity __result) // �۵� x
    {
        if (Plugin.isRandom.Value == false)
        {
            int rand = new System.Random().Next(1, Plugin.commond.Value + Plugin.rared.Value + Plugin.Uniqed.Value + Plugin.Legeno.Value + 1);

            if (rand <= Plugin.commond.Value)
            {
                UnityEngine.Debug.LogError("�⺻!");
                __result = Rarity.Common;
            }
            else if (rand > Plugin.commond.Value && rand <= Plugin.commond.Value + Plugin.rared.Value)
            {
                UnityEngine.Debug.LogError("����!");
                __result = Rarity.Rare;
            }
            else if (rand > Plugin.commond.Value + Plugin.rared.Value && rand <= Plugin.commond.Value + Plugin.rared.Value + Plugin.Uniqed.Value)
            {
                UnityEngine.Debug.LogError("����ũ!");
                __result = Rarity.Unique;
            }
            else if (rand > Plugin.commond.Value + Plugin.rared.Value + Plugin.Uniqed.Value && rand <= Plugin.commond.Value + Plugin.rared.Value + Plugin.Uniqed.Value + Plugin.Legeno.Value)
            {
                UnityEngine.Debug.LogError("������!");
                __result = Rarity.Legendary;
            }
        }else if(Plugin.isReverseRandom.Value == true) 
        {
            if (__result == Rarity.Legendary)
            {
                UnityEngine.Debug.LogError("�⺻!");
                __result = Rarity.Common;
            }
            else if (__result == Rarity.Unique)
            {
                UnityEngine.Debug.LogError("����!");
                __result = Rarity.Rare;
            }
            else if (__result == Rarity.Rare)
            {
                UnityEngine.Debug.LogError("����ũ!");
                __result = Rarity.Unique;
            }
            else if (__result == Rarity.Common)
            {
                UnityEngine.Debug.LogError("������!");
                __result = Rarity.Legendary;
            }
        }
    }
}

