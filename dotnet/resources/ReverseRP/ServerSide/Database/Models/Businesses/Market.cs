using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Newtonsoft.Json;


namespace ServerSide.Database.Models;

public class Market : BusinessBase
{

    [NotMapped]
    public Dictionary<int, int> PriceItems
    {
        get { return JsonConvert.DeserializeObject<Dictionary<int, int>>(PriceItemsJson); }
        set { PriceItemsJson = JsonConvert.SerializeObject(value); }
    }
    public string PriceItemsJson { get; set; }

    public Market(int bank) : base(bank)
    {
        PriceItems = new Dictionary<int, int>()
        {
            {0,200}
        };
    }
}