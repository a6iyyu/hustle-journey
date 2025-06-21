using Assets.App.Scripts.Models;

namespace Assets.App.Scripts.Player
{
    public class Player
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public PhysiqueModel Physique { get; set; } = new PhysiqueModel();
        public Needs Needs { get; set; } = new Needs();
    }
}