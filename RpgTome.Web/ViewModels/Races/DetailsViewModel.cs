using System.Collections.Generic;
using RpgTome.Model;

namespace RpgTome.Web.ViewModels.Races
{
    public class DetailsViewModel
    {
        public Race Race { get; set; }
        public IEnumerable<RaceAbilityModifier> AbilityModifiers { get; set; }
        public IEnumerable<RaceSkillBonus> SkillBonuses { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}