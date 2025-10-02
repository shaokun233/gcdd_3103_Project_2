

public class ItemDataCanChange
{
    public Item item;
    public int count;

    public ItemDataCanChange(Item item)
    {
        this.item = item;
        count = 1;
    }

    public bool add()
    {
        if (count < item.max)
        {
            count++;
            return true;
        }
        return false;
    }
    

}
