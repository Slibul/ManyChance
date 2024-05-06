using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using MachineChance;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{

    public enum Rarity
    {
        commond = 1,
        rare = 2,
        uniqe = 3,
        Legend = 4,
        ALL = 999
    }

    public static ConfigEntry<Rarity> Rare;

    private void Awake()
    {
        Rare = Config.Bind<Rarity>("General", "나올 레어도", Rarity.ALL, "원하시는걸 선택해주세요.");
        Harmony.CreateAndPatchAll(typeof(MachineChanced));
        Logger.LogInfo($"Mod {MyPluginInfo.PLUGIN_GUID} is loaded!");
    }
    private void Update()
    {
        Config.Reload();
    }
}
