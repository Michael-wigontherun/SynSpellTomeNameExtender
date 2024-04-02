using Mutagen.Bethesda;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.Skyrim;
using Mutagen.Bethesda.Synthesis;

namespace SynSpellTomeNameExtender
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            return await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .SetTypicalOpen(GameRelease.SkyrimSE, "SynSpellTomeNameExtender.esp")
                .Run(args);
        }
        public static IPatcherState<ISkyrimMod, ISkyrimModGetter> State;
        public static Dictionary<FormKey, string> dict = new Dictionary<FormKey, string>();

        public static HashSet<string> IgnoredPlugins = new()
        {
            "EldenSkyrim_RimSkills.esp",
            "EldenSkyrim.esp",
            "EldenPerkTree.esp"
        };

        public static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            State = state;
            SpellTypeDictory();
            
            foreach (var book in state.LoadOrder.PriorityOrder.Book().WinningOverrides())
            {
                switch (book.Teaches)
                {
                    case IBookSpellGetter teachesSpell:
                        if (IgnoredPlugins.Contains(teachesSpell.Spell.FormKey.ModKey.ToString(), StringComparer.OrdinalIgnoreCase)) continue;

                        Book updatedBook = state.PatchMod.Books.GetOrAddAsOverride(book);
                        updatedBook.Name = UpdateName(teachesSpell, updatedBook.Name);
                        //state.PatchMod.Books.GetOrAddAsOverride(updatedBook);
                        break;
                    default:
                        break;
                }
            }
        }

        public static string UpdateName(IBookSpellGetter teachesSpell, string currentName)
        {
            string nameAddition;
            if (teachesSpell.Spell.TryResolve(State.LinkCache, out var spell))
            {
                if (dict.TryGetValue(spell.HalfCostPerk.FormKey, out nameAddition)) { }
                else nameAddition = "";
            }
            else return currentName;

            currentName = currentName.Replace("Spell Tome", "Spell Tome" + nameAddition);

            return currentName;
        }

        public static void SpellTypeDictory()
        {
            dict.Add(FormKey.Factory("0F2CA8:Skyrim.esm"), " N D");
            dict.Add(FormKey.Factory("0C44BF:Skyrim.esm"), " Ap D");
            dict.Add(FormKey.Factory("0C44C0:Skyrim.esm"), " Ad  D");
            dict.Add(FormKey.Factory("0C44C1:Skyrim.esm"), " E D");
            dict.Add(FormKey.Factory("0C44C2:Skyrim.esm"), " M D");

            dict.Add(FormKey.Factory("0F2CA6:Skyrim.esm"), " N A");
            dict.Add(FormKey.Factory("0C44B7:Skyrim.esm"), " Ap A");
            dict.Add(FormKey.Factory("0C44B8:Skyrim.esm"), " Ad  A");
            dict.Add(FormKey.Factory("0C44B9:Skyrim.esm"), " E A");
            dict.Add(FormKey.Factory("0C44BA:Skyrim.esm"), " M A");

            dict.Add(FormKey.Factory("0F2CAA:Skyrim.esm"), " N R");
            dict.Add(FormKey.Factory("0C44C7:Skyrim.esm"), " Ap R");
            dict.Add(FormKey.Factory("0C44C8:Skyrim.esm"), " Ad  R");
            dict.Add(FormKey.Factory("0C44C9:Skyrim.esm"), " E R");
            dict.Add(FormKey.Factory("0C44CA:Skyrim.esm"), " M R");

            dict.Add(FormKey.Factory("0F2CA7:Skyrim.esm"), " N C");
            dict.Add(FormKey.Factory("0C44BB:Skyrim.esm"), " Ap C");
            dict.Add(FormKey.Factory("0C44BC:Skyrim.esm"), " Ad  C");
            dict.Add(FormKey.Factory("0C44BD:Skyrim.esm"), " E C");
            dict.Add(FormKey.Factory("0C44BE:Skyrim.esm"), " M C");

            dict.Add(FormKey.Factory("0F2CA9:Skyrim.esm"), " N I");
            dict.Add(FormKey.Factory("0C44C3:Skyrim.esm"), " Ap I");
            dict.Add(FormKey.Factory("0C44C4:Skyrim.esm"), " Ad  I");
            dict.Add(FormKey.Factory("0C44C5:Skyrim.esm"), " E I");
            dict.Add(FormKey.Factory("0C44C6:Skyrim.esm"), " M I");
        }

    }
}
