using Mutagen.Bethesda.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynSpellTomeNameExtender
{
    public class Settings
    {
        public List<ModKey> IgnoredMods { get; set; }

        public string Alteration_Novice { get; set; } = "Alteration I";
        public string Alteration_Apprentice { get; set; } = "Alteration II";
        public string Alteration_Adept { get; set; } = "Alteration III";
        public string Alteration_Expert { get; set; } = "Alteration IV";
        public string Alteration_Master { get; set; } = "Alteration V";

        public string Conjuration_Novice { get; set; } = "Conjuration I";
        public string Conjuration_Apprentice { get; set; } = "Conjuration II";
        public string Conjuration_Adept { get; set; } = "Conjuration III";
        public string Conjuration_Expert { get; set; } = "Conjuration IV";
        public string Conjuration_Master { get; set; } = "Conjuration V";

        public string Destruction_Novice { get; set; } = "Destruction I";
        public string Destruction_Apprentice { get; set; } = "Destruction II";
        public string Destruction_Adept { get; set; } = "Destruction III";
        public string Destruction_Expert { get; set; } = "Destruction IV";
        public string Destruction_Master { get; set; } = "Destruction V";

        public string Illusion_Novice { get; set; } = "Illusion I";
        public string Illusion_Apprentice { get; set; } = "Illusion II";
        public string Illusion_Adept { get; set; } = "Illusion III";
        public string Illusion_Expert { get; set; } = "Illusion IV";
        public string Illusion_Master { get; set; } = "Illusion V";

        public string Restoration_Novice { get; set; } = "Restoration I";
        public string Restoration_Apprentice { get; set; } = "Restoration II";
        public string Restoration_Adept { get; set; } = "Restoration III";
        public string Restoration_Expert { get; set; } = "Restoration IV";
        public string Restoration_Master { get; set; } = "Restoration V";
    }
}
