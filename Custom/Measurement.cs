
namespace Custom
{
    public abstract class Measurement<TMeasurement> : Enum<TMeasurement, decimal>
        where TMeasurement : Measurement<TMeasurement>
    {
        public Measurement(string name)
            : base(name)
        {
        }
    }
}
