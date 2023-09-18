int basket = 3;
int mode = 4;
Washing washing = new WashingWithSamsungMachine(basket, mode);

washing.TemplateMethod();

public abstract class Washing
{
    public int BasketCount { get; set; }
    public int Mode { get; set; }

    public Washing(int BasketCount, int Mode)
    {
        this.BasketCount = BasketCount;
        this.Mode = Mode;
    }

    public void TemplateMethod()
    {
        GatherClothes(BasketCount);
        LaunchWashingMachine(BasketCount, Mode);
        HangClothes(BasketCount);
    }

    public void GatherClothes(int BasketCount)
    {
        Console.WriteLine("Я собрал для стирки целых " + BasketCount + " корзины белья!");
    }
    public abstract void LaunchWashingMachine(int BasketCount, int Mode);
    public void HangClothes(int BasketCount)
    {
        Console.WriteLine("После стирки я развесил все " + BasketCount + " корзины белья");
    }
}

class WashingWithSamsungMachine : Washing
{
    private string Machine;

    public WashingWithSamsungMachine(int BasketCount, int Mode) : base(BasketCount, Mode) 
    {
        Machine = "Samsung";
    }

    public override void LaunchWashingMachine(int BasketCount, int Mode)
    {
        Console.WriteLine("Запущена стиралка {0} в режиме {1}, чтобы постирать {2} корзины белья", Machine, Mode, BasketCount);
    }
}

