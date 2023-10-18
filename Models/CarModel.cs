using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CarDealershipApp.Models
{
    public class CarModel
    {
        [DisplayName("Car Id")]
        public int Id { get; set; }

        [DisplayName("Car manufacturer")]
        public string? Make { get; set; }

        [DisplayName("Car model")]
        public string? Model { get; set; }

        [DisplayName("Year of make")]
        public int CarModelYear { get; set; }

        [DisplayName("Price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public List<CarModel>? CarList { get; set; }

        public int CurrentPageIndex { get; set; }

        public int PageCount { get; set; }
    }

}
