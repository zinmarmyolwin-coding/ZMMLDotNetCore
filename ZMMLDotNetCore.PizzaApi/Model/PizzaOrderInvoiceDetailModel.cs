﻿namespace ZMMLDotNetCore.PizzaApi.Model
{
    public class PizzaOrderInvoiceDetailModel
    {
        public int PizzaOrderDetailId { get; set; }
        public string PizzaOrderInvoiceNo { get; set; }
        public int PizzaExtraId { get; set; }
        public string PizzaExtraName { get; set; }
        public decimal Price { get; set; }
    }
}
