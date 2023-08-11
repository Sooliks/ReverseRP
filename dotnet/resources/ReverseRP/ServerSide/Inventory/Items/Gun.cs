namespace ServerSide.Inventory.Items;

public class Gun : ItemBase
{
    public void Use()
    {
        //достаем ган
    }
    public override void DropItem()
    {
        //дропаем ган если умираем с ним в руках
        base.DropItem();
    }
}