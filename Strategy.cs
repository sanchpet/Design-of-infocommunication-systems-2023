string point1 = "Дом";
string point2 = "Корпус ИТМО на Ломоносова";

StrategyRoute route = new RoadRoute();
NavigatorApp app = new NavigatorApp(route, point1, point2);

app.PrintRoute();

route = new WalkingRoute();
app = new NavigatorApp(route, point1, point2);

app.PrintRoute();

route = new BikePathRoute();
app = new NavigatorApp(route, point1, point2);

app.PrintRoute();

route = new PublicTransportRoute();
app = new NavigatorApp(route, point1, point2);

app.PrintRoute();

route = new SightseeingRoute();
app = new NavigatorApp(route, point1, point2);

app.PrintRoute();

abstract class StrategyRoute
{
    public string Map { get; set; }

    public abstract string ShowMap();
    public abstract string SetRoute(string point1, string point2);
}

class RoadRoute : StrategyRoute
{
    public RoadRoute()
    {
        Map = "Карта автодорог";
    }

    public override string ShowMap()
    {
        return Map;
    }

    public override string SetRoute(string point1, string point2)
    {
        return "Построен автомобильный маршрут от " + point1 + " к " + point2;
    }
}

class WalkingRoute : StrategyRoute
{
    public WalkingRoute()
    {
        Map = "Карта пеших маршрутов";
    }

    public override string ShowMap()
    {
        return Map;
    }

    public override string SetRoute(string point1, string point2)
    {
        return "Построен пеший маршрут от " + point1 + " к " + point2;
    }
}

class BikePathRoute : StrategyRoute
{
    public BikePathRoute()
    {
        Map = "Карта велодорожек";
    }

    public override string ShowMap()
    {
        return Map;
    }

    public override string SetRoute(string point1, string point2)
    {
        return "Построен веломаршрут от " + point1 + " к " + point2;
    }
}

class PublicTransportRoute : StrategyRoute
{
    public PublicTransportRoute()
    {
        Map = "Карта маршрутов общественного транспорта";
    }

    public override string ShowMap()
    {
        return Map;
    }

    public override string SetRoute(string point1, string point2)
    {
        return "Построен маршрут на общественном транспорте от " + point1 + " к " + point2;
    }
}

class SightseeingRoute : StrategyRoute
{
    public SightseeingRoute()
    {
        Map = "Карта достопримечательностей";
    }

    public override string ShowMap()
    {
        return Map;
    }

    public override string SetRoute(string point1, string point2)
    {
        return "Построен маршрут от " + point1 + " к " + point2 + " с посещением достоприметчальностей";
    }
}

class NavigatorApp
{
    StrategyRoute strategy;

    string point1;
    string point2;

    public NavigatorApp(StrategyRoute strategy, string point1, string point2)
    {
        this.strategy = strategy;
        this.point1 = point1;
        this.point2 = point2;
    }

    public string ShowMap()
    {
        return strategy.ShowMap();
    }

    public string SetRoute()
    {
        return strategy.SetRoute(point1, point2);
    }

    public void PrintRoute()
    {
        Console.WriteLine("Используемая карта: " + ShowMap());
        Console.WriteLine(SetRoute());
    }
}
