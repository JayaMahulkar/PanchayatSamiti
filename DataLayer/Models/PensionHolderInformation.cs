using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Models;

[Table("PensionHolderInformation")]
public partial class PensionHolderInformation
{
    [StringLength(50)]
    public string? RetirementType { get; set; }

    public string? FullName { get; set; }

    [Column("Father's / Husband'sFullName")]
    [StringLength(50)]
    public string? FatherSHusbandSFullName { get; set; }

    public string? CurrentAddress { get; set; }

    [StringLength(50)]
    public string? ReligionCaste { get; set; }

    [StringLength(50)]
    public string? Height { get; set; }

    public DateOnly? DateofBirth { get; set; }

    public string? IdentificationMark { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? MobileNumber { get; set; }

    [StringLength(50)]
    public string? AadhaarCardNumber { get; set; }

    [Column("PANCardNumber")]
    [StringLength(50)]
    public string? PancardNumber { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IsDisabilityPensionPayable { get; set; }

    [Column("AsperGovernmentRule(For Zilla Parishad Only)")]
    public string? AsperGovernmentRuleForZillaParishadOnly { get; set; }

    [Column("PensionHolder'sName")]
    public string? PensionHolderSName { get; set; }

    [Column("Pension Holder's Relationship")]
    [StringLength(50)]
    public string? PensionHolderSRelationship { get; set; }

    [Column("Pension Holder's Date of Birth")]
    public DateOnly? PensionHolderSDateOfBirth { get; set; }

    [Column("Pension Holder's Address")]
    public string? PensionHolderSAddress { get; set; }

    [Column("Percentage of Commuted Pension and Gratuity Payable – If Commuted Pension")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PercentageOfCommutedPensionAndGratuityPayableIfCommutedPension { get; set; }

    [Column("NoteRegardingCommuted Pension and Gratuity]]]")]
    public string? NoteRegardingCommutedPensionAndGratuity { get; set; }

    [Key]
    public int Id { get; set; }

    public bool? IsActive { get; set; }

    [StringLength(10)]
    public string CreatedBy { get; set; } = null!;

    [StringLength(10)]
    public string? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ModifiedDate { get; set; }

    public Guid UniqueId { get; set; }
}
