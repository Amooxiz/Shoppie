﻿using System.ComponentModel.DataAnnotations;

namespace Shoppie.DataAccess.Entities
{
    public class Offer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public bool IsFinished { get; set; }
        [Range(0, 100)]
        public double Discount { get; set; } = 0;
        public DateTime CreationDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string ImagePath { get; set; }
    }
}
