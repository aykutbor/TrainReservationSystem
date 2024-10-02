namespace TrainReservationSystemApi.Models
{
    public class Train
    {
        public string Name { get; set; }
        public List<Wagon> Wagons { get; set; }
    }
}
