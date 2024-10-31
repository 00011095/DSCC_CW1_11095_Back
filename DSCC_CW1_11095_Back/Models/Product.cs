﻿namespace DSCC_CW1_11095_Back.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public int ProducerId { get; set; }

        public Producer Producer { get; set; }
    }
}
