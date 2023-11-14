using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeGame.Models.Characters.Playable
{
    public interface IHeroCharacter
    {
        public int Health { get; set; }
        public string Name { get; set; }
        public int Hunger { get; set; }
        public int Level { get; set; }
        public int AttackDmg { get; set; }
    }
}
