﻿namespace ZMMLDotNetCore.PizzaApi.Model
{
    public class OrderRequest
    {
        public int PizzaId { get; set; }
        public int[] Extras { get; set; }
    }
}
