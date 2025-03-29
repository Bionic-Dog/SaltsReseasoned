using BepInEx;
using BrutalAPI;
using UnityEngine;

//"name", "mod name" are placeholders. replace w/ your info. formatting advised to stay the same
// EX. "tech", "brutal orchestra mod"

namespace SaltsEnemies_Reseasoned //replace this with your mod's name. EX. "BRUTAL_ORCHESTRA_MOD", "MyBorchMod", etc
{
    [BepInPlugin("millieamp.reseasoned", "Salt Enemies (TM) Reseasoned", "0.1")] //version doesn't matter too much, as long as it's there. Replace
    [BepInDependency("BrutalOrchestra.BrutalAPI", BepInDependency.DependencyFlags.HardDependency)]
    public class SaltsReseasoned : BaseUnityPlugin //replace 'ModName' with your mod's name. EX. "BrutalOrchestraMod"
    {
        public void Awake()
        {
            Logger.LogInfo("they salt on my enemies till i season?"); //sends a message to the logging console confirming your mod is able to read info in this bracket

            //to add a seperate file, simply put the name of the .cs file and put .Add(); after. 
            //Characters
            //YourCharacter.Add(); //change this to whatever filename your fool's data is using. EX. TechCH.Add();

        }
    }
}
