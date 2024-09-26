namespace EnergyTotal.Primitives
{
    public static class EnergyStatus
    {
        public enum Status
        {
            Unknown = 0,
            NoBattery,
            Discharging,
            Charging
        }

        public static Status FromBatteryChargeStatus(BatteryChargeStatus status)
        {
            return status switch
            {
                BatteryChargeStatus.Unknown => Status.Unknown,
                BatteryChargeStatus.NoSystemBattery => Status.NoBattery,
                BatteryChargeStatus.Charging => Status.Charging,
                _=> Status.Discharging
            };
        }
    }
}
