using System.Collections.ObjectModel;

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

    public static class EnergyRecordsExtension
    {
        public static IReadOnlyList<IReadOnlyList<EnergyRecord>> SplitRecordsByStatus(this IEnumerable<EnergyRecord> records) =>
            records.Aggregate(
                new List<ReadOnlyCollection<EnergyRecord>>(),
                (groups, current) =>
                {
                    if (groups.Count == 0 || groups.Last().Last().Status != current.Status)
                    {
                        groups.Add(new ReadOnlyCollection<EnergyRecord>([current]));
                    }
                    else
                    {
                        var lastGroup = groups.Last();
                        var tempList = new List<EnergyRecord>(lastGroup)
                        {
                            current
                        };
                        groups.RemoveAt(groups.Count - 1);
                        groups.Add(new ReadOnlyCollection<EnergyRecord>(tempList));
                    }
                    return groups;
                }
            ).AsReadOnly();
    }
}
