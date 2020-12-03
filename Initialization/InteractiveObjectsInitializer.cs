namespace Labyrinth
{
    public class InteractiveObjectsInitializer : IInitialization
    {
        #region Fields

        private ListOfFlyingBonuses _flyingBonuses;
        private ListOfRotatingBonuses _rotatingBonuses;
        private ListOfFlickeringBonuses _flickeringBonuses;

        private HoleBonus _holeBonus;
        private BadSpeedBonus _badSpeedBonus;
        private HighSpeedBonus _highSpeedBonus;
        private WinBonus[] _winBonuses;

        public ListOfFlyingBonuses ListOfFlyingBonuses => _flyingBonuses;
        public ListOfRotatingBonuses ListOfRotatingBonuses => _rotatingBonuses;

        public ListOfFlickeringBonuses ListOfFlickeringBonuses => _flickeringBonuses;

        public HoleBonus HoleBonus
        {
            get => _holeBonus;
            set => _holeBonus = value;
        }

        public WinBonus[] WinBonuses => _winBonuses;

        #endregion


        public void Initialize()
        {
            var bonusReference = new BonusReference();

            _flyingBonuses = new ListOfFlyingBonuses();
            _flickeringBonuses = new ListOfFlickeringBonuses();
            _rotatingBonuses = new ListOfRotatingBonuses();

            _holeBonus = bonusReference.HoleBonus;

            _badSpeedBonus = bonusReference.BadSpeedBonus;
            _flyingBonuses.AddFlyingBonus(_badSpeedBonus);
            _rotatingBonuses.AddRotatingBonus(_badSpeedBonus);

            _highSpeedBonus = bonusReference.HighSpeedBonus;
            _rotatingBonuses.AddRotatingBonus(_highSpeedBonus);
            _flickeringBonuses.AddFlickeringBonus(_highSpeedBonus);

            _winBonuses = bonusReference.WinBonuses;
            _flickeringBonuses.AddManyFlickeringBonus(_winBonuses);
            _flyingBonuses.AddManyFlyingBonus(_winBonuses);
        }
    }
}
