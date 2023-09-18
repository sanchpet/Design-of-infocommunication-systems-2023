Renault reno = new Renault("Рено", "Renault LOGAN Active", 499.0);
Print(reno);
AutoBase myreno = new MediaNAV(reno, "Навигация");
Print(myreno);
AutoBase newmyReno = new SystemSecurity(new MediaNAV(reno, "Навигация"),
"Безопасность");
Print(newmyReno);

Shevrolet shevrolet = new Shevrolet("Шевроле", "Shevrolet Camaro", 599.0);
Print(shevrolet);
AutoBase myShevrolet = new MediaNAV(shevrolet, "Навигация");
Print(myShevrolet);
AutoBase newmyShevrolet = new SystemSecurity(new MediaNAV(shevrolet, "Навигация"),
"Безопасность");
Print(newmyShevrolet);
AutoBase newNewMyShervolet = new FoldingRoof(newmyShevrolet, "Откидная крыша");
Print(newNewMyShervolet);

static void Print(AutoBase av)
{
    Console.WriteLine(av.ToString());
}

public abstract class AutoBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double CostBase { get; set; }
    public abstract double GetCost();
    public override string ToString()
    {
        string s = String.Format("Ваш автомобиль: \n{0} \nОписание: {1} \nСтоимость {2}\n",
        Name, Description, GetCost());
        return s;
    }
}

class Renault : AutoBase
{
    public Renault(string name, string info, double costbase)
    {
        Name = name;
        Description = info;
        CostBase = costbase;
    }
    public override double GetCost()
    {
        return CostBase * 1.18;
    }
}

class Shevrolet : AutoBase
{
    public Shevrolet(string name, string info, double costbase)
    {
        Name = name;
        Description = info;
        CostBase = costbase;
    }
    public override double GetCost()
    {
        return CostBase * 1.3;
    }
}

class DecoratorOptions : AutoBase
{
    public AutoBase AutoProperty { protected get; set; }
    public string Title { get; set; }
    public DecoratorOptions(AutoBase au, string tit)
    {
        AutoProperty = au;
        Title = tit;
    }

    public override double GetCost()
    {
        return AutoProperty.GetCost();
    }

}

class MediaNAV : DecoratorOptions
{

    public MediaNAV(AutoBase p, string t) : base(p, t)
    {
        AutoProperty = p;
        Name = p.Name + ". Современный";
        Description = p.Description + ". " + this.Title + ". Обновленная мультимедийная навигационная система";
   
 }
    public override double GetCost()
    {
        return AutoProperty.GetCost() + 15.99;
    }
}

class SystemSecurity : DecoratorOptions
{

    public SystemSecurity(AutoBase p, string t) : base(p, t)
    {
        AutoProperty = p;
        Name = p.Name + ". Повышенной безопасности";
        Description = p.Description + ". " + this.Title + ". Передние боковые подушки безопасности, ESP -система динамической стабилизации автомобиля";
    }
    public override double GetCost()
    {
        return AutoProperty.GetCost() + 20.99;
    }
}

class FoldingRoof : DecoratorOptions
{

    public FoldingRoof(AutoBase p, string t) : base(p, t)
    {
        AutoProperty = p;
        Name = p.Name + ". С откидной крышей";
        Description = p.Description + ". " + this.Title + ". Откидная крыша, управляется кнопкой и задвигается за 20 секунд";
    }
    public override double GetCost()
    {
        return AutoProperty.GetCost() + 40.99;
    }
}
