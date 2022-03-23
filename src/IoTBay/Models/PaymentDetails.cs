﻿using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace IoTBay.Models;
public class PaymentDetails
{
    public Guid Id { get; set; }

    [MaxLength(31)]
    public string CardName { get; set; }

    [Precision(16)]
    public decimal CardNumber { get; set; }

    [Precision(3)]
    public decimal CardCvc { get; set; }

    [Precision(2)]
    public decimal ExpiryMonth { get; set; }

    [Precision(4)]
    public decimal ExpiryYear { get; set; }

    public Customer Customer { get; set; }

    public PaymentDetails(string cardName, decimal cardNumber, decimal cardCvc, decimal expiryMonth, decimal expiryYear)
    {
        CardName = cardName;
        CardNumber = cardNumber;
        CardCvc = cardCvc;
        ExpiryMonth = expiryMonth;
        ExpiryYear = expiryYear;
    }
}