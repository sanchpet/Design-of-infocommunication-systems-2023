CarFactory ford_car = new FordFactory();
Client c1 = new Client(ford_car);

Console.WriteLine("Максимальная скорость {0} составляет {1} км/час",
 c1.ToString(), c1.RunMaxSpeed());
Console.WriteLine("А тип кузова у этой тачки {0}", c1.SayBodyType());

CarFactory gmc_car = new GMCFactory();
Client c2 = new Client(gmc_car);

Console.WriteLine("Максимальная скорость {0} составляет {1} км/час",
 c2.ToString(), c2.RunMaxSpeed());
Console.WriteLine("А тип кузова у этой тачки {0}", c2.SayBodyType());

CarFactory pres_car = PresidentCarFactory.LovelyPresident;
Client c3 = new Client(pres_car);

Console.WriteLine("Максимальная скорость президентской {0} составляет {1} км/час",
 c3.ToString(), c3.RunMaxSpeed());
Console.WriteLine("А тип кузова у этой тачки {0}", c3.SayBodyType());

abstract class CarFactory
{
    public abstract AbstractCar CreateCar();
    public abstract AbstractEngine CreateEngine();
    public abstract AbstractBody CreateBody();
}

abstract class AbstractCar
{
    public string Name { get; set; }
    public abstract int MaxSpeed(AbstractEngine engine);
    public abstract string BodyType(AbstractBody body);
}

abstract class AbstractEngine
{
    public int max_speed { get; set; }
}

abstract class AbstractBody
{
    public string body_type { get; set; }
}

class FordFactory : CarFactory
{
    public override AbstractCar CreateCar()
    {
        return new FordCar("Форд");
    }
    public override AbstractEngine CreateEngine()
    {
        return new FordEngine();
    }
    public override AbstractBody CreateBody()
    {
        return new FordBody();
    }
}

class GMCFactory : CarFactory
{
    public override AbstractCar CreateCar()
    {
        return new GMCCar("GMC");
    }

    public override AbstractEngine CreateEngine()
    {
        return new GMCEngine();
    }
    public override AbstractBody CreateBody()
    {
        return new GMCBody();
    }

}

class FordCar : AbstractCar
{
    public FordCar(string name)
    {
        Name = name;
    }
    public override int MaxSpeed(AbstractEngine engine)
    {
        int ms = engine.max_speed;
        return ms;
    }
    public override string BodyType(AbstractBody body)
    {
        string bd = body.body_type;
        return bd;
    }
    public override string ToString()
    {
        return "Автомобиль " + Name;
    }
}

class GMCCar : AbstractCar
{
    public GMCCar(string name)
    {
        Name = name;
    }

    public override int MaxSpeed(AbstractEngine engine)
    {
        int ms = engine.max_speed;
        return ms;
    }

    public override string BodyType(AbstractBody body)
    {
        string bd = body.body_type;
        return bd;
    }

    public override string ToString()
    {
        return "Автомобиль " + Name;
    }
}

class FordEngine : AbstractEngine
{
    public FordEngine()
    {
        max_speed = 220;
    }
}

class GMCEngine : AbstractEngine
{
    public GMCEngine()
    {
        max_speed = 160;
    }
}

class FordBody : AbstractBody
{
    public FordBody()
    {
        body_type = "Sedan";
    }
}

class GMCBody : AbstractBody
{
    public GMCBody()
    {
        body_type = "Minivan";
    }
}

class Client
{
    private AbstractCar abstractCar;
    private AbstractEngine abstractEngine;
    private AbstractBody abstractBody;
    public Client(CarFactory car_factory)
    {
        abstractCar = car_factory.CreateCar();
        abstractEngine = car_factory.CreateEngine();
        abstractBody = car_factory.CreateBody();
    }
    public int RunMaxSpeed()
    {
        return abstractCar.MaxSpeed(abstractEngine);
    }
    public string SayBodyType()
    {
        return abstractCar.BodyType(abstractBody);
    }
    public override string ToString()
    {
        return abstractCar.ToString();
    }
}

class PresidentCarFactory : CarFactory
{ 
    private PresidentCarFactory() { }

    static Lazy<PresidentCarFactory> lovelyPresident = new Lazy<PresidentCarFactory>(()=> new PresidentCarFactory());

    public static PresidentCarFactory LovelyPresident
    {
        get
        {
            return lovelyPresident.Value;
        }
    }

    public override AbstractBody CreateBody()
    {
        return new PresidentCarBody();
    }

    public override AbstractCar CreateCar()
    {
        return new PresidentCar("Кадиллак");
    }

    public override AbstractEngine CreateEngine()
    {
        return new PresidentCarEngine();
    }
}

class PresidentCar : AbstractCar
{
    public PresidentCar(string name)
    {
        Name = name;
    }

    public override int MaxSpeed(AbstractEngine engine)
    {
        int ms = engine.max_speed;
        return ms;
    }

    public override string BodyType(AbstractBody body)
    {
        string bd = body.body_type;
        return bd;
    }

    public override string ToString()
    {
        return "Автомобиль " + Name;
    }
}

class PresidentCarEngine : AbstractEngine
{
    public PresidentCarEngine()
    {
        max_speed = 300;
    }
}

class PresidentCarBody : AbstractBody
{
    public PresidentCarBody()
    {
        body_type = "Rodster";
    }
}
