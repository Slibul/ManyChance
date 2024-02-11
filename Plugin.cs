using BepInEx;
using BepInEx.Configuration;
using ChestChance;
using HarmonyLib;
using UnityEngine.PlayerLoop;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    public static ConfigEntry<int> commond;
    public static ConfigEntry<int> rared;
    public static ConfigEntry<int> Uniqed;
    public static ConfigEntry<int> Legeno;
    public static ConfigEntry<bool> isRandom;
    public static ConfigEntry<bool> isReverseRandom;
    private void Awake()
    {
        commond = Config.Bind<int>("General", "일반", 25, "0부터 100사이의 확율을 지정해주세요");
        rared = Config.Bind<int>("General", "레어", 25, "0부터 100사이의 확율을 지정해주세요");
        Uniqed = Config.Bind<int>("General", "유니크", 25, "0부터 100사이의 확율을 지정해주세요");
        Legeno = Config.Bind<int>("General", "레전드", 25, "0부터 100사이의 확율을 지정해주세요");
        isRandom = Config.Bind<bool>("General", "확율 정상화", false, "확율을 정상적으로 되돌립니다.");
        isReverseRandom = Config.Bind<bool>("General", "확율역전화", false, "확율을 역전시킵니다.");
        Harmony.CreateAndPatchAll(typeof(ChestChanced));
        Logger.LogInfo($"Mod {MyPluginInfo.PLUGIN_GUID} is loaded!");
    }
    private void Update()
    {
        Config.Reload();
    }
}
