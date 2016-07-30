﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Orders.ViewModels
{
    public class OrderItemVm
    {
        public long Id { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductPriceString => string.Concat(ProductPrice.ToString("N0", new CultureInfo("vi-VN")), " VND");

        public int Quantity { get; set; }

        public decimal Total => Quantity * ProductPrice;

        public string TotalString => string.Concat(Total.ToString("N0", new CultureInfo("vi-VN")), " VND");

        public IEnumerable<ProductVariationOptionVm> VariationOptions { get; set; } =
            new List<ProductVariationOptionVm>();

        public static IEnumerable<ProductVariationOptionVm> GetVariationOption(Product variation)
        {
            if (variation == null)
            {
                return new List<ProductVariationOptionVm>();
            }

            return variation.OptionCombinations.Select(x => new ProductVariationOptionVm
            {
                OptionName = x.Option.Name,
                Value = x.Value
            });
        }
    }
}
