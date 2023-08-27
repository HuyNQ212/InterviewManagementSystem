using System;
using System.Collections.Generic;
using System.Text.Json;

namespace DataAccess.Models;

public partial class Offer : BaseEntity
{
    public int Id { get; set; }

    public string? ContractType { get; set; }

    public int DepartmentId { get; set; }

    public string? OfferStatus { get; set; }

    public DateTime? DueDate { get; set; }

    public decimal? BaseSalary { get; set; }

    public int? BonusRate { get; set; }

    public int ApprovedByManagerId { get; set; }

    public int PositionId { get; set; }

    public virtual User ApprovedByManager { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;

    public virtual Position Position { get; set; } = null!;

}
