namespace MyVehicle
{
    public class Program
    {
        public static void Main()
        {
            var list = new List<Vehicle>()
            {
                   new Car(100,50,"Казани","Москву"),
                   new Ship(50,10,"Москвы","Казань"),
                   new Plane(1000,400, "Казани", "Москву"),
            };
            foreach (var f in list)
                Console.WriteLine(f);
            foreach (var f in list)
                f.SpeedUp();
            foreach (var f in list)
                Console.WriteLine(f);
            foreach (var f in list)
                f.SpeedDown();
            foreach (var f in list)
                Console.WriteLine(f);
        }
    }
}