using System.Collections.Generic;

public class Inventory
{
    public List<Item> Items { get; set; }
    public int Gold { get; set; }
    public int Gem { get; set; }

    public override string ToString()
    {
        return $"Gold => {Gold} Gem => {Gem} Items Count => {Items.Count}";
    }
}