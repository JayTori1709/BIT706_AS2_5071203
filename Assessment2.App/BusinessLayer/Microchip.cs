using Assessment2.App.BusinessLayer;

namespace Assessment2.App.BusinessLayer
{
    public class Microchip
    {
        public string ChipId { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Manufacturer} ({ChipId})";
        }
    }
}
