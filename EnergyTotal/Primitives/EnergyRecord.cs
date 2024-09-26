namespace EnergyTotal.Primitives
{
    public class EnergyRecord
    {
        public DateTime Time { get; set; }
        public EnergyStatus.Status Status { get; set; }
        public float LifePercent { get; set; }

        public EnergyRecord(DateTime time, EnergyStatus.Status status, float lifePercent)
        {
            Time = time;
            Status = status;
            LifePercent = lifePercent;
        }

        public EnergyRecord(PowerStatus powerStatus)
        {
            Time = DateTime.Now;
            Status = EnergyStatus.FromBatteryChargeStatus(powerStatus.BatteryChargeStatus);
            LifePercent = powerStatus.BatteryLifePercent;
        }
    }
}
