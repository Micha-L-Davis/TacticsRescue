using IntensityTable;

public interface IBreakable
{
    void Damage(int amount, Intensity intensity);
    void UndoDamage(int amount, Intensity intensity);
    int Integrity { get; }
    Intensity MaterialResistance { get; }
}