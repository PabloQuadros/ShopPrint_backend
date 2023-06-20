﻿using System.ComponentModel.DataAnnotations;

namespace ShopPrint_API.Entities.DTOs;
public class BankSlipDTO : PaymentDTO
{
    [Required(ErrorMessage = "O campo CPF é obrigatório.")]
    [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O formato do CPF é inválido.")]
    public string CPF { get; set; }
    public string? bankSlipCode { get; set; }
}
