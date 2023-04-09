
public class Item
{
    public int ID { get; set; }
    public string Name { get; set; }
    public float ItemValue { get; set; }
    public float ItemExtraValue { get; set; }
    public float MagicValue { get; set; }
    
    public override string ToString()
    {
        return $"ID:{ID} Name:{Name} Item Value:{ItemValue} Item Extra Value:{ItemExtraValue} Magic Value:{MagicValue}";
    }
}