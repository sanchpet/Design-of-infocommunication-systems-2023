Sensor sensor = new Sensor();
Console.WriteLine("Температура за окном: {0} градусов по фаренгейту", sensor.GetTemperatureFarenheit());

SensorCelsium sensorCelsium = new SensorCelsium();
IMeasure measure = new AdatperMeasure(sensorCelsium);
Console.WriteLine("Температура за окном: {0} градусов по цельсию", measure.GetTemperatureFarenheit());

public static class Globals
{
    public static int Temperature = new Random().Next(200, 400);
}

interface IMeasure
{
    float GetTemperatureFarenheit();
}

class Sensor : IMeasure
{

    public float GetTemperatureFarenheit()
    {
        return (float)(1.8 * (Globals.Temperature - 273) + 32); //код предоставляет возможность брать температуру в Фаренгейтах
    }
}

class SensorCelsium
{
    public float GetTemperatureCelsium()
    {
        return Globals.Temperature - 273;
    }
}

class AdatperMeasure : IMeasure
{
    SensorCelsium sensorCelsium;

    public AdatperMeasure(SensorCelsium sc)
    {
        sensorCelsium= sc;
    }

    public float GetTemperatureFarenheit()
    {
        return sensorCelsium.GetTemperatureCelsium();
    }
}
